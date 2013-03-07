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

public partial class admin_ProductKeyFeatureEdit : System.Web.UI.Page
{
    dsProductKeyFeatureTableAdapters.ProductKeyFeaturesTableAdapter ta = new dsProductKeyFeatureTableAdapters.ProductKeyFeaturesTableAdapter();
    dsProductKeyFeature.ProductKeyFeaturesDataTable dt;

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

        if (Request.QueryString["KeyFeatureId"] != null)
        {
            dt = ta.SelectProductKeyFeaturesbyKeyFeatureId(Convert.ToInt32(Request.QueryString["KeyFeatureId"]));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductKeyFeatures/" + row["Image"].ToString() + "&size=100";
                lblLargeImage.Text = row["Image"].ToString();
                txtSortOrder.Text = row["Sort"].ToString();
                txtTitle.Text = row["Title"].ToString();
                txtDescription.Text = row["Description"].ToString();

            }
            else
            {
                tblProductKeyFeature.Visible = false;
                lblMsg.Text = "Features Details not found";
            }
        }
        else
        {
            tblProductKeyFeature.Visible = false;
            lblMsg.Text = "Features Details not found";
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string filename1 = "";
        if (FileUpload1.HasFile)
        {
            filename1 = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductKeyFeatures\\" + FileUpload1.FileName);
        }
        else
            filename1 = lblLargeImage.Text;

        ta.EditProductKeyFeatures(Convert.ToInt32(Request.QueryString["KeyFeatureId"]),
                                       Convert.ToInt32(txtSortOrder.Text.Trim()),
                                        filename1,
                                        txtTitle.Text.Trim(),
                                        txtDescription.Text.Trim(),
                                        DateTime.Now);

        Response.Redirect("ProductKeyFeatures.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
