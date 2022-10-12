<%@ Page Title="ns_bhxh_qt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_bhxh_qt.aspx.cs" Inherits="f_ns_bhxh_qt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quá trình đóng bảo hiểm" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
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
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <table id="Upa_ct" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server" Text="Loại " Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:DR_nhap ID="loaibh" runat="server" Width="156px" CssClass="css_drop" onchange="ns_bhxh_qt_P_LKE_DR()">
                                                                                <asp:ListItem Text="Bảo hiểm xã hội" Value="BHXH" />
                                                                                <asp:ListItem Text="Bảo hiểm thất nghiệp" Value="BHTN" />
                                                                            </Cthuvien:DR_nhap>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label22" runat="server" Width="20px" Text=" " CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:kieu ID="tinh" runat="server" lke="C,K" Text="C" ToolTip="C - Tính thời gian đóng;K - Không tính thời gian đóng và lũy kế " CssClass="css_ma_c" Width="30px" onblur="ns_tinh_namthang();" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Mã số CB" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="K" CssClass="css_ma" kieu_chu="true"
                                                                                gchu="gchu" ten="Mã số cán bộ" Width="150px" ToolTip="Mã số cán bộ" BackColor="#f6f7f7"
                                                                                ktra="ns_bhxh,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_bhxh_P_KTRA('SO_THE')" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label12" runat="server" Width="20px" Text=" " CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="ten" ten="Tên cán bộ" runat="server" kieu_unicode="true" Width="206px"
                                                                                kt_xoa="K" CssClass="css_ma" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text="Số sổ" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="sobhxh" runat="server" ToolTip="Tiền đóng BHXH" Width="150px" kt_xoa="K" CssClass="css_ma_c" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Từ tháng" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:thang  placeholder='MM/yyyy' ID="thangd" runat="server" ToolTip="Từ tháng" Width="150px" kt_xoa="G" CssClass="css_ma_c" onchange="ns_bhxh_qt_P_KTRA('THANGD')" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label2" runat="server" Text="Tới tháng" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:thang  placeholder='MM/yyyy' ID="thangc" runat="server" ToolTip="Tới tháng" Width="150px" kt_xoa="G" CssClass="css_ma_c" onchange="ns_bhxh_qt_P_KTRA('THANGC')" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Nội dung" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="nd" runat="server" ToolTip="Từ tháng" Width="387px" kt_xoa="K" CssClass="css_ma" TextMode="MultiLine" Rows="2" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Thời gian đóng" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td align="center">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="NAM" runat="server" ToolTip="Năm" Width="80px" kt_xoa="G" Text="0" CssClass="css_ma_c" Enabled="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label5" runat="server" Text="Năm" Width="90px" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="THANG" runat="server" ToolTip="Tháng" Width="80px" kt_xoa="G" Text="0" CssClass="css_ma_c" Enabled="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label6" runat="server" Text="Tháng" Width="90px" CssClass="css_gchu" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text="Tổng thời gian" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td align="center">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="tgnam" runat="server" ToolTip="Năm" Width="80px" kt_xoa="G" Text="0" CssClass="css_ma_c"  />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label18" runat="server" Text="Năm" Width="90px" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="tgthang" runat="server" ToolTip="Tháng" Width="80px" kt_xoa="G" Text="0" CssClass="css_ma_c"  />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label21" runat="server" Text="Tháng" Width="90px" CssClass="css_gchu" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text="Hệ số lương" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="hso" runat="server" ToolTip="Tiền lương" Width="150px" kt_xoa="K" CssClass="css_so_c" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label14" runat="server" Text="h.số P.cấp" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="hspc" runat="server" ToolTip="Phụ cấp" Width="150px" kt_xoa="K" CssClass="css_so_c" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Tiền lương" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:so ID="tienluong" runat="server" ToolTip="Tiền lương" Width="150px" kt_xoa="K" CssClass="css_so_c" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server" Text="Tỷ lệ BH" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="tlbh" runat="server" ToolTip="Tỷ lệ BHTN" Width="150px" kt_xoa="X" CssClass="css_so_c" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Ngày đóng" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" runat="server" ToolTip="Tiền đóng BHXH" Width="150px" kt_xoa="X" CssClass="css_ma_c" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label15" runat="server" Text="Tiền đóng" Width="75px" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:so ID="tiendong" runat="server" ToolTip="Tiền đóng BHXH" Width="150px" kt_xoa="X" CssClass="css_so" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nd ID="note" runat="server" ToolTip="Ghi chú" Width="387px" kt_xoa="X" CssClass="css_ma" Height="50px" TextMode="MultiLine" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Phụ cấp" Width="90px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:GridX ID="GR_ct" runat="server" loai="N"
                                                                                AutoGenerateColumns="false" hangKt="3" cot="ma_loai,loai,muc" PageSize="1" CssClass="table gridX" cotAn="ma_loai">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:BoundField HeaderText="Mã" DataField="ma_loai" HeaderStyle-Width="18px" ItemStyle-CssClass="css_Gma" />
                                                                                    <asp:TemplateField HeaderText="Loại" HeaderStyle-Width="250px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:ma ID="loai" runat="server" Width="250px" CssClass="css_Gma" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Mức" HeaderStyle-Width="126px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:so ID="muc" runat="server" Width="126px" CssClass="css_Gma_c" ValueText="0" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_qt_P_NH();form_P_LOI();"
                                                        Text="Nhập" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="moi" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_qt_P_MOI();form_P_LOI();"
                                                        Text="Mới" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_qt_P_XOA();form_P_LOI();"
                                                        Text="Xóa" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="19" hamRow="ns_bhxh_qt_GR_lke_RowChange()">
                                            <Columns>

                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Từ tháng" DataField="thangd" HeaderStyle-Width="80px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tới tháng" DataField="thangc" HeaderStyle-Width="80px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Nội dung" DataField="nd" HeaderStyle-Width="250px"
                                                    ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tiền đóng" DataField="tiendong" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField HeaderText="Tỷ lệ" DataField="tlbh" HeaderStyle-Width="50px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_bhxh_qt_P_LKE()" rong="80" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="css_border" colspan="2">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" kt_xoa="X" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,550" />
    </div>

</asp:Content>
