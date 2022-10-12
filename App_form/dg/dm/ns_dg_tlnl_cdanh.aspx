<%@ Page Title="ns_dg_tlnl_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_tlnl_cdanh.aspx.cs" Inherits="f_ns_dg_tlnl_cdanh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập năng lực đánh giá theo nhóm chức danh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nam,ky_dg,so_id" hamRow="ns_dg_tlnl_cdanh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="nhom_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_ad" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dg_tlnl_cdanh_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam" ten="Năm" runat="server" ktra="DT_NAM" CssClass="css_list" Width="157px" onchange="ns_dg_tlnl_cdanh_P_NAM();" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" CssClass="css_list" Width="200px" onchange="ns_dg_tlnl_cdanh_P_KTRA('KY_DG');" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Nhóm chức danh<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NCD" ten="Nhóm chức danh" runat="server" ktra="DT_NCD" onchange="ns_cdanh_P_LIST()" CssClass="form-control css_list" Width="157px" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày áp dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" runat="server" ten="Ngày áp dụng" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="N" cotAn="so_idct" cot="mota,tytrong,so_idct"
                            hangKt="14" gchuId="gchu">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Năng lực" HeaderStyle-Width="80%">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" ten="Mô tả" kieu_unicode="true" Width="100%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tỉ trọng" HeaderStyle-Width="20%">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="tytrong" runat="server" CssClass="css_Gma" ten="Tỉ trọng" kieu_so="true" Width="100%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số id chi tiết">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="so_idct" runat="server" CssClass="css_Gma" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dg_tlnl_cdanh_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dg_tlnl_cdanh_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_dg_tlnl_cdanh_P_XOA();form_P_LOI();" />
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1370,700" />
    </div>
</asp:Content>
