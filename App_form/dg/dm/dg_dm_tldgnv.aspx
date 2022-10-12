<%@ Page Title="dg_dm_tldgnv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_dm_tldgnv.aspx.cs" Inherits="f_dg_dm_tldgnv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập tỷ lệ xếp loại đánh giá nhân viên theo xếp loại bộ phận" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Công ty</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="cty_tk" ten="Công ty" runat="server" ktra="DT_CTY_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return dg_dm_tldgnv_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="dg_dm_tldgnv_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Công ty" DataField="cty" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_tldgnv_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Công ty</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cty" ten="Công ty" runat="server" ktra="DT_CTY" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" ten="Ngày hiệu lực"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="xeploai_bp,xeploai_xuatsac,xeploai_tot,xeploai_dat,xeploai_caithien,xeploai_kdat"
                                hangKt="15" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Xếp loại bộ phận">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="xeploai_bp" ktra="DT_XL_DG" runat="server" kt_xoa="G" CssClass="css_Glist" Width="100%"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ xuất sắc (A*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xeploai_xuatsac" runat="server" CssClass="css_Gma" gchu="Tỷ lệ xuất sắc (A*)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ tốt (A)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xeploai_tot" runat="server" CssClass="css_Gma" gchu="Tỷ lệ tốt (A)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ đạt (B)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xeploai_dat" runat="server" CssClass="css_Gma" gchu="Tỷ lệ đạt (B)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ cần cải thiện (C)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xeploai_caithien" runat="server" CssClass="css_Gma" ten="Tỷ lệ cần cải thiện (B)" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ không đạt (D)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xeploai_kdat" runat="server" CssClass="css_Gma" ten="Tỷ lệ không đạt (C)" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return dg_dm_tldgnv_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return dg_dm_tldgnv_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return dg_dm_tldgnv_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1320,810" />
    </div>
</asp:Content>
