using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUser" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        bool CheckUser(string email, string pass);
        [OperationContract]
        bool CheckEmailExisted(string email);
        [OperationContract]
        //[WebGet(UriTemplate = "UserGerAll/", ResponseFormat = WebMessageFormat.Json)]
        List<user> GetAllUser();
        [OperationContract]
        //[WebGet(UriTemplate = "UserGetId?id={id}", ResponseFormat = WebMessageFormat.Json)]
        user GetUserById(int id);
        [OperationContract]
        user GetUserByEmail(string email);
        [OperationContract]
        List<user> FindUserByEmail(string email);
        [OperationContract]
        List<user> GetUserByName(string name);
        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "UserPost", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddUser(user user);
        [OperationContract]
        //[WebInvoke(Method = "PUT", UriTemplate = "UserPut", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool UpdateUser(user user);
        [OperationContract]
        bool DeleteUser(int id);
    }
}
