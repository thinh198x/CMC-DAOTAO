<%@ Page Title="ns_tc_dangl2" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_dangl2.aspx.cs" Inherits="f_ns_tc_dangl2" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="kết nạp đảng lần 1" />
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
                <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>

                                        <Cthuvien:DR_nhap ID="PHONG" runat="server" Width="492px" CssClass="css_drop"
                                            onchange="ns_tc_dangl2_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="SO_THE" runat="server" ten="Mã số cán bộ" ToolTip="Mã số cán bộ"
                                            CssClass="css_ma" Width="150px" nhap="true" BackColor="#f6f7f7" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                            ktra="ns_cb,so_the,ten" kt_xoa="G" onchange="ns_tc_dangl2_P_KTRA('so_the')" kieu_chu="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Ngày vào Đảng" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvao" runat="server" CssClass="css_so_c" Width="150px" nhap="true"
                                                        kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Width="125" Text="Nơi vào" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noivao" runat="server" CssClass="css_ma" Width="200px" nhap="true"
                                                        kt_xoa="X" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Ngày chính thức" CssClass="css_gchu"
                                            Width="100px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>

                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayct" runat="server" Width="150px" CssClass="css_so_c" nhap="true"
                                                        kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Nơi chính thức" CssClass="css_gchu_c" Width="125px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noict" runat="server" Width="200px" CssClass="css_ma" nhap="true"
                                                        kt_xoa="X" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Ngày phục hồi" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>

                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayph" runat="server" ToolTip="Ngày được phục hồi" Width="150px"
                                                        CssClass="css_so_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Nơi được phục hồi" CssClass="css_gchu_c" Width="125px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noiph" runat="server" ToolTip="Nơi được phục hồi" Width="200px"
                                                        CssClass="css_ma" kt_xoa="X" kieu_unicode="true" />
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Người GT 1" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>

                                                <td>
                                                    <Cthuvien:ma ID="nguoi1" runat="server" ToolTip="Người giới thiệu 1" CssClass="css_ma"
                                                        nhap="true" kt_xoa="X" kieu_unicode="true" Width="150px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="C.vụ/ ĐV Người GT 1" CssClass="css_gchu_c"
                                                        Width="125px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cvu1" runat="server" ToolTip="Chức vụ/ Đơn vị Người giới thiệu 1"
                                                        nhap="true" kt_xoa="X" kieu_unicode="true" Width="200px" CssClass="css_ma" />
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Người GT 2" CssClass="css_gchu" Width="100px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>


                                                <td>
                                                    <Cthuvien:ma ID="nguoi2" runat="server" ToolTip="Người giới thiệu 2" CssClass="css_ma"
                                                        nhap="true" kt_xoa="X" kieu_unicode="true" Width="150px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="C.vụ/ ĐV Người GT 2" CssClass="css_gchu_c"
                                                        Width="125px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cvu2" runat="server" ToolTip="Chức vụ/ Đơn vị Người giới thiệu 2"
                                                        nhap="true" kt_xoa="X" kieu_unicode="true" Width="200px" CssClass="css_ma" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                            <table cellpadding="0" cellspacing="0" id="Upa_nhap" style="padding-top: 10px;">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" CssClass="css_button"
                                            OnClick="return ns_tc_dangl2_P_NH();form_P_LOI();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" CssClass="css_button"
                                            OnClick="return ns_tc_dangl2_P_MOI();form_P_LOI();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" CssClass="css_button"
                                            OnClick="return ns_tc_dangl2_P_XOA();form_P_LOI();" />
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
                                CssClass="table gridX" loai="X" hangKt="9" hamRow="ns_tc_dangl2_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Số Thẻ" DataField="so_the" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_ma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                ham="ns_tc_dangl2_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="945,365" />
</asp:Content>
