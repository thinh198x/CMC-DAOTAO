<%@ Page Title="ns_cdanh_kn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cdanh_kn.aspx.cs" Inherits="f_ns_cdanh_kn" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chức danh kiêm nhiệm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_right form-group iterm_form" style="display: none;">
                        <span class="standard_label lv2 b_left col_30">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" CssClass="form-control css_list" runat="server" kieu="S" ktra="DT_PH" />
                        </div>

                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Họ và tên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_tk" ten="Tên tìm kiếm" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="100px" OnClick="ns_cdanh_kn_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="13" cotAn="so_id" hamRow="ns_cdanh_kn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Công ty" DataField="ten_cty" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ban/Phòng" DataField="ten_phong" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng/Bộ phận" DataField="ten_bophan" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cdanh_kn_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner">
                    <div id="UPa_ct">
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Mã nhân viên<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                        f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="G" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                        onchange="ns_cdanh_kn_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="HO_TEN" ten="Tên nhân viên" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                        ToolTip="Tên nhân viên" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Công ty<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_cty" ten="Công ty" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                        ToolTip="Công ty" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ban/Phòng</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_phong" ten="Ban/Phòng" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                        ToolTip="Ban/Phòng" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Phòng/Bộ phận<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_bophan" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                        ToolTip="Phòng/bộ phận" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Chức danh</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                        ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" kieu_unicode="true" />
                                </div>
                            </div>
                        </div>
                        <div style="display: none">
                            <Cthuvien:ma ID="cty" ten="công ty" runat="server" CssClass="css_form" kt_xoa="X" />
                            <Cthuvien:ma ID="phong" ten="phòng" runat="server" CssClass="css_form" kt_xoa="X" />
                            <Cthuvien:ma ID="bophan" ten="bộ phận" runat="server" CssClass="css_form" kt_xoa="X" />
                            <Cthuvien:ma ID="cdanh" ten="chức danh" runat="server" CssClass="css_form" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="grid_table width_common lv2" id="UPa_gr">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" Width="100%" cot="cty,phong,bophan,cdanh,ngay_hl,ngay_het_hl,phucap_kn,ghichu,so_the_den" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Công ty" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cty" ktra="DT_CTY" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng ban" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="phong" ktra="ns_phong_P_LIST()" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bộ phận" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="bophan" ktra="ns_bophan_P_LIST()" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh kiêm nhiệm" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh" ktra="ns_cdanh_P_LIST()" runat="server" CssClass="css_Glist" Width="130px" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hiệu lực" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_hl" runat="server" CssClass="css_Gma_c" Width="80px" kt_xoa="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hết hiệu lực" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_het_hl" runat="server" CssClass="css_Gma_c" Width="80px" kt_xoa="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phụ cấp kiêm nhiệm" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="phucap_kn" runat="server" HeaderStyle-Width="100px" CssClass="css_Gma" gchu="gchu" kt_xoa="X" ten="Phụ cấp kiêm nhiệm" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" CssClass="css_Gma" HeaderStyle-Width="180px" ten="Ghi chú" kt_xoa="X" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_the_den" />
                                </Columns>
                            </Cthuvien:GridX>

                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_cdanh_kn_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_cdanh_kn_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="moi" runat="server" Width="90px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_cdanh_kn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_cdanh_kn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_cdanh_kn_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,750" />
    </div>
</asp:Content>
