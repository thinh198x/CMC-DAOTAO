<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_nnn.aspx.cs" Inherits="f_ns_hdns_ma_nnn"
    Title="ns_hdns_ma_nnn" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Nhóm chức danh" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="15" cotAn="tt,nsd" hamRow="ns_hdns_ma_nnn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderText="Mã nhóm chức danh" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên nhóm chức danh" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ten_tt" HeaderText="Trạng thái" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_hdns_ma_nnn_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" class="bt_action" Width="100px" OnClick="return ns_hdns_ma_nnn_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã Nhóm chức danh<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" ten="Mã Nhóm chức danh" BackColor="#f6f7f7"
                                    kt_xoa="G" MaxLength="10" onchange="ns_hdns_ma_nnn_P_KTRA('MA')" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên Nhóm chức danh<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên Nhóm chức danh"
                                    MaxLength="255"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Trạng thái<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TT" ten="Trạng thái" CssClass="form-control css_list" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="ghichu" CssClass="form-control css_ma" runat="server" TextMode="MultiLine" kt_xoa="X" Height="50px"
                                    MaxLength="1000" kieu_unicode="true"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" class="bt_action" anh="K" Width="90px" OnClick="return ns_hdns_ma_nnn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" class="bt_action" anh="K" OnClick="return ns_hdns_ma_nnn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" class="bt_action" anh="K" OnClick="return ns_hdns_ma_nnn_P_XOA();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_ma_nnn_P_MAU();form_P_LOI();" />
                            <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_ma_nnn_FILE_IMPORT();form_P_LOI();" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                            <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,550" />
</asp:Content>
