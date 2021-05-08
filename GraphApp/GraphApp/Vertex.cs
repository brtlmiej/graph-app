using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
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
