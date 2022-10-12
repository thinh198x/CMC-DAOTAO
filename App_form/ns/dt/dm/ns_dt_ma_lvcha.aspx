<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_ma_lvcha.aspx.cs" Inherits="f_ns_dt_ma_lvcha"
    Title="ns_dt_ma_lvcha" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục lĩnh vực cha" />
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
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                                    CssClass="table gridX" loai="X" hangKt="10" cotAn="" hamRow="ns_dt_ma_lvcha_GR_lke_RowChange()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                            <HeaderStyle Width="10px"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Mã lĩnh vực cha" DataField="ma" HeaderStyle-Width="120px">
                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                            <ItemStyle CssClass="css_Gma" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Tên lĩnh vực cha" DataField="ten" HeaderStyle-Width="200px">
                                                            <HeaderStyle Width="200px"></HeaderStyle>
                                                            <ItemStyle CssClass="css_Gnd" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="120px">
                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                            <ItemStyle CssClass="css_Gnd" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divl:ctr_khud_divl id="Ctr_khud_divL1" runat="server" loai="X" gridid="GR_lke"
                                                ham="ns_dt_ma_lvcha_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 15px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_lvcha_P_IN();form_P_LOI();" />
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
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã lĩnh vực cha" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã lĩnh vực cha" ToolTip="Mã lĩnh vực cha"
                                                                    kt_xoa="G" onchange="ns_dt_ma_lvcha_P_KTRA('MA')" Width="250px" MaxLength="20" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Tên lĩnh vực cha" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên lĩnh vực cha" ToolTip="Tên lĩnh vực cha" MaxLength="255" Width="250px"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_list" runat="server" Width="250px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" MaxLength="1000" ten="Mô tả" ToolTip="Mổ tả" Width="250px"></Cthuvien:nd>
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
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_lvcha_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_lvcha_P_NH();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_ma_lvcha_P_XOA();form_P_LOI();" Width="100px" />
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
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,550" />
</asp:Content>
