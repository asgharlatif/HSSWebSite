using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MasterProductDisplay : System.Web.UI.MasterPage
{
    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;


    protected void Page_Load(object sender, EventArgs e)
    {
        SetProductCategories();
        SetProductQuantity();
    }

    public void setQtyValue(int qty)
    {
        lblTotalItems.Text = qty.ToString();
    }

    private void SetProductQuantity()
    {
        int TotalQty =0;
        
        if (Session["NewGuid"] !=null)
        TotalQty = Convert.ToInt16(taProduct.SelectProductCountUsingVisitorId(Session["NewGuid"].ToString()));

        lblTotalItems.Text = "Your Shopping Cart contains (" + TotalQty.ToString() + ") items";

        if (Convert.ToInt16( TotalQty) == 0)
            btnGoToCart.Enabled = false;
        else
            btnGoToCart.Enabled = true;

    }

    private void SetProductCategories()
    {
        SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MBCConnectionString"].ToString());
        conn.Open();
        DataTable dtDB = new DataTable("category");
        SqlDataAdapter adpDB = new SqlDataAdapter("select 'productviewgallery.aspx?dispid=idPrdDipCategoryWiseSpecificCategory&catQty='+categoryname+'&categoryid=' + cast(categoryid as varchar(2))  as categoryid,categoryname + '(' + cast(dbo.TotalProductsOfThisCategory(categoryid) as varchar(4)) + ')' as categoryname from category where companyid=16", conn);
        adpDB.Fill(dtDB);

        BulletedList2.DataSource = dtDB;
        BulletedList2.DataMember = "category";
        BulletedList2.DataValueField = "categoryid";
        BulletedList2.DataTextField = "categoryname";
        BulletedList2.DataBind();

        BulletedList1.DataSource = dtDB;
        BulletedList1.DataMember = "category";
        BulletedList1.DataValueField = "categoryid";
        BulletedList1.DataTextField = "categoryname";
        BulletedList1.DataBind();
        
    }


    protected void GoToCart(object sender, EventArgs e)
    {
        Response.Redirect("cart.aspx");
    }
}
