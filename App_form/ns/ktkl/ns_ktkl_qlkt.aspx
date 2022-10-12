<%@ Page Title="ns_ktkl_qlkt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ktkl_qlkt.aspx.cs" Inherits="f_ns_ktkl_qlkt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý khen thưởng" />
                <img class="b_right" src="../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Đối tượng khen thưởng</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="dtkt_tk" runat="server" onchange="checkanhien();" CssClass="form-control css_list" ToolTip="Đối tượng kỷ luật" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Từ ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay_tk" runat="server" ten="Ngày hiệu lực" ToolTip="Ngày hiệu lực" CssClass="form-control css_ngay" kieu_luu="I" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay_tk" runat="server" ten="Ngày hiệu lực" ToolTip="Ngày hiệu lực" CssClass="form-control css_ngay" kieu_luu="I" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="trangthai_tk" lke=",Chờ phê duyệt,Phê duyệt" tra=",CPD,PD" CssClass="form-control css_list" runat="server" ten="Trạng thái" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form" style="display: none">
                        <span class="standard_label lv2 b_left col_40">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong_tk" runat="server" CssClass="form-control css_list" ktra="DT_PHONG_TK" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_chu="true" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" kieu_chu="false" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="nghi_viec_tk" runat="server" lke=",X" tra="0,1" Width="30px" ToolTip="  - Chưa nghỉ việc,X - Nghỉ việc" CssClass="form-control css_ma_c" Text="" />
                            <asp:Label ID="Label4" runat="server" Text="Nhân viên nghỉ việc" CssClass="css_gchu" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <Cthuvien:nhap ID="timki" runat="server" Text="Tìm kiếm" anh="K" class="bt_action" onclick="return ns_ktkl_qlkt_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common css_divb">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,dtuong,trangthai" hamRow="ns_ktkl_qlkt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Đối tượng" DataField="ten_dtuong" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Hình thức khen thưởng" DataField="hinhthuc" HeaderStyle-Width="165px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_nd_r" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd_c" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="dtuong" />
                                    <asp:BoundField DataField="trangthai" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke" ham="ns_ktkl_qlkt_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Xuất excel" hoi="0" OnServerClick="xuat_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin Quyết định khen thưởng</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" ten="Ngày hiệu lực"
                                    ToolTip="Ngày hiệu lực" CssClass="form-control css_ngay" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hhl" runat="server" ten="Ngày hết hiệu lực"
                                    ToolTip="Ngày hết hiệu lực" CssClass="form-control css_ngay" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số quyết định</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="soqd" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="false" kieu_chu="true" MaxLength="255" ten="Số quyết định" ToolTip="Số quyết định" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Người ký</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_nguoiky" runat="server" kt_xoa="X" CssClass="form-control css_ma" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" BackColor="#f6f7f7" ToolTip="Người ký" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Vị trí chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanhnk" runat="server" kieu_unicode="true" kt_xoa="X" CssClass="form-control css_ma" Enabled="false" BackColor="#f6f7f7" ToolTip="Chức danh người ký" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày ký<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYKY" runat="server" ten="Ngày ban hành"
                                    CssClass="form-control css_ngay" kt_xoa="X" ToolTip="Ngày ban hành" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TRANGTHAI" lke="Chờ phê duyệt,Phê duyệt" tra="CPD,PD" CssClass="form-control css_list" runat="server" ten="Trạng thái" ToolTip="Trạng thái" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="width_common pv_bl"><span>Thông tin khen thưởng</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đối tượng khen thưởng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="DTUONG" runat="server" onchange="checkanhien();" CssClass="form-control css_list" ToolTip="Đối tượng khen thưởng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div id="an_canhan">
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Mã nhân viên<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="so_the" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                        f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                        BackColor="#f6f7f7" ToolTip="Mã nhân viên" MaxLength="20" ten="Mã nhân viên" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Họ tên</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten" runat="server" kt_xoa="X" CssClass="form-control css_ma" Enabled="false" BackColor="#f6f7f7" MaxLength="255" ToolTip="Họ tên" />
                                </div>
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Vị trí chức danh</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_cdanh" runat="server" kieu_unicode="true" kt_xoa="X" CssClass="form-control css_ma" Enabled="false" BackColor="#f6f7f7" ReadOnly="true" ToolTip="Chức danh" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Đơn vị/Bộ phận</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_dvi" runat="server" kieu_unicode="true" kt_xoa="X" CssClass="form-control css_ma" Enabled="false" BackColor="#f6f7f7" ToolTip="Đơn vị" />
                                </div>
                            </div>
                        </div>
                        <div style="display: none">
                            <Cthuvien:ma ID="nguoiky" runat="server" kt_xoa="X" />
                            <Cthuvien:ma ID="cdanhnk" runat="server" kt_xoa="X" />
                            <Cthuvien:ma ID="cdanh" runat="server" kt_xoa="X" />
                            <Cthuvien:ma ID="dvi" runat="server" kt_xoa="X" />

                        </div>
                    </div>
                    <div id="an_tapthe" style="display: none">
                        <div class="grid_table width_common css_divCn">
                            <div>
                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="N" cot="so_thenv,tennv,ten_cdanhnv,ten_dvinv,cdanhnv,dvinv" cotAn="cdanhnv,dvinv" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã NV (*)" HeaderStyle-Width="117px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="so_thenv" runat="server" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                    BackColor="#f6f7f7" Width="117px" ReadOnly="true" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="tennv" runat="server" Width="150px" CssClass="css_Gma" kt_xoa="X" ReadOnly="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vị trí chức danh" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_cdanhnv" runat="server" Width="170px" CssClass="css_Gma" kt_xoa="X" ReadOnly="true" kieu_unicode="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_dvinv" runat="server" kieu_unicode="true" Width="100%" CssClass="css_Gma" kt_xoa="X" ReadOnly="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mã chức danh">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="cdanhnv" runat="server" CssClass="css_Gma" kt_xoa="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mã đơn vị">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="dvinv" runat="server" CssClass="css_Gma" kt_xoa="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_ct" />
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_ktkl_qlkt_HangLen(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_ktkl_qlkt_HangXuong(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_ktkl_qlkt_CatDong(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_ktkl_qlkt_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Cấp khen thưởng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="CAP_KTKL" runat="server" onchange="checkanhien();" CssClass="form-control css_list" ToolTip="Cấp kỷ luật" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tiền KT</span>
                            <div class="input-group">
                                <Cthuvien:so ID="sotien" co_dau="K" runat="server" kt_xoa="X" CssClass="form-control css_so" MaxLength="20" so_tp="3" ToolTip="Số tiền" />
                                <Cthuvien:ma ID="ma_nte" runat="server" kt_xoa="K" CssClass="css_ma_c" kieu_chu="true" BackColor="#DBE8F1" Width="35px" Height="22px" Text="VND" ten="Mã tiền tệ" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">HT khen thưởng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="HINHTHUC" runat="server" ten="Hình thức khen thưởng" ToolTip="Hình thức khen thưởng" kt_xoa="X" ktra="DT_HTKT" CssClass="form-control css_list"
                                    onchange="ns_ktkl_qlkt_P_KTRA('HINHTHUC');" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Lý do khen thưởng</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="lydo" runat="server" kieu_unicode="true" kt_xoa="X" CssClass="form-control css_ma" MaxLength="1000" ToolTip="Lý do kỷ luật" />
                        </div>
                    </div>
                    <div id="an_canhan1">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Có cộng vào lương</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="cvluong" runat="server" kt_xoa="X" lke=",X" tra=",X" Width="30px" ToolTip="X - Có trừ vào lương" CssClass="form-control css_ma_c" onchange="checkanhien();" MaxLength="1" />
                            </div>
                        </div>
                        <div class="col_2_iterm width_common" id="an_congluong" style="display: none">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Năm<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="nam" runat="server" ktra="DT_NAM" CssClass="form-control css_list" onchange="ns_danhsach_P_KYLUONG()" ToolTip="Trừ tiền vào năm" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Kỳ lương</span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="kyluong" runat="server" ktra="DT_KYLUONG" CssClass="form-control css_list" ToolTip="Cộng tiền vào kỳ lương" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ktkl_qlkt_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap2" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ktkl_qlkt_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="in" runat="server" Text="In" Width="70px" class="bt_action" anh="K" title="In" OnServerClick="msword_Click" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ktkl_qlkt_P_XOA();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="file" runat="server" Text="File" class="bt_action" anh="K" Width="70px"
                            title="File" OnClick="return nhap_file();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="alhd" runat="server" />
        <Cthuvien:an ID="dtkt_Hi" runat="server" />
        <Cthuvien:an ID="tthai_Hi" runat="server" />
        <Cthuvien:an ID="phong_Hi" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,840" />
    </div>
</asp:Content>
