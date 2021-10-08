using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerServices.Models.Dto
{
    public abstract class BaseDto<TResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TResponse> Content { get; set; }
    }
}
