using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.DomainModel;

namespace Zing.Modules.Test.Models
{
    public class UserAteRelEntity : Entity
    {
        public virtual string UserId { get; set; }
        public virtual string AteName { get; set; }
    }

    public class UserAteRelEntityOverride : IAutoMappingOverride<UserAteRelEntity>
    {
        public void Override(AutoMapping<UserAteRelEntity> mapping)
        {
            mapping.Table("UserAteRel");
            //mapping.   
        }
    }
}
