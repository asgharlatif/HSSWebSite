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

public partial class admin_CategoryEdit : System.Web.UI.Page
{

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        LoadCompanies();

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Edited";
            }
        }

        if (Request.QueryString["CategoryId"] != null)
        {
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            dtCategory = taCategory.SelectCategorybyCategoryId(CategoryId);

            if (dtCategory.Rows.Count > 0)
            {
                DataRow row = dtCategory.Rows[0];
                ddlCompany.Items.FindByValue(row["companyid"].ToString()).Selected = true;                
                txtCategory.Text = row["CategoryName"].ToString();
                
                
            }
            else
            {
                lblMsg.Text = "No Record Found";
                btnEdit.Visible = false;
                return;
            }
        }
        else
        {
            lblMsg.Text = "No Record Found";
            btnEdit.Visible = false;
            return;
        }


        
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
        taCategory.EditCategory(Convert.ToInt32(ddlCompany.SelectedItem.Value), CategoryId,txtCategory.Text.Trim(), DateTime.Now);

        Response.Redirect("Categories.aspx?ID=True&CategoryId=" + CategoryId);
    }
}
