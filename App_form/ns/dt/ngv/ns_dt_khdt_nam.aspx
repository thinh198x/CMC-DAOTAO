<%@ Page Title="ns_dt_khdt_nam" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_khdt_nam.aspx.cs" Inherits="f_ns_dt_khdt_nam" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kế hoạch đào tạo năm" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="namtk" runat="server" Width="120px" ktra="DT_NAM" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thangtk" ktra="DT_THANG_TK" runat="server" kt_xoa="X" ten="Tháng" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" Width="100px" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_dt_khdt_nam_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,nhom_nd" hamRow="ns_dt_khdt_nam_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Nhóm nội dung" DataField="nhom_nd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Nhóm nội dung" DataField="ten_nhom_nd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Khóa đào tạo" DataField="kdt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="T.số lớp" DataField="tonglop" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng số lượng học viên" DataField="so_hv" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng chi phí khóa" DataField="cphi" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_dt_khdt_nam_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Theo yêu cầu ĐT</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_yeucau" runat="server" lke=",X" kt_xoa="X" Width="30px" CssClass="form-control css_ma" Text="" onchange="ns_dt_khdt_P_NPA(),ns_dt_khdt_nam_P_KTRA('YEUCAU')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Năm" ten="Năm"
                                    onchange="ns_dt_khdt_nam_P_KTRA('NAM')" MaxLength="4" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thang" ktra="DT_THANG" CssClass="form-control css_list" runat="server" kt_xoa="X" ten="Tháng" onchange="ns_dt_khdt_nam_P_KTRA('THANG')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nhóm nội dung</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhom_nd" runat="server" CssClass="form-control css_ma" ktra="DT_NND" kt_xoa="X" onchange="ns_dt_khdt_nam_P_KTRA('NHOM_ND')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhucau" kt_xoa="X" ten="Khóa đào tạo" runat="server" CssClass="form-control css_list" ktra="DT_NHUCAU" onchange="ns_dt_khdt_nam_P_KTRA('KDT_NHUCAU')" />
                                <Cthuvien:DR_lke ID="KDT" kt_xoa="X" runat="server" CssClass="form-control css_list" ktra="DT_KDT" onchange="ns_dt_khdt_nam_P_KTRA('KDT')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tổng số lớp học</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tonglop" runat="server" CssClass="form-control css_ma" MaxLength="10" onchange="ns_dt_khdt_nam_P_KTRA('SO_HV')" kt_xoa="X" gchu="gchu" ToolTip="Tổng số lớp học" kieu_so="True" TaoValid="False" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Địa điểm đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ddiem" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" gchu="gchu" ToolTip="Địa điểm đào tạo" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Hình thức đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="hthuc" lke=",Inclass,Hội thảo,On Job Training,Talkshow" tra=",IL,HT,OJT,TS" CssClass="form-control css_list"
                                    kt_xoa="X" runat="server" ten="Hình thức đào tạo" ToolTip="Hình thức đào tạo" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đối tượng tham gia</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dtuong" ToolTip="Đối tượng tham gia" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời lượng đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="thoiluong" ToolTip="Thời lượng đào tạo" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">S.lượng h.viên ĐK</span>
                            <div class="input-group">
                                <Cthuvien:so ID="so_hv" ToolTip="Số lượng học viên đăng ký 1 lớp" runat="server"
                                    CssClass="form-control css_so" kt_xoa="X" kieu_so="True" onchange="ns_dt_khdt_nam_P_KTRA('SO_HV')"
                                    MaxLength="10" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">S.lượng h.viên ĐK/1 lớp</span>
                            <div class="input-group">
                                <Cthuvien:so ID="so_hv_lop" runat="server" CssClass="form-control css_so" ten="Chi phí đào tạo 1 lớp"
                                    co_dau="K" kt_xoa="X" so_tp="3" onchange="ns_dt_khdt_nam_P_KTRA('CPHI_LOP')" ToolTip="Chi phí đào tạo 1 lớp"
                                    Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Chi phí ĐT của khóa</span>
                            <div class="input-group">
                                <Cthuvien:so ID="cphi" tootip="Chi phí đào tạo của khóa" onchange="ns_dt_khdt_nam_P_KTRA('CPHI')" runat="server" CssClass="form-control css_so" kt_xoa="X" so_tp="3" MaxLength="30" />
                                <Cthuvien:ma ID="ma2" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" BackColor="#DBE8F1" Width="35px" Text="VND" ten="Mã tiền tệ" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chi phí đào tạo/lớp</span>
                            <div class="input-group">
                                <Cthuvien:so ID="cphi_lop" runat="server" kt_xoa="X" CssClass="form-control css_so" Enabled="false" BackColor="#f6f7f7" />
                                <Cthuvien:ma ID="ma1" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" BackColor="#DBE8F1" Width="35px" Text="VND" ten="Mã tiền tệ" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" CssClass="form-control css_nd" ToolTip="Ghi chú" kt_xoa="X" TabIndex="5" TextMode="MultiLine" ten="Ghi chú" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_khdt_nam_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_khdt_nam_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_dt_khdt_nam_P_XOA();form_P_LOI();" Width="70px" />
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,780" />
    </div>
</asp:Content>
