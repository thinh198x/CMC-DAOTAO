<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelView.aspx.cs" Inherits="ExcelView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ExcelView</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td >
                        <asp:Panel ID="pnlTopPane" runat="server">
                            <Cthuvien:nhap ID="save" runat="server" Text="Save" OnServerClick="Save_Click" Height="20px" />
                            <br />
                            <asp:Label ID="lblErrText" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="ExcelPanel" runat="server" Height="500" Width="1000" ScrollBars="Auto" BorderWidth="1px">
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div id="UPa_hi">
            <Cthuvien:an ID="output" runat="server" />
            <Cthuvien:an ID="kthuoc" runat="server" Value="1200,700" />
        </div>
    </form>
</body>
</html>
