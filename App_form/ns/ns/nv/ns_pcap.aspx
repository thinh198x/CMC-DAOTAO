<%@ Page Title="ns_pcap" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_pcap.aspx.cs" Inherits="f_ns_pcap" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý các khoản hỗ trợ" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
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
                        <div class="b_left form-group iterm_form"> 
                            <span class="standard_label b_left col_40">Loại hưởng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loaihuong_tk" ten="Loại hưởng" runat="server" CssClass="form-control css_list"
                                    lke=",Theo tháng,Theo công thực tế" tra=",TT,TC" />

                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="ns_pcap_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="lh,ma_phucap,loaihuong,ghichu,so_id" hamRow="ns_pcap_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số quyết định" DataField="so_qd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại phụ cấp" DataField="tenpc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại hưởng" DataField="lh" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="số tiền" DataField="tien" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngayc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ma_phucap" />
                                    <asp:BoundField DataField="loaihuong" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_pcap_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã số CB <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_form" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                    ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_pcap_P_KTRA('SO_THE')" kt_xoa="X" />
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_form" ToolTip="Họ tên cán bộ" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" CssClass="form-control css_form" ToolTip="Chức danh" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong" ten="Phòng" runat="server" CssClass="form-control css_form" ToolTip="Phòng ban" kieu_unicode="true" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại phụ cấp <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_PHUCAP" ktra="DT_MA_PHUCAP" runat="server" CssClass="form-control css_list" kt_xoa="X"></Cthuvien:DR_lke>
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số quyết định <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_QD" runat="server" CssClass="form-control css_form" kt_xoa="X" ten="Số quyết định" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại hưởng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loaihuong" ten="Loại hưởng" runat="server" CssClass="form-control css_list"
                                    lke="Theo tháng,Theo công thực tế" tra="TT,TC" />
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tiền</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tien" runat="server" CssClass="form-control css_form_r" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_30">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày hết hiệu lực" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Ghi chú</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="form-control css_form" kt_xoa="X" Width="100%" Height="50px"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="day" ten="" runat="server" Text="A" />
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" anh="K" class="bt_action" Text="Làm mới" OnClick="return ns_pcap_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" anh="K" class="bt_action" Text="Ghi" OnClick="return ns_pcap_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="file" runat="server" Width="70px" anh="K" class="bt_action" Text="File" title="File" OnClick="return nhap_file();form_P_LOI();" />
                        <Cthuvien:nhap ID="in" runat="server" Width="70px" anh="K" class="bt_action" Text="In" title="In" OnClick="return ns_pcap_P_IN()" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="90px" anh="K" class="bt_action" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" anh="K" class="bt_action" Text="Xóa" OnClick="return ns_pcap_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="Xuat2" runat="server" Width="70px" Text="Export" OnServerClick="msword_Click" />
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,620" />
    </div>
</asp:Content>
