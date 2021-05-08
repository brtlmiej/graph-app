using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    public class Connection: BaseModel
    {
        public Vertex Begin { get; set; }
        public Vertex End { get; set; }

        public Connection(): base()
        {

        }

        /// <summary>
        /// Check if Connection includes given <c>Vertex</c>
        /// </summary>
        /// <param name="vertex">Vertex to check</param>
        /// <returns><c>bool</c></returns>
        public bool Includes(Vertex vertex)
        {
            return Begin.Id == vertex.Id || End.Id == vertex.Id;
        }

        /// <summary>
        /// Get neighbor vertex id
        /// </summary>
        /// <param name="vertex">Vertex to check</param>
        /// <returns>int | null</returns>
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
