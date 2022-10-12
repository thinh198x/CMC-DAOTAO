<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_luong_imp.aspx.cs" Inherits="f_tl_luong_imp"
    Title="tl_luong_imp" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Các khoản phát sinh khác" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="close" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam" ten="Năm" runat="server" onchange="tl_luong_imp_P_NAM();" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kyluong" ten="Kỳ lương" runat="server" CssClass="form-control css_list" onchange="tl_luong_imp_P_KTRA('KYLUONG')" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" runat="server" ten="Phòng" CssClass="form-control css_list" onchange="tl_luong_imp_P_KTRA('PHONG')" ktra="DT_PHONG" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Loại lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="nhomluong" ten="Loại lương" lke="Bảng lương khối Back,Bảng lương khối Sale,Bảng lương cộng tác viên BB,Bảng lương cộng tác viên BS,Bảng lương thực tập sinh"
                                    tra="BACK,SALE,BB,BS,TTS" runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0"
                                OnClick="return tl_luong_imp_P_LKE();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,TEN_NHOMLUONG,ghichu"
                                cot="so_the,ten,ten_phong,ten_cdanh,TEN_NHOMLUONG,ten_ml,giatri,ghichu"
                                hamRow="tl_luong_imp_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên NV" DataField="ten" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nhóm lương" DataField="ten_phong" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nhóm lương" DataField="TEN_NHOMLUONG" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mục lương" DataField="ten_ml" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Giá trị" DataField="giatri" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma_r" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ghi chú" DataField="ghichu" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_luong_imp_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="File mẫu" Class="bt_action" OnClick="return tl_luong_imp_Export();form_P_LOI();" Width="80px" anh="K" />
                        <Cthuvien:nhap ID="imp" runat="server" Text="Import" Class="bt_action" OnClick="return tl_luong_imp_Import();form_P_LOI();" Width="80px" anh="K" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="xuatexcel" runat="server" Text="File mẫu" Class="bt_action" OnServerClick="nhap_Click" Width="80px" anh="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1060,770" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
        <Cthuvien:an ID="anhomluong" runat="server" />
    </div>
</asp:Content>
