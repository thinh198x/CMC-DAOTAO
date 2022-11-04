<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bai4_TINTC.aspx.cs" Inherits="f_tin_bai4"
    Title="hieu_bai4" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="hieu bai 4" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã đơn vị<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma" ten="mã đơn vị" runat="server" CssClass="form-control css_ma" kieu_chu="True" Enabled="false"
                                kt_xoa="G" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thành lập<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tl" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày áp dụng</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ad" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Đến ngày" />
                            </div>
                        </div>
                    </div>

                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Chức danh<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NHOM_CDANH" f_tkhao="~/App_form/daotao-2022/TINTC/Bai2/Bai2_TINTC.aspx" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Nhóm chức danh" BackColor="#f6f7f7"
                                placeholder="Nhấn (F1)" Width="200px" />
                            <Cthuvien:ma ID="TEN_NHOM_CDANH" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                    </div>
                </div>

            </div>
        </div>
    </div>   

    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
