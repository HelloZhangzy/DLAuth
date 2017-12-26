using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLiteAuthFrame.APP.ViewModel;

namespace DLiteAuthFrame.APP.APP
{
    public class RoleManageApp: IRoleManageApp
    {
        public IRoleRepository _role { get; set; }

        public ResultModel AddRole(RoleViewModel Info)
        {
            throw new NotImplementedException();
        }

        public ResultModel DeleteRole(Guid ID)
        {
            throw new NotImplementedException();
        }

        public ResultModel RoleSetAuth(Guid ID, List<Guid> Auths)
        {
            throw new NotImplementedException();
        }

        public ResultModel UpdateRole(RoleViewModel Info)
        {
            throw new NotImplementedException();
        }
    }
}
