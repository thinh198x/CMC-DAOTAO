<%@ Page Title="ns_tlap_dk_cmccare" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tlap_dk_cmccare.aspx.cs" Inherits="f_ns_tlap_dk_cmccare" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" style="overflow: scroll">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Điều kiện hưởng CMC Care" />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L" hangKt="15" cotAn="so_id,bh_cmc_care" hamRow="ns_tlap_dk_cmccare_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="bh_cmc_care" />
                                                <asp:BoundField DataField="ten_bh_cmc_care" HeaderText="Gói BH CMC Care" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="thamnien" HeaderText="Thâm niên" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_r" />
                                                <asp:BoundField DataField="ngayd" HeaderText="Ngày hiệu lực" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField DataField="ngayc" HeaderText="Ngày hết hiệu lực" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_tlap_dk_cmccare_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xuat" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_tlap_dk_cmccare_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <div style="height: 600px; width: 100%; overflow-y: scroll">
                                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Label1" runat="server" Text="Gói BH CMC Care" Width="110px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <%--<Cthuvien:ma ID="BH_CMC_CARE" placeholder="Nhấn (F1)" Width="166px" BackColor="#f6f7f7" ten="Gói BH CMC Care" runat="server" CssClass="css_form"
                                                                        f_tkhao="~/App_form/ns/ma/ns_ma_chiphi_cmccare.aspx" ktra="ns_ma_chiphi_cmccare,ma,ten" kt_xoa="X" />--%>
                                                                    <Cthuvien:DR_lke ID="BH_CMC_CARE" ten="Gói BH CMC Care" runat="server" Width="166px" ktra="DT_GBH" kt_xoa="G" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Thâm niên" Width="115px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="thamnien" runat="server" kt_xoa="X" kieu_so="true" CssClass="css_form_r" Width="115px" />
                                                                </td>
                                                                <td style="border: none">
                                                                    <%--<Cthuvien:ma ID="ma3" runat="server" kt_xoa="K" CssClass="css_form" kieu_chu="true" Enabled="false" Width="43px" Text="tháng" />--%>
                                                                    <asp:Label ID="Label8" runat="server" Text="tháng" CssClass="css_gchu_c" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Ngày hiệu lực" Width="80px" CssClass="css_gchu" />
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="140px" CssClass="css_form_c" kt_xoa="X"
                                                                            kieu_luu="S" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label11" runat="server" Text="Ngày hết hiệu lực" Width="115px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="140px" CssClass="css_form_c" kt_xoa="X"
                                                                            kieu_luu="S" />
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
                                                        <Cthuvien:nd ID="ghichu" ten="Ghi chú" runat="server" kt_xoa="X" onchange="ns_tlap_dk_cmccare_P_KTRA('note')"
                                                            CssClass="css_form" Width="460px" kieu_unicode="true" Height="50px" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="Ngạch nghề nghiệp" CssClass="css_gchu" />
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div style="height: 140px; width: 100%; overflow: scroll">
                                                                        <Cthuvien:GridX ID="GR_nnnghiep" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" cot="ma_nnnghiep,ten_nnnghiep" hangKt="5" hamUp="ns_tlap_dk_cmccare_Update">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã ngạch nghề nghiệp" HeaderStyle-Width="150px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ma_nnnghiep" runat="server" Width="150px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nn.aspx"
                                                                                            ktra="ns_hdns_ma_nn,ma,ten" kieu_chu="true" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Tên ngạch nghề nghiệp" DataField="ten_nnnghiep" HeaderStyle-Width="255px" ItemStyle-CssClass="css_Gma" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20px; height: 20px;" align="right" valign="middle">
                                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return nnnghiep_HangLen();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return nnnghiep_HangXuong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return nnnghiep_CatDong();" />
                                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return nnnghiep_ChenDong('C');" />
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
                                                                    <div style="height: 140px; width: 100%; overflow: scroll">
                                                                        <Cthuvien:GridX ID="GR_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" cot="ma_cd,ten,so_id_cd" cotAn="so_id_cd" hangKt="6" hamUp="ns_tlap_dk_cmccare_Update">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="150px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ma_cd" runat="server" Width="150px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx"
                                                                                            ktra="ns_hdns_cdanh_tk,ma,ten" kieu_chu="true" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="255px" ItemStyle-CssClass="css_Gma" />
                                                                                 <asp:BoundField DataField="so_id_cd" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
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
                                                                    <div style="height: 140px; width: 100%; overflow: scroll">
                                                                        <Cthuvien:GridX ID="GR_level" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" cot="ma_level_cdanh,ten_level_cdanh" hangKt="6" hamUp="ns_tlap_dk_cmccare_Update">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã level chức danh" HeaderStyle-Width="150px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ma_level_cdanh" runat="server" Width="150px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/hdns_ma_lvcdanh.aspx"
                                                                                            ktra="hdns_ma_lvcdanh,ma,ten" kieu_chu="true" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Tên level chức danh" DataField="ten_level_cdanh" HeaderStyle-Width="255px" ItemStyle-CssClass="css_Gma" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
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
                                                                    <div style="height: 140px; width: 100%; overflow: scroll">
                                                                        <Cthuvien:GridX ID="GR_lhd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" cot="ma_lhd,ten_lhd" hangKt="6" hamUp="ns_tlap_dk_cmccare_Update">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã loại hợp đồng" HeaderStyle-Width="150px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ma_lhd" runat="server" Width="150px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/hdns/dm/ns_ma_lhd.aspx"
                                                                                            ktra="ns_ma_lhd,ma,ten" kieu_chu="true" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Tên loại hợp đồng" DataField="ten_lhd" HeaderStyle-Width="255px" ItemStyle-CssClass="css_Gma" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
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
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_tlap_dk_cmccare_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_tlap_dk_cmccare_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_tlap_dk_cmccare_P_XOA();form_P_LOI();" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,810" />
    </div>
</asp:Content>