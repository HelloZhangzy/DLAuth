using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.Base.Model
{
    public class DBInit : CreateDatabaseIfNotExists<DLAuthContext>
    {
        private Guid UserID = Guid.Empty;
        private Guid OrgID = Guid.Empty;
        private Guid RoleID = Guid.Empty;

        protected override void Seed(DLAuthContext context)
        {
            

            context.Users.AddRange(GetUser());
            context.Menus.AddRange(GetMenu());
            context.Roles.AddRange(GetRole());
            context.Organizations.AddRange(GetOrg());
            context.SaveChanges();
            context.UserRoles.AddRange(GetUserRole());
            context.OrgUsers.AddRange(GetOrgUser());
            context.SaveChanges();

            base.Seed(context);
        }

        public List<User> GetUser()
        {
            UserID = Guid.NewGuid();
            return new List<User>()
            {
                new User{
                        UserCode =UserID
                        ,UserName="Admin"
                        ,UserExplain=""
                        ,Sex=0
                        ,LoginCode="admin"
                        ,LoginPass="admin"
                        ,ibState=true
                        ,LoginCount=0
                        ,LastLoginDate=null
                        ,CreateUserCode=null
                        ,CreaterDate=DateTime.Now
                        ,UpdateDate=null
                        ,UpdateUserCode=null
                }

            };
        }

        public List<Menu> GetMenu()
        {
            Guid SysSetID = Guid.Empty;
            return new List<Menu>()
            {
                new Menu
                {
                    MenuCode=Guid.NewGuid(),
                    ParentMenuCode=SysSetID,
                    SortNo = 0,
                    MenuName="系统设置",
                    MenuExplain="",
                    Url="",
                    IsVisible=true,
                    IsEnable=false,
                    CreateUserCode=UserID,
                    CreaterDate=DateTime.Now,
                    UpdateDate=null,
                    UpdateUserCode=null
                },                
                new Menu
                {
                    MenuCode=Guid.NewGuid(),
                    ParentMenuCode=SysSetID,
                    SortNo = 0,
                    MenuName="机构管理",
                    MenuExplain="",
                    Url="/Org/Index",
                    IsVisible=true,
                    IsEnable=false,
                    CreateUserCode=UserID,
                    CreaterDate=DateTime.Now,
                    UpdateDate=null,
                    UpdateUserCode=null
                },
                new Menu
                {
                    MenuCode=Guid.NewGuid(),
                    ParentMenuCode=SysSetID,
                    SortNo = 0,
                    MenuName="角色管理",
                    MenuExplain="",
                    Url="/Role/Index",
                    IsVisible=true,
                    IsEnable=false,
                    CreateUserCode=UserID,
                    CreaterDate=DateTime.Now,
                    UpdateDate=null,
                    UpdateUserCode=null
                },
                new Menu
                {
                    MenuCode=Guid.NewGuid(),
                    ParentMenuCode=SysSetID,
                    SortNo = 0,
                    MenuName="用户管理",
                    MenuExplain="",
                    Url="/User/Index",
                    IsVisible=true,
                    IsEnable=false,
                    CreateUserCode=UserID,
                    CreaterDate=DateTime.Now,
                    UpdateDate=null,
                    UpdateUserCode=null
                },
                new Menu
                {
                    MenuCode=Guid.NewGuid(),
                    ParentMenuCode=SysSetID,
                    SortNo = 0,
                    MenuName="菜单管理",
                    MenuExplain="",
                    Url="/Memu/Index",
                    IsVisible=true,
                    IsEnable=false,
                    CreateUserCode=UserID,
                    CreaterDate=DateTime.Now,
                    UpdateDate=null,
                    UpdateUserCode=null
                }
            };
        }

        public List<Role> GetRole()
        {
            RoleID = Guid.Empty;
            return new List<Role>()
            {
                new Role(){
                        RoleCode=RoleID,
                        SortNo =0,
                        RoleName="超级管理员",
                        RoleExplain="",
                        CreateUserCode =UserID,
                        CreaterDate=DateTime.Now,
                        UpdateUserCode =null,
                        UpdateDate=null
                }
            };
        }

        public List<Organization> GetOrg()
        {
            OrgID = Guid.NewGuid();
            return new List<Organization>()
            {
                new Organization(){
                                    OrgCode =OrgID,
                                    ParentCode = Guid.Empty,
                                    OrgName = "本部",
                                    OrgExplain = "",
                                    CreateUserCode = UserID,
                                    CreaterDate = DateTime.Now,
                                    UpdateDate = null,
                                    UpdateUserCode = null
                }
            };
        }

        public List<OrgUser> GetOrgUser()
        {
            return new List<OrgUser>()
            {
                new OrgUser(){
                   ID=Guid.NewGuid(),
                   OrgCode=OrgID,
                   UserCode=UserID
                }
            };
        }       

        public List<UserRole> GetUserRole()
        {
            return new List<UserRole>()
            {
                new UserRole(){
                      ID=Guid.NewGuid(),
                      UserCode=UserID,
                      RoleCode=RoleID
                }
            };
        }            

    }
}
