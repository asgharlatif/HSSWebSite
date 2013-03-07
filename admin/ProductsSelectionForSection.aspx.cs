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

public partial class admin_ProductsSelectionForSection : System.Web.UI.Page
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

    connectionstring constr = new connectionstring();
    ClassP.ylibWebClass ylib;

    int SectionCode ;

    #endregion

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
        Response.Redirect("ProductsSelectionForSection.aspx?SectionCode=" + StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]) + "&CompanyId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]) + "&CategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]) + "&SubCategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]) + "&ProductGroupCode_=" + StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]) + "&CompanyId=" + ddlCompany.SelectedItem.Value + "&lblGroupLevel=" + Request.QueryString["lblGroupLevel"]);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductsSelectionForSection.aspx?SectionCode=" + StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]) + "&CompanyId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]) + "&CategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]) + "&SubCategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]) + "&ProductGroupCode_=" + StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]) + "&CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&lblGroupLevel=" + Request.QueryString["lblGroupLevel"]);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductsSelectionForSection.aspx?SectionCode=" + StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]) + "&CompanyId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]) + "&CategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]) + "&SubCategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]) + "&ProductGroupCode_=" + StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]) + "&CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value + "&lblGroupLevel=" + Request.QueryString["lblGroupLevel"]);
    }
    protected void ddlProductGroupCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductsSelectionForSection.aspx?SectionCode=" + StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]) + "&CompanyId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]) + "&CategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]) + "&SubCategoryId_=" + StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]) + "&ProductGroupCode_=" + StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]) + "&CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value + "&ProductGroupCode=" + ddlProductGroupCode.SelectedItem.Value + "&lblGroupLevel=" + Request.QueryString["lblGroupLevel"]);
    }

    #endregion

    private void BindData()
    {
        int SectionCode = 0;
        FillWebControlClass FCC = new FillWebControlClass();

        ylib = new ClassP.ylibWebClass(constr.connect());

        lblGroupLevel.Text = Request.QueryString["lblGroupLevel"];
        
        int CompanyId ;        int SubCategoryId ;        int CategoryId;        int ProductGroupCode ;

        #region SetListVariables


        SectionCode = StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]);
        CompanyId = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId"]);
        CategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId"]); 
        SubCategoryId = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId"]);     
        ProductGroupCode = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode"]);

        #region Write Cookies
        
        if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0 && ProductGroupCode != 0)            
        {            
            Response.Cookies["ProductGroupCode"].Value=ProductGroupCode.ToString();
            Response.Cookies["ProductGroupCode"].Expires=DateTime.Now.AddDays(1);
        }
        else if (CompanyId != 0 && CategoryId != 0 && SubCategoryId != 0)            
        {            
            Response.Cookies["SubCategoryId"].Value=SubCategoryId.ToString();
            Response.Cookies["SubCategoryId"].Expires=DateTime.Now.AddDays(1);
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

        #endregion

        #endregion

        lblSectionName.Text = ylib.giveValue("select SectionName from   MainPageSection where SectionCode=" + SectionCode);

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
        if (e.CommandName == "AddRemove")
        {

            dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter taProductMainPageSection = new dsProductMainPageSectionTableAdapters.ProductMainPageSectionTableAdapter();

        int CompanyId_; int SubCategoryId_; int CategoryId_; int ProductGroupCode_;

        #region SetListVariables

        CompanyId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]);
        CategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]);
        SubCategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]);
        ProductGroupCode_ = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]);
        SectionCode = StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]);
        #endregion


        int ProductId = Convert.ToInt32(e.CommandArgument);
        taProductMainPageSection.Prc_Ins_ProductMainPageSection(CompanyId_, CategoryId_, SubCategoryId_, ProductGroupCode_, SectionCode, ProductId);

        Response.Redirect("MainPageSectionDetail.aspx?CompanyId=" + CompanyId_ + "&CategoryId=" + CategoryId_ + "&SubCategoryId=" + SubCategoryId_ + "&ProductGroupCode=" + ProductGroupCode_);

        }



        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            SectionCode = StringOperation.QueryStringInt16Value(Request.QueryString["SectionCode"]);
            LinkButton btnAddRemoveSelection = (LinkButton)e.Row.FindControl("btnAddRemoveSelection");

            int ProductId =Convert.ToInt16( btnAddRemoveSelection.Text);



            if (DoesProductExists(SectionCode, ProductId) == true)
            {
                btnAddRemoveSelection.Visible = false;
                //btnAddRemoveSelection.Text = "Remove from selection.";
                //btnAddRemoveSelection.Attributes.Add("OnClick", "return confirm('Are you sure to remove this record?');");
            }
            else
            {
                btnAddRemoveSelection.Text = "add to selection.";
                btnAddRemoveSelection.Attributes.Add("OnClick", "return confirm('Are you sure to add this record into the selection?');");
            }


        }
    }

    private Boolean DoesProductExists(int SectionCode, int ProductId)
    {
        string SearchString = "";
        Boolean Exists = false;
        ylib = new ClassP.ylibWebClass(constr.connect());

        DataTable DT;

        int CompanyId_; int SubCategoryId_; int CategoryId_; int ProductGroupCode_;

        #region SetListVariables

        CompanyId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CompanyId_"]);
        CategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["CategoryId_"]);
        SubCategoryId_ = StringOperation.QueryStringInt16Value(Request.QueryString["SubCategoryId_"]);
        ProductGroupCode_ = StringOperation.QueryStringInt16Value(Request.QueryString["ProductGroupCode_"]);

        #endregion

        #region SetSelectionLabel

        if (CompanyId_ != 0 && CategoryId_ != 0 && SubCategoryId_ != 0 && ProductGroupCode_ != 0)
            SearchString = " CompanyId=" + CompanyId_ + " and CategoryId =" + CategoryId_ + " and SubCategoryId=" + SubCategoryId_ + " and ProductGroupCode=" + ProductGroupCode_;
        else if (CompanyId_ != 0 && CategoryId_ != 0 && SubCategoryId_ != 0)
            SearchString = " CompanyId=" + CompanyId_ + " and CategoryId =" + CategoryId_ + " and SubCategoryId=" + SubCategoryId_ + " and ProductGroupCode is null" ;
        else if (CompanyId_ != 0 && CategoryId_ != 0)
            SearchString = " CompanyId=" + CompanyId_ + " and CategoryId =" + CategoryId_ + " and SubCategoryId is null and ProductGroupCode is null";
        else if (CompanyId_ != 0)
            SearchString = " CompanyId=" + CompanyId_ + " and CategoryId is null and SubCategoryId is null and ProductGroupCode is null"; ;



        #endregion
                
        #region SetProductCount
        if (SearchString != "")
        {
            SearchString = SearchString + " and sectioncode=" + SectionCode + " and ProductId=" + ProductId;
            SearchString = "SELECT ProductId,ProductTitle,ProductGroupDescription,SubCategoryName,CategoryName   FROM [v_ProductMainPageSection] where " + SearchString;

            DT = ylib.GiveDataTable_BySQLStatement(SearchString);

            if (DT.Rows.Count > 0)
            {
                Exists = true;
            }
            

        }
        #endregion

        return Exists;
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
}
