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

public partial class faqsection : System.Web.UI.Page
{
    dsFAQTableAdapters.FAQTableAdapter taFAQ = new dsFAQTableAdapters.FAQTableAdapter();
    dsFAQ.FAQDataTable dtFAQ;
    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategories = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategories;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["SectionId"] != null)
        {
            int SectionId = Convert.ToInt32(Request.QueryString["SectionId"]);
            dtSections = taSections.SelectSectionsbySectionId(SectionId);
            if (dtSections.Rows.Count > 0)
            {
               
                dtFAQ = taFAQ.SelectQuestionsbySectionId(SectionId);
                if (dtFAQ.Rows.Count > 0)
                {
                    
                    Repeater2.DataSource = dtFAQ;
                 
                    Repeater2.DataBind();
                }
                else
                {
                   
                    Repeater2.Visible = false;
                }
            }
            else
            {
                
                Repeater2.Visible = false;
            }
        }
        else
        {
           
            Repeater2.Visible = false;
        }
    }
    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}