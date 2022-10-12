<%@ Page Title="ns_td_chuyen_uv_nv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_chuyen_uv_nv.aspx.cs" Inherits="f_ns_td_chuyen_uv_nv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chuyển ứng viên sang hồ sơ nhân viên" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="namtk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma" onchange="ns_td_uv_yeucauTD_P_KTRA('NAMTK')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã yêu cầu TD</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ma_yc_tk" ten="Mã yêu cầu TD" ktra="DT_MA_YC_TK" runat="server" CssClass="form-control css_list" />

                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="120px" OnClick="return ns_td_chuyen_uv_nv_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="20" hamRow="ns_td_chuyen_uv_nv_GR_lke_RowChange()" Width="100%"
                                cotAn="ma_dx,so_id">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã Yêu cầu TD" DataField="ma_dx" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Mã Yêu cầu TD" DataField="ten_ma_dx" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" ItemStyle-CssClass="css_Gnd" HeaderStyle-Width="300px" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gnd" HeaderStyle-Width="200px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_chuyen_uv_nv_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="nhap_Click"></Cthuvien:nhap>
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm  <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_uv_yeucauTD_P_KTRA('NAM')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Yêu cầu tuyển dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MAYEUCAU_TD" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TD" runat="server" CssClass="form-control css_list"
                                    onchange="ns_td_chuyen_uv_nv_P_KTRA('MAYEUCAU_TD')" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Phòng/bộ phận</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Đơn vị" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_cdanh" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Chức danh" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="height: 380px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="so_the,ten,ten_phong,ten_cdanh,ten_trangthai,trangthai,ngay_dl_tt,ma_nv"
                                cotAn="ma_nv,trangthai" hangKt="50" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <%--<asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn ứng viên" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" ItemStyle-CssClass="css_Gnd" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" />
                                    <asp:TemplateField HeaderText="Ngày đi làm thực tế" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_dl_tt" runat="server" Width="100%" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_nv" runat="server" Width="90px" CssClass="css_Gma" MaxLength="30" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_nh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="CHON,stt,phanloai,ma,ten,so_luong,so_id" cotAn="so_id,ma" hangKt="8" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Hoàn thành" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="CHON" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke=",X" ToolTip="Chọn thủ tục" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="STT" DataField="stt" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Phân loại" DataField="phanloai" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ma" />
                                    <asp:BoundField HeaderText="Loại giấy tờ" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số lượng" DataField="so_luong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" Width="100px" OnClick="return ns_td_chuyen_uv_nv_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="250px" class="bt_action" anh="K" Text="Chuyển ứng viên sang hồ sơ" OnClick="return ns_td_chuyen_uv_nv_P_NH();form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="nhap1" runat="server" Width="250px" Text="Chuyển ứng viên về kho ứng viên" OnClick="return ns_td_chuyen_uv_kho_P_NH();form_P_LOI();" />--%>
                        <%--<Cthuvien:nhap ID="xoa" runat="server" Width="100px" Text="Xóa" OnClick="return ns_td_chuyen_uv_nv_P_XOA();form_P_LOI();" />--%>
                        <%--<a href="#" class="bt bt-grey" onclick="return sendMail();form_P_LOI();"><i class="fa fa-send"></i><span class="txUnderline">G</span>ửi thư</a>--%>
                        <%--<a href="#" onclick="return ns_td_chuyen_uv_nv_P_HUY();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">K</span>hông đi làm</a>--%>
                        <%--<a href="#" class="bt bt-grey" onclick="return ns_td_chuyen_uv_nv_LICHSU();form_P_LOI();"><span class="txUnderline">L</span>ịch sử</a>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1380,880" />
    </div>
</asp:Content>
