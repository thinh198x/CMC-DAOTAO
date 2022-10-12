<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_nd.aspx.cs" Inherits="f_daotao_nd"
    Title="daotao_nd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:nd" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">

                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" CssClass="form-control css_nd" kt_xoa="X"
                                MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Ghi chú (Height="300px")</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="Nd1" Height="300px" runat="server" CssClass="form-control css_nd" kt_xoa="X"
                                MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
