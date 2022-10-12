<%@ Page Title="ns_cc_tonghop_lthem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tonghop_lthem.aspx.cs" Inherits="f_ns_cc_tonghop_lthem" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xử lý dữ liệu làm thêm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" runat="server" kieu="U" CssClass="form-control css_list" onchange="ns_cc_tonghop_lthem_P_KTRA('PHONG')" ktra="DT_PHONG" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_tonghop_lthem_P_NAM();" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" CssClass="form-control css_list" runat="server"
                                    onchange="ns_cc_tonghop_lthem_P_KTRA('KYLUONG')" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="G" onchange="ns_cc_tonghop_lthem_P_KTRA('KYLUONG')" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="G" onchange="ns_cc_tonghop_lthem_P_KTRA('KYLUONG')" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_10"></span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="nhap" runat="server" Font-Bold="True" class="bt_action" anh="K" Width="100px" Text="Tổng hợp" OnClick="return ns_cc_tonghop_lthem_TINH();form_P_LOI();" />
                            </div>
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="qd_hso_1_5,qd_hso_2_1,qd_hso_2,qd_hso_2_7,qd_hso_3,qd_hso_3_9,tong_quydoi,quydoi_tt,so_id">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="12px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="SO_THE" HeaderStyle-Width="63px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="TEN" HeaderStyle-Width="203px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="TEN_CDANH" HeaderStyle-Width="133px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="TEN_PHONG" HeaderStyle-Width="133px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="01" DataField="N1" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="02" DataField="N2" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="03" DataField="N3" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="04" DataField="N4" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="05" DataField="N5" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="06" DataField="N6" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="07" DataField="N7" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="08" DataField="N8" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="09" DataField="N9" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="10" DataField="N10" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="11" DataField="N11" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="12" DataField="N12" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="13" DataField="N13" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="14" DataField="N14" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="15" DataField="N15" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="16" DataField="N16" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="17" DataField="N17" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="18" DataField="N18" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="19" DataField="N19" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="20" DataField="N20" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="21" DataField="N21" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="22" DataField="N22" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="23" DataField="N23" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="24" DataField="N24" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="25" DataField="N25" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="26" DataField="N26" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="27" DataField="N27" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="28" DataField="N28" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="29" DataField="N29" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="30" DataField="N30" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="31" DataField="N31" HeaderStyle-Width="23px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày thường thực tế" DataField="HSO_1_5" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày thường 1.5" DataField="QD_HSO_1_5" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày thường thực tế" DataField="HSO_2_1" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày thường 2.1" DataField="QD_HSO_2_1" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày nghỉ thực tế" DataField="HSO_2" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày nghỉ 2.0" DataField="QD_HSO_2" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày nghỉ thực tế" DataField="HSO_2_7" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày nghỉ 2.7" DataField="QD_HSO_2_7" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày lễ thực tế" DataField="HSO_3" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT ngày lễ 3.0" DataField="QD_HSO_3" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày lễ thực tế" DataField="HSO_3_9" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="OT đêm ngày lễ 3.9" DataField="QD_HSO_3_9" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số giờ làm thêm theo luật thực tế" DataField="TONG_TT" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số giờ làm thêm theo luật quy đổi" DataField="TONG_QUYDOI" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Số giờ làm thêm không theo luật(IT)" DataField="SOGIO_LTHEM_KTL_IT" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Số giờ làm thêm không theo luật(Lái Xe)" DataField="SOGIO_LTHEM_KTL_LX" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Công ăn ca làm thêm từ 5-11h" DataField="CONG_ANCA_5_11" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Công ăn ca làm thêm lớn hơn 11h" DataField="CONG_ANCA_TREN_11" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng công ăn ca OVT" DataField="TONGCONG_ANCA_OVT" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số giờ làm thêm thanh toán đã quy đổi" DataField="QUYDOI_TT" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số giờ làm thêm chuyển nghỉ bù" DataField="TONG_NGHIBU" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số giờ làm thêm trong tháng" DataField="TONG_TRONGTHANG" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng thời gian làm thêm từ tháng 1 đến hiện tại" DataField="TONG_1_HIENTAI" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_tonghop_lthem_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action" id="UPa_nhap">
                        <Cthuvien:nhap ID="nhap1" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="120px" Text="Xuất excel" OnClick="return ns_cc_tonghop_lthem_P_IN();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,780" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
    </div>
</asp:Content>
