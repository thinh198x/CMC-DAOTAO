<%@ Page Title="hd_ma_tuyendung" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hd_ma_tuyendung.aspx.cs" Inherits="f_hd_ma_tuyendung" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập số vòng tuyển dụng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
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
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="8" cotAn="nsd, so_id,ma_cdanh,
                                            mon_i_dmax,mon_i_diem,mon_ii_dmax,mon_ii_diem,mon_iii_dmax,mon_iii_diem,ghichu,nsd"
                                                hamRow="hd_ma_tuyendung_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Vòng 1" DataField="MON_I" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Vòng 2" DataField="MON_II" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Vòng 3" DataField="MON_III" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SO_ID"></asp:BoundField>
                                                    <asp:BoundField DataField="ma_cdanh"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_i_dmax"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_i_diem"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_ii_dmax"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_ii_diem"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_iii_dmax"></asp:BoundField>
                                                    <asp:BoundField DataField="mon_iii_diem"></asp:BoundField>
                                                    <asp:BoundField DataField="ghichu"></asp:BoundField>
                                                    <asp:BoundField DataField="nsd"></asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="hd_ma_tuyendung_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return hd_ma_tuyendung_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" style="text-align: left;" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Chức danh" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 196px">
                                        <Cthuvien:DR_lke ID="MA_CDANH" runat="server" Width="160px" ten="Chức danh" kt_xoa="X" ktra="DT_CDANH" />
                                    </td>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label12" runat="server" Text="Vòng 1" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="MON_I" runat="server" CssClass="css_form" kt_xoa="X"
                                            ten="vòng 1" gchu="gchu" Width="160px" MaxLength="255" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Thang điểm vòng 1" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_I_dmax" runat="server" CssClass="css_form_r" kieu_chu="true" kt_xoa="X"
                                            ten="Thang điểm vòng thi 1" gchu="gchu" Width="160px" co_dau="K" MaxLength="15" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Đạt điểm vòng 1" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_I_diem" runat="server" CssClass="css_form_r" kieu_chu="true" kt_xoa="X"
                                            so_tp="2" ten="Đạt điểm vòng thi 1" gchu="gchu" Width="160px" co_dau="K" MaxLength="15" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Vòng 2" Width="120px" CssClass="css_gchu" Height="16px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="mon_II" runat="server" CssClass="css_form" kt_xoa="X"
                                            ten="chức vụ" gchu="gchu" Width="160px" MaxLength="255" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Thang điểm vòng 2" Width="120px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_II_dmax" runat="server" CssClass="css_form_r" kt_xoa="X"
                                            ten="Thang điểm vòng thi 2" gchu="gchu" co_dau="K" Width="160px" MaxLength="15" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Đạt điểm vòng 2" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_II_diem" runat="server" CssClass="css_form_r" co_dau="K" kt_xoa="X"
                                            so_tp="2" ten="Đạt điểm vòng thi 2" gchu="gchu" Width="160px" MaxLength="15" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Vòng 3" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="mon_III" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                            ToolTip="vòng thi 3" MaxLength="255" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Thang điểm vòng 3" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_III_dmax" runat="server" CssClass="css_form_r" kt_xoa="X" Width="160px"
                                            so_tp="2" ToolTip="Thang điểm vòng thi 3" co_dau="K" MaxLength="15" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Đạt điểm vòng 3" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="mon_III_diem" runat="server" CssClass="css_form_r" kt_xoa="X" Width="160px"
                                            so_tp="2" ToolTip="Điểm thi vòng 3" co_dau="K" MaxLength="15" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Mô tả" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td colspan="3" align="left">
                                        <Cthuvien:nd ID="ghichu" ten="Ghi chú" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form" kieu_unicode="True"
                                            kt_xoa="X" Width="486px" MaxLength="1000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <Cthuvien:so ID="so_id" runat="server" CssClass="css_form hiden" kieu_chu="true" kt_xoa="X"
                                            gchu="gchu" Width="450px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <table id="UPa_nhap" runat="server" class="box3 txRight">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="100px" OnClick="return hd_ma_tuyendung_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="100px" OnClick="return hd_ma_tuyendung_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return hd_ma_tuyendung_P_MAU();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return hd_ma_tuyendung_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="100px" OnServerClick="FileMau_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="100px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="100px" OnClick="return hd_ma_tuyendung_P_XOA();form_P_LOI();" />
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
                </table>
                <div id="UPa_gchu" class="css_border" align="left" style="height: 19px">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1250,470" />
</asp:Content>
