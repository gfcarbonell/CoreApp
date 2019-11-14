using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel.Authentication
{
    public class ModuleModelResponse
    {
        public ModuleModelResponse()
        {
            this.Menus = new List<MenuModelResponse>();
        }

        public int ID { get; set; }
        public int SystemID { get; set; }
        public string Denomination { get; set; }
        public string URL { get; set; }
        public string Photography { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }
        public string Initials { get; set; }
        public string Aux { get; set; }
        public int? OrderNumber { get; set; }

        public virtual SystemModelResponse System { get; set; }
        public virtual ICollection<MenuModelResponse> Menus { get; set; }
    }
}
