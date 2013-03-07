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

public partial class admin_CompanyAdd : System.Web.UI.Page
{
    //dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
   // dsCategory.CategoryDataTable dtCategory;

    
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
                lblMsg.Text = "Successfully Added";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taCompany.addCompany(txtCompany.Text.Trim(), DateTime.Now);
        Response.Redirect("CompanyAdd.aspx?ID=True");
           
        
        //taCategory.AddCategory(txtCompany.Text.Trim(), DateTime.Now);
       // Response.Redirect("CompanyAdd.aspx?ID=True");
    }
}
