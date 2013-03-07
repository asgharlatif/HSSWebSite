<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DYLdbConnectionString %>"
            DeleteCommand="DELETE FROM [SecurityPages] WHERE [SecurityPageNameId] = @SecurityPageNameId"
            InsertCommand="INSERT INTO [SecurityPages] ([SecurityPageSectionId], [SecurityPageName]) VALUES (@SecurityPageSectionId, @SecurityPageName)"
            SelectCommand="SELECT * FROM [SecurityPages]" UpdateCommand="UPDATE [SecurityPages] SET [SecurityPageSectionId] = @SecurityPageSectionId, [SecurityPageName] = @SecurityPageName WHERE [SecurityPageNameId] = @SecurityPageNameId">
            <DeleteParameters>
                <asp:Parameter Name="SecurityPageNameId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="SecurityPageSectionId" Type="Int32" />
                <asp:Parameter Name="SecurityPageName" Type="String" />
                <asp:Parameter Name="SecurityPageNameId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="SecurityPageSectionId" Type="Int32" />
                <asp:Parameter Name="SecurityPageName" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="SecurityPageNameId" DataSourceID="SqlDataSource1">
            <EditItemTemplate>
                SecurityPageNameId:
                <asp:Label ID="SecurityPageNameIdLabel1" runat="server" Text='<%# Eval("SecurityPageNameId") %>'>
                </asp:Label><br />
                SecurityPageSectionId:
                <asp:TextBox ID="SecurityPageSectionIdTextBox" runat="server" Text='<%# Bind("SecurityPageSectionId") %>'>
                </asp:TextBox><br />
                SecurityPageName:
                <asp:TextBox ID="SecurityPageNameTextBox" runat="server" Text='<%# Bind("SecurityPageName") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                SecurityPageSectionId:
                <asp:TextBox ID="SecurityPageSectionIdTextBox" runat="server" Text='<%# Bind("SecurityPageSectionId") %>'>
                </asp:TextBox><br />
                SecurityPageName:
                <asp:TextBox ID="SecurityPageNameTextBox" runat="server" Text='<%# Bind("SecurityPageName") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                SecurityPageNameId:
                <asp:Label ID="SecurityPageNameIdLabel" runat="server" Text='<%# Eval("SecurityPageNameId") %>'>
                </asp:Label><br />
                SecurityPageSectionId:
                <asp:Label ID="SecurityPageSectionIdLabel" runat="server" Text='<%# Bind("SecurityPageSectionId") %>'>
                </asp:Label><br />
                SecurityPageName:
                <asp:Label ID="SecurityPageNameLabel" runat="server" Text='<%# Bind("SecurityPageName") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
