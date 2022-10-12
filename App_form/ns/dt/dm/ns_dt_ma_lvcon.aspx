<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_ma_lvcon.aspx.cs" Inherits="f_ns_dt_ma_lvcon"
    Title="ns_dt_ma_lvcon" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục lĩnh vực con" />
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
                                        <div class="css_divb">
                                            <div>
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                                    CssClass="table gridX" loai="X" hangKt="10" cot="ten_ma_cha,ten,trangthai,so_id,ma" cotAn="so_id,ma" hamRow="ns_dt_ma_lvcon_GR_lke_RowChange()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField HeaderText="Tên lĩnh vực cha" DataField="ten_ma_cha" HeaderStyle-Width="150px">
                                                            <ItemStyle CssClass="css_Gnd" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Tên lĩnh vực con" DataField="ten" HeaderStyle-Width="150px">
                                                            <ItemStyle CssClass="css_Gnd" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="150px">
                                                            <ItemStyle CssClass="css_Gnd" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="so_id" />
                                                        <asp:BoundField DataField="ma" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divl:ctr_khud_divl id="Ctr_khud_divL" runat="server" loai="X" gridid="GR_lke"
                                                ham="ns_dt_ma_lvcon_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 15px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_lvcon_P_IN();form_P_LOI();" />
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
                                                <td style="width: 114px">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Tên lĩnh vực cha" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_CHA" runat="server" ten="Lĩnh vực cha" ToolTip="Lĩnh vực cha" kt_xoa="G" ktra="DT_MA_CHA" Width="250px" CssClass="css_list" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 114px">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã lĩnh vực con" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã lĩnh vực con" ToolTip="Mã lĩnh vực con" MaxLength="20"
                                                        kt_xoa="X" onfocusout="ns_dt_ma_lvcon_P_KTRA('MA')" Width="250px" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 114px">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên lĩnh vực con" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên lĩnh vực con" ToolTip="Tên lĩnh vực con" Width="250px" MaxLength="255"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 114px">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TRANGTHAI" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_list" runat="server" Width="250px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 114px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="gchu" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" ToolTip="Mô tả"
                                                        Width="250px" MaxLength="1000"></Cthuvien:nd>
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
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_lvcon_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_lvcon_P_NH();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_ma_lvcon_P_XOA();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left">
                                <Cthuvien:gchu ID="ghichu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,550" />
    </div>
</asp:Content>
