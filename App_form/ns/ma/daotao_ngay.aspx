<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_ngay.aspx.cs" Inherits="f_daotao_ngay"
    Title="daotao_ngay" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:ngay" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">kt_xoa="X"</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay2" runat="server" CssClass="form-control icon_lich" kieu_luu="S" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap1" runat="server" Width="120px" Text="Xóa vùng X" OnClick="return daotao_ngay_XOA_VUNG_X();" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_luu="S" trả giá trị format dd/MM/yyyy</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" CssClass="form-control icon_lich" kieu_luu="S" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_luu="I" trả giá trị format yyyMMdd</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay1" runat="server" CssClass="form-control icon_lich" kieu_luu="I" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_luu="D" trả giá trị format date theo định dạng của máy</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay3" runat="server" CssClass="form-control icon_lich" kieu_luu="I" kt_xoa="X" />
                        </div>
                    </div>
                    <span style="color: red;">NOTE: Kiểu dữ liệu trong bang thiết kế database phải là number</span>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
