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

public partial class admin_SubCategories : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;

    dsSubCategoryTableAdapters.SubCategoryTableAdapter taSubCategory = new dsSubCategoryTableAdapters.SubCategoryTableAdapter();
    dsSubCategory.SubCategoryDataTable dtSubCategory;

    connectionstring concls= new connectionstring();
    ClassP.ylibWebClass ylib;
    

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

       
        

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Edited";
            }
        }

        LoadCompanies();
        SelectCategories();
        BindData();

    }
    protected void SelectCategories()
    {
        int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);

        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0))
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);

            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;

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
        else
            ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("SubCategories.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
    }

    protected void LoadCompanies()
    {
        
        dtCompany = taCompany.SelectAllCompany();
        ddlCompany.DataSource = dtCompany;
        ddlCompany.DataTextField = dtCompany.Columns[1].ToString();
        ddlCompany.DataValueField = dtCompany.Columns[0].ToString();
        ddlCompany.DataBind();
        
    }

    private void BindData()
    {
        if (Request.QueryString["CompanyId"] != null && Request.QueryString["CategoryId"] !=null)
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);

            dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);    
            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;

            if (dtSubCategory.Rows.Count > 0)
            {
                GridView1.DataSourceID = null;
                GridView1.DataSource = dtSubCategory;
                GridView1.DataBind();
            }
            else
            {
                lblMsg.Text = "No record found";
                return;
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int SubCategoryId = Convert.ToInt32(e.CommandArgument);
            taSubCategory.Delete(SubCategoryId);
            
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int SubCategoryId = Convert.ToInt32(e.CommandArgument);

            int CompanyId = 0;
            int CategoryId = 0;
            ylib = new ClassP.ylibWebClass(concls.connect());

            CategoryId = Convert.ToInt16(ylib.GiveTableQueryValue("select CategoryId from SubCategory where SubCategoryId=" + SubCategoryId));
            CompanyId = Convert.ToInt16(ylib.GiveTableQueryValue("select CompanyId from Category where CategoryId=" + CategoryId));

            Response.Redirect("SubCategoryAdd.aspx?CompanyId=" + CompanyId + "&CategoryId=" + CategoryId + "&SubCategoryId=" + SubCategoryId);

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCategoryId = (Label)e.Row.FindControl("lblCategoryId");
                if (lblCategoryId.Text != "")
                {
                    dtCategory = taCategory.SelectCategorybyCategoryId(Convert.ToInt16(lblCategoryId.Text.ToString()));

                    if (dtCategory.Rows.Count > 0)
                        lblCategoryId.Text = dtCategory[0].CategoryName.ToString();
                    else
                        lblCategoryId.Visible = false;


                    LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
                    lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
                }
            }
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("SubCategories.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
}
