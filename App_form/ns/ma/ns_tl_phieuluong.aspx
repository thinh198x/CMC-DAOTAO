<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tl_phieuluong.aspx.cs" Inherits="f_ns_tl_phieuluong"
    Title="ns_tl_phieuluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập phiếu lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,cong_thuc,nsd,kieu_dl" hamRow="ns_tl_phieuluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="STT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="STT hiển thị" DataField="SOTT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã trường" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên trường" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_trangthai" HeaderText="Trạng thái" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="cong_thuc" />
                                    <asp:BoundField DataField="nsd" />
                                    <asp:BoundField DataField="kieu_dl" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_phieuluong_P_LKE()" />
                    </div>
                </div>
                <div class="b_left col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Sắp xếp</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="STT" runat="server" onchange="ns_tl_phieuluong_P_KTRA('STT')" ten="Số thứ tự" CssClass="form-control css_ma" kt_xoa="G" MaxLength="100" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Số TT hiển thị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SOTT" ten="Số TT hiển thị" runat="server" CssClass="form-control css_ma" kieu_chu="True" MaxLength="20"
                                    kt_xoa="X" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã trường</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã trường" runat="server" CssClass="form-control css_ma" kieu_chu="True" MaxLength="20"
                                    kt_xoa="X" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên trường</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" ten="Tên trường" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    MaxLength="100" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Kiểu dữ liệu</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="kieu_dl" runat="server" lke="Số,Ngày,ký tự" CssClass="form-control css_list" ten="Kiểu dữ liệu" tra="S,N,K" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TRANGTHAI" runat="server" lke="Áp dụng,Ngừng áp dụng" CssClass="form-control css_list" ten="Trạng thái" tra="A,N" Width="500px" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Công thức</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="cong_thuc" ten="Mô tả" TextMode="MultiLine" Height="200px" runat="server" CssClass="css_form css_nd"
                                    kieu_unicode="True" kt_xoa="X" Width="500px" MaxLength="1000" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" anh="K" class="bt_action" Width="100px" OnClick="return ns_tl_phieuluong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" anh="K" class="bt_action" Width="100px" OnClick="return ns_tl_phieuluong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" anh="K" class="bt_action" Width="100px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" anh="K" class="bt_action" Width="100px" OnClick="return ns_tl_phieuluong_P_XOA();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1230,630" />
    </div>
</asp:Content>
