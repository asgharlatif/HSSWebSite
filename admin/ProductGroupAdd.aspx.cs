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


public partial class admin_ProductGroupAdd : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

        dsProductGroupTableAdapters.ProductGroupTableAdapter taProductGroup = new dsProductGroupTableAdapters.ProductGroupTableAdapter();
    dsProductGroup.ProductGroupDataTable dtProductGroup;
    
    int ProductGroupCode;

    connectionstring concls = new connectionstring();
    ClassP.ylibWebClass ylib;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        
        
        ProductGroupCode = 0;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Added";
            }
        }

        LoadCompanies();
        SelectCategories();
        SelectSubCategories();

        if (Request.QueryString["ProductGroupCode"] != null)
        {
            ProductGroupCode = Convert.ToInt16(Request.QueryString["ProductGroupCode"]);

            ylib = new ClassP.ylibWebClass(concls.connect());

            txtProductGroupName.Text = ylib.GiveTableQueryValue("select ProductGroupDescription from ProductGroup where ProductGroupCode=" + ProductGroupCode);
           
            
            ddlSubCategory.Enabled = false;
            ddlCategory.Enabled = false;
            ddlCompany.Enabled = false;

            
            lblFormLabel.Text = "Edit Product Group";
            btnAdd.Text = "Edit";
        }

    }
    protected void SelectCategories()
    {
        dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
        dsCategory.CategoryDataTable dtCategory;

        int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);


        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0))
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);
            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;
        }
        else
            dtCategory = taCategory.SelectAllCategory();


        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns[1].ToString();
        ddlCategory.DataValueField = dtCategory.Columns[0].ToString();
        ddlCategory.DataBind();

        if ((Request.QueryString["CategoryId"] != null) && (Convert.ToInt16(Request.QueryString["CategoryId"]) != 0))
        {
            ddlCategory.Items.FindByValue(Request.QueryString["CategoryId"]).Selected = true;
           
        }
        else
            ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }

    protected void SelectSubCategories()
    {
        int CategoryId = 0;
        dsSubCategoryTableAdapters.SubCategoryTableAdapter taSubCategory = new dsSubCategoryTableAdapters.SubCategoryTableAdapter(); 
        dsSubCategory.SubCategoryDataTable dtSubCategory;
               
        int SubCategoryId = Convert.ToInt32(Request.QueryString["SubCategoryId"]);
        CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);

        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0) && CategoryId != 0)
        {           
            dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);
            ddlCategory.Items.FindByValue(CategoryId.ToString()).Selected = true;
        }
        else
            dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);

        

        ddlSubCategory.DataSourceID = null;
        ddlSubCategory.DataSource = dtSubCategory;
        ddlSubCategory.DataTextField = dtSubCategory.Columns[2].ToString();
        ddlSubCategory.DataValueField = dtSubCategory.Columns[1].ToString();
        ddlSubCategory.DataBind();

        if ((Request.QueryString["SubCategoryId"] != null) && (Convert.ToInt16(Request.QueryString["SubCategoryId"]) != 0))
        {
            ddlSubCategory.Items.FindByValue(Request.QueryString["SubCategoryId"]).Selected = true;
        }
        else
            ddlSubCategory.Items.Insert(0, new ListItem("Please Select", ""));

    }

    protected void LoadCompanies()
    {

        dtCompany = taCompany.SelectAllCompany();
        ddlCompany.DataSource = dtCompany;
        ddlCompany.DataTextField = dtCompany.Columns[1].ToString();
        ddlCompany.DataValueField = dtCompany.Columns[0].ToString();
        ddlCompany.DataBind();
        ddlCompany.Items.Insert(0, new ListItem("Please select one", ""));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductGroupCode"] == null)
        {
            taProductGroup.Prc_Ins_ProductGroup(ProductGroupCode, Convert.ToInt32(ddlSubCategory.SelectedItem.Value), txtProductGroupName.Text.Trim(), DateTime.Now);
            Response.Redirect("ProductGroupAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
        }
        else
        {
            taProductGroup.Prc_Ins_ProductGroup(Convert.ToInt16(Request.QueryString["ProductGroupCode"]), Convert.ToInt32(ddlSubCategory.SelectedItem.Value), txtProductGroupName.Text.Trim(), DateTime.Now);
            Response.Redirect("ProductGroups.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
        }
        
    }

    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductGroupAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductGroupAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductGroupAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
}