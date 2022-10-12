<%@ Page Title="ns_hdns_dbien" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_dbien.aspx.cs" Inherits="f_ns_hdns_dbien" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Định biên nhân sự" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" runat="server" CssClass="form-control css_so" kieu_so="true" kt_xoa="G" ten="Năm" ToolTip="Năm" MaxLength="4" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_15">Công ty</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="dvi_tk" ten="Phòng" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_DONVI_TK" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_hdns_dbien_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="donvi,so_id" hamUp="ns_hdns_dbien_ns_tinh" hamRow="ns_hdns_dbien_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phongban_ct" HeaderStyle-Width="400px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="donvi" DataField="donvi" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_dbien_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_hdns_dbien_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đơn vị<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="DONVI" ktra="DT_DONVI" runat="server" CssClass="form-control css_list" onchange="ns_hdns_dbien_P_KTRA_DR('DONVI')" kt_xoa="X" ten="Công ty"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Đơn vị/ bộ phận<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="phongban_ct" runat="server" CssClass="form-control" Enabled="false" BackColor="#f6f7f7" kt_xoa="X" ten="Đơn vị/ bộ phận" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ban/Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ban" ktra="DT_BAN" runat="server" CssClass="form-control css_list" onchange="ns_hdns_dbien_P_KTRA_DR('BAN')" kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Phòng/Bộ phận</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" onchange="ns_hdns_dbien_P_KTRA_DR('PHONG')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="height: 600px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" hamUp="hsns_dinhbien_ns_tinh" runat="server" AutoGenerateColumns="false" PageSize="1" loai="X"
                                CssClass="table gridX" hangKt="100" cotAn="cdanh,so_id" Width="100%"
                                cot="cdanh,ten_cdanh,ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12,SO_ID">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chức danh" ItemStyle-Wrap="true" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <%--<Cthuvien:DR_lke ID="cdanh" Wrap="true" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>--%>
                                            <Cthuvien:ma ID="cdanh" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" ItemStyle-Wrap="true" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <%--<Cthuvien:DR_lke ID="cdanh" Wrap="true" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>--%>
                                            <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_Gma" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhân sự hiện tại tính đến 31/12 năm trước" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ns_hientai" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right" style="display: none">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_hdns_dbien_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_hdns_dbien_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_hdns_dbien_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_hdns_dbien_ChenDong();" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="ns_hdns_dbien_P_NH();form_P_LOI('');" Title="Nhập" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="ns_hdns_dbien_P_MOI();form_P_LOI('');" Title="Mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_hdns_dbien_P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />

                        <a href="#" onclick="return ns_hdns_dbien_P_LSU()" class="bt bt-grey"><span>Lịch sử định biên</span></a>
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="filemau" runat="server" class="bt_action" anh="K" Text="File mẫu" OnServerClick="nhap_Click" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" class="bt_action" anh="K" Text="File mẫu" OnServerClick="excel_Click" />
                        <Cthuvien:nhap ID="nhapfile" runat="server" Text="Import" class="bt_action" anh="K" OnClick="return ns_hdns_dbien_Import();form_P_LOI();" />

                        <Cthuvien:nhap ID="file" runat="server" class="bt_action" anh="K" Text="File" OnClick="return ns_hdns_dbien_P_FI_NH();form_P_LOI();" Title="Lấy thông tin để chuyển sang form khác" />
                        <Cthuvien:nhap ID="getfile" runat="server" class="bt_action" Text="Lấy file" OnClick="return ns_hdns_dbien_P_FI_LAY();form_P_LOI();" />
                        <Cthuvien:nhap ID="filelay" runat="server" class="bt_action" anh="K" Text="Lấy file" OnClick="return ns_hdns_dbien_P_FI_LAY();form_P_LOI();" Title="Lấy thông tin để chuyển sang form khác" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="an_Nam" runat="server" Value="0" />
        <Cthuvien:an ID="an_phong" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,690" />
    </div>
</asp:Content>
