<%@ Page Title="ns_td_phongvan" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_phongvan.aspx.cs" Inherits="f_ns_td_phongvan" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xếp lịch thi/phỏng vấn" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_phongvan_P_KTRA('NAM_TK')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã yêu cầu TD</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ma_dx_tk" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TK_TD" runat="server" CssClass="form-control css_list">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="120px" class="bt_action" anh="K" OnClick="return ns_td_phongvan_P_LKE('M')" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="15" cotAn="ma_dx,vong_thi" hamRow="ns_td_phongvan_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Yêu cầu TD" DataField="ma_dx" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Yêu cầu TD" DataField="ten_ma_dx" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đơn vị/Phòng ban" DataField="ten_phong" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Vị trí trí tuyển dụng" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày xếp lịch" DataField="ngay_xeplich" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Vòng thi" DataField="ten_vong_thi" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="vong_thi" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_phongvan_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="120px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_phongvan_P_KTRA('NAM')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Yêu cầu TD <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_DX" kt_xoa="X" ten="Yêu cầu TD" ktra="DT_MAYEUCAU_TD" CssClass="form-control css_list" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Vòng thi <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="VONG_THI" runat="server" kieu_chu="true" CssClass="form-control css_list" ten="Trạng thái" kt_xoa="X"
                                    onchange="ns_td_phongvan_P_KTRA('VONG_THI')" ktra="DT_VONG_THI"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày xếp lịch <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_XEPLICH" kt_xoa="X" ten="Ngày xếp lịch" runat="server"
                                    CssClass="form-control icon_lich" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_10">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_cdanh" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Chức danh" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_10">Phòng/Ban</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="phongban_ct" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Đơn vị" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                       <div style="height: 450px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" ctrS="nhap" ctrT="so_tt"
                                CssClass="table gridX" loai="N" cot="chon,so_the,ten,vongthi_pv,ngaythi_pv,giothi_pv_bd,giothi_pv_kt,nguoi_pv,trangthai,so_id"
                                cotAn="vongthi_pv,so_id" hangKt="50" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="90px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:TemplateField HeaderText="Vòng thi/Phỏng vấn" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="vongthi_pv" runat="server" Width="120px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày thi/phỏng vấn">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngaythi_pv" runat="server" Width="100%" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giờ thi/phỏng vấn từ">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="giothi_pv_bd" runat="server" Width="100%" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Giờ thi/phỏng vấn đến">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="giothi_pv_kt" runat="server" Width="100%" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Người phỏng vấn">
                                        <ItemTemplate>
                                            <%--<Cthuvien:ma ID="nguoi_pv" runat="server" Width="100%" CssClass="css_Gma" />--%>
                                             <Cthuvien:ma ID="nguoi_pv" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" Width="100%" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trạng thái thư mời">
                                        <ItemTemplate>
                                            <Cthuvien:DR_list ID="loaithu" runat="server" Width="100%" lke=",Đồng ý,Không đồng ý" tra=",2,3" ten="Trạng thái" CssClass="css_Glist" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="so_id" DataField="so_id">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_td_phongvan_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_td_phongvan_HangXuong();" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_td_phongvan_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_td_phongvan_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Xóa" OnClick="return ns_td_phongvan_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="mail" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Gửi mail" OnClick="return ns_td_phongvan_P_sendMail();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1440,780" />
    </div>
</asp:Content>
