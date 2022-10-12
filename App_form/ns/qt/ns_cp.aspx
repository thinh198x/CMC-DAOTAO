<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_cp.aspx.cs" Inherits="f_ns_cp" Title="ns_cp" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý điều chuyển giữa các công ty thành viên " />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div id="UPa_tk" class="width_common auto_sc line_37">
                <div class="b_left col_30 inner">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Từ ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" ten="Ngày hiệu lực" CssClass="form-control css_ngay" kieu_luu="S"
                                kt_xoa="X" ToolTip="Ngày hiệu lực" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Đến ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" ten="Đến ngày" CssClass="form-control css_ngay" kieu_luu="S"
                                kt_xoa="X" ToolTip="Đến ngày" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="tt_tk" runat="server" CssClass="form-control css_list" lke=",Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra=",CPD,PD,KPD" ten="Trạng thái"
                                ToolTip="Trạng thái"></Cthuvien:DR_list>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form" style="display: none;">
                        <span class="standard_label b_left col_30">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" CssClass="form-control css_list" runat="server" onchange="ns_cp_P_KTRA('PHONG_TK')">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" kieu_unicode="true" CssClass="form-control css_ma" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_cp_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="10" cotAn="so_id,tt,hinhthuc" hamRow="ns_cp_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Chức danh ĐC đi" DataField="CDANH_CU" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị ĐC đi" DataField="CTY_DI" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh ĐC đến" DataField="CDANH" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị ĐC đến" DataField="CTY_DEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="tt" DataField="tt" />
                                    <asp:BoundField HeaderText="so_id" DataField="hinhthuc" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cp_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="ns_cp_P_IN()" />
                    </div>
                </div>
                <div id="UPa_ct" class="b_right col_70 inner">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                    onchange="ns_cp_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên nhân viên" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong_cu" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Phòng" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh_cu" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin lương</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Thang lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_tl" disabled="true" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" gchu="gchu"
                                    kieu_unicode="true" kt_xoa="K" ten="Mã nhân viên" ToolTip="Thang lương" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngạch lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_nl" ten="Ngạch lương" disabled="true" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Ngạch lương" kt_xoa="X" kieu_unicode="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Bậc lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_bl" ten="Bậc lương" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Bậc lương" kt_xoa="X" kieu_unicode="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lương cơ bản</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="luong_cb" ten="Lương cơ bản" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Lương cơ bản" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div id="an_luongcb_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Thu nhập hàng tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thunhap_thang" ten="Thu nhập tháng hiện tại" runat="server" BackColor="#f6f7f7" CssClass="form-control css_so" kt_xoa="X"
                                    Enabled="false" ReadOnly="true" ToolTip="Thu nhập tháng hiện tại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Thưởng kết quả cv tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thuong_thang" ReadOnly="true" kieu_so="true" ten="Thưởng kết quả công việc tháng hiện tại" Enabled="false" runat="server" kt_xoa="X"
                                    CssClass="form-control css_so" BackColor="#f6f7f7" ToolTip="Thưởng kết quả công việc tháng hiện tại" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin điều chuyển</span></div>
                    <div id="an_pt_huongluong_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Công ty<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CONG_TY" ktra="DT_CTY" ten="Công ty" kt_xoa="X" CssClass="form-control css_list" onchange="ns_cp_P_KTRA_DR('CONG_TY')" runat="server" ToolTip="Phòng mới" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" onchange="ns_cp_P_KTRA_DR('PHONG')" kt_xoa="X" ten="Chức danh" ToolTip="Chức danh mới" />
                            </div>
                        </div>
                    </div>
                    <div id="an_thang_ngach_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh" ktra="DT_CDANH" runat="server" CssClass="form-control css_list" onchange="ns_cp_P_KTRA('CDANH')" kt_xoa="T" ten="Chức danh" ToolTip="Chức danh mới" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Loại QĐ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="HINHTHUC" runat="server" kieu_chu="true" CssClass="form-control css_list" lke="QĐ điều chuyển giữa các công ty thành viên" tra="QD010" ten="Loại QĐ"
                                    ToolTip="Loại QĐ" kt_xoa="X"></Cthuvien:DR_list>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" id="an_bac_luong_td">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30" id="lblNgachLuongMoi">Số QĐ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_QD" runat="server" ten="Số quyết định" CssClass="form-control css_ma" kieu_unicode="True" MaxLength="100" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày hiệu lực" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày hiệu lực" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày hết hiệu lực" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày hết hiệu lực" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30"></span>
                            <div class="input-group">
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin phê duyệt</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Người ký</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nguoi_ky" runat="server" kt_xoa="X" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Người ký" placeholder="Nhấn (F1)"
                                    onchange="ns_cp_P_KTRA('NGUOI_KY')" ktra="ns_cb,so_the,ten" ToolTip="Mã người ký" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh người ký</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh_ky" runat="server" BackColor="#f6f7f7" kt_xoa="X" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Chức danh người ký" Enabled="false" ReadOnly="true" ToolTip="Chức danh người ký" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày ký QĐ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_KY" runat="server" ten="Ngày ký QĐ" CssClass="form-control css_ngay" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày ký quyết định" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Trạng thái <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TT" runat="server" kieu_chu="true" CssClass="form-control css_list" lke="Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra="CPD,PD,KPD" ten="Trạng thái"
                                    ToolTip="Trạng thái"></Cthuvien:DR_list>
                            </div>
                        </div>
                    </div>

                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="90px" class="bt_action" anh="K" OnClick="ns_cp_P_MOI();form_P_LOI('');" Title="Mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" class="bt_action" anh="K" OnClick="ns_cp_P_NH();form_P_LOI('');" Title="Nhập" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" class="bt_action" anh="K" OnClick="ns_cp_P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />

                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="in" runat="server" Text="In" Width="70px" class="css_button" title="In" OnServerClick="msword_Click" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="form_P_CHON('so_qd,so_id');form_P_LOI('');" Title="Chọn" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Export" OnServerClick="xuatExcel_Click" />
                        <Cthuvien:nhap ID="Xuat2" runat="server" Width="70px" Text="Export" OnServerClick="xuat_Click" />
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
        <Cthuvien:an ID="alqdinh" runat="server" />
        <Cthuvien:an ID="so_the_luu" runat="server" />
        <Cthuvien:an ID="ten_luu" runat="server" />
        <Cthuvien:an ID="atluong" runat="server" />
        <Cthuvien:an ID="anluong" runat="server" />
        <Cthuvien:an ID="abluong" runat="server" />
        <Cthuvien:an ID="phong_luu" runat="server" />
        <Cthuvien:an ID="tt_tk_luu" runat="server" />
        <Cthuvien:an ID="nghi_viec_luu" runat="server" />
        <Cthuvien:an ID="atcdanh" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1210,860" />
    </div>
</asp:Content>
