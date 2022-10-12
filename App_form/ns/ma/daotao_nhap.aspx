<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_nhap.aspx.cs" Inherits="f_daotao_nhap"
    Title="daotao_nhap" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:nhap" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Gọi đến JS(client)</span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="nhap1" runat="server" Width="120px" Text="Click" OnClick="return daotao_nhap();" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Gọi đến CS(server)</span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="nhap2" runat="server" Width="120px" Text="Click" OnServerClick="btnNhap_click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
