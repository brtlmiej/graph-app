using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    /// <summary>
    /// Logical graph connection representation
    /// </summary>
    public class Connection
    {
        public int Id { get; set; }
        public Vertex Begin { get; set; }
        public Vertex End { get; set; }
        static int AutoIncrement = 1;

        public Connection()
        {
            Id = AutoIncrement;
            AutoIncrement++;
        }

        /// <summary>
        /// Check if Connection includes given <c>Vertex</c>
        /// </summary>
        /// <param name="vertex">Vertex to check</param>
        /// <returns>true if connection includes given Vertex, otherwise false</returns>
        public bool Includes(Vertex vertex)
        {
            return Begin.Id == vertex.Id || End.Id == vertex.Id;
        }

        /// <summary>
        /// Get neighbor <c>Vertex</c>
        /// </summary>
        /// <param name="vertex">Vertex to check</param>
        /// <returns><c>Vertex</c> or null value if connection doesn't include given Vertex</returns>
        public Vertex Neighbor(Vertex vertex)
        {
            if (Begin.Id == vertex.Id)
                return End;
            else if (End.Id == vertex.Id)
                return Begin;
            return null;
        }
    }
}
