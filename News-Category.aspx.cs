    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News_Category : System.Web.UI.Page
{

    dsNewsTableAdapters.NewsCategoryTableAdapter taNewsCategory = new dsNewsTableAdapters.NewsCategoryTableAdapter();
    dsNews.NewsCategoryDataTable dtNewsCategory;
    dsNewsTableAdapters.NewsTableAdapter taNews = new dsNewsTableAdapters.NewsTableAdapter();
    dsNews.NewsDataTable dtNews;

    protected int currentPageNumber = 1;
    private const int PAGE_SIZE = 2;
    protected int pageindex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        ItemsGet();
    }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Set viewstate variable to the previous page
        CurrentPage -= 1;

        // Reload control
        ItemsGet();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Set viewstate variable to the next page
        CurrentPage += 1;

        // Reload control
        ItemsGet();
    }

    private void ItemsGet()
    {
        if (Request.QueryString["NewsCategoryId"] != null)
        {

            int NewsCategoryId = Convert.ToInt32(Request.QueryString["NewsCategoryId"]);
            dtNewsCategory = taNewsCategory.SelectNewsCategoryNameByNewsCategoryId(NewsCategoryId);
            if (dtNewsCategory.Rows.Count > 0)
            {
                int page = 10;
                lblCategoryName.Text = dtNewsCategory[0].NewsCategoryTitle.ToString();
                dtNews = taNews.SelectNewsbyNewsCategoryId(NewsCategoryId);
                if (dtNews.Rows.Count > 0)
                {
                    PagedDataSource objPds = new PagedDataSource();

                    objPds.DataSource = dtNews.DefaultView;
                    objPds.AllowPaging = true;
                    objPds.PageSize = page;

                    objPds.CurrentPageIndex = CurrentPage;
                    //objPds.CurrentPageIndex = CurrentPage - 1; 

                    int count = objPds.PageCount;

                    lblCurrentPage.Text = "Page " + (CurrentPage + 1).ToString() + " of "
                       + objPds.PageCount.ToString();

                    //Disable Prev or Next buttons if necessary
                    //Button1.Visible = !objPds.IsFirstPage;
                    //Button2.Visible = !objPds.IsLastPage;
                    if (objPds.IsFirstPage)
                        Button1.Visible = false;
                    else
                        Button1.Visible = true;

                    if (objPds.IsLastPage)
                        Button2.Visible = false;
                    else
                        Button2.Visible = true;


                    Repeater1.DataSource = objPds;
                    Repeater1.DataBind();


                }
                else
                {
                    Repeater1.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = false;
                }
            }
            else
            {
                Repeater1.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
            }
        }
        else
        {
            Repeater1.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
        }
    }
}