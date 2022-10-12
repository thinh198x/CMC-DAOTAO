<%@ Page Title="ns_tc_qd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_qd.aspx.cs" Inherits="f_ns_tc_qd" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tham gia quân đội" />
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
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:Dr_nhap ID="PHONG" runat="server" Width="366px" CssClass="css_drop"
                                            onchange="ns_tc_qd_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Mã CB" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" kt_xoa="X"
                                                        ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" kieu_chu="true" Width="130px" onchange="ns_tc_qd_P_KTRA('so_the')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Ngày nhập ngũ" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYNHAP" ten="Ngày nhập ngũ" runat="server"  Width="130px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Ngày xuất ngũ" CssClass="css_gchu_c" Width="90px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayxuat" ten="Ngày xuất ngũ" runat="server"  Width="130px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Lý do xuất ngũ" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="LYDO" ten="Lý do xuất ngũ" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Quân chủng" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="quanchung" ten="Quân chủng" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Binh chủng" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="binhchung" ten="Binh chủng" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Quân hàm" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="quanham" ten="Quân hàm" ToolTip="Quân hàm cao nhất" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Đơn vị" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="donvi" ten="Đơn vị" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Chức vụ" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="chucvu" ten="Chức vụ" ToolTip="Chức vụ cao nhất" runat="server" kt_xoa="X" CssClass="css_ma" Width="360px"  kieu_unicode="true"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id ="UPa_nhap" runat ="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tc_qd_P_NH();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tc_qd_P_MOI();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tc_qd_P_XOA();form_P_LOI();" Width="70px" />
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
                                CssClass="table gridX" loai="X" hangKt="11" hamRow="ns_tc_qd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Số Thẻ" DataField="so_the" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                ham="ns_tc_qd_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id ="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
   
        <Cthuvien:an ID="kthuoc" runat="server" Value="810,425" />
</asp:Content>
