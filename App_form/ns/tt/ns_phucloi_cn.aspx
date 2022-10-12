<%@ Page Title="ns_phucloi_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_phucloi_cn.aspx.cs" Inherits="f_ns_phucloi_cn" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phúc lợi cá nhân" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="dr_phongban" ktra="NS_PHUCLOI_CN_DVI" CssClass="form-control css_list" runat="server" onchange="ns_phucloi_cn_P_KTRA('dr_phongban')"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" kieu_chu="true" gchu="gchu" ten="Số thẻ cán bộ" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Họ tên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="hoten_tk" runat="server" CssClass="form-control css_ma" kieu_chu="true" gchu="gchu" ten="Họ tên cán bộ" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_phucloi_cn_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="10" Width="100%" cotAn="so_id" hamRow="ns_phucloi_cn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên phúc lợi" DataField="TEN_PL" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày thanh toán" DataField="ngay_tt" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div>
                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_phucloi_cn_P_LKE();" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="L"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" kieu_chu="true" placeholder="Nhấn (F1)"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_phucloi_cn_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên cán bộ" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Vị trí chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh" ToolTip="Vị trí chức danh" kt_xoa="L" Enabled="false" runat="server" ReadOnly="true"
                                    CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Công ty/Bộ phận</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong" ToolTip="Công ty/Bộ phận" kt_xoa="L" CssClass="form-control css_ma" runat="server" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên phúc lợi <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LOAI_PL" ktra="NS_PHUCLOI_CN_PL" ten="Tên phúc lợi" CssClass="form-control css_list" runat="server" kt_xoa="X"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tiền <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="SOTIEN" kt_xoa="X" ToolTip="Số tiền" ten="Số tiền" runat="server"
                                    CssClass="form-control css_so" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày thanh toán</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tt" kt_xoa="X" ToolTip="Ngày thanh toán" ten="Ngày thanh toán" runat="server"
                                    CssClass="form-control css_ngay" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="luong_chiuthue" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma_c" Text="" onchange="ns_phucloi_cn_P_KTRA('LUONG_CHIUTHUE');" />
                            <asp:Label ID="lbLuong_chiuthue" runat="server" Text="Tính vào lương (Chịu thuế)" CssClass="css_gchu" Style="float: left; padding-top: 5px;"></asp:Label>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="luong_khongchiuthue" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="form-control css_ma_c" Text="" onchange="ns_phucloi_cn_P_KTRA('LUONG_KHONGCHIUTHUE');" Style="float: left;" />
                            <asp:Label ID="lblLuong_khongchiuthue" runat="server" Text="Tính vào lương (Không chịu thuế)" CssClass="css_gchu" Style="float: left; padding-top: 5px;"></asp:Label>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">
                                <asp:Label ID="lblNam" runat="server" Text="Năm" CssClass="css_gchu"></asp:Label>
                            </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nam" ten="Năm" runat="server" CssClass="form-control css_ma_r" MaxLength="5" kt_xoa="X"
                                    kieu_so="true" onchange="ns_phucloi_cn_P_KTRA('NAM');" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">
                                <asp:Label ID="lblKyLuong" runat="server" Text="Kỳ lương" CssClass="css_gchu_c"></asp:Label>
                            </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kyluong" runat="server" CssClass="form-control css_list" ktra="DT_KYLUONG" kt_xoa="X">
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" ToolTip="Ghi chú" kt_xoa="X" runat="server" kieu="U" Width="100%" Height="50px"
                                CssClass="form-control css_ma" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_phucloi_cn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_phucloi_cn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_phucloi_cn_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ma_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,670" />
    </div>
</asp:Content>
