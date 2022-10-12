<%@ Page Title="ns_qt_nghiviec" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_nghiviec.aspx.cs" Inherits="f_ns_qt_nghiviec" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khai báo nghỉ việc" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã Số CB</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" disabled="true"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_danhsach.aspx" onchange="ns_qt_nghiviec_P_KTRA('SO_THE')" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" ten="Tên cán bộ" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" disabled="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Tên chức danh" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" disabled="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Tên phòng" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" disabled="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày vào cty</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_vao" ten="Ngày vào" disabled="true" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Thâm niên</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tham_nien" runat="server" CssClass="form-control css_so" kt_xoa="X" so_tp="0" disabled="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại hợp đồng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="loai_hd" ten="Loại hợp đồng" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" disabled="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" ten="Ngày hiệu lực" disabled="true" runat="server" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_het_hl" ten="Ngày hết hiệu lực" disabled="true" runat="server" kt_xoa="G" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin nghỉ việc</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày nộp đơn</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_nop" ten="Ngày nộp đơn" runat="server" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày xin thôi việc</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_xin" ten="Ngày xin thôi việc" runat="server" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày nghỉ thực tế</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tt" ten="Ngày nghỉ thực tế" runat="server" CssClass="form-control icon_lich" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Lý do nghỉ việc</span></div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Lý do 1</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo1" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Lý do 2</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo2" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Lý do 3</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo3" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lý do 4</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo4" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Lý do 5</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo5" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Lý do khác</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="lydo_khac" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('LYDO_KHAC')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chi tiết lý do</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lydo_chitiet" ten="Chi tiết lý do" disabled="true" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" />
                            </div>
                        </div>

                    </div>
                    <div class="width_common pv_bl"><span>Đánh giá về công ty của CBNV trước khi nghỉ việc</span></div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Mức lương</span>

                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Không hài lòng</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ml_khl" onchange="ns_qt_nghiviec2_P_KTRA('ML_KHL')" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ml_hl" onchange="ns_qt_nghiviec2_P_KTRA('ML_HL')" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Rất hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ml_rhl" onchange="ns_qt_nghiviec2_P_KTRA('ML_RHL')" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Quản lý</span>

                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Không hài lòng</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ql_khl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('QL_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ql_hl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('QL_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Rất hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ql_rhl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('QL_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Môi trường</span>

                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Không hài lòng</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="mt_khl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('MT_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="mt_hl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('MT_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Rất hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="mt_rhl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('MT_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Cơ hội thăng tiến</span>

                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Không hài lòng</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ch_khl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('CH_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ch_hl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('CH_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Rất hài lòng	</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ch_rhl" runat="server" onchange="ns_qt_nghiviec2_P_KTRA('CH_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Góp ý cá nhân với CT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="gopy" ten="Góp ý cá nhân với CT" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" Width="100%"
                            AutoGenerateColumns="false" hangKt="5" cot="ten_tailieu,ng_nhan,ngay_bg,file_duongdan" PageSize="1" CssClass="table gridX">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Tên tài liệu" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="ten_tailieu" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                            kt_xoa="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Người nhận bàn giao" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="ng_nhan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                            kt_xoa="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày nhận" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bg" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                            Width="120px" kt_xoa="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đường dẫn file" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="file_duongdan" runat="server" kieu_unicode="true" CssClass="css_Gma"
                                            kt_xoa="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <div class="col_2_iterm mgt10 width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap Enabled="false" ID="tinhtrang" runat="server" Width="156px" CssClass="form-control css_ma">
                                    <asp:ListItem Value="0" Text="Chưa gửi" />
                                    <asp:ListItem Value="1" Text="Đã gửi" />
                                    <asp:ListItem Value="2" Text="Phê duyệt" />
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_qt_nghiviec_P_NH();form_P_LOI();" class="bt_action"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return ns_qt_nghiviec_P_MOI();form_P_LOI();"><span class="txUnderline">M</span>ới</button>
                        <button class="bt_action" onclick="return ns_qt_nghiviec_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</button>
                        <button class="bt_action" onclick="return ns_qt_nghiviec_gui();form_P_LOI();"><span class="txUnderline"></span>Gửi</button>

                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="960,800" />
</asp:Content>
