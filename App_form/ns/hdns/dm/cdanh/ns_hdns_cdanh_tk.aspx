<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_cdanh_tk.aspx.cs" Inherits="f_ns_hdns_cdanh_tk"
    Title="ns_hdns_cdanh_tk" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Hiển thị chức danh của công ty" />
                <img class="b_right" src="../../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="col_3_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Tên chức danh</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_tk" ten="Tên chức danh" runat="server" CssClass="form-control css_ma" kieu_chu="true" kieu_unicode="true"></Cthuvien:ma>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Trạng thái <span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                </div>
                            </div>
                        </div>
                        <div class="b_left lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" anh="K" class="bt_action" Width="100px" OnClick="return ns_hdns_cdanh_tk_P_LKE();form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N" Width="100%"
                                cot="CHON,MA_CD,TEN,TEN_TT,SO_ID_CD,MA_CDANH_DVI,ma,ten_nnn" cotAn="SO_ID_CD,MA_CDANH_DVI,ma,ten_nnn" hangKt="20">
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
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="MA_CD" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="TEN" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="TEN_TT" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="SO_ID_CD" />
                                    <asp:BoundField DataField="MA_CDANH_DVI" />
                                    <asp:BoundField DataField="ma" />
                                    <asp:BoundField DataField="ten_nnn" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" anh="K" class="bt_action" Width="90px" OnClick="return form_P_TRA_LIST();form_P_LOI();" />

                        <div style="display: none;">
                            <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" anh="K" class="bt_action" Width="100px" OnClick="return ns_hdns_cdanh_tk_P_EXCEL();form_P_LOI();" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                            <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="nnn" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="800,600" />
        <Cthuvien:an ID="acheckall" runat="server" />
    </div>
</asp:Content>
