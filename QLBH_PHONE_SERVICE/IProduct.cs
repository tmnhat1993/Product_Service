using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.ServiceModel.Web;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProduct" in both code and config file together.
    [ServiceContract]
    public interface IProduct
    {
        [OperationContract]
        //[WebGet(UriTemplate = "ProductGetId?id={id}", ResponseFormat = WebMessageFormat.Xml)]
        product GetProductById(int id);
        //[OperationContract]
        //[WebGet(UriTemplate = "ProductGetPage?manufacturer={m}&page={p}")]

        [OperationContract]
        //[WebGet(UriTemplate="ProductGetAll/", ResponseFormat = WebMessageFormat.Xml)]
        List<product> GetAllProduct();

        [OperationContract]
        List<product> GetProductByName(string n);
        [OperationContract]
        List<product> GetProductByIdManu(int idManu);
        [OperationContract]
        List<product> GetProductByNameManu(string nameManu);
        [OperationContract]
        List<product> GetProductByIdManuAndNameProduct(int idManu, string namePro);
        [OperationContract]
        List<product> GetAllProductOrByNameManu(string nManu);
        [OperationContract]
        List<product> GetNewProduct();
        [OperationContract]
        List<product> GetProductSave();
        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "ProductPost")]
        bool AddProduct(product product);

        [OperationContract]
        //[WebInvoke(Method = "PUT", UriTemplate = "ProductPut")]
        bool UpdateProduct(product product);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE", UriTemplate = "ProductDel/{id}", ResponseFormat = WebMessageFormat.Json)]
        //void DeleteProduct(int id);
        [OperationContract]
        bool DeleteProduct(int id);
    }
}
