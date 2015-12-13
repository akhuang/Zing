using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Modules.Users.Models;
using Zing.Mvc;

namespace Zing.Modules.Users.ViewModels
{
    public class UserViewModel
    {
        static UserViewModel()
        {
            Mapper.CreateMap<UserViewModel, UserEntity>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Category { get; set; }
    }

    public class UserViewModelMetadata : ModelMetadataConfiguration<UserViewModel>
    {
        public UserViewModelMetadata()
        {
            Configure(x => x.UserName)
                .DisplayName("用户姓名")
                .Required();

            Configure(x => x.Email)
                .DisplayName("Email")
                .AsEmail()
                .Required();

            Configure(x => x.NormalizedUserName)
                .DisplayName("用户登录名");

            Configure(x => x.Password)
                .DisplayName("密码").Hide()
                .AsPassword()
                .MaximumLength(50)
                .MinimumLength(7);

            Configure(x => x.ConfirmPassword)
                .DisplayName("确认密码").Hide()
                .AsPassword()
                .Compare("Password");

            Configure(x => x.Category).AsDropDownList("aaaa").Required();
        }
    }
}
