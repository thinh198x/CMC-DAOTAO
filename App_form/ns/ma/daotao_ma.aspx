<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_ma.aspx.cs" Inherits="f_daotao_ma"
    Title="daotao_ma" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:ma" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">kt_xoa="X"</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="20"></Cthuvien:ma>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap1" runat="server" Width="120px" Text="Xóa vùng X" OnClick="return daotao_ma_XOA_VUNG_X();" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_chu="true"</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA3" runat="server" CssClass="form-control css_ma" kieu_chu="true" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_so="true"</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA1" runat="server" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">kieu_unicode="true" (trả về tiếng việt)</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA2" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>


                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nnn.aspx"</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NHOM_CDANH" f_tkhao="~/App_form/daotao-2022/TINTC/Bai2/Bai2_TINTC.aspx" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Nhóm chức danh" BackColor="#f6f7f7"
                                placeholder="Nhấn (F1)" Width="200px" />
                            <Cthuvien:ma ID="TEN_NHOM_CDANH" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>   

    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
