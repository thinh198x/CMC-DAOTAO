<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_nhomluong.aspx.cs" Inherits="f_ns_ma_nhomluong"
    Title="ns_ma_nhomluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục ngạch lương" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,ma_tl,tt,note" hamRow="ns_ma_nhomluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_tl" />
                                    <asp:BoundField HeaderText="Bảng lương" DataField="ma_tl_ten" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã ngạch lương" DataField="ma" HeaderStyle-Width="110px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên ngạch lương" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tthai">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="note" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_ma_nhomluong_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Bảng lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_TL" ten="Thang lương" runat="server" CssClass="form-control css_list" ktra="DT_MA_TL" kt_xoa="G" f_tkhao="~/App_form/ns/hdns/tl/hd_ma_httluong.aspx" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã ngạch lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="true" ten="Mã ngạch lương"
                                kt_xoa="G" onchange="ns_ma_nhomluong_P_KTRA('MA');" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên ngạch lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên ngạch lương"
                                MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" TextMode="MultiLine" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X" Height="50px"
                                MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="day2" runat="server" CssClass="css_form" kieu_unicode="True" ten="Tên ngạch lương"
                            Width="54px"></Cthuvien:ma>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_nhomluong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_nhomluong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_nhomluong_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="990,540" />
    <Cthuvien:an ID="luu_day" runat="server" Value="" />
</asp:Content>
