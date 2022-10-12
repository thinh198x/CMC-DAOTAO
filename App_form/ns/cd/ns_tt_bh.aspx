<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tt_bh.aspx.cs" Inherits="f_ns_tt_bh"
    Title="ns_tt_bh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý thông tin bảo hiểm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã NV" runat="server" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Họ tên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left lv2 col_20"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="nghi_viec_tk" runat="server" lke=",X" Width="30px" ToolTip="  - Chưa nghỉ việc,X - Nghỉ việc" CssClass="form-control css_ma" Text="" />
                            <span class="standard_label b_left lv2 col_40">Nhân viên nghỉ việc</span>
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="120px" OnClick="ns_tt_bh_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" cotAn="sothe_yte,ten_noikham,noikham_chuabenh,nsd,so_id" hangKt="15" hamRow="ns_tt_bh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="60px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Lương đóng BH" DataField="luong_bh" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tt_bh_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                         <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" OnClick="return ns_tt_bh_P_EXCEL();form_P_LOI();" />
                       <%-- <Cthuvien:nhap ID="excel" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="export_excel" />--%>
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl lv2"><span>Thông tin nhân viên</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma"  kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên" kt_xoa="X"
                                    onchange="ns_tt_bh_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" Enabled="false" runat="server" kt_xoa="X" ReadOnly="true" CssClass="form-control css_ma" kieu_chu="true"
                                    kieu_unicode="true" BackColor="#f3f3f3" ten="Tên nhân viên" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CDANH" Enabled="false" runat="server" kt_xoa="X" ReadOnly="true" CssClass="form-control css_ma" kieu_chu="true"
                                    kieu_unicode="true" BackColor="#f3f3f3" ten="Chức danh" />
                                <Cthuvien:an ID="CDANH" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng ban </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_PHONG" Enabled="false" runat="server" ReadOnly="true" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="tên phòng" BackColor="#f3f3f3" ten="Phòng" />
                                <Cthuvien:an ID="PHONG" runat="server" Value="" />
                            </div>
                        </div>
                    </div>

                    <div class="width_common pv_bl lv2"><span>Thông tin bảo hiểm</span></div>
                    <%--<div class="width_common pv_bl"><span></span></div>--%>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương bảo hiểm</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong_bh" BackColor="#f3f3f3" runat="server" kt_xoa="X" CssClass="form-control css_so"
                                    ToolTip="Lương bảo hiểm" co_dau="K" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">TG đóng BH trước khi vào cty</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tg_dongbh_truoc" runat="server" kt_xoa="X" CssClass="form-control css_so" kieu_so="true"
                                    kieu_unicode="true" co_dau="K" ten="TG đóng BH trước khi vào cty" />
                                <span>(Tháng)</span>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="tuthang_bhxh" runat="server" ten="Từ tháng" kt_xoa="X" CssClass="form-control icon_lich"
                                    ToolTip="Từ tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="denthang_bhxh" runat="server" kt_xoa="X" ten="Đến tháng" CssClass="form-control icon_lich"
                                    ToolTip="Đến tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số sổ BHXH</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="soso_bhxh" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="Số sổ" ten="Số sổ" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã sổ BHXH</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="maso_bhxh" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="Mã sổ BHXH" ten="Mã sổ BHXH" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tình trạng sổ </span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang_so" runat="server" CssClass="form-control css_list" lke=",Đã cấp sổ,Chưa cấp sổ,Người lao động giữ" tra=",DC,CC,LDG" ten="Tình trạng sổ bảo hiểm" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày cấp</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_cap" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Ngày cấp sổ" />
                            </div>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã số hộ gia đình</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="maso_hogiadinh" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="Mã sổ hộ gia đình" ten="Mã số hộ gia đình" />
                            </div>
                        </div>

                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Vùng sinh sống </span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="vung_sinhsong" runat="server" CssClass="form-control css_list" lke=",K1,K2,K3" tra=",K1,K2,K3" ten="khu vực sinh sống" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Vùng lương tối thiểu </span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="vung_luongtoithieu" runat="server" CssClass="form-control css_list" lke=",01-Vùng I, 02-Vùng II, 03-Vùng III, 04-Vùng IV" tra=",V1,V2,V3,V4" ten="khu vực sinh sống" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nơi làm việc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noilamviec" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_luu="S" ToolTip="Nơi làm việc" ten="Nơi làm việc" />
                            </div>
                        </div>
                    </div>

                    <div class="width_common pv_bl lv2"><span>Bảo hiểm y tế</span></div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="tuthang_bhyt" runat="server" kt_xoa="X" ten="Từ tháng" CssClass="form-control icon_lich"
                                    ToolTip="Từ tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="denthang_bhyt" runat="server" kt_xoa="X" ten="Đến tháng" CssClass="form-control icon_lich"
                                    ToolTip="Đến tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số thẻ y tế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sothe_yte" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tình trạng thẻ</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang_the" runat="server" CssClass="form-control css_list" lke=",Đang sử dụng,Khác" tra=",DSC,K" ten="Tình trạng thẻ" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Ngày hiệu lực" />
                            </div>
                        </div>
                     <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày bàn giao thẻ BHYT</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bangiaothe" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_date="true"
                                    ToolTip="Ngày bàn giao thẻ BHYT" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nơi khám chữa bệnh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noikham_chuabenh" runat="server" kt_xoa="G" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Mã bệnh viện" ToolTip="Bệnh viện" placeholder="Nhấn (F1)"
                                    ktra="ns_ma_bv,ma,ten" f_tkhao="~/App_form/ns/sk/ma/ns_ma_bv.aspx" onchange="ns_tt_bh_P_KTRA('MABV')" />
                            </div>
                        </div>
                    </div>
                  
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_tt_bh_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Mới" OnClick="return ns_tt_bh_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Xóa" OnClick="return ns_tt_bh_P_XOA();form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="xuatfilemau" runat="server" class="bt_action" anh="K" Width="120px" Text="File mẫu" OnServerClick="nhap_Click" />
                        <Cthuvien:nhap ID="nhapfile" runat="server" class="bt_action" anh="K" Text="Import" Width="140px" title="Nhập file mẫu" OnClick="return ns_tt_bh_Import();form_P_LOI();" />--%>
                    </div>
                     <div style="display: none">
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,800" />
        <Cthuvien:an ID="aphong" runat="server" />
    </div>
</asp:Content>
