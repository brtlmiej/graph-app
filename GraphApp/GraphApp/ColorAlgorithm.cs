using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    public enum AlgorithmType
    {
        BaseAlgorithm,
        LFAlgorithm,
        SLFAlgorithm
    }
    public class ColorAlgorithm
    {
        public AlgorithmType Type { get; set; }
        public string DisplayText { get; set; }
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
