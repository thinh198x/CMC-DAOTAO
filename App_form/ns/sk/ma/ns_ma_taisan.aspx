<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_taisan.aspx.cs" Inherits="f_ns_ma_taisan"
    Title="ns_ma_taisan" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục tài sản cấp phát" />
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
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="NHOM,TRANGTHAI,GHICHU,nsd" hamRow="ns_ma_taisan_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã tài sản" DataField="ma" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên tài sản" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="NHOM" />
                                            <asp:BoundField HeaderText="Nhóm tài sản" DataField="TEN_NHOM" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="Số tiền" DataField="SOTIEN" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_r" />
                                            <asp:BoundField DataField="TRANGTHAI" />
                                            <asp:BoundField HeaderText="Trạng thái" DataField="TEN_TRANGTHAI" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="GHICHU" />
                                            <asp:BoundField DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_ma_taisan_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_ma_taisan_P_IN();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left" style="width:80px">
                                        <asp:Label ID="Label2" runat="server" Text="Mã tài sản" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ma" ten="Mã tài sản" runat="server" CssClass="css_form" kieu_chu="True" MaxLength="20"
                                            kt_xoa="G" onchange="ns_ma_taisan_P_KTRA('MA')" Width="300px" ReadOnly="true" BackColor="#f6f7f7" />
                                    </td>
                                    <td style="display: none">
                                        <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" Font-Bold="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Tên tài sản</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" ten="Tên tài sản" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" Width="300px" MaxLength="100" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu">Nhóm tài sản</Cthuvien:bbuoc></td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="NHOM" kt_xoa="G" ten="Nhóm tài sản" CssClass="css_list" ktra="NHOM_TS" runat="server" Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu">Số tiền</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:so ID="SOTIEN" runat="server" ten="số tiền" CssClass="css_form_r" kieu_unicode="True" kt_xoa="X"
                                            Width="300px" MaxLength="15" co_dau="K"></Cthuvien:so>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_list ID="TRANGTHAI" runat="server" Width="300px" CssClass="css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ToolTip="Trạng thái" ten="Trạng thái" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Mô tả" Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="ghichu" ten="Ghi chú" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form"
                                            kieu_unicode="True" kt_xoa="X" Width="300px" MaxLength="1000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_ma_taisan_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_ma_taisan_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON_GRID('GR_lke:NHOM,GR_lke:MA,GR_lke:ten,GR_lke:SOTIEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xo1a" runat="server" Text="Xóa" Width="90px" OnClick="return ns_ma_taisan_P_XOA();form_P_LOI();" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1080,535" />
</asp:Content>
