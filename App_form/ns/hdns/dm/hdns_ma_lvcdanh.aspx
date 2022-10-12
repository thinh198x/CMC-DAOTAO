<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hdns_ma_lvcdanh.aspx.cs" Inherits="f_hdns_ma_lvcdanh"
    Title="hdns_ma_lvcdanh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục cấp bậc" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                CssClass="talbe gridX" loai="X" Width="100%" hangKt="15" cotAn="nsd,tt,note" hamRow="hdns_ma_lvcdanh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã cấp bậc" DataField="ma" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên cấp bậc" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt_ten" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="note" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="hdns_ma_lvcdanh_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" OnClick="return hdns_ma_lvcdanh_P_IN();form_P_LOI();" Width="100px" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Mã cấp bậc<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" ten="Mã cấp bậc" 
                                kt_xoa="G" MaxLength="10" onchange="ns_hdns_ma_nnn_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Tên cấp bậc<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" MaxLength="255" kt_xoa="X" ten="Tên cấp bậc"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" ten="trạng thái" CssClass="form-control css_list" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Mô tả<span class="require"></span></span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" TextMode="MultiLine" CssClass="form-control css_ma" kt_xoa="X" Height="50px"
                                ten="Ghi chú" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return hdns_ma_lvcdanh_P_MOI();form_P_LOI('');" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return hdns_ma_lvcdanh_P_NH();form_P_LOI('');" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI('');" Width="70px" />
                        <Cthuvien:nhap ID="xao" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return hdns_ma_lvcdanh_P_XOA();form_P_LOI('');" Width="70px" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="960,520" />
</asp:Content>
