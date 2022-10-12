<%@ Page Title="ns_tv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tv.aspx.cs" Inherits="f_ns_tv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_content">
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý nghỉ việc" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div id="UPa_tk" class="b_left col_30 inner">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Từ ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" kt_xoa="X" ten="Từ ngày" CssClass="form-control css_ngay" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Đến ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" kt_xoa="X" ten="Đến ngày" CssClass="form-control css_ngay" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" CssClass="form-control css_list" runat="server" onchange="ns_tv_P_KTRA('PHONG_TK')">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="hoten_tk" ten="Tên nhân viên" runat="server" kieu_unicode="true" kieu_chu="true" CssClass="form-control css_ma" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_tv_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id,tinhtrang"
                                cot="so_id,tinhtrang,so_the,ho_ten,ten_cdanh,ten_phong,ngay_tt,ten_tinhtrang" hamRow="ns_tv_GR_lke_RowChange();">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="tinhtrang" />
                                    <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày nghỉ việc" DataField="ngay_tt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tinhtrang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tv_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap2" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="G" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                    onchange="ns_tv_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" disabled="true" ten="Tên cán bộ" BackColor="#f6f7f7" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Phòng" kt_xoa="X" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none;">
                        <Cthuvien:ma ID="cdanh" disabled="true" BackColor="#f6f7f7" ten="Tên chức danh" runat="server" CssClass="form-control css_ma"
                            kt_xoa="X" />
                        <Cthuvien:ma ID="phong" disabled="true" BackColor="#f6f7f7" ten="Tên phòng" runat="server" CssClass="form-control css_ma"
                            kt_xoa="X" />
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_tt" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                            Text="Thông tin nghỉ việc" />
                        <Cthuvien:tab ID="NPa_bg" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                            Text="Thông tin bàn giao" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_tt" runat="server" Style="display: block;">
                            <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày vào công ty</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_vao" disabled="true" ten="Ngày vào" runat="server" kt_xoa="G" CssClass="form-control css_ma_c" kieu_luu="S" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Thâm niên</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="tham_nien" disabled="true" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" so_tp="0" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Loại hợp đồng</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_lhd" disabled="true" ten="Loại hợp đồng" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày hiệu lực</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" disabled="true" ten="Ngày vào" runat="server" kt_xoa="G" CssClass="form-control css_ma_c" kieu_luu="S" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Ngày hết HL</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_het_hl" disabled="true" ten="Ngày hết hiệu lực" runat="server" kt_xoa="G" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin nghỉ việc</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày nộp đơn<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_NOP" kt_xoa="X" ten="Ngày nộp đơn" runat="server" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Ngày thỏa thuận NV<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TTHUAN" kt_xoa="X" ten="Ngày thỏa thuận NV" runat="server" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày nghỉ TT<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TT" kt_xoa="X" ten="Ngày nghỉ thực tế" runat="server" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày phê duyệt<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay onchange="ns_tv_ngaypheduyet();" placeholder='dd/MM/yyyy' ID="NGAY_PD" kt_xoa="X" ten="Ngày phê duyệt" runat="server" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>

                            </div>
                            <div class="width_common pv_bl"><span>Lý do nghỉ việc</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Lý do nghỉ việc</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="lydo_nv" ktra="DT_LD_NV" runat="server" CssClass="form-control css_list"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group col_3_2_iterm iterm_form">
                                    <span class="standard_label lv2 b_left col_25">Lý do chi tiết</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="lydo_chitiet" ten="Lý do chi tiết" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                            kt_xoa="X" MaxLength="2000" TextMode="MultiLine" />
                                    </div>
                                </div>

                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Danh sách đen</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="co_den" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma_c" Text="" />
                                    </div>
                                </div>
                                <div class="b_left form-group col_3_2_iterm iterm_form">
                                    <span class="standard_label lv2 b_left col_25">Lý do DS đen</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="lydo_co_den" ten="Lý do chi tiết" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                            kt_xoa="X" MaxLength="2000" TextMode="MultiLine" />
                                    </div>
                                </div>

                            </div>
                            <div class="width_common pv_bl"><span>Thông tin thanh lý hợp đồng</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Trợ cấp thôi việc</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="tctv" ten="Tiền phép" runat="server" kieu_so="true" CssClass="form-control css_so"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Tiền bồi hoàn đào tạo</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="tien_bh_daotao" ten="Tiền bồi hoàn đào tạo" runat="server" kieu_so="true" CssClass="form-control css_ma_r"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Truy thu khác</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="khoan_khac" ten="Truy thu khác" runat="server" kieu_so="true" CssClass="form-control css_so"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Truy thu BHYT Người lao động</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="bhxh_nld" ten="Tiền phép" runat="server" kieu_so="true" CssClass="form-control css_so"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Truy thu BHYT Người sử dụng lao động</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="bhxh_nsdld" ten="Tiền bồi hoàn đào tạo" runat="server" kieu_so="true" CssClass="form-control css_ma_r"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Tiền bảo hiểm sức khỏe</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="bh_suckhoe" ten="Khoản khác" runat="server" kieu_so="true" CssClass="form-control css_so"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Hỗ trợ khác</span>
                                    <div class="input-group">
                                        <Cthuvien:so so_tp="3" ID="htro_khac" ten="Hỗ trợ khác" runat="server" kieu_so="true" CssClass="form-control css_so"
                                            kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Năm</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="nam" ktra="DT_NAM" runat="server" kt_xoa="X" CssClass="form-control css_list"
                                            onchange="ns_tv_P_NAM()"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group col_3_2_iterm iterm_form">
                                    <span class="standard_label lv2 b_left col_25">Kỳ lương</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="ky_luong" ktra="DT_KY" runat="server" kt_xoa="X" CssClass="form-control css_list"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin phê duyệt</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số QĐ <span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="SO_QD" ten="Số QĐ" runat="server" CssClass="form-control css_ma"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Trạng thái ký</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="tinhtrang" runat="server" CssClass="form-control css_list" lke="Chưa phê duyệt,Phê duyệt" tra="0,1" ten="Trạng thái ký" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Người ký</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="nguoi_ky" ten="Mã người ký" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã người ký" kt_xoa="X" kieu_chu="true"
                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_tv_P_KTRA('NGUOI_KY')" gchu="gchu" placeholder="Nhấn F1" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Họ tên</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_nguoi_ky" ten="Họ tên người ký" runat="server" CssClass="form-control css_ma"
                                            kt_xoa="X" ReadOnly="true" Enabled="false" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_50">Chức danh</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_cdanh_ky" ten="Chức danh" runat="server" CssClass="form-control css_ma"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày ký</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ky" ten="Ngày vào" runat="server" kt_xoa="X" CssClass="form-control css_ma_c" kieu_luu="S" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: none">
                                <Cthuvien:ma ID="cdanh_ky" ten="Chức danh" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" Style="display: none;" />
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_bg" runat="server" Style="display: none;">
                            <div>
                                <div class="width_common pv_bl"><span>Công việc phụ trách</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX1" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Tài liệu, hồ sơ bàn giao</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX2" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Hệ thống account, email, domain,idoc</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX3" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Tài khoản chứng khoán cá nhân</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX4" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Danh sách tài sản bàn giao</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX5" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Danh sách Các khoản tạm ứng và thanh toán</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX6" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Nội dung khác</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GridX7" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ý kiến/ xác nhận của cán bộ quản lý trực tiếp">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>

                            </div>
                            <div style="display: none;">
                                <div class="width_common pv_bl"><span>Thông tin bàn giao hành chính</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GR_tl" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_bg,ng_nhan,ng_pduyet,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Danh mục">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người phê duyệt">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_pduyet" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ghi chú">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Thông tin bàn giao kế toán</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GR_tb" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" Width="100%" cot="STT,danh_muc,ngay_tu,so_tien,ng_xnhan,ng_pduyet,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Danh mục" HeaderStyle-Width="150px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="danh_muc" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày tạm ứng">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tu" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Số tiền">
                                                <ItemTemplate>
                                                    <Cthuvien:so ID="so_tien" so_tp="3" runat="server" kieu_unicode="true" CssClass="css_Gso"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người xác nhận">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_xnhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người phê duyệt">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_pduyet" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ghi chú">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Bàn giao công việc chuyên môn</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GR_ts" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" cot="STT,noidung_cv,ngay_bg,ng_xnhan,ng_pduyet,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Nội dung CV">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="noidung_cv" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="2000" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" CssClass="css_Gma_c"
                                                        Width="100%" kt_xoa="K" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người xác nhận">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_xnhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người phê duyệt">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_pduyet" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ghi chú">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <div class="width_common pv_bl"><span>Bàn giao hồ sơ tài liệu</span></div>
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GR_hs" runat="server" loai="N"
                                        AutoGenerateColumns="false" hangKt="5" cot="stt,ma_hs,ten_hs,so_luong,tinhtrang,vitri_hs,ng_nhan,ng_pduyet,ghichu" PageSize="1" CssClass="table gridX">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="30px" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:TemplateField HeaderText="Mã hồ sơ tài liệu">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ma_hs" runat="server" kieu_chu="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="2000" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên hồ sơ tài liệu">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ten_hs" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="2000" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Số lượng">
                                                <ItemTemplate>
                                                    <Cthuvien:so ID="so_luong" so_tp="3" runat="server" kieu_unicode="true" CssClass="css_Gso"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tình trạng">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="tinhtrang" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="2000" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vị trí hồ sơ/Tài liệu">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="vitri_hs" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="2000" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người nhận bàn giao">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Người phê duyệt">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_pduyet" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="100" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ghi chú">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                                        Width="100%" kt_xoa="K" MaxLength="255" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                            </div>
                        </asp:Panel>

                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="100px" Text="Làm mới"
                                OnClick="return ns_tv_P_MOI();form_P_LOI();" />
                            <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Ghi"
                                OnClick="return ns_tv_P_NH();form_P_LOI();" />
                            <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa"
                                OnClick="return ns_tv_P_XOA();form_P_LOI();" />
                            <Cthuvien:nhap ID="inqd" runat="server" Width="140px" class="bt_action" anh="K" Text="In QĐ chấm dứt"
                                OnClick="return ns_tv_P_IN_QD();form_P_LOI();" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="file" runat="server" Text="File" class="bt_action" anh="K" Width="70px" title="File" OnClick="return nhap_file();form_P_LOI();" />
                            <Cthuvien:nhap ID="Nhap1" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                            <Cthuvien:nhap ID="Nhap3" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap2_Click" />
                            <Cthuvien:nhap ID="Nhap4" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap3_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="UPa_hi">
            <Cthuvien:an ID="so_id" runat="server" Value="0" />
            <Cthuvien:an ID="kthuoc" runat="server" Value="1380,860" />
            <Cthuvien:an ID="so_id_in" runat="server" Value="0" />
        </div>
    </div>
</asp:Content>
