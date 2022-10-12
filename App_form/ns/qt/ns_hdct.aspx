<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_hdct.aspx.cs" Inherits="f_ns_hdct"
    Title="ns_hdct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý quyết định" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div id="UPa_tk" class="b_left col_40 inner">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại quyết định</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="hinhthuc_tk" ktra="DT_HINHTHUC_TK" kt_xoa="K" ten="Loại quyết định" runat="server" CssClass="form-control css_list"
                                    onchange="checkanhien();" ToolTip="Loại quyết định"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" runat="server" kieu_chu="true" lke=",Phê duyệt,Chờ phê duyệt,Không phê duyệt" tra=",PD,CPD,KPD" ten="Trạng thái" CssClass="form-control css_list"
                                    ToolTip="Trạng thái"></Cthuvien:DR_list>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Đến ngày" />
                            </div>
                        </div>
                    </div>
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
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none;">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" CssClass="form-control css_list" runat="server" onchange="ns_hdct_P_KTRA('PHONG_TK')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nhân viên NV</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="nghi_viec_tk" runat="server" lke=",X" Width="30px" ToolTip="  - Chưa nghỉ việc,X - Nghỉ việc" CssClass="form-control css_ma_c" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_hdct_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="20" cot="chon,so_the,ten,loai_qd,ngayd,ngayc,so_id,tt,ten_tt,hinhthuc"
                                cotAn="ngayc,so_id,tt,hinhthuc" hamRow="ns_hdct_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại quyết định" DataField="loai_qd" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngayc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="tt" DataField="tt" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="hinhthuc" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdct_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_hdct_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div id="UPa_ct" class="b_right col_60 inner">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                    onchange="ns_hdct_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
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
                            <span class="standard_label lv2 b_left col_40">Loại quyết định<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="HINHTHUC" ktra="DT_HINHTHUC" kt_xoa="X" CssClass="form-control css_list" ten="Loại quyết định" runat="server"
                                    onchange="checkanhien();ns_hdct_P_SOQD();" ToolTip="Loại quyết định"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số quyết định<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_QD" ten="Số quyết định" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    kieu_unicode="true" kieu_chu="true" ToolTip="Số quyết định" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày hiệu lực" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày hiệu lực" onchange="ns_hdct_P_SOQD()" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày hết hiệu lực" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày hết hiệu lực" />
                            </div>
                        </div>
                    </div>
                    <div id="an_title_bonhiem" class="width_common pv_bl"><span>Thông tin bổ nhiệm</span></div>
                    <div id="an_title_miennhiem" class="width_common pv_bl"><span>Thông tin bổ nhiệm</span></div>
                    <div id="an_title_dieuchuyen" class="width_common pv_bl"><span>Thông tin chức danh, đơn vị sau điều chuyển</span></div>
                    <div id="an_title_tiepnhan" class="width_common pv_bl"><span>Thông tin chức danh, đơn vị sau tiếp nhận</span></div>
                    <div id="an_ngayhl_bonhiem" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày bổ nhiệm lần đầu<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bn_landau" runat="server" ten="Ngày bổ nhiệm lần đầu" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày bổ nhiệm lần đầu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày bổ nhiệm gần nhất</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bn_gannhat" runat="server" ten="Ngày bổ nhiệm gần nhất" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày bổ nhiệm gần nhất" />
                            </div>
                        </div>
                    </div>
                    <div id="an_phong_cdanh_bonhiem" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng mới<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_m" ktra="DT_PHONG" ten="Phòng mới" kt_xoa="X" runat="server" CssClass="form-control css_list"
                                    onchange="ns_hdct_P_KTRA('PHONG')" ToolTip="Phòng mới" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh mới<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh_m" ktra="DT_CDANH" runat="server" onchange="ns_hdct_P_KTRA('CDANH')"
                                    CssClass="form-control css_list" kt_xoa="T" ten="Chức danh" ToolTip="Chức danh mới" />
                            </div>
                        </div>
                    </div>

                    <div id="an_cdanh_miennhiem" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh miễn nhiệm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh_miennhiem" ktra="DT_PHONG" ten="Phòng mới" kt_xoa="X" runat="server" CssClass="form-control css_list" onchange="ns_hdct_P_KTRA('PHONG')" ToolTip="Phòng mới" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh sau miễn nhiệm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh_saumiennhiem" ktra="DT_CDANH" runat="server" onchange="ns_hdct_P_KTRA('CDANH')" CssClass="form-control css_list" kt_xoa="T" ten="Chức danh" ToolTip="Chức danh mới" />
                            </div>
                        </div>
                    </div>

                    <div id="an_title_luonght" class="width_common pv_bl"><span>Thông tin lương hiện tại</span></div>
                    <div id="an_thang_ngach_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 Bảng lương b_left col_40">Thang lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tl_c" ten="Thang lương hiện tại" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" ToolTip="Thang lương hiện tại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngạch lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_nl_c" ten="Ngạch lương hiện tại" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" BackColor="#f6f7f7" ToolTip="Ngạch lương hiện tại" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="ma_tl_c" ten="Bảng lương hiện tại" runat="server" Width="200px" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X"
                            Enabled="false" ReadOnly="true" ToolTip="Bảng lương hiện tại" />
                        <Cthuvien:ma ID="ma_nl_c" ten="Ngạch lương hiện tại" runat="server" Width="200px" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X"
                            Enabled="false" ReadOnly="true" ToolTip="Ngạch lương hiện tại" />
                        <Cthuvien:ma ID="ma_bl_c" ten="Bậc lương hiện tại" runat="server" Width="200px" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X"
                            Enabled="false" ReadOnly="true" ToolTip="Bậc lương hiện tại" />
                    </div>
                    <div id="an_bac_luong_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Bậc lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_bl_c" ten="Bậc lương hiện tại" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" ToolTip="Bậc lương hiện tại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương cơ bản</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luongcb_c" runat="server" kieu_so="true" kt_xoa="X" Enabled="false" CssClass="form-control css_so"
                                    ten="Lương cơ bản hiện tại" BackColor="#f6f7f7" ToolTip="Lương cơ bản hiện tại" />
                            </div>
                        </div>
                    </div>
                    <div id="an_luongcb_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thu nhập hàng tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thunhapthang_c" ten="Thu nhập tháng hiện tại" runat="server" BackColor="#f6f7f7" CssClass="form-control css_so" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" ToolTip="Thu nhập tháng hiện tại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương HQCV</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thuong_ketqua_c" ReadOnly="true" kieu_so="true" ten="Lương HQCV" Enabled="false" runat="server" kt_xoa="X"
                                    CssClass="form-control css_so" BackColor="#f6f7f7" ToolTip="Lương HQCV" />
                            </div>
                        </div>
                    </div>
                    <div id="an_pt_huongluong_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đơn giá</span>
                            <div class="input-group">
                                <Cthuvien:so ID="dongia_c" ten="Đơn giá" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" Enabled="false" ReadOnly="true" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">% hưởng lương</span>
                            <div class="input-group">
                                <Cthuvien:so ID="pt_huongluong_c" runat="server" kieu_so="true" kt_xoa="X" Enabled="false" CssClass="form-control css_so"
                                    ToolTip="% hưởng lương hiện tại" ten="% hưởng lương hiện tại" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div id="an_tyle_hoahong_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng theo phí giao dịch </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tyle_hoahong_theophi_c" ten="Tỷ lệ hoa hồng theo phí giao dịch" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" ToolTip="Tỷ lệ hoa hồng theo phí giao dịch" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tyle_hoahong_c" ten="Tỷ lệ hoa hồng" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" Enabled="false" ReadOnly="true" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div id="an_title_luongtd" class="width_common pv_bl"><span>Thông tin lương thay đổi</span></div>
                    <div id="an_thang_ngach_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thang lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_tl" ktra="DT_MA_TL" CssClass="form-control css_list" ten="Thang lương" kt_xoa="X" runat="server" onchange="ns_hdct_P_KTRA('MA_TL')" ToolTip="Thang lương" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngạch lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_nl" ktra="DT_MA_NL" ten="Ngạch lương" kt_xoa="X" runat="server" CssClass="form-control css_list" onchange="ns_hdct_P_KTRA('MA_NL')" ToolTip="Ngạch lương" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" id="an_bac_luong_td">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40" id="lblNgachLuongMoi">Bậc lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_bl" ktra="DT_MA_BL" ten="Bậc lương" kt_xoa="X" runat="server" CssClass="form-control css_list" onchange="ns_hdct_P_KTRA('MA_BL')" ToolTip="Bậc lương"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương cơ bản</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luongcb" runat="server" kieu_so="true" kt_xoa="X" ten="Lương cơ bản" ToolTip="Lương cơ bản"
                                    onchange="ns_hdct_tinh_thuongkq();" CssClass="form-control css_so" />
                            </div>
                        </div>
                    </div>
                    <div id="an_luongcb_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span id="lblTongLuongMoi" class="standard_label lv2 b_left col_40">Thu nhập hàng tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thunhapthang" runat="server" kieu_so="true" kt_xoa="X" CssClass="form-control css_so" onchange="ns_hdct_tinh_thuongkq();"
                                    ten="Thu nhập tháng" ToolTip="Thu nhập tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương HQCV</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thuong_ketqua" Enabled="false" ten="Lương HQCV" ToolTip="Lương HQCV" runat="server"
                                    BackColor="#f6f7f7" kt_xoa="X" CssClass="form-control css_so" />
                            </div>
                        </div>
                    </div>
                    <div id="an_pt_huongluong_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đơn giá</span>
                            <div class="input-group">
                                <Cthuvien:so ID="dongia" ten="Đơn giá" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40">% hưởng lương</span>
                            <div class="input-group">
                                <Cthuvien:so ID="pt_huongluong" runat="server" ten="% hưởng lương" kieu_so="true" kt_xoa="X" CssClass="form-control css_so"
                                    Text="100" ToolTip="% hưởng lương" />
                            </div>
                        </div>
                    </div>
                    <div id="an_tyle_hoahong_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng theo phí giao dịch </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="tyle_hoahong_theophi" ktra="DT_CHIPHI" ten="Biểu mẫu phí giao dịch" kt_xoa="X" CssClass="form-control css_list"
                                    runat="server" ToolTip="Biểu mẫu phí giao dịch" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tyle_hoahong" ten="Tỷ lệ hoa hồng" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" />
                            </div>
                        </div>
                    </div>

                    <div class="width_common pv_bl"><span>Thông tin phê duyệt</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày ký QĐ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_QD" runat="server" ten="Ngày ký QĐ" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày ký quyết định" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Trạng thái<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TT" runat="server" kieu_chu="true" CssClass="form-control css_list" lke="Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra="CPD,PD,KPD" ten="Trạng thái"
                                    ToolTip="Trạng thái"></Cthuvien:DR_list>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Người ký</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_nguoiky" runat="server" kt_xoa="X" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Người ký" placeholder="Nhấn (F1)"
                                    onchange="ns_hdct_P_KTRA('MA_NGUOIKY')" ktra="ns_cb,so_the,ten" ToolTip="Mã người ký" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh người ký</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh_nguoiky" runat="server" BackColor="#f6f7f7" kt_xoa="X" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Chức danh người ký" Enabled="false" ReadOnly="true" ToolTip="Chức danh người ký" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20 lv2 iterm_form">Ghi chú</span>
                        <div class="input-group iterm_form">
                            <Cthuvien:nd ID="ghichu" TextMode="MultiLine" Height="35px" runat="server" CssClass="form-control css_nd" kt_xoa="X" MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                        </div>
                    </div>
                    <div>
                        <div class="width_common pv_bl" style="display: none"><span>Thông tin phụ cấp</span></div>
                        <div class="grid_table width_common">
                            <div>
                                <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" hamUp="ns_hdct_P_Update" cotAn="co_bh" Width="100%"
                                    AutoGenerateColumns="false" hangKt="10" cot="ma_pc,ten,sotien,ngay_ad,ngay_kt,co_bh" PageSize="1" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã phụ cấp" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ma_pc" runat="server" placeholder="Nhấn (F1)" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac.aspx"
                                                    CssClass="css_Gma" Width="100px" kt_xoa="K" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ten" HeaderText="Tên phụ cấp" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                        <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:so ID="sotien" runat="server" CssClass="css_Gma_r" Width="100%" kt_xoa="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày áp dụng" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ad" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100px" kt_xoa="K" TaoValid="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày kết thúc" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_kt" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100px" kt_xoa="K" TaoValid="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đóng BH" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="co_bh" runat="server" lke=",C" Width="80px" ToolTip="  - Không đóng bảo hiểm,X - Đóng bảo hiểm" CssClass="css_Gma_c" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img alt="" src="../../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdct_P_HangLen();" />
                                    </li>
                                    <li>
                                        <img alt="" src="../../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdct_P_HangXuong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="../../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdct_P_CatDong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="../../../images/bitmaps/chen.gif" title="Thêm 1 dòng mới" onclick="return ns_hdct_P_chenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action lv2">
                        <div class="col_3_iterm width_common">
                            <div id="an_mopd" class="b_left form-group iterm_form">
                                <Cthuvien:nhap ID="mopd" runat="server" Text="Mở chờ phê duyệt" class="bt_action" anh="K" Width="120px" OnClick="ns_hdct_P_PHEDUYET();form_P_LOI('');" Title="Mở chờ phê duỵệt" />
                            </div>
                            <div class="b_left" style="padding-left: 3px;">
                                <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="ns_hdct_P_MOI();form_P_LOI('');" Title="Mới" />
                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="ns_hdct_P_NH('N');form_P_LOI('');" Title="Nhập" />
                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="ns_hdct_P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                                <Cthuvien:nhap ID="in" runat="server" Text="In" class="bt_action" anh="K" title="In" OnClick="ns_hdct_P_BIEUMAU();form_P_LOI();" />
                                <Cthuvien:nhap ID="excel" runat="server" Text="File" class="bt_action" anh="K" OnClick="ns_tv_P_FILE();form_P_LOI('');" Title="Đính kèm file" />
                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_CHON('so_qd,so_id');form_P_LOI('');" Title="Chọn" />
                                <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" class="bt_action" anh="K" OnClick="ns_hdct_P_NH('P');form_P_LOI('');" Title="Phe duyệt" />
                                <Cthuvien:nhap ID="cat_pc" runat="server" Text="Cắt phụ cấp" class="bt_action" anh="K" OnClick="ns_hdct_P_CAT_PC();form_P_LOI('');" Title="Cắt phụ cấp" />

                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <button onclick="return ns_hdct_Export();form_P_LOI();" class="bt_action mgt10">Xuất file mẫu</button>
                        <button onclick="return ns_hdct_Import();form_P_LOI();" class="bt_action mgt10">Import</button>


                        <Cthuvien:nhap ID="xuatfilemau" runat="server" Width="100px" Text="File mẫu" OnServerClick="export_excel" />
                        <Cthuvien:nhap ID="msword" runat="server" Width="70px" Text="Export" OnServerClick="msword_Click" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
            </div>
        </div>
        <div id="UPa_gchu" style="display: none">
            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="a_so_id" runat="server" />
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="alqdinh" runat="server" />
        <Cthuvien:an ID="aphong_tk" runat="server" />
        <Cthuvien:an ID="atrangthai" runat="server" />
        <Cthuvien:an ID="so_the_luu" runat="server" />
        <Cthuvien:an ID="ten_luu" runat="server" />
        <Cthuvien:an ID="atluong" runat="server" />
        <Cthuvien:an ID="anluong" runat="server" />
        <Cthuvien:an ID="abluong" runat="server" />
        <Cthuvien:an ID="acheckall" runat="server" />
        <Cthuvien:an ID="phong_luu" runat="server" />
        <Cthuvien:an ID="nghi_viec_luu" runat="server" />
        <Cthuvien:an ID="atcdanh" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1210,860" />
    </div>
</asp:Content>
