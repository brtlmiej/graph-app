using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    /// <summary>
    /// Logical graph representation
    /// </summary>
    public class Graph: BaseModel
    {
        public List<Vertex> Vertices { get; set; }
        public List<Connection> Connections { get; set; }

        public Graph(): base()
        {
            Vertices = new List<Vertex>();
            Connections = new List<Connection>();
        }
        /// <summary>
        /// Find <c>Vertex</c> by given id
        /// </summary>
        /// <param name="id"><c>Vertex</c> id</param>
        /// <returns> Vertex or null</returns>
        public Vertex FindVertex(int id)
        {
            return Vertices.Find((Vertex v) => v.Id == id);
        }

        /// <summary>
        /// Add new <c>Vertex</c> to graph
        /// </summary>
        /// <param name="x">vertex x position</param>
        /// <param name="y">vartex y position</param>
        public void AddVertex(int x, int y)
        {
            Vertices.Add(new Vertex() {
                X = x,
                Y = y,
                Color = 0
            });
        }

        /// <summary>
        /// Remove vertex from graph.
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        public void RemoveVertex(Vertex vertex)
        {
            foreach(var connection in vertex.Connections)
            {
                Connections.Remove(connection);
            }
            Vertices.Remove(vertex);
        }

        /// <summary>
        /// Find <c>Connection</c> by given id
        /// </summary>
        /// <param name="id">Connection id</param>
        /// <returns>Connection or null</returns>
        public Connection FindConnection(int id)
        {
            return Connections.Find((Connection c) => c.Id == id);
        }

        /// <summary>
        /// Add new connection to graph.
        /// </summary>
        /// <param name="begin">Connection's begining vertex</param>
        /// <param name="end">Connection's end vertex</param>
        public void AddConnection(Vertex begin, Vertex end)
        {
            var connection = new Connection()
            {
                Begin = begin,
                End = end
            };

            Connections.Add(connection);
            begin.Connections.Add(connection);
            end.Connections.Add(connection);
        }

        /// <summary>
        /// Remove Connection from graph
        /// </summary>
        /// <param name="connection">Connection to remove</param>
        public void RemoveConnection(Connection connection)
        {
            Connections.Remove(connection);
            connection.Begin.Connections.Remove(connection);
            connection.End.Connections.Remove(connection);
        }
    }
}
