<%@ Page Title="ns_ls_qt_dt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_qt_dt.aspx.cs" Inherits="f_ns_ls_qt_dt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,lop,nd,ldt,dd_tc,diem,ghichu" hamRow="ns_ls_qt_dt_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Tên khóa học" DataField="ten_kdt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngay_d" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngay_c" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Trạng thái lớp học" DataField="ten_tt" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Tên đơn vị tổ chức" DataField="dvi_tc" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Kết quả thi" DataField="kq" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Chi phí" DataField="tien" ItemStyle-CssClass="css_Gma_r" />
                                <asp:BoundField DataField="ghichu" />
                                <asp:BoundField DataField="diem" />
                                <asp:BoundField DataField="dd_tc" />
                                <asp:BoundField DataField="ldt" />
                                <asp:BoundField DataField="nd" />
                                <asp:BoundField DataField="lop" />
                                <asp:BoundField DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ls_qt_dt_P_LKE()" />
                    <div>
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tên cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên cán bộ"
                                    kieu_unicode="true" ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_KDT" ten="Tên khóa đào tạo" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" MaxLength="100" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Lớp học</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lop" ten="Lớp học" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true"
                                    gchu="gchu" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nội dung đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="nd" runat="server" TextMode="MultiLine" CssClass="form-control css_ma" kt_xoa="X" Height="50px"
                                    MaxLength="1000"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày bắt đầu<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Ngày kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Loại đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ldt" runat="server" kt_xoa="K" lke="X," tra="X," Width="30px" ToolTip="X - Đào tạo trong công ty"
                                    CssClass="form-control css_ma_c" MaxLength="1" ReadOnly="true" Enabled="false" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái lớp học</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tt" runat="server" lke="Hoàn thành,Đang thi,Đã thi,Chưa hoàn thành" tra="H,T,D,C"
                                    ten="Trạng thái lớp học" CssClass="form-control css_list" ToolTip="Trạng thái lớp học" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Đơn vị tổ chức</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dvi_tc" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ten="Đơn vị tổ chức" kieu_unicode="true" MaxLength="100" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Địa chỉ tổ chức</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dd_tc" ten="Địa điểm tổ chức" runat="server" CssClass="form-control css_ma" kieu_unicode="true"
                                    kieu_chu="true" gchu="gchu" ToolTip="Địa chỉ tổ chức" kt_xoa="X" MaxLength="255" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Điểm thi</span>
                            <div class="input-group">
                                <Cthuvien:so ID="diem" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Điểm thi" co_dau="K" MaxLength="20" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kết quả thi</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="kq" kieu="U" lke="Đạt,Không đạt" tra="D,K" runat="server" CssClass="form-control css_list"></Cthuvien:DR_list>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Chi phí</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tien" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Số tiền" co_dau="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="form-control css_ma" kt_xoa="X" Height="50px"
                                    MaxLength="1000"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" anh="K" class="bt_action" OnClick=" ns_ls_qt_dt_P_MOI();form_P_LOI('');" Title="Ấn nút để nhập mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" anh="K" class="bt_action" OnClick=" ns_ls_qt_dt_P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="mau_excel" runat="server" Text="File mẫu" anh="K" class="bt_action" OnServerClick="excel_mau_Click" />
                        <Cthuvien:nhap ID="import_excel" runat="server" Text="Import" anh="K" class="bt_action" OnClick="return ns_ls_qt_dt_FILE_Import();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" anh="K" class="bt_action" OnClick=" ns_ls_qt_dt_P_XOA();form_P_LOI('');" Title="Ấn nút để xóa" />
                        <Cthuvien:nhap ID="file" runat="server" Text="File" anh="K" class="bt_action" OnClick=" nhap_file();form_P_LOI('');" Title="Ấn nút để tải file" />
                    </div>
                </div>
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="so_the_an" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
    </div>
</asp:Content>
