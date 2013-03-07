using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["ID"].ToString() == "Subscribed")
        {
            Subscribed.Visible = true;
        }

        if (Request["ID"].ToString() == "Feedback")
        {
            Feedback.Visible = true;
        }
    }
}