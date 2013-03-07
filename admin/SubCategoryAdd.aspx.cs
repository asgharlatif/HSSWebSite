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

public partial class admin_SubCategoryAdd : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;

    dsSubCategoryTableAdapters.SubCategoryTableAdapter taSubCategory = new dsSubCategoryTableAdapters.SubCategoryTableAdapter();
    dsSubCategory.SubCategoryDataTable dtSubCategory;

    connectionstring concls = new connectionstring();
    ClassP.ylibWebClass ylib;

    int SubCategoryId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        
        SubCategoryId = 0;

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

        if (Request.QueryString["SubCategoryId"] != null)
        {
            SubCategoryId = Convert.ToInt16(Request.QueryString["SubCategoryId"]);

            ylib = new ClassP.ylibWebClass(concls.connect());

            txtSubCategory.Text = ylib.GiveTableQueryValue("select SubCategoryName from SubCategory where SubCategoryId=" + SubCategoryId);
            ddlCategory.Enabled = false;
            ddlCompany.Enabled = false;
            lblFormLabel.Text = "Edit Sub Category";
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
        

        if (Request.QueryString["SubCategoryId"] == null)
        {
            taSubCategory.Prc_Ins_SubCategory(SubCategoryId, Convert.ToInt32(ddlCategory.SelectedItem.Value), txtSubCategory.Text.Trim(), DateTime.Now);
            Response.Redirect("SubCategoryAdd.aspx?ID=True&CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
        }
        else
        {
            taSubCategory.Prc_Ins_SubCategory(Convert.ToInt16(Request.QueryString["SubCategoryId"]), Convert.ToInt32(ddlCategory.SelectedItem.Value), txtSubCategory.Text.Trim(), DateTime.Now);
            Response.Redirect("SubCategories.aspx?ID=True&CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
        }

        
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("SubCategoryAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value  +"&CategoryId="+  ddlCategory.SelectedItem.Value);
    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("SubCategoryAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
}