<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_lhd.aspx.cs" Inherits="f_ns_ma_lhd"
    Title="ns_ma_lhd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục loại hợp đồng lao động" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="nsd,tt,ghichu,ma_sinh_shd,is_thue_pt,thue_pt,is_thue_lt,ten_in" hamRow="ns_ma_lhd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã loại hợp đồng" DataField="ma" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="120px" />
                                    <asp:BoundField HeaderText="Tên loại hợp đồng" ItemStyle-CssClass="css_Gnd" DataField="ten" />
                                    <asp:BoundField HeaderText="Thời hạn" ItemStyle-CssClass="css_Gma_c" DataField="thoihan" HeaderStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Khối" ItemStyle-CssClass="css_Gma_c" DataField="khoi" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="BHXH" ItemStyle-CssClass="css_Gma_c" DataField="is_bhxh" HeaderStyle-Width="40px" />
                                    <asp:BoundField HeaderText="BHYT" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gma_c" DataField="is_bhyt" HeaderStyle-Width="40px" />
                                    <asp:BoundField HeaderText="BHTN" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gma_c" DataField="is_bhtn" HeaderStyle-Width="40px" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="70px" />
                                    <asp:BoundField DataField="nsd" />
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="ten_in" />
                                    <asp:BoundField DataField="MA_SINH_SHD" />
                                    <asp:BoundField DataField="is_thue_pt" />
                                    <asp:BoundField DataField="thue_pt" />
                                    <asp:BoundField DataField="is_thue_lt" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" gridId="GR_lke" ham="ns_ma_lhd_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ma_nuoc_P_IN();form_P_LOI();" Width="100px" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã loại hợp đồng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã loại hợp đồng"
                                kt_xoa="G" onchange="ns_ma_lhd_P_KTRA('MA')" MaxLength="20" />
                            <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Tên hợp đồng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="tên hợp đồng" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Tên in hợp đồng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN_IN" runat="server" ten="tên in hợp đồng" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Thời hạn hợp đồng (tháng)<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="THOIHAN" runat="server" CssClass="form-control css_so" ten="thời hạn hợp đồng" kt_xoa="X" kieu_so="true"
                                MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã tự sinh số HĐ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA_SINH_SHD" runat="server" ten="Mã tự sinh số HĐ" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Khối</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="khoi" ktra="DT_KHOI" runat="server" CssClass="form-control css_list"
                                kt_xoa="X" ten="Khối">
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">BHXH</span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="is_bhxh" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" MaxLength="1" kt_xoa="X" />
                            <span class="standard_label lv2 b_left col_15">BHXH</span>
                            <Cthuvien:kieu ID="is_bhyt" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" MaxLength="1" kt_xoa="X" />
                            <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Width="40px">BHTN</asp:Label>
                            <Cthuvien:kieu ID="is_bhtn" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" MaxLength="1" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Ghi chú" runat="server" Height="50px" TextMode="MultiLine" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" MaxLength="2000" />
                        </div>
                    </div>
                    <div style="display: none">
                        <span id="lbltile"></span>
                        <Cthuvien:kieu ID="is_thue_lt" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c" Text="" MaxLength="1" kt_xoa="X" onchange="return ns_ms_lhd_P_KTRA_THUE('IS_THUE_LT')" />
                        <Cthuvien:kieu ID="is_thue_pt" runat="server" lke=",X" Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c"
                            Text="" MaxLength="1" kt_xoa="X" onchange="return ns_ms_lhd_P_KTRA_THUE('IS_THUE_PT')" />
                        <Cthuvien:so ID="thue_pt" runat="server" CssClass="css_form_r" kt_xoa="X" so_tp="2" Width="128px" MaxLength="20" co_dau="K" />
                        <Cthuvien:so ID="Ma1" runat="server" CssClass="css_form_r" kt_xoa="X" so_tp="2" kieu_so="true" Width="31px" MaxLength="20" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_ma_lhd_P_NH();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_lhd_P_MOI();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_lhd_P_XOA();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="mauin" runat="server" Text="Tải mẫu in" class="bt_action" anh="K" OnClick="return ns_ma_lhd_FI_NH();form_P_LOI();" Width="120px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="80px" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1248,560" />
</asp:Content>
