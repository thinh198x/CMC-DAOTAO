<%@ Page Title="tl_tlap_lamthem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_lamthem.aspx.cs" Inherits="f_tl_tlap_lamthem" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Hệ số làm thêm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="so_id" hamRow="tl_tlap_lamthem_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_tlap_lamthem_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="form-control icon_lich" kt_xoa="G" kieu_luu="S"
                                    ten="Ngày hiệu lực" onchange="tl_tlap_lamthem_P_KTRA('NGAY')" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="N" cot="ma,ten,lamthem,lamdem,mota" cotAn="ma,mota" hangKt="10" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderStyle-Width="18px" />
                                    <asp:BoundField HeaderText="Loại làm thêm" DataField="ten" HeaderStyle-Width="120px" />
                                    <asp:TemplateField HeaderText="Tỷ lệ làm thêm(%) (*)" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="lamthem" MaxLength="5" runat="server" Width="100%" CssClass="css_Gma_c" so_tp="1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ làm đêm(%) (*)" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="lamdem" MaxLength="5" runat="server" Width="100%" so_tp="2" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="mota" HeaderStyle-Width="18px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" Width="90px" OnClick="return tl_tlap_lamthem_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" Width="90px" OnClick="return tl_tlap_lamthem_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" Width="90px" OnClick="return tl_tlap_lamthem_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="690,400" />
    </div>
</asp:Content>
