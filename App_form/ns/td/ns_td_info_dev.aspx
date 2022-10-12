<%@ Page Title="ns_td_info_dev" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_info_dev.aspx.cs" Inherits="f_ns_td_info_dev" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thông tin Phòng ban - Ứng viên" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <%--grid loại tìm kiếm--%>
                <div class="b_left col_30 inner" id="UPa_tk">
                    <%--select phòng ban--%>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Đơn vị/ Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ten="Đơn vị/ Phòng ban" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" onclick="ns_phong_P_LIST('PHONG_TK')" ktra="DT_PHONG_TK" />
                        </div>
                    </div>
                    <%--select chức danh--%>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="cdanh_tk" ktra="DT_CDANH_TK" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Chức danh" />
                        </div>
                    </div>
                    <%--button tìm kiếm--%>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_td_info_dev_P_LKE('K'); form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <%--grid hiển thị kết quả tìm kiếm--%>
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="16" Width="100%" cotAn="so_id,phong,cdanh" hamRow="ns_td_info_dev_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Phòng" DataField="ten_phong" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" />
                                    <asp:BoundField HeaderText="Lương" DataField="luong" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" />
                                    <asp:BoundField HeaderText="Số ID" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <%--scroll and pagging--%>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_info_dev_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <%--grid loại chi tiết--%>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <%--select phòng--%>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_30">Phòng ban: <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Phòng" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lương: </span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Lương" ToolTip="Lương" kieu_so="true" />
                            </div>
                        </div>

                    </div>
                    <%--input lương--%>
                    <div class="col_2_iterm width_common">
                        <%--select chức danh--%>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh: </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh" ktra="DT_CDANH" runat="server" CssClass="form-control css_list" onchange="ns_td_info_dev_P_KTRA_CT('CDANH')" kt_xoa="X" ten="Chức danh" />
                            </div>
                        </div>
                        <%--select ngày--%>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực: </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" MaxLength="20" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <%--textbox ghi chú--%>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú: </span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" Multiline="true" Height="50px" runat="server" CssClass="form-control css_nd" kieu_unicode="true" MaxLength="300" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <%--grid hiển thị chi tiết--%>
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" hamUp="ns_td_dx_P_LAY_CANTUYEN"
                                CssClass="table gridX" loai="N" Width="100%" cotAn="cong_ty_ct,bophan_ct,ghichu_ct" cot="cong_ty_ct,phong_ct,bophan_ct,cdanh_ct,ngay_hl_ct,luong_ct,ghichu_ct" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Công ty">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cong_ty_ct" ktra="DT_CONGTY" onchange="ns_td_info_dev_P_KTRA_CT('DONVI_CT')" runat="server" CssClass="css_Glist" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng ban" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="PHONG_CT" ktra="DT_PHONG_CT" onchange="ns_td_info_dev_P_KTRA_CT('PHONG_CT')" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bộ phận" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="bophan_ct" ktra="DT_BOPHAN_CT" onchange="ns_td_info_dev_P_KTRA_CT('BAN_CT')" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh_ct" ktra="DT_CDANH_CT" onchange="ns_td_info_dev_P_KTRA_CT('CDANH_CT')" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hiệu lực" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_hl_ct" runat="server" CssClass="css_Gma_c" Width="80px" kt_xoa="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lương" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="luong_ct" runat="server" CssClass="css_Gma" HeaderStyle-Width="180px" ten="Lương" kt_xoa="X" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu_ct" runat="server" CssClass="css_Gma" HeaderStyle-Width="180px" ten="Ghi chú" kt_xoa="X" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_td_info_dev_P_MOI(); form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_td_info_dev_P_NH(); form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_td_info_dev_P_XOA(); form_P_LOI();" />
                    </div>
                </div>
            </div>
            <div id="UPa_gchu">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,700" />
    </div>
</asp:Content>
