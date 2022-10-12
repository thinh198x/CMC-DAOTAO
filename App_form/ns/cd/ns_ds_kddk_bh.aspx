<%@ Page Title="ns_ds_kddk_bh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ds_kddk_bh.aspx.cs" Inherits="f_ns_ds_kddk_bh" %>

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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách không đủ điều kiện đóng bảo hiểm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" kieu_chu="true" gchu="gchu" ten="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma runat="server" ID="ten" kieu_unicode="true" CssClass="form-control css_ma"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="NS_DS_KDDK_BH_P_NAM('NAM');"
                                    runat="server" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ công lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kyluong_tk" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="ns_ds_kddk_bh_P_KTRA('KYLUONG_TK')" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="120px" OnClick="NS_DS_KDDK_BH_P_LKE('K');form_P_LOI('');" Title="Tìm kiếm" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="lhd,cdanh,phong,ma_ky" cot="chon,so_the,ten,ten_cdanh,ten_phong,luongbh,loai_hd,ky_luong,trangthai,is_nldd,lhd,cdanh,phong,ma_ky" hangKt="14" Width="100%">
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
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="90px" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lương đóng bảo hiểm" DataField="luongbh" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Hợp đồng LD" DataField="loai_hd" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px"/>
                                    <asp:BoundField HeaderText="Kỳ công lương" DataField="ky_luong" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px"/>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="Người lao động đóng BH" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="is_nldd" runat="server" Width="60px" CssClass="css_Gma_c" Text="X" lke="X," />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="lhd" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="cdanh" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="phong" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ma_ky" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Lưu" Width="90px" class="bt_action" anh="K" OnClick="return NS_DS_KDDK_BH_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
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
        <Cthuvien:an ID="aky" runat="server" Value="0" />
    </div>
</asp:Content>
