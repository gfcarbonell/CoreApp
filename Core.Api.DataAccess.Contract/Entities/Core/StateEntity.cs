using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.Core
{
    public class StateEntity
    {
        public StateEntity()
        {
            this.Users = new List<UserEntity>();
        }

        public int ID { get; set; }
        public string Denomination { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }
        public string Initials { get; set; }
        public string Aux { get; set; }
        public int? OrderNumber { get; set; }
        public int? StateGroupID { get; set; }
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

        public virtual StateGroupEntity StateGroup { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }

}
