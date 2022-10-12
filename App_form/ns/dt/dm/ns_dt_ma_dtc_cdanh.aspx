<%@ Page Title="ns_dt_ma_dtc_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_dtc_cdanh.aspx.cs" Inherits="f_ns_dt_ma_dtc_cdanh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Danh mục đào tạo chuẩn theo chức danh" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div class="css_divb">
                                            <div>
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_ma_dtc_cdanh_GR_lke_RowChange()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="kdt" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="230px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField DataField="so_id" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_dtc_cdanh_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 15px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_dtc_cdanh_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left" style="padding-top: 27px" colspan="4">
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Tên khóa đào tạo" Width="115px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div style="display: none">
                                                        <Cthuvien:ma ID="so_id" runat="server" kt_xoa="G" />
                                                    </div>
                                                    <Cthuvien:DR_lke ID="KDT" runat="server" ten="Tên khóa đào tạo" ToolTip="Khóa đào tạo" kt_xoa="X" ktra="DT_KDT" Width="418px" CssClass="css_list" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Chức danh" Width="115px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" valign="top" style="padding-top: 2px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="css_divb" style="margin-right: 20px;">
                                                                    <div class="css_divCn">
                                                                        <Cthuvien:GridX ID="GR_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" cot="ma_cd,ten" cotAn="" hangKt="4">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã chức danh(*)" HeaderStyle-Width="130px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ma_cd" runat="server" Width="130px" CssClass="css_Gma" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" kieu_chu="false" ReadOnly="true" placeholder="Nhấn (F1)" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Tên chức danh(*)" DataField="ten" HeaderStyle-Width="230px" ItemStyle-CssClass="css_Gnd" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                    <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_cdanh" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-top: 0px;">
                                                                <table id="UPa_nhap_gr_cd" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="center" valign="middle">
                                                                            <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return  cdanh_HangLen();" />
                                                                        </td>
                                                                        <td align="center" valign="middle">
                                                                            <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return  cdanh_HangXuong();" />
                                                                        </td>
                                                                        <td align="center" valign="middle">
                                                                            <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return cdanh_CatDong();" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text="Trạng thái" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_list ID="TRANGTHAI" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_list" runat="server" Width="418px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Mô tả" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" ToolTip="Mô tả"
                                                        Width="418px" MaxLength="1000"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-top: 0px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="css_divb" style="margin-right: 20px;">
                                                        <div class="css_divCn">
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="N" cot="so_id,nhom_nluc,nluc,ten_nluc,muc_nluc,ten_muc_nluc" cotAn="so_id,nluc,muc_nluc" hangKt="4" gchuId="gchu">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField DataField="so_id" />
                                                                    <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="170px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="nhom_nluc" runat="server" CssClass="css_Gnd" kt_xoa="X" Width="170px" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" ReadOnly="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="nluc" />
                                                                    <asp:TemplateField HeaderText="Năng lực" HeaderStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ten_nluc" runat="server" Width="150px" CssClass="css_Gnd" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" ReadOnly="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="muc_nluc" />
                                                                    <asp:TemplateField HeaderText="Mức năng lực" HeaderStyle-Width="155px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ten_muc_nluc" runat="server" Width="155px" CssClass="css_Gnd" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" ReadOnly="true" placeholder="Nhấn (F1)" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc2" runat="server" gridId="GR_ct" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top: 0px;">
                                                    <table id="UPa_nhap_grd_dd" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dt_ma_dtc_cdanh_HangLen(1);" />
                                                            </td>
                                                            <td align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dt_ma_dtc_cdanh_HangXuong(1);" />
                                                            </td>
                                                            <td align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_dtc_cdanh_CatDong(1);" />
                                                            </td>
                                                            <td align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dt_ma_dtc_cdanh_ChenDong('C');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" style="padding-top: 20px">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_dtc_cdanh_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_dtc_cdanh_P_NH();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_ma_dtc_cdanh_P_XOA();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,700" />
    </div>
</asp:Content>
