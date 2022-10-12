<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tl_hs_lamthemgio.aspx.cs" Inherits="f_ns_tl_hs_lamthemgio"
    Title="ns_tl_hs_lamthemgio" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập hệ số làm thêm giờ" />
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
                            <div>
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="mota,tt,nsd" hamRow="ns_tl_hs_lamthemgio_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Hệ số làm thêm" DataField="heso" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gso" />
                                            <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="mota" />
                                            <asp:BoundField DataField="tt" />
                                            <asp:BoundField DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_tl_hs_lamthemgio_P_LKE()" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Mã</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                    onfocusout="ns_tl_hs_lamthemgio_P_KTRA('MA')" Width="300px" MaxLength="20" />
                                                            </td>
                                                            <td style="width: 100px; display: none">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_nsd" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Width="105px">Hệ số thêm giờ</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="heso" runat="server" ten="Hệ số thêm giờ" CssClass="css_form_r" kt_xoa="X"
                                                     Width="300px" MaxLength="10" co_dau="K" so_tp="2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" Width="300px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" ten="Mô tả" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="300px" MaxLength="1000" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 0px" colspan="2">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_tl_hs_lamthemgio_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_tl_hs_lamthemgio_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td style="display:none">
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_tl_hs_lamthemgio_P_XOA();form_P_LOI();" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="950,510" />
</asp:Content>
