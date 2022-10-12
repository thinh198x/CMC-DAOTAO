<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_cn_dky_lthem.aspx.cs" Inherits="f_ns_cc_cn_dky_lthem"
    Title="ns_cc_cn_dky_lthem" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đăng ký làm thêm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" ten="Trạng thái" runat="server" CssClass="form-control css_list" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="cc_cn_dky_dmvs_P_KTRA('TRANGTHAI_TK')" />
                            </div>
                            <div style="display: none;">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" Width="152px" CssClass="form-control css_ma" kieu_chu="true" />
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" Width="152px" CssClass="form-control css_ma" kieu_unicode="true" />
                                <Cthuvien:ngay ID="ngayd_tk" ten="Từ ngày" runat="server" CssClass="form-control css_ma_c" kieu_luu="S" Width="124px" />
                                <Cthuvien:ngay ID="ngayc_tk" ten="Đến ngày" runat="server" CssClass="form-control css_ma_c" kieu_luu="S" Width="124px" />
                                <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" onchange="ns_cc_cn_dky_lthem_P_NAM();" Width="152px" ktra="DT_PHONG" />
                                <Cthuvien:nhap ID="tims" runat="server" Width="120px" Text="Tìm kiếm" OnClick="ns_cc_cn_dky_lthem_P_LKE('K');form_P_LOI();" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_cc_cn_dky_lthem_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <div style="overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,hso,tt" hamRow="ns_cc_cn_dky_lthem_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Phòng" DataField="ten_phong" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày đăng ký" DataField="NGAY_BD" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Giờ bắt đầu" DataField="gio_bd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Giờ kết thúc" DataField="gio_kt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tình trạng" DataField="ten_tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Đối tượng nhập" DataField="dtuong_nh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField DataField="so_id" HeaderStyle-Width="2px" />
                                        <asp:BoundField DataField="hso" HeaderStyle-Width="2px" />
                                        <asp:BoundField HeaderText="Mã tình trạng" DataField="tt" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_cn_dky_lthem_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" placeholder="Nhấn (F1)" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7"
                                    kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_cc_cn_dky_lthem_P_KTRA('SO_THE')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="K" gchu="gchu" />
                            </div>
                            <div style="display: none">
                                <Cthuvien:ma ID="CDANH" Enabled="false" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div id="UPa_ngay" class="b_left lv2 form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày làm thêm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_BD" ten="Ngày làm thêm" runat="server" onchange="ns_cc_cn_dky_lthem_P_KTRA('NGAY_BD')" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none;">
                            <span class="standard_label lv2 b_left col_40">Hệ số <span class="require">*</span></span>
                            <div class="input-group">
                                <%--  <Cthuvien:DR_lke ID="hso" ktra="DT_HSO" kt_xoa="K" ten="Hệ số" runat="server" CssClass="form-control css_list">                                                                                
                                </Cthuvien:DR_lke>--%>
                                <Cthuvien:ma ID="hso" runat="server" Enabled="false" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Hình thức</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="hinhthuc" ten="Hình thức" BackColor="#f6f7f7" disabled="true" runat="server" CssClass="form-control" ReadOnly="true" lke="Ngày thường,Ngày cuối tuần,Ngày lễ" tra="T,C,H" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại làm thêm</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="lthem_theoluat" ten="Loại làm thêm" runat="server" CssClass="form-control css_list" disabled="disabled" lke="Theo luật,Không theo luật" tra="C,K" kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Có check vân tay</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="loai_lt" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_BD" ten="Từ giờ" runat="server" onchange="ns_cc_cn_dky_lthem_P_KTRA('GIO_BD')" kt_xoa="X" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_KT" ten="Đến giờ" onchange="ns_cc_cn_dky_lthem_P_KTRA('GIO_KT')" runat="server" kt_xoa="X" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                        <div style="display: none;">
                            <Cthuvien:ma ID="nghi_gct" ten="Giờ nghỉ từ" runat="server" onchange="ns_cc_cn_dky_lthem_P_KTRA('NGHI_GCT')" kt_xoa="X" CssClass="form-control css_ma_c"
                                Width="140px" />
                            <Cthuvien:ma ID="nghi_gcd" ten="Giờ nghỉ đến" onchange="ns_cc_cn_dky_lthem_P_KTRA('NGHI_GCD')" runat="server" kt_xoa="X" CssClass="form-control css_ma_c"
                                Width="150px" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số giờ nghỉ giữa ca </span>
                            <div class="input-group">
                                <Cthuvien:so ID="sogio_nghigiuaca" so_tp="2" ten="Số giờ nghỉ giữa ca" runat="server" kt_xoa="X" CssClass="form-control css_ma_r"
                                    onchange="ns_cc_cn_dky_lthem_P_KTRA('SOGIO_NGHIGIUACA')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số giờ LT ngày</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_gio_ngay" Enabled="false" disabled="disabled" BackColor="#f6f7f7" ten="LT ngày" runat="server" kt_xoa="X" CssClass="form-control css_ma_r" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số giờ LT đêm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_gio_dem" Enabled="false" runat="server" BackColor="#f6f7f7" disabled="disabled" CssClass="form-control css_ma_r" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số giờ LT ngày chuyển nghỉ bù</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_ngay_nb" ten="Số giờ LT ngày chuyển nghỉ bù" runat="server" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_cc_cn_dky_lthem_P_KTRA('SG_NGAY_NB')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số giờ LT đêm chuyển nghỉ bù</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sg_dem_nb" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" gchu="gchu" onchange="ns_cc_cn_dky_lthem_P_KTRA('SG_DEM_NB')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số giờ thêm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_gio_lt" Enabled="false" disabled="disabled" BackColor="#f6f7f7" ten="LT ngày" runat="server" kt_xoa="X" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số giờ chuyển nghỉ bù</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_gio_nb" runat="server" disabled="disabled" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số giờ được thanh toán</span>
                            <div class="input-group">
                                <Cthuvien:so ID="so_gio_tt" so_tp="2" Enabled="false" disabled="disabled" BackColor="#f6f7f7" ten="Số giờ làm thêm được thanh toán" onchange="ns_cc_dky_lthem_P_KTRA('SO_GIO_TT')" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do làm thêm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" Rows="2"
                                kt_xoa="X" Height="50px" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập" OnClick="return ns_cc_cn_dky_lthem_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="60px" Text="Mới" OnClick="return ns_cc_cn_dky_lthem_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="60px" Text="Xóa" OnClick="return ns_cc_cn_dky_lthem_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_cc_cn_dky_lthem_P_GUI();form_P_LOI();" />
                        <div style="display: none">
                            <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,640" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
