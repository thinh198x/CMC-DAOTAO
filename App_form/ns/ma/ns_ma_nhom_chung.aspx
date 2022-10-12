<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_nhom_chung.aspx.cs" Inherits="f_ns_ma_nhom_chung"
    Title="ns_ma_nhom_chung" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Nhóm danh mục dùng chung" />
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
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" cotAn="nsd,trangthai" hangKt="10" hamRow="ns_ma_nhom_chung_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="css_Gma" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="240px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="nsd" DataField="nsd" />
                                            <asp:BoundField HeaderText="trangthai" DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_ma_nhom_chung_P_LKE()" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Mã nhóm danh mục" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="css_form" kieu_chu="True"
                                                        kt_xoa="G" onchange="ns_ma_nhom_chung_P_KTRA('MA')" Width="240px" MaxLength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Tên nhóm danh mục" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" Width="240px" MaxLength="255" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Trạng thái</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="trangthai" runat="server" Width="240px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" kieu_unicode="True" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="240px" MaxLength="200"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 39px">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton" width="100%">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_ma_nhom_chung_P_MOI();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_ma_nhom_chung_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_ma_nhom_chung_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,500" />
</asp:Content>
