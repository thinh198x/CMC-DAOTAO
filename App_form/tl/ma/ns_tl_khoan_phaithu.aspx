<%@ Page Title="ns_tl_khoan_phaithu" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_khoan_phaithu.aspx.cs" Inherits="f_ns_tl_khoan_phaithu" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập khoản phải thu" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" kt_xoa="M" onchange="ns_tl_khoan_phaithu_P_NAM('NAM_TK');" CssClass="form-control css_list" ktra="DT_NAM_TK" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kyluong_tk" ten="Kỳ lương" kt_xoa="N" runat="server" CssClass="form-control css_list" ktra="DT_KYLUONG_TK" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" kieu_unicode="true" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_tl_khoan_phaithu_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_tl_khoan_phaithu_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ lương" DataField="ten_kyluong_id" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số tiền thu" DataField="sotien_thu" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Số tiền trả" DataField="sotien_tra" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_tl_khoan_phaithu_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã số CB <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_form" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                    ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_tl_khoan_phaithu_P_KTRA('SO_THE')" kt_xoa="G" />
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_form" ToolTip="Họ tên cán bộ"
                                    kieu_unicode="true" BackColor="#f6f7f7" Enabled="false" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" CssClass="form-control css_form" ToolTip="Chức danh"
                                    BackColor="#f6f7f7" Enabled="false" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Phòng" runat="server" CssClass="form-control css_form" ToolTip="Phòng ban"
                                    BackColor="#f6f7f7" Enabled="false" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="phong" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="css_form"
                            ToolTip="Phòng" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                        <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="css_form"
                            ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" kt_xoa="G" onchange="ns_tl_khoan_phaithu_P_NAM('NAM');" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_ID" ten="Kỳ lương" kt_xoa="G" runat="server" CssClass="form-control css_list" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số tiền phải thu</span>
                            <div class="input-group">
                                <Cthuvien:so ID="sotien_thu" runat="server" ten="Số tiền phải thu" CssClass="form-control css_so" kt_xoa="X" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tiền phải trả </span>
                            <div class="input-group">
                                <Cthuvien:so ID="sotien_tra" runat="server" ten="Số tiền phải trả" CssClass="form-control css_so" kt_xoa="X" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Ngày tạo</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaytao" ten="Ngày tạo" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ToolTip="Ngày tạo" onchange="ns_tl_khoan_phaithu_P_NGAYTAO();" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Nội dung phải thu</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="noidung_thu" runat="server" TextMode="MultiLine" CssClass="form-control css_form" kt_xoa="X" Width="100%" Height="50px"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                     <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Nội dung phải trả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="noidung_tra" runat="server" TextMode="MultiLine" CssClass="form-control css_form" kt_xoa="X" Width="100%" Height="50px"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" anh="K" class="bt_action" Text="Làm mới" OnClick="return ns_tl_khoan_phaithu_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" anh="K" class="bt_action" Text="Lưu" OnClick="return ns_tl_khoan_phaithu_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" anh="K" class="bt_action" Text="Xóa" OnClick="return ns_tl_khoan_phaithu_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" class="bt_action" anh="K" Text="File mẫu" OnClick="return ns_tl_khoan_phaithu_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap4" runat="server" class="bt_action" anh="K" Text="Import excel" OnClick="return ns_tl_khoan_phaithu_FILE_Import();form_P_LOI('');" />
                    </div>
                    <div style="display: none;">
                         <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,620" />
    </div>
</asp:Content>
