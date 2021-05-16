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
        /// Find <c>Connection</c> by given id
        /// </summary>
        /// <param name="id">Connection id</param>
        /// <returns>Connection or null</returns>
        public Connection FindConnection(int id)
        {
            return Connections.Find((Connection c) => c.Id == id);
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
    }
}
