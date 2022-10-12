<%@ Page Title="ns_qt_xin_nghiphep" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_xin_nghiphep.aspx.cs" Inherits="f_ns_qt_xin_nghiphep" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đăng ký nghỉ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" ten="Trạng thái" runat="server" CssClass="form-control css_list" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_qt_xin_nghiphep_P_LKE('K');form_P_LOI();" />

                            <div style="display: none;">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" Width="152px" CssClass="form-control css_ma" kieu_chu="true" />
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" Width="152px" CssClass="form-control css_ma" kieu_unicode="true" />
                                <Cthuvien:ngay ID="ngayd_tk" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="form-control css_ma_c" kieu_luu="S" Width="124px" onchange="ns_qt_xin_nghiphep_P_KTRA('NGAYD')" />
                                <Cthuvien:ngay ID="ngayc_tk" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="form-control css_ma_c" kieu_luu="S" Width="124px" onchange="ns_qt_xin_nghiphep_P_KTRA('NGAYC')" />

                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="macc_nghi,ten_cdanh,ten_phong,sang,chieu,noidung,so_id,tt"
                                hamRow="ns_qt_xin_nghiphep_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại hình nghỉ" DataField="ten_loai" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại hình nghỉ" DataField="macc_nghi" />
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" />
                                    <asp:BoundField HeaderText="Công sáng" DataField="sang" />
                                    <asp:BoundField HeaderText="Công chiều" DataField="chieu" />
                                    <asp:BoundField HeaderText="Nội dung" DataField="noidung" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="tt" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_qt_xin_nghiphep_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" Enabled="false" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    oolTip="Mã số nhân viên" kt_xoa="K" kieu_chu="true"
                                    gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại hình nghỉ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MACC_NGHI" ktra="DT_KIEUNGHI" kt_xoa="X" CssClass="form-control css_list" ten="Loại hình nghỉ" runat="server" onchange="ns_qt_xin_nghiphep_P_KTRA('MACC_NGHI');">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Nhân viên thay thế</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="sothe_thaythe" ktra="DT_SOTHE_THAYTHE" kt_xoa="X" runat="server" ten="Nhân viên thay thế" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <div style="display: none;">
                                <Cthuvien:ma ID="namtru" runat="server" Width="50px" CssClass="form-control css_ma_c" kt_xoa="X" kieu_so="true" onchange="ns_qt_xin_nghiphep_P_KTRA('NAMTRU')" MaxLength="4" />
                                <Cthuvien:DR_list ID="gio_bd" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CN,2HD,NC" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" kt_xoa="X" />
                                <Cthuvien:DR_list ID="gio_kt" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CN,2HD,NC" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" kt_xoa="X" />
                                <Cthuvien:ma ID="ghichu" ten="Nội dung nghỉ phép" runat="server" kieu_unicode="true" CssClass="form-control css_ma" Width="367px" kt_xoa="X" />
                                <Cthuvien:so ID="danghi" runat="server" Enabled="false" Width="50px" CssClass="form-control css_ma_c" kt_xoa="X" so_tp="2" disable="true" />
                                <Cthuvien:kieu ID="truphepnam" runat="server" lke="X," ToolTip="X - trừ vào phép năm, - không trừ phép năm" Width="30px" CssClass="form-control css_ma_c" />
                                <Cthuvien:so ID="truphep" runat="server" Width="50px" CssClass="form-control css_ma_c" kt_xoa="X" onchange="ns_qt_xin_nghiphep_P_KTRA('TRUPHEP')" so_tp="2" />
                                <Cthuvien:kieu ID="nghibu" runat="server" lke="X," ToolTip="X - trừ vào phép năm, - không trừ phép năm" Width="30px" CssClass="form-control css_ma_c" />
                                <Cthuvien:so ID="ngaybu" runat="server" Width="50px" CssClass="form-control css_ma_c" kt_xoa="X" so_tp="2" />
                                <Cthuvien:ma ID="huydon" ten="Trạng thái hủy đơn" runat="server" kieu_so="true"
                                    CssClass="form-control css_ma" Width="100" Text="0" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Công sáng</span>
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
                            <span class="standard_label b_left col_40">Từ ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYD" placeholder='dd/MM/yyyy' ten="Từ ngày" runat="server" kt_xoa="X" CssClass="form-control icon_lich css_ma" kieu_luu="S" onchange="ns_qt_xin_nghiphep_P_KTRA('NGAYD')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYC" placeholder='dd/MM/yyyy' ten="Đến ngày" runat="server" CssClass="form-control icon_lich css_ma" kieu_luu="S" onchange="ns_qt_xin_nghiphep_P_KTRA('NGAYC')" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phép còn</span>
                            <div class="input-group">
                                <Cthuvien:so ID="phepcon" Enabled="false" runat="server" CssClass="form-control css_so" kt_xoa="K" so_tp="2" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số ngày nghỉ</span>
                            <div class="input-group">
                                <Cthuvien:so ID="ngaynghi" Enabled="false" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" so_tp="2" ten="Ngày nghỉ" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do nghỉ</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập" OnClick="return ns_qt_xin_nghiphep_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="80px" Text="Mới" OnClick="return ns_qt_xin_nghiphep_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="80px" Text="Xóa" OnClick="return ns_qt_xin_nghiphep_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_qt_xin_nghiphep_P_GUI();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1350,640" />
</asp:Content>
