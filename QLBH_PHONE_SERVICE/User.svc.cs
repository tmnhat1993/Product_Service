using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Diagnostics;
using System.Data.Entity;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "User" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select User.svc or User.svc.cs at the Solution Explorer and start debugging.
    public class User : IUser
    {
        public List<user> GetAllUser()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = (data.users.Select(p => p)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public user GetUserById(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.First(s => s.id == id);
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddUser(user user)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    data.users.Add(user);
                    data.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool UpdateUser(user user)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //Code first
                    //data.Entry(user).State = EntityState.Modified;                  
                    //data.SaveChanges();
                    //return true;
                    //////////// Code change
                    var getItem = data.users.Single(p => p.id == user.id);
                    getItem.id_role = user.id_role;
                    getItem.address = user.address;
                    getItem.email = user.email;
                    getItem.name = user.name;
                    getItem.password = user.password;
                    getItem.phone_number = user.phone_number;
                    data.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool CheckUser(string email, string pass)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.AsNoTracking()
                        .Where(u => u.email == email && u.password == pass).FirstOrDefault();
                    if (my_data == null) return false;
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool CheckEmailExisted(string email)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.AsNoTracking()
                        .Where(u => u.email == email).FirstOrDefault();
                    if (my_data == null) return false;
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public user GetUserByEmail(string email)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.AsNoTracking()
                        .Where(u => u.email == email).FirstOrDefault();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<user> FindUserByEmail(string email)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.AsNoTracking()
                        .Where(u => u.email.ToUpper().Contains(email) || u.email.ToLower().Contains(email)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<user> GetUserByName(string name)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.users.AsNoTracking()
                        .Where(u => u.name.ToUpper().Contains(name) || u.name.ToLower().Contains(name)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public bool DeleteUser(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var user = data.users.Single(u => u.id == id);
                    var exportBill = data.export_bill.Where(e => e.id_user == id).ToList();
                    foreach (var item in exportBill)
                    {
                        var exportBill_Detail = data.export_bill_detail.Where(e => e.id_export_bill == item.id).ToList();
                        foreach (var item2 in exportBill_Detail)
                        {
                            data.export_bill_detail.Remove(item2);                          
                        }
                        data.export_bill.Remove(item);
                    }
                    data.users.Remove(user);
                    data.SaveChanges();
                    return true;                 
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
