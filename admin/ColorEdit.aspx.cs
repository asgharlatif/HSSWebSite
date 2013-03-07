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

public partial class admin_ColorEdit : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Edited";
            }
        } 
        
        if (Request.QueryString["ColorId"] != null)
        {
            int colorId = Convert.ToInt32(Request.QueryString["ColorId"].ToString());
            dtColors = taColors.SelectColorbyColorId(colorId);
            if (dtColors.Rows.Count > 0)
            {
                txtTitle.Text = dtColors[0].ColorTitle.ToString();
                txtHexaCode.Text = dtColors[0].HexaCode.ToString();
            }
        }
        else
        {
            tblColor.Visible = false;
            lblMsg.Text = "No Record Found";
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int colorId = Convert.ToInt32(Request.QueryString["ColorId"]);

        taColors.EditColor(colorId,
                          txtTitle.Text.Trim(),
                          txtHexaCode.Text.Trim(),
                          DateTime.Now);

        Response.Redirect("Colors.aspx?ColorId=" + colorId + "&ID=True");
    }
}
