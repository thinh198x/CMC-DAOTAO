<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xembc.aspx.cs" Inherits="f_xembc" Title="xembc"  EnableSessionState="ReadOnly"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display: none">
        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieude" Text="xem" />
    </div>
    <%--<CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" Width="100%" 
                onunload="CRV_Unload"/>--%>
    <div style="width: 100%" align="left">
        <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" OnUnload="CRV_Unload"
            Height="700" Width="1024" HasCrystalLogo="False" HasToggleGroupTreeButton="True"
            SeparatePages="True" DisplayToolbar="True" />
    </div>
    </form>
    <Cthuvien:an id="thumuc" runat="server" />
</body>
</html>
