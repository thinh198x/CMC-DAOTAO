<%@ Page Title="ns_lsct_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_lsct_tt.aspx.cs" Inherits="f_ns_lsct_tt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình công tác trước khi vào công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="17" cotAn="dccty,sodt,lydo,so_id,tthai" hamRow="ns_lsct_tt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên công ty" DataField="tencty" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mức lương" DataField="mucluong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày vào" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày nghỉ việc" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="dccty" />
                                    <asp:BoundField DataField="sodt" />
                                    <asp:BoundField DataField="lydo" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="so_id" DataField="tthai" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_lsct_tt_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" anh="K" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_lsct_tt_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã số CB <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" disabled runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                    ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_lsct_tt_P_KTRA('SO_THE')" gchu="gchu" kt_xoa="K" />
                                <Cthuvien:an ID="so_the_an" runat="server" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên cán bộ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên cán bộ" kieu_unicode="true" ReadOnly="true" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tên công ty</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tencty" ten="Tên công ty" runat="server" CssClass="form-control css_ma" ToolTip="tên công ty" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Số điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sodt" ten="Số điện thoại" runat="server" CssClass="form-control css_ma" ToolTip="Số điện thoại" kt_xoa="X" />

                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dccty" ten="Địa chỉ công ty" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Địa chỉ công ty" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày vào</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày vào" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="I" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày nghỉ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" ten="ngày nghỉ" ToolTip="Ngày nghỉ" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="I" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" CssClass="form-control css_ma" ToolTip="Chức danh" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mức lương</span>
                            <div class="input-group">
                                <Cthuvien:so ID="mucluong" ten="Mức lương" ToolTip="Mức lương tại công ty cũ" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Lý do nghỉ việc</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="lydo" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_lsct_tt_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Text="Ghi" Width="90px" OnClick="return ns_lsct_tt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_lsct_tt_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Text="Xóa" Width="90px" OnClick="return ns_lsct_tt_P_XOA();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,600" />
</asp:Content>
