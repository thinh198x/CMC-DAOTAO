<%@ Page Title="dg_dm_dtdg" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_dm_dtdg.aspx.cs" Inherits="f_dg_dm_dtdg" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập đối tượng được đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="dg_dm_dtdg_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_ad" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <%--  <asp:BoundField HeaderText="nhóm" DataField="nhom_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="danh" DataField="cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="bac" DataField="capbac" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />--%>
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_dtdg_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_dm_dtdg_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_dm_dtdg_P_KTRA('KY_DG');" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group width_common iterm_form">
                            <span class="standard_label b_left col_40">Ngày áp dụng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" ten="Ngày đánh giá" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="ma_cd,ten,capbac,thamnien,ghichu" hangKt="17" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <%--<asp:TemplateField HeaderText="Nhóm chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="nhom_cdanh" ktra="DT_NHOM_CDANH" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X" ten="Nhóm chức danh"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X"
                                                f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" Width="100%" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh" runat="server" Width="100%" CssClass="css_Glist" ktra="ns_cdanh_P_LIST()"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Cấp bậc" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="capbac" ktra="DT_CAPBAC" runat="server" CssClass="css_Glist" Width="100%"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thâm niên (tháng)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="thamnien" runat="server" CssClass="css_Gso" Width="80px" gchu="thâm niên" kieu_so="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" CssClass="css_Gma" Width="130px" ten="Ghi chú" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" loai="N" runat="server" gridId="GR_ct" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="100px" class="bt_action" anh="K" OnClick="return dg_dm_dtdg_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Ghi" OnClick="return dg_dm_dtdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa" OnClick="return dg_dm_dtdg_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1280,550" />
</asp:Content>
