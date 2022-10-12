<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_noi_khambenh.aspx.cs" Inherits="f_ns_hdns_ma_noi_khambenh"
    Title="ns_hdns_ma_noi_khambenh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục nơi khám chữa bệnh" />
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
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="tt,nsd" hamRow="ns_hdns_ma_noi_khambenh_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã bệnh viện" DataField="ma" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên bệnh viện" DataField="ten" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Địa chỉ" DataField="diachi" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tỉnh/thành phố" DataField="ten_tpho" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Quận huyện" DataField="ten_qhuyen" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="tt" />
                                                    <asp:BoundField DataField="nsd" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                            <ctr_khud_divl:ctr_khud_divl id="GR_lke_slide" runat="server" gridid="GR_lke" ham="ns_hdns_ma_noi_khambenh_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_ma_noi_khambenh_P_EXCEL();form_P_LOI();" />
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
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã bệnh viện" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã bệnh viện"
                                                        kt_xoa="G" MaxLength="20" onchange="ns_hdns_ma_noi_khambenh_P_KTRA('MA')" Width="270px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên bệnh viện" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên bệnh viện"
                                                        Width="270px" MaxLength="100"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Địa chỉ</asp:Label>

                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="diachi" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên bệnh viện"
                                                        Width="270px" MaxLength="255"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Tỉnh/thành phố</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="tpho" runat="server" Width="270px" kt_xoa="X" ktra="DT_TPHO" onchange="P_LKE_QUANHUYEN()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Quận/huyện</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="qhuyen" runat="server" Width="270px" kt_xoa="L" ktra="DT_QHUYEN" />
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="css_gchu">Xã/phường</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="xphuong" ten="Trạng thái" runat="server" Width="270px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" Width="270px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
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
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_hdns_ma_noi_khambenh_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_ma_noi_khambenh_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_ma_noi_khambenh_P_MAU();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_ma_noi_khambenh_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_ma_noi_khambenh_P_XOA();form_P_LOI();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="center">
                                                    <table>
                                                        </table>
                                                </td>
                                            </tr>--%>
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1370,530" />
</asp:Content>
