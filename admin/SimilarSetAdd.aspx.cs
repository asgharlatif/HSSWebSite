using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SimilarSetAdd : System.Web.UI.Page
{

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    SimilarSetTableAdapters.ProductSimilarSetTableAdapter taSimilarSet = new SimilarSetTableAdapters.ProductSimilarSetTableAdapter();
    SimilarSet.ProductSimilarSetDataTable dtSimilarSet;
    
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Added";
            }
        }

        LoadCompanies();
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
        taSimilarSet.AddSet(txtSetName.Text.Trim(),Convert.ToInt16( ddlCompany.Text));
        Response.Redirect("SimilarSetAdd.aspx?ID=True");
        
    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}