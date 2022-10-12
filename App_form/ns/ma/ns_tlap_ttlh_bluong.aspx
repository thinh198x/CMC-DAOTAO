<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tlap_ttlh_bluong.aspx.cs" Inherits="f_ns_tlap_ttlh_bluong"
    Title="ns_tlap_ttlh_bluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập thông tin liên hệ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_10">Nội dung<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:nd ID="NOIDUNG" ten="Nội dung" runat="server" CssClass="form-control css_nd" kt_xoa="G" Width="100%" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Nhập" OnClick="return ns_tlap_ttlh_bluong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_tlap_ttlh_bluong_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,300" />
    </div>
</asp:Content>
