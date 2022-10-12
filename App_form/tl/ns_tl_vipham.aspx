<%@ Page Title="ns_tl_vipham" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_vipham.aspx.cs" Inherits="f_ns_tl_vipham" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
         <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc id="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xử lý vi phạm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM_TK" ten="Năm" ktra="DT_NAM_TK" kt_xoa="M" onchange="ns_tl_vipham_P_KTRA('NAM_TK');"
                                    runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_TK" ten="Kỳ lương" ktra="DT_KYLUONG_TK" kt_xoa="N"
                                    runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                         <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã nhân viên</span>
                           <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" onchange="ns_tl_vipham_P_KTRA('KYLUONG_TK');">                                                                                
                                </Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_tl_vipham_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id" hamRow="ns_tl_vipham_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tháng/năm" DataField="nam" HeaderStyle-Width="15%"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ lương chi trả" DataField="ten_kyluong" HeaderStyle-Width="35%"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="15%"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="25%"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số tiền bị trừ" DataField="tien" HeaderStyle-Width="20%"
                                        ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_vipham_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ToolTip="Mã số nhân viên" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" placeholder="Nhấn (F1)" kt_xoa="K"
                                    kieu_chu="true" onchange="ns_tl_vipham_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten" ten="Tên nhân viên" kieu_unicode="true" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma"
                                    Enabled="false" kt_xoa="X" gchu="gchu" MaxLength="250" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong" ten="Phòng ban" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" kieu_unicode="True" MaxLength="250" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh" ten="Chức danh" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" kieu_unicode="True" MaxLength="250" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại vi phạm</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_VP" runat="server" lke="Đi muộn,Về sớm,khác" CssClass="form-control css_list" tra="DM,VS,KH" ten="Loại vi phạm" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tổng số lần</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lan_vp" ten="Tổng số lần" runat="server" CssClass="form-control css_ma" kieu_so="true" kt_xoa="X" MaxLength="15"
                                    gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số tiền bị trừ</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tien" ten="Số tiền bị giảm trừ" so_tp="3" runat="server" CssClass="form-control css_so" kieu_so="true" kt_xoa="X"
                                    MaxLength="15" co_dau="k" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45">Có tinh vào lương</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="co_tinhluong" runat="server" lke="C," Width="30px" kt_xoa="X"
                                    ToolTip="C - Có tính vào lương,  - Không tính vào lương" CssClass="form-control css_ma" Text="C" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="ns_tl_vipham_P_NAM();" runat="server"
                                    CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kyluong" ten="Kỳ lương" ktra="DT_KYLUONG" kt_xoa="N" runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return ns_tl_vipham_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return ns_tl_vipham_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return ns_tl_vipham_P_XOA();form_P_LOI();" Width="70px" anh="K" />

                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="filemau" runat="server" Width="100px" Text="File mẫu" OnServerClick="nhap_Click" />
                        <Cthuvien:nhap ID="import" runat="server" Text="Import" onclick="return ns_tl_vipham_Import();form_P_LOI();" Width="120px" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,600" />
        <Cthuvien:an ID="aphong" runat="server" Value="" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
