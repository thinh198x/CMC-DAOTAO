<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_giuluong.aspx.cs" Inherits="f_tl_giuluong"
    Title="tl_giuluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc id="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khai báo giữ lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common"> 
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM_TK" ten="Năm" runat="server" CssClass="form-control css_ma" onchange="tl_giuluong_P_NAM()" ktra="DT_NAM" />
                            </div>
                        </div>
                         <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_TK" ten="Kỳ lương" runat="server" CssClass="form-control css_list" ktra="DT_KYLUONG_TK" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                       <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma " kt_xoa="G" />
                            </div>
                        </div> 
                         <div class="b_right form-group iterm_form" style="display:none">
                            <span class="standard_label b_left col_30">Phòng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG_TK" runat="server" ten="Phòng" onchange="tl_giuluong_load_luong()"
                                    CssClass="form-control css_list" ktra="DT_PHONG" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return tl_giuluong_P_LKE();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="tl_giuluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ lương" DataField="kyluong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tiền lương" DataField="tien_luong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Tổng bị giữ lại" DataField="tien_giu" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày thanh toán" DataField="ngay_tt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_giuluong_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" kt_xoa="G" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên"
                                    onchange="tl_giuluong_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten,cdanh,phong" placeholder="Nhấn (F1)" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" ten="tên nhân viên" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    kieu_unicode="True" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CDANH" ten="chức danh" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="True"
                                    Enabled="false" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_PHONG" ten="phòng ban" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="True"
                                    Enabled="false" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_35">Trợ cấp thôi việc</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tc_thoiviec" runat="server" BackColor="#f6f7f7" so_tp="3" CssClass="form-control css_ma" Enabled="false"
                                    kt_xoa="G" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trợ cấp mất việc</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tc_matviec" runat="server" BackColor="#f6f7f7" so_tp="3" CssClass="form-control css_ma" Enabled="false"
                                    kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Hỗ trợ khác</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tc_khac" runat="server" CssClass="css_form" so_tp="3" BackColor="#f6f7f7" kieu_so="true" Enabled="false" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="tl_giuluong_P_KTRA('NAM')" runat="server"
                                    CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" ktra="DT_KYLUONG" kt_xoa="X" runat="server" onchange="tl_giuluong_load_luong()"
                                    CssClass="form-control css_list" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tiền lương</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tien_luong" runat="server" ReadOnly="true" Enabled="false" CssClass="form-control css_so" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tiền bị giữ lại</span>
                            <div class="input-group">
                                <Cthuvien:so ID="TIEN_GIU" ten="Tiền bị giữ lại" runat="server" so_tp="3" CssClass="form-control css_so"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thanh toán</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tt" runat="server" ten="Ngày thanh toán"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display:none;">
                            <span class="standard_label lv2 b_left col_35">Tổng tiền</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tong_tien" runat="server" ReadOnly="true" Enabled="false" CssClass="form-control css_so" kieu_chu="True"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="dien_giai" ten="Ghi chú" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control css_ma"
                                    kieu_unicode="True" kt_xoa="X" Height="50px" Width="100%"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return tl_giuluong_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return tl_giuluong_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return tl_giuluong_P_XOA();form_P_LOI();" Width="70px" anh="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,700" />
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
    </div>
</asp:Content>
