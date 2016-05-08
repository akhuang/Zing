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
    public class AteEntity : Entity
    {
        public virtual string AteName { get; set; }
    }

    public class AteEntityOverride : IAutoMappingOverride<AteEntity>
    {
        public void Override(AutoMapping<AteEntity> mapping)
        {
            mapping.Table("Ate");
            //mapping.   
        }
    }
}
