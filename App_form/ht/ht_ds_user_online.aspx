<%@ Page Title="ht_ds_user_online" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ht_ds_user_online.aspx.cs" Inherits="f_ht_ds_user_online" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách user online" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tài khoản" DataField="ma" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="70px" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="180px" />
                                    <asp:BoundField HeaderText="Email" DataField="email" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Số điện thoại" DataField="dtdd" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="120px" />
                                    <asp:BoundField HeaderText="Thời gian đăng nhập" DataField="time_login" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Thời gian thoát" DataField="time_off" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_ds_user_online_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action" style="display: none;">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" onclick="checkEmpty()" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="UPa_hi">
            <Cthuvien:an ID="kthuoc" runat="server" Value="1390,780" />
        </div>
    </div>
</asp:Content>
