<%@ Page Title="ht_lichsu_dangnhap" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ht_lichsu_dangnhap.aspx.cs" Inherits="f_ht_lichsu_dangnhap" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Lịch sử đăng nhập" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Tài khoản</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_tk_tk" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
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
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ht_lichsu_dangnhap_P_LKE('K');form_P_LOI('');" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="ngay_thoat,gio_thoat">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tài khoản" DataField="ma_tk" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="180px" />
                                    <asp:BoundField HeaderText="Email" DataField="email" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Số điện thoại" DataField="dtdd" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="120px" />
                                    <asp:BoundField HeaderText="Ngày đăng nhập" DataField="ngay_dn" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Giờ đăng nhập" DataField="gio_dn" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Ngày thoát" DataField="ngay_thoat" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Giờ thoát" DataField="gio_thoat" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Tên máy thao tác" DataField="hostname" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                    <asp:BoundField HeaderText="Địa chỉ IP thao tác" DataField="ip" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_lichsu_dangnhap_P_LKE('K')" />
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
            <Cthuvien:an ID="ama_tk" runat="server" Value="" />
            <Cthuvien:an ID="atungay" runat="server" Value="" />
            <Cthuvien:an ID="adenngay" runat="server" Value="" />
            <Cthuvien:an ID="kthuoc" runat="server" Value="1390,780" />
        </div>
    </div>
</asp:Content>
