using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for PersonService_
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class PersonService_ : System.Web.Services.WebService {
    
    dsVisitorProductsTableAdapters.VisitorProductsTableAdapter taVisitorProduct = new dsVisitorProductsTableAdapters.VisitorProductsTableAdapter();
    //dsVisitorProducts.VisitorProductsDataTable dtVisitorProduct;

    public PersonService_ () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 

        string VisitorId = Session["NewGuid"].ToString();
        int ProductId = 38;// Convert.ToInt16(Request.Form.Get("ProductId"));  //Convert.ToInt16(Request.QueryString["ProductId"]);
        
        taVisitorProduct.Delete(VisitorId, ProductId);
               

    }

    [WebMethod]
    public string GetPerson()
    {
        return "Hello World";
    }
    
}
