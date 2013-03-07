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

public partial class admin_SectionCategoryEdit : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Edited";
            }
        }

        if (Request.QueryString["CategoryId"] != null)
        {
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            dtCategory = taCategory.SelectSectionCategorybyCategoryId(CategoryId);

            if (dtCategory.Rows.Count > 0)
            {
                DataRow row = dtCategory.Rows[0];
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
        taCategory.EditSectionCategory(CategoryId,
                                       txtCategory.Text.Trim(),
                                       DateTime.Now);

        Response.Redirect("SectionCategories.aspx?ID=True&CategoryId=" + CategoryId);
    }
}
