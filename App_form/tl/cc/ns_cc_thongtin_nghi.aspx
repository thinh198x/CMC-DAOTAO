<%@ Page Title="ns_cc_thongtin_nghi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_thongtin_nghi.aspx.cs" Inherits="f_ns_cc_thongtin_nghi" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý đăng ký nghỉ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm </span>
                            <%-- <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_thongtin_nghi_P_NAM();" ktra="DT_NAM" />  
                            </div>--%>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="ns_cc_thongtin_nghi_P_NAM('NAM');"
                                    runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="ns_cc_thongtin_nghi_P_KTRA('KYLUONG_TK')" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" CssClass="form-control css_list" onchange="ns_cc_thongtin_nghi_P_KTRA('PHONG_TK')" ktra="DT_PHONG" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_cc_thongtin_nghi_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="ten_huydon,macc_nghi,huydon,ten_cdanh,ten_phong,sang,chieu,noidung,so_id,dtuong_nh"
                                hamRow="ns_cc_thongtin_nghi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại hình nghỉ" DataField="ten_loai" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_huydon" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đối tượng nhập" DataField="ten_dtuong_nh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đối tượng nhập" DataField="dtuong_nh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại hình nghỉ" DataField="macc_nghi" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="huydon" />
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" />
                                    <asp:BoundField HeaderText="Công sáng" DataField="sang" />
                                    <asp:BoundField HeaderText="Công chiều" DataField="chieu" />
                                    <asp:BoundField HeaderText="Nội dung" DataField="noidung" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_thongtin_nghi_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_cc_thongtin_nghi_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" placeholder="Nhấn (F1)" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số nhân viên" kt_xoa="X" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_cc_thongtin_nghi_P_KTRA('SO_THE')" gchu="gchu" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>

                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="PHONG" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại hình nghỉ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MACC_NGHI" ktra="DT_KIEUNGHI" ten="Loại hình nghỉ" CssClass="form-control css_list" runat="server"
                                    onchange="ns_cc_thongtin_nghi_P_KTRA('MACC_NGHI');">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Nhân viên thay thế </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="sothe_thaythe" ktra="DT_SOTHE_THAYTHE" kt_xoa="X" runat="server" ten="Nhân viên thay thế" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div style="display: none;">
                            <Cthuvien:ma ID="namtru" runat="server" Width="50px" CssClass="form-control css_ma" kt_xoa="X" kieu_so="true" onchange="ns_cc_thongtin_nghi_P_KTRA('NAMTRU')" MaxLength="4" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Công sáng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sang" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Công chiều</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="chieu" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" onchange="ns_cc_thongtin_nghi_P_KTRA('NGAYD')" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC" ten="Đến ngày" runat="server" CssClass="form-control icon_lich" kieu_luu="S" onchange="ns_cc_thongtin_nghi_P_KTRA('NGAYC')" kt_xoa="X" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="gio_bd" runat="server" Width="240px" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" tra="CN,2HD,NC" ten="Loại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="gio_kt" runat="server" Width="240px" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" tra="CN,2HD,NC" ten="Loại" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phép còn</span>
                            <div class="input-group">
                                <Cthuvien:so ID="phepcon" Enabled="false" runat="server" CssClass="form-control css_ma_r" MaxLength="2" kt_xoa="X" so_tp="2" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số ngày nghỉ</span>
                            <div class="input-group">
                                <Cthuvien:so ID="ngaynghi" Enabled="false" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma_r"
                                    kt_xoa="X" so_tp="2" ten="Ngày nghỉ" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Lý do nghỉ</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Nhập" OnClick="return ns_cc_thongtin_nghi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="80px" class="bt_action" anh="K" Text="Mới" OnClick="return ns_cc_thongtin_nghi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_cc_thongtin_nghi_P_XOA();form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" Text="Hủy đơn" OnClick="return ns_cc_thongtin_nghi_P_Update();form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" class="bt_action" anh="K" Text="File mẫu" OnClick="return ns_cc_thongtin_nghi_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap4" runat="server" class="bt_action" anh="K" Text="Import excel" OnClick="return ns_cc_thongtin_nghi_FILE_Import();form_P_LOI('');" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                            <Cthuvien:ma ID="ghichu" ten="Nội dung nghỉ phép" runat="server" kieu_unicode="true" CssClass="form-control css_ma" Width="367px" kt_xoa="X" />
                            <Cthuvien:so ID="danghi" runat="server" Enabled="false" Width="50px" CssClass="form-control css_ma" MaxLength="4" kt_xoa="X" so_tp="2" disable="true" />
                            <Cthuvien:kieu ID="truphepnam" runat="server" lke="X," ToolTip="X - trừ vào phép năm, - không trừ phép năm" Width="30px" CssClass="form-control css_ma" />
                            <Cthuvien:so ID="truphep" runat="server" Width="50px" CssClass="form-control css_ma" kt_xoa="X" onchange="ns_cc_thongtin_nghi_P_KTRA('TRUPHEP')" so_tp="2" />
                            <Cthuvien:kieu ID="nghibu" runat="server" lke="X," ToolTip="X - trừ vào phép năm, - không trừ phép năm" Width="30px" CssClass="form-control css_ma" />
                            <Cthuvien:so ID="ngaybu" runat="server" Width="50px" CssClass="form-control css_ma" kt_xoa="X" so_tp="2" />
                            <Cthuvien:ma ID="huydon" ten="Trạng thái hủy đơn" runat="server" kieu_so="true"
                                CssClass="form-control css_ma" Width="100" Text="0" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
    <Cthuvien:an ID="aphong" runat="server" Value="TATCA" />
    <Cthuvien:an ID="akyluong" runat="server" Value="" />
</asp:Content>
