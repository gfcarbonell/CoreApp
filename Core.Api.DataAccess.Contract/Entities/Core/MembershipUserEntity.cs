﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.Core
{
    public class MembershipUserEntity
    {
        public int MembershipID { get; set; }
        public int UserID { get; set; }
        public int? PriorityNumber { get; set; }
        public int? OrderNumber { get; set; }
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

        public virtual MembershipEntity Membership { get; set; }
        public virtual UserEntity User { get; set; }

    }
}
