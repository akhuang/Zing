using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using Zing.DomainModel;

namespace Zing.Modules.Customer.Models
{
    public class CustomerEntity : Entity
    { 
        public virtual string CustKey
        {
            get; set;
        }

        public virtual string CustName
        {
            get;
            set;
        }

        /// <summary>
        /// 客户类型   如：会员、代理商等
        /// </summary>
        public virtual int? TypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户全名
        /// </summary>
        public virtual string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// 客户地址
        /// </summary>
        public virtual string CustAbbr
        {
            get;
            set;
        }
        /// <summary>
        /// 客户搜索名（除去关键字后的客户名字）
        /// </summary>
        public virtual string SearchName
        {
            get;
            set;
        }

        /// <summary>
        /// 联系周期
        /// </summary>
        public virtual int? ContactCycle
        {
            get;
            set;
        }

        /// <summary>
        /// 标签
        /// </summary>
        public virtual string Tags
        {
            get;
            set;
        }

        /// <summary>
        /// 客户优先级
        /// </summary>
        public virtual int? PriorityCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户电话类型
        /// </summary>
        public virtual int? PhoneTypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 电话号码，主电话号码
        /// </summary>
        public virtual string PhoneNo
        {
            get;
            set;
        }

        /// <summary>
        /// 传真号
        /// </summary>
        public virtual string Fax
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int? CustStatusCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户关闭日期时间
        /// </summary>
        public virtual DateTime? CloseDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否关闭
        /// </summary>
        public virtual bool IsClose
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭员工ID
        /// </summary>
        public virtual string CloserID
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭员工名字
        /// </summary>
        public virtual string CloserName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public virtual int? IsDel
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 客户来源
        /// </summary>
        public virtual int? SourceCD
        {
            get;
            set;
        }

        /// <summary>
        /// 主页
        /// </summary>
        public virtual string HomePage
        {
            get;
            set;
        }
    }

    public class CustomerOverride : IAutoMappingOverride<CustomerEntity>
    {
        public void Override(AutoMapping<CustomerEntity> mapping)
        {
            mapping.Table("Customer");
            //mapping.   
        }
    }
}
