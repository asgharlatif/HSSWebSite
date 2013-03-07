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

public partial class admin_EditGroupProfile : System.Web.UI.Page
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
                lblCompany.Text = row["CompanyName"].ToString();
            }
        }
    }
}