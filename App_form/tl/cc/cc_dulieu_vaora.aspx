<%@ Page Title="cc_dulieu_vaora" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_dulieu_vaora.aspx.cs" Inherits="f_cc_dulieu_vaora" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý dữ liệu vào ra" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Số thẻ" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" runat="server" kieu_unicode="true" CssClass="form-control css_ma" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PHONG_TK" runat="server" CssClass="form-control css_list" onchange="cc_dulieu_vaora_P_KTRA('PHONG')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" CssClass="form-control icon_lich" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC" runat="server" CssClass="form-control icon_lich" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_P_LKE();form_P_LOI();" Width="103px" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:kieu runat="server" ID="di_muon" ten="Đi muộn" lke=",X" tra=",X" CssClass="form-control css_ma_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:kieu runat="server" ID="ve_som" ten="Về sớm" lke=",X" tra=",X" CssClass="form-control css_ma_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:kieu runat="server" ID="nghi_cn" ten="Nghỉ cả ngày" lke=",X" tra=",X" CssClass="form-control css_ma_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_P_LKE();form_P_LOI();" Width="103px" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" cot="STT,van_tay,so_the,ten,ten_cdanh,ten_phong,ngay,land,loai,IP" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="TT" DataField="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã vân tay" DataField="van_tay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày quẹt" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Vân tay" DataField="land" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Dữ liệu tải/Import dữ liệu tải" DataField="loai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="IP máy chấm công" DataField="IP" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_dulieu_vaora_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="export" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_EXPORT();form_P_LOI();"
                            Width="100px" />
                        <Cthuvien:nhap ID="excel" runat="server" Text="File mẫu" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_MAU();form_P_LOI();"
                            Width="100px" />
                        <Cthuvien:nhap ID="import" runat="server" Text="Import" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_Import();form_P_LOI();"
                            Width="100px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return cc_dulieu_vaora_P_XOA();form_P_LOI();"
                                Width="70px" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,760" />
        <Cthuvien:an ID="aphong" runat="server" />
    </div>
</asp:Content>
