<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dm_ky_dg.aspx.cs" Inherits="f_ns_dm_ky_dg"
    Title="ns_dm_ky_dg" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục kỳ đánh giá " />
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
                            <table cellpadding="0" cellspacing="0" width="500px">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd" hamRow="ns_dm_ky_dg_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã kỳ đánh giá" DataField="ma" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên kỳ đánh giá" DataField="ten" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ngày BĐ kỳ đánh giá" DataField="ngay_d" HeaderStyle-Width="105px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ngày KT kỳ đánh giá" DataField="ngay_c" HeaderStyle-Width="105px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dm_ky_dg_P_LKE('K')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 40px;">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" OnServerClick="excel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã kỳ đánh giá" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã"
                                                                    kt_xoa="G" onchange="ns_dm_ky_dg_P_KTRA('MA')" Width="190px" MaxLength="20" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên kỳ đánh giá" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                        Width="190px" ten="Tên"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Ngày BĐ kỳ ĐG" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" ten="Ngày bắt đầu CV" runat="server" CssClass="css_form_c" kieu_luu="I"
                                                                        Width="163px" kt_xoa="X" ToolTip="Ngày bắt đầu CV" />
                                                                    <%--                                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" ten="Ngày bắt đầu kỳ đánh giá" runat="server"
                                                                        CssClass="css_form_c" Width="162px" kt_xoa="X" />
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Ngày KT kỳ ĐG" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" ten="Ngày bắt đầu CV" runat="server" CssClass="css_form_c" kieu_luu="I"
                                                                        Width="163px" kt_xoa="X" ToolTip="Ngày bắt đầu CV" />
                                                                    <%--<Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" ten="Ngày kết thúc kỳ đánh giá" runat="server"
                                                                        CssClass="css_form_c" Width="162px" kt_xoa="G" kieu_luu="I" />
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Thời gian thực hiện ĐG từ" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="thoigian_d" ten="Ngày bắt đầu CV" runat="server" CssClass="css_form_c" kieu_luu="I"
                                                                        Width="163px" kt_xoa="X" ToolTip="Ngày bắt đầu CV" />
                                                                    <%--   <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="thoigian_d" ten="Ngày kết thúc kỳ đánh giá" runat="server"
                                                                        CssClass="css_form_c" Width="162px" kt_xoa="G" kieu_luu="I" />
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Thời gian thực hiện ĐG đến" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="thoigian_c" ten="Ngày bắt đầu CV" runat="server" CssClass="css_form_c" kieu_luu="I"
                                                                        Width="163px" kt_xoa="X" ToolTip="Ngày bắt đầu CV" />
                                                                    <%--  <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="thoigian_c" ten="Thời gian thực hiện ĐG đến" runat="server"
                                                                        CssClass="css_form_c" Width="162px" kt_xoa="G" kieu_luu="I" />
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Mô tả" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="mo_ta" MaxLength="250" runat="server" CssClass="css_form" Width="190px" kieu_unicode="true" TextMode="MultiLine" Height="80px" kt_xoa="X" ten="Ghi Chú" />
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
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="ns_dm_ky_dg_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="ns_dm_ky_dg_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="ns_dm_ky_dg_P_XOA();form_P_LOI();" Width="70px" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="950,550" />
</asp:Content>
