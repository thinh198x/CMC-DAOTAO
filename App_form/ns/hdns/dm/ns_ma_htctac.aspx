<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_htctac.aspx.cs" Inherits="f_ns_ma_htctac"
    Title="ns_ma_htctac" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục quyết định" />
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
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="tt,ghichu,nsd,tdl" hamRow="ns_ma_htctac_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã quyết định" DataField="ma" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên quyết định" DataField="ten" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="110px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="tdl" />
                                                    <asp:BoundField DataField="tt" />
                                                    <asp:BoundField DataField="ghichu" />
                                                    <asp:BoundField DataField="nsd" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_ma_htctac_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="Td1" style="padding-top: 10px;" runat="server" align="center">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" OnClick="return ns_ma_htctac_P_IN();form_P_LOI();" Width="100px" />
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
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Mã quyết định" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" ten="Mã quyết định" ReadOnly="true"
                                                                    kt_xoa="G" onchange="ns_ma_htctac_P_KTRA('MA')" Width="270px" MaxLength="20" />
                                                            </td>
                                                            <td style="width: 100px; display: none;">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Tên quyết định" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" ten="Tên quyết định" kt_xoa="X"
                                                        Width="270px" MaxLength="255"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" runat="server" Width="270px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Thay đổi lương</asp:Label>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:kieu ID="tdl" runat="server" lke="X," Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text="X" MaxLength="1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" runat="server" kt_xoa="X" CssClass="css_form" Width="270px"
                                                        kieu_unicode="true" ToolTip="Ghi chú" MaxLength="1000" TextMode="MultiLine" Rows="3" Height="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_ma_htctac_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_ma_htctac_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="mauin" runat="server" Text="Tải mẫu in" OnClick="return ns_ma_htctac_P_BM();form_P_LOI();" Width="120px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_ma_htctac_P_XOA();form_P_LOI();" Width="70px" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,530" />
</asp:Content>
