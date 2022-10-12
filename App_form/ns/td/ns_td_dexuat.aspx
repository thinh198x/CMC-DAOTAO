<%@ Page Title="ns_td_dexuat" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_dexuat.aspx.cs" Inherits="f_ns_td_dexuat" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đề xuất tuyển dụng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" runat="server" ten="Năm" kt_xoa="G" CssClass="form-control css_ma" kieu_so="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label b_left col_40">Đơn vị/Bộ phận</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ten="Đơn vị/Bộ phận" ktra="DT_PHONG_TK" runat="server" CssClass="form-control css_list">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="150px" OnClick="return ns_td_dexuat_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,trangthai_pd" hamRow="ns_td_dexuat_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="trangthai" DataField="trangthai_pd" />
                                    <asp:BoundField HeaderText="Mã đề xuất" DataField="Ma" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Bộ phận" DataField="phongban_ct" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số lượng tuyển dụng" DataField="soluong_td" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày cần nhân sự" DataField="ngay_can_ns" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai_pd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_dexuat_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã đề xuất <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" ten="Mã" kt_xoa="G" CssClass="form-control css_ma" Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" ten="Năm" kt_xoa="X" CssClass="form-control css_so"
                                    onchange="ns_td_dexuat_P_KTRA('NAM');" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày đề xuất <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_DEXUAT" ten="Ngày đề xuất" ToolTip="Ngày đề xuất" runat="server"
                                    CssClass="form-control icon_lich" kt_xoa="X" />
                            </div>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Công ty <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="donvi" ktra="DT_DONVI" runat="server" CssClass="form-control css_list" onchange="ns_td_dexuat_P_KTRA('DONVI')" kt_xoa="X" ten="Công ty"></Cthuvien:DR_lke>

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ban/Phòng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ban" ktra="DT_BAN" runat="server" CssClass="form-control css_list" onchange="ns_td_dexuat_P_KTRA('BAN')" kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phòng/Bộ phận</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" onchange="ns_td_dexuat_P_KTRA('PHONG')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CDANH" ktra="DT_CDANH" runat="server" onchange="ns_td_dexuat_P_KTRA('CDANH');" CssClass="form-control css_list" kt_xoa="X" ten="Chức danh"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Đơn vị/ bộ phận<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="phongban_ct" runat="server" CssClass="form-control" Enabled="false" BackColor="#f6f7f7" kt_xoa="X" ten="Đơn vị/ bộ phận" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số lượng hiện tại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sl_hientai" ten="Số lượng hiện tại" kieu_so="true" runat="server" CssClass="form-control css_ma_r" ToolTip="Số lượng hiện tại"
                                    kt_xoa="X" Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Định biên được duyệt</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="db_duocduyet" ten="Định biên được duyệt" kieu_so="true" runat="server" CssClass="form-control css_ma_r"
                                    ToolTip="Định biên được duyệt" kt_xoa="X" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số lượng DXTD</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="soluong_td" kieu_so="true" runat="server" ten="Số lượng TD" kt_xoa="X" CssClass="form-control css_ma_r" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left col_40"></span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="vitri_key" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Có là vị trí key,  - Không phải vị trí key" CssClass="form-control css_ma_c" Text="" />
                                <span class="standard_label lv2 b_left col_70">Vị trí key</span>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40"></span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="cotheo_kh_nam" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Có theo kế hoạch năm,  - Không theo kế hoạch năm"
                                    onchange="ns_td_dexuat_P_NPA()" CssClass="form-control css_ma" Text="" />
                                <span class="standard_label lv2 b_left col_80">Có theo kế hoạch năm</span>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kế hoạch năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kehoach_nam" ktra="DT_KEHOACH_NAM" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="kế hoạch năm"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày cần nhân sự</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_can_ns" ten="ngày cần nhân sự" ToolTip="ngày cần nhân sự" runat="server"
                                    CssClass="form-control icon_lich" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lý do tuyển dụng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="lydo_tuyendung" runat="server" CssClass="form-control css_list" lke="Tuyển mới, Tuyển thay thế, Tuyển thời vụ, Tuyển khác" tra="TM,TTT,TTV,TK" ten="Lý do tuyển dụng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loai_nv" runat="server" CssClass="form-control css_list" lke="Chính thức,Cộng tác viên,TSS,Học việc" tra="CT,CTV,TSS,HV" ten="Loại nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trình độ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="trinhdo" kieu_unicode="true" runat="server" ten="Trình độ" kt_xoa="X" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left lv2 col_20">Loại hợp đồng</span>
                        <div class="grid_table">
                            <div>
                                <Cthuvien:GridX ID="Gr_hd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="N" cot="sott,lhd,soluong" hangKt="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:TemplateField HeaderText="STT" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="sott" runat="server" kieu_so="true" CssClass="css_Gma" kt_xoa="X" Width="80px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loại hợp đồng">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="lhd" ktra="DT_LHD" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X" ten="loại hợp đồng"></Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số lượng">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="soluong" runat="server" kieu_so="true" CssClass="css_Gma" kt_xoa="X" Width="70px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                                <div class="btex_luoi b_right">
                                    <ul>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return loai_hd_HangLen();" />
                                        </li>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return loai_hd_HangXuong();" />
                                        </li>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return loai_hd_CatDong();" />
                                        </li>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return loai_hd_ChenDong('C');" />
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mức lương từ</span>
                            <div class="input-group">
                                <Cthuvien:so ID="mucluong_tu" so_tp="3" ten="Mức lương từ" kieu_so="true" runat="server" CssClass="form-control css_so" ToolTip="Mức lương từ" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mức lương đến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="mucluong_den" so_tp="3" ten="Mức lương đến" kieu_so="true" runat="server" CssClass="form-control css_so" ToolTip="Mức lương đến" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Mô tả công việc</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota_cv" ten="Mô tả công việc" runat="server" kt_xoa="X" Height="50px"
                                CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Chuyên ngành đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="chuyennganh_dt" ten="Chuyên ngành đào tạo" kieu_unicode="true" runat="server" CssClass="form-control css_ma" ToolTip="Chuyên ngành đào tạo"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kinh nghiệm làm việc</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kinhnghiem" ktra="DT_KINHNGHIEM" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Kinh nghiệm làm việc"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kinh nghiệm khác</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kinhnghiem_khac" ten="Kinh nghiệm khác" runat="server" CssClass="form-control" ToolTip="Kinh nghiệm khác" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Yêu cầu kỹ năng khác</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="yeucau_kn" ten="Yêu cầu kỹ năng khác" runat="server" kt_xoa="X"
                                CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Người chịu trách nhiệm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NGUOICHIU_TN" ktra="DT_NGUOICHIU_TN" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Người chịu trách nhiệm"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40"></span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="daduocduyet" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Đã được phê duyệt,  - Chưa được phê duyệt" CssClass="form-control css_ma_c" Text="" />
                                <span class="standard_label lv2 b_left col_70">Đã được phê duyệt</span>

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày phê duyệt ĐXTD</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_pd" ten="Ngày phê duyệt ĐXTD" ToolTip="Ngày phê duyệt ĐXTD" runat="server"
                                    CssClass="form-control icon_lich" kt_xoa="X" Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái PD</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_pd" runat="server" CssClass="form-control css_list" lke="Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra="0,1,2"
                                    BackColor="#f6f7f7" ten="Trạng thái PD" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="100px" Text="Ghi" OnClick="return ns_td_dexuat_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" Width="100px" OnClick="return ns_td_dexuat_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="100px" Text="Xóa" OnClick="return ns_td_dexuat_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>

        <div id="UPa_gchu">
            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,700" />
    </div>

</asp:Content>

