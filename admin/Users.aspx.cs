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

public partial class admin_Users : System.Web.UI.Page
{
    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;

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

        BindData();
    }
    private void BindData()
    {
        dtAdmin = taAdmin.GetAllUsers();
        if (dtAdmin.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtAdmin;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int UserId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UserEdit.aspx?UserId=" + UserId);
        }
    }
}
