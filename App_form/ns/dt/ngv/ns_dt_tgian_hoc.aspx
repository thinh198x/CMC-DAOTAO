<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tgian_hoc.aspx.cs" Inherits="f_ns_dt_tgian_hoc"
    Title="ns_dt_tgian_hoc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thời gian học tập giảng dạy" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_50 inner" id="UPa_tk" style="display: none;">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" ten="Bảng công" runat="server" Width="180px" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="ns_dt_tgian_hoc_P_KTRA('TRANGTHAI_TK')" />
                            </div>
                        </div>
                        <div class="b_right form-group lv2 iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" OnClick="return ns_dt_tgian_hoc_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="width: 650px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id,gchu,tt" cot="so_the,ten,ngay_dky,loai_dky,sophut,tinhtrang,so_id,gchu,tt" hamRow="ns_dt_tgian_hoc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_dky" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại đăng ký" DataField="LOAI_DKY" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số phút" DataField="SOPHUT" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="gchu" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_tgian_hoc_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" ten="Năm" MaxLength="30" onchange="ns_dt_tgian_hoc_P_KTRA('NAM')" runat="server" CssClass="form-control css_ma" kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Mã cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" MaxLength="30" ReadOnly="true" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" BackColor="#f6f7f7" Enabled="false" runat="server" CssClass="form-control css_ma"  ReadOnly="true" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin thời gian học tập, giảng dạy</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">TL tham dự ĐT tối thiếu Inclass</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt_iclas_hv" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">TL tham dự ĐT tối thiếu OJT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt_ojt_hv" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng TL tham dự ĐT tối thiếu</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt_hv" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">TL giảng dạy tối thiểu Inclass</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt_iclas" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">TL giảng dạy tối thiểu OJT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt_ojt" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng TL giảng dạy tối thiểu</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_gd_tt" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Số giờ học tập thực tế Inclass</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt_iclas_hv" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số giờ học tập thực tế OJT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt_ojt_hv" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số giờ học tập thực tế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt_hv" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Số giờ giảng dạy thực tế Inclass</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt_iclas" Enabled="false" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số giờ giảng dạy thực tế OJT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt_ojt" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số giờ giảng dạy thực tế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_hoctap_tt" runat="server" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none;">
                        <Cthuvien:DR_list ID="LOAI_DKY" ten="Loại đăng ký" runat="server" lke="Đăng ký đi muộn,Đăng ký về sớm" tra="DM,VS" kt_xoa="X" />
                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_DKY" ten="Ngày đăng ký" runat="server" Width="125px" CssClass="form-control css_ma_c" kieu_luu="S"
                            kt_xoa="X" />
                        <Cthuvien:ma ID="giod" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" />
                        <Cthuvien:ma ID="gioc" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_dt_tgian_hoc_P_KTRA('GIOC')" Width="150px" />
                        <Cthuvien:ma ID="SOPHUT" ten="Số phút" Enabled="false" runat="server" kt_xoa="X" CssClass="form-control css_ma_c" />
                        <Cthuvien:nd ID="gchu" ten="Lý do" runat="server" CssClass="form-control css_ma" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                            Width="382px" kt_xoa="X" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Nhập" OnClick="return ns_dt_tgian_hoc_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="60px" Text="Mới" OnClick="return ns_dt_tgian_hoc_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="60px" Text="Xóa" OnClick="return ns_dt_tgian_hoc_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_dt_tgian_hoc_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu2" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,500" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
