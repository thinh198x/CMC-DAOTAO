<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_gt_cc.aspx.cs" Inherits="f_ns_gt_cc"
    Title="ns_gt_cc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Giải trình chấm công của CBNV" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM_TK" ten="Năm" ktra="DT_NAM_TK" CssClass="form-control css_list" kt_xoa="M" onchange="ns_gt_cc_P_KTRA('NAM_TK')" runat="server" > </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ lương <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_TK" ten="Kỳ lương" CssClass="form-control css_list" ktra="DT_KYLUONG_TK" kt_xoa="N" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" ten="Bảng công" runat="server"  CssClass="form-control css_list" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="ns_gt_cc_P_KTRA('TRANGTHAI_TK')" />
                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Width="100px" Text="Tìm kiếm" OnClick="return ns_gt_cc_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="17" cotAn="so_id,tt" cot="so_the,ten,ngay_gt,giod,gioc,LY_DO,tinhtrang,so_id,tt" hamRow="ns_gt_cc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten"  HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày giải trình" DataField="ngay_gt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Giờ vào" DataField="giod" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Giờ ra" DataField="gioc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Lý do" DataField="LY_DO" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="160px" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="tt" DataField="tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_gt_cc_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" MaxLength="30" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                    kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_gt_cc_P_KTRA('SO_THE')"  />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="form-control css_ma"  kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="K" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" ktra="DT_NAM" kt_xoa="M" CssClass="form-control css_list" onchange="ns_gt_cc_P_KTRA('NAM')" runat="server" >                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ lương <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" ktra="DT_KYLUONG"  CssClass="form-control css_list" kt_xoa="U" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày giải trình*</span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAY_GT"  placeholder='dd/MM/yyyy' ten="Ngày giải trình" runat="server" onchange="ns_gt_cc_P_KTRA('NGAY_GT')" CssClass="form-control icon_lich" kieu_luu="S" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã chấm công <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MACC_NGHI" ktra="DT_KIEUNGHI" ten="Mã chấm công" runat="server" CssClass="form-control css_list" kt_xoa="X">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Giờ vào</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="giod" ten="Giờ vào" MaxLength="30" runat="server" kt_xoa="X" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_gt_cc_P_KTRA('GIOD')"  />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Giờ ra</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="gioc" ten="Giờ ra" MaxLength="30" runat="server" kt_xoa="X" CssClass="form-control css_ma_c" kieu_chu="True" onchange="ns_gt_cc_P_KTRA('GIOC')" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ly_do" ten="Lý do" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập" OnClick="return ns_gt_cc_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="60px" Text="Mới" OnClick="return ns_gt_cc_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="60px" Text="Xóa" OnClick="return ns_gt_cc_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_gt_cc_P_GUI();form_P_LOI();" />

                        <div style="display: none">
                            <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu2" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1230,630" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
