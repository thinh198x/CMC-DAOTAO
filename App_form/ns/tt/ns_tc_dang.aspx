<%@ Page Title="ns_tc_dang" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_dang.aspx.cs" Inherits="f_ns_tc_dang" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thông tin đảng viên" />
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
                        <td align="left">
                            <table id="UPa_ct" runat="server"  cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:Dr_nhap ID="PHONG" runat="server" Width="563px" CssClass="css_drop"
                                            onchange="ns_tc_dang_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" kt_xoa="G"
                                                        ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" kieu_chu="true" Width="130px" onchange="ns_tc_dang_P_KTRA('SO_THE')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Số lý lịch Đảng" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SO_LLD" ten="Số lý lịch Đảng" runat="server" CssClass="css_ma" 
                                                        kt_xoa="X" kieu_chu="true" Width="110px"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Số thẻ Đảng" CssClass="css_gchu_c" Width="80px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SOTHE_DANG" ten="Số thẻ Đảng" runat="server" CssClass="css_ma" 
                                                        kt_xoa="X" kieu_chu="true" Width="110px"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Ngày cấp" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYCAP" ten="Ngày cấp" runat="server"  Width="130px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Nơi cấp" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noicap" ten="Nơi cấp" runat="server" kt_xoa="X" CssClass="css_ma" Width="110px" kieu_unicode="true"/>
                                                </td>
                                                <td>
                                                 <asp:Label ID="Label17" runat="server" Text="Lần" CssClass="css_gchu_c" Width="80px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lan" ten="Lần kết nạp" runat="server" CssClass="css_so" 
                                                        kt_xoa="X" kieu_chu="true" Width="110px"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Ngày vào Đảng" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvao" ten="Ngày vào Đảng" runat="server"  Width="130px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Nơi vào Đảng" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noivao" ten="Nơi vào Đảng" runat="server" kt_xoa="X" CssClass="css_ma" Width="310px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Ngày chính thức" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayct" ten="Ngày chính thức" runat="server"  Width="130px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Nơi chính thức" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noict" ten="Nơi chính thức" runat="server" kt_xoa="X" CssClass="css_ma" Width="310px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Người giới thiệu 1" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="nguoi1" ten="Người giới thiệu 1" kieu_unicode="true" runat="server"  Width="130px" CssClass="css_ma" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Chức vụ/Đơn vị" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cvu1" kieu_unicode="true" runat="server" kt_xoa="X" CssClass="css_ma" Width="310px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Người giới thiệu 2" CssClass="css_gchu" Width="110px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="nguoi2" ten="Người giới thiệu 2" kieu_unicode="true" runat="server"  Width="130px" CssClass="css_ma" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Chức vụ/Đơn vị" CssClass="css_gchu_c" Width="105px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cvu2" kieu_unicode="true" runat="server" kt_xoa="X" CssClass="css_ma" Width="310px"
                                                        onchange="ns_tc_dang_P_KTRA('cvu2')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label9" runat="server" Text="Quá trình hoạt động" 
                                CssClass="css_gchu" Font-Bold="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="tt,cvu,donvi,ngayd,ngayc" hangKt="7" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="TT" HeaderStyle-Width="50px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:so ID="tt" runat="server" Width="50px" CssClass="css_Gma_c" />
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chức vụ" HeaderStyle-Width="170px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="cvu" runat="server" Width="170px" CssClass="css_Gma" kieu_unicode="true"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="190px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="donvi" runat="server" Width="190px" CssClass="css_Gma" kieu_unicode="true"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Từ ngày" HeaderStyle-Width="120px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="120px" CssClass="css_Gma_c" kieu_luu="S"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đến ngày" HeaderStyle-Width="120px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="120px" CssClass="css_Gma_c" kieu_luu="S"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
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
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tc_dang_P_NH();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tc_dang_P_MOI();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tc_dang_P_XOA();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_tc_dang_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_tc_dang_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_tc_dang_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_tc_dang_ChenDong('C');" />
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
                                CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id" hamRow="ns_tc_dang_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số lí lịch đảng" DataField="so_lld" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số thẻ đảng" DataField="sothe_dang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="so_id"/>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="100" gridId="GR_lke"
                                ham="ns_tc_dang_P_LKE()" />
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
    <div id ="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1210,560" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
