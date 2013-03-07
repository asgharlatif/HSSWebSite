using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cart : System.Web.UI.Page
{


    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["NewGuid"] ==null)
            Response.Redirect("productviewgallery.aspx?dispid=idPrdDipCategoryWise&pv=productviewgallery");

        string visitorid = Session["NewGuid"].ToString();
        
        dtProduct = taProduct.SelectProductbyVisitorId(visitorid);
       
        if (dtProduct.Rows.Count > 0)
        {
            Repeater1.DataSource = dtProduct;
            Repeater1.DataBind();
        }

        SetProductQuantity();
    }

    private void SetProductQuantity()
    {
        int TotalQty = 0;

        if (Session["NewGuid"] != null)
            TotalQty = Convert.ToInt16(taProduct.SelectProductCountUsingVisitorId(Session["NewGuid"].ToString()));

        lblTotalItems.Text = "Your Shopping Cart Contains Following (" + TotalQty.ToString() + ") Items";
        lblTotalItems1.Text = "Your Shopping Cart Contains Following (" + TotalQty.ToString() + ") Items";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (Session["email"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
            Server.Transfer("EmailTemplates/QuotationEmailConfirmation.aspx");

    }

}