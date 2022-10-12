<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_kieu.aspx.cs" Inherits="f_daotao_kieu"
    Title="daotao_kieu" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:kieu" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">lke="1,2,3,4,5"</span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="CAP" runat="server" CssClass="form-control css_ma_c" lke="1,2,3,4,5" Text="1" Width="30px" ToolTip="Cấp đơn vị từ 1 -> 5" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">lke="Gara,Bảo hiểm,Quản trị" tra="G,B,Q"</span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="VP" runat="server" CssClass="form-control css_ma_c" Width="101px" lke="Gara,Bảo hiểm,Quản trị" tra="G,B,Q"
                                ToolTip="Gara,Bảo hiểm,Quản trị" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Kiểu checkbox</span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="kieu1" runat="server" lke=",X" Width="30px" ToolTip="  - Chưa nghỉ việc,X - Nghỉ việc" CssClass="form-control css_ma_c" Text="" />
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
