using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.Models.MetricsDto
{
    public class CpuResponse: BaseResponse
    {
        public double Value { get; set; }
        public long Dt { get; set; }
        public CpuResponse() : base() { }
    }
}
