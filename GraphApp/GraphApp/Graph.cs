using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    /// <summary>
    /// Logical graph representation
    /// </summary>
    public class Graph
    {
        public ObservableCollection<Vertex> Vertices { get; set; }
        public ObservableCollection<Connection> Connections { get; set; }

        public Graph(): base()
        {
            Vertices = new ObservableCollection<Vertex>();
            Connections = new ObservableCollection<Connection>();
        }

        public void Clear()
        {
            Vertices.Clear();
            Connections.Clear();
        }

        /// <summary>
        /// Find <c>Connection</c> by given id
        /// </summary>
        /// <param name="id">Connection id</param>
        /// <returns>Connection or null</returns>
        public Connection FindConnection(int id)
        {
            return Connections.Where((Connection c) => c.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Find <c>Vertex</c> by given id
        /// </summary>
        /// <param name="id"><c>Vertex</c> id</param>
        /// <returns> Vertex or null</returns>
        public Vertex FindVertex(int id)
        {
            return Vertices.Where((Vertex v) => v.Id == id).FirstOrDefault();
        }
    }
}
