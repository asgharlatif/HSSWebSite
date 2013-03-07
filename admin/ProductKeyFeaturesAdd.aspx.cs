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

public partial class admin_ProductKeyFeaturesAdd : System.Web.UI.Page
{
    dsProductKeyFeatureTableAdapters.ProductKeyFeaturesTableAdapter ta = new dsProductKeyFeatureTableAdapters.ProductKeyFeaturesTableAdapter();
    dsProductKeyFeature.ProductKeyFeaturesDataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ProductId"] == null)
        {
            tblProductKeyFeatures.Visible = false;
            lblMsg.Text = "Sorry you cannot add Features";
            //return;
        }
        else
        {

            dt = ta.SelectProductNamebyProductId(Convert.ToInt32(Request.QueryString["ProductId"]));

            if (dt.Rows.Count > 0)
                lblProductName.Text = dt.Rows[0]["ProductTitle"].ToString();
            else
            {
                tblProductKeyFeatures.Visible = false;
                lblMsg.Text = "Sorry you cannot add an image";
            }
        }
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
        ta.AddProductKeyFeatures(Convert.ToInt32(Request.QueryString["ProductId"]),
                                       Convert.ToInt32(txtSortOrder.Text.Trim()),
                                       FileUpload1.FileName,
                                       txtTitle.Text.Trim(),
                                       txtDescription.Text.Trim(),
                                       DateTime.Now);

        FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductKeyFeatures\\" + FileUpload1.FileName);
        Response.Redirect("ProductKeyFeatures.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
