<%@ Page Title="ns_qhe" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qhe.aspx.cs" Inherits="f_ns_qhe" EnableEventValidation="false" %>

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
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,lqhe" hamRow="ns_qhe_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Họ tên nhân thân" DataField="HO_TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Quan hệ" DataField="ten_lqh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đối tượng giảm trừ" DataField="phuthuoc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="loại quan hệ" DataField="lqhe" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_qhe_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnClick="return ns_qhe_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_fra">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã cán bộ" kieu_chu="true" placeholder="Nhấn (F1)"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_qhe_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tencb" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên cán bộ"
                                    kieu_unicode="true" ReadOnly="true" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Họ tên nhân thân <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Họ tên" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mối quan hệ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LQHE" ktra="DT_LQHE" runat="server" CssClass="form-control css_list" kt_xoa="X"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày sinh</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaysinh" runat="server" ten="Ngày sinh"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã số thuế NPT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="maso_thue" ten="Mã số thuế NPT" ToolTip="Mã số thuế NPT" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số CMTND/Thẻ CC</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_cmt" ten="Số CMTND/Thẻ CC" ToolTip="Số CMTND/Thẻ CC" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày cấp</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_cmt" runat="server" ten="Ngày cấp"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nơi cấp</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dchi" ten="Nơi cấp" runat="server" kt_xoa="X" CssClass="form-control css_nd" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sdt" ten="Số điện thoại" ToolTip="Số điện thoại" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nơi công tác</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noi_ctac" ten="Nơi công tác" ToolTip="Nơi công tác" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Địa chỉ thường trú</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="diachi_thuongchu" ten="Địa chỉ thường trú" runat="server" kt_xoa="X" CssClass="form-control css_nd" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nghề nghiệp</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="n_ngh" ten="Nghề nghiệp" runat="server" kt_xoa="X" CssClass="form-control css_nd" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>

                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_100"><b>Thông tin trên giấy khai sinh của người phụ thuộc (nếu không có MST,CMTND, Hộ chiếu)</b></span>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so" ten="Số" ToolTip="Số" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Quyển số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="quyenso" ten="Quyển số" ToolTip="Quyển số" runat="server" kt_xoa="X"
                                    CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Quốc tịch</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nn" runat="server" CssClass="form-control css_list" ten="Quốc tịch" ktra="ns_ma_nuoc,ma,ten" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỉnh/Thành phố</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="tinhthanh" ten="Tỉnh/Thành phố" runat="server" CssClass="form-control css_list"
                                    onchange="ns_qhe_P_KTRA_DR('tinhthanh')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Quận/Huyện</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="quanhuyen" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" onchange="ns_qhe_P_KTRA_DR('quanhuyen')" ToolTip="Quận huyện" Height="22px" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Xã/Phường</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phuongxa" ten="Xã/Phường" runat="server" CssClass="form-control css_list" onchange="ns_qhe_P_KTRA_DR('phuongxa')" ToolTip="Xã phường" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Đối tượng giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="phuthuoc" runat="server" Text="X" lke="X," ToolTip="X - Giảm trừ,  - Không giảm trừ" Width="30px" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày BD giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Ngày cấp"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày KT giảm trừ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày cấp"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="form-control css_nd" kieu_unicode="true" Height="50px" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" anh="K" class="bt_action" OnClick="return ns_qhe_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" anh="K" class="bt_action" OnClick="return ns_qhe_P_CHECK_NHANTHAN();form_P_LOI();" />
                        <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" anh="K" class="bt_action" OnClick="return ns_qhe_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" anh="K" class="bt_action" OnClick="return ns_qhe_FILE_IMPORT();form_P_LOI();" />
                        <Cthuvien:nhap ID="File" runat="server" Text="File" anh="K" class="bt_action" OnClick="return nhap_file();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" anh="K" class="bt_action" OnClick="return ns_qhe_P_XOA();form_P_LOI();" />

                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="xuatfilemau" runat="server" Width="100px" Text="File mẫu" OnServerClick="FileMau_Click" />
                        <%-- <Cthuvien:nhap ID="Nhap1" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_ma_cm_P_MAU();form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,800" />
        <Cthuvien:an ID="aho_ten" runat="server" />
    </div>
</asp:Content>
