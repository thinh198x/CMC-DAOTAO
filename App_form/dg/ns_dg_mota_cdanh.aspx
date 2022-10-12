<%@ Page Title="ns_dg_mota_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_mota_cdanh.aspx.cs" Inherits="f_ns_dg_mota_cdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Mô tả chức danh công việc" />
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
                <table border="0" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Mã chức danh" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MACDANH" runat="server" kt_xoa="K" CssClass="css_ma" ten="Mã sản phẩm"
                                                        ToolTip="Mã sản phẩm" kieu_chu="true" Width="115px" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx"
                                                        ktra="ns_ma_cdanh,ma,ten" onchange="ns_dg_mota_cdanh_P_KTRA('MACDANH')" BackColor="#f6f7f7" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Ngày quyết định" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayqd" runat="server" Width="115px" CssClass="css_ma" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="gtrid,gtric" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Công việc" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="gtrid" runat="server" Width="250px" CssClass="css_Gma" so_tp="2" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="350px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="gtric" runat="server" Width="350px" CssClass="css_Gma" so_tp="2" />
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
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_mota_cdanh_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_mota_cdanh_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_mota_cdanh_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:hso');form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dg_mota_cdanh_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dg_mota_cdanh_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_mota_cdanh_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_mota_cdanh_ChenDong('C');" />
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
                                CssClass="table gridX" loai="X" hangKt="8" cotAn="so_id" hamRow="ns_dg_mota_cdanh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="ns_dg_mota_cdanh_P_LKE()" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="820,370" />
    </div>
</asp:Content>
