<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_macvu.aspx.cs" Inherits="f_ht_macvu" 
    Title="ht_macvu" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Chức danh" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
        <tr>
            <td valign="middle">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left" style="width:50px;">
                                        <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" kieu_chu="True"
                                            kt_xoa="G" Width="120px" onchange="ht_macvu_P_KTRA('MA')" />
                                        <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="120px" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Mã q.lý" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ma_ct" runat="server" CssClass="css_ma" Width="120px" kieu_chu="True"
                                            kt_xoa="K" ktra="ht_ma_phong,ma" ten="mã quản lý" onchange="ht_macvu_P_KTRA('ma_ct')" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return ht_macvu_P_NH();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ht_macvu_P_XOA();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                loai="L" hangKt="15" cotAn="ma_ct,nsd" hamRow="ht_macvu_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ma_ct" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                        <td class="css_scrl_td">
                            <khud_scrl:khud_scrl ID="GR_lke_slide" runat="server" loai="L" gridId="GR_lke" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="775,455" />
</asp:Content>
