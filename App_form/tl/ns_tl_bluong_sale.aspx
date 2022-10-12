<%@ Page Title="ns_tl_bluong_sale" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_bluong_sale.aspx.cs" Inherits="f_ns_tl_bluong_sale" %>

<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<%@ Register Src="~/App_ctr/khud/ns_khud.ascx" TagName="ns_khud" TagPrefix="ns_khud" %>
<%@ Register Src="~/App_ctr/khud/ns_khudtk.ascx" TagName="ns_khudtk" TagPrefix="ns_khudtk" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Bảng tính lương khối SALE" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20" style="width: 60px">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" kt_xoa="M" Width="100px" onchange="ns_tl_bluong_sale_P_NAM();" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40" style="width: 80px">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" Width="300px" kt_xoa="N" runat="server" CssClass="form-control css_list" onchange="ns_tl_bluong_sale_P_KTRA('KYLUONG')" ktra="DT_KY" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="G" onchange="ns_tl_bluong_sale_P_KTRA('KYLUONG')" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45"></span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tính lương" hoi="0" OnClick="return ns_tl_bluong_sale_TINH();" />
                            </div>
                        </div>
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common" style="display: none">
                        <Cthuvien:tab ID="NPa_yc" runat="server" CssClass="css_tab_ngang_ac" Width="150px" Height="20px" Text="Lương trong kỳ" />
                        <Cthuvien:tab ID="NPa_tt" runat="server" CssClass="css_tab_ngang_de" Width="150px" Height="20px" Text="Lương tổng hợp " />
                    </div>
                    <div class="tab_content">
                        <asp:Panel ID="Pa_yc" runat="server" Style="display: none;">
                            <div style="width: 100%; overflow-x: scroll">
                                <table>
                                    <tr>
                                        <td align="left" style="width: 100%">
                                            <div style="width: 100%">
                                                <ns_khudtk:ns_khudtk ID="ns_khudtk" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td>
                                            <Cthuvien:GridX ID="GR_tk" runat="server" hangKt="18">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField DataField="cotan" ItemStyle-CssClass="css_Gma" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_tk_slide" runat="server" loai="X" gridId="GR_tk" ham="ns_tl_bluong_sale_tk_P_LKE()" />
                        </asp:Panel>
                        <asp:Panel ID="Pa_tt" runat="server" Style="display: block;">
                            <div style="width: 100%; overflow-x: scroll">
                                <table>
                                    <tr>
                                        <td align="left" style="width: 100%">
                                            <div style="width: 100%">
                                                <ns_khud:ns_khud ID="ns_khud" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" hangKt="18">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField DataField="cotan" ItemStyle-CssClass="css_Gma" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_bluong_sale_P_LKE()" />
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action lv2">
                        <div class="col_5_iterm width_common">
                            <%-- <div id="tdKhoa" class="b_left">
                                <Cthuvien:nhap ID="nhap" runat="server" Text="Khóa" OnClick="ns_tl_bluong_sale_P_DONG();form_P_LOI('');" class="bt_action" anh="K" />
                            </div>
                            <div id="tdMo" class="b_left">
                                <Cthuvien:nhap ID="moi" runat="server" Text="Mở" OnClick="ns_tl_bluong_sale_P_MO();form_P_LOI('');" class="bt_action" anh="K" />
                            </div>
                            <div id="tdKhoavv" class="b_left">
                                <Cthuvien:nhap ID="nhap1" runat="server" OnClick="ns_tl_bluong_sale_P_DONG_VV();form_P_LOI('');" Text="Khóa vĩnh viễn" class="bt_action" anh="K" />
                            </div>--%>

                            <div class="b_left" style="padding-left: 3px;">
                                <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" Width="90px" OnClick="ns_tl_bluong_sale_P_IN();form_P_LOI('');" Title="Xuất excel" class="bt_action" anh="K" />
                            </div>
                            <div style="display: none">
                                <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button" OnClick="return ns_tl_bluong_sale_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Import" OnServerClick="nhap_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,790" />
        <Cthuvien:an ID="aphong" runat="server" Value="" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
