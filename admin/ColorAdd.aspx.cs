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

public partial class admin_ColorAdd : System.Web.UI.Page
{
    dsColorsTableAdapters.ColorsTableAdapter taColors = new dsColorsTableAdapters.ColorsTableAdapter();
    dsColors.ColorsDataTable dtColors;

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
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taColors.AddColor(txtTitle.Text.Trim(),
                         txtHexaCode.Text.Trim(),
                         DateTime.Now);
        Response.Redirect("ColorAdd.aspx?ID=True");
    }
}
