<%@ Page Title="dgia_kpi_nv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dgia_kpi_nv.aspx.cs" Inherits="f_dgia_kpi_nv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá KPIs" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" ktra="DT_NAM_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G"
                                onchange="dgia_kpi_nv_P_NAM('F');" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dgia_kpi_nv_P_NAM_TK();" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="100px" OnClick="return dgia_kpi_nv_P_LKE('M');form_P_LOI();" />

                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="25" cotAn="so_id,trangthai" hamRow="dgia_kpi_nv_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dgia_kpi_nv_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dgia_kpi_nv_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    onchange="dgia_kpi_nv_P_KY_DG('K');" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đợt đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="DOT_DG" ten="Đợt đánh giá" runat="server" ktra="DT_DOT_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    ten="Tên nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Phần I: Đánh giá mức độ hoàn thành công việc</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="10" gchuId="gchu" Width="100%"
                                cotAn="so_id,so_id_ct" cot="tieuchi,dv_tinh,cac_chitieu_kd,cac_chitieu_ct,cac_chitieu_d,cac_chitieu_t,cac_chitieu_x,trong_so,diem_dg,diem_dg_tt,diem_dg_ql,diem_dg_tt_ql,gchu,so_id,so_id_ct">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tên tiêu chí đánh giá" HeaderStyle-Width="170px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tieuchi" runat="server" CssClass="css_Gma" Width="170px" gchu="Tên tiêu chí đánh giá" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị tính" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dv_tinh" runat="server" Width="100px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Không đạt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_kd" runat="server" CssClass="css_Gma" Width="80px" ten="Mô tả" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cần cải tiến" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_ct" runat="server" CssClass="css_Gma" Width="80px" ten="Cần cải tiến" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đạt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_d" runat="server" CssClass="css_Gma" Width="80px" ten="Đạt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tốt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_t" runat="server" CssClass="css_Gma" Width="80px" ten="Tốt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Xuất sắc" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_x" runat="server" CssClass="css_Gma" Width="80px" ten="Xuất sắc" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỉ trọng" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="trong_so" runat="server" onkeyup="tinhtong_P_KTRA('TRONG_SO,DIEM_DG=DIEM_DG_TT')" CssClass="css_Gma" Width="80px" ten="Xuất sắc" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg" runat="server" onkeyup="tinhtong_P_KTRA('TRONG_SO,DIEM_DG=DIEM_DG_TT')" CssClass="css_Gma" Width="80px" ten="Xuất sắc" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm DG theo tỉ trọng" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_tt" runat="server" Enabled="false" CssClass="css_Gma" Width="100px" ten="Xuất sắc" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá(CBQL)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_ql" runat="server" CssClass="css_Gma" Width="80px" ten="Điểm đánh giá(CBQL)" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm ĐG theo tỉ trọng(CBQL)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_tt_ql" runat="server" CssClass="css_Gma" Width="110px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gchu" runat="server" CssClass="css_Gma" Width="120px" ten="Ghi chú" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="so_id_ct" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>

                    <div class="list_bt_action">
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Điểm TB KPI mức độ hoàn thành công việc tự đánh giá <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DIEM_TB_KPI" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                ten="Điểm TB KPI mức độ hoàn thành công việc tự đánh giá" Enabled="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Điểm TB KPI mức độ hoàn thành công việc QLDG</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="diem_tb_kpi_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="X"
                                ten="Điểm TB KPI mức độ hoàn thành công việc quản lý đánh giás" Enabled="false" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Phần II: Đánh giá năng lực</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow: scroll;">
                            <Cthuvien:GridX ID="GR_nl_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="so_id" cot="mota,ti_trong,diem_dg_nl,diem_dg_s,diem_dg_ql,diem_dg_s_ql,so_id" hangKt="10" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mô tả năng lực" HeaderStyle-Width="450px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" Width="450px" gchu="Mô tả năng lực" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ trọng" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="titrong" onkeyup="tinhtong_nl_ct_P_KTRA('TI_TRONG,DIEM_DG_NL=DIEM_DG_S')" runat="server" Width="120px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_nl" onkeyup="tinhtong_nl_ct_P_KTRA('TI_TRONG,DIEM_DG_NL=DIEM_DG_S')" runat="server" CssClass="css_Gma" Width="120px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá sau khi nhân hệ số" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_s" runat="server" CssClass="css_Gma" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá(CBQL)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_ql" runat="server" CssClass="css_Gma" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm ĐG sau khi nhân hệ số(CBQL)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_s_ql" runat="server" CssClass="css_Gma" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>

                    <div class="col_2_iterm mgt10 width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Điểm trung bình năng lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DIEM_TB_NL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Điểm trung bình năng lực tự đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả tự đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="KETQUA_XL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả tự đánh giá" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Điểm TB năng lực QL đánh giá	</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="diem_tb_nl_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Điểm trung bình năng lực tự đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Kết quả CBQL đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ketqua_cb_dgia" runat="server" kieu_unicode="true" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả CBQL đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả thống nhất</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ketqua_tn" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả thống nhất" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Xếp loại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="xeploai" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Xếp loại đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Nhận xét của CBNV</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" Width="100px" OnClick="return dgia_kpi_nv_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="dgia_kpi_nv_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="80px" Text="Gửi" OnClick="return dgia_kpi_nv_P_NH('GUI');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return dgia_kpi_nv_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1360,900" />
</asp:Content>
