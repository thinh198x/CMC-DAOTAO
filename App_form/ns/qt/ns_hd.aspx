<%@ Page Title="ns_hd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hd.aspx.cs" Inherits="f_ns_hd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_content">
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý hợp đồng" />
                <asp:Label ID="tong_hd_cpd" runat="server" class="require" Text="(0)" ToolTip="Số hợp đồng đang chờ phê duyệt" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div id="UPa_tk" class="b_left col_40 inner">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Loại hợp đồng</span>
                        <div class="input-group">
                            <%--<Cthuvien:DR_lke ID="lhd_tk" ktra="DT_LHD_TK" kt_xoa="K" ten="Loại hợp đồng" runat="server" CssClass="form-control css_list"
                                ToolTip="Loại hợp đồng"></Cthuvien:DR_lke>--%>
                            <Cthuvien:DR_lke ID="lhd_tk" ktra="DT_LHD_TK" kt_xoa="K" ten="Loại hợp đồng" runat="server" CssClass="form-control css_list"
                                ToolTip="Loại hợp đồng"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="trangthai_tk" runat="server" kieu_chu="true" CssClass="form-control css_list" lke=",Chờ phê duyệt,Phê duyệt,Không phê duyệt"
                                tra=",CPD,PD,KPD" ten="Trạng thái"></Cthuvien:DR_list>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Đến ngày" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" kieu_unicode="true" kieu_chu="true" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" CssClass="form-control css_list" runat="server" onchange="ns_hd_P_KTRA('PHONG_TK')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nhân viên NV</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="nghi_viec_tk" runat="server" lke=",X" Width="30px" ToolTip="  - Chưa nghỉ việc,X - Nghỉ việc" CssClass="form-control css_ma_c" Text="" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_hd_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="20" cot="chon,so_the,ten,ten_cdanh,ten_phong,ten_lhd,ngayd,ngayc,ten_ttr,lhd,ngay_tl,so_hd,so_id,ttr" cotAn="lhd,so_hd,so_id,ttr,ngay_tl" hamRow="ns_hd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Vị trí chức danh" DataField="ten_cdanh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng/Bộ phận" DataField="ten_phong" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại hợp đồng" DataField="ten_lhd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngayc" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_ttr" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="lhd" DataField="lhd" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày thanh lý" DataField="ngay_tl" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số hợp đồng" DataField="so_hd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField DataField="ttr" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hd_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap2" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_hd_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin hợp đồng</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                    onchange="ns_hd_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" ten="Tên nhân viên" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Phòng/bộ phận" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Phòng" kt_xoa="X" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Chức danh" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="ten_vitri" runat="server" BackColor="#f6f7f7" kt_xoa="X" CssClass="form-control css_ma"
                            gchu="gchu" ten="vị trí CV" Enabled="false" ReadOnly="true" ToolTip="Vị trí công việc" />
                        <Cthuvien:ma ID="bac_cdanh" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                            f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" gchu="gchu" ten="Chức danh công việc" MaxLength="30"
                            Enabled="false" ReadOnly="false" kt_xoa="X" />
                        <Cthuvien:ma ID="vitri" runat="server" ten="Vị trí" CssClass="form-control css_ma" />
                        <Cthuvien:ma ID="CDANH" runat="server" ten="Chức danh" CssClass="form-control css_ma" />
                        <Cthuvien:ma ID="PHONG" runat="server" ten="Phòng ban" CssClass="form-control css_ma" />
                        <Cthuvien:so ID="heso_cd" runat="server" BackColor="#f6f7f7" kt_xoa="X" CssClass="form-control css_ma_r" so_tp="2"
                            gchu="gchu" ten="Hệ số" Enabled="false" ReadOnly="true" />
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại HĐ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LHD" ktra="DT_LHD" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Loại hợp đồng"
                                    onchange="ns_hd_P_NGAYKETTHUC()"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số HĐ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_HD" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_chu="true"
                                    kieu_unicode="true" ten="Số hợp đồng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" kieu_luu="S" CssClass="form-control css_ma_c"
                                    onchange="ns_hd_P_NGAYKETTHUC()" kt_xoa="X" ten="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" kieu_luu="S" CssClass="form-control css_ma_c"
                                    kt_xoa="X" ten="Đến ngày" />
                            </div>
                        </div>
                    </div>
                    <div id="an_luongcb_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TTR" runat="server" CssClass="form-control css_list" kieu_chu="true" lke="Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra="CPD,PD,KPD" ten="Trạng thái"></Cthuvien:DR_list>
                            </div>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh mới</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh_m" ktra="DT_CDANH" runat="server" CssClass="form-control css_list" kt_xoa="T"
                                    ten="Chức danh" ToolTip="Chức danh mới" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thời gian làm việc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tg_lv" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ten="Thời gian làm việc" ToolTip="Thời gian làm việc" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>


                    <div id="an_pt_huongluong_ht" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Người ký<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_NGUOIKY" runat="server" kt_xoa="X" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Người ký" placeholder="Nhấn (F1)"
                                    onchange="ns_hd_P_KTRA('MA_NGUOIKY')" ktra="ns_cb,so_the,ten" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh người ký<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh_nguoiky" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Chức danh người ký" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div id="an_thang_ngach_td" class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày ký <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_KY" runat="server" kt_xoa="X" CssClass="form-control css_ma_c"
                                    kieu_luu="S" ToolTip="Ngày ký hợp đồng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày thanh lý</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tl" runat="server" kt_xoa="X" CssClass="form-control css_ma_c"
                                    kieu_luu="S" ToolTip="Ngày thanh lý" ten="Ngày thanh lý" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20" id="lblNgachLuongMoi">Công việc phải làm</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                kieu_unicode="true" ToolTip="Công việc phải làm" TextMode="MultiLine" Height="50px" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin lương</span></div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nhập lương tại HĐ</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="hddau" runat="server" onchange="ns_hd_P_KTRA('HDDAU')" lke=",X" Width="30px" ToolTip="  - Chọn từ quyết định, X - Nhập lương tại hợp đồng" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" id="lblChonSqd">
                            <span class="standard_label lv2 b_left col_40">Chọn số QĐ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_qd" runat="server" ten="Số quyết định" CssClass="form-control css_ma" placeholder="Nhấn (F1)"
                                    BackColor="#f6f7f7" kieu_chu="true" guiId="so_the,ho_ten" f_tkhao="~/App_form/ns/qt/ns_hdct.aspx"
                                    kt_xoa="X" onchange="ns_hd_P_KTRA('SO_QD')" ToolTip="Số quyết định" ktra="ns_hdct,so_qd,so_id" />
                            </div>
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Bảng lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_tl" ktra="DT_MA_TL" ten="Bảng lương" kt_xoa="X" CssClass="form-control css_list" runat="server" onchange="ns_hd_P_KTRA('MA_TL')" ToolTip="Bảng lương" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngạch lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_nl" ktra="DT_MA_NL" ten="Ngạch lương" kt_xoa="X" CssClass="form-control css_list" runat="server" onchange="ns_hd_P_KTRA('MA_NL')" ToolTip="Ngạch lương" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Bậc lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_bl" ktra="DT_MA_BL" ten="Bậc lương" kt_xoa="X" CssClass="form-control css_list" runat="server" onchange="ns_hd_P_KTRA('MA_BL')" ToolTip="Bậc lương"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương cơ bản<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="luongcb" ten="Lương cơ bản" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" onchange="ns_hd_tinh_thuongkq();" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tổng lương mục tiêu<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong" runat="server" ten="Tổng thu nhập" kt_xoa="X" CssClass="form-control css_so"
                                    onchange="ns_hd_tinh_thuongkq();" co_dau="K" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương hiệu quả CV</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luonght" ten="Lương hiệu quả CV" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đơn giá</span>
                            <div class="input-group">
                                <Cthuvien:so ID="dongia" ten="Đơn giá" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" Enabled="false" ReadOnly="true" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">% hưởng lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="PHANTRAM_LUONG" runat="server" kt_xoa="K" kieu="U" Text="100" CssClass="form-control css_so"
                                    ten="% hưởng lương" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng theo phí giao dịch</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="tyle_hoahong_theophi" ktra="DT_CHIPHI" ten="Biểu mẫu phí giao dịch" kt_xoa="X" CssClass="form-control css_list"
                                    runat="server" ToolTip="Biểu mẫu phí giao dịch" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tỷ lệ hoa hồng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tyle_hoahong" ten="Tỷ lệ hoa hồng" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_so" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Phụ cấp</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" cotAn="co_bh" Width="100%"
                                AutoGenerateColumns="false" hangKt="10" cot="ma_pc,ten,sotien,ngay_ad,ngay_kt,co_bh" PageSize="1" CssClass="gridX">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã phụ cấp" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_pc" runat="server" placeholder="Nhấn (F1)" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac.aspx"
                                                CssClass="css_Gma" Width="100px" kt_xoa="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ten" HeaderText="Tên phụ cấp" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100%" />
                                    <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="sotien" runat="server" CssClass="css_Gma_r" Width="100%" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hiệu lực" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ad" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100px" kt_xoa="K" TaoValid="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hết hiệu lực" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_kt" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100px" kt_xoa="K" TaoValid="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đóng BH" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="co_bh" runat="server" lke=",C" Width="80px" ToolTip="  - Không đóng bảo hiểm,X - Đóng bảo hiểm" CssClass="css_Gma_c" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_hd_P_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_hd_P_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_hd_P_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_hd_P_chenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div style="display: none">
                        <Cthuvien:DR_list ID="tratheo" runat="server" lke="Kỳ lương" tra="KL" ten="Trả lương theo" />
                        <Cthuvien:DR_list ID="loailuong" runat="server" lke="Gross,Net" tra="GROS,NET" ten="Loại lương" />
                        <Cthuvien:so ID="tienbh" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_ma" />
                        <Cthuvien:so ID="tien_tns" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_ma" />
                        <Cthuvien:so ID="tien_tdgt" runat="server" kt_xoa="X" kieu="U" CssClass="form-control css_ma" />
                        <Cthuvien:ma ID="cdanh_nguoiky" kt_xoa="X" runat="server" />
                        <Cthuvien:so ID="so_qd_id" kt_xoa="K" runat="server" Value="0" />
                        <Cthuvien:DR_list ID="trang_thai" ten="Trạng thái" runat="server"
                            CssClass="form-control css_list" kieu="S"> 
                        </Cthuvien:DR_list>
                    </div>
                    <div class="list_bt_action">
                        <div id="an_mopd" class="b_left form-group iterm_form">
                            <Cthuvien:nhap ID="mopd" runat="server" Text="Mở chờ phê duyệt" class="bt_action" anh="K" Width="150px" OnClick="ns_hd_P_PHEDUYET();form_P_LOI('');" Title="Mở chờ phê duỵệt" />
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px"
                                Text="Mới" OnClick="return ns_hd_P_MOI();form_P_LOI();" />
                            <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px"
                                Text="Ghi" OnClick="return ns_hd_P_NH('N');form_P_LOI();" />
                            <Cthuvien:nhap ID="Nhap1" runat="server" Text="In" Width="70px" class="bt_action" anh="K"
                                title="In" OnClick="ns_hd_P_BIEUMAU();form_P_LOI('');" />
                            <Cthuvien:nhap ID="phuluc" runat="server" Text="Phụ lục" Width="70px" class="bt_action" anh="K"
                                title="Phụ lục" OnClick="return ns_hd_P_PL();form_P_LOI();" />
                            <Cthuvien:nhap ID="file" runat="server" Text="File" Width="70px" class="bt_action" anh="K"
                                title="File" OnClick="return nhap_file();form_P_LOI();" />
                            <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="70px"
                                Text="Xóa" OnClick="return ns_hd_P_XOA();form_P_LOI();" />
                            <button onclick="return ns_hd_Export();form_P_LOI();" class="bt_action mgt10">File mẫu</button>
                            <button onclick="return ns_hd_Import();form_P_LOI();" class="bt_action mgt10">Import</button>
                            <Cthuvien:nhap ID="pheduyet" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px"
                                Text="Phê duyệt" OnClick="return ns_hd_P_NH('P');form_P_LOI();" />
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="xuatfilemau" runat="server" Width="100px" Text="File mẫu" OnServerClick="export_excel" />
                        <Cthuvien:nhap ID="thanhly" runat="server" Text="Thanh lý" Width="70px" class="css_button"
                            title="Thanh lý" OnClick="return ns_hd_P_TL();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap3" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        <Cthuvien:nhap ID="msword" runat="server" Width="70px" Text="Export" OnServerClick="msword_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="a_so_id" runat="server" />
        <Cthuvien:an ID="alhd" runat="server" />
        <Cthuvien:an ID="atluong" runat="server" />
        <Cthuvien:an ID="anluong" runat="server" />
        <Cthuvien:an ID="abluong" runat="server" />
        <Cthuvien:an ID="acheckall" runat="server" />
        <Cthuvien:an ID="alhd_tk" runat="server" />
        <Cthuvien:an ID="atrangthai_tk" runat="server" />
        <Cthuvien:an ID="aphong_tk" runat="server" Value="TATCA" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,850" />
    </div>
</asp:Content>
