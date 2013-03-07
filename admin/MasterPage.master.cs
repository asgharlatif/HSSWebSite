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

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;
    dsSecurityTableAdapters.SecurityPageSectionsTableAdapter taSecurityPageSections = new dsSecurityTableAdapters.SecurityPageSectionsTableAdapter();
    dsSecurity.SecurityPageSectionsDataTable dtSecurityPageSections;
    dsSecurityTableAdapters.SecurityPagesTableAdapter taSecurityPages = new dsSecurityTableAdapters.SecurityPagesTableAdapter();
    dsSecurity.SecurityPagesDataTable dtSecurityPages;
    dsSecurityTableAdapters.PermissionsTableAdapter taPermissions = new dsSecurityTableAdapters.PermissionsTableAdapter();
    dsSecurity.PermissionsDataTable dtPermissions;


    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["DYL"];
        if (cookie == null)
        {
            string ReturnURL = Request.RawUrl.ToString();
            Response.Redirect("Login.aspx?msg=Your session has expired due to inactivity. Please login again.&ReturnURL=" + ReturnURL);
        }
        else
        {
            int AdminId = Convert.ToInt32(cookie["userid"]);
            dtAdmin = taAdmin.GetDataByAdminId(AdminId);
            string currentPageName = GetCurrentPageName();
            if (dtAdmin[0].Type.ToString() != "admin")
            {
                if (currentPageName != "home.aspx" 
                    && currentPageName != "ChangePassword.aspx" 
                    && currentPageName != "Logout.aspx" 
                    && currentPageName != "PermissionDenied.aspx")
                {
                    dtSecurityPages = taSecurityPages.GetDataByPageName(currentPageName);
                    if (dtSecurityPages.Rows.Count > 0)
                    {
                        int SectionId = Convert.ToInt32(dtSecurityPages[0].SecurityPageSectionId);
                        dtPermissions = taPermissions.GetDataBySecurityPageSectionId(SectionId,AdminId);
                        if (dtPermissions.Rows.Count < 1)
                            Response.Redirect("PermissionDenied.aspx");
                        else
                            return;
                    }
                    else
                        Response.Redirect("PermissionDenied.aspx");
                }
                else
                    return;
            }
        }
        
    }

    public string GetCurrentPageName()
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        return sRet;
    } 
}
