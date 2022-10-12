<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kh_tso.aspx.cs" Inherits="f_kh_tso"
    Title="kh_tso" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="hr_kh_tso" runat="server" Text="Thiết lập tham số hệ thống" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tương tác tác màn hình</span>
                            <div class="input-group">
                                <%--<Cthuvien:DR_list ID="modal" CssClass="form-control css_list" ten="Tương tác tác màn hình" runat="server" kieu="S" Width="200px" tra=",T,C,K" lke="Tạo popup,Tạo cửa sổ mới,Tương tác một màn hình,Tương tác nhiều màn hình" />--%>
                                <Cthuvien:DR_list ID="modal" CssClass="form-control css_list" ten="Tương tác tác màn hình" runat="server" kieu="S" Width="200px" tra="C,T" lke="Tạo popup,Tạo cửa sổ mới" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label b_left col_30">Thao tác một màn hình</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="modal2" runat="server" CssClass="form-control css_ma_c" Width="30px" lke="C,K" Text="K" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngôn ngữ</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="nuoc" CssClass="form-control css_list" dich="K" ten="Tương tác tác màn hình" runat="server" kieu="S" Width="200px" tra="VIE,ENG,KOR,JAN,FRE" lke="Tiếng Việt,English,한국어,日本人,Français" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số ký tự bắt đầu tìm gợi ý</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="list_dai" runat="server" CssClass="form-control css_ma_r" Width="50px" Text="2" kieu_so="true" MaxLength="1" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số dòng gợi ý</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="list_kt" runat="server" CssClass="form-control css_ma_r" Width="50px" Text="6" kieu_so="true" MaxLength="2" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label b_left col_30">Số Mobile</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="mobi" runat="server" CssClass="form-control css_ma" Width="143px" ToolTip="Số Mobil nhận tin nhắn xác thực quyền truy cập" />
                                <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="(Ví dụ:0904044848)" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Thời gian</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phut" runat="server" CssClass="form-control css_ma_r" Width="50px" Text="10" kieu_so="true"
                                    ToolTip="Khoảng thời gian login kế tiếp sẽ phải kiểm tra qua Mobil" MaxLength="2" />
                                <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="(phút)" />
                            </div>
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return kh_tso_P_NH();form_P_LOI();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="600,360" />
    </div>
</asp:Content>
