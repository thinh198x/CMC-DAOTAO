<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_biendong_bh.aspx.cs" Inherits="f_ns_biendong_bh"
    Title="ns_biendong_bh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Biến động bảo hiểm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">

                <div class="b_left col_50 inner" id="UPa_tk" style="display: list-item">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_right form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Phòng tìm kiếm"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tháng biến động</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="thangd_tk" runat="server" kieu_luu="S" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Từ ngày truy thu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="thangc_tk" runat="server" kt_xoa="X" ten="Tháng biến động" CssClass="form-control icon_lich"
                                    ToolTip="Tháng biến động" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">

                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="120px" class="bt_action" anh="K" OnClick="ns_biendong_bh_P_LKE('TK');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" cotAn="nsd,thang_bd,so_id" hangKt="15" hamRow="ns_biendong_bh_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="170px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Loại biến động" DataField="ten_loai_bd" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Phương án biến động" DataField="phuong_an" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BHXH" ItemStyle-CssClass="css_Gnd" DataField="is_bhxh" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="BHYT" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gnd" DataField="is_bhyt" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="BHTN" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gnd" DataField="is_bhtn" HeaderStyle-Width="80px" />
                                    <asp:BoundField DataField="so_id" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_biendong_bh_P_LKE('K')" />
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="120px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>

                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common lv2 pv_bl"><span>Thông tin nhân viên</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Số thẻ cán bộ" kt_xoa="X"
                                    onchange="ns_biendong_bh_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten,cdanh,phong" placeholder="Nhấn (F1)" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" ten="Tên nhân viên" ToolTip="Tên nhân viên" runat="server" Enabled="false" kt_xoa="X" CssClass="form-control css_ma"
                                    BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CDANH" Enabled="false" runat="server" kt_xoa="X" ReadOnly="true" CssClass="form-control css_ma" kieu_chu="true"
                                    kieu_unicode="true" BackColor="#f6f7f7" />
                                <Cthuvien:an ID="CDANH" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_PHONG" Enabled="false" runat="server" ReadOnly="true" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="tên phòng" BackColor="#f6f7f7" />
                                <Cthuvien:an ID="PHONG" runat="server" Value="" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common lv2 pv_bl"><span>Biến động bảo hiểm</span></div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_20">Loại biến động <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="LOAI_BD" ktra="DT_LOAI_BD" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Loại biến động"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" kieu_luu="S" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Từ ngày truy thu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left col_40">Tháng biến động<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="THANG_BD" runat="server" kt_xoa="X" ten="Tháng biến động" CssClass="form-control icon_lich"
                                    ToolTip="Tháng biến động" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">BHXH</span>
                            <div class="input-group">

                                <Cthuvien:kieu ID="is_bhxh" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">BHYT</span>
                            <div class="input-group">

                                <Cthuvien:kieu ID="is_bhyt" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">BHTN</span>
                            <div class="input-group">

                                <Cthuvien:kieu ID="is_bhtn" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">L.kỳ trước</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong_c" runat="server" kt_xoa="X" CssClass="form-control css_so" ten="Lương kỳ trước" kieu_so="true"
                                    kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">L.Kỳ này</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong_m" runat="server" kt_xoa="X" ten="Lương kỳ này" CssClass="form-control css_so" kieu_so="true"
                                    kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày trả sổ BHXH</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaytra_bhxh" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Ngày trả thẻ BHXH" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày trả thẻ BHYT</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaytra_bhyt" runat="server" CssClass="form-control icon_lich" kieu_luu="S" kt_xoa="X" kieu_date="true"
                                    ToolTip="Ngày trả thẻ BHYT" />
                            </div>
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phương án</span>
                            <div class="input-group">
                               
                                    <Cthuvien:DR_lke ID="phuong_an" ktra="DT_PHUONG_AN" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Phương án"></Cthuvien:DR_lke>
                                
                            </div>
                        </div>

                    </div>

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" runat="server" kt_xoa="X" CssClass="form-control css_nd"
                                kieu_unicode="true" ToolTip="Ghi chú" TextMode="MultiLine" Height="50px" />
                        </div>
                    </div>
                    <div class="width_common lv2 pv_bl"><span>Truy thu</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_truythu_d" onchange="ns_biendong_bh_P_KTRA('ngay_truythu_d')" runat="server" kieu_luu="S" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Từ ngày truy thu" ten="Từ ngày truy thu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_truythu_c" onchange="ns_biendong_bh_P_KTRA('ngay_truythu_d')" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Đến ngày truy thu" ten="Đến ngày truy thu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHXH</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tt_bhxh" runat="server" CssClass="form-control css_so" ReadOnly="true"
                                    kt_xoa="X" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHYT</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tt_bhyt" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHTN</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tt_bhtn" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common lv2 pv_bl"><span>Thoái thu</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_thoaithu_d" onchange="ns_biendong_bh_P_KTRA('ngay_thoaithu_d')" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Từ ngày truy thu" ten="Từ ngày truy thu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_thoaithu_c" onchange="ns_biendong_bh_P_KTRA('ngay_thoaithu_d')" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Đến ngày truy thu" ten="Đến ngày truy thu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHXH</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tht_bhxh" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHYT</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tht_bhyt" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHTN</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tht_bhtn" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap1" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_biendong_bh_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Mới" OnClick="return ns_biendong_bh_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Xóa" OnClick="return ns_biendong_bh_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,795" />
        <Cthuvien:an ID="aphong" runat="server" />
    </div>
</asp:Content>
