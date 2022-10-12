﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_cm.aspx.cs" Inherits="f_ns_hdns_ma_cm"
    Title="ns_hdns_ma_cm" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục chuyên môn" />
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
                        <td class="form_left" valign="top">
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="ma_nn,so_id,tt,nsd" hamRow="ns_hdns_ma_cm_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="ten_nn" HeaderText="Tên ngành nghề" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ma" HeaderText="Mã chuyên môn" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten" HeaderText="Tên chuyên môn" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten_tt" HeaderText="Trạng thái" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ma_nn" />
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="tt" />
                                            <asp:BoundField DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_hdns_ma_cm_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_ma_cm_P_EXCEL();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr style="display: none">
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Ngành nghề" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_NN" ten="Mã ngành nghề" runat="server" Width="270px" ktra="DT_NN" kt_xoa="G" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã chuyên môn" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã chuyên môn"
                                                        kt_xoa="L" MaxLength="10" onchange="ns_hdns_ma_cm_P_KTRA('MA')" Width="270px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên chuyên môn" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên chuyên môn"
                                                        Width="270px" MaxLength="255"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" Width="270px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="270px" MaxLength="1000"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_hdns_ma_cm_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_ma_cm_P_NH();form_P_LOI();" />
                                                            </td>

                                                            <td>
                                                                <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_ma_cm_P_MAU();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_ma_cm_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
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
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_ma_cm_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,530" />
</asp:Content>
