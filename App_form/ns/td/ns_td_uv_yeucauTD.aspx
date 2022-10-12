<%@ Page Title="ns_td_uv_yeucauTD" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_uv_yeucauTD.aspx.cs" Inherits="f_ns_td_uv_yeucauTD" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khai báo ứng viên vào yêu cầu tuyển dụng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="Pa_ch">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã yêu cầu TD </span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ma_yc_tk" ten="Mã yêu cầu TD" ktra="DT_MA_YC_TK" runat="server" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái </span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_uv_theoyc_tk" kt_xoa="X" ten="Trạng thái" ktra="DT_UV_TK" runat="server" CssClass="form-control css_list">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" class="bt_action" anh="K" OnClick="return ns_td_uv_yeucauTD_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="width: 100%; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="sott,mayeucau_td,trangthai_uv_theoyc,so_id" hamRow="ns_td_uv_yeucauTD_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="T.tự" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã đề xuất tuyển dụng " DataField="mayeucau_td" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đề xuất tuyển dụng " DataField="ten_mayeucau_td" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên ứng viên" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số điện thoại" DataField="sodt_dd" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Email" DataField="email" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai_uv_theoyc" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai_uv_theoyc" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_uv_yeucauTD_P_LKE('L')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma" onchange="ns_td_uv_yeucauTD_P_KTRA('NAM')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đề xuất tuyển dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MAYEUCAU_TD" kt_xoa="X" CssClass="form-control css_list" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TD" runat="server" onchange="ns_td_uv_yeucauTD_P_KTRA('MAYEUCAU_TD')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_10">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_cdanh" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Chức danh" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_10">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Đơn vị" BackColor="#f6f7f7" />
                        </div>
                    </div>

                    <div class="b_left width_common round_ctent" id="TPu">
                        <div id="NPa" runat="server" class="navi_tabngang width_common">
                            <Cthuvien:tab ID="NPa_ttc" runat="server" CssClass="css_tab_ngang_ac" Width="103px" Text="Thông tin chung" Height="20px" />
                            <Cthuvien:tab ID="NPa_tdbc" runat="server" CssClass="css_tab_ngang_de" Width="110px" Text="Trình độ học vấn" Height="20px" />
                            <Cthuvien:tab ID="NPa_tdnn" runat="server" CssClass="css_tab_ngang_de" Width="120px" Text="Trình độ ngoại ngữ" Height="20px" />
                            <Cthuvien:tab ID="NPa_tdcc" runat="server" CssClass="css_tab_ngang_de" Width="66px" Text="Chứng chỉ" Height="20px" />
                            <Cthuvien:tab ID="NPa_qtct" runat="server" CssClass="css_tab_ngang_de" Width="115px" Text="Quá trình công tác" Height="20px" />
                            <Cthuvien:tab ID="NPa_qhnt" runat="server" CssClass="css_tab_ngang_de" Width="130px" Text="Quan hệ nhân thân" Height="20px" />
                            <Cthuvien:tab ID="NPa_ttngt" runat="server" CssClass="css_tab_ngang_de" Width="180px" Text="Thông tin người giới thiệu" Height="20px" />
                            <Cthuvien:tab ID="NPa_ttk" runat="server" CssClass="css_tab_ngang_de" Width="130px" Text="Thông tin khác" Height="20px" />
                        </div>
                        <div>
                            <asp:Panel ID="Pa_ttc" runat="server" Style="display: block;">
                                <div class="col_3_iterm width_common mg_top">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Mã ứng viên</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="so_the" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" Enabled="false" BackColor="#f6f7f7"
                                                ToolTip="Mã số cán bộ" ten="Số thẻ" onchange="ns_td_uv_yeucauTD_P_KTRA('SO_THE')" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Họ và Tên <span class="require">*</span></span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                                ten="Họ và tên" />
                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Ngành nghề hiện tại</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="nganhnghe_ht" ten="Ngành nghề hiện tại" runat="server" ToolTip="Ngành nghề hiện tại"
                                                CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Cấp bậc hiện tại</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="capbac_ht" ten="Cấp bậc hiện tại" runat="server" ToolTip="Cấp bậc hiện tại"
                                                CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Ngành nghề quan tâm</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="nganhnghe_qt" ten="Ngành nghề quan tâm" runat="server" ToolTip="Ngành nghề quan tâm" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                                        </div>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Nơi làm việc mong muốn</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="noilamviec_mm" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Lương mong muốn</span>
                                        <div class="input-group">
                                            <Cthuvien:so ID="mucluong_mm" ten="Mức lương mong muốn" kieu_so="true" runat="server" ToolTip="Mức lương mong muốn"
                                                CssClass="form-control css_so" kt_xoa="X" co_dau="K" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Giới tính <span class="require">*</span></span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke ID="GIOITINH" kt_xoa="X" ten="Giới tính" CssClass="form-control css_list" ktra="DT_GIOI_TINH" runat="server">                                                                                
                                            </Cthuvien:DR_lke>
                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Ngày sinh <span class="require">*</span></span>
                                        <div class="input-group">
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="NGAYSINH" ten="Ngày sinh" runat="server" CssClass="form-control icon_lich"
                                                kt_xoa="X" ToolTip="Năm sinh" />
                                        </div>
                                    </div>
                                </div>

                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Nơi sinh</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="noisinh" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                            kieu_unicode="true" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Tỉnh/Thành</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="tt_noisinh" ten="Tỉnh/Thành" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('tt_noisinh')" ToolTip="Tỉnh/Thành " ktra="ns_ma_tt,ma,ten" />

                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="qh_noisinh" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('qh_noisinh')" ToolTip="Quận/Huyện " />

                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="xp_noisinh" ten="Xã/Phường" runat="server" CssClass="form-control css_list" ToolTip="Xã/Phường" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Số CMND <span class="require">*</span></span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="SO_CMT" ten="Số CMND" kieu_so="true" ToolTip="Số chứng minh nhân dân" runat="server"
                                                CssClass="form-control css_ma" kt_xoa="X" />

                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Ngày cấp</span>
                                        <div class="input-group">
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngaycap_cmt" ten="Ngày cấp CMND" ToolTip="Ngày cấp CMND" runat="server"
                                                CssClass="form-control icon_lich" kt_xoa="X" />

                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Nơi cấp</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="noicap_cmt" ten="Nơi cấp CMT" kt_xoa="X" runat="server" CssClass="form-control css_ma" MaxLength="255" kieu_unicode="true" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Số hộ chiếu</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="so_hochieu" ten="Số CMND" kieu_so="true" ToolTip="Số hộ chiếu" runat="server"
                                                CssClass="form-control css_ma" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Ngày cấp</span>
                                        <div class="input-group">
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngaycap_hochieu" ten="Ngày cấp hộ chiếu" ToolTip="Ngày cấp CMND" runat="server"
                                                CssClass="form-control icon_lich" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Nơi cấp</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="noicap_hochieu" ten="Nơi cấp hộ chiếu" kt_xoa="X" runat="server" CssClass="form-control css_ma" MaxLength="255" kieu_unicode="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Chỗ ở hiện nay</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="tamtru" runat="server" kt_xoa="X" CssClass="form-control css_ma" ToolTip="Chỗ ở hiện nay"
                                            kieu_unicode="true" />
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Tỉnh/Thành</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="tt_tamtru" ten="Tỉnh/Thành" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('tt_tamtru')" ToolTip="Tỉnh/Thành " ktra="ns_ma_tt,ma,ten" />

                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="qh_tamtru" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('qh_tamtru')" ToolTip="Quận/Huyện " />

                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="xp_tamtru" ten="Xã/Phường" runat="server" CssClass="form-control css_list" ToolTip="Xã/Phường" />

                                        </div>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Hộ khẩu thường trú</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="thuongtru" runat="server" kt_xoa="X" CssClass="form-control css_ma" ToolTip="Hộ khẩu thường trú"
                                            kieu_unicode="true" ten="Hộ khẩu thường trú" />

                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Tỉnh/Thành</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="tt_thuongtru" ten="Tỉnh/Thành" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('tt_thuongtru')" ToolTip="Tỉnh/Thành " ktra="ns_ma_tt,ma,ten" />

                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="qh_thuongtru" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" onchange="ns_td_uv_yeucauTD_P_KTRA_DR('qh_thuongtru')" ToolTip="Quận/Huyện " />

                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke kt_xoa="X" ID="xp_thuongtru" ten="Xã/Phường" runat="server" CssClass="form-control css_list" ToolTip="Xã/Phường" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Tình trạng hôn nhân</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke ID="tt_honnhan" kt_xoa="X" ten="Tình trạng hôn nhân" CssClass="form-control css_list" ktra="DT_TT_HONNHAN" runat="server">                                                                                
                                            </Cthuvien:DR_lke>
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">ĐT nhà riêng</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="sodt_nr" ten="Số điện thoại nhà riêng" kieu_so="true" runat="server" ToolTip="Số điện thoại nhà riêng"
                                                CssClass="form-control css_ma" kt_xoa="X" />

                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">ĐT di động</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="sodt_dd" ten="Số điện thoại di động" kieu_so="true" runat="server" ToolTip="Số điện thoại di động"
                                                CssClass="form-control css_ma" kt_xoa="X" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Email <span class="require">*</span></span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="EMAIL" ten="Email" runat="server" CssClass="form-control css_ma" kt_xoa="X" />

                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Chiều cao</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="chieucao" ten="Chiều cao" runat="server" ToolTip="Chiều cao"
                                                CssClass="form-control css_ma" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Cân nặng</span>
                                        <div class="input-group">
                                            <Cthuvien:ma ID="cannang" ten="Cân nặng" kieu_so="true" runat="server" ToolTip="Cân nặng"
                                                CssClass="form-control css_ma" kt_xoa="X" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col_3_iterm width_common">
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_45">Dân tộc</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke ID="dantoc" kt_xoa="X" ten="Dân tộc" ktra="DT_DT" CssClass="form-control css_list" runat="server">                                                                                
                                            </Cthuvien:DR_lke>
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Tôn giáo</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke ID="tongiao" kt_xoa="X" ten="Tôn giáo" CssClass="form-control css_list" ktra="DT_TG" runat="server">                                                                                
                                            </Cthuvien:DR_lke>
                                        </div>
                                    </div>
                                    <div class="b_right form-group iterm_form">
                                        <span class="standard_label lv2 b_left col_45">Trạng thái</span>
                                        <div class="input-group">
                                            <Cthuvien:DR_lke ID="trangthai_uv_theoyc" kt_xoa="X" CssClass="form-control css_list" ten="Trạng thái ứng viên theo yêu cầu tuyển dụng" ktra="DT_UV" runat="server" Enabled="false">                                                                                
                                            </Cthuvien:DR_lke>
                                        </div>
                                    </div>
                                    <div style="display: none;">
                                        <Cthuvien:DR_lke ID="trangthai" kt_xoa="X" CssClass="form-control css_list" ten="Trạng thái ứng viên trong kho" ktra="DT_UV" runat="server" Enabled="false">                                                                                
                                        </Cthuvien:DR_lke>

                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_tdbc" runat="server" Style="display: none;">
                                <div class="grid_table width_common">
                                    <div style="height: 450px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_td" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="15" cot="ten_tentruong,ten_chuyennganh,tunam,dennam,ten_trinhdo,ten_hinhthuc_dt,loai_totnghiep,tentruong,chuyennganh,trinhdo,hinhthuc_dt"
                                            cotAn="sott,so_id,tentruong,chuyennganh,trinhdo,hinhthuc_dt" hamUp="ns_td_uv_td_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Tên trường" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <%--<Cthuvien:ma ID="tentruong" runat="server" CssClass="css_Gma" Width="250px" gchu="gchu" ten="Nhóm năng lực" />--%>
                                                        <Cthuvien:ma ID="ten_tentruong" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                            Width="250px" f_tkhao="~/App_form/ns/ma/ns_ma_truonghoc.aspx" gchu="gchu" ten="Hình thức đào tạo"
                                                            onchange="ns_td_uv_P_KTRA('TRUONGHOC')" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chuyên ngành" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_chuyennganh" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                            Width="250px" f_tkhao="~/App_form/ns/ma/ns_ma_cnganh_dt.aspx" gchu="gchu" ten="Chuyên ngành" guiId="TD_CN"
                                                            onchange="ns_td_uv_P_KTRA('CHUYENNGANH')" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Từ năm" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="tunam" runat="server" Width="80px" kieu_so="true" CssClass="css_Gma_c" MaxLength="4" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đến năm" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="dennam" runat="server" Width="80px" kieu_so="true" CssClass="css_Gma_c" MaxLength="4" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Trình độ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_trinhdo" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                            Width="250px" f_tkhao="~/App_form/ns/ma/ns_ma_capdt.aspx" gchu="gchu" ten="Trình độ"
                                                            onchange="ns_td_uv_P_KTRA('TEN_TRINHDO')" guiId="TD" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hình thức đào tạo" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_hinhthuc_dt" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                            Width="250px" f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" gchu="gchu" ten="Hình thức đào tạo"
                                                            onchange="ns_td_uv_P_KTRA('HINHTHUC_DT')" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loại tốt nghiệp" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="loai_totnghiep" runat="server" CssClass="css_Gma" Width="250px" kieu_unicode="true" gchu="gchu" ten="Loại tốt nghiệp" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ma_truong_hoc" DataField="tentruong">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ma_chuyennganh" DataField="chuyennganh">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ma_trinhdo" DataField="trinhdo">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ma_hinhthuc_dt" DataField="hinhthuc_dt">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_tdnn" runat="server" Style="display: none;">
                                <div class="grid_table width_common">
                                    <div style="height: 450px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_tdnn" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="15" cot="ten_ngoaingu,chungchi_nn,namcap,noicap,diem_nn,xeploai_nn"
                                            cotAn="so_id" hamUp="ns_td_uv_td_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Tên ngoại ngữ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_ngoaingu" runat="server" CssClass="css_Gma" Width="250px" kieu_unicode="true" gchu="gchu" ten="Tên ngoại ngữ" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chứng chỉ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="chungchi_nn" runat="server" CssClass="css_Gma" Width="250px" kieu_unicode="true" gchu="gchu" ten="Chứng chỉ" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Năm cấp" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="namcap" runat="server" Width="80px" kieu_so="true" CssClass="css_Gma_c" MaxLength="4" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nơi cấp" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="noicap" runat="server" CssClass="css_Gma" Width="250px" kieu_unicode="true" gchu="gchu" ten="Nơi cấp" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="diem_nn" runat="server" Width="100px" kieu_so="true" CssClass="css_Gma_c" MaxLength="4" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Xếp loại" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="xeploai_nn" runat="server" CssClass="css_Gma" Width="250px" kieu_unicode="true" gchu="gchu" ten="Loại tốt nghiệp" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_tdcc" runat="server" Style="display: none;">
                                <div class="grid_table width_common">
                                    <div style="height: 450px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_cc" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                            CssClass="table gridX" loai="N" hangKt="15" cot="tenchungchi,noidung,sohieu,coso_daotao,tungay,denngay,ngay_hl,ngay_hhl"
                                            cotAn="" hamUp="ns_td_uv_yeucauTD_td_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Tên chứng chỉ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="tenchungchi" runat="server" CssClass="css_Gma" kieu_unicode="true" Width="250px" gchu="gchu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="noidung" runat="server" CssClass="css_Gma" kieu_unicode="true" Width="250px" gchu="gchu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Số hiệu" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="sohieu" runat="server" CssClass="css_Gma" Width="250px" gchu="gchu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cơ sở đào tạo" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="coso_daotao" runat="server" CssClass="css_Gma" kieu_unicode="true" Width="250px" gchu="gchu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Từ ngày" HeaderStyle-Width="110px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đến ngày" HeaderStyle-Width="110px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ngày hiệu lực của CC" HeaderStyle-Width="110px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ngày hết hiệu lực CC" HeaderStyle-Width="110px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hhl" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>

                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_qtct" runat="server" Style="display: none;">
                                <div class="grid_table width_common">
                                    <div style="height: 450px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="15" cot="tencty,chucdanh,nhiemvu,tuthang,denthang,lydo_nghiviec"
                                            cotAn="sott">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Tên đơn vị công tác" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="tencty" runat="server" Width="250px" CssClass="css_Gma" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chức danh đảm nhiệm" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="chucdanh" runat="server" Width="250px" CssClass="css_Gma" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nhiệm vụ đảm nhiệm" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="nhiemvu" runat="server" Width="250px" CssClass="css_Gma" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Từ tháng/Năm" HeaderStyle-Width="115px">
                                                    <ItemTemplate>
                                                        <Cthuvien:thang ID="tuthang" runat="server" kt_xoa="X" ten="Từ tháng" CssClass="css_Gma_c" Width="115px"
                                                            ToolTip="Từ tháng" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đến tháng/Năm" HeaderStyle-Width="115px">
                                                    <ItemTemplate>
                                                        <Cthuvien:thang ID="denthang" runat="server" kt_xoa="X" ten="Đến tháng" CssClass="css_Gma_c" Width="115px"
                                                            ToolTip="Đến tháng" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lý do nghỉ việc" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="lydo_nghiviec" runat="server" Width="250px" CssClass="css_Gma" kt_xoa="X" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_qhnt" runat="server" Style="display: none;">
                                <div class="grid_table width_common">
                                    <div style="height: 450px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_nt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="15" cot="hoten,ten_quanhe,ngaysinh,nghenghiep,noi_ct,quanhe"
                                            cotAn="quanhe" hamUp="ns_td_uv_nt_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Họ và tên" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="hoten" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mối quan hệ" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_quanhe" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                            Width="100px" f_tkhao="~/App_form/ns/ma/ns_ma_lqh.aspx" gchu="gchu" ten="Mối quan hệ"
                                                            onchange="ns_td_uv_P_KTRA('QUANHE')" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ngày sinh" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngaysinh" runat="server" kt_xoa="X" ten="Từ tháng" CssClass="css_Gma_c" Width="120px"
                                                            ToolTip="Ngày sinh" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nghề nghiệp" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="nghenghiep" runat="server" Width="250px" kieu_unicode="true" CssClass="css_Gma" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nơi công tác" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="noi_ct" runat="server" Width="250px" CssClass="css_Gma" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Mã quan hệ" DataField="quanhe">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_ttngt" runat="server" Style="display: none;">
                                <div class="b_left col_100 inner">
                                    <div class="width_common pv_bl"><span>Thông tin người thân/họ hàng làm việc tại Tân Việt</span></div>
                                    <div class="b_left width_common form-group iterm_form">
                                        <span class="standard_label b_left col_20">Có</span>
                                        <div class="input-group">
                                            <Cthuvien:kieu ID="nguoithan_lvttd_co" runat="server" lke=",X" Width="30px" ToolTip="Có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                onchange="ns_td_uv_P_ANHIEN('NGUOITHAN_CO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />
                                            <span class="standard_label lv2 b_left col_20">Không</span>
                                            <Cthuvien:kieu ID="nguoithan_lvttd_ko" runat="server" lke=",X" Width="30px" ToolTip="Không có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                onchange="ns_td_uv_P_ANHIEN('NGUOITHAN_KO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />

                                        </div>
                                    </div>
                                    <div class="b_left width_common form-group iterm_form">
                                        <span class="standard_label b_left col_20">Nếu có ghi rõ Họ tên, Chưc danh, ĐV công tác</span>
                                        <div class="input-group">
                                            <Cthuvien:nd ID="nguoithan_lvttd_thongtin" runat="server" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X"
                                                ten="Nếu có ghi rõ Họ tên, Chưc danh, ĐV công tác" />
                                        </div>
                                    </div>
                                    <div class="width_common pv_bl"><span>Anh chị đã từng làm việc tại Tân Việt/span></div>
                                    <div class="col_2_iterm width_common">
                                        <div class="b_left form-group iterm_form">
                                            <span class="standard_label b_left col_40">Có</span>
                                            <div class="input-group">
                                                <Cthuvien:kieu ID="banthan_lvttd_co" runat="server" lke=",X" Width="30px" ToolTip="Có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                    onchange="ns_td_uv_P_ANHIEN('BANTHAN_CO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />
                                                <span class="standard_label b_left lv2 col_50">Không</span>
                                                <Cthuvien:kieu ID="banthan_lvttd_ko" runat="server" lke=",X" Width="30px" ToolTip="Không có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                    onchange="ns_td_uv_P_ANHIEN('BANTHAN_KO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />
                                            </div>
                                        </div>
                                        <div class="b_right form-group iterm_form">
                                            <span class="standard_label lv2 b_left col_40">Vị trí</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="banthan_lvttd_vitri" ten="Vị trí" kieu_unicode="true" runat="server" ToolTip="Vị trí"
                                                    CssClass="form-control css_ma" kt_xoa="X" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col_2_iterm width_common">
                                        <div class="b_left form-group iterm_form">
                                            <span class="standard_label b_left col_40">Bộ phận</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="banthan_lvttd_bophan" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ToolTip="Bộ phận" ten="Bộ phận" />
                                            </div>
                                        </div>
                                        <div class="b_right form-group iterm_form">
                                            <span class="standard_label lv2 b_left col_40">Tên trưởng bộ phận</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="banthan_lvttd_tbp" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên trưởng bộ phận" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col_2_iterm width_common">
                                        <div class="b_left form-group iterm_form">
                                            <span class="standard_label b_left col_40">Tên công ty</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="banthan_lvttd_cty" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ToolTip="Bộ phân" ten="Số thẻ" />
                                            </div>
                                        </div>
                                        <div class="b_right form-group iterm_form">
                                            <span class="standard_label lv2 b_left col_40">Thời gian làm việc</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="banthan_lvttd_tglv" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên trưởng bộ phận" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="b_left width_common form-group iterm_form">
                                        <span class="standard_label b_left col_20">Lý do thôi việc</span>
                                        <div class="input-group">
                                            <Cthuvien:nd ID="banthan_lvttd_lydo_nv" runat="server" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X"
                                                ten="Họ và tên" />
                                        </div>
                                    </div>
                                    <div class="width_common pv_bl"><span>Anh chị đã ứng tuyển vào một vị trí khác của Tân Việt</span></div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_20">Có</span>
                                        <div class="input-group">
                                            <Cthuvien:kieu ID="banthan_ut_co" runat="server" lke=",X" Width="30px" ToolTip="Có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                onchange="ns_td_uv_P_ANHIEN('UNGTUYEN_CO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />
                                            <span class="standard_label b_left lv2 col_20">Không</span>
                                            <Cthuvien:kieu ID="banthan_ut_ko" runat="server" lke=",X" Width="30px" ToolTip="Không có người thân/họ hàng làm việc tại Tập đoàn thủ đô"
                                                onchange="ns_td_uv_P_ANHIEN('UNGTUYEN_KO')" CssClass="form-control css_ma" Text="" kt_xoa="X" />
                                        </div>
                                    </div>
                                    <div class="b_left form-group iterm_form">
                                        <span class="standard_label b_left col_20">Nếu có ghi rõ Vị trí, công ty, thời gian ứng tuyển</span>
                                        <div class="input-group">
                                            <Cthuvien:nd ID="banthan_ut_thongtin" runat="server" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X"
                                                ten="Nếu có ghi rõ Vị trí, công ty, thời gian ứng tuyển" />

                                        </div>
                                    </div>
                                    <div class="width_common pv_bl"><span>Thông tin liên hệ</span></div>
                                    <div class="col_2_iterm width_common">
                                        <div class="b_left form-group iterm_form">
                                            <span class="standard_label b_left col_40">Họ tên</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="lienhe_hoten" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ToolTip="Họ tên" ten="Họ tên" />
                                            </div>
                                        </div>
                                        <div class="b_right form-group iterm_form">
                                            <span class="standard_label lv2 b_left col_40">Mối quan hệ</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="lienhe_mqh" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Mối quan hệ" ToolTip="Mối quan hệ" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col_2_iterm width_common">
                                        <div class="b_left form-group iterm_form">
                                            <span class="standard_label b_left col_40">Số điện thoại</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="lienhe_sdt" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ToolTip="Số điện thoại"
                                                    ten="Số điện thoại" />
                                            </div>
                                        </div>
                                        <div class="b_right form-group iterm_form">
                                            <span class="standard_label lv2 b_left col_40">Địa chỉ</span>
                                            <div class="input-group">
                                                <Cthuvien:ma ID="lienhe_diachi" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Địa chỉ" ToolTip="Địa chỉ" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Pa_ttk" runat="server" Style="display: none;">
                                <div class="width_common pv_bl"><span>Kế hoạch phát triển sự nghiệp</span></div>
                                <div class="b_left width_common form-group iterm_form">
                                    <div class="input-group">
                                        <Cthuvien:nd ID="kh_phattrien_sn" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                            kieu_unicode="true" MaxLength="255" Height="100px" />
                                    </div>
                                </div>
                                <div class="width_common pv_bl"><span>Các thành tích ấn tượng đạt được</span></div>
                                <div class="b_left width_common form-group iterm_form">
                                    <div class="input-group">
                                        <Cthuvien:nd ID="cac_thanhtich" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                            kieu_unicode="true" MaxLength="255" Height="100px" />
                                    </div>
                                </div>
                                <div class="width_common pv_bl"><span>Người có thể tham khảo thông tin</span></div>
                                <div class="grid_table width_common">
                                    <div style="height: 250px; overflow-x: scroll">
                                        <Cthuvien:GridX ID="GR_ttk" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="10" cot="hoten,congty,chucdanh,quanhe,sodt,email"
                                            cotAn="quanhe" hamUp="ns_td_uv_nt_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Họ và tên" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="hoten" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Đơn vị công tác" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="congty" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chức vụ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="chucdanh" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mối quan hệ" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="quanhe" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Điện thoại" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="sodt" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" HeaderStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="email" runat="server" Width="250px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </asp:Panel>

                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px" Text="Nhập" OnClick="return ns_td_uv_yeucauTD_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_td_uv_yeucauTD_P_MOI();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px" Text="Xóa" OnClick="return ns_td_uv_yeucauTD_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="file" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px" Text="File" OnClick="return nhap_file();form_P_LOI();" />
                        <Cthuvien:nhap ID="chonkho" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="180px" Text="Chọn ứng viên từ kho" OnClick="return ns_td_uv_yeucauTD_chonkho();form_P_LOI();" />

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
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,800" />
    </div>
</asp:Content>
