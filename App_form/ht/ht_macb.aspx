<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_macb.aspx.cs" Inherits="f_ht_macb"
    Title="ht_macb" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Mã cán bộ" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
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
                <table id="UPa_ct" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left" style="width:55px;">
                            <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu" Text="Phòng" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="PHONG" runat="server" CssClass="css_ma" Width="100px" kt_xoa="K" 
                                f_tkhao="~/App_form/ht/ht_maph.aspx" gchu="gchu" kieu_chu="True" 
                                ktra="ht_ma_phong,ma,ten" ten="mã phòng" onchange="ht_macb_P_KTRA('PHONG')" />
                            <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <Cthuvien:bbuoc ID="Lable8" runat="server" CssClass="css_gchu" Text="Mã" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" Width="100px" 
                                kieu_chu="True" kt_xoa="G" ten="mã cán bộ" onchange="ht_macb_P_KTRA('MA')" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên cán bộ" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="220px" ten="tên" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Số CMT" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="so_cmt" runat="server" CssClass="css_nd" kt_xoa="X" Width="220px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Chức vụ" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="cv" runat="server" CssClass="css_nd" Width="220px" 
                                kt_xoa="X" f_tkhao="~/App_form/ht/ht_macvu.aspx" ktra="ht_ma_cvu,ma,ten" 
                                ten="mã chức vụ" onchange="ht_macb_P_KTRA('cv')" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="center">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return ht_macb_P_NH();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ht_macb_P_XOA();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA');" />
                                        <img id="dia" runat="server" alt="" src="~/images/bitmaps/dia.gif" 
                                            title="Lấy số liệu vào từ File" onclick="return ht_macb_FILE();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label22" runat="server" CssClass="css_gchu" Text="Tìm" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="tim_ten" runat="server" CssClass="css_nd" TabIndex="-1" Width="220px" kt_xoa="K" nhap="false" onblur="ht_macb_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                loai="X" hangKt="15" hamRow="ht_macb_GR_lke_RowChange()" >
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                        <td class="css_scrl_td">
                            <khud_scrl:khud_scrl ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_macb_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="840,560" />
</asp:Content>
