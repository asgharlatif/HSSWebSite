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
using ClassP;

public partial class admin_Products : System.Web.UI.Page
{
    #region DataTablesDeclarations
    
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;

    dsSubCategoryTableAdapters.SubCategoryTableAdapter taSubCategory = new dsSubCategoryTableAdapters.SubCategoryTableAdapter();
    dsSubCategory.SubCategoryDataTable dtSubCategory;

    dsProductGroupTableAdapters.ProductGroupTableAdapter taProductGroup = new dsProductGroupTableAdapters.ProductGroupTableAdapter();
    dsProductGroup.ProductGroupDataTable dtProductGroup;

    #endregion

    connectionstring ConStr = new connectionstring();
    ylibWebClass ylib;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        }

        

       
        BindData();
    }
   

    #region SelectedIndexChanged
    
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("products.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("products.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("products.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
    }
    protected void ddlProductGroupCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("products.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value + "&ProductGroupCode=" + ddlProductGroupCode.SelectedItem.Value);
    }

    #endregion

    private void BindData()
    {
        FillWebControlClass FCC = new FillWebControlClass();
        
        int CompanyId ;        int SubCategoryId ;        int CategoryId;        int ProductGroupCode ;

        #region SetListVariables

        CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
        CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]); 
        SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);     
        ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);


        #region Write Cookies

        if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0 && ProductGroupCode != 0)
        {
            Response.Cookies["ProductGroupCode"].Value = ProductGroupCode.ToString();
            Response.Cookies["ProductGroupCode"].Expires = DateTime.Now.AddDays(1);
        }
        else if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0)
        {
            Response.Cookies["SubCategoryId"].Value = SubCategoryId.ToString();
            Response.Cookies["SubCategoryId"].Expires = DateTime.Now.AddDays(1);
        }
        else if (CompanyId != 0 && CategoryId != 0)
        {
            Response.Cookies["CategoryId"].Value = CategoryId.ToString();
            Response.Cookies["CategoryId"].Expires = DateTime.Now.AddDays(1);
        }
        else if (CompanyId != 0)
        {
            Response.Cookies["CompanyId"].Value = CompanyId.ToString();
            Response.Cookies["CompanyId"].Expires = DateTime.Now.AddDays(1);
        }

        #region GetCookies
       
        if (Request.Cookies["CompanyId"] != null && CompanyId==0)
            CompanyId = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["CompanyId"].Value));
        if (Request.Cookies["CompanyId"] != null && Request.Cookies["CategoryId"] != null && CategoryId == 0)
            CategoryId = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["CategoryId"].Value));
        if (Request.Cookies["CompanyId"] != null && Request.Cookies["CategoryId"] != null && Request.Cookies["SubCategoryId"] != null && SubCategoryId == 0)
            SubCategoryId = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["SubCategoryId"].Value));
        //if (Request.Cookies["ProductGroupCode"] != null && ProductGroupCode == 0)
        //    ProductGroupCode = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["ProductGroupCode"].Value));

        #endregion

        #endregion



        #endregion

        #region FillDropDownLists
        
        dtCompany = taCompany.GetData();
        FCC.FillDropDownList(ref ddlCompany, dtCompany, "CompanyName", "CompanyId",true,true,CompanyId.ToString());

        
        dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);
        FCC.FillDropDownList(ref ddlCategory, dtCategory, "CategoryName", "CategoryId", true, true, CategoryId.ToString());

        
        dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);
        FCC.FillDropDownList(ref ddlSubCategory, dtSubCategory, "SubCategoryName", "SubCategoryId", true, true, SubCategoryId.ToString());

        dtProductGroup = taProductGroup.GetDataBySubCategoryId(SubCategoryId);
        FCC.FillDropDownList(ref ddlProductGroupCode, dtProductGroup, "ProductGroupDescription", "ProductGroupCode", true, true, ProductGroupCode.ToString());

        #endregion

        if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0 && ProductGroupCode!=0)                
            dtProduct = taProduct.GetDataByProductGroupCode(ProductGroupCode);       
        else
            dtProduct = taProduct.GetDataByProductGroupCode(0);

        
        if (dtProduct.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtProduct;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtProduct;
            GridView1.DataBind();
            lblMsg.Text = "No record found";
            return;
        }
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        ylib = new ylibWebClass(ConStr.connect());

        if (e.CommandName == "Delete")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            taProduct.DeleteProduct(ProductId);
            BindData();
        }


        if (e.CommandName == "Edit")
        {
            DataTable DT = new DataTable();
            int ProductId = Convert.ToInt32(e.CommandArgument);
            DT = ylib.GiveDataTable_BySQLStatement("select CompanyId,CategoryId,SubCategoryId,ProductGroupCode from v_products where productid=" + ProductId);
            if (DT.Rows.Count > 0)
            {
                DataRow row = DT.Rows[0];
                Response.Redirect("ProductAdd.aspx?ProductId=" + ProductId + "&CompanyId=" + Convert.ToInt16(row["CompanyId"]) + "&CategoryId=" + Convert.ToInt16(row["CategoryId"]) + "&SubCategoryId=" + Convert.ToInt16(row["SubCategoryId"]) + "&ProductGroupCode=" + Convert.ToInt16(row["ProductGroupCode"]) );
            }
            else
                Response.Redirect("ProductAdd.aspx?ProductId=" + ProductId);
        }

        if (e.CommandName == "Image")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductImages.aspx?ProductId=" + ProductId);
        }

        if (e.CommandName == "Features")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductKeyFeatures.aspx?ProductId=" + ProductId);
        }

        if (e.CommandName == "Color")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductColors.aspx?ProductId=" + ProductId);
        }

        if (e.CommandName == "TechnicalSpecs")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("TechnicalSpecsEdit.aspx?ProductId=" + ProductId);
        }

        if (e.CommandName == "Documents")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DocumentsDetails.aspx?ProductId=" + ProductId + "&DocumenType=0&osDocumenType=0");
        }
        if (e.CommandName == "Drivers")
        {
            int ProductId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DocumentsDetails.aspx?ProductId=" + ProductId + "&DocumenType=1&osDocumenType=1");
        }
        if (e.CommandName == "FreeShipment")
        {
            string sqlupdate;
            Boolean IsFreeShipment = false;
            string[] Str= new string[2];

            Str = e.CommandArgument.ToString().Split(';');
            int ProductId = Convert.ToInt32(Str[0]);
            IsFreeShipment = Convert.ToBoolean(Str[1]);

            if (IsFreeShipment == false) IsFreeShipment = true; else IsFreeShipment = false;

            sqlupdate = "";

            if (IsFreeShipment == true)
                sqlupdate = "update product set freeshipment=1 where productid=" + ProductId;
            else
                sqlupdate = "update product set freeshipment=0 where productid=" + ProductId;

            ylib.ExecuateSQLStatement(sqlupdate);

            BindData();
        }

        if (e.CommandName == "InStock")
        {

            string sqlupdate;
            Boolean IsInStock = false;
            string[] Str = new string[2];

            Str = e.CommandArgument.ToString().Split(';');
            int ProductId = Convert.ToInt32(Str[0]);
            IsInStock = Convert.ToBoolean(Str[1]);

            sqlupdate = "";

            if (IsInStock == false) IsInStock = true; else IsInStock = false;

            if (IsInStock == true)
                sqlupdate = "update product set InStock=1 where productid=" + ProductId;
            else
                sqlupdate = "update product set InStock=0 where productid=" + ProductId;

            ylib.ExecuateSQLStatement(sqlupdate);

            BindData();

        }
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("lbtnDelete");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

            LinkButton lbtnFreeShipment = (LinkButton)e.Row.FindControl("lbtnFreeShipment");
            if (lbtnFreeShipment.Text == "True")
                lbtnFreeShipment.Text = "Free Shipment";
            else
                lbtnFreeShipment.Text = "Charged Shipment";

            LinkButton lbtnInStock = (LinkButton)e.Row.FindControl("lbtnInStock");
            if (lbtnInStock.Text == "True")
                lbtnInStock.Text = "Remove from Stock";
            else
                lbtnInStock.Text = "Add into Stock";

        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }


    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        DataTable DTPrice;

        ylib = new ylibWebClass(ConStr.connect());

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        lblProductId.Text = gvrow.Cells[0].Text;
        lblItemName.Text = gvrow.Cells[1].Text;


        DTPrice = ylib.GiveDataTable_BySQLStatement("select productid,price,date from ProductPricing where productid="+Convert.ToInt16(gvrow.Cells[0].Text) );
        if (DTPrice.Rows.Count > 0)
        {
            GrdPrices.DataSource = DTPrice;
            GrdPrices.DataBind();
            lblPriceNotDefined.Visible = false;
        }
        else
        {
            lblPriceNotDefined.Visible = true;
            GrdPrices.DataSource = null;
            GrdPrices.DataBind();
        }



        this.ModalPopupExtender1.Show();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string sqlinsert = "";
        ylib = new ylibWebClass(ConStr.connect());

        sqlinsert = "insert into ProductPricing(ProductId,Price,Date) values (" + lblProductId.Text + ",'"+ txtPrice.Text  +"','"+ DateTime.Now +"')";
        ylib.ExecuateSQLStatement(sqlinsert);
        //Update the record here



        this.ModalPopupExtender1.Hide();
        //imgbtn_Click
    }
}
