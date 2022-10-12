<%@ Page Title="cc_sp_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_sp_tt.aspx.cs" Inherits="f_cc_sp_tt" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chấm công sản phẩm tập thể" />
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
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id" hamRow="cc_sp_tt_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ca" DataField="ca" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_sp_tt_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Phòng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" ktra="DT_PHONG" kt_xoa="G"
                                CssClass="form-control css_list" kieu="S" onchange="cc_sp_tt_P_KTRA('PHONG')" />
                            <Cthuvien:kieu ID="lh" MaxLength="1" runat="server" Text="K" lke="C,K" ToolTip="C - Lấy hết danh sách cán bộ của phòng, K - Không lấy danh sách cán bộ"
                                Width="30px" CssClass="form-control css_ma" onblur="cc_sp_tt_P_KTRA('PHONG')" />
                            <%--<img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return cc_sp_tt_phong();" />--%>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" MaxLength="10" ten="Ngày" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    kieu_luu="S" onchange="cc_sp_tt_P_KTRA('NGAY')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ca<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ca" MaxLength="1" runat="server" CssClass="form-control css_ma" ten="ten_kieu"
                                    Text="S" lke="S,C,Đ" ToolTip="S-Ca Sáng, C-Ca Chiều, Đ-Ca Đêm" onchange="cc_sp_tt_P_KTRA('NGAY')" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" MaxLength="200" kt_xoa="X" CssClass="form-control css_nd" ten="Ghi chú" Height="50px"
                                ToolTip="ghi chú" />
                        </div>
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_sp" runat="server" CssClass="css_tab_ngang_ac" Width="180px"
                            Text="Sản phẩm/Công việc" ham="cc_sp_tt_P_NPA('sp')" />
                        <Cthuvien:tab ID="NPa_ds" runat="server" CssClass="css_tab_ngang_de" Width="180px"
                            Text="Danh sách cán bộ" ham="cc_sp_tt_P_NPA('ds')" />
                    </div>
                    <div class="tab_content">
                        <asp:Panel ID="Pa_sp" runat="server" Style="display: block;">
                            <div>
                                <Cthuvien:GridX ID="GR_sp" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="N" cot="ten_sp,masp,donvi,chatluong,soluong" cotAn="masp" hangKt="12" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_sp_tt_sp_Update">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã sản phẩm" HeaderStyle-Width="160px">
                                            <ItemTemplate>
                                                <Cthuvien:ma MaxLength="10" ID="ten_sp" kieu_chu="true" runat="server" Width="160px" CssClass="css_Gma"
                                                    f_tkhao="~/App_form/tl/ma/tl_ma_spham.aspx" ktra="ns_tl_ma_spham,ma,ten" placeholder="Nhấn (F1)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Sản phẩm" DataField="masp" HeaderStyle-Width="133px" ItemStyle-CssClass="css_Gnd" />

                                        <asp:BoundField HeaderText="Đơn vị" DataField="donvi" HeaderStyle-Width="133px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:TemplateField HeaderText="Chất lượng" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:so MaxLength="10" ID="chatluong" Max="100" runat="server" Width="170px" CssClass="css_Gso" co_dau="K" so_tp="2" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số lượng" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:so MaxLength="10" ID="soluong" runat="server" Width="170px" CssClass="css_Gso" co_dau="K" so_tp="2" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>

                            </div>
                            <div class="btex_luoi b_right" id="id_chensp">
                                <ul>
                                    <li>
                                        <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return cc_sp_tt_sp_HangLen();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return cc_sp_tt_sp_HangXuong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cc_sp_tt_sp_CatDong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return cc_sp_tt_sp_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_ds" runat="server" Style="display: none;">
                            <div style="overflow-y: scroll; height: 320px;">
                                <Cthuvien:GridX ID="GR_ds" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="N" cot="so_the,ten,cdanh,phong" hangKt="100" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_sp_tt_ds_Update">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã cán bộ" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <Cthuvien:ma MaxLength="30" ID="so_the" kieu_chu="true" runat="server" CssClass="css_Gma"
                                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>

                            </div>
                            <div class="btex_luoi b_right" id="id_chends">
                                <ul>
                                    <li>
                                        <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return cc_sp_tt_ds_HangLen();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return cc_sp_tt_ds_HangXuong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cc_sp_tt_ds_CatDong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return cc_sp_tt_ds_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return cc_sp_tt_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                        <button onclick="return cc_sp_tt_P_MOI();form_P_LOI();" class="bt_action">Mới</button>
                        <button onclick="return cc_sp_tt_P_XOA();form_P_LOI();" class="bt_action">Xóa</button>

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
        <Cthuvien:an ID="kthuoc" runat="server" Value="955,655" />
    </div>
</asp:Content>
