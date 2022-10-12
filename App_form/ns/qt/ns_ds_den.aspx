<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ds_den.aspx.cs" Inherits="f_ns_ds_den"
    Title="ns_ds_den" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách đen" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Số thẻ cán bộ" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_15">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hoten" runat="server" CssClass="form-control css_ma" kieu_unicode="true"
                                    gchu="gchu" ten="Họ tên cán bộ" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="dr_phongban" ktra="NS_DS_DEN_DVI" runat="server" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_ds_den_P_LKE('K');" Width="100px" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cdanh" HeaderText="Vị trí chức danh" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="phong" HeaderText="Đơn vị" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày vào" DataField="ngay_vao" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CMTND" DataField="CMTND" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày nộp" DataField="ngay_nop" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày nghỉ thực tế" DataField="ngaynghi" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lydo" HeaderText="Lý do" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ds_den_P_LKE('K');" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" anh="K" runat="server" Text="Xuất excel" onclick="ns_ds_den_P_Excel();return false;" />
                        <Cthuvien:nhap ID="excel_an" runat="server" Text="Xuất excel ẩn" OnServerClick="excel_Click" style="display: none;" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,620" />
        <Cthuvien:an ID="ma_phong" runat="server" />
    </div>
</asp:Content>
