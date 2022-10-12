<%@ Page Title="ns_khaibao_dm" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_khaibao_dm.aspx.cs" Inherits="f_ns_khaibao_dm" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khai báo đóng mới bảo hiểm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tháng khai biến động <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="THANGBIENDONG" ten="Tháng khai biến động" runat="server" CssClass="form-control icon_lich" kt_xoa="X" onchange="NS_KHAIBAO_DM_P_KTRA('thang_bd')" />
                            </div>
                        </div>

                    </div>
                    <div class="width_common pv_bl"><span>Thông tin tìm kiếm</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tháng ký hợp đồng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="thang_bd" ten="Tháng biến động" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang" runat="server" CssClass="form-control css_list" lke="Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra="0,1,2" ten="Trạng thái" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma runat="server" ID="ten" kieu_unicode="true" CssClass="form-control css_ma"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="120px" OnClick="NS_KHAIBAO_DM_P_KTRA('TINHTRANG');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="lhd" cot="chon,so_the,ten,Cdanh,luongbh,ngayhl,loai_hd,is_bhxh,is_bhyt,is_bhtn,lhd" hangKt="14" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="Cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lương đóng bảo hiểm" DataField="luongbh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayhl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Hợp đồng LD" DataField="loai_hd" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="BHXH" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="is_bhxh" runat="server" Width="60px" CssClass="css_Gma_c" Text="X" lke="X," Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BHYT" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="is_bhyt" runat="server" Width="60px" CssClass="css_Gma_c" Text="X" lke="X," Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BHTN" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="is_bhtn" runat="server" Width="60px" CssClass="css_Gma_c" Text="X" lke="X," Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="lhd" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="pheduyet" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px"
                            Text="Phê duyệt" OnClick="return NS_KHAIBAO_DM_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="khongpheduyet" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="130px"
                            Text="Không phê duyệt" OnClick="return NS_KHAIBAO_DM_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="acheckall" runat="server" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,680" />
        <Cthuvien:an ID="aphong" runat="server" Value="1" />
    </div>
</asp:Content>
