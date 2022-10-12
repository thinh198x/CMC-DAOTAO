<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_drlist.aspx.cs" Inherits="f_daotao_drlist"
    Title="daotao_drlist" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:DR_List" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">DR list</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="laytext" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CT,KCT"
                                    lke="Đối tượng cư trú,Đối tượng không cư trú" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap1" runat="server" Width="120px" Text="Lấy text" OnClick="return daotao_drlist_laytext();" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">DR list</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="layvalue" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CT,KCT"
                                    lke="Đối tượng cư trú,Đối tượng không cư trú" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap2" runat="server" Width="120px" Text="Lấy value" OnClick="return daotao_drlist_layvalue();" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">DR list</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="datgiatri" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CT,KCT"
                                    lke="Đối tượng cư trú,Đối tượng không cư trú" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap3" runat="server" Width="120px" Text="Đặt giá trị" OnClick="return daotao_drlist_datgiatri();" />
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
