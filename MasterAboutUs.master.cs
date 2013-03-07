using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterAboutUs : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["flag"]==null )
        imgFlag.ImageUrl = "frontimages/SmallPics/Flag2.gif";
        else
            imgFlag.ImageUrl = "frontimages/SmallPics/Flag" +Request.QueryString["flag"] + ".gif";

    }
}
