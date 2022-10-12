﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_bd_bh.aspx.cs" Inherits="f_ns_hdns_ma_bd_bh"
    Title="ns_hdns_ma_bd_bh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục biến động bảo hiểm" />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="ten_nhom,ten_tt,ma_nhom_bd,tt,nsd" hamRow="ns_hdns_ma_bd_bh_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Nhóm biến động" DataField="ten_nhom" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã biến động" DataField="ma" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên biến động" DataField="ten" HeaderStyle-Width="250px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ma_nhom_bd" />
                                                    <asp:BoundField DataField="tt" />
                                                    <asp:BoundField DataField="nsd" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <ctr_khud_divl:ctr_khud_divl id="GR_lke_slide" runat="server" gridid="GR_lke" ham="ns_hdns_ma_bd_bh_P_LKE()" />
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_ma_bd_bh_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Nhóm biến động" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_NHOM_BD" ten="Nhóm biến động" kt_xoa="G" runat="server" Width="270px" ktra="DT_NHOM_BD" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã biến động" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã biến động"
                                                        kt_xoa="G" MaxLength="30" onchange="ns_hdns_ma_bd_bh_P_KTRA('MA')" Width="270px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên biến động" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên biến động"
                                                        Width="270px" MaxLength="100"></Cthuvien:ma>
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
                                                    <Cthuvien:nd ID="mota" ten="Mô tả" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="270px" MaxLength="1000" />
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
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_hdns_ma_bd_bh_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_ma_bd_bh_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_ma_bd_bh_P_XOA();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,510" />
</asp:Content>
