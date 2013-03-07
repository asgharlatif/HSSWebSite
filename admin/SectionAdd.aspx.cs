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

public partial class admin_SectionAdd : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategory = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategory;

    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Added";
            }
        }

       SelectCategories();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taSections.AddSections(Convert.ToInt32(ddlCategory.SelectedItem.Value),
                               txtSectionName.Text.Trim(),
                               DateTime.Now);

        Response.Redirect("SectionAdd.aspx?ID=True");
    }
    protected void SelectCategories()
    {
        dtCategory = taCategory.SelectAllSectionCategories();
        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns[1].ToString();
        ddlCategory.DataValueField = dtCategory.Columns[0].ToString();
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }
}
