<%@ Page Title="cbnv_ct_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cbnv_ct_kpi.aspx.cs" Inherits="f_cbnv_ct_kpi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cán bộ nhập chỉ tiêu giao KPI" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Kỳ đánh giá <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg1" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG1" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_right width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="cbnv_ct_kpi_P_NAM_TK();" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="100px" OnClick="return cbnv_ct_kpi_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,trangthai,ky_dg" hamRow="cbnv_ct_kpi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <%--<asp:BoundField HeaderText="Mã nhân viên" DataField="ma" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />--%>
                                    <%--<asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />--%>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cbnv_ct_kpi_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G"
                                    onchange="cbnv_ct_kpi_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G"
                                    onchange="cbnv_ct_kpi_P_KTRA('KY_DG')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    ten="Tên nhân viên" Enabled="false" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Phần I: Đánh giá mức độ hoàn thành công việc</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 150px;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="nhom_tc,so_idct" cot="stt,nhom_tc,tieuchi,titrong,donvitinh,khongdat,cancaitien,dat,tot,xuatsac,so_idct" hangKt="10" gchuId="gchu" Width="650px" hamUp="thaydoiRow">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="40px" CssClass="css_Gma_c" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhóm tiêu chí*" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="NHOM_TC" ktra="DT_NTC" runat="server" CssClass="css_Glist" Width="130px" ten="Nhóm tiêu chí"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiêu chí*" HeaderStyle-Width="260px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tieuchi" runat="server" CssClass="css_Gma" Width="260px" gchu="Tên tiêu chí đánh giá" />
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
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cbnv_ct_kpi_CatDong(1);" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return cbnv_ct_kpi_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Phần II: Đánh giá năng lực</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 150px;">
                            <Cthuvien:GridX ID="GR_ct1" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="so_idct" cot="stt,mota,titrong,so_idct" hangKt="10" gchuId="gchu" Width="650px" hamUp="thaydoiRow1">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="40px" CssClass="css_Gma_c" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả năng lực" HeaderStyle-Width="590px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" Width="590px" gchu="Mô tả năng lực" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ trọng" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="titrong" runat="server" Width="130px" CssClass="css_Gma" kieu_so="true" so_tp="2" />
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
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cbnv_ct_kpi_CatDong(2);" />

                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return cbnv_ct_kpi_ChenDong('2');" />

                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="trangthai" runat="server" lke="Chưa gửi, Chờ xem xét,Đã xem xét,Không phê duyệt" tra="CG,0,1,2" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" BackColor="#f6f7f7" Enabled="false" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" Width="100px" OnClick="return cbnv_ct_kpi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="cbnv_ct_kpi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="80px" Text="Gửi" OnClick="return cbnv_ct_kpi_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return cbnv_ct_kpi_P_XOA();form_P_LOI();" />
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
