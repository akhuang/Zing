using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Mvc;

namespace Zing.Modules.Customer.ViewModels
{
    public class CustomerViewModel
    {
        public long Id
        {
            get; set;
        }

        public string CustKey
        {
            get; set;
        }

        public string CustName
        {
            get;
            set;
        }

        /// <summary>
        /// 客户类型   如：会员、代理商等
        /// </summary>
        public int? TypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户全名
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// 客户地址
        /// </summary>
        public string CustAbbr
        {
            get;
            set;
        }
        /// <summary>
        /// 客户搜索名（除去关键字后的客户名字）
        /// </summary>
        public string SearchName
        {
            get;
            set;
        }

        /// <summary>
        /// 联系周期
        /// </summary>
        public int? ContactCycle
        {
            get;
            set;
        }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags
        {
            get;
            set;
        }

        /// <summary>
        /// 客户优先级
        /// </summary>
        public int? PriorityCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户电话类型
        /// </summary>
        public int? PhoneTypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 电话号码，主电话号码
        /// </summary>
        public string PhoneNo
        {
            get;
            set;
        }

        /// <summary>
        /// 传真号
        /// </summary>
        public string Fax
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? CustStatusCD
        {
            get;
            set;
        }

        /// <summary>
        /// 客户关闭日期时间
        /// </summary>
        public DateTime? CloseDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool IsClose
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭员工ID
        /// </summary>
        public string CloserID
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭员工名字
        /// </summary>
        public string CloserName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public int? IsDel
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 客户来源
        /// </summary>
        public int? SourceCD
        {
            get;
            set;
        }

        /// <summary>
        /// 主页
        /// </summary>
        public string HomePage
        {
            get;
            set;
        }
    }

    public class CustomerViewModelMetadata : ModelMetadataConfiguration<CustomerViewModel>
    {
        public CustomerViewModelMetadata()
        {

        }
    }
}
