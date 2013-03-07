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

public partial class admin_SectionCategoryAdd : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategory = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategory;

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
        taCategory.AddSectionCategory(txtCategory.Text.Trim(), DateTime.Now);
        Response.Redirect("SectionCategoryAdd.aspx?ID=True");
    }
}
