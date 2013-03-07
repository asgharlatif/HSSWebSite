using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.co

public partial class SiteMaster : System.Web.UI.MasterPage
{
    //HttpCookie UserVisitGuid = new HttpCookie("UserVisitGuid");

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;
   

    protected void Page_Load(object sender, EventArgs e)
    {

        int TotalQty = 0;

        if (Session["NewGuid"] != null)
            TotalQty = Convert.ToInt16(taProduct.SelectProductCountUsingVisitorId(Session["NewGuid"].ToString()));

        if (Session["email"] != null)
        {
            Emailhyperlink.Text = "Email:-" + Session["email"].ToString();
            LoginHyperLink.Visible = false;
        }
        else
        {
            Emailhyperlink.Visible = false;
            LogoutHyperLink.Visible = false;
        }


        if (Request.QueryString["action"] == "logout")
        {
            Session["email"] = null;
            Session["CustomerLogin"] = false;
            Response.Redirect("default.aspx");
        }

        if (TotalQty == 0)
            imgcart.ImageUrl = "~/frontimages/logo/addtocart.gif";
        else
            imgcart.ImageUrl = "~/frontimages/logo/fillcart.jpg";

        CreateCookie();
    }

    

    private void CreateCookie()
    {
        if (Session["NewGuid"] == null)
        {
            if (Request.Cookies["NewGuid"] != null)
            {
                Session["NewGuid"] = Server.HtmlEncode(Request.Cookies["NewGuid"].Value);
            }
            else
            {
                Response.Cookies["NewGuid"].Value = GetUniqGuid();
                Response.Cookies["NewGuid"].Expires = DateTime.Now.AddDays(1);
                //Response.Cookies["domain"].Domain = "support.contoso.com";
            }
        }


    }

    private void SetUserSession()
    {
        if (Session["NewGuid"] == null)
        {
            Session["NewGuid"] = GetUniqGuid();
        }
    }
    public string GetUniqGuid()
    {
        return Guid.NewGuid().ToString().GetHashCode().ToString("x");
    }
}
