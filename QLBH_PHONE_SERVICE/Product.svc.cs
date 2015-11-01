using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Diagnostics;
using System.Data;
using System.Data.Entity;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Product" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Product.svc or Product.svc.cs at the Solution Explorer and start debugging.
    public class Product : IProduct
    {
        public product GetProductById(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.First(s => s.id == id);
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetAllProduct()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = (data.products.Select(p => p)).ToList();
      
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddProduct(product product)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    data.products.Add(product);
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

        public bool UpdateProduct(product product)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //data.products.Attach(product);
                    //data.Entry(product).State = EntityState.Modified;
                    //getItem.id = product.id;
                    var getItem = data.products.Single(p => p.id == product.id);//get the specific product
                                        
                    getItem.id_manufacturer = product.id_manufacturer;

                    getItem.id_save = product.id_save;
                     
                    getItem.name = product.name;
                    
                    getItem.sale_price = product.sale_price;
                     
                    getItem.number = product.number;
                     
                    getItem.image = product.image;
                    
                    getItem.product_info = product.product_info;
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

        public List<product> GetProductByName(string n)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking()
                        .Where(p => p.name.ToUpper().Contains(n) || p.name.ToLower().Contains(n)).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetProductByIdManu(int idManu)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking().Where(p => p.id_manufacturer == idManu).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetProductByNameManu(string nameManu)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking().Where(p => p.manufacturer.name == nameManu).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetProductByIdManuAndNameProduct(int idManu, string namePro)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking()
                        .Where(p => p.id_manufacturer == idManu && p.name.Contains(namePro)).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetAllProductOrByNameManu(string nManu)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking()
                        .Where(p => p.manufacturer.name == nManu || nManu == null).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public List<product> GetNewProduct()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking().OrderByDescending(p => p.id)
                        .Take(18).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<product> GetProductSave()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_product = data.products.AsNoTracking()
                        .OrderByDescending(p => p.save.percent_save).Take(18).ToList();
                    return my_product;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public bool DeleteProduct(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var product = data.products.Single(p => p.id == id);
                    var exportBill_Detail = data.export_bill_detail.Where(e => e.id_product == id).ToList();
                    foreach(var item in exportBill_Detail)
                    {
                        data.export_bill_detail.Remove(item);
                    }
                    var importBill_Detail = data.import_bill_detail.Where(i => i.id_product == id).ToList();
                    foreach (var item in importBill_Detail)
                    {
                        data.import_bill_detail.Remove(item);
                    }
                    data.products.Remove(product);
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
