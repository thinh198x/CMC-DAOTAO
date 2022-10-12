<%@ Page Title="ns_cc_th_may" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_th_may.aspx.cs" Inherits="f_ns_cc_th_may" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
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
                        <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp dữ liệu công máy" />
                        <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
                    </div>
                    <div class="width_common auto_sc">
                        <div class="b_right col_100 inner" id="UPa_ct">
                            <div style="display: none">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_30">Phòng</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" CssClass="form-control css_list" kieu="U" kt_xoa="K" onchange="ns_cc_th_may_P_KTRA('PHONG')" ktra="DT_PHONG" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_30">Năm</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_th_may_P_KTRA('NAM');" kt_xoa="K" ktra="DT_NAM" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cc_th_may_P_KTRA('KYLUONG')" ktra="DT_KYLUONG" />
                                    </div>
                                </div>
                                <div style="display: none;">
                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="20px" />
                                    <Cthuvien:gchu ID="Gchu1" runat="server" kt_xoa="X" Width="30px" />
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_30">Mã CB tìm kiếm</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_the" ten="Mã CB tìm kiếm" onchange="ns_cc_th_may_P_KTRA('so_the')" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_30">Tên CB tìm kiếm</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="hoten" ten="Tên nhân viên" onchange="ns_cc_th_may_P_KTRA('hoten')" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="list_bt_action">
                                <Cthuvien:nhap ID="nhap" runat="server" Text="Tổng hợp" class="bt_action" anh="K" OnClick="return ns_cc_th_may_TINH();form_P_LOI();" Width="120px" />
                            </div>
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                        loai="L" cotAn="phong,checkout_sang,checkin_chieu,cong_com" hangKt="15" gchuId="gchu" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="20px" />
                                            <asp:BoundField DataField="PHONG" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField DataField="SO_THE" HeaderText="Mã nhân viên" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField DataField="TEN" HeaderText="Tên nhân viên" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField DataField="NGAY" HeaderText="Ngày làm việc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="CA" HeaderText="Ca làm việc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="CHECKIN" HeaderText="Lần đầu" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="CHECKOUT_SANG" HeaderText="Lần ra buổi sáng" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="CHECKIN_CHIEU" HeaderText="Lần vào buổi chiều" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="CHECKOUT" HeaderText="Lần cuối" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="TONG_GIO_LV" HeaderText="Tổng giờ làm việc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                            <asp:BoundField DataField="MA_CONG" HeaderText="Mã công" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="D_MUON" HeaderText="Số phút đi muộn" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                            <asp:BoundField DataField="V_SOM" HeaderText="Số phút về sớm" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                            <asp:BoundField DataField="cong_com" HeaderText="Công cơm" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_cc_th_may_P_LKE('K')" />
                            </div>
                            <div class="list_bt_action" id="UPa_nhap">
                                <Cthuvien:nhap ID="nhap1" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnClick="return ns_cc_th_may_EXCEL();form_P_LOI();" Width="120px" />
                                <div style="display: none;">
                                    <Cthuvien:nhap ID="nhap2" runat="server" Width="70px" Text="Nhập" OnServerClick="nhap_Click" giu="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="nhap2" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,740" />
        <Cthuvien:an ID="aphong" runat="server" Value="1" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
