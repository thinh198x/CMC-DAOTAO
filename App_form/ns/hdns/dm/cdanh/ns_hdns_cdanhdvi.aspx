<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_cdanhdvi.aspx.cs" Inherits="f_ns_hdns_cdanhdvi"
    Title="ns_hdns_cdanhdvi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                        <td class="form_left" valign="top" align="center">
                            <div class="css_divb">
                                <div class="css_divCn">
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                        cot="MA_CD,TEN,ten_nn,ten_cm,ten_nnn,ten_cbnn,SO_ID_CD,ma,ma_plnv,ten_plnv" cotAn="ten_nn,ten_cm,ten_nnn,ten_cbnn,SO_ID_CD,ma,ma_plnv,ten_plnv" hangKt="10">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã chức danh" DataField="MA_CD" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="Tên chức danh" DataField="TEN" HeaderStyle-Width="350px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten_nn" />
                                            <asp:BoundField DataField="ten_cm" />
                                            <asp:BoundField DataField="ten_nnn" />
                                            <asp:BoundField DataField="ten_cbnn" />
                                            <asp:BoundField DataField="SO_ID_CD" />
                                            <asp:BoundField DataField="ma" />
                                            <asp:BoundField DataField="ma_plnv" />
                                            <asp:BoundField DataField="ten_plnv" />
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
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return ns_hdns_cdanhdvi_P_CHON('GR_lke:MA_CD,GR_lke:TEN,GR_lke:ten_nn,GR_lke:ten_cm,GR_lke:ten_nnn,GR_lke:ten_cbnn,GR_lke:ma_plnv,GR_lke:ten_plnv');form_P_LOI();" />
                                    </td>
                                    <td style="display: none">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_cdanhdvi_P_EXCEL();form_P_LOI();" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="680,500" />
    </div>
</asp:Content>
