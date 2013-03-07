using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class cartprocess : System.Web.UI.Page
{
    dsVisitorProductsTableAdapters.VisitorProductsTableAdapter taVisitorProduct = new dsVisitorProductsTableAdapters.VisitorProductsTableAdapter();
    dsVisitorProducts.VisitorProductsDataTable dtVisitorProduct;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        string VisitorId = Session["NewGuid"].ToString();
        int ProductId =Convert.ToInt16(Request.Form.Get("ProductId"));
        string RequestingForm = Request.Form.Get("RequestingForm");

        if (RequestingForm == "CartDel")
        {
            taVisitorProduct.Delete(VisitorId, ProductId);
            TextBox1.Text = taProduct.SelectProductCountUsingVisitorId(Session["NewGuid"].ToString()).ToString();
        }
        else if (RequestingForm == "ShoppingCart")
        {
            if (taVisitorProduct.IfProductExists(VisitorId, ProductId) == 0)
            {
                taVisitorProduct.AddVisitorProducts(VisitorId, ProductId);
                TextBox1.Text = taProduct.SelectProductCountUsingVisitorId(Session["NewGuid"].ToString()).ToString();
            }
            else
                TextBox1.Text = "0";

        }

    }
 
}