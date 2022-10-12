<%@ Page Title="ns_td_kq" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kq.aspx.cs" Inherits="f_ns_td_kq" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cập nhật kết quả các vòng thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="Upa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_kq_P_KTRA('NAM_TK')" />
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
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="120px" OnClick="return ns_td_kq_P_LKE('M');form_P_LOI();" />

                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="15" cotAn="ma_yc,so_id" hamRow="ns_td_kq_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã yêu cầu" DataField="ma_yc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã yêu cầu" DataField="ten_yc" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng/Ban" DataField="ten_phong" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Vị trí TD" DataField="ten_cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_kq_P_LKE('K')" />


                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="120px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner">
                    <div id="UPa_ct">
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_kq_P_KTRA('NAM')" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Yêu cầu TD <span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="MAYEUCAU_TD" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TD" runat="server" CssClass="form-control css_list" onchange="ns_td_kq_P_KTRA('MAYEUCAU_TD')">                                                                                
                                    </Cthuvien:DR_lke>
                                </div>
                            </div>

                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Chức danh" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Phòng/Ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phongban_ct" runat="server" Enabled="false" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Đơn vị" BackColor="#f6f7f7" />
                            </div>
                        </div>

                    </div>
                    <div class="grid_table width_common">
                      <div style="height: 450px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="chon,so_the,ten,ngaysinh,monthi1,ngaythi1,nguoi_pv1,diemdat1,ketqua1,monthi2,ngaythi2,nguoi_pv2,diemdat2,ketqua2,monthi3,ngaythi3,nguoi_pv3,diemdat3,ketqua3,ketqua_chung,gd_nhansu_pd,tgd_pd"
                                cotAn="nguoi_pv1,diemdat1,nguoi_pv2,diemdat2,nguoi_pv3,diemdat3,so_id" hangKt="50">
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
                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Vòng 1" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="monthi1" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythi1" runat="server" Width="110px" CssClass="css_Gngay" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Người PV" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nguoi_pv1" runat="server" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá 1" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diemdat1" runat="server" kieu_so="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả vòng 1" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="ketqua1" runat="server" DataTextField="ten" DataValueField="ma"
                                                kieu="S" Height="25px" Width="120px" CssClass="css_Glist">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Không đạt" Value="2"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vòng 2" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="monthi2" CssClass="css_Gma" runat="server" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' CssClass="css_Gngay" ID="ngaythi2" runat="server" Width="110px" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Người PV 2" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nguoi_pv2" runat="server" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá 2" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diemdat2" runat="server" kieu_so="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả vòng 2" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="ketqua2" runat="server" DataTextField="ten" DataValueField="ma"
                                                kieu="S" Height="25px" Width="120px" CssClass="css_Gma">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Không đạt" Value="2"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vòng 3" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="monthi3" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythi3" runat="server" Width="110px" CssClass="css_Gngay" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Người PV 3" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nguoi_pv3" runat="server" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá 3" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diemdat3" runat="server" kieu_so="true" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả vòng 3" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="ketqua3" runat="server" DataTextField="ten" DataValueField="ma"
                                                kieu="S" Height="25px" Width="120px" CssClass="css_Gma">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Không đạt" Value="2"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả chung" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="ketqua_chung" ten="Xác nhận" runat="server" DataTextField="ten" DataValueField="ma"
                                                kieu="S" Height="25px" Width="160px" CssClass="css_Gma" Enabled="false">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Chờ thi tuyển" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Không đạt" Value="2"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GĐ nhân sự PD" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gd_nhansu_pd" CssClass="css_Gma" runat="server" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TGĐ phê duyệt" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tgd_pd" CssClass="css_Gma" runat="server" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_td_kq_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_td_kq_HangXuong();" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_td_kq_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_td_kq_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Xóa" OnClick="return ns_td_kq_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="mail" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Gửi mail" OnClick="return sendMail();form_P_LOI();" />
                        <Cthuvien:nhap ID="pheduyet" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Phê duyệt" OnClick="return ns_td_kq_P_PD('1');form_P_LOI();" />
                        <Cthuvien:nhap ID="kopheduyet" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="130px" Text="Không phê duyệt" OnClick="return ns_td_kq_P_PD('2');form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
    </div>
</asp:Content>
