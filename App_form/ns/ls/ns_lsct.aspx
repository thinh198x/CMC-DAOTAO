<%@ Page Title="ns_lsct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_lsct.aspx.cs" Inherits="f_ns_lsct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình công tác trước khi vào công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="12" cotAn="dccty,sodt,lydo,so_id" hamRow="ns_lsct_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên công ty" DataField="tencty" HeaderStyle-Width="30%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mức lương" DataField="mucluong" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày vào" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày nghỉ việc" DataField="ngayc" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="dccty" />
                                    <asp:BoundField DataField="sodt" />
                                    <asp:BoundField DataField="lydo" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_lsct_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        <Cthuvien:nhap ID="excel_all" class="bt_action" runat="server" Text="Xuất excel All" OnServerClick="XuatExcel_Click_All" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã số CB</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten"
                                    placeholder="Nhấn (F1)" ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                    onchange="ns_lsct_P_KTRA('SO_THE')" gchu="gchu" kt_xoa="K" />
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
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Địa chỉ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dccty" ten="Địa chỉ công ty" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Địa chỉ công ty"
                                    kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày vào</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày nghỉ</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
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
                                <Cthuvien:so ID="mucluong" ten="Mức lương" ToolTip="Mức lương tại công ty cũ" runat="server" CssClass="form-control css_so" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Lý do nghỉ việc</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="lydo" runat="server" CssClass="form-control css_nd" kt_xoa="X" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" anh="K" class="bt_action" OnClick="return ns_lsct_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" anh="K" class="bt_action" OnClick="return ns_lsct_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" anh="K" class="bt_action" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" anh="K" class="bt_action" OnClick="return ns_lsct_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="gui" runat="server" Width="100px" Text="Gửi" OnClick="return ns_lsct_P_GUI();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,600" />
    </div>
</asp:Content>
