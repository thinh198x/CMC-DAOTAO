<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_gt.aspx.cs" Inherits="f_ns_cc_gt"
    Title="ns_cc_gt" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Giải trình chấm công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng/Bộ phận <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" runat="server" CssClass="form-control css_list" onchange="ns_cc_gt_P_KTRA('PHONG')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ban</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="BAN" ktra="DT_BAN" runat="server" CssClass="form-control css_list" onchange="ns_cc_gt_P_KTRA('BAN')"
                                    kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" CssClass="form-control css_list" ktra="DT_NAM" kt_xoa="K"
                                    onchange="ns_cc_gt_P_KTRA('NAM')" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_15">Kỳ lương <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" CssClass="form-control css_list" ktra="DT_KYLUONG"
                                    onchange="ns_cc_gt_P_KTRA('KYLUONG')" kt_xoa="G" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Width="100px" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_cc_gt_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:DR_list ID="trangthai_tk" ten="Bảng công" runat="server" Width="140px" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="ns_cc_gt_P_KTRA('TRANGTHAI_TK')" />
                        <Cthuvien:nhap ID="tims" runat="server" Width="100px" Text="Tìm kiếm" OnClick="return ns_cc_gt_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="padding-top: 10px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="tinhtrang,so_id,tt" cot="so_the,ten,cdanh,phong,ngay_gt,giod,gioc,macc_nghi,ly_do,tinhtrang,so_id,tt" hamRow="ns_cc_gt_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="phong" />
                                    <asp:BoundField HeaderText="Ngày giải trình" DataField="ngay_gt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Giờ vào" DataField="giod" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Giờ ra" DataField="gioc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã công" DataField="macc_nghi" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Lý do giải trình" DataField="LY_DO" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="160px" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="tt" DataField="tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_gt_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>                
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,630" />
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="aphong" runat="server" Value="TATCA" />
    <Cthuvien:an ID="akyluong" runat="server" Value="" />
</asp:Content>
