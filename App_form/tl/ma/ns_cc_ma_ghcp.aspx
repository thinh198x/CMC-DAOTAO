<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_ma_ghcp.aspx.cs" Inherits="f_ns_cc_ma_ghcp"
    Title="ns_cc_ma_ghcp" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập gia hạn cắt phép cho CBNV" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="G" onchange="ns_cc_ma_ghcp_P_KTRA('MA')" MaxLength="20" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_nv_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    MaxLength="255"></Cthuvien:ma>
                            </div>
                        </div> 
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_cc_ma_ghcp_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" cotAn="" hangKt="20" hamRow="ns_cc_ma_ghcp_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày gia hạn cắt phép" DataField="ngay_ghcp" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_ma_ghcp_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã nhân viên <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_form" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_cc_ma_ghcp_P_KTRA('SO_THE')" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên nhân viên <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" MaxLength="255"
                                ten="Tên" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Chức danh <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN_CDANH" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Tên" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Đơn vị <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_phong" Enabled="false" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Tên" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ngày gia hạn cắt phép</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ghcp" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="70px" Text="Nhập" OnClick="return ns_cc_ma_ghcp_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="70px" Text="Mới" OnClick="return ns_cc_ma_ghcp_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="70px" Text="Xóa" OnClick="return ns_cc_ma_ghcp_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="960,510" />
    </div>
</asp:Content>
