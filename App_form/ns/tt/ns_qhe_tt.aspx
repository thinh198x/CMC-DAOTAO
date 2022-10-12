<%@ Page Title="ns_qhe_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qhe_tt.aspx.cs" Inherits="f_ns_qhe_tt" EnableEventValidation="false" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quan hệ nhân thân" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="so_id,lqhe,tthai" hamRow="ns_qhe_tt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Họ tên nhân thân" DataField="TEN" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Quan hệ" DataField="ten_lqh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đối tượng giảm trừ" DataField="phuthuoc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="loại quan hệ" DataField="lqhe" />
                                    <asp:BoundField HeaderText="loại quan hệ" DataField="tthai" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_qhe_tt_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" anh="K" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_qhe_tt_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" disabled ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã cán bộ" kieu_chu="true" gchu="gchu" />
                                <Cthuvien:an ID="ASOTHE" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tencb" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên cán bộ" kieu_unicode="true" ReadOnly="true" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Họ tên nhân thân <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Họ tên" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mối quan hệ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LQHE" ktra="DT_LQHE" runat="server" kt_xoa="X" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Ngày sinh</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaysinh" runat="server" ten="Ngày sinh"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã số thuế NPT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="maso_thue" ten="Mã số thuế NPT" ToolTip="Mã số thuế NPT" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số CMTND/Thẻ CC</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_cmt" ten="Số CMTND/Thẻ CC" ToolTip="Số CMTND/Thẻ CC" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Ngày cấp</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_cmt" ten="Ngày cấp" ToolTip="Ngày cấp CMT" runat="server" kt_xoa="X" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left lv2 col_25">Nơi cấp</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dchi" ten="Nơi cấp" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sdt" ten="Số điện thoại" ToolTip="Số điện thoại" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nơi công tác</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noi_ctac" ten="Nơi công tác" ToolTip="Nơi công tác" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Địa chỉ thường trú</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="diachi_thuongchu" ten="Địa chỉ thường trú" runat="server" kt_xoa="X" CssClass="form-control css_nd" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Nghề nghiệp</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="n_ngh" ten="Nghề nghiệp" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin trên giấy khai sinh của người phụ thuộc (nếu không có MST,CMTND, Hộ chiếu)</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so" ten="Số" ToolTip="Số" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Quyển số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="quyenso" ten="Quyển số" ToolTip="Quyển số" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Quốc tịch</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nn" runat="server" ten="Quốc tịch" CssClass="form-control css_list" ktra="ns_ma_nuoc,ma,ten" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tỉnh/Thành phố</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="tinhthanh" ten="Tỉnh/Thành phố" CssClass="form-control css_list" runat="server" onchange="ns_qhe_tt_P_KTRA_DR('tinhthanh')" 
                                    ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" kt_xoa="X"/>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Quận/Huyện</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="quanhuyen" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" onchange="ns_qhe_tt_P_KTRA_DR('quanhuyen')" ToolTip="Quận huyện" kt_xoa="X"/>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Xã/Phường</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phuongxa" ten="Xã/Phường" CssClass="form-control css_list" runat="server" onchange="ns_qhe_tt_P_KTRA_DR('phuongxa')" ToolTip="Xã phường" kt_xoa="X"/>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Đối tượng giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="phuthuoc" runat="server" Text="X" lke="X," ToolTip="X - Giảm trừ,  - Không giảm trừ" Width="30px" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Ngày bắt đầu giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày bắt đầu giảm trừ" ToolTip="Ngày bắt đầu giảm trừ" runat="server" kt_xoa="X"
                                    CssClass="form-control icon_lich" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Ngày kết thúc giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" ten="Ngày kết thúc giảm trừ" ToolTip="Ngày kết thúc giảm trừ"
                                    runat="server" kt_xoa="X" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                kieu_unicode="true" Height="50px" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Hộ khẩu</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_hokhau" runat="server" lke=",X" Width="30px" ToolTip="X - Có đính kèm hộ khẩu,  - Không đính kèm hộ khẩu" CssClass="form-control css_ma_c" Text="" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Biểu mẫu D02K</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_d02k" runat="server" lke=",X" Width="30px" ToolTip="X - Có đính kèm biểu mẫu D02K,  - Không đính kèm biểu mẫu D02K" CssClass="form-control css_ma_c" Text="" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Giấy khai sinh</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_giay_ks" runat="server" lke=",X" Width="30px" ToolTip="X - Có đính kèm giấy khai sinh,  - Không đính kèm giấy khai sinh" CssClass="form-control css_ma_c" Text="" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">CMND</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_cmnd" runat="server" lke=",X" Width="30px" ToolTip="X - Có đính kèm CMND,  - Không đính kèm CMND" CssClass="form-control css_ma_c" Text="" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Xác nhận địa phương</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_xn_diaphuong" runat="server" lke=",X" Width="30px"
                                    ToolTip="X - Có đính kèm giấy xác nhận của địa phương,  - Không đính kèm giấy xác nhận của địa phương" CssClass="form-control css_ma_c" Text="" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>


                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_qhe_tt_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Text="Ghi" Width="90px" OnClick="return ns_qhe_tt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="130px" Text="Gửi phê duyệt" OnClick="return ns_qhe_tt_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="File" class="bt_action" anh="K" runat="server" Text="File" Width="60px" OnClick="return nhap_file();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Text="Xóa" Width="90px" OnClick="return ns_qhe_tt_P_XOA();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_qhe_tt_P_MAU();form_P_LOI();" />
                            <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_qhe_tt_FILE_IMPORT();form_P_LOI();" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                            <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
</asp:Content>
