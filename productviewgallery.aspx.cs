using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class productviewgallery : System.Web.UI.Page
{
    dsVisitorProductsTableAdapters.VisitorProductsTableAdapter taVisitor = new dsVisitorProductsTableAdapters.VisitorProductsTableAdapter();


    //MasterProductDisplay MPF = new MasterProductDisplay();

    connectionstring strConn = new connectionstring();
    SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MBCConnectionString"].ToString());

    InventoryClass InvCls = new InventoryClass();
    string SubCateCode = "", ItemKey = "";

    DataTable VDT = new DataTable("VDT");
    DataSet VDDS = new DataSet("VDDS");


    int Count = 0, CurrentPage = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
  
        if (!Page.IsPostBack)
        {
            Session["CurrentPage"] = 0;
        }
       
        conn.Open();
        GetItems();
       
    }

    

    public void GetItems()
    {
       
        if (Convert.ToInt32(Session["CurrentPage"].ToString()) != 0)
        {
            CurrentPage = Convert.ToInt32(Session["CurrentPage"].ToString());
        }
        
        DataTable dtDB = new DataTable("ItemInfo");
        DataTable dtDB1 = new DataTable("ItemInfo1");
        

        if (  Request.QueryString["categoryid"] == null || Request.QueryString["categoryid"]=="")
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select  productid,producttitle,sort,model,thumbNail from Product where categoryid in (select categoryid from Category where companyid=16) order by sort ", conn);
            adpDB.Fill(dtDB);
        }
        else 
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select  productid,producttitle,sort,model,thumbNail from Product where categoryid in (select categoryid from Category where companyid=16 and categoryid=" + Request.QueryString["categoryid"] + ") order by sort ", conn);
            adpDB.Fill(dtDB);            
        }

        PagedDataSource objPage = new PagedDataSource();
        objPage.DataSource = dtDB.DefaultView;
        objPage.AllowPaging = true;
        objPage.PageSize = 100;
        Session["TotalPages"] = objPage.PageCount - 1;
        objPage.CurrentPageIndex = CurrentPage;       

        
        DataList1.DataSource = objPage;
        DataList1.DataBind();
        conn.Close();
        
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
           
            e.Item.FindControl("GalPanel1").Visible = false;
        }
        
    }

    protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
    {
      

    }

    private Boolean IsThisProductSelectedForCart(  int ProductId)
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
