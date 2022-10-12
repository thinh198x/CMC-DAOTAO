<%@ Page Title="ns_export" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ns_export.aspx.cs" Inherits="f_ns_export" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="420px">
        <tr>
            <td align="left" colspan="2">
                <Cthuvien:luu ID="ltieude" runat="server" Text="Export dữ liệu" CssClass="css_tieude" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table id="UPa_ct" runat="server" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="display: none">
                                        <Cthuvien:ma ID="ma" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="L" hangKt="10" cotAn="ma_bc,rep,ddan,excel" hamRow="ns_export_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="400px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ma_bc" />
                                    <asp:BoundField DataField="rep" />
                                    <asp:BoundField DataField="ddan" />
                                    <asp:BoundField DataField="excel" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-top: 5px">
                                        <div class="box3 txRight">
                                            <a href="#" class="bt bt-grey" onclick="return ns_export_P_XEM();form_P_LOI();"><span class="txUnderline">X</span>uất</a>
                                        </div>
                                    </td>
                                    <%--<td align="center" colspan="2">
                                        <Cthuvien:nhap ID="nhap" runat="server" giu="false" Text="Xuất File" Width="100px" OnClick="return ns_export_P_XEM();form_P_LOI();" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" /><br />
                <Cthuvien:gchu ID="lrep" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="ten_rp" runat="server" />
    <Cthuvien:an ID="ten_menu" runat="server" />
    <Cthuvien:an ID="ddan" runat="server" Value="~/App_rpt/tt/" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="455,490" />
</asp:Content>
