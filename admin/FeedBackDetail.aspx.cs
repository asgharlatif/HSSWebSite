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

public partial class admin_FeedBackDetail : System.Web.UI.Page
{
    dsFeedBackTableAdapters.FeedbackTableAdapter taFeedBack = new dsFeedBackTableAdapters.FeedbackTableAdapter();
    dsFeedBack.FeedbackDataTable dtFeedBack;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        BindData();
    }
    private void BindData()
    {
        if (Request.QueryString["FeedBackId"] != null)
        {
            int feedBackId = Convert.ToInt32(Request.QueryString["FeedBackId"]);
            dtFeedBack = taFeedBack.SelectFeedBackbyFeedBackId(feedBackId);
            if (dtFeedBack.Rows.Count > 0)
            {
                DetailsView1.DataSource = dtFeedBack;
                DetailsView1.DataBind();
            }
            else
            {
                DetailsView1.Visible = false;
                lblMsg.Text = "No record found";
            }
        }
        else
        {
            DetailsView1.Visible = false;
            lblMsg.Text = "No record found";
        }
    }
}
