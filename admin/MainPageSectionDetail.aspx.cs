using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassP;

public partial class admin_MainPageSectionDetail : System.Web.UI.Page
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

    dsMainPageSectionTableAdapters.MainPageSectionTableAdapter taMainPageSection = new dsMainPageSectionTableAdapters.MainPageSectionTableAdapter();
    dsMainPageSection.MainPageSectionDataTable dtMainPageSection;


    connectionstring constr = new connectionstring();
    ylibWebClass ylib;



    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        ylib = new ClassP.ylibWebClass(constr.connect());

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
        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
    }
    protected void ddlProductGroupCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value + "&ProductGroupCode=" + ddlProductGroupCode.SelectedItem.Value);
    }

    #endregion


    

    private void BindData()
    {
        DataTable DT;
        ylib = new ylibWebClass(constr.connect());

        FillWebControlClass FCC = new FillWebControlClass();

        int CompanyId; int SubCategoryId; int CategoryId; int ProductGroupCode;

        #region SetListVariables

        CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
        CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]);
        SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);
        ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);

        #endregion

        #region FillDropDownLists

       
        dtCompany = taCompany.GetData();
        FCC.FillDropDownList(ref ddlCompany, dtCompany, "CompanyName", "CompanyId", true, true, CompanyId.ToString());


        dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);
        FCC.FillDropDownList(ref ddlCategory, dtCategory, "CategoryName", "CategoryId", true, true, CategoryId.ToString());


        dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);
        FCC.FillDropDownList(ref ddlSubCategory, dtSubCategory, "SubCategoryName", "SubCategoryId", true, true, SubCategoryId.ToString());

        dtProductGroup = taProductGroup.GetDataBySubCategoryId(SubCategoryId);
        FCC.FillDropDownList(ref ddlProductGroupCode, dtProductGroup, "ProductGroupDescription", "ProductGroupCode", true, true, ProductGroupCode.ToString());



        #endregion

        #region SetSelectionLabel

        if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0 && ProductGroupCode != 0)
            lblGroupLevel.Text = "Product Group";
        else if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0)
            lblGroupLevel.Text = "Sub Category";
        else if (CompanyId != 0 && CategoryId != 0)
            lblGroupLevel.Text = "Category";
        else if (CompanyId != 0)
            lblGroupLevel.Text = "Company";

        #endregion

        #region Set Main Repeater Page Parts

        DT = ylib.GiveDataTable_BySQLStatement("select PagePartName from PageParts ");

        if (DT.Rows.Count > 0)
        {
            if (CompanyId != 0)
            {
                Repeater1.DataSource = DT;
                Repeater1.DataBind();
            }

        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }

        #endregion



    }

    protected void GrdProductDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");            
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure you want to remove this record?')");
        }
    }

    protected void GrdProductDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {

            dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter taProductMainPageSection = new dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter();

            int CompanyId; int SubCategoryId; int CategoryId; int ProductGroupCode;

            #region SetListVariables
            CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
            CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]);
            SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);
            ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);
            #endregion

            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            int ProductId = Convert.ToInt32(arg[0]);
            int SectionCode = Convert.ToInt32(arg[1]);
            taProductMainPageSection.Prc_Ins_ProductMainPageSection(CompanyId, CategoryId, SubCategoryId, ProductGroupCode, SectionCode, ProductId);
            Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + CompanyId + "&CategoryId=" + CategoryId + "&SubCategoryId=" + SubCategoryId + "&ProductGroupCode=" + ProductGroupCode);

        }
        
    }

    protected void btnUpdateExpiry_Click(object sender, EventArgs e)
    {
        SetExpiry(true, false);
        
    }

    private void SetExpiry(Boolean ToSet , Boolean ToRemove)
    {
        DateTime ExpiryDate;

        dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter taProductMainPageSection = new dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter();

        int CompanyId; int SubCategoryId; int CategoryId; int ProductGroupCode;

        #region SetListVariables
        CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
        CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]);
        SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);
        ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);
        #endregion


        int ProductId = Convert.ToInt32(lblProductId.Text);
        int SectionCode = Convert.ToInt32(lblSectionId.Text);
        
        if (ToSet == true)
        {
            ExpiryDate = Convert.ToDateTime(txtStartDate.Text);
            taProductMainPageSection.Prc_update_ProductMainPageSection(CompanyId, CategoryId, SubCategoryId, ProductGroupCode, SectionCode, ProductId, ExpiryDate);
        }
        else if (ToRemove == true)
            taProductMainPageSection.Prc_RemoveExpiryDate_ProductMainPageSection(CompanyId, CategoryId, SubCategoryId, ProductGroupCode, SectionCode, ProductId);


        
        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + CompanyId + "&CategoryId=" + CategoryId + "&SubCategoryId=" + SubCategoryId + "&ProductGroupCode=" + ProductGroupCode);

        this.ModalPopupExtender1.Hide();
    }
    protected void btnRemoveExpiry_Click(object sender, EventArgs e)
    {
        SetExpiry(false, true);
    }
    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
  
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        lblProductId.Text = gvrow.Cells[0].Text;
        lblSectionId.Text = gvrow.Cells[1].Text;
        if (gvrow.Cells[7].Text != "" && gvrow.Cells[7].Text != "&nbsp;")
        {
            txtStartDate.Text = Convert.ToDateTime(gvrow.Cells[7].Text).ToString();
        }

        this.ModalPopupExtender1.Show();
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable DT;
       
        Label lblPagePartName = (Label)e.Item.FindControl("lblPagePartName");
        GridView GridView1 = (GridView)e.Item.FindControl("GridView1");
        DT = ylib.GiveDataTable_BySQLStatement("SELECT TOP 1000 SectionCode,[SectionName]   FROM [MainPageSection] where PagePartName='" + lblPagePartName.Text + "' and companyid= " + ddlCompany.SelectedValue.ToString() );

        if (DT.Rows.Count > 0)
        {
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            int CompanyId_; int SubCategoryId_; int CategoryId_; int ProductGroupCode_;

            #region SetListVariables

            CompanyId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
            CategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]);
            SubCategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);
            ProductGroupCode_ = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);

            #endregion

            #region GetCookies
            int CompanyId = 0; int SubCategoryId=0; int CategoryId=0; int ProductGroupCode=0;

            if (Request.Cookies["CompanyId"] !=null )
                CompanyId = StringOperation.QueryStringInt16Value(Convert.ToString( Request.Cookies["CompanyId"].Value));
            if (Request.Cookies["CategoryId"] != null)
                CategoryId = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["CategoryId"].Value));
            if (Request.Cookies["SubCategoryId"] != null)
                SubCategoryId = StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["SubCategoryId"].Value));
            if (Request.Cookies["ProductGroupCode"] != null)
                ProductGroupCode =StringOperation.QueryStringInt16Value(Convert.ToString(Request.Cookies["ProductGroupCode"].Value));
            
            #endregion

            int SectionCode = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductsSelectionForSection.aspx?SectionCode=" + SectionCode + "&CompanyId_=" + CompanyId_ + "&CategoryId_=" + CategoryId_ + "&SubCategoryId_=" + SubCategoryId_ + "&ProductGroupCode_=" + ProductGroupCode_ + "&lblGroupLevel=" + lblGroupLevel.Text + "&CompanyId=" + CompanyId + "&CategoryId=" + CategoryId + "&SubCategoryId=" + SubCategoryId + "&ProductGroupCode=" + ProductGroupCode);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProductCount = (Label)e.Row.FindControl("lblProductCount");
            Label lblSectionCode = (Label)e.Row.FindControl("lblSectionCode");       
 
            GridView GrdProductDetail = (GridView)e.Row.FindControl("GrdProductDetail");

            SetDataCounts ( ref lblSectionCode, ref lblProductCount,ref GrdProductDetail);
        }
    }

    private void SetDataCounts(ref Label lblSectionCode, ref Label lblProductCount,ref GridView GrdProductDetail)
    {
        string SearchString = "";

        DataTable DT;

        int CompanyId; int SubCategoryId; int CategoryId; int ProductGroupCode;

        #region SetListVariables

        CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
        CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]);
        SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);
        ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);

        #endregion

        #region SetSelectionLabel

        if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0 && ProductGroupCode != 0)
            SearchString = " CompanyId=" + CompanyId + " and CategoryId =" + CategoryId + " and SubCategoryId=" + SubCategoryId + " and ProductGroupCode=" + ProductGroupCode;
        else if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0)
            SearchString = " CompanyId=" + CompanyId + " and CategoryId =" + CategoryId + " and SubCategoryId=" + SubCategoryId + " and ProductGroupCode is null";
        else if (CompanyId != 0 && CategoryId != 0)
            SearchString = " CompanyId=" + CompanyId + " and CategoryId =" + CategoryId + " and SubCategoryId is null and ProductGroupCode is null";
        else if (CompanyId != 0)
            SearchString = " CompanyId=" + CompanyId + " and CategoryId is null and SubCategoryId is null and ProductGroupCode is null"; ;

       

        #endregion

        lblProductCount.Text = "0";
        #region SetProductCount        
        if (SearchString != "")
        {
            SearchString = SearchString + " and sectioncode=" + lblSectionCode.Text;
            SearchString = "SELECT ProductId,ProductTitle,ProductGroupDescription,SubCategoryName,CategoryName,SectionCode, CONVERT(VARCHAR(9), ExpiryDate, 6)  as ExpiryDate  FROM [v_ProductMainPageSection] where " + SearchString;



            DT = ylib.GiveDataTable_BySQLStatement(SearchString);
            
            if (DT.Rows.Count > 0)
            {
                lblProductCount.Text = DT.Rows.Count.ToString();
                GrdProductDetail.DataSource = DT;
                GrdProductDetail.DataBind();
            }
        }
        #endregion

    }

}