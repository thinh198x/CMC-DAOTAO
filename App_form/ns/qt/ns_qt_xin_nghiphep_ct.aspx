<%@ Page Title="ns_qt_xin_nghiphep_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_xin_nghiphep_ct.aspx.cs" Inherits="f_ns_qt_xin_nghiphep_ct" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đơn xin nghỉ" />
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
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Mã Số CB" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="150px"
                                            f_tkhao="~/App_form/ns/tt/ns_danhsach.aspx" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('SO_THE')" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Họ tên" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="TEN" ten="Tên khóa học" runat="server" kieu_unicode="true" CssClass="css_ma"
                                            Width="366px" kt_xoa="K" disabled="true" />
                                    </td>
                                </tr>
                                 <tr style="display:none">
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Mã chức danh" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="cdanh" ten="Tên khóa học" runat="server" kieu_unicode="true" CssClass="css_ma"
                                            Width="366px" kt_xoa="K" disabled="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Chức danh" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="ten_cdanh" ten="Tên chức danh" runat="server" kieu_unicode="true" CssClass="css_ma"
                                            Width="366px" kt_xoa="K" disabled="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Phòng" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="PHONG" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma" disabled="true"
                                            CssClass="css_drop" kieu="S" Width="372px" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('PHONG')"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Mã cán bộ thay thế" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="sothe_thaythe" ten="Mã cán bộ thay thế công việc" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="150px" kt_xoa="G"
                                            f_tkhao="~/App_form/ns/tt/ns_danhsach.aspx" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('SOTHE_THAYTHE')" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Người duyệt" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="nguoiduyet" ten="Mã cán bộ duyệt" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="150px" kt_xoa="G"
                                            f_tkhao="~/App_form/ns/tt/ns_danhsach.aspx" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('NGUOIDUYET')" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Lý do nghỉ" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="macc_nghi" ten="Lý do nghỉ" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_drop" kieu="S" Width="156px" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('MA_CC')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Từ ngày" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="css_ma_c" kieu_luu="S" Width="150px" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('NGAYD')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Loại" Width="60px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="gio_bd" runat="server" CssClass="css_drop" Width="150px"  onchange="ns_qt_xin_nghiphep_ct_P_KTRA('GIO_BD')">
                                                        <asp:ListItem Value="CN" Text="Cả ngày(ca)" />
                                                        <asp:ListItem Value="NC" Text="Nửa ngày(ca) cuối" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Tới ngày" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Từ ngày" runat="server" CssClass="css_ma_c" kieu_luu="S" Width="150px" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('NGAYC')" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Loại" Width="60px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="gio_kt" runat="server" Width="150px" CssClass="css_drop" onchange="ns_qt_xin_nghiphep_ct_P_KTRA('GIO_KT')">
                                                        <asp:ListItem Value="CN" Text="Cả ngày(ca)" />
                                                        <asp:ListItem Value="ND" Text="Nửa ngày(ca) đầu" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Số ngày nghỉ" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="ngaynghi" runat="server" Width="50px" CssClass="css_so_c" kt_xoa="X" so_tp="2" disabled="true"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Đã nghỉ" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="danghi" runat="server" Width="50px" CssClass="css_so_c" so_tp="2" disabled="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="Nghỉ phép còn" Width="105px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="nghicon" runat="server" Width="50px" CssClass="css_so_c" so_tp="2" disabled="true"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Ngày xin nghỉ" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayxn" ten="Ngày xin nghỉ" runat="server" CssClass="css_ma_c" kt_xoa="K" kieu_luu="S" Width="150px" disabled="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Nội dung" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="noidung" ten="Nội dung khóa học" runat="server" kieu_unicode="true"
                                            CssClass="css_ma" Width="366px" TextMode="MultiLine" Rows="2" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Ý kiến cấp trên" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="ykien" ten="Ý kiến cấp trên" kieu_unicode="true" runat="server" CssClass="css_ma"
                                            Width="366px" kt_xoa="X" disabled="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_qt_xin_nghiphep_ct_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_qt_xin_nghiphep_ct_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_qt_xin_nghiphep_ct_P_XOA();form_P_LOI();"
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
                                            CssClass="table gridX" loai="X" hangKt="17" hamRow="ns_qt_xin_nghiphep_ct_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày xin nghỉ" DataField="ngayxn" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Người PD" DataField="nguoi_pd" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_qt_xin_nghiphep_ct_P_LKE()" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1150,540" />
</asp:Content>
