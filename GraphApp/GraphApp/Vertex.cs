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
    public class Vertex: BaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Color { get; set; }
        public List<Connection> Connections { get; set; }
        public Vertex(): base()
        {
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
    }
}
