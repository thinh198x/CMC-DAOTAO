<%@ Page Title="ns_dt_hinhthuc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_hinhthuc.aspx.cs" Inherits="f_ns_dt_hinhthuc" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thời gian đào tạo theo hình thức OJT" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Năm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nam_tk" kieu_so="true" ten="Năm" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_dt_hinhthuc_P_LKE('K');form_P_LOI();" Width="90px" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <div style="overflow-x: scroll;">
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="gridX" loai="X" hangKt="15" cotAn="so_id,ma_hv" hamRow="ns_dt_hinhthuc_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tên giảng viên" DataField="ten_gv" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên học viên" DataField="ten_hv" HeaderStyle-Width="110px"
                                            ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày đào tạo" DataField="Ngay_gd" HeaderStyle-Width="150px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Kết quả" DataField="ket_qua" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                        <asp:BoundField HeaderText="ma_hv" DataField="ma_hv" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_hinhthuc_P_LKE('K')" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_hinhthuc_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" ten="Năm" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nhân viên giảng dạy <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ToolTip="Mã số nhân viên" f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_gv_noi.aspx" placeholder="Nhấn (F1)" kt_xoa="K"
                                    kieu_chu="true" onchange="ns_dt_hinhthuc_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Phòng ban" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="True" MaxLength="250" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="True" MaxLength="250" Enabled="false" />
                                <div style="display: none;">
                                    <Cthuvien:ma ID="cdanh" ten="Chức danh" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="True" MaxLength="250" Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Ngày đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAY_GD" placeholder='dd/MM/yyyy' runat="server" ten="Ngày đào tạo" CssClass="form-control icon_lich"
                                    kt_xoa="X" ToolTip="Ngày đào tạo" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thời lượng đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="THOI_GIAN_GD" ten="Thời lượng đào tạo" so_tp="3" runat="server" CssClass="form-control css_so" kt_xoa="X" MaxLength="15"
                                    gchu="gchu" onchange="ns_dt_hinhthuc_P_KTRA('THOI_GIAN_GD')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Từ giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TU_GIO" ten="Từ giờ" onchange="ns_dt_hinhthuc_P_KTRA('TU_GIO')" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="15"
                                    gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Đến giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DEN_GIO" ten="Đến giờ" onchange="ns_dt_hinhthuc_P_KTRA('DEN_GIO')" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="15" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Nội dung đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:nd TextMode="MultiLine" ID="noidung" ten="Nội dung đào tạo" runat="server" CssClass="form-control css_nd" kt_xoa="X" MaxLength="15" gchu="gchu" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" hamUp="ns_dt_hinhthuc_P_Update" Width="100%"
                                AutoGenerateColumns="false" hangKt="12" cot="ma_hv,ten_hv,donvi,ten_donvi,thoi_gian_hoc,ket_qua" cotAn="donvi" PageSize="1" CssClass="gridX">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã học viên" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_hv" ReadOnly="true" runat="server" CssClass="css_Gma" BackColor="#f6f7f7" kieu_chu="true"
                                                Width="200px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã học viên" placeholder="Nhấn (F1)" ktra="ns_cb,so_the,ten" ToolTip="Mã học viên" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ten_hv" HeaderText="Tên học viên" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_donvi" HeaderText="Đơn vị" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                    <asp:BoundField DataField="donvi" HeaderText="Đơn vị" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                    <asp:TemplateField HeaderText="Thời gian học" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="thoi_gian_hoc" ReadOnly="true" ten="Thời gian học" runat="server" Enabled="true" CssClass="css_Gma" kt_xoa="X" MaxLength="15" Width="135px" gchu="gchu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="ket_qua" ktra="DT_KETQUA" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_hinhthuc_HangLen(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_hinhthuc_HangXuong(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_hinhthucc_CatDong(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_hinhthuc_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_dt_hinhthuc_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_dt_hinhthuc_P_MOI();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_dt_hinhthuc_P_XOA();form_P_LOI();" Width="70px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="filemau" runat="server" Width="100px" Text="File mẫu" OnServerClick="nhap_Click" />
                            <Cthuvien:nhap ID="import" runat="server" Text="Import" onclick="return ns_dt_hinhthuc_Import();form_P_LOI();" Width="120px" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" Value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,650" />
</asp:Content>
