<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_nha.aspx.cs" Inherits="f_ns_ma_nha"
    Title="ns_ma_nha" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục ngân hàng" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x:scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cot="ma,ten,tt" cotAn="" hamRow="ns_ma_nha_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã ngân hàng" DataField="ma" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên ngân hàng" DataField="ten" HeaderStyle-Width="270px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_nha_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ma_nha_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mã ngân hàng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Mã ngân hàng" ToolTip="Mã ngân hàng" MaxLength="20" Enabled="false" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tên ngân hàng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên chi nhánh ngân hàng" ToolTip="Tên chi nhánh ngân hàng" MaxLength="100" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="tt" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" runat="server" ten="Mô tả" kieu_unicode="true" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_nha_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_nha_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_nha_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,540" />
</asp:Content>
