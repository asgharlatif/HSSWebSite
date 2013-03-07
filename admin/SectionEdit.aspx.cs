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

public partial class admin_SectionEdit : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategory = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategory;

    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        
        SelectCategories();
        
        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Edited";
            }
        }
        if (Request.QueryString["SectionId"] != null)
        {
            int SectionId = Convert.ToInt32(Request.QueryString["SectionId"]);
            dtSections = taSections.SelectSectionsbySectionId(SectionId);
            if (dtSections.Rows.Count > 0)
            {
                ddlCategory.Items.FindByValue(dtSections[0].CategoryId.ToString()).Selected = true;
                txtSectionName.Text = dtSections[0].SectionName.ToString();
            }
            else
            {
                lblMsg.Text = "No record found";
                btnEdit.Visible = false;
                return;
            }
        }
        else
        {
            lblMsg.Text = "No record found";
            btnEdit.Visible = false;
            return;
        }
        

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        taSections.EditSections(Convert.ToInt32(Request.QueryString["SectionId"]),
                                Convert.ToInt32(ddlCategory.SelectedItem.Value),
                                txtSectionName.Text.Trim());

        Response.Redirect("Sections.aspx?SectionId=" + Request.QueryString["SectionId"] + "&ID=True");
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
