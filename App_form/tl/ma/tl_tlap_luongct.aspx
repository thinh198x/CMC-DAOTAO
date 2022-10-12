<%@ Page Title="tl_tlap_luongct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_luongct.aspx.cs" Inherits="f_tl_tlap_luongct" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập lương tối thiểu (công ty)" />
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
                <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <table cellspacing="0">
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="90px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="100px" kieu_luu="S"
                                                        ten="Ngày hiệu lực" onchange = "tl_tlap_luongct_P_KTRA('NGAY')" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Số QĐ" Width="80px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="so_qd" runat="server" CssClass="css_ma" kt_xoa="X" Width="100px"
                                                        ten="Số quyết định" ToolTip="Số quyết định" kieu_chu="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu_c" Text="Ngày QĐ" Width="60px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_qd" runat="server" CssClass="css_ma_c" kt_xoa="X" Width="100px"
                                                        ten="Ngày quyết định" ToolTip="Ngày quyết định" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Số tiền" Width="80px" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="tien" runat="server" CssClass="css_so" kt_xoa="X" Width="289px"
                                            ten="Số tiền" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Ghi chú" Width="80px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" runat="server" CssClass="css_nd" kt_xoa="X" Width="289px" Height="50px"
                                            ten="Ghi chú"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id = "UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_tlap_luongct_P_NH();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_tlap_luongct_P_MOI();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_tlap_luongct_P_XOA();form_P_LOI();" Width="70px"/>
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
                                CssClass="table gridX" loai="X" hangKt="15" hamRow="tl_tlap_luongct_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="tl_tlap_luongct_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id ="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="610,470" />
    </div>
</asp:Content>
