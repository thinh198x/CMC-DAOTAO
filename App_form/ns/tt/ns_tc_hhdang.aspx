<%@ Page Title="ns_tc_hhdang" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_hhdang.aspx.cs" Inherits="f_ns_tc_hhdang" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Huy hiệu đảng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
            <td>
                <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="60px" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten"
                                            ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_tc_hhdang_P_KTRA('SO_THE')" gchu="gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Huy hiệu" CssClass="css_gchu" Width="60px" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="HHD" ten="Huy hiệu" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_ma_hhdang,ma,ten"
                                            kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/ma/ns_ma_hhdang.aspx" onchange="ns_tc_hhdang_P_KTRA('HHD')" gchu="gchu" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Năm nhận" Width="60px" CssClass="css_gchu_c" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="NAM" ten="Năm nhận" runat="server" kt_xoa="X" CssClass="css_so" Width="120px" kieu_so="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="60px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_nd" Width="310px" kieu_unicode="true" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tc_hhdang_P_NH();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tc_hhdang_P_MOI();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tc_hhdang_P_XOA();form_P_LOI();" Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="6" cotAn="so_id" hamRow="ns_tc_hhdang_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Huy Hiệu Đảng" DataField="hhd" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Năm nhận" DataField="nam" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                ham="ns_tc_hhdang_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="790,310" />
    </div>
</asp:Content>
