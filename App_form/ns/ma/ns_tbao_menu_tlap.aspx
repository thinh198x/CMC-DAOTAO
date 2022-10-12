<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tbao_menu_tlap.aspx.cs" Inherits="f_ns_tbao_menu_tlap"
    Title="ns_tbao_menu_tlap" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập gợi nhắc" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Hết hạn hợp đồng trước: </span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_hhhd" runat="server" lke="X," Width="50px" kt_xoa="X" ToolTip="X - Áp dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="X" />
                                <Cthuvien:ma ID="tbao_hethopdong" ten="Hết hạn hợp đồng" runat="server" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" Width="200px" />
                                <span class="standard_label lv2 b_left col_10">Ngày</span>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Sinh nhật trước:</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_sn" runat="server" lke="X," Width="50px" kt_xoa="X" ToolTip="X - Áp dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="X" />
                                <Cthuvien:ma ID="sinhnhat" ten="Hết hạn sinh nhật" runat="server" Text="10" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" Width="200px" />
                                <span class="standard_label lv2 b_left col_10">Ngày</span>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Hết hạn hộ chiếu: </span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_hc" runat="server" lke="X," Width="50px" kt_xoa="X" ToolTip="X - Áp dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="X" />
                                <Cthuvien:ma ID="ho_chieu" ten="Hết hạn hộ chiếu" runat="server" Text="10" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" Width="200px" />
                                <span class="standard_label lv2 b_left col_10">Ngày</span>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Hết hạn quyết định: </span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_qd" runat="server" lke="X," Width="50px" kt_xoa="X" ToolTip="X - Áp dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="X" />
                                <Cthuvien:ma ID="quyetdinh" ten="Quyết định" runat="server" Text="10" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" Width="200px" />
                                <span class="standard_label lv2 b_left col_10">Ngày</span>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Hết hạn Nộp hồ sơ: </span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_nop_hs" runat="server" lke="X," Width="50px" kt_xoa="X" ToolTip="X - Áp dụng,  - Không áp dụng" CssClass="form-control css_ma" Text="X" />
                                <Cthuvien:ma ID="nop_hs" ten="Hết hạn Nộp hồ sơ" runat="server" Text="10" CssClass="form-control css_ma" kieu_so="true" kt_xoa="G" Width="200px" />
                                <span class="standard_label lv2 b_left col_10">Ngày</span>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Nhập" OnClick="return ns_tbao_menu_tlap_P_NH();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="500,470" />
    </div>
</asp:Content>
