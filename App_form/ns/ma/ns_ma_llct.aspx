<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_llct.aspx.cs" Inherits="f_ns_ma_llct"
    Title="ns_ma_llct" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
      <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Lý luận chính trị" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
        <tr>
            <td valign="middle">
                <table cellpadding="1" cellspacing="1" >
                    <tr>
                        <td>
                            <table id = "UPa_ct" runat = "server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Mã" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="css_ma" kieu_chu="True"
                                                        kt_xoa="G" onchange = "ns_ma_llct_P_KTRA('MA')" Width="120px" />
                                                </td>
                                                <td style="width: 100px">
                                                    <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" Font-Bold="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Tên</asp:Label>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="190px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-left:39px">
                            <table id = "UPa_nhap" runat ="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_ma_llct_P_NH();form_P_LOI();"
                                            Text="Nhập" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_ma_llct_P_XOA();form_P_LOI();"
                                            Text="Xóa" Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="C_out">
                <div id = "UPa_lke">
                <Cthuvien:GridX ID="GR_lke" runat="server" ctr_sott="sott" mauten="#9fc54e,#3a3a3a,#ffffff"
                        DisplayLayout-ClientSideEvents-AfterRowActivateHandler="ns_ma_llct_GR_lke_ActiveRowChange">
                   <%-- <Bands>
                        <igtbl:UltraGridBand AllowAdd = "Yes">
                            <Columns>
                                <igtbl:UltraGridColumn BaseColumnName="ma" Width="120px">
                                    <Header Caption="Mã">
                                    </Header>
                                    <CellStyle CssClass="css_grid_ma">
                                    </CellStyle>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="ten" Width="250px" AllowUpdate="No">
                                    <Header Caption="Tên">
                                    </Header>
                                    <CellStyle CssClass="css_grid_nd" HorizontalAlign="Left" Width="250px">
                                    </CellStyle>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="nsd" Hidden="True">
                                    <Header Caption="nsd">
                                    </Header>
                                </igtbl:UltraGridColumn>
                            </Columns>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                            AutoGenerateColumns="False" RowHeightDefault="18px">
                            <FrameStyle Height="140px" />
                            <Pager PageSize="7" />
                        </DisplayLayout>--%>
                </Cthuvien:GridX>
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id = "UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="760,320" />
    </div>
</asp:Content>
