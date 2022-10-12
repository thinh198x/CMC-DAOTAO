<%@ Page Title="ns_ho_gdinh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ho_gdinh.aspx.cs" Inherits="f_ns_ho_gdinh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thông tin hộ gia đình" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="K" ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Họ tên" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Họ tên nhân viên" kt_xoa="K" ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên chủ hộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="CHUHO" ten="Họ tên chủ hộ" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" MaxLength="100" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Số điện thoại<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="PHONE" ten="Số điện thoại" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Số điện thoại" kt_xoa="X" MaxLength="255" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Số sổ hộ khẩu <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_HK" ten="Số sổ hộ khẩu" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" MaxLength="255" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã hộ gia đình<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_HO_GD" ten="Mã hộ gia đình" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Mã hộ gia đình" kt_xoa="X" kieu_unicode="true" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_10">Địa chỉ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DIACHI" ten="Địa chỉ" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Địa chỉ" kt_xoa="X" kieu_unicode="true" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tỉnh/Thành phố<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="TINHTHANH" ktra="ns_ma_tt,ma,ten" kt_xoa="X" 
                                    ten="Tỉnh/Thành phố" runat="server" CssClass="form-control css_list" onchange="ns_ho_gdinh_P_KTRA('TINHTHANH');"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Quận/Huyện<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="QUANHUYEN" kt_xoa="X" runat="server"
                                    ten="Quận/Huyện" CssClass="form-control css_list" onchange="ns_ho_gdinh_P_KTRA('QUANHUYEN');"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Xã/Phường<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="XAPHUONG" kt_xoa="X" runat="server" CssClass="form-control css_list" ten="Xã/Phường"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div class="css_divCn">
                            <Cthuvien:GridX ID="GR_qhe" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N" hangKt="15" ctrS="nhap"
                                cot="ten,bhxh,ngaysinh,gtinh,ncap_gks,qhe,cmt,mota" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Họ tên(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="100" ToolTip="Họ tên người quan hệ với chủ hộ" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã số BHXH" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="bhxh" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="10" ToolTip="Mã số BHXH của người quan hệ với chủ hộ (nếu có)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày sinh(*)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaysinh" runat="server" Width="100%" CssClass="css_Gma_c" kt_xoa="X" ten="Ngày sinh" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giới tính(*)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="gtinh" ktra="NS_HO_GDINH_GT" CssClass="css_Glist" runat="server" Width="100%"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nơi cấp giấy khai sinh(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ncap_gks" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="255" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mối quan hệ với chủ hộ(*)">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="qhe" ktra="NS_HO_GDINH_QHE" CssClass="css_Glist" runat="server" Width="100%"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số CMT/Thẻ căn cước/Hộ chiếu(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cmt" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="255" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="1000" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <khud:ctr_khud_divC ID="GR_lke_tn" runat="server" gridId="GR_qhe" />
                    </div>
                    <div class="btex_luoi b_right">
                        <ul>
                            <li>
                                <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_ho_gdinh_HangLen();" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_ho_gdinh_HangXuong();" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_ho_gdinh_CatDong();" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_ho_gdinh_ChenDong('C');" />
                            </li>
                        </ul>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ho_gdinh_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ho_gdinh_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ho_gdinh_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
    </div>
</asp:Content>

