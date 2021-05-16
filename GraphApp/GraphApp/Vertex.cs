using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    /// <summary>
    /// Logical graph vertex representation
    /// </summary>
    public class Vertex
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Color { get; set; }
        public List<Connection> Connections { get; set; }
        static int AutoIncrement = 1;
        public Vertex()
        {
            Id = AutoIncrement;
            AutoIncrement++;
            Connections = new List<Connection>();
        }

        /// <summary>
        /// Get all Vertices that are connected to this <c>Vertex</c>
        /// </summary>
        /// <returns>List of Vertices</returns>
        public List<Vertex> GetAllNeighbors()
        {
            var neighbors = new List<Vertex>();

            foreach (var connection in Connections)
            {
                neighbors.Add(connection.Neighbor(this));
            }
            return neighbors;
        }

        public override string ToString()
        {
            return "wierzchołek " + Id;
        }
    }
}
