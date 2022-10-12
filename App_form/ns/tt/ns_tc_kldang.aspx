<%@ Page Title="ns_tc_kldang" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_kldang.aspx.cs" Inherits="f_ns_tc_kldang" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kỷ luật đảng" />
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
                <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="90px" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px"
                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_tc_kldang_P_KTRA('SO_THE')"
                                            gchu="gchu" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Số quyết định" Width="80px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="SO_QD" ten="Số quyết định" runat="server" kt_xoa="X" CssClass="css_ma"
                                            Width="120px" kieu_chu="true" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Hình thức KL" CssClass="css_gchu_c" Width="90px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="hinhthuc" ten="Hình thức kỷ luật" ToolTip="Hình thức kỷ luật" runat="server"
                                            CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_ma_htkl,ma,ten" kieu_chu="true"
                                            Width="120px" kt_xoa="X" f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_htkl.aspx" onchange="ns_tc_kldang_P_KTRA('hinhthuc')"
                                            gchu="gchu" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Nguyên nhân" Width="90px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="nguyennhan" ten="Nguyên nhân kỷ luật" ToolTip="Nguyên nhân kỷ luật"
                                runat="server" kt_xoa="X" CssClass="css_ma" Width="340px" kieu_unicode="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" Text="Ngày quyết định" CssClass="css_gchu"
                                Width="95px" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayqd" ten="Ngày quyết định" runat="server" Width="120px" CssClass="css_ma_c"
                                            kt_xoa="X" kieu_luu="S" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" Text="Cấp quyết định" Width="90px" CssClass="css_gchu_c" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="capqd" ten="Cấp quyết định" runat="server" kt_xoa="X" CssClass="css_ma"
                                            Width="120px" kieu_unicode="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Kỷ luật từ ngày" CssClass="css_gchu"
                                Width="90px" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" ten="Kỷ luật từ ngày" runat="server" Width="120px" CssClass="css_ma_c"
                                            kt_xoa="X" kieu_luu="S" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Đến ngày" CssClass="css_gchu_c" Width="90px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYC" ten="Kỷ luật đến ngày" ToolTip="Kỷ luật đến ngày" runat="server"
                                            Width="120px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Cơ quan" Width="90px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="coquan" ten="Cơ quan" ToolTip="Cơ quan ra quyết định kỷ luật" runat="server"
                                kt_xoa="X" CssClass="css_ma" Width="340px" kieu_unicode="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Người ký" Width="90px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:ma ID="nguoiky" ten="Người ký" ToolTip="Người ký quyết định" runat="server"
                                            kt_xoa="X" CssClass="css_ma" Width="120px" kieu_unicode="true" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label13" runat="server" Text="Chức vụ" Width="90px" CssClass="css_gchu_c" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="cvu" ten="Chức vụ người ký" ToolTip="Chức vụ người ký" runat="server"
                                            kt_xoa="X" CssClass="css_ma" Width="120px" kieu_unicode="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                        </td>
                        <td align="left">
                            <Cthuvien:nd Height="50px" ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_ma"
                                Width="340px" kieu_unicode="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label11" runat="server" Text="Trục xuất khỏi Đảng: " CssClass="css_gchu" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label15" runat="server" Text="   " CssClass="css_gchu" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:kieu ID="tt" runat="server" Text="K" lke="C,K" ToolTip="K - Không, C - Có" 
                                            Width="20px" CssClass="css_ma_c" BackColor="#00ccff" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tc_kldang_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tc_kldang_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tc_kldang_P_XOA();form_P_LOI();"
                                            Width="70px" />
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
                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id" hamRow="ns_tc_kldang_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="120px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="120px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="ns_tc_kldang_P_LKE()" />
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
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="845,435" />
    
</asp:Content>
