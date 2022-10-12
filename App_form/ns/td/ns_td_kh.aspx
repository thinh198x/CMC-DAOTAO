<%@ Page Title="ns_td_kh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kh.aspx.cs" Inherits="f_ns_td_kh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch tuyển dụng" />
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
                <table cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" Text="Mã kế hoạch" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" ten="Mã kế hoạch" runat="server" kt_xoa="G" CssClass="css_ma" Width="155px" kieu_chu="true"
                                                        onchange ="return ns_td_kh_P_KTRA('MA')" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Ngày lập" Width="100px" CssClass="css_gchu_c" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" ten="Ngày đề xuất" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="155px" kieu_luu="S" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Tên kế hoạch" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ten" ten="Tên kế hoạch" runat="server" kt_xoa="G" CssClass="css_ma" Width="420px" kieu_unicode="true" />
                                                </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Ngày tuyển dự kiến" Width="115px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaydk" ten="Ngày dự kiến" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="155px" kieu_luu="S" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Kinh phí dự trù" Width="100px" CssClass="css_gchu_c" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="kinhphi" ten="Kinh phí dự trù" runat="server" CssClass="css_so" kt_xoa="X" Width="155px" so_tp="2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Ý kiến lãnh đạo" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ykien" ten="Ý kiến lãnh đạo" runat="server" kt_xoa="X" CssClass="css_ma" Width="420px" kieu_unicode="true"
                                            TextMode="MultiLine" Rows="2" ReadOnly="true" />
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
                                            CssClass="table gridX" loai="N" cot="sott,nhom_cdanh,cdanh,phong,soluong,noi_lv" hangKt="5" hamUp="ns_td_kh_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="TT" HeaderStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="sott" runat="server" Width="30px" CssClass="css_Gma_c" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nhóm chức danh" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="nhom_cdanh" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx"
                                                            ktra="ns_ma_ncdanh,ma,ten" kieu_chu="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="cdanh" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx"
                                                            ktra="ns_ma_cdanh,ma,ten,ncdanh" kieu_chu="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bộ phận" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="phong" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ht/ht_maph.aspx"
                                                            ktra="ht_ma_phong,ma,ten" kieu_chu="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Số lượng" HeaderStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="soluong" runat="server" Width="60px" CssClass="css_Gma_c" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Nơi làm việc" HeaderStyle-Width="128px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="noi_lv" runat="server" Width="100px" CssClass="css_Gma" />
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
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_td_kh_P_NH();form_P_LOI();"
                                            Width="70px" /> 
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_kh_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_td_kh_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_td_kh_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_td_kh_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_td_kh_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_td_kh_ChenDong('C');" />
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
                                CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id,ma_cdanh" hamRow="ns_td_kh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày lập" DataField="ngay" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="80" gridId="GR_lke"
                                ham="ns_td_kh_P_LKE()" />
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,460" />
    </div>
</asp:Content>
