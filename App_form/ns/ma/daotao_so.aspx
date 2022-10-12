<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_so.aspx.cs" Inherits="f_daotao_so"
    Title="daotao_so" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:so" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">kt_xoa="X"</span>
                            <div class="input-group">
                                <Cthuvien:so ID="ma" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="20" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap1" runat="server" Width="120px" Text="Xóa vùng X" OnClick="return daotao_so_XOA_VUNG_X();" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">co_dau="C"(Nhập dấu âm)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="MA3" runat="server" CssClass="form-control css_ma" co_dau="C" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">co_dau="K"(không nhập dấu)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="MA1" runat="server" CssClass="form-control css_ma" co_dau="K" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">so_tp="2"(nhập được số thập phân)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="MA2" runat="server" CssClass="form-control css_ma" so_tp="2" kt_xoa="G" />
                        </div>
                    </div>


                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nnn.aspx"</span>
                        <div class="input-group">
                            <Cthuvien:so ID="NHOM_CDANH" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nnn.aspx" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Nhóm chức danh" BackColor="#f6f7f7"
                                placeholder="Nhấn (F1)" Width="200px" />
                            <Cthuvien:so ID="TEN_NHOM_CDANH" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
