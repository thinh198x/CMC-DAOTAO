<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_lvdt.aspx.cs" Inherits="f_ns_dt_lvdt"
    Title="ns_dt_lvdt" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="right">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Lĩnh vực đào tạo" />
                                    </td>
                                    <td align="right">
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
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="css_divb" style="margin-right: 20px;">
                                                        <div class="css_divCn">
                                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                                                cot="CHON,ma_lvcha,ten_lvcha,tt" cotAn="" hangKt="10">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:kieu ID="CHON" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Mã lĩnh vực" DataField="ma_lvcha" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Tên lĩnh vực" DataField="ten_lvcha" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_lke" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top: 10px">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_LIST();form_P_LOI();" />
                                    </td>
                                    <%--<td>
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_dt_lvdt_P_EXCEL();form_P_LOI();" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="3">
                            <table>
                                <tr>
                                    <td style="display: none">
                                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                    </td>
                                    <td style="display: none">
                                        <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="800,550" />
    </div>
</asp:Content>
