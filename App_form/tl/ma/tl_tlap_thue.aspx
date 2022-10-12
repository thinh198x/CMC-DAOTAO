<%@ Page Title="tl_tlap_thue" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_thue.aspx.cs" Inherits="f_tl_tlap_thue" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục thuế thu nhập cá nhân" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>

            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="dt_cutru,so_id" hamRow="tl_tlap_thue_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Đối tượng cư trú" DataField="ten_dt_cutru" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đối tượng cư trú" DataField="dt_cutru" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_tlap_thue_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Text="Xuất excel" class="bt_action" OnServerClick="nhap_Click" Width="100px" anh="K" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Đối tượng cư trú</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="DT_CUTRU" runat="server" Width="150px" ten="Đối tượng cư trú" tra="CT,KCT"
                                    lke="Đối tượng cư trú,Đối tượng không cư trú" kt_xoa="K" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="thunhaptu,thunhapden,thuesuat" hangKt="8" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Thu nhập từ (*)">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="thunhaptu" MaxLength="10" runat="server" kt_xoa="G" Text="0" nhap="true" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thu nhập đến (*)">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="thunhapden" MaxLength="10" runat="server" CssClass="css_Gso" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thuế suất (%)(*)">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="thuesuat" MaxLength="2" runat="server" CssClass="css_Gma_c" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return tl_tlap_thue_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return tl_tlap_thue_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return tl_tlap_thue_P_XOA();form_P_LOI();" Width="70px" anh="K" />

                    </div>
                </div>

            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="950,490" />
    </div>
</asp:Content>
