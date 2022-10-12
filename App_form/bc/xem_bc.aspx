<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="xem_bc.aspx.cs" Inherits="f_xem_bc" Title="xem_bc" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: none">
        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieude" Text="xem" />
    </div>
    <div style="width: 100%" align="left">
        <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" OnUnload="CRV_Unload"
            Height="700" Width="1024" HasCrystalLogo="False" HasToggleGroupTreeButton="True"
             SeparatePages="True" DisplayToolbar="True"   />
    </div>
    <Cthuvien:an id="thumuc" runat="server" />
    <Cthuvien:an id="kthuoc" runat="server" value="0,0" />
</asp:Content>
