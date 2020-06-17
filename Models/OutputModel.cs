using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrisAPI.Models
{
    public class OutputModel
    {
        public float SepalLength { get; set; }
        public float SepalWidth { get; set; }
        public float PetalLength { get; set; }
        public float PetalWidth { get; set; }
        public uint ClusterId { get; set; }

        public OutputModel(InputModel inputModel, uint cluster)
        {
            SepalLength = inputModel.SepalLength;
            SepalWidth = inputModel.SepalWidth;
            PetalLength = inputModel.PetalLength;
            PetalWidth = inputModel.PetalWidth;
            ClusterId = cluster;
        }
    }
}
