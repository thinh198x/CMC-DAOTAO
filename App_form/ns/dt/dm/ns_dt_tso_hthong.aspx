<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tso_hthong.aspx.cs" Inherits="f_ns_dt_tso_hthong"
    Title="ns_dt_tso_hthong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tham số hệ thống" />
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
                        <td valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="L" hangKt="10" cot="ma,ten,tt " cotAn="" hamRow="ns_dt_ma_tso_hthong_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã danh mục" DataField="ma" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên danh mục" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_ma_tso_hthong_P_LKE()" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 20px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_tso_hthong_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Width="80px" Text="Mã danh mục" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G" Width="220px" onchange="ns_dt_ma_tso_hthong_P_KTRA('MA')" MaxLength="20" ten="Mã danh mục" ToolTip="Mã danhh mục" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên danh mục" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" ten="Tên danh mục" ToolTip="Tên danh mục" kt_xoa="X" Width="220px" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Trạng thái" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="tt" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_list" runat="server" Width="220px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Mô tả" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" ToolTip="Mô tả"
                                                        Width="270px" ten="Mô tả"></Cthuvien:nd>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" style="padding-top: 20px">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_tso_hthong_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_tso_hthong_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_ma_tso_hthong_P_XOA();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="940,510" />
</asp:Content>
