<%@ Page Title="ns_cb_dgia_kpi_nv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cb_dgia_kpi_nv.aspx.cs" Inherits="f_ns_cb_dgia_kpi_nv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý đánh giá KPIs của cán bộ nhân viên" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Năm<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam1" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cb_dgia_kpi_nv_P_NAM('F');" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Kỳ đánh giá</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg_tk" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cb_dgia_kpi_nv_P_NAM('F');" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái tìm kiếm" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true"
                                CssClass="form-control css_list" kt_xoa="G" onchange="ns_cb_dgia_kpi_nv_P_NAM_TK();" />
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" class="bt_action" anh="K" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_cb_dgia_kpi_nv_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id,trangthai" hamRow="ns_cb_dgia_kpi_nv_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Số thẻ" DataField="ma" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kết quả thống nhất" DataField="ketqua_tn" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="trangthai" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cb_dgia_kpi_nv_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" class="bt_action" anh="K" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_cb_dgia_kpi_nv_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Nhóm nội dung" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cb_dgia_kpi_nv_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kỳ đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" onchange="ns_cb_dgia_kpi_nv_P_KY_DG('K');" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đợt đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="DOT_DG" ten="Đợt đánh giá" runat="server" ktra="DT_DOT_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="K"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="K"
                                    ten="Tên nhân viên" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common mgt10 pv_bl"><span>Phần I: Đánh giá mức độ hoàn thành công việc</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 150px;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N"
                                cotAn="so_id" cot="ten_tieuchi,dv_tinh,cac_chitieu_kd,cac_chitieu_ct,cac_chitieu_d,cac_chitieu_t,cac_chitieu_x,trong_so,diem_dg,diem_dg_tt,diem_dg_ql,diem_dg_tt_ql,gchu,so_id"
                                hangKt="10" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tên tiêu chí đánh giá" HeaderStyle-Width="170px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_tieuchi" runat="server" CssClass="css_Gma" Width="170px" gchu="Tên tiêu chí đánh giá" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị tính" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dv_tinh" runat="server" Width="80px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Không đạt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_kd" runat="server" CssClass="css_Gma" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cần cải tiến" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_ct" runat="server" CssClass="css_Gma" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đạt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_d" runat="server" CssClass="css_Gma" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tốt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_t" runat="server" CssClass="css_Gma" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Xuất sắc" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cac_chitieu_x" runat="server" CssClass="css_Gma" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỉ trọng" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="trong_so" runat="server" onkeyup="tinhtong_P_KTRA('TRONG_SO,DIEM_DG=DIEM_DG_TT')" CssClass="css_Gma" Width="80px" ten="Xuất sắc" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg" runat="server" onkeyup="tinhtong_P_KTRA('trong_so,DIEM_DG=DIEM_DG_TT')" CssClass="css_Gma" Width="80px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm ĐG theo tỉ trọng" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_tt" runat="server" CssClass="css_Gma" Width="100px" ten="Điểm đánh giá theo tỉ trọng" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá(CBQL)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_ql" runat="server" onkeyup="tinhtong_P_KTRA('TRONG_SO,DIEM_DG_QL=DIEM_DG_TT_QL')" CssClass="css_Gma" Width="80px" ten="Điểm đánh giá(CBQL)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm ĐG theo tỉ trọng(CBQL)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_tt_ql" runat="server" CssClass="css_Gma" Width="110px" ten="Điểm đánh giá theo tỉ trọng(CBQL)" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gchu" runat="server" CssClass="css_Gma" ten="Ghi chú" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="b_left width_common mgt10 form-group iterm_form">
                        <span class="standard_label b_left col_25">Điểm TB KPI mức độ hoàn thành công việc CNDG<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DIEM_TB_KPI" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="X"
                                ten="Điểm TB KPI mức độ hoàn thành công việc nhân viên đánh giá" Enabled="false" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Điểm TB KPI mức độ hoàn thành công việc QLDG</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="diem_tb_kpi_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="X"
                                ten="Điểm TB KPI mức độ hoàn thành công việc quản lý đánh giás" Enabled="false" />
                        </div>
                    </div>
                    <div class="width_common mgt10 pv_bl"><span>Phần II: Đánh giá năng lực</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-y: scroll; height: 150px;">
                            <Cthuvien:GridX ID="GR_nl_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="so_id" cot="stt,mota,ti_trong,diem_dg_nl,diem_dg_s,diem_dg_ql,diem_dg_s_ql,so_id" hangKt="10" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="30px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả năng lực" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" gchu="Mô tả năng lực" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ trọng" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ti_trong" onkeyup="tinhtong_nl_ct_P_KTRA('TI_TRONG,DIEM_DG=DIEM_DG_S')" runat="server" Width="70px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_nl" onkeyup="tinhtong_nl_ct_P_KTRA('TI_TRONG,DIEM_DG_NL=DIEM_DG_S')" runat="server" Width="100px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm ĐG sau khi nhân hệ số" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_s" runat="server" CssClass="css_Gma" Width="120px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá(CBQL)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem_dg_ql" onkeyup="tinhtong_nl_ct_P_KTRA('TI_TRONG,DIEM_DG_QL=DIEM_DG_S_QL')" runat="server" CssClass="css_Gma" />
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
                            <span class="standard_label b_left col_50">Điểm TB năng lực tự đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DIEM_TB_NL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Điểm trung bình năng lực tự đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả tự đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="KETQUA_XL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả tự đánh giá" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Điểm TB năng lực QL đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DIEM_TB_NL_QL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Điểm TB năng lực QL đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Kết quả xếp loại CBQL đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ketqua_cb_dgia" runat="server" kieu_unicode="true" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả xếp loại CBQL đánh giá" Enabled="false" />
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
                                <Cthuvien:ma ID="xeploai" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kieu_unicode ="true" kt_xoa="X"
                                    ten="Xếp loại đánh giá" Enabled="false" />
                            </div>
                        </div>
<%--                        <div class="b_left form-group iterm_form" style="display:none;">
                            <span class="standard_label b_left col_50">Hệ số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="heso" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kieu_unicode ="true" kt_xoa="X"
                                    ten="Xếp loại đánh giá" Enabled="false" />
                            </div>
                        </div>--%>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="TRANGTHAI" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI"
                                    Enabled="false" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Nhận xét của CBQL</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="nd" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="ns_cb_dgia_kpi_nv_P_NH('');form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="gui" runat="server" Width="80px" Text="Gửi" OnClick="return ns_cb_dgia_kpi_nv_P_GUI();form_P_LOI();" />--%>
                        <%--<Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_cb_dgia_kpi_nv_P_XOA();form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="xacnhan" class="bt_action" anh="K" runat="server" Width="80px" Text="Xác nhận" OnClick="return ns_cb_dgia_kpi_nv_P_NH('XN');form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap3" class="bt_action" anh="K" runat="server" Width="80px" Text="In" OnClick="return ns_cb_dgia_kpi_nv_P_PRINT();form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="guilai" runat="server" Width="80px" Text="Gửi lại" OnClick="return ns_cb_dgia_kpi_nv_P_XACNHAN_GUILAI('TC');form_P_LOI();" />--%>


                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                            <Cthuvien:nhap ID="Nhap4" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="nam_tk_an" runat="server" />
    <Cthuvien:an ID="ky_dg_tk_an" runat="server" />
    <Cthuvien:an ID="trangthai_tk_an" runat="server" />
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1370,850" />
</asp:Content>
