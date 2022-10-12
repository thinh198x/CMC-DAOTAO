<%@ Page Title="ns_qt_dky_ncn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_dky_ncn.aspx.cs" Inherits="f_ns_qt_dky_ncn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đăng ký ca nuôi con nhỏ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" CssClass="form-control css_list"
                                    tra="DT_NAM_TK" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kỳ công lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_luong_tk" ten="Trạng thái" runat="server" CssClass="form-control css_list"
                                    tra="DT_KY_LUONG" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" class="bt_action" anh="K" Text="Tìm kiếm"
                                OnClick="return ns_qt_dky_ncn_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,noidung"
                                hamRow="ns_qt_dky_ncn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="sott" HeaderText=" Số thứ tự" />
                                    <asp:BoundField DataField="so_id" HeaderText="Số ID" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" />
                                    <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_dky" />
                                    <asp:BoundField HeaderText="Nội dung" DataField="noidung" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trang_thai" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_qt_dky_ncn_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <Cthuvien:ma ID="so_id" ten="Số ID" Enabled="false" runat="server" CssClass="" kt_xoa="X" />
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
                            <span class="standard_label b_left col_40">Ngày bắt đầu </span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYD" placeholder='dd/MM/yyyy' ten="Từ ngày" runat="server" kt_xoa="X" CssClass="form-control icon_lich css_ma" kieu_luu="S" onchange="ns_qt_dky_ncn_P_KTRA('NGAYD')" />
                            </div>
                        </div>
                         <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày Kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYC" placeholder='dd/MM/yyyy' ten="Từ ngày" runat="server" kt_xoa="X" CssClass="form-control icon_lich css_ma" kieu_luu="S" onchange="ns_qt_dky_ncn_P_KTRA('NGAYD')" />
                            </div>
                        </div>
                    </div>
                     <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ca <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="Ca" ten="Ca" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_qt_dky_ncn_P_KTRA('GIOD')" />
                            </div>
                        </div>
                         </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOD" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_qt_dky_ncn_P_KTRA('GIOD')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOC" ten="Đến giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_qt_dky_ncn_P_KTRA('GIOC')" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do nghỉ</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" kt_xoa="X" Rows="3" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập"
                            OnClick="return ns_qt_dky_ncn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="80px" Text="Mới"
                            OnClick="return ns_qt_dky_ncn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="80px" Text="Xóa"
                            OnClick="return ns_qt_dky_ncn_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt"
                            OnClick="return ns_qt_dky_ncn_P_GUI();form_P_LOI();" />
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
