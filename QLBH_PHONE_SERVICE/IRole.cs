using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRole" in both code and config file together.
    [ServiceContract]
    public interface IRole
    {
        [OperationContract]
        List<role> GetAllRole();
        [OperationContract]
        role GetRoleWithId(int id);
        [OperationContract]
        bool AddRole(role s);
        [OperationContract]
        bool UpdateRole(role s);
    }
}
