<%@ Page Title="ns_td_kh_dieuchuyenbonhiem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kh_dieuchuyenbonhiem.aspx.cs" Inherits="f_ns_td_kh_dieuchuyenbonhiem" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
    <%--    <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>--%>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kế hoạch điều chuyển bổ nhiệm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_so="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Công ty</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="donvi_tk" ktra="DT_CONGTY" runat="server" CssClass="form-control css_list" onchange="ns_td_dchuyen_bnhiem_P_KTRA('DONVI_TK')" kt_xoa="X" ten="Công ty" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Đơn vị/ Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ban_tk" ten="Đơn vị/ Phòng ban" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" onchange="ns_td_dchuyen_bnhiem_P_KTRA('BAN_TK')" ktra="DT_BAN" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="cdanh_tk" ktra="DT_CDANH" runat="server" onchange="ns_td_dchuyen_bnhiem_P_KTRA('CDANH_TK');" CssClass="form-control css_list" kt_xoa="X" ten="Chức danh" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label b_left col_30">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_PHONG_TK" onchange="ns_td_dchuyen_bnhiem_P_KTRA('PHONG_TK')" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_td_kh_nam_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="16" Width="100%" cotAn="so_id" hamRow="ns_td_kh_dieuchuyenbonhiem_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Công ty" DataField="donvi" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Khối" DataField="ban" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phong" />
                                    <asp:BoundField HeaderText="Bộ phận" DataField="bophan" />
                                    <asp:BoundField HeaderText="Tổ nhóm" DataField="tonhom" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_kh_dieuchuyenbonhiem_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nam_ct" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Công ty <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="donvi_ct" ktra="DT_DONVI" runat="server" CssClass="form-control css_list" onchange="ns_td_dchuyen_bnhiem_P_KTRA_CT('DONVI_CT')" kt_xoa="X" ten="Công ty" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Khối </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ban_ct" ktra="DT_BAN" runat="server" CssClass="form-control css_list" onchange="ns_td_dchuyen_bnhiem_P_KTRA_CT('BAN_CT')" kt_xoa="X" ten="Ban/Bộ phận" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng/ Đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_ct" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" onchange="ns_td_dchuyen_bnhiem_P_KTRA_CT('PHONG_CT')" kt_xoa="X" ten="Phòng/Bộ phận" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Bộ phận </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="bophan_ct" ten="Bộ phận" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" ktra="ns_bophan_P_LIST()" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tổ nhóm </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="tonhom_ct" ten="Tổ nhóm" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" ktra="DT_TONHOM" onchange="ns_td_kh_nam_P_BY_PHONG()" />
                            </div>
                        </div>

                    </div>

                    <div class="grid_table mgt10 width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" hamUp="ns_td_dx_P_LAY_CANTUYEN"
                                CssClass="table gridX" loai="N" Width="100%" cot="ma_kh,ban,phong" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng giảm do điều chuyển bổ nhiệm" ItemStyle-Wrap="true">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng tăng do điều chuyển bổ nhiệm" ItemStyle-Wrap="true">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_td_kh_dieuchuyenbonhiem_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_td_kh_dieuchuyenbonhiem_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_td_kh_nam_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="XuatFileMau" runat="server" class="bt_action" anh="K" Width="80px" CssClass="css_button" Text="File mẫu" OnServerClick="XuatFileMau_Click" />
                        <Cthuvien:nhap ID="NhapFileMau" runat="server" class="bt_action" anh="K" CssClass="css_button" Font-Bold="True" Width="100px" Text="Import" OnClick="return ns_td_kh_nam_Import();form_P_LOI();" />
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
