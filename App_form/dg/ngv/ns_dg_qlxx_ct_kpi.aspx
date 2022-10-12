<%@ Page Title="ns_dg_qlxx_ct_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_qlxx_ct_kpi.aspx.cs" Inherits="f_ns_dg_qlxx_ct_kpi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý xem xét chỉ tiêu giao KPI" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kỳ đánh giá<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg1" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG1" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_tk" ten="Nhóm nội dung" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_dg_qlxx_ct_kpi_P_NAM_TK();" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="100px" OnClick="return ns_dg_qlxx_ct_kpi_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,trangthai,ky_dg" hamRow="ns_dg_qlxx_ct_kpi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dg_qlxx_ct_kpi_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Nhóm nội dung" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_dg_qlxx_ct_kpi_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Nhóm nội dung" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="K"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="K"
                                    ten="Tên nhân viên" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common mgt10 pv_bl"><span>Phần I: Đánh giá mức độ hoàn thành công việc</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 200px;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="nhom_tc,so_idct" cot="stt,nhom_tc,tieuchi,titrong,donvitinh,khongdat,cancaitien,dat,tot,xuatsac,so_idct" hangKt="10" gchuId="gchu" Width="100%" hamUp="thaydoiRow">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="40px" CssClass="css_Gso" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhóm tiêu chí*" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="NHOM_TC" ktra="DT_NTC" runat="server" CssClass="css_Glist" Width="130px" ten="Nhóm tiêu chí"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiêu chí*" HeaderStyle-Width="255px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TIEUCHI" runat="server" CssClass="css_Gma" Width="255px" gchu="Tên tiêu chí đánh giá" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ trọng" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="titrong" runat="server" Width="80px" so_tp="2" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị tính" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="donvitinh" runat="server" Width="80px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Không đạt" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="khongdat" runat="server" CssClass="css_Gma" Width="50px" ten="Mô tả" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cần cải tiến" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cancaitien" runat="server" CssClass="css_Gma" Width="50px" ten="Cần cải tiến" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đạt" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dat" runat="server" CssClass="css_Gma" Width="50px" ten="Đạt" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tốt" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tot" runat="server" CssClass="css_Gma" Width="50px" ten="Tốt" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Xuất sắc" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xuatsac" runat="server" CssClass="css_Gma" Width="50px" ten="Xuất sắc" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số id chi tiết" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_idct" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                             
                        </div>
                        <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_qlxx_ct_kpi_CatDong(1);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_qlxx_ct_kpi_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                    </div>
                    <div class="width_common mgt10 pv_bl"><span>Phần II: Đánh giá năng lực</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 150px;">
                            <Cthuvien:GridX ID="GR_ct1" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="so_idct" cot="stt,mota,titrong,so_idct" hangKt="10" gchuId="gchu" Width="100%" hamUp="thaydoiRow1">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="40px" CssClass="css_Gso" Enabled="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả năng lực" HeaderStyle-Width="590px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" Width="590px" gchu="Mô tả năng lực" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ trọng" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="titrong" runat="server" Width="130px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số id chi tiết" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_idct" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                           
                            
                        </div>
                         <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_qlxx_ct_kpi_CatDong(2);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_qlxx_ct_kpi_ChenDong('2');" />
                                    </li>
                                </ul>
                            </div>
                    </div>
                    <div class="b_left width_common mgt10 form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Ghi chú" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Width="680px" Height="50px" MaxLength="1000" />
                            <div style="display: none">
                                <Cthuvien:DR_list ID="trangthai" runat="server" Width="190px" lke="Chưa gửi, Chờ xem xét,Đã xem xét,Không phê duyệt" tra="CG,0,1,2" ten="Trạng thái" ToolTip="Trạng thái" CssClass="css_list" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xacnhan" class="bt_action" anh="K" runat="server" Width="80px" Text="Xác nhận" OnClick="return ns_dg_qlxx_ct_kpi_P_XACNHAN_GUILAI('XN');form_P_LOI();" />
                        <Cthuvien:nhap ID="guilai" class="bt_action" anh="K" runat="server" Width="80px" Text="Gửi lại" OnClick="return ns_dg_qlxx_ct_kpi_P_XACNHAN_GUILAI('TC');form_P_LOI();" />

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1460,790" />
</asp:Content>
