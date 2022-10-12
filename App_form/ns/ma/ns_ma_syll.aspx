<%@ Page Title="ns_ma_syll" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ma_syll.aspx.cs" Inherits="f_ns_ma_syll" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Sơ yếu lý lịch" />
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
            <td>
                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Mã" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="css_ma" kieu_chu="True" kt_xoa="G"
                                onchange="ns_ma_syll_P_KTRA('MA')" Width="256px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X"
                                Width="256px" ten="Tên" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Kiểu" />
                        </td>
                        <td align="left">
                            <table cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:kieu ID="KIEU" runat="server" CssClass="css_ma_c" Width="30px" Text="C"
                                            lke="C,S,N,D" ten="Tên kiểu" ToolTip="C-Chữ,S-Chuỗi,N-Số,D-Ngày" />
                                    </td>
                                    <td>
                                        <Cthuvien:gchu ID="ten_kieu" runat="server" CssClass="css_gchu" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Tham khảo" />
                        </td>
                        <td align="left">
                            <Cthuvien:ma ID="ftkhao" runat="server" CssClass="css_nd" kt_xoa="X" Width="256px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Kiểm tra" />
                        </td>
                        <td align="left">
                            <table cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="ktra" runat="server" kt_xoa="X" CssClass="css_nd" Width="211px" />
                                    </td>
                                    <td>
                                        <Cthuvien:kieu ID="bb" runat="server" CssClass="css_ma_c" Width="33px" Text="K" lke="C,K"
                                            ToolTip="K-Không,C-Có" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="padding-left: 79px">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_ma_syll_P_NH();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_ma_syll_P_XOA();"
                                            Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="7" cotAn="nsd,kieu,ftkhao,ktra,bb,tt" hamRow="ns_ma_syll_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="kieu" DataField="kieu"></asp:BoundField>
                                    <asp:BoundField HeaderText="ftkhao" DataField="ftkhao"></asp:BoundField>
                                    <asp:BoundField HeaderText="ktra" DataField="ktra"></asp:BoundField>
                                    <asp:BoundField HeaderText="bb" DataField="bb"></asp:BoundField>
                                    <asp:BoundField HeaderText="tt" DataField="tt"></asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                       <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                ham="ns_ma_syll_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="800,310" />
</asp:Content>
