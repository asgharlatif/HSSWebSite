using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DataAccess;
using System.Data;

public partial class admin_SimilarSetEdit : System.Web.UI.Page
{
    SimilarSetTableAdapters.ProductSimilarSetTableAdapter taSimilarSet = new SimilarSetTableAdapters.ProductSimilarSetTableAdapter();
    SimilarSet.ProductSimilarSetDataTable dtSimilarSet;
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

        if (Request.QueryString["SetCode"] != null)
        {
            int SetCode = Convert.ToInt32(Request.QueryString["SetCode"]);
            dtSimilarSet = taSimilarSet.SelectProductsSimilarTo(SetCode);

            if (dtSimilarSet.Rows.Count > 0)
            {
                DataRow row = dtSimilarSet.Rows[0];

                txtSetName.Text = row["setDescription"].ToString();

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
        int SetCode = Convert.ToInt32(Request.QueryString["SetCode"]);
        int CompanyId =Convert.ToInt32( taSimilarSet.SelectCompanyIdUsingSetCode(SetCode));


        taSimilarSet.UpdateQuery(txtSetName.Text.Trim(), CompanyId, SetCode);

        Response.Redirect("ProductSimilarSet.aspx?ID=True&SetCode=" + SetCode);
    }
}