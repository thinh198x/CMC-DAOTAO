<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hd_ma_httluong.aspx.cs" Inherits="f_hd_ma_httluong"
    Title="hd_ma_httluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục bảng lương" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="ghichu" hamRow="hd_ma_httluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                        <HeaderStyle Width="10px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã bảng lương" DataField="ma" HeaderStyle-Width="110px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên bảng lương" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ng_hluc">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ghichu" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="hd_ma_httluong_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã bảng lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" kieu_chu="True" ten="Mã bảng lương"
                                kt_xoa="G" onchange="hd_ma_httluong_P_KTRA('MA')" CssClass="form-control css_ma" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên bảng lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" kieu_unicode="True" CssClass="form-control css_ma" kt_xoa="X" ten="Tên bảng lương" MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Ngày hiệu lực<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NG_HLUC" CssClass="form-control icon_lich"
                                ten="Ngày hiệu lực" runat="server" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" kieu_unicode="true" TextMode="MultiLine" CssClass="form-control css_ma" kt_xoa="X" Height="50px" TabIndex="5" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return hd_ma_httluong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return hd_ma_httluong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return hd_ma_httluong_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,550" />
</asp:Content>
