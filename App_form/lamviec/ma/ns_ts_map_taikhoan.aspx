<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ts_map_taikhoan.aspx.cs" Inherits="f_ns_ts_map_taikhoan"
    Title="ns_ts_map_taikhoan" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách dự án" />
                        </td>
                        <td align="right">
                            <table id="UPa_dau" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Img1" runat="server" alt="" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img3" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left" style="width: 120px;">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Mã quản lý" />
                                                </td>
                                                <td align="left"> 
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="138px" kt_xoa="X" f_tkhao="~/App_form/ht/ht_mansd.aspx" gchu="gchu" ten="Tài khoản" ktra="ht_ma_nsd,ma,ten" />
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" onchange="ns_hd_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten"/>                                            

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc runat="server" CssClass="css_gchu" Text="Mã cá nhân" Width="120px"/>
                                                </td>
                                                <td align="left">
                                                     <Cthuvien:ma ID="MA_CN" kt_xoa="X"  runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="138px" f_tkhao="~/App_form/ht/ht_mansd.aspx" gchu="gchu" ten="Tài khoản" ktra="ht_ma_nsd,ma,ten" /> 
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td>
                                        <table id="Table1" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left" style="width: 60px;">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Họ tên" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ho_ten" runat="server" CssClass="css_ma" Width="138px"
                                                        kieu_chu="True" kt_xoa="G" ten="loại tài sản" onchange="ns_ts_map_taikhoan_P_KTRA('MA')" />
                                                    <Cthuvien:gchu ID="Gchu1" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc runat="server" CssClass="css_gchu" Text="Tên" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="mota" runat="server" CssClass="css_nd" kt_xoa="X" Width="212px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td style="width: 60px;" />
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Lưu" OnClick="return ns_ts_map_taikhoan_P_NH();" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ts_map_taikhoan_P_XOA();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" Width="70px"
                                                        Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="L" hangKt="15" cotAn="nsd" hamRow="ns_ts_map_taikhoan_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã quản lý" DataField="ma" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã cá nhân" DataField="ma_cn" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="800,460" />
</asp:Content>
