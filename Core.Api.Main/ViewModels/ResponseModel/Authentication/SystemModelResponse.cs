using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel.Authentication
{
    public class SystemModelResponse
    {
        public SystemModelResponse()
        {
            this.Modules = new List<ModuleModelResponse>();
        }

        public int ID { get; set; }
        public string Denomination { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }
        public string Initials { get; set; }
        public string Aux { get; set; }
        public int? OrderNumber { get; set; }
        public virtual ICollection<ModuleModelResponse> Modules { get; set; }

    }
}
