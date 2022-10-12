<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menuN.aspx.cs" Inherits="f_menuN"
    Title="menu" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" EnableViewState="false">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:40px; background-color:#5a6e6c;">
                        <td align="left" valign="top" style="width: 340px;" >
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_cmcAc.jpg" />
                        </td>
                        <td valign="top" style="background-color: #5a6e6c">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/qtdn.gif" />
                                    </td>
                                    <td valign="bottom" align="right">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/cmcsoftslogan.gif" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color:#799c9c;">
                <div id="div_bar" runat="server" style="background-color: transparent;" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="top">
                            <div id="div_goc" runat="server" style="background-color: transparent;" />
                            <div id="div_phu" runat="server" style="background-color: transparent;" />
                        </td>
                        <td align="right">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:luu ID="Lb_dvi" runat="server" ForeColor="Teal" Text="Don vi" Font-Names="Tahoma" Font-Size="Small" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Lb_phong" runat="server" ForeColor="Teal" Text="Phong" Font-Names="Tahoma" Font-Size="Small" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Lb_nsd" runat="server" ForeColor="Teal" Text="Nsd" Font-Names="Tahoma" Font-Size="Small" Font-Italic="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="0,0" />
    <Cthuvien:an ID="tm" runat="server" />
</asp:Content>
