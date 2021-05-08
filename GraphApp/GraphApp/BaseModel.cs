using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        static int AutoIncrement = 1;
        public BaseModel()
        {
            Id = AutoIncrement;
            AutoIncrement++;
        }
    }
}
