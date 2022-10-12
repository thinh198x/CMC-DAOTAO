﻿<%@ Page Title="ns_td_kh_dchuyen_bnhiem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kh_dchuyen_bnhiem.aspx.cs" Inherits="f_ns_td_kh_dchuyen_bnhiem" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kế hoạch điều chuyển bổ nhiệm" />
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
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="donvi_tk" ten="Phòng" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_DONVI_TK" onchange="ns_td_kh_dchuyen_bnhiem_P_KTRA('DONVI_TK')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="cdanh_tk" ten="CHức danh" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_CDANH" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_td_kh_dchuyen_bnhiem_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="16" Width="100%" cotAn="donvi,so_id" hamRow="ns_td_kh_dchuyen_bnhiem_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phongban_ct" HeaderStyle-Width="400px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Công ty" DataField="donvi" />
                                    <asp:BoundField HeaderText="Công ty" DataField="ten_donvi" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ds_den_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="DONVI" ten="Đơn vị" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" ktra="DT_DONVI" onchange="ns_td_kh_dchuyen_bnhiem_P_KTRA('DONVI')" />
                            </div>
                        </div>
                    </div>

                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Đơn vị/ bộ phận<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="phongban_ct" runat="server" CssClass="form-control" Enabled="false" BackColor="#f6f7f7" kt_xoa="X" ten="Đơn vị/ bộ phận" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" hamUp="ns_td_dx_P_LAY_CANTUYEN"
                                CssClass="table gridX" loai="N" Width="100%" cot="ma_kh,cdanh,giam_t1,giam_t2,giam_t3,giam_t4,giam_t5,giam_t6,giam_t7,giam_t8,giam_t9,giam_t10,giam_t11,giam_t12,tang_t1,tang_t2,tang_t3,tang_t4,tang_t5,tang_t6,tang_t7,tang_t8,tang_t9,tang_t10,tang_t11,tang_t12,ghichu" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã kế hoạch (Tự sinh)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_kh" runat="server" CssClass="css_Gma" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" ItemStyle-Wrap="true" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh" Wrap="true" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Giảm T1" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t1" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T2" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t2" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T3" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t3" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T4" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t4" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T5" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t5" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T6" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t6" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T7" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t7" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T8" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t8" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T9" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t9" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T10" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t10" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T11" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t11" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giảm T12" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="giam_t12" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Tăng T1" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t1" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T2" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t2" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T3" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t3" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T4" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t4" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T5" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t5" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T6" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t6" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T7" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t7" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T8" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t8" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T9" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t9" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T10" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t10" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T11" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t11" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tăng T12" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tang_t12" runat="server" CssClass="css_Gma_r" gchu="gchu" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" CssClass="css_Gma" ten="Ghi chú" kieu_unicode="true" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_td_kh_dchuyen_bnhiem_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_td_kh_dchuyen_bnhiem_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_td_kh_dchuyen_bnhiem_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="XuatFileMau" runat="server" class="bt_action" anh="K" Width="80px" CssClass="css_button" Text="File mẫu" OnServerClick="XuatFileMau_Click" />
                        <Cthuvien:nhap ID="NhapFileMau" runat="server" class="bt_action" anh="K" CssClass="css_button" Font-Bold="True" Width="100px" Text="Import" OnClick="return ns_td_kh_dchuyen_bnhiem_Import();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,700" />
    </div>
</asp:Content>


