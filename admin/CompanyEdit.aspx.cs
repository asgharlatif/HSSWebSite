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

public partial class admin_CompanyEdit : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;


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

        if (Request.QueryString["companyid"] != null)
        {
            int companyid = Convert.ToInt32(Request.QueryString["companyid"]);
            dtCompany = taCompany.SelectAllCompanyByCompanyId(companyid);

            if (dtCompany.Rows.Count > 0)
            {
                DataRow row = dtCompany.Rows[0];
                txtCompany.Text = row["CompanyName"].ToString();
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
        taCompany.editCompany(txtCompany.Text.Trim(),DateTime.Now, CompanyId);

        Response.Redirect("companies.aspx?ID=True&CompanyId=" + CompanyId);
    }
}