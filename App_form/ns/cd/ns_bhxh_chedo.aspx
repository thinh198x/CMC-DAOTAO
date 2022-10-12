<%@ Page Title="ns_bhxh_chedo" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_bhxh_chedo.aspx.cs" Inherits="f_ns_bhxh_chedo" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chế độ BHXH" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" kieu_unicode="true" kieu_chu="true" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_bhxh_chedo_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="so_id" hamRow="ns_bhxh_chedo_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã số CB" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng/Ban" DataField="ten_phong" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_bhxh_chedo_P_LKE('K')" />
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnServerClick="nhap_Click" Width="100px" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="G" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Mã số cán bộ" ToolTip="Mã số cán bộ" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                    ktra="ns_cb,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_bhxh_chedo_P_KTRA('SO_THE')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" ten="Tên nhân viên" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Phòng" kt_xoa="X" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                            <div style="display: none">
                                <Cthuvien:ma ID="PHONG" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="css_form"
                                    ToolTip="Phòng" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                                <Cthuvien:ma ID="CDANH" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="css_form"
                                    ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tài khoản</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_tk" ten="Số tài khoản" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Số tài khoản" kt_xoa="X" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chủ tài khoản</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_chu_tk" ten="Chủ tài khoản" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Chủ tài khoản" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã ngân hàng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_ngan_hang" ten="Mã ngân hàng" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Mã ngân hàng" kt_xoa="X" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên ngân hàng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ngan_hang" ten="Tên ngân hàng" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên ngân hàng" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Hình thức nhận</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="hinhthuc_nhan" ten="Hình thức nhận" runat="server" CssClass="form-control css_list"
                                ktra="DT_HINHTHUC_NHAN" kt_xoa="X" />
                        </div>
                    </div>
                    <div id="TPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="TPa_cdod" runat="server" CssClass="css_tab_ngang_ac" Width="120px" Text="Chế độ ốm đau" />
                        <Cthuvien:tab ID="TPa_cdts" runat="server" CssClass="css_tab_ngang_de" Width="120px" Text="Chế độ thai sản" />
                        <Cthuvien:tab ID="TPa_phsk" runat="server" CssClass="css_tab_ngang_de" Width="200px" Text="Dưỡng sức phục hồi sức khỏe" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_cdod" runat="server" Style="display: block;">
                            <div class="width_common pv_bl"></div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label b_left col_20">Hình thức kê khai</span>
                                <div class="input-group">
                                    <Cthuvien:DR_list ID="hinhthuc_kekhai_cd" CssClass="form-control css_list" ten="Hình thức kê khai" ToolTip="Hình thức kê khai"
                                        runat="server" kt_xoa="X" tra="P1,P2" lke="P1 - DS hưởng chế độ mới phát sinh,P2 - DS đề nghị điều chỉnh số đã được giải quyết" />
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Điều kiện làm việc</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="dieukien_lv_cd" ten="Điều kiện làm việc" ToolTip="Điều kiện làm việc" runat="server" CssClass="form-control css_list"
                                            ktra="DT_DIEUKIEN_LV_CD" kt_xoa="X" />
                                    </div>
                                </div>

                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày nghỉ hàng tuần</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ngaynghi_hangtuan_cd" ten="Ngày nghỉ hàng tuần" ToolTip="Ngày nghỉ hàng tuần" runat="server" kt_xoa="X"
                                            kieu_unicode="true" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tuyến bệnh viện</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="tuyen_bv_cd" ten="Tuyến bệnh viện" ToolTip="Tuyến bệnh viện" runat="server"
                                            CssClass="form-control css_list" ktra="DT_TUYEN_BV_CD" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số seri</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_seri_cd" ten="Số seri" ToolTip="Số seri" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Từ ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay_cd" ToolTip="Từ ngày" runat="server" ten="Từ ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay_cd" ToolTip="Đến ngày" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tổng số ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="tong_so_ngay_cd" ten="Tổng số ngày" ToolTip="Tổng số ngày" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày Đ.vi đề nghị hưởng</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_denghi_huong_cd" runat="server" ten="Ngày đơn vị đề nghị hưởng"
                                            ToolTip="Ngày đơn vị đề nghị hưởng" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày sinh con</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_sinhcon_cd" runat="server" ten="Ngày sinh con" ToolTip="Ngày sinh con" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số thẻ BHYT của con</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="sothe_bhyt_con_cd" ten="Số thẻ BHYT của con" ToolTip="Số thẻ BHYT của con" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số con bị ốm</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="so_con_biom_cd" ten="Số con bị ốm" ToolTip="Số con bị ốm" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Mã bệnh dài ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ma_benh_daingay_cd" ten="Mã bệnh dài ngày" ToolTip="Mã bệnh dài ngày" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tên bệnh</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_benh_cd" ten="Tên bệnh" ToolTip="Tên bệnh" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Nghỉ dưỡng thai</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="nghi_duong_thai_cd" runat="server" Text="" lke=",X" kt_xoa="X" ten="Nghỉ dưỡng thai" ToolTip="Nghỉ dưỡng thai" Width="30px" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày giải quyết trước</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gquyet_truoc_cd" runat="server" ten="Ngày giải quyết trước" ToolTip="Ngày giải quyết trước" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Phương án</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="phuong_an_cd" ten="Phương án" ToolTip="Phương án" runat="server"
                                            CssClass="form-control css_list" ktra="DT_PHUONG_AN_CD" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt giải quyết</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_giaiquyet_cd" ten="Đợt giải quyết" ToolTip="Đợt giải quyết" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_gquyet_cd" ten="Tháng năm giải quyết" ToolTip="Tháng năm giải quyết" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt bổ sung</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_bsung_cd" ten="Đợt bổ sung" ToolTip="Đợt bổ sung" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_bsung_cd" ten="Tháng năm bổ sung" ToolTip="Tháng năm bổ sung" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group width_common iterm_form">
                                <span class="standard_label b_left col_20">Ghi chú</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="ghichu_cd" runat="server" kt_xoa="X" CssClass="form-control css_nd" ten="ghi chú"
                                        ToolTip="ghi chú" TextMode="MultiLine" Row="3" />
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Pa_cdts" runat="server" Style="display: none;">
                            <div class="width_common pv_bl"></div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Hình thức kê khai</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="hinhthuc_kekhai_ts" CssClass="form-control css_list" ten="Hình thức kê khai" ToolTip="Hình thức kê khai"
                                            runat="server" kt_xoa="X" tra="P1,P2" lke="P1 - DS hưởng chế độ mới phát sinh,P2 - DS đề nghị điều chỉnh số đã được giải quyết" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày nghỉ hàng tuần</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ngay_nghi_ht_ts" ten="Ngày nghỉ hàng tuần" ToolTip="Ngày nghỉ hàng tuần" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label b_left col_20">Trường hợp hưởng thai sản</span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="th_huong_thaisan_ts" ten="Trường hợp hưởng thai sản" ToolTip="Trường hợp hưởng thai sản"
                                        runat="server" CssClass="form-control css_list" ktra="DT_TH_HUONG_THAISAN_TS" kt_xoa="X" />
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày đi làm lại</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dilam_lai_ts" runat="server" ten="Ngày đi làm lại"
                                            ToolTip="Ngày đi làm lại" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số seri/Lưu trữ</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_seri_ts" ten="Số seri/Lưu trữ" ToolTip="Số seri/Lưu trữ" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Từ ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay_ts" runat="server" ToolTip="Từ ngày" ten="Từ ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay_ts" runat="server" ToolTip="Đến ngày" ten="Đến ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tổng số ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="tong_so_ngay_ts" ten="Tổng số ngày" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày Đ.vi đề nghị hưởng</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_denghi_huong_ts" runat="server" ten="Ngày đơn vị đề nghị hưởng"
                                            ToolTip="Ngày đơn vị đề nghị hưởng" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Điều kiện khám thai</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="dieukien_khamthai_ts" ten="Điều kiện khám thai" ToolTip="Điều kiện khám thai" runat="server"
                                            CssClass="form-control css_list" ktra="DT_DIEUKIEN_KHAMTHAI_TS" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Điều kiện sinh con</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="dieukien_sinhcon_ts" ten="Điều kiện sinh con" ToolTip="Điều kiện sinh con" runat="server"
                                            CssClass="form-control css_list" ktra="DT_DIEUKIEN_SINHCON_TS" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số BHXH của con</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ma_bhxh_con_ts" ten="Số BHXH của con" ToolTip="Số BHXH của con" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>

                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số BHYT của con</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="sothe_bhyt_con_ts" ten="Số BHYT của con" ToolTip="Số BHYT của con" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tuổi thai</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="tuoithai_ts" ten="Tuổi thai" runat="server" kt_xoa="X" CssClass="form-control css_so" kieu_so="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày sinh con</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_sinh_con_ts" runat="server" ten="Ngày sinh con" ToolTip="Ngày sinh con"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày con chết</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_con_chet_ts" runat="server" ten="Ngày con chết" ToolTip="Ngày con chết"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số con</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="socon_ts" ten="Tuổi thai" ToolTip="Số con" runat="server" kt_xoa="X" CssClass="form-control css_so" kieu_so="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số con hoặc thai chết</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="socon_thai_chet_ts" ten="Số con hoặc thai chết" ToolTip="Số con chết hoặc thai chết lưu khi sinh" runat="server"
                                            kt_xoa="X" CssClass="form-control css_so" kieu_so="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày nhận con nuôi</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaynhan_connuoi_ts" runat="server" ten="Ngày nhận con nuôi" ToolTip="Ngày nhận con nuôi"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày nhận con nuôi (MTH)</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaynhan_con_mth_ts" runat="server" ten="Ngày nhận con nuôi(MTH)" ToolTip="Ngày nhận con nuôi đối với mẹ nhờ mang thai hộ"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số BHXH của mẹ</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ma_bhxh_cuame_ts" ten="Số BHXH của mẹ" ToolTip="Số BHXH của mẹ" runat="server"
                                            kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số BHYT của mẹ</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="sothe_bhyt_me_ts" ten="Số BHYT của mẹ" ToolTip="Số BHYT của mẹ" runat="server"
                                            kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Số CMND của mẹ</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_cmnd_me_ts" ten="Số CMND của mẹ" ToolTip="Số CMND của mẹ" runat="server"
                                            kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Nghỉ dưỡng thai</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="nghi_duong_thai_ts" runat="server" Text="" lke=",X" kt_xoa="X" ToolTip="Nghỉ dưỡng thai" Width="30px"
                                            CssClass="form-control css_ma_c" ten="Nghỉ dưỡng thai" />
                                    </div>
                                </div>
                            </div>

                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Mang thai hộ</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="mangthai_ho_ts" ten="Mang thai hộ" runat="server"
                                            CssClass="form-control css_list" ktra="DT_MANGTHAI_HO_TS" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Phẫu thuật hoặc thai dưới 32 tuần</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="pthuat_thai_duoi32t_ts" runat="server" Text="" lke=",X" kt_xoa="X" ToolTip="Phẫu thuật hoặc thai dưới 32 tuần"
                                            ten="Phẫu thuật hoặc thai dưới 32 tuần" Width="30px" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày mẹ chết</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_me_chet_ts" runat="server" ten="Ngày mẹ chết" ToolTip="Ngày mẹ chết"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày kết luận</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ketluat_ts" runat="server" ten="Ngày kết luận" ToolTip="Ngày kết luận"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Phí giám định</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="phi_giamdinh_ts" ten="Phí giám định" ToolTip="Phí giám định" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số sổ BHXH của người nuôi</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="soso_bhxh_nguoinuoi_ts" ten="Số sổ BHXH của người nuôi" ToolTip="Số sổ BHXH của người nuôi dưỡng" runat="server"
                                            kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Cha nghỉ chăm con</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="cha_nghi_chamcon_ts" runat="server" Text="" lke=",X" kt_xoa="X" ToolTip="Cha nghỉ chăm con" Width="30px" CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày giải quyết trước</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gquyet_truoc_ts" runat="server" ten="Ngày giải quyết trước" ToolTip="Ngày giải quyết trước"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt giải quyết</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_giaiquyet_ts" ten="Đợt giải quyết" ToolTip="Đợt giải quyết" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_gquyet_ts" ten="Tháng năm giải quyết" runat="server"
                                            CssClass="form-control icon_lich" ToolTip="Tháng năm giải quyết" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt bổ sung</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_bsung_ts" ten="Đợt bổ sung" ToolTip="Đợt bổ sung" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode=" true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_bsung_ts" ten="Tháng năm bổ sung" ToolTip="Tháng năm bổ sung" runat="server"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Lý do đề nghị ĐC</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="lydo_denghi_dchinh_ts" ten="Lý do đề nghị ĐC" ToolTip="Lý do đề nghị điều chỉnh" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Phương án</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="phuong_an_ts" ten="Phương án" ToolTip="Phương án" runat="server"
                                            CssClass="form-control css_list" ktra="DT_PHUONG_AN_TS" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group width_common iterm_form">
                                <span class="standard_label b_left col_20">Ghi chú</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="ghichu_ts" runat="server" kt_xoa="X" CssClass="form-control css_nd" ten="ghi chú"
                                        ToolTip="ghi chú" TextMode="MultiLine" Row="3" />
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Pa_phsk" runat="server" Style="display: none;">
                            <div class="width_common pv_bl"></div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label b_left col_20">Hình thức kê khai</span>
                                <div class="input-group">
                                    <Cthuvien:DR_list ID="hinhthuc_kekhai_phsk" CssClass="form-control css_list" ten="Hình thức kê khai" ToolTip="Hình thức kê khai"
                                        runat="server" kt_xoa="X" tra="P1,P2" lke="P1 - DS hưởng chế độ mới phát sinh,P2 - DS đề nghị điều chỉnh số đã được giải quyết" />
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày đi làm lại</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dilam_lai_phsk" runat="server" ten="Ngày đi làm lại"
                                            ToolTip="Ngày đi làm lại" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Số seri/Lưu trữ</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_seri_phsk" ten="Số seri/Lưu trữ" ToolTip="Số seri/Lưu trữ" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Từ ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay_phsk" runat="server" ten="Từ ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay_phsk" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tổng số ngày</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="tong_so_ngay_phsk" ten="Tổng số ngày" ToolTip="Tổng số ngày" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày Đ.vi đề nghị hưởng</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_denghi_huong_phsk" runat="server" ten="Ngày đơn vị đề nghị hưởng"
                                            ToolTip="Ngày đơn vị đề nghị hưởng" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Tỷ lệ suy giảm</span>
                                    <div class="input-group">
                                        <Cthuvien:so ID="tyle_suygiam_phsk" ten="Tỷ lệ suy giảm" ToolTip="Tỷ lệ suy giảm" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Ngày giám định</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_giamdinh_phsk" runat="server" ten="Ngày giám định" ToolTip="Ngày giám định" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Ngày giải quyết trước</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gquyet_truoc_phsk" runat="server" ten="Ngày giải quyết trước"
                                            ToolTip="Ngày giải quyết trước" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Phương án</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="phuong_an_phsk" ten="Phương án" runat="server"
                                            CssClass="form-control css_list" ktra="DT_PHUONG_AN_PHSK" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt giải quyết</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_giaiquyet_phsk" ten="Đợt giải quyết" ToolTip="Đợt giải quyết" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_gquyet_phsk" ten="Tháng năm giải quyết"
                                            ToolTip="Tháng năm giải quyết" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_2_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_40">Đợt bổ sung</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dot_bsung_phsk" ten="Đợt bổ sung" ToolTip="Đợt bổ sung" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_40">Tháng năm</span>
                                    <div class="input-group">
                                        <Cthuvien:thang placeholder='MM/yyyy' ID="thang_nam_bsung_phsk" ten="Tháng năm bổ sung"
                                            ToolTip="Tháng năm bổ sung" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group width_common iterm_form">
                                <span class="standard_label b_left col_20">Lý do đề nghị ĐC</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="lydo_denghi_dchinh_phsk" runat="server" kt_xoa="X" CssClass="form-control css_nd" ten="Lý do đề nghị ĐC"
                                        ToolTip="Lý do đề nghị điều chỉnh" TextMode="MultiLine" Row="3" />
                                </div>
                            </div>
                            <div class="b_left form-group width_common iterm_form">
                                <span class="standard_label b_left col_20">Ghi chú</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="ghichu_phsk" runat="server" kt_xoa="X" CssClass="form-control css_nd" ten="ghi chú"
                                        ToolTip="ghi chú" TextMode="MultiLine" Row="3" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap1" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_bhxh_chedo_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Mới" OnClick="return ns_bhxh_chedo_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Xóa" OnClick="return ns_bhxh_chedo_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,680" />
    </div>
</asp:Content>


