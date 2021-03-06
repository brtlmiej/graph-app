using GraphApp.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    public class GraphService
    {
        Random randomizer;

        public GraphService()
        {
            randomizer = new Random();
        }

        /// <summary>
        /// Create new <c>Vertex</c> and add it to graph
        /// </summary>
        /// <param name="graph">Graph</param>
        /// <returns>new vertex</returns>
        /// 
        public Vertex CreateVertex(Graph graph, int maxWidth, int maxHeight)
        {
            int xPos, yPos;
            do
            {
                xPos = randomizer.Next(maxWidth - DrawConstants.ELLIPSE_SIZE);
                yPos = randomizer.Next(maxHeight - DrawConstants.ELLIPSE_SIZE);
            } while (!isValidPosition(graph, xPos, yPos));

            var vertex = new Vertex()
            {
                X = xPos,
                Y = yPos,
                Color = 0
            };

            graph.Vertices.Add(vertex);
            return vertex;
        }

        /// <summary>
        /// Remove vertex from graph.
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        public void RemoveVertex(Graph graph, Vertex vertex)
        {
            foreach (var connection in vertex.Connections)
            {
                graph.Connections.Remove(connection);
            }
            graph.Vertices.Remove(vertex);
        }

        /// <summary>
        /// Add new connection to graph.
        /// </summary>
        /// <param name="begin">Connection's begining vertex</param>
        /// <param name="end">Connection's end vertex</param>
        /// <returns>new connection</returns>
        public Connection CreateConnection(Graph graph, Vertex begin, Vertex end)
        {
            var connection = new Connection()
            {
                Begin = begin,
                End = end
            };

            graph.Connections.Add(connection);
            begin.Connections.Add(connection);
            end.Connections.Add(connection);

            return connection;
        }

        /// <summary>
        /// Remove Connection from graph
        /// </summary>
        /// <param name="connection">Connection to remove</param>
        public void RemoveConnection(Graph graph, Connection connection)
        {
            graph.Connections.Remove(connection);
            connection.Begin.Connections.Remove(connection);
            connection.End.Connections.Remove(connection);
        }

        /// <summary>
        /// Color graph with base algorithm and get used colors
        /// </summary>
        /// <param name="graph">Graph</param>
        /// <returns>list of colors numbers</returns>
        public List<int> colorGraphWithBaseAlgorithm(Graph graph)
        {
            List<int> usedColors = new List<int>();
            foreach(var vertice in graph.Vertices)
            {
                int color = 1;
                List<int> neighborColors = vertice.GetAllNeighbors().Select(n => n.Color).ToList();
                while(true)
                {
                    if (!neighborColors.Contains(color))
                        break;
                    color++;
                }
                usedColors.Add(color);

                vertice.Color = color;
            }
            return usedColors;
        }


        /// <summary>
        /// Color graph with SLF algorithm and get used colors
        /// </summary>
        /// <param name="graph">Graph</param>
        /// <returns>list of colors numbers</returns>
        public List<int> colorGraphWithSLFAlgorithm(Graph graph)
        {
            List<int> usedColors = new List<int>();
            var vertice = graph.Vertices
                .Where(v => v.Color == 0)
                .OrderByDescending(v => v.GetAllNeighbors().Select(n => n.Color).Distinct().ToList().Count)
                .ThenByDescending(v => v.GetAllNeighbors().Count)
                .FirstOrDefault();

            while (vertice != null)
            {
                int color = 1;
                List<int> neighborColors = vertice.GetAllNeighbors().Select(n => n.Color).ToList();
                while (true)
                {
                    if (!neighborColors.Contains(color))
                        break;
                    color++;
                }
                usedColors.Add(color);

                vertice.Color = color;
                vertice = graph.Vertices
                    .Where(v => v.Color == 0)
                    .OrderByDescending(v => v.GetAllNeighbors().Select(n => n.Color).Distinct().ToList().Count)
                    .ThenByDescending(v => v.GetAllNeighbors().Count)
                    .FirstOrDefault();
            }
            return usedColors;
        }


        /// <summary>
        /// Color graph with LF algorithm and get used colors
        /// </summary>
        /// <param name="graph">Graph</param>
        /// <returns>list of colors numbers</returns>
        public List<int> colorGraphWithLFAlgorithm(Graph graph)
        {
            List<int> usedColors = new List<int>();
            foreach (var vertice in graph.Vertices.OrderByDescending(v => v.GetAllNeighbors().Count))
            {
                int color = 1;
                List<int> neighborColors = vertice.GetAllNeighbors().Select(n => n.Color).ToList();
                while (true)
                {
                    if (!neighborColors.Contains(color))
                        break;
                    color++;
                }
                usedColors.Add(color);

                vertice.Color = color;
            }
            return usedColors;
        }

        public void ClearGraphVerticesColors(Graph graph)
        {
            foreach(var vertex in graph.Vertices)
            {
                vertex.Color = 0;
            }
        }

        private bool isValidPosition(Graph graph, int xPos, int yPos)
        {
            foreach(var vertex in graph.Vertices)
                if (Math.Abs(vertex.X - xPos) < DrawConstants.SPACE_BETWEEN_ELLIPSES)
                    return false;
                else if (Math.Abs(vertex.Y - yPos) < DrawConstants.SPACE_BETWEEN_ELLIPSES)
                    return false;

            return true;
        }
    }
}
