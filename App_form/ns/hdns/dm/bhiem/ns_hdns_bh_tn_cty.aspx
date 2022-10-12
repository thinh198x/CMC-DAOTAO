<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_bh_tn_cty.aspx.cs" Inherits="f_ns_hdns_bh_tn_cty"
    Title="ns_hdns_bh_tn_cty" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập điều kiện hưởng BH tự nguyện cho Công ty" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                            CssClass="table gridX" loai="X" hangKt="10" cot="ma_ts,ten_phong,ngay_hl,so_id,phong,nsd" cotAn="so_id,phong,nsd" hamRow="ns_hdns_bh_tn_cty_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã phòng ban" DataField="ma_ts" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên phòng ban" DataField="ten_phong" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_hl" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="so_id" />
                                                <asp:BoundField DataField="phong" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_hdns_bh_tn_cty_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_bh_tn_cty_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr style="display: none">
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Phòng" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="CONG_TY" ten="Công ty" runat="server" Width="250px" ktra="DT_DVI" kt_xoa="G" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Tên loại BH" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="LOAI_BH" ten="Tên loại BH" runat="server" Width="250px" ktra="DT_LBH" kt_xoa="G" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày áp dụng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" CssClass="css_form_c" ten="Ngày áp dụng" kt_xoa="G" onchange="ns_hdns_bh_tn_cty_P_MA_KTRA();" Width="243px" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="MA_CD,ten,ten_tt,ma_cdanh_dvi,SO_ID_CD" cotAn="SO_ID_CD" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="172px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" Width="172px" placeholder="Nhấn (F1)" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="165px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="165px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="193px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ten_tt" runat="server" Enabled="false" Width="193px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mã chức danh theo đơn vị" HeaderStyle-Width="193px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma_cdanh_dvi" Enabled="false" runat="server" Width="193px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="SO_ID_CD" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                                <td class="css_scrl_td">
                                                    <khud_scrl:khud_scrl ID="GR_ct_slide" loai="L" runat="server" gridId="GR_ct" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_bh_tn_cty_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_bh_tn_cty_P_MAU();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_bh_tn_cty_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON_GRID('GR_ct:phong,GR_ct:so_id_cd,GR_ct:ten');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_bh_tn_cty_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1350,550" />
</asp:Content>
