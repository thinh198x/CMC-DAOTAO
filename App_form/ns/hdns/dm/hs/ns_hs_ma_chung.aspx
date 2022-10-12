<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hs_ma_chung.aspx.cs" Inherits="f_ns_hs_ma_chung"
    Title="ns_hs_ma_chung" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục dùng chung hồ sơ nhân sự" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="25" cotAn="nsd,NHOM_MA,thamso1,thamso2,trangthai,mota" hamRow="ns_hs_ma_chung_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nhóm danh mục" DataField="ten_nhom" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã danh mục" DataField="ma" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên danh mục" DataField="ten" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai"  >
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nhom_ma" />
                                    <asp:BoundField DataField="thamso1" />
                                    <asp:BoundField DataField="thamso2" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="mota" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_hs_ma_chung_P_LKE()" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Nhóm danh mục<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NHOM_MA" ktra="DT_HS_MA_CHUNG_NHOM" ten="Nhóm danh mục" CssClass="form-control css_list" kt_xoa="G" runat="server" ></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mã danh mục<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã danh mục"
                                kt_xoa="G" onfocusout="ns_ma_pbo_P_KTRA('MA')" MaxLength="20"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tên danh mục<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="Tên danh mục" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tham số 1</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="thamso1" ten="Tham số 1" runat="server" CssClass="form-control css_ma" kt_xoa="X"  MaxLength="50" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tham số 2</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="thamso2" ten="Tham số 2" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="50" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="mota" runat="server" ten="Mô tả" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_hs_ma_chung_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_hs_ma_chung_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return ns_hs_ma_chung_P_XOA();form_P_LOI();" />
                    </div> 
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1080,510" />
</asp:Content>

