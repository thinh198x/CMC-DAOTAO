<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_doipass.aspx.cs" Inherits="f_ht_doipass"
    Title="ht_doipass" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đổi mật khẩu" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Mật khẩu cũ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="pascu" runat="server" CssClass="form-control css_ma" kt_xoa="X" TextMode="Password" Width="250px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Mật khẩu mới</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="pasmoi" runat="server" CssClass="form-control css_ma" kt_xoa="X" TextMode="Password" Width="250px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Xác nhận mật khẩu mới</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="cfpas" runat="server" CssClass="form-control css_ma" kt_xoa="X" TextMode="Password" Width="250px" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ht_doipass_P_NH();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="500,290" />
</asp:Content>
