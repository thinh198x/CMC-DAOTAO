<%@ Page Title="tl_tlap_gtru_banthan" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_gtru_banthan.aspx.cs" Inherits="f_tl_tlap_gtru_banthan" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập giảm trừ bản thân" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="10" hamRow="tl_tlap_gtru_banthan_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Giá trị" DataField="giatri" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_tlap_gtru_banthan_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich css_ngay" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Giá trị</span>
                            <div class="input-group">
                                <Cthuvien:so ID="GIATRI" MaxLength="15" runat="server" CssClass="form-control css_so" kt_xoa="X"
                                    ten="Giá trị" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return tl_tlap_gtru_banthan_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return tl_tlap_gtru_banthan_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return tl_tlap_gtru_banthan_P_XOA();form_P_LOI();" Width="70px" anh="K" />
                    </div>
                </div>
            </div>


        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="600,540" />
    </div>
</asp:Content>
