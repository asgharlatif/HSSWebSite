using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for InventoryClass
/// </summary>
public class InventoryClass
{
    connectionstring strConn = new connectionstring();

    enum FormType
    {
        SaleOrder,
        SaleInvoice,
        GeneralLedger
    };

    public InventoryClass()
    {
        //
        // TODO: Add constructor logic here
        //        
    }

    public void FillDocType(String FormName, CheckBoxList clb)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select ordtype, ordtype+' > '+typedesc as order_ From v_inv_form_orderType Where formcode='" + getFormCode(FormName) + "'", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            clb.Items.Add(new ListItem(dtDoc.Rows[i]["order_"].ToString(), dtDoc.Rows[i]["ordtype"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillStatus(String FNN, DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select LevelId, LevelName From v_aut_formLevelsTran Where formid='" + FNN + "' Order by LevelNo", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["LevelName"].ToString(), dtDoc.Rows[i]["LevelId"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillDocType(String FormName, DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select ordtype, ordtype+' > '+typedesc as order_ From v_inv_form_orderType Where formcode='" + getFormCode(FormName) + "' Order by 1 Desc", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["order_"].ToString(), dtDoc.Rows[i]["ordtype"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillShipVia(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select viaName From Bas_Via Order by def desc", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["viaName"].ToString(), dtDoc.Rows[i]["viaName"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillTerm(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select TermName From Bas_Terms Order by def desc", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["TermName"].ToString(), dtDoc.Rows[i]["TermName"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillCurrency(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select CurrencyCode, CurrencyName From Bas_Currency Order by def Desc", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["CurrencyName"].ToString(), dtDoc.Rows[i]["CurrencyCode"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public string getFormCode(String FormName)
    {
        if (FormName == FormType.SaleInvoice.ToString())
        {
            return "SI";
        }
        else if (FormName == FormType.GeneralLedger.ToString())
        {
            return "GL";
        }
        else if (FormName == FormType.SaleOrder.ToString())
        {
            return "SO";
        }
        return null;
    }

    public void fillMyStatus_withString(String FNN, String Mnu, String ModId, DropDownList ddl, Boolean withCode)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtStatus = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select levelid, levelname From v_aut_formlevelstran Where formid='" + FNN + "' and mnuname='" + Mnu + "' and modid='" + ModId + "' Order by levelno", conn);
        adpDB.Fill(dtStatus);
        for (int i = 0; i < dtStatus.Rows.Count; i++)
        {
            if (withCode == true)
            {
                ddl.Items.Add(new ListItem(dtStatus.Rows[i]["levelname"].ToString() + " " + "[" + dtStatus.Rows[i]["LevelId"].ToString() + "]", dtStatus.Rows[i]["LevelId"].ToString()));
            }
            else
            {
            }
        }
        ddl.Items.Add(new ListItem("ALL", "ALL"));
        conn.Close();
    }

    public void FillUnit(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtUnit = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select UCode, UnitDesc From CompUnits", conn);
        adpDB.Fill(dtUnit);
        for (int i = 0; i < dtUnit.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtUnit.Rows[i]["UnitDesc"].ToString(), dtUnit.Rows[i]["UCode"].ToString()));
        }
        dtUnit.Clear();
        conn.Close();
    }

    public void FillLoc(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtLoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select LocationCode, LocationName From CompLocations", conn);
        adpDB.Fill(dtLoc);
        for (int i = 0; i < dtLoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtLoc.Rows[i]["LocationName"].ToString(), dtLoc.Rows[i]["LocationCode"].ToString()));
        }
        dtLoc.Clear();
        conn.Close();
    }

    public void FillDep(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDep = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select DepCode, Name From Department", conn);
        adpDB.Fill(dtDep);
        for (int i = 0; i < dtDep.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDep.Rows[i]["Name"].ToString(), dtDep.Rows[i]["DepCode"].ToString()));
        }
        dtDep.Clear();
        conn.Close();
    }

    public void FillLeaseSchemeGroup(CheckBoxList clb)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtLSG = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select SchmGCode, SchmGName From Lease_ScheemeGroup", conn);
        adpDB.Fill(dtLSG);
        for (int i = 0; i < dtLSG.Rows.Count; i++)
        {
            clb.Items.Add(new ListItem(dtLSG.Rows[i]["SchmGName"].ToString(), dtLSG.Rows[i]["SchmGCode"].ToString()));
        }
        dtLSG.Clear();
        conn.Close();
    }

    public void FillLeaseSchemeGroup(RadioButtonList rbl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtLSG = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select SchmGCode, SchmGName From Lease_ScheemeGroup", conn);
        adpDB.Fill(dtLSG);
        for (int i = 0; i < dtLSG.Rows.Count; i++)
        {
            rbl.Items.Add(new ListItem(dtLSG.Rows[i]["SchmGName"].ToString(), dtLSG.Rows[i]["SchmGCode"].ToString()));
        }
        dtLSG.Clear();
        conn.Close();
    }

    public string RecordSelectionFormulaString(CheckBoxList clb)
    {
        string SchmGCode = "";
        int Count = 0;

        foreach (ListItem li in clb.Items)
        {
            if (li.Selected == true && Count == 0)
            {
                //SchmGCode = "'" + li.Value + "'";
                SchmGCode = li.Value;
                Count = Count + 1;
            }
            else if (li.Selected == true && Count > 0)
            {
                //SchmGCode = SchmGCode + "'" + li.Value + "'";
                SchmGCode = SchmGCode + "*" + li.Value;
                Count = Count + 1;
            }
        }
        return SchmGCode;
    }

    public string RecordSelectionFormulaString1(CheckBoxList clb)
    {
        string SchmGCode = "";
        int Count = 0;

        foreach (ListItem li in clb.Items)
        {
            if (li.Selected == true && Count == 0)
            {
                SchmGCode = "'" + li.Value + "'";
                Count = Count + 1;
            }
            else if (li.Selected == true && Count > 0)
            {
                SchmGCode = SchmGCode + "'" + li.Value + "'";
                Count = Count + 1;
            }
        }
        return SchmGCode;
    }

    public DateTime FinFrom(string Yr)
    {
        DateTime FinFrom;
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDB = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select dbo.FD ('" + Yr + "', 'F') as FinFrom", conn);
        adpDB.Fill(dtDB);
        FinFrom = Convert.ToDateTime(dtDB.Rows[0]["FinFrom"].ToString());
        conn.Close();
        return FinFrom;
    }

    public DateTime FinTo(string Yr)
    {
        DateTime FinTo;
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDB = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select dbo.FD ('" + Yr + "', 'T') as FinTo", conn);
        adpDB.Fill(dtDB);
        FinTo = Convert.ToDateTime(dtDB.Rows[0]["FinTo"].ToString());
        conn.Close();
        return FinTo;
    }

    public void MCModel(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtMCModel = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select EngType, ModelCode From MC_Model Where ItMCode = '006'", conn);
        adpDB.Fill(dtMCModel);
        for (int i = 0; i < dtMCModel.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtMCModel.Rows[i]["EngType"].ToString(), dtMCModel.Rows[i]["EngType"].ToString()));
        }
        dtMCModel.Clear();
        conn.Close();
    }

    public void MCBrand(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtMCBrand = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select Br_Code, Br_desc From inv_Item_Brand", conn);
        adpDB.Fill(dtMCBrand);
        for (int i = 0; i < dtMCBrand.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtMCBrand.Rows[i]["Br_desc"].ToString(), dtMCBrand.Rows[i]["Br_Code"].ToString()));
        }
        dtMCBrand.Clear();
        conn.Close();
    }

    public void PurReason(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection("Data Source=DBSERVER;Initial Catalog=SaleDealer;User ID=sa;Password=masghar");
        conn.Open();
        DataTable dtPurReason = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select pur_rea_code, Pur_rea_Name From Purchase_reason", conn);
        adpDB.Fill(dtPurReason);
        for (int i = 0; i < dtPurReason.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtPurReason.Rows[i]["Pur_rea_Name"].ToString(), dtPurReason.Rows[i]["pur_rea_code"].ToString()));
        }
        dtPurReason.Clear();
        conn.Close();
    }

    public void TypeOfUse(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection("Data Source=DBSERVER;Initial Catalog=SaleDealer;User ID=sa;Password=masghar");
        conn.Open();
        DataTable dtUse = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select use_code, use_Name From MC_type_ofuse", conn);
        adpDB.Fill(dtUse);
        for (int i = 0; i < dtUse.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtUse.Rows[i]["use_Name"].ToString(), dtUse.Rows[i]["use_code"].ToString()));
        }
        dtUse.Clear();
        conn.Close();
    }

    public bool isUserHaveRights(string UserID, string FormID, string MnuFormID)
    {
        bool Flag = false;
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtUserRight = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select view_ From FormTransaction Where logid = '" + UserID + "' and formid = '" + FormID + "' and MnuName = '" + MnuFormID + "' and Modid = '20'", conn);
        adpDB.Fill(dtUserRight);
        foreach (DataRow dr in dtUserRight.Rows)
        {
            Flag = Convert.ToBoolean(dr["view_"]);
        }
        dtUserRight.Clear();
        conn.Close();
        return Flag;
    }

    public void InventoryType(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtInvType = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select ItMDesc, CounterIdentity From Inv_ItemGroup_ForFiction Where active = 1 and webShow = 1", conn);
        adpDB.Fill(dtInvType);
        for (int i = 0; i < dtInvType.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtInvType.Rows[i]["ItMDesc"].ToString(), dtInvType.Rows[i]["CounterIdentity"].ToString()));
        }
        dtInvType.Clear();
        conn.Close();
    }

    public void FillVehicle(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select V_No from v_clm_Vehicle_detail", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["V_No"].ToString(), dtDoc.Rows[i]["V_No"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillItemInClaim(DropDownList ddl, string str)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("SELECT Top 200 Item_Key + ' --> ' + ItemName + ' --> ' + ItemNo as Item, Item_Key FROM Bas_ItemMain WHERE ItemName is not Null and ItemNo is not Null and(ITMCode = '006') Order By " + str + " asc", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["Item"].ToString(), dtDoc.Rows[i]["Item_Key"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public void FillStarShopDealer(DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDoc = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("SELECT DlrId, CompName FROM Bas_Dealer WHERE DlrId like 'Str-%'", conn);
        adpDB.Fill(dtDoc);
        for (int i = 0; i < dtDoc.Rows.Count; i++)
        {
            ddl.Items.Add(new ListItem(dtDoc.Rows[i]["CompName"].ToString(), dtDoc.Rows[i]["DlrId"].ToString()));
        }
        dtDoc.Clear();
        conn.Close();
    }

    public Boolean isReportAllowed(String RPKey, String UserID, String Action)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtReportAllowed = new DataTable();
        if (Action == "Show")
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select * From aut_ReportTransaction Where logid = '" + UserID + "' and ReportKey = '" + RPKey + "' and show_ = 1", conn);
            adpDB.Fill(dtReportAllowed);
        }
        else if (Action == "Print")
        {
            SqlDataAdapter adpDB = new SqlDataAdapter("Select * From aut_ReportTransaction Where logid = '" + UserID + "' and ReportKey = '" + RPKey + "' and print_ = 1", conn);
            adpDB.Fill(dtReportAllowed);
        }

        if (dtReportAllowed.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveHistory(string LogID, int ActivityID)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        SqlCommand command = new SqlCommand("Insert into login_history (logid, logdate, logtime, activityid) Values (@logid, @logdate, @logtime, @activityid)", conn);
        command.Parameters.Add("@logid", SqlDbType.VarChar).Value = LogID;
        command.Parameters.Add("@logdate", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
        command.Parameters.Add("@logtime", SqlDbType.DateTime).Value = DateTime.Now.ToLocalTime();
        command.Parameters.Add("@activityid", SqlDbType.Int).Value = ActivityID;
        command.ExecuteNonQuery();
        conn.Close();
    }

    public string getDealerGL(int LevelNo, string SchmGCode, string DlrCode)
    {
        string ReturnValue = "";
        string T_Key = "", ST_Key = "";
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtDealerGL = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select T_Key, ST_Key From bas_dealer_GLRef Where SchmGCode = '" + SchmGCode + "' and DlrID = '" + DlrCode + "'", conn);
        adpDB.Fill(dtDealerGL);
        if (dtDealerGL.Rows.Count > 0)
        {
            T_Key = dtDealerGL.Rows[0]["T_Key"].ToString();
            ST_Key = dtDealerGL.Rows[0]["ST_Key"].ToString();
        }
        if (LevelNo == 4)
        {
            ReturnValue = T_Key;
        }
        else if (LevelNo == 5)
        {
            ReturnValue = ST_Key;
        }
        return ReturnValue;
    }

    public double DealerBalance(string U, string L, string D, DateTime SD, DateTime TD, string SchmGCode, string DlrCode)
    {
        double OPBal, RunBal, UnTraSIB, TSaleOrder, TSaleInvoice, CredLimit, PendSOBalance, DealerBalance;
        string T_Key = "", ST_Key = "";

        T_Key = getDealerGL(4, SchmGCode, DlrCode);
        ST_Key = getDealerGL(5, SchmGCode, DlrCode);

        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dtGiveOpeningBalance = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select dbo.inv_Fnc_GiveOpeningBalance('" + U + "', '" + L + "', '" + T_Key + "', '" + ST_Key + "', dbo.Inv_Fnc_GetSt('" + T_Key + "'), '07')", conn);
        adpDB.Fill(dtGiveOpeningBalance);

        DataTable dttstBalance = new DataTable();
        adpDB = new SqlDataAdapter("Select dbo.inv_Fnc_tstBalance('" + U + "', '" + L + "', '" + T_Key + "', '" + ST_Key + "', dbo.Inv_Fnc_GetSt('" + T_Key + "'), '" + SD + "', '" + TD + "')", conn);
        adpDB.Fill(dttstBalance);

        DataTable dtUnTraSIB = new DataTable();
        adpDB = new SqlDataAdapter("Select dbo.Get_SaleInvoiceS_Total_SpareParts('" + U + "', '" + L + "', '" + D + "', '" + "MO" + "', '" + DlrCode + "')", conn);
        adpDB.Fill(dtUnTraSIB);

        DataTable dtTSaleOrder = new DataTable();
        adpDB = new SqlDataAdapter("Select dbo.Get_SaleOrderS_Total_SpareParts('" + U + "', '" + L + "', '" + D + "', '" + "MO" + "', '" + DlrCode + "')", conn);
        adpDB.Fill(dtTSaleOrder);

        DataTable dtTSaleInvoice = new DataTable();
        adpDB = new SqlDataAdapter("Select dbo.Get_SaleInvoiceS_Pending_Total_SpareParts('" + U + "', '" + L + "', '" + D + "', '" + "MO" + "', '" + DlrCode + "')", conn);
        adpDB.Fill(dtTSaleInvoice);

        DataTable dtCreditLimit = new DataTable();
        adpDB = new SqlDataAdapter("Select dbo.bas_dealer_limit('" + DlrCode + "')", conn);
        adpDB.Fill(dtCreditLimit);

        OPBal = -1 * Convert.ToDouble(dtGiveOpeningBalance.Rows[0][0].ToString());
        RunBal = -1 * Convert.ToDouble(dttstBalance.Rows[0][0].ToString());
        UnTraSIB = Convert.ToDouble(dtUnTraSIB.Rows[0][0].ToString());
        TSaleOrder = Convert.ToDouble(dtTSaleOrder.Rows[0][0].ToString());
        TSaleInvoice = Convert.ToDouble(dtTSaleInvoice.Rows[0][0].ToString());
        PendSOBalance = TSaleOrder - TSaleInvoice;
        CredLimit = Convert.ToDouble(dtCreditLimit.Rows[0][0].ToString());
        DealerBalance = (OPBal + RunBal + CredLimit) - (UnTraSIB + PendSOBalance);
        return DealerBalance;
    }

    public string getItemPrice(string Item_Key, string UCode, string LCode)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select IsNull(SalePr,0) as StdPr from Inv_prices Where Item_Key = '" + Item_Key + "' and UCode = '" + UCode + "' and LCode ='" + LCode + "'", conn);
        adpDB.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["StdPr"].ToString();
        }
        else
        {
            return null;
        }
    }

    public string getItemWarranty(string Item_Key)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select warName from Inv_Warranty_info Where war_code = (Select war_code from Bas_ItemDesc where Item_Key = '" + Item_Key + "')", conn);
        adpDB.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["warName"].ToString();
        }
        else
        {
            return null;
        }
    }

    public string getItemBrand(string Item_Key)
    {
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("Select Br_desc from Inv_Item_brand Where br_code = (Select Br_code from Bas_ItemDesc where Item_Key = '" + Item_Key + "')", conn);
        adpDB.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Br_desc"].ToString();
        }
        else
        {
            return null;
        }
    }

    public int getTotalItemDisplyed(string ItemName)
    {
        int Qty = 0;
        SqlConnection conn = new SqlConnection(strConn.connect());
        conn.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adpDB = new SqlDataAdapter("SELECT * FROM singleRecordSetting_Default Where LineDesc = '" + ItemName + "'", conn);
        adpDB.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Qty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
        }
        return Qty;
    }
}
