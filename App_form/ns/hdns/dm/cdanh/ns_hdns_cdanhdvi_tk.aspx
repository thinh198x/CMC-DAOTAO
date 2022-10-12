<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_cdanhdvi_tk.aspx.cs" Inherits="f_ns_hdns_cdanhdvi_tk"
    Title="ns_hdns_cdanhdvi_tk" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Chức danh theo phòng ban" />
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
                            <div class="css_divb">
                                <div class="css_divCn">
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                        cot="CHON,MA_CD,TEN,SO_ID_CD,ma" cotAn="SO_ID_CD,ma" hangKt="10">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="CHON" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Mã chức danh" DataField="MA_CD" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="Tên chức danh" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="SO_ID_CD" />
                                            <asp:BoundField DataField="ma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divc:ctr_khud_divc id="GR_lke_slide" runat="server" gridid="GR_lke" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_LIST();form_P_LOI();" />
                                    </td>
                                    <td style="display: none">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_cdanhdvi_tk_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
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
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="phong" runat="server" />
        <Cthuvien:an ID="ngay_hl" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="600,500" />
    </div>
</asp:Content>
