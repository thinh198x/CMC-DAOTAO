<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_lydobhxh.aspx.cs" Inherits="f_ns_ma_lydobhxh"
    Title="ns_ma_lydobhxh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục chế độ bảo hiểm" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cot="ma_nhom,ten_nhom,ma,ten,songay_huong,muchuong,trangthai,ten_trangthai,nsd,luyke"
                                cotAn="ma_nhom,trangthai,nsd,luyke,songay_huong,muchuong" hamRow="ns_ma_lydobhxh_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nhóm chế độ" DataField="ma_nhom">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Nhóm chế độ">
                                        <ItemTemplate>
                                            <Cthuvien:ma runat="server" ID="ten_nhom" Enabled="false" ReadOnly="true" Width="200px" CssClass="css_Gma"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã chế độ" DataField="ma" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tên chế độ">
                                        <ItemTemplate>
                                            <Cthuvien:ma runat="server" ID="ten" Enabled="false" ReadOnly="true" Width="200px" CssClass="css_Gma"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Số ngày hưởng" DataField="songay_huong" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức hưởng" DataField="muchuong" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="luyke" DataField="luyke">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_lydobhxh_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
						 <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
					</div> 
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Nhóm chế độ <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_NHOM" ktra="DT_NS_MA_LYDOBHXH" runat="server" CssClass="form-control css_list" onchange="ns_ma_lydobhxh_P_LKE('K');" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã chế độ <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã chế độ" runat="server" CssClass="form-control css_ma" kieu_chu="True"
                                kt_xoa="G" onchange="ns_ma_lydobhxh_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên chế độ <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên chế độ" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tổng số ngày</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="songay_huong" ten="Tổng số ngày" runat="server" kieu_so="true" CssClass="form-control css_ma" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mức hưởng</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="muchuong" ten="Mức hưởng" runat="server" kieu_so="true" CssClass="form-control css_ma" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label b_left col_30"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="luyke" ten="Tên" runat="server" CssClass="disable" lke=",X" kt_xoa="X" Width="20px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ma_lydobhxh_P_NH();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_lydobhxh_P_MOI();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_lydobhxh_P_XOA();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="80px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1060,500" />
</asp:Content>
