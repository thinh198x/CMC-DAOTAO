<%@ Page Title="ns_cc_phep_nam" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_phep_nam.aspx.cs" Inherits="f_ns_cc_phep_nam" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý phép năm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" CssClass="form-control css_list" kieu="U" kt_xoa="K" onchange="ns_cc_phep_nam_P_KTRA('PHONG')" ktra="DT_PHONG" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                       
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_phep_nam_P_KTRA('NAM');" kt_xoa="K" ktra="DT_NAM" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cc_phep_nam_P_KTRA('KYLUONG')" ktra="DT_KYLUONG" />

                            </div>
                        </div>
                         <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên" MaxLength="30"
                                    onchange="ns_cc_phep_nam_P_LKE()" ktra="ns_cb,so_the,ten" kt_xoa="K" />

                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="t" runat="server" Text="Tổng hợp phép năm" class="bt_action" anh="K" Width="160px" OnClick="ns_cc_phep_nam_TINH();form_P_LOI('');" Title="Tổng hợp phép năm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                <tr>
                                    <td rowspan="2" id="td011" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label18" runat="server" Width="12px" />
                                    </td>
                                    <td rowspan="2" id="td111" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label19" runat="server" Width="50px" Text="Số TT" />
                                    </td>
                                    <td rowspan="2" id="td211" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label20" runat="server" Width="75px" Text="Mã nhân viên" />
                                    </td>
                                    <td rowspan="2" id="td311" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label21" runat="server" Width="193px" Text="Họ tên" />
                                    </td>
                                    <td rowspan="2" id="td511" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label23" runat="server" Width="193px" Text="Chức danh" />
                                    </td>
                                    <td rowspan="2" id="td411" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label22" runat="server" Width="193px" Text="Bộ phận" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label28" runat="server" Width="115px" Text="Ngày vào" />
                                    </td>
                                    <td rowspan="2" id="td512" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label6" runat="server" Width="193px" Text="Kỳ tính" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label7" runat="server" Width="143px" Text="Thâm niên" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label1" runat="server" Width="143px" Text="Phép thâm niên" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label25" runat="server" Width="143px" Text="Phép năm trước chuyển sang" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label30" runat="server" Width="143px" Text="Ngày cắt phép năm trước" />
                                    </td>
                                    <td rowspan="2" id="td515" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label27" runat="server" Width="143px" Text="Số phép năm" />
                                    </td>
                                    <td rowspan="2" id="td516" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label29" runat="server" Width="143px" Text="Phép được nghỉ trong năm" />
                                    </td>
                                    <td rowspan="2" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label5" runat="server" Width="125px" Text="Số ngày đã nghỉ" />
                                    </td>
                                    <td colspan="12" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label24" runat="server" Width="120px" Text="Số ngày đã sử dụng" />
                                    </td>
                                    <td rowspan="2" id="td518" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label33" runat="server" Width="100px" Text="Số phép còn lại" />
                                    </td> 
                                </tr>
                                <tr>
                                    <td id="td8" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label8" runat="server" Width="36px" Text="T1" />
                                    </td>
                                    <td id="td9" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label9" runat="server" Width="36px" Text="T2" />
                                    </td>
                                    <td id="td10" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label10" runat="server" Width="36px" Text="T3" />
                                    </td>
                                    <td id="td11" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label11" runat="server" Width="36px" Text="T4" />
                                    </td>
                                    <td id="td12" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label12" runat="server" Width="36px" Text="T5" />
                                    </td>
                                    <td id="td13" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label13" runat="server" Width="36px" Text="T6" />
                                    </td>
                                    <td id="td14" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label14" runat="server" Width="36px" Text="T7" />
                                    </td>
                                    <td id="td15" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label15" runat="server" Width="36px" Text="T8" />
                                    </td>
                                    <td id="td16" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label16" runat="server" Width="36px" Text="T9" />
                                    </td>
                                    <td id="td17" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label17" runat="server" Width="36px" Text="T10" />
                                    </td>
                                    <td id="td18" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label3" runat="server" Width="36px" Text="T11" />
                                    </td>
                                    <td id="td19" style="background-color: #9fc54e; borde   r-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label26" runat="server" Width="36px" Text="T12" />
                                    </td>
                                </tr>
                            </table>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="20" Width="100%" cotAn="SO_ID">
                                <Columns>
                                    <asp:BoundField HeaderStyle-Width="7px" />
                                    <asp:BoundField DataField="SOTT" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ho_ten" HeaderStyle-Width="188px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="CDANH" HeaderStyle-Width="188px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="TEN_PHONG" HeaderStyle-Width="188px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="NGAY_VAO" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ky_tinh" HeaderStyle-Width="188px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="thamnien" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="phep_tn" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="phep_nt" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="ngay_cat_phep" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="tong_p" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="tong_dn" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="phep_sd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t1" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t2" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t3" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t4" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t5" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t6" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t7" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t8" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t9" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t10" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t11" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="t12" HeaderStyle-Width="31px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="phep_cl" HeaderStyle-Width="95px" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_phep_nam_P_LKE()" /> 
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Xuất Excel" class="bt_action" anh="K" Width="120px" OnClick="ns_cc_phep_nam_P_EXPORT();form_P_LOI('');" Title="Tìm kiếm" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,660" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="phongc" runat="server" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

