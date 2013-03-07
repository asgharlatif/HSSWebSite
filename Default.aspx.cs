using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dsNewsTableAdapters.NewsCategoryTableAdapter taNewsCategory = new dsNewsTableAdapters.NewsCategoryTableAdapter();
    dsNews.NewsCategoryDataTable dtNewsCategory;
    dsNewsTableAdapters.NewsTableAdapter taNews = new dsNewsTableAdapters.NewsTableAdapter();
    dsNews.NewsDataTable dtNews;

    public int CurrentPage
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 0;   // default to showing the first page
            else
                return (int)o;
        }

        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }

   

    protected void Page_Load(object sender, EventArgs e)
    {

        

            dtNewsCategory = taNewsCategory.SelectNewsCategoryNameByNewsCategoryId(5);
            if (dtNewsCategory.Rows.Count > 0)
            {
                int page = 10;
                
                dtNews = taNews.SelectNewsbyNewsCategoryId(5);
                if (dtNews.Rows.Count > 0)
                {
                    PagedDataSource objPds = new PagedDataSource();
                    objPds.DataSource = dtNews.DefaultView;
                    objPds.AllowPaging = true;
                    objPds.PageSize = page;
                    objPds.CurrentPageIndex = CurrentPage;           
                    Repeater1.DataSource = objPds;
                    Repeater1.DataBind();
                }
                else
                {
                    Repeater1.Visible = false;                   
                }
            }
            else
            {
                Repeater1.Visible = false;                
            }
      
    }
}