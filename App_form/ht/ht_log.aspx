<%@ Page Title="ht_log" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ht_log.aspx.cs" Inherits="f_ht_log" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý log thao tác" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Phân hệ</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phanhe_tk" ten="Phân hệ" runat="server" ktra="DT_PHANHE" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Nhóm chức năng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhom_chucnang_tk" ten="Kỳ đánh giá" runat="server" ktra="DT_NHOM_CN" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Tài khoản</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_tk_tk" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ và tên" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Màn hình thao tác</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="chucnang_tk" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ và tên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay_tk" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay_tk" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="form-group iterm_form" style="text-align: center; padding: 10px 0px 10px 0px">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ht_log_P_LKE('K');form_P_LOI('');" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="width: 1280px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tài khoản" DataField="ma_tk" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="180px" />
                                    <asp:BoundField HeaderText="Email" DataField="email" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Số điện thoại" DataField="dtdd" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="120px" />
                                    <asp:BoundField HeaderText="Phân hệ thao tác" DataField="phanhe" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Nhóm chức năng" DataField="nhom_chucnang" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Màn hình thao tác" DataField="chucnang" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                    <asp:BoundField HeaderText="Thao tác" DataField="thaotac" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Ngày thao tác" DataField="ngay_thaotac" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Giờ thao tác" DataField="gio_thaotac" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Tên máy thao tác" DataField="hostname" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                    <asp:BoundField HeaderText="Địa chỉ IP thao tác" DataField="ip" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_log_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" onclick="checkEmpty()" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="UPa_hi">
            <Cthuvien:an ID="aphanhe" runat="server" Value="" />
            <Cthuvien:an ID="anhom_cn" runat="server" Value="" />
            <Cthuvien:an ID="ama_tk" runat="server" Value="" />
            <Cthuvien:an ID="achucnang" runat="server" Value="" />
            <Cthuvien:an ID="atungay" runat="server" Value="" />
            <Cthuvien:an ID="adenngay" runat="server" Value="" />
            <Cthuvien:an ID="kthuoc" runat="server" Value="1390,780" />
        </div>
    </div>
</asp:Content>
