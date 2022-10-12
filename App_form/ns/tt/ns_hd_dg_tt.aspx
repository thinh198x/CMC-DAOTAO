<%@ Page Title="ns_hd_dg_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hd_dg_tt.aspx.cs" Inherits="f_ns_hd_dg_tt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá HĐLĐ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" ten="Tên vị trí chức danh" ToolTip="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ten="Họ tên" ToolTip="Họ tên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ten="Phòng ban" ToolTip="Phòng ban" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ten="Chức danh" ToolTip="Chức danh" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại hợp đồng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_lhd" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ten="Loại hợp đồng" ToolTip="Loại hợp đồng" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày bắt đầu</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ngayd" runat="server" CssClass="form-control icon_lich" kieu_unicode="true" ten="Ngày bắt đầu" ToolTip="Ngày bắt đầu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ngayc" runat="server" CssClass="form-control icon_lich" kieu_unicode="true" ten="Ngày kết thúc" ToolTip="Ngày kết thúc" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Báo cáo kết quả công việc đã thực hiện</span></div>
                    <div class="grid_table width_common">
                        <div style="height: 100px; width: 100%; overflow-y: scroll">
                            <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" Width="100%"
                                CssClass="table gridX" hangKt="19"
                                cot="SOTT,CONG_VIEC,MO_TA,NGUOI_HD,NGUOI_PH,ket_qua">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT(*)" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="SOTT" runat="server" CssClass="css_Gma_c" kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Công việc(*)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="CONG_VIEC" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mô tả phương thức thực hiện(*)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="MO_TA" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Người hướng dẫn(*)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="NGUOI_HD" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Người phối hợp thực hiện(*)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="NGUOI_PH" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Kết quả đạt được" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ket_qua" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>

                    </div>
                    <div class="width_common pv_bl"><span>Các tiêu chuẩn yêu cầu</span></div>
                    <div class="grid_table width_common">
                        <div style="height: 100px; width: 100%; overflow-y: scroll">
                            <Cthuvien:GridX ID="GR_qhcv" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" Width="100%"
                                CssClass="table gridX" hangKt="19"
                                cot="sott,noi_dung,yeu,kem,trung_binh,kha,xuat_sac,ghi_chu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="sott" runat="server" CssClass="css_Gma_c" kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="noi_dung" runat="server" CssClass="css_Gma" kt_xoa="X" Width="120px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Yếu" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="yeu" runat="server" CssClass="css_Gma_c" lke="X," kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Kém" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="kem" runat="server" CssClass="css_Gma_c" lke="X," kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Trung bình" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="trung_binh" runat="server" CssClass="css_Gma_c" lke="X," kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Khá" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="kha" runat="server" CssClass="css_Gma_c" lke="X," kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Xuất sắc" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="xuat_sac" runat="server" CssClass="css_Gma_c" lke="X," kt_xoa="X" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghi_chú" runat="server" Width="150px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </Cthuvien:GridX>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left mgt10 form-group iterm_form">
                            <span class="standard_label b_left col_30">Thuận lợi, khó khăn trong QT làm việc</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="thuanloi_khokhan" runat="server" Multiline="true" CssClass="form-control css_ma" kt_xoa="G" Height="35px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>


                    <div class="width_common pv_bl"><span>Ý kiến đóng góp/Đề xuất</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Về công việc</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="yk_congviec" runat="server" Multiline="true" CssClass="form-control css_ma" kt_xoa="G" Height="35px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Về chính sách</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="yk_chinhsach" runat="server" Multiline="true" CssClass="form-control css_ma" kt_xoa="G" Height="35px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Nhu cầu đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="yk_daotao" runat="server" Multiline="true" CssClass="form-control css_ma" kt_xoa="G" Height="35px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Vấn đề khác</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="yk_khac" runat="server" Multiline="true" CssClass="form-control css_ma" kt_xoa="G" Height="35px" ten="Vấn đề khác" ToolTip="Vấn đề khác" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <button onclick="return ns_hd_dg_tt_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button onclick="return ns_hd_dg_tt_P_MOI();form_P_LOI();" class="bt_action"><span class="txUnderline">M</span>ới</button>
                        <button class="bt_action" onclick="return ns_hd_dg_tt_P_GUI();form_P_LOI();"><span class="txUnderline">G</span>ửi</button>

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,820" />
    </div>
</asp:Content>
