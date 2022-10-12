<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cc_cn_dky_dmvs.aspx.cs" Inherits="f_cc_cn_dky_dmvs"
    Title="cc_cn_dky_dmvs" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý đi muộn về sớm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" ten="Bảng công" runat="server" CssClass="form-control css_list" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="cc_cn_dky_dmvs_P_KTRA('TRANGTHAI_TK')" />
                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Width="120px" Text="Tìm kiếm" OnClick="return cc_cn_dky_dmvs_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,gchu,tt" cot="so_the,ten,ngay_dky,loai_dky,sophut,tinhtrang,so_id,gchu,tt" hamRow="cc_cn_dky_dmvs_GR_lke_RowChange()">
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
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_cn_dky_dmvs_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã cán bộ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" MaxLength="30" ReadOnly="true" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" ReadOnly="true" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại đăng ký <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_DKY" ten="Loại đăng ký" CssClass="form-control css_list" runat="server" lke="Đăng ký đi muộn,Đăng ký về sớm" tra="DM,VS" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày đăng ký <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAY_DKY" placeholder='dd/MM/yyyy' runat="server" kieu_luu="S" ten="Ngày đăng ký" CssClass="form-control icon_lich css_ma_c" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOD" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="cc_cn_dky_dmvs_P_KTRA('GIOD')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến giờ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOC" ten="Đến giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True" onchange="cc_cn_dky_dmvs_P_KTRA('GIOC')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Số phút <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SOPHUT" ten="Số phút" Enabled="false" runat="server" kt_xoa="X" CssClass="form-control css_ma_r" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Lý do</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" ten="Lý do" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập" OnClick="return cc_cn_dky_dmvs_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="60px" Text="Mới" OnClick="return cc_cn_dky_dmvs_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="60px" Text="Xóa" OnClick="return cc_cn_dky_dmvs_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return cc_cn_dky_dmvs_P_GUI();form_P_LOI();" />

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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1210,630" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
