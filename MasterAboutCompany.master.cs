using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterAboutCompany : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.QueryString["qv"])
        {
            case "bs":  
                 lblaboutthecompany.Text = "About Badi Shops";
                 lblCompanyProfile.Text="Badi Shops profile detail";
                 lblHotSale.Text = "Hot Sale of Badi Shops";
                 lblFeaturedProducts.Text = "Featured Products of Badi shops";
                 lblInquiretocompany.Text = "Make Inquiry to Badi Shops";
                 lblMapLocation.Text = "Map Location of Badi Shops";
                 break;
             case "bc":
                                 lblaboutthecompany.Text = "About Black Copper";
                                 lblCompanyProfile.Text = "Black Copper profile detail";
                                 lblHotSale.Text = "Hot Sale of Black Copper";
                                 lblFeaturedProducts.Text = "Featured Products of Black Copper";
                                 lblInquiretocompany.Text = "Make Inquiry to Black Copper";
                                 lblMapLocation.Text = "Map Location of Black Copper";

                break;
            case "wa":
                                 lblaboutthecompany.Text = "About Web Art";
                                 lblCompanyProfile.Text = "Web Art profile detail";
                                 lblHotSale.Text = "Hot Sale of Web Art";
                                 lblFeaturedProducts.Text = "Featured Products of Web Art";
                                 lblInquiretocompany.Text = "Make Inquiry to Web Art";
                                 lblMapLocation.Text = "Map Location of Web Art";
                break;
            case "mb":
                                                 lblaboutthecompany.Text = "About MB Communication";
                                                 lblCompanyProfile.Text = "MB profile detail";
                                                 lblHotSale.Text = "Hot Sale of MB";
                                                 lblFeaturedProducts.Text = "Featured Products of MB";
                                                 lblInquiretocompany.Text = "Make Inquiry to MB";
                                                 lblMapLocation.Text = "Map Location of MB";

                break;
            case "bb":
                                                                 lblaboutthecompany.Text = "About BikenBike";
                                                                 lblCompanyProfile.Text = "BikenBike profile detail";
                                                                 lblHotSale.Text = "Hot Sale of BikenBike";
                                                                 lblFeaturedProducts.Text = "Featured Products of BikenBike";
                                                                 lblInquiretocompany.Text = "Make Inquiry to BikenBike";
                                                                 lblMapLocation.Text = "Map Location of BikenBike";

                break;

        }


        
    }
}
