using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AgentInfo: BaseEntity
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
