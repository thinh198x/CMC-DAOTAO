<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_ma_tusinh.aspx.cs" Inherits="f_ht_ma_tusinh"
    Title="ht_ma_tusinh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cấu hình mã tự sinh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="sothe" Width="250px" ten="Mã nhân viên"  onchange="ht_ma_tusinh_P_KTRA('SOTHE')" runat="server" CssClass="form-control css_list" lke="Tự sinh,Nhập tay,Tự sinh hoặc nhập tay" tra="TS,NT,TS_NT" />                             
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" id="trTuSinhSothe" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tiền tố</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tiento" runat="server" Text="CB" kieu_chu="true" ten="Tiền tố" MaxLength="2" Width="250px"></Cthuvien:ma>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_15">Độ dài</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DodaiSothe" runat="server" kieu_so="true" ten="Độ dài" MaxLength="1" Text="6" Width="250px"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTuSinhSothe2" style="display: none">
                        <span class="standard_label b_left col_15">Ví dụ</span>
                        <div class="input-group">
                            <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Font-Bold="true" Font-Italic="true" Text="CB0001" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Số hợp đồng</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="hopdong" Width="250px" Height="22px" ten="Số hợp đồng" onchange="ht_ma_tusinh_P_KTRA('HOPDONG')" runat="server" CssClass="form-control css_list" lke="Tự sinh,Nhập tay" tra="TS,NT" />                             
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTuSinhhopdong">
                        <span class="standard_label b_left col_15">Độ dài</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DodaiHD" runat="server" kieu_so="true" ten="Độ dài" MaxLength="1" Width="60px" Text="4"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTuSinhhopdong2">
                        <span class="standard_label b_left col_15">Ví dụ</span>
                        <div class="input-group">
                            <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Font-Bold="true" Font-Italic="true" Text="0001/Năm ký HĐ/Mã loại hợp đồng; ví dụ: 0001/2017/HĐLĐ" Width="400px" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Số quyết định</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="quyetdinh" Width="250px" Height="22px" ten="Số hợp đồng" onchange="ht_ma_tusinh_P_KTRA('QUYETDINH')" runat="server" CssClass="form-control css_list" lke="Tự sinh,Nhập tay" tra="TS,NT" />                            
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTuSinhquyetdinh">
                        <span class="standard_label b_left col_15">Độ dài</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DoDaiQD" runat="server" kieu_so="true" ten="Độ dài" MaxLength="1" Width="60px" Text="4"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTuSinhquyetdinh2">
                        <span class="standard_label b_left col_15">Ví dụ</span>
                        <div class="input-group">
                            <asp:Label ID="Label13" runat="server" CssClass="css_gchu" Font-Bold="true" Font-Italic="true" Text="0001/Năm bắt đầu/Mã loại quyết định; ví dụ: 0001/2017/DC" Width="400px" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ht_ma_tusinh_P_NH();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,450" />
    </div>
</asp:Content>
