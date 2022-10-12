<%@ Page Title="ns_hdns_nl_cdanh_dvi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_nl_cdanh_dvi.aspx.cs" Inherits="f_ns_hdns_nl_cdanh_dvi" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Gán năng lực chức danh sử dụng cho mỗi đơn vị" />
                                    </td>
                                    <td align="right">
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
                        <td align="left" valign="top" class="form_left">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="X" hangKt="10" cotAn="sott,so_id,nnnghiep,cdanh" hamRow="ns_hdns_nl_cdanh_dvi_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField DataField="phong" HeaderText="Mã phòng ban" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField DataField="ten_phong" HeaderText="Tên phòng ban" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="ten_nnnghiep" HeaderText="Ngạch nghề nghiệp" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="ten_cdanh" HeaderText="Tên chức danh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="ngay_hl" HeaderText="Ngày áp dụng" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField DataField="so_id" />
                                        <asp:BoundField DataField="nnnghiep" />
                                        <asp:BoundField DataField="cdanh" />
                                        <asp:BoundField DataField="sott" />
                                    </Columns>
                                </Cthuvien:GridX>                            
                                <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_nl_cdanh_dvi_P_LKE()" />
                            </div>  
                            <div style="padding-top:10px; text-align:center;">
                                 <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" OnClick="return ns_hdns_nl_cdanh_dvi_P_EXCEL();form_P_LOI();" />
                            </div>
                            <div style="display:none;">
                                 <Cthuvien:nhap ID="excel_an" runat="server" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                            </div>
                        </td>
                        <td valign="top" class="form_right" style="padding-right:30px;">
                            <table runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Width="120px">Phòng</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="PHONG" kt_xoa="G" ten="Phòng" ktra="NL_CD_DVI_PHONG" runat="server" onchange="ns_hdns_nl_cdanh_dvi_P_KTRA('PHONG')" Width="250px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Width="120px">Ngạch nghề nghiệp</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="NNNGHIEP" kt_xoa="G" ten="Ngạch nghề nghiệp" ktra="NL_CD_DVI_NNNGHIEP" runat="server" onchange="ns_hdns_nl_cdanh_dvi_P_KTRA('NNNGHIEP')" Width="250px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Width="120px">Chức danh</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="CDANH" kt_xoa="G" ten="Chức danh" ktra="NL_CD_DVI_CDANH" runat="server" onchange="ns_hdns_nl_cdanh_dvi_P_KTRA('CDANH')" Width="250px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Width="100px" Text="Ngày áp dụng" />
                                                </td>
                                                <td>                                                    
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" MaxLength="10" runat="server" CssClass="css_form_c" kt_xoa="G" Width="220px"
                                                            ten="Ngày áp dụng" onchange="ns_hdns_nl_cdanh_dvi_P_KTRA('NGAY_HL')" kieu_luu="S" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>                                                            
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <div class="css_divb">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="N" cot="ten_nhom_nl,ten_nl,muc_nl,mota,so_id,so_id_nl,so_id_nl_ct"
                                                    cotAn="so_id,so_id_nl,so_id_nl_ct" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_nhom_nl" runat="server" CssClass="css_Gma"
                                                                    BorderStyle="None" Width="100%"
                                                                    MaxLength="100" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tên năng lực" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_nl" runat="server" CssClass="css_Gma"
                                                                    BorderStyle="None" Width="100%"
                                                                    MaxLength="100" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mức năng lực" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="muc_nl" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                                    BorderStyle="None" Width="100%" MaxLength="100"
                                                                    f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" ReadOnly="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="mota" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="so_id" />
                                                        <asp:BoundField DataField="so_id_nl" />
                                                        <asp:BoundField DataField="so_id_nl_ct" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <khud:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-right:-20px;">
                                            <tr>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_nl_cdanh_dvi_HangLen();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_nl_cdanh_dvi_HangXuong();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_nl_cdanh_dvi_CatDong();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_nl_cdanh_dvi_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="90px" OnClick="return ns_hdns_nl_cdanh_dvi_P_MOI();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_nl_cdanh_dvi_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON_GRID('GR_ct:phong,GR_ct:so_id_cd,GR_ct:ten');form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_nl_cdanh_dvi_P_XOA();form_P_LOI();" />                                                       
                                                    </div>
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1320,560" />
    </div>
</asp:Content>
