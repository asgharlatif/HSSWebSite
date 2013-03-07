using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class productinlinedisplay : System.Web.UI.Page
{
    connectionstring strConn = new connectionstring();
    InventoryClass InvCls = new InventoryClass();
    string SubCateCode = "", ItemKey = "";
    dsVisitorProductsTableAdapters.VisitorProductsTableAdapter taVisitor = new dsVisitorProductsTableAdapters.VisitorProductsTableAdapter();


    int Count = 0, CurrentPage = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["CurrentPage"] = 0;
        }
        GetItems();
    }
  

    public void GetItems()
    {

        if (Convert.ToInt32(Session["CurrentPage"].ToString()) != 0)
        {
            CurrentPage = Convert.ToInt32(Session["CurrentPage"].ToString());
        }
        SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MBCConnectionString"].ToString());
        conn.Open();
        DataTable dtDB = new DataTable("ItemInfo");
        DataTable dtDB1 = new DataTable("ItemInfo1");
        if (Request.QueryString["categoryid"] == null || Request.QueryString["categoryid"] == "")
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select  productid,producttitle,Description,TechnicalSpecs,sort,model,thumbNail from Product where categoryid in (select categoryid from Category where companyid=16) order by sort ", conn);
            adpDB.Fill(dtDB);
        }
        else
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select  productid,producttitle,Description,TechnicalSpecs,sort,model,thumbNail from Product where categoryid in (select categoryid from Category where companyid=16 and categoryid=" + Request.QueryString["categoryid"] + ") order by sort ", conn);
            adpDB.Fill(dtDB);
        }

        PagedDataSource objPage = new PagedDataSource();
        objPage.DataSource = dtDB.DefaultView;
        objPage.AllowPaging = true;
        objPage.PageSize = 100;// InvCls.getTotalItemDisplyed("TotalNumberOfProductOnPrductPage");
        Session["TotalPages"] = objPage.PageCount - 1;
        objPage.CurrentPageIndex = CurrentPage;

        if (objPage.PageCount > 1)
        {
            //lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of " + objPage.PageCount.ToString();
        }

        // Disable Prev or Next buttons if necessary
        //cmdPrev.Visible = !objPage.IsFirstPage;
        //cmdNext.Visible = !objPage.IsLastPage;
        //cmdFirst.Visible = !objPage.IsFirstPage;
        //cmdLast.Visible = !objPage.IsLastPage;
        DataList1.DataSource = objPage;
        DataList1.DataBind();
        conn.Close();
        if (dtDB.Rows.Count == 0)
        {
            //Image1.Visible = true;
        }
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        System.Data.DataRowView drv = (System.Data.DataRowView)(e.Item.DataItem);
        int ProductId = int.Parse(drv.Row["ProductId"].ToString());
        if (IsThisProductSelectedForCart(ProductId) == true)
        {
            //e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            e.Item.FindControl("GalPanel1").Visible = false;
        }

    }
    private Boolean IsThisProductSelectedForCart(int ProductId)
    {
        if (Session["NewGuid"] != null)
        {
            string visitorid = Session["NewGuid"].ToString();

            if (Convert.ToBoolean(taVisitor.IfProductExists(visitorid, ProductId)) == true)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
}