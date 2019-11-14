using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.Core
{
    public class MenuEntity
    {
        public MenuEntity()
        {
            this.MembershipsMenus = new List<MembershipMenuEntity>();
            this.Menus = new List<MenuEntity>();
        }

        public int ID { get; set; }
        public int ModuleID { get; set; }
        public string Denomination { get; set; }
        public string URL { get; set; }
        public string Photography { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }
        public string Initials { get; set; }
        public string Aux { get; set; }
        public int? OrderNumber { get; set; }
        public int? ParentMenuID { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDelete { get; set; }
        public string ChangeType { get; set; }
        public string HostnameCreated { get; set; }
        public string IPAddressCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string HostnameUpdated { get; set; }
        public string IPAddressUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ModuleEntity Module { get; set; }
        public virtual MenuEntity ParentMenu { get; set; }
        public virtual ICollection<MembershipMenuEntity> MembershipsMenus { get; set; }
        public virtual ICollection<MenuEntity> Menus { get; set; }
    }
}
