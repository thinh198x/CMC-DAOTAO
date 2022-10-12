<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="xexcel.aspx.cs" Inherits="f_xexcel" Title="xexcel" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: none">
        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieude" Text="xem" />
    </div>
    <Cthuvien:an id="thumuc" runat="server" />
    <Cthuvien:an id="kthuoc" runat="server" value="0,0" />
</asp:Content>
