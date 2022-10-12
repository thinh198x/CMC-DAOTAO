<%@ Page Title="ns_hdns_tl_dk_bh_tn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_tl_dk_bh_tn.aspx.cs" Inherits="f_ns_hdns_tl_dk_bh_tn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Điều kiện hưởng bảo hiểm tự nguyện" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_left" valign="top">
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="L" hangKt="19" cotAn="loai_bh,goi_bh,nnnghiep,ma_dvi,trang_thai,so_id" hamRow="ns_hdns_tl_dk_bh_tn_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="loai_bh" />
                                            <asp:BoundField DataField="goi_bh" />
                                            <asp:BoundField DataField="nnnghiep" />
                                            <asp:BoundField DataField="ma_dvi" />
                                            <asp:BoundField DataField="ten_loai_bh" HeaderText="Tên loại BH" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten_goi_bh" HeaderText="Gói BH" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten_nnnghiep" HeaderText="Ngạch nghề nghiệp" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten_cong_ty" HeaderText="Công ty" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ngayd" HeaderText="Ngày áp dụng" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="ngayc" HeaderText="Ngày ngừng áp dụng" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="trang_thai" />
                                            <asp:BoundField DataField="so_id" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_hdns_tl_dk_bh_tn_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="xuat" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_hdns_tl_dk_bh_tn_P_IN();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="0" style="width: 540px">
                                <tr>
                                    <td align="left">
                                        <div style="height: 620px">
                                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Label1" runat="server" Text="Tên loại BH" Width="110px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <Cthuvien:DR_lke ID="LOAI_BH" ten="Tên loại BH" runat="server" Width="145px" ktra="DT_LBH" kt_xoa="K" onchange="ns_hdns_tl_dk_bh_tn_P_KTRA('LOAI_BH')" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Gói BH" Width="115px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:DR_lke ID="goi_bh" ten="Gói BH" runat="server" Width="145px" ktra="DT_GBH" kt_xoa="G" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="Thâm niên" Width="110px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="thamnien" runat="server" kt_xoa="X" kieu_so="true" CssClass="css_form_r" Width="103px" />
                                                                            </td>
                                                                            <td style="border: none; background-color: #f4f6f8;">
                                                                                <asp:Label ID="Label10" runat="server" Text="tháng" CssClass="css_gchu_c" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label12" runat="server" Text="Công ty" Width="115px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:DR_lke ID="ma_dvi" ten="Công ty" runat="server" Width="145px" ktra="DT_CTY" kt_xoa="K" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text="Ngạch nghề nghiệp" Width="110px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:DR_lke ID="nnnghiep" ten="Ngạch nghề nghiệp" runat="server" Width="145px" ktra="DT_NNN" kt_xoa="G"
                                                                                    onchange="ns_hdns_tl_dk_bh_tn_P_KTRA('NNNGHIEP')" />
                                                                            </td>
                                                                            <td style="display: none">
                                                                                <Cthuvien:ma ID="ma_nnnghiep" runat="server" ktra="DT_MA_NNN" kt_xoa="X" />
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
                                                        <asp:Label ID="Label5" runat="server" Text="Chức danh" CssClass="css_gchu" />
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="css_divb">
                                                                        <div class="css_divCn">
                                                                            <Cthuvien:GridX ID="GR_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                                CssClass="table gridX" loai="N" cot="ma_cd,ten" hangKt="3">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="105px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:ma ID="ma_cd" runat="server" Width="110px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx"
                                                                                                guiId="ma_nnnghiep" kieu_chu="true" placeholder="Nhấn (F1)" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </div>
                                                                        <ctr_khud_divC:ctr_khud_divC ID="GR_cdanh_slide" runat="server" gridId="GR_cdanh" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20px; height: 20px;" align="right" valign="middle">
                                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return cdanh_HangLen();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return cdanh_HangXuong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return cdanh_CatDong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return cdanh_ChenDong('C');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="Level chức danh" CssClass="css_gchu" />
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="css_divb">
                                                                        <div class="css_divCn">
                                                                            <Cthuvien:GridX ID="GR_level" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                                CssClass="table gridX" loai="N" cot="ma_level_cdanh,ten_level_cdanh" hangKt="3">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:TemplateField HeaderText="Mã level chức danh" HeaderStyle-Width="105px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:ma ID="ma_level_cdanh" runat="server" Width="110px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/hdns_ma_lvcdanh.aspx"
                                                                                               kieu_chu="true" placeholder="Nhấn (F1)" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Tên level chức danh" DataField="ten_level_cdanh" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </div>
                                                                        <ctr_khud_divC:ctr_khud_divC ID="GR_level_slide" runat="server" gridId="GR_level" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20px; height: 20px;" align="right" valign="middle">
                                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return level_cdanh_HangLen();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return level_cdanh_HangXuong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return level_cdanh_CatDong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return level_cdanh_ChenDong('C');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="Loại hợp đồng" CssClass="css_gchu" />
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="css_divb">
                                                                        <div class="css_divCn">
                                                                            <Cthuvien:GridX ID="GR_lhd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                                CssClass="table gridX" loai="N" cot="ma_lhd,ten_lhd" hangKt="3">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:TemplateField HeaderText="Mã loại hợp đồng" HeaderStyle-Width="105px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:ma ID="ma_lhd" runat="server" Width="110px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/ns_ma_lhd.aspx"
                                                                                               kieu_chu="true" placeholder="Nhấn (F1)" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Tên loại hợp đồng" DataField="ten_lhd" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </div>
                                                                        <ctr_khud_divC:ctr_khud_divC ID="GR_lhd_slide" runat="server" gridId="GR_lhd" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20px; height: 20px;" align="right" valign="middle">
                                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return loai_hd_HangLen();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return loai_hd_HangXuong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return loai_hd_CatDong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return loai_hd_ChenDong('C');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày áp dụng" Width="80px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày áp dụng" Width="117px" CssClass="css_form_c" kt_xoa="X"
                                                                            kieu_luu="S" />
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label11" runat="server" Text="Ngày ngừng áp dụng" Width="115px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày ngừng áp dụng" Width="117px" CssClass="css_form_c" kt_xoa="X"
                                                                            kieu_luu="S" />
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="Mô tả" Width="80px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:nd ID="ghichu" ten="Ghi chú" runat="server" kt_xoa="X" onchange="ns_hdns_tl_dk_bh_tn_P_KTRA('note')"
                                                            CssClass="css_form" Width="415px" kieu_unicode="true" Height="50px" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5px"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div style="width: 110px"></div>
                                                </td>
                                                <td>
                                                    <div>
                                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="0" style="width: 415px; text-align: center;">
                                                            <tr>
                                                                <td>
                                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="100px" OnClick="return ns_hdns_tl_dk_bh_tn_P_MOI();form_P_LOI();" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="100px" OnClick="return ns_hdns_tl_dk_bh_tn_P_NH();form_P_LOI();" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="100px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="100px" OnClick="return ns_hdns_tl_dk_bh_tn_P_XOA();form_P_LOI();" />
                                                                </td>
                                                                <td style="display: none">
                                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--<td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_hdns_tl_dk_bh_tn_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_tl_dk_bh_tn_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_tl_dk_bh_tn_P_XOA();form_P_LOI();" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1450,810" />
        <Cthuvien:an ID="madvi" runat="server" />
    </div>
</asp:Content>
