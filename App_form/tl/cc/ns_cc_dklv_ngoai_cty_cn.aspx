<%@ Page Title="ns_cc_dklv_ngoai_cty_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_dklv_ngoai_cty_cn.aspx.cs" Inherits="f_ns_cc_dklv_ngoai_cty_cn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">

        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đăng ký làm việc ngoài công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM_TK" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="ns_cc_dklv_ngoai_cty_cn_P_NAM('NAM');"
                                    runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_TK" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="ns_cc_dklv_ngoai_cty_cn_P_KTRA('KYLUONG_TK')" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tt_tk" ten="Trạng thái" runat="server" CssClass="form-control css_list" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" />
                            </div>
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="tt,so_id" hamRow="ns_cc_dklv_ngoai_cty_cn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng/Ban" DataField="ten_phong" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_dk" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Từ giờ" DataField="gio_bd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến giờ" DataField="gio_kt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_dklv_ngoai_cty_cn_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" placeholder="Nhấn (F1)" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số nhân viên" kt_xoa="K" kieu_chu="true" Enabled="false"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_cc_dklv_ngoai_cty_cn_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày đăng ký <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_DK" ten="Ngày đăng ký" runat="server" kt_xoa="x" CssClass="form-control icon_lich" kieu_luu="S" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời gian từ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_BD" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_cc_dklv_ngoai_cty_cn_P_KTRA('GIO_BD')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thời gian đến <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_KT" ten="Đến giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_cc_dklv_ngoai_cty_cn_P_KTRA('GIO_KT')" />
                            </div>
                        </div>
                    </div>

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="lydo" ten="Lý do" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="80px" class="bt_action" anh="K" Text="Mới" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_cc_dklv_ngoai_cty_cn_P_GUI();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />

    <Cthuvien:an ID="aSothe" runat="server" Value="" />
    <Cthuvien:an ID="aNam_tk" runat="server" Value="" />
    <Cthuvien:an ID="akyluong_tk" runat="server" Value="" />
    <Cthuvien:an ID="att_tk" runat="server" Value="" />
</asp:Content>
