using MetricsManagerServices.Models.MetricsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.Models.Dto
{
    public class CpuDto: BaseDto<CpuResponse>
    {
        public CpuDto() : base() { }
        public CpuDto(long id, List<CpuResponse> content) : base()
        {
            Id = id;
            Content = content;
        }

    }
}
