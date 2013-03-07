using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class MasterProductInquiry : System.Web.UI.MasterPage
{
    dsVisitorProductsTableAdapters.VisitorProductsTableAdapter taVisitorProduct = new dsVisitorProductsTableAdapters.VisitorProductsTableAdapter();
    dsVisitorProducts.VisitorProductsDataTable dtVisitorProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                Response.Redirect("productviewgallery.aspx?dispid=idPrdDipCategoryWise&pv=productviewgallery");
            }
        }

        IsThisProductSelectedForCart(Convert.ToInt16(Request.QueryString["ProductId"]));
    }

    private void SaveInVisitorQuotation()
    {
        string VisitorId=Session["NewGuid"].ToString();

        int ProductId= Convert.ToInt16( Request.QueryString["ProductId"]);

        taVisitorProduct.AddVisitorProducts(VisitorId, ProductId);

        Response.Redirect("productinquiry.aspx?ProductId=" + ProductId + "&ID=True");
       
    }
    private void SaveInCustomerQuotation()
    { 
    
    }
    private void GoToLoginScreen()
    {

    }

    private void GoToProductPage()
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SaveInVisitorQuotation();

       /*
        if (Session["CustomerId"] == null)
        {
            SetUserSession();
            Session["GoingForLogin"] = true;
            SaveInVisitorQuotation();
            GoToLoginScreen();
        }
        else
        {
            Session["GoingForLogin"] = false ;
            SaveInCustomerQuotation();
            GoToProductPage();
        }
        */
       

    }

    private void SaveForQuotation()
    {

    }

   

    protected void GoToCart(object sender, EventArgs e)
    {
        Response.Redirect("cart.aspx");
    }

    private void IsThisProductSelectedForCart(int ProductId)
    {
        if (Session["NewGuid"] != null)
        {
            string visitorid = Session["NewGuid"].ToString();

            if (Convert.ToBoolean(taVisitorProduct.IfProductExists(visitorid, ProductId)) == true)
            {
                btnAdd.Visible = false;
            }            
        }        
    }  

}
