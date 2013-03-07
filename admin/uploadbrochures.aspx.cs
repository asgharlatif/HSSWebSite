using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClassP;


public partial class admin_uploadbrochures : System.Web.UI.Page
{
    dsLanguagesTableAdapters.LanguagesTableAdapter taLanguages = new dsLanguagesTableAdapters.LanguagesTableAdapter();
    dsLanguages.LanguagesDataTable dtLanguages;

    dsDocumentsTableAdapters.DocumentsTableAdapter taDocuments = new dsDocumentsTableAdapters.DocumentsTableAdapter();
    dsDocuments.DocumentsDataTable dtDocuments;

    dsOperatingSystemTableAdapters.OperatingSystemTableAdapter taOperatingSystem = new dsOperatingSystemTableAdapters.OperatingSystemTableAdapter();
    dsOperatingSystem.OperatingSystemDataTable dtOperatingSystem;


    dsProductDocumentationTableAdapters.ProductDocumentationTableAdapter taProductDocumentation = new dsProductDocumentationTableAdapters.ProductDocumentationTableAdapter();
    dsProductDocumentation.ProductDocumentationDataTable dtProductDocumentation;

    

    connectionstring constr = new connectionstring();
    ylibWebClass ylib;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        BindData();

        if (Request.QueryString["ProductId"] != null)
        {
            lblProductId.Text = Request.QueryString["ProductId"].ToString();     
        }

        if (Request.QueryString["ID"] != null)
        {

            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited . Ready to open folder.";
            }
        }
    }

    private void BindData()
    {
       

        FillWebControlClass FCC = new FillWebControlClass();

        int ProductId; int DocumentId; int LanguageId; int OSId; int OSDocumenType;

        #region SetListVariables

        ProductId = StringOperation.QueryStringInt16Value(Request.QueryString["ProductId"]);
        DocumentId = StringOperation.QueryStringInt16Value(Request.QueryString["DocumentId"]);
        LanguageId = StringOperation.QueryStringInt16Value(Request.QueryString["LanguageId"]);

        OSDocumenType = StringOperation.QueryStringInt16Value(Request.QueryString["OSDocumenType"]);
        OSId = StringOperation.QueryStringInt16Value(Request.QueryString["OSId"]);

        if (OSDocumenType == 0)
        {
            lblDocumentype.Text = "Documents ";
            DocDriverType.Text = "(PDF,DOC,DOCX,XLS,XLSX,TXT)";
            RegularExpressionValidator1.ErrorMessage = "You must select a .pdf, .doc,.docx, .xls,.xlsx file to upload.";
            RegularExpressionValidator1.ValidationExpression = "^.+\\.((doc)|(DOC)|(docx)|(DOCX)|(pdf)|(PDF)|(xls)|(XLS)(xlsx)|(XLSX)|(TXT)|(txt))$";
 
        }
        else if (OSDocumenType == 1)
        {
            lblDocumentype.Text = "Drivers ";
            DocDriverType.Text = "(EXE,RAR)";
            RegularExpressionValidator1.ErrorMessage = "You must select a .exe, .rar file to upload.";
            RegularExpressionValidator1.ValidationExpression = "^.+\\.((exe)|(EXE)|(rar)|(RAR))$";
        }

        #endregion

        #region FillDropDownLists

        dtDocuments = taDocuments.GetData();
        FCC.FillDropDownList(ref ddlBrochureName, dtDocuments, "DocumentName", "DocumentId", true, true, DocumentId.ToString());

        dtLanguages = taLanguages.GetData();
        FCC.FillDropDownList(ref ddlLanguage, dtLanguages, "LanguageName", "LanguageId", true, true, LanguageId.ToString());

        dtOperatingSystem = taOperatingSystem.GetDataByDocumenType(Convert.ToInt16(OSDocumenType));
        FCC.FillDropDownList(ref ddlOS, dtOperatingSystem, "OSDescription", "OSId",true,true, OSId.ToString());

        #endregion
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int DocumentId;
        int ProductId;
        int LanguageId;
        int OSId;

        ProductId = Convert.ToInt16(Request.QueryString["ProductId"]);
        DocumentId = StringOperation.QueryStringInt16Value(Request.QueryString["DocumentId"]);
        LanguageId = StringOperation.QueryStringInt16Value(Request.QueryString["LanguageId"]);
        OSId = StringOperation.QueryStringInt16Value(Request.QueryString["OSId"]);
        

        if (flfPDF.HasFile)

            flfPDF.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Documentation\\" + DocumentId.ToString() + "-" + LanguageId + "-" + OSId+ "-"  + ProductId.ToString() +  System.IO.Path.GetExtension(flfPDF.FileName));


        if (flfThumbNail.HasFile)
            flfThumbNail.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Documentation\\DocumentationThumbNail\\" + DocumentId.ToString() + "-" + LanguageId  + "-" + OSId + "-" + ProductId.ToString() + System.IO.Path.GetExtension(flfThumbNail.FileName));

        taProductDocumentation.Insert(ProductId, Convert.ToInt16(ddlLanguage.SelectedItem.Value.ToString()), Convert.ToInt16(ddlBrochureName.SelectedItem.Value.ToString()), txtDescription.Text, flfThumbNail.FileName, flfPDF.FileName, OSId);

        Response.Redirect("DocumentsDetails.aspx?ProductId=" + Request.QueryString["ProductId"] + "&DocumentId=" + Request.QueryString["DocumentId"] + "&DocumenType=" + Request.QueryString["DocumenType"].ToString() + "&osDocumenType=" + Request.QueryString["osDocumenType"].ToString() + "&ID=True");

    }

  
}