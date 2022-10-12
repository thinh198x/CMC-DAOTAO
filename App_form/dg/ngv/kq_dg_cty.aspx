<%@ Page Title="kq_dg_cty" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="kq_dg_cty.aspx.cs" Inherits="f_kq_dg_cty" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kết quả đánh giá của công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kỳ đánh giá</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg1" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return kq_dg_cty_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,trangthai" hamRow="kq_dg_cty_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="kq_dg_cty_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G"
                                    onchange="kq_dg_cty_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    onchange="kq_dg_cty_P_LKE_ct('K')" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Loại đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loai_dg" ten="Loại đánh giá" runat="server" kieu="S" CssClass="form-control css_list" tra="0,1" lke="Đánh giá theo tháng,Đánh giá theo năm" />
                            </div>
                        </div>
                        <div class="grid_table width_common">
                            <div>
                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="N" cotAn="congty,ban_phong,phong_bophan,ten_phong_bophan,so_idct" hangKt="15" gchuId="gchu"
                                    cot="congty,ten_congty,ban_phong,ten_ban_phong,phong_bophan,ten_phong_bophan,xeploai_danhgia,so_idct" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã công ty" DataField="congty" />
                                        <asp:TemplateField HeaderText="Công ty" HeaderStyle-Width="40%">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_congty" runat="server" CssClass="css_Gma" gchu="Công ty" Width="100%" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã ban/phòng" DataField="ban_phong" />
                                        <asp:TemplateField HeaderText="Ban/Phòng" HeaderStyle-Width="40%">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_ban_phong" runat="server" CssClass="css_Gnd" Width="100%" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã phòng/bộ phận" DataField="phong_bophan" />
                                        <asp:TemplateField HeaderText="Phòng/Bộ phận">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_phong_bophan" runat="server" CssClass="css_Gnd" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Xếp loại đánh giá" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="xeploai_danhgia" ktra="ns_kq_dg_cty_P_LIST()" runat="server" CssClass="css_Glist" Width="100%" ten="Xếp loại đánh giá"></Cthuvien:DR_lke>
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
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return kq_dg_cty_P_MOI();form_P_LOI();" />
                            <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Nhập" OnClick="kq_dg_cty_P_NH();form_P_LOI();" />
                            <Cthuvien:nhap ID="yhuhkuhhk" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return kq_dg_cty_P_XOA();form_P_LOI();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
    </div>
</asp:Content>
