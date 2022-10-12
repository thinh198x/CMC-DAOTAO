<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_truonghoc.aspx.cs" Inherits="f_ns_ma_truonghoc"
    Title="ns_ma_truonghoc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục tên trường" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="trangthai,ghichu,nsd" hamRow="ns_ma_truonghoc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã trường" DataField="ma" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên trường" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_trangthai" HeaderText="Trạng thái" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_ma_truonghoc_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ma_truonghoc_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mã trường<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã trường" runat="server" CssClass="form-control css_ma" kieu_chu="True" MaxLength="20"
                                kt_xoa="G" onchange="ns_ma_truonghoc_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tên trường<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="Tên trường" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="100" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Mô tả" TextMode="MultiLine" Height="50px" runat="server" CssClass="form-control css_nd"
                                kieu_unicode="True" kt_xoa="X" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_truonghoc_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_truonghoc_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" hoi="4" class="bt_action" anh="K" OnClick="return ns_ma_truonghoc_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="import" runat="server" Width="80px" class="bt_action" anh="K" Text="Import" OnClick="return ns_ma_truonghoc_P_IMPORT();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_truonghoc_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="FileMau" runat="server" Text="Mẫu excel" Width="90px" OnServerClick="FileMau_Click" />
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="100px" OnServerClick="XuatExcel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,530" />
</asp:Content>
