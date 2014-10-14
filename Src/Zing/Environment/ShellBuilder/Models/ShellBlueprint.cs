using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.Descriptor.Models;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.ShellBuilder.Models
{
    public class ShellBlueprint
    {
        public ShellSettings Settings { get; set; }
        public ShellDescriptor Descriptor { get; set; }

        public IEnumerable<DependencyBlueprint> Dependencies { get; set; }

        public IEnumerable<RecordBlueprint> Records { get; set; }
    }
    public class DependencyBlueprint : ShellBlueprintItem
    {
        public IEnumerable<ShellParameter> Parameters { get; set; }
    }
    public class ShellBlueprintItem
    {
        public Type Type { get; set; }
        public Feature Feature { get; set; }
    }

    /// <summary>
    /// 此类主要收集所有的实体类的表名, 在CompositionStrategy的BuildRecord方法将模块名附加到类名上
    /// 如果你定义的类名为UserEntity, 原方法得到的就是Zing_Module_UserEntity
    /// 现修改为不附加模块名
    /// </summary>
    public class RecordBlueprint : ShellBlueprintItem
    {
        public string TableName { get; set; }
    }
}
