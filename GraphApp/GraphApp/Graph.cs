using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    class Graph: BaseModel
    {
        Random randomizer;
        public List<Vertex> Vertices { get; set; }
        public List<Connection> Connections { get; set; }

        public Graph(): base()
        {
            randomizer = new Random();
        }

        public Vertex FindVertex(int id)
        {
            return Vertices.Find((Vertex v) => v.Id == id);
        }

        public void AddVertex()
        {
            Vertices.Add(new Vertex() {
                X = randomizer.Next(1, 100),
                Y = randomizer.Next(1, 100),
                Color = 0
            });
        }

        public void RemoveVertex(Vertex vertex)
        {
            foreach(var connection in vertex.Connections)
            {
                Connections.Remove(connection);
            }
            Vertices.Remove(vertex);
        }

        public Connection FindConnection(int id)
        {
            return Connections.Find((Connection c) => c.Id == id);
        }

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

        public void RemoveConnection(Connection connection)
        {
            Connections.Remove(connection);
            connection.Begin.Connections.Remove(connection);
            connection.End.Connections.Remove(connection);
        }
    }
}
