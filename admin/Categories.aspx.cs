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

public partial class admin_Categories : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;

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
        BindData();

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
        if (Request.QueryString["CompanyId"] != null)
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);
            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;
            if (dtCategory.Rows.Count > 0)
            {
                GridView1.DataSourceID = null;
                GridView1.DataSource = dtCategory;
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
            int CategoryId = Convert.ToInt32(e.CommandArgument);
            taCategory.DeleteCategory(CategoryId);
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int CategoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("CategoryEdit.aspx?CategoryId=" + CategoryId);

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCompanyId = (Label)e.Row.FindControl("lblCompanyId");
                if (lblCompanyId.Text != "")
                {
                    dtCompany = taCompany.SelectCompanyNameFromCompanyId(Convert.ToInt32(lblCompanyId.Text));

                    if (dtCompany.Rows.Count > 0)
                        lblCompanyId.Text = dtCompany[0].CompanyName.ToString();
                    else
                        lblCompanyId.Visible = false;


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

        Response.Redirect("Categories.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
}
