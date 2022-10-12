<%@ Page Title="ns_hd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cb_chon.aspx.cs" Inherits="f_ns_cb_chon" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_content">
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chọn nhân viên" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai_tk" onchange="ns_cb_chon_P_KTRA('PHONG_TK')" CssClass="form-control css_list"
                                    ten="Trạng thái" runat="server" kieu="S" tra="0,1" lke="Làm việc,Nghỉ việc" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ktra="DT_PH" runat="server" CssClass="form-control css_list" onchange="cc_dulieu_vaora_P_KTRA('PHONG')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" runat="server" kieu_unicode="true" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_cb_chon_P_LKE();form_P_LOI();" Width="103px" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" cot="so_the,ten,ten_cdanh,ten_phong,ngayd,phong,cdanh,so_id" cotAn="phong,cdanh,so_id" hangKt="15" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày vào công ty" DataField="ngayd" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" />
                                    <asp:BoundField HeaderText="Số Id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cb_chon_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <div align="center">
                            <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON_GRID('GR_lke:so_the,GR_lke:ten,GR_lke:phong,GR_lke:ten_phong,GR_lke:ngayd,GR_lke:cdanh,GR_lke:ten_cdanh,GR_lke:nsinh,GR_lke:so_id');form_P_LOI();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

