<%@ Page Title="ns_menu_tbao_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_menu_tbao_ct.aspx.cs" Inherits="f_ns_menu_tbao_ct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Biến động nhân sự" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="col_100 inner" id="UPa_ct">
                    <div style="margin-left: 50px; padding-bottom: 20px;">
                        <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Điều kiện" Width="80px" />

                        <Cthuvien:DR_list ID="NV_SN" CssClass="form-control css_list" ten="Trạng thái" runat="server" kieu="S" onchange="ns_menu_tbao_ct_P_KTRA('NV_SN')" Width="300px"
                            tra="SN,HD,HS,CCHN,CON" lke="Nhân viên sắp sinh nhật,Nhân viên sắp hết hạn hợp đồng,Nhân viên hết hạn nộp hồ sơ,Danh sách đủ điều kiện thi CCHN,Danh sách con hết giảm trừ" />

                        <%-- <Cthuvien:DR_nhap ID="NV_SN" ten="Nhân viên sinh nhật" runat="server" Width="400px" CssClass="form-control css_list"
                            onchange="ns_menu_tbao_ct_P_KTRA('NV_SN')">
                            <asp:ListItem Selected="True" Value="SN" Text="Nhân viên sắp sinh nhật"></asp:ListItem>
                            <asp:ListItem Value="HD" Text="Nhân viên sắp hết hạn hợp đồng"></asp:ListItem> 
                            <asp:ListItem Value="HS" Text="Nhân viên hết hạn nộp hồ sơ"></asp:ListItem>
                            <asp:ListItem Value="CCHN" Text="Danh sách đủ điều kiện thi CCHN"></asp:ListItem>
                            <asp:ListItem Value="CON" Text="Danh sách con hết giảm trừ"></asp:ListItem>

                             <asp:ListItem Value="HC" Text="Nhân viên sắp hết hạn hộ chiếu"></asp:ListItem>
                            <asp:ListItem Value="CMT" Text="Nhân viên sắp hết hạn CMTND"></asp:ListItem>
                            <asp:ListItem Value="QD" Text="Nhân viên sắp hết hạn quyết định"></asp:ListItem>
                            <asp:ListItem Value="VS" Text="Nhân viên sắp hết hạn visa"></asp:ListItem>
                            <asp:ListItem Value="TD" Text="Bạn đang có yêu cầu tuyển dụng"></asp:ListItem>

                        </Cthuvien:DR_nhap>--%>
                    </div>
                    <div class="grid_table width_common">
                        <div id="lke_cb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="L" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mã cán bộ" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên cán bộ" DataField="TEN" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày sinh" DataField="NSINH" HeaderStyle-Width="90px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Phòng" DataField="PHONG" HeaderStyle-Width="300px"
                                            ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày vào" DataField="NGAYD" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Loại hợp đồng" DataField="LHD" HeaderStyle-Width="250px"
                                            ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày hết hạn HĐ" DataField="NGAYHH" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Loại quyết định" DataField="LQD" HeaderStyle-Width="250px"
                                            ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày hết hạn QĐ" DataField="NGAYHH_QD" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_menu_tbao_ct_P_LKE('K')" />
                        </div>

                        <div id="lke_cdanh" style="display: none">
                            <div>
                                <Cthuvien:GridX ID="GR_td" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="L" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Bộ phân yêu cầu" DataField="phong" HeaderStyle-Width="260px"
                                            ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="260px"
                                            ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày yêu cầu" DataField="ngay_yc" HeaderStyle-Width="120px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Số lượng cần tuyển" DataField="sl_cantuyen" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_td_slide" runat="server" loai="X" gridId="GR_td" ham="ns_menu_tbao_ct_P_LKE('K')" />
                        </div>

                        <div id="lke_hs" style="display: none">
                            <div>
                                <Cthuvien:GridX ID="GR_hs" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="L" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mã cán bộ" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên cán bộ" DataField="TEN" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày sinh" DataField="NSINH" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày vào" DataField="NGAYD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tên hồ sơ" DataField="TEN_HS" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày hết hạn nộp" DataField="ngay_p" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_hs_slide" runat="server" loai="X" gridId="GR_hs" ham="ns_menu_tbao_ct_P_LKE('HS')" />
                        </div>

                        <div id="lke_cchn" style="display: none">
                            <div class="width_common auto_sc line_37">
                                <div class="b_left col_30 inner" id="UPa_tk">
                                    <div class="grid_table width_common">
                                        <div>
                                            <Cthuvien:GridX ID="Gr_lke_cchn" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="25" cotAn="nsd,ghichu,tc,ma_cchn" hamRow="ns_menu_tbao_ct_GR_lke_cchn_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Tên chứng chỉ hành nghề" DataField="ten_cchn" HeaderStyle-Width="80px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="70px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tc" HeaderStyle-Width="50px"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Ghi chú" DataField="ghichu"></asp:BoundField>
                                                    <asp:BoundField DataField="tc"></asp:BoundField>
                                                    <asp:BoundField DataField="ma_cchn"></asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <ctr_khud_divL:ctr_khud_divL ID="Gr_lke_cchn_slide" runat="server" gridId="Gr_lke_cchn" ham="ns_menu_tbao_ct_cchn_P_LKE()" />
                                    </div>
                                </div>
                                <div class="b_right col_70 inner" id="UPa_ct_cchn">
                                    <div class="grid_table width_common">
                                        <div>
                                            <Cthuvien:GridX ID="Gr_ct_cchn" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="L" hangKt="25">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Mã cán bộ" DataField="SO_THE" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Họ tên" DataField="TEN" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Ngày sinh" DataField="NSINH" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Ngày vào" DataField="NGAYD" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <ctr_khud_divL:ctr_khud_divL ID="Gr_ct_cchn_slide" runat="server" loai="X" gridId="Gr_ct_cchn" ham="ns_menu_tbao_ct_cchn_ct_P_CHUYEN_HANG()" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="lke_con" style="display: none">
                            <div>
                                <Cthuvien:GridX ID="GR_con" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="L" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mã cán bộ" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên cán bộ" DataField="TEN" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Họ tên nhân thân" DataField="ten_nhanthan" HeaderStyle-Width="170px"
                                            ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Quan hệ" DataField="ten_lqh" HeaderStyle-Width="70px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Đối tượng giảm trừ" DataField="phuthuoc" HeaderStyle-Width="70px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày BD giảm trừ" DataField="ngayd" HeaderStyle-Width="100px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày KT giảm trừ" DataField="ngayc" HeaderStyle-Width="250px"
                                            ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_con_slide" runat="server" loai="X" gridId="GR_con" ham="ns_menu_tbao_ct_P_LKE('K')" />
                        </div>
                    </div>
                    <%--<div class="list_bt_action" align="center">
                        <div class="box3 txCenter">
                            <a href="#" onclick="return ns_menu_tbao_ct_EXCEL();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất Excel</a>
                            <a href="#" onclick="return ns_menu_tbao_ct_P_CB();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ạo HĐ mới</a>
                            <Cthuvien:nhap ID="xuat_excel" runat="server" Width="100px" Text="Xuất excel" onclick="return ns_menu_tbao_ct_EXCEL();form_P_LOI();" />
                             <Cthuvien:nhap ID="tao_hd" runat="server" Width="100px" Text="Xuất excel"onclick="return ns_menu_tbao_ct_P_CB();form_P_LOI();"/>
                        </div>

                    </div>--%>
                    <div class="list_bt_action" align="center">
                        <Cthuvien:nhap ID="xuat_excel" runat="server" Text="Xuất excel" Width="100px" class="bt_action" anh="K" OnClick="return ns_menu_tbao_ct_EXCEL();form_P_LOI();" />
                        <Cthuvien:nhap ID="tao_hd" runat="server" Width="130px" class="bt_action" anh="K" Text="Tạo hợp đồng" OnClick="return ns_menu_tbao_ct_P_CB();form_P_LOI();" />

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,690" />
    </div>
</asp:Content>
