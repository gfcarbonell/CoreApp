﻿using Core.Api.DataAccess.Contract.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.Contract.Entities.Core
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Nickname { get; set; }
        public int? UserGroupID { get; set; }
        public int StateID { get; set; }
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

        public virtual UserGroupEntity UserGroup { get; set; }
        public virtual StateEntity State { get; set; }
        public virtual ICollection<UserSessionEntity> UserSessions { get; set; }
    }
}
