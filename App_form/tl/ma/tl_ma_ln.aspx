<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_ma_ln.aspx.cs" Inherits="f_tl_ma_ln"
    Title="tl_ma_ln" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đơn giá lợi nhuận" />
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
                        <td>
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Mã doanh thu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" kieu_chu="True" kt_xoa="G"
                                                        onchange="tl_ma_ln_P_KTRA('MA')" Width="120px" ten="Mã doanh thu" />
                                                </td>
                                                <td style="width: 100px">
                                                    <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên doanh thu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN_DT" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X"
                                            Width="192px" ten="Tên doanh thu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Đơn giá" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="dongia" ten="Đơn giá" runat="server" CssClass="css_so" 
                                                        kt_xoa="X" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="/" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="dvi" runat="server" CssClass="css_ma_c" Width="80px" kieu_unicode="true" Text="phút" lke="phút,1000 đồng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-left: 56px">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" OnClick="return tl_ma_ln_P_NH();form_P_LOI();"
                                            Text="Nhập" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" OnClick="return tl_ma_ln_P_XOA();form_P_LOI();"
                                            Text="Xóa" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return form_P_TRA_CHON('MA,TEN_DT');form_P_LOI();"
                                            Text="Chọn" Width="70px" />
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
                                CssClass="table gridX" loai="X" hangKt="5" cotAn="nsd" hamRow="tl_ma_ln_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten_dt" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="tl_ma_ln_P_LKE()" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="650,275" />
    </div>

</asp:Content>
