using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News_Detail : System.Web.UI.Page
{
    dsNewsTableAdapters.NewsCategoryTableAdapter taNewsCategory = new dsNewsTableAdapters.NewsCategoryTableAdapter();
    dsNews.NewsCategoryDataTable dtNewsCategory;
    dsNewsTableAdapters.NewsTableAdapter taNews = new dsNewsTableAdapters.NewsTableAdapter();
    dsNews.NewsDataTable dtNews;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["NewsId"] != null)
        {
            int NewsId = Convert.ToInt32(Request.QueryString["NewsId"]);
            dtNews = taNews.SelectNewsbyNewsId(NewsId);
            if (dtNews.Rows.Count > 0)
            {
                lblNewsTitle.Text = dtNews[0].Title.ToString();
                imgNews.ImageUrl = "thumbnail.aspx?Image=Images/NewsImages/" + dtNews[0].MainImage.ToString() + "&size=500";
                lblNewsDescription.Text = dtNews[0].LongDescription.ToString();
            }
            else
            {
                imgNews.Visible = false;
                lblNewsDescription.Visible = false;
            }
        }
        else
        {
            imgNews.Visible = false;
            lblNewsDescription.Visible = false;
        }

    }

    //protected override SiteMapNode OnSiteMapResolve(SiteMapResolveEventArgs e)
    //{
    //    SiteMapNode homeNode = SiteMap.RootNode.Clone();
    //    homeNode.ChildNodes = new SiteMapNodeCollection();
    //    SiteMapNode newsEventsNode = new SiteMapNode(e.Provider, Guid.NewGuid().ToString());
    //    SiteMapNode newsCategoryNode = new SiteMapNode(e.Provider, Guid.NewGuid().ToString());
    //    SiteMapNode newsNode = new SiteMapNode(e.Provider, Guid.NewGuid().ToString());
    //    int newsID = Convert.ToInt32(Request.QueryString["NewsId"]);
    //    dtNews = taNews.SelectNewsbyNewsId(newsID);
    //    if (dtNews.Rows.Count > 0)
    //    {
    //        int newsCategoryId = Convert.ToInt32(dtNews[0].NewsCategoryId);
    //        dtNewsCategory = taNewsCategory.SelectNewsCategoryNameByNewsCategoryId(newsCategoryId);
    //        if (dtNewsCategory.Rows.Count > 0)
    //        {
    //            newsEventsNode.ChildNodes = new SiteMapNodeCollection();
    //            newsEventsNode.Title = "News and Events";
    //            newsEventsNode.ChildNodes.Add(newsEventsNode);
    //            newsEventsNode.ParentNode = homeNode;
    //            newsEventsNode.Url = "News-Category.aspx?NewsCategoryId=5";

    //            newsCategoryNode.Title = dtNewsCategory[0].NewsCategoryTitle.ToString();
    //            newsCategoryNode.ParentNode = newsEventsNode;
    //            newsCategoryNode.Url = "News-Category.aspx?NewsCategoryId=" + newsCategoryId.ToString();

    //            newsNode.Title = dtNews[0].Title.ToString();
    //            newsNode.ParentNode = newsCategoryNode;
    //        }
    //    }
    //    return newsNode;
    //}
}