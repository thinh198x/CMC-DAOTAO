<%@ Page Title="cc_khoan_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_khoan_tt.aspx.cs" Inherits="f_cc_khoan_tt" %>

<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chấm công khoán tập thể" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
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
                    <div class="b_left form-group iterm_form">
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" class="bt_action" anh="K" OnClick="cc_sp_tt_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id" hamRow="cc_khoan_tt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã sản phẩm/Công việc" DataField="masp" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tiền" DataField="tien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_khoan_tt_P_LKE('K')" />
                        </div>
                    </div>

                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Phòng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" ktra="DT_PHONG"
                                CssClass="form-control css_list" kieu="S" onchange="cc_khoan_tt_P_KTRA('PHONG')" />
                            <Cthuvien:kieu ID="lh" MaxLength="1" runat="server" Text="K" lke="C,K" ToolTip="C - Lấy hết danh sách cán bộ của phòng, K - Không lấy danh sách cán bộ"
                                Width="30px" CssClass="form-control css_ma" onblur="cc_khoan_tt_P_KTRA('PHONG')" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Sản phẩm/Công việc<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MASP" MaxLength="10" runat="server" kt_xoa="G" CssClass="form-control css_ma" ten="Mã sản phẩm/công việc"
                                    ToolTip="Mã sản phẩm/ công việc" kieu_chu="true" f_tkhao="~/App_form/tl/ma/tl_ma_spham.aspx"
                                    ktra="ns_tl_ma_spham,ma,ten" onchange="cc_khoan_tt_P_KTRA('MASP')" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" MaxLength="10" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    kieu_luu="S" ten="Ngày chấm công" ToolTip="Ngày chấm công" onchange="cc_khoan_tt_P_KTRA('NGAY')" />
                            </div>
                        </div>
                    </div>

                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Tiền<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="TIEN" runat="server" MaxLength="10" kt_xoa="X" CssClass="form-control css_so" ten="Số tiền"
                                ToolTip="Số tiền được nhận sau khi hoàn thành công việc" />
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <div style="height: 386px; overflow-y: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="so_the,ten,cdanh,chatluong,ngayhoanthanh,tyle" hangKt="40" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_khoan_tt_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã cán bộ" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" MaxLength="10" kieu_chu="true" runat="server" Width="120px" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="Chất lượng(*)" HeaderStyle-Width="170px">
                                        <ItemTemplate>
                                            <Cthuvien:so MaxLength="3" ID="chatluong" runat="server" Width="170px" CssClass="css_Gso" co_dau="K" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hoàn thành(*)" HeaderStyle-Width="170px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay ID="ngayhoanthanh" runat="server" Width="170px" CssClass="css_Gngay" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ hoàn thành(*)" HeaderStyle-Width="170px">
                                        <ItemTemplate>
                                            <Cthuvien:so MaxLength="3" ID="tyle" runat="server" Width="170px" CssClass="css_Gso" co_dau="K" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right" id="id_chensp">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return cc_khoan_cn_sp_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return cc_khoan_cn_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cc_khoan_cn_sp_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return cc_khoan_cn_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return cc_khoan_tt_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                        <button onclick="return cc_khoan_tt_P_MOI();form_P_LOI();" class="bt_action">Mới</button>
                        <button onclick="return cc_khoan_tt_P_XOA();form_P_LOI();" class="bt_action">Xóa</button>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,700" />
    </div>
</asp:Content>
