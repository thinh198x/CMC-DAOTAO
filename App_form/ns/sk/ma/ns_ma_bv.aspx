<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_bv.aspx.cs" Inherits="f_ns_ma_bv"
    Title="ns_ma_bv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục nơi khám chữa bệnh" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" cot="ma,ten,dchi,ten_tinhthanh,tinhthanh,ten_quanhuyen,quanhuyen,ten_trangthai,trangthai,nsd"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="tinhthanh,quanhuyen,trangthai,nsd" hamRow="ns_ma_bv_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã bệnh viện" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tên bệnh viện" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma runat="server" ID="ten" Enabled="false" Width="200px" ReadOnly="true" CssClass="css_Gma"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Địa chỉ" DataField="dchi" HeaderStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField HeaderText="Thành phố" DataField="ten_tinhthanh" HeaderStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField HeaderText="mã tinh thành" DataField="tinhthanh"></asp:BoundField>
                                    <asp:BoundField HeaderText="Quận huyện" DataField="ten_quanhuyen" HeaderStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField HeaderText="mã quận huyện" DataField="quanhuyen"></asp:BoundField>
                                    <asp:BoundField HeaderText="Tên trạng thái" DataField="ten_trangthai" HeaderStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai"></asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd"></asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_bv_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnClick="return ns_ma_bv_P_IN();form_P_LOI();" Width="120px" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_30">Mã <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                onchange="ns_ma_bv_P_KTRA('MA')" ten="Mã bệnh viện" />
                            <Cthuvien:an ID="NN" runat="server" Value="QG001" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Tên bệnh viện <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Tên bệnh viện" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dchi" ten="Địa chỉ bệnh viện" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Tỉnh/Thành phố</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="tinhthanh" ten="Tỉnh/Thành phố" runat="server" CssClass="form-control css_list" kt_xoa="X"
                                onchange="ns_ma_bv_P_KTRA('tinhthanh')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                        </div>
                    </div>

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Quận/Huyện</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="quanhuyen" ten="Quận/Huyện" runat="server" CssClass="form-control css_list" kt_xoa="X"
                                ToolTip="Quận/Huyện" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ma_bv_P_NH();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_bv_P_MOI();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_bv_P_XOA();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN,DCHI');form_P_LOI();" Width="80px" />
                    </div>
                    <div style="display: none;">
                           <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1280,600" />
</asp:Content>
