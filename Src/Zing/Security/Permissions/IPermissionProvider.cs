﻿using System.Collections.Generic;
using Zing.Environment.Extensions.Models;

namespace Zing.Security.Permissions {
    /// <summary>
    /// Implemented by modules to enumerate the types of permissions
    /// the which may be granted
    /// </summary>
    public interface IPermissionProvider : IDependency {
        Feature Feature { get; }
        IEnumerable<Permission> GetPermissions();
        IEnumerable<PermissionStereotype> GetDefaultStereotypes();
    }

    public class PermissionStereotype {
        public string Name { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}