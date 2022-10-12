<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hs_cctc_quyen.aspx.cs" Inherits="f_ns_hs_cctc_quyen"
    Title="ns_hs_cctc_quyen" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách phòng ban" />
                                    </td>
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
                        <td class="form_left">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                    loai="L" hangKt="15" cot="ten,ma,ma_ct,cap,tinh_trang,tc" cotAn="ma,ma_ct,cap,tinh_trang,tc" hamRow="ns_hs_cctc_quyen_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Tên bộ phận" HeaderStyle-Width="350px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten" runat="server" Width="350px" CssClass="css_Gnd" onclick="return ns_hs_cctc_quyen_P_LKE('T');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ma" />
                                        <asp:BoundField DataField="ma_ct" />
                                        <asp:BoundField DataField="cap" />
                                        <asp:BoundField DataField="tinh_trang" />
                                        <asp:BoundField DataField="tc" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div>
                               <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_hs_cctc_quyen_P_LKE('L')" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="80px" OnClick="return form_P_TRA_CHON_GRID('GR_lke:ma,GR_lke:ten');form_P_LOI();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="600,700" />
    <Cthuvien:an ID="ma" runat="server"/>
    <Cthuvien:an ID="ten" runat="server"/>
</asp:Content>
