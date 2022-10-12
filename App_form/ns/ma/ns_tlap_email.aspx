<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tlap_email.aspx.cs" Inherits="f_ns_tlap_email"
    Title="ns_tlap_email" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập email phê duyệt" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_30 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Email<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="EMAIL" ten="email" runat="server" CssClass="form-control css_ma" kt_xoa="G" Width="250px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mật khẩu<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MATKHAU" ten="Mật khẩu" runat="server" CssClass="form-control css_ma" kt_xoa="K" Width="250px" TextMode="Password" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">SMTP<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="SMTP" ten="SMTP" runat="server" CssClass="form-control css_ma" kt_xoa="G" Width="250px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Port<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="PORT" ten="Port" runat="server" CssClass="form-control css_ma" kt_xoa="G" Width="250px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">SSL<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="SSL" ten="SSL" runat="server" CssClass="form-control css_ma" Text="C" kt_xoa="G" Width="30px" lke="C,K"
                                ToolTip="C- Có, K - Không" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_tlap_email_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_tlap_email_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="test" runat="server" class="bt_action" anh="K" Text="Test mail" OnClick="return ns_tlap_email_P_TEST();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="550,325" />
    </div>
</asp:Content>
