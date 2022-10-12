<%@ Page Title="ns_dg_hopdong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_hopdong.aspx.cs" Inherits="f_ns_dg_hopdong" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá hợp đồng lao động" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" CssClass="form-control css_list"
                                    ktra="DT_PHONG" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action" style="display: none;">
                        <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_dg_hopdong_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="" hamRow="ns_dg_hopdong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại hợp đồng" DataField="ten_lhd" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kết quả hợp đồng" DataField="ketqua" HeaderStyle-Width="140px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngay_hl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngay_hhl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />

                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dg_hopdong_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dg_hopdong_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" placeholder="Nhấn (F1)" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số nhân viên" kt_xoa="X" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_dg_hopdong_P_KTRA('SO_THE')" gchu="gchu" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>

                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số ID bảng hợp đồng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_id" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>

                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã hợp đồng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lhd" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày nhập<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_NHAP" ten="ngày nhập" runat="server" kt_xoa="G"
                                    CssClass="form-control icon_lich" kieu_luu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại hợp đồng đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="loai_hd" ten="Loại hợp đồng đánh giá" CssClass="form-control" runat="server" kt_xoa="X" Enabled="false">  
                                </Cthuvien:ma>
                            </div>
                        </div>

                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" ten="Từ ngày" runat="server" kt_xoa="G" Enabled="false"
                                    CssClass="form-control icon_lich" kieu_luu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hhl" ten="Đến ngày" runat="server" CssClass="form-control icon_lich"
                                    Enabled="false" kieu_luu="S" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="gio_bd" runat="server" Width="240px" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" tra="CN,2HD,NC" ten="Loại" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="gio_kt" runat="server" Width="240px" lke="Cả ngày(ca),Nghỉ 2 giờ,Nửa ngày(ca)" tra="CN,2HD,NC" ten="Loại" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kết quả <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KETQUA" ktra="DT_KQ" ten="Loại hình nghỉ" CssClass="form-control css_list" kt_xoa="X"
                                    runat="server">  
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại hợp đồng tiếp theo
                                <span class="require">*</span>
                            </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="HD_TIEP" ktra="DT_HD" ten="Loại hợp đồng tiếp theo" CssClass="form-control css_list" kt_xoa="X" runat="server">  
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" kt_xoa="X" Rows="4" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi"
                            OnClick="return ns_dg_hopdong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="80px" class="bt_action" anh="K" Text="Mới"
                            OnClick="return ns_dg_hopdong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa"
                            OnClick="return ns_dg_hopdong_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" class="bt_action" anh="K" Text="File mẫu"
                            OnClick="return ns_dg_hopdong_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap4" runat="server" class="bt_action" anh="K" Text="Import excel"
                            OnClick="return ns_dg_hopdong_FILE_Import();form_P_LOI('');" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
    <Cthuvien:an ID="aphong" runat="server" Value="" />
    <Cthuvien:an ID="akyluong" runat="server" Value="" />
</asp:Content>
