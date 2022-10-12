<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_tile_bh.aspx.cs" Inherits="f_ns_ma_tile_bh"
    Title="ns_ma_tile_bh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quy định % đóng bảo hiểm" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,nsd" hamRow="ns_ma_tile_bh_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức trần BHXH" DataField="muctran_bhxh" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức trần BHYT" DataField="muctran_bhyt" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức trần BHTN" DataField="muctran_bhtn" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng BHXH" DataField="cty_bhxh" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng BHYT" DataField="cty_bhyt" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng BHTN" DataField="cty_bhtn" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng đoàn phí" DataField="cty_cdp" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng đảng phí" DataField="cty_dangphi" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% cty đóng BHTNNN" DataField="cty_bhtnnn" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng BHXH" DataField="nv_bhxh" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng BHYT" DataField="nv_bhyt" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng BHTN" DataField="nv_bhtn" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng đoàn phí" DataField="nv_cdp" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng đảng phí" DataField="nv_dangphi" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="% CBNV đóng BHTNNN" DataField="nv_bhtnnn" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hệ số hưởng ốm đau" DataField="heso_omdau" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hệ số hưởng thai sản" DataField="heso_thaisan" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nghỉ tập trung" DataField="nghi_taptrung" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nghỉ tại nhà" DataField="nghi_tainha" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tuổi nam nghỉ hưu" DataField="nghihuu_nam" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tuổi nữ nghỉ hưu" DataField="nghihuu_nu" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px"></asp:BoundField>
                                    <asp:BoundField DataField="trangthai"></asp:BoundField>
                                    <asp:BoundField DataField="nsd"></asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_ma_tile_bh_P_LKE()" />

                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" ten="ngày hiệu lực" runat="server" CssClass="form-control icon_lich" kieu_luu="S" onchange="ns_ma_tile_bh_P_KTRA('MA')"
                                    kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Mức trần đóng bảo hiểm</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">BHXH</span>
                            <div class="input-group">
                                <Cthuvien:so ID="muctran_bhxh" ten="Mức trần BHXH" kieu_so="true" ToolTip="Mức trần BHXH" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="10" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHYT </span>
                            <div class="input-group">
                                <Cthuvien:so ID="muctran_bhyt" ten="Mức trần BHYT" kieu_so="true" ToolTip="Mức trần BHYT" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="10" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHTN</span>
                            <div class="input-group">
                                <Cthuvien:so ID="muctran_bhtn" ten="Mức trần BHTN" kieu_so="true" ToolTip="Mức trần BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="10" co_dau="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Tỷ lệ công ty đóng cho nhân viên</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">BHXH <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="CTY_BHXH" ten="Tỷ lệ công ty đóng BHXH" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHXH" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('CTY_BHXH')" so_tp="1" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHYT <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="CTY_BHYT" ten="Tỷ lệ công ty đóng BHYT" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHYT" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('CTY_BHYT')" so_tp="1" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHTN <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cty_bhtn" ten="Tỷ lệ công ty đóng BHTN" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('CTY_BHTN')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phí công đoàn <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="CTY_CDP" ten="Phí công đoàn" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đảng phí<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="CTY_DANGPHI" ten="Đảng phí" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left col_40">BHTNNN<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="CTY_BHTNNN" ten="Bảo hiểm tai nạn nghề nghiệp" kieu_so="true" ToolTip="Bảo hiểm tai nạn nghề nghiệp" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>

                    </div>
                    <div class="width_common pv_bl"><span>Tỷ lệ CBNV đóng</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">BHXH <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NV_BHXH" ten="Tỷ lệ nhân viên đóng BHXH" kieu_so="true" ToolTip="Tỷ lệ nhân viên đóng BHXH" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NV_BHXH')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHYT <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NV_BHYT" ten="Tỷ lệ nhân viên đóng BHYT" kieu_so="true" ToolTip="Tỷ lệ nhân viên đóng BHYT" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NV_BHYT')" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">BHTN <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nv_bhtn" ten="Tỷ lệ nhân viên đóng BHTN" kieu_so="true" ToolTip="Tỷ lệ nhân viên đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NV_BHTN')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phí công đoàn <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NV_CDP" ten="Phí công đoàn" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đảng phí<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NV_DANGPHI" ten="Đảng phí" kieu_so="true" ToolTip="Tỷ lệ công ty đóng BHTN" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left col_40">BHTNNN<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NV_BHTNNN" ten="Bảo hiểm tai nạn nghề nghiệp" kieu_so="true" ToolTip="Bảo hiểm tai nạn nghề nghiệp" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Hệ số hưởng ốm đau, TS</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ốm đau <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="HESO_OMDAU" ten="Chế độ ốm đau" kieu_so="true" ToolTip="Chế độ ốm đau" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('HESO_OMDAU')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thai sản <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="HESO_THAISAN" ten="Chế độ thai sản" kieu_so="true" ToolTip="Chế độ thai sản" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('HESO_THAISAN')" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Hệ số hưởng chế độ DS, PHSK</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nghỉ tập trung <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NGHI_TAPTRUNG" ten="Nghỉ tập trung" kieu_so="true" ToolTip="Nghỉ tập trung" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NGHI_TAPTRUNG')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nghỉ tại nhà <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NGHI_TAINHA" ten="Nghỉ tại nhà" kieu_so="true" ToolTip="Nghỉ tại nhà" runat="server"
                                    CssClass="form-control css_" kt_xoa="X" MaxLength="5" so_tp="1" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NGHI_TAINHA')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Tuổi về hưu</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nam <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NGHIHUU_NAM" ten="Tuổi về hưu nam" kieu_so="true" ToolTip="Tuổi về hưu nam" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="4" so_tp="2" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NGHIHUU_NAM')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nữ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="NGHIHUU_NU" ten="Tuổi về hưu nữ" kieu_so="true" ToolTip="Tuổi về hưu nữ" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" MaxLength="4" so_tp="2" co_dau="K" onchange="ns_ma_tile_bh_P_KTRA('NGHIHUU_NU')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Lưu" class="bt_action" anh="K" OnClick="return ns_ma_tile_bh_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_tile_bh_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_tile_bh_P_XOA();form_P_LOI('');" Width="100px" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="1280,620" />
</asp:Content>
