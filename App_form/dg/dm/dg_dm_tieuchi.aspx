<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_dm_tieuchi.aspx.cs" Inherits="f_dg_dm_tieuchi"
    Title="dg_dm_tieuchi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục tiêu chí đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="MA_NHOM,tt,gchu" hamRow="dg_dm_tieuchi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nhóm tiêu chí" DataField="MA_NHOM_TEN" HeaderStyle-Width="180px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã tiêu chí" DataField="ma" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên tiêu chí" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" HeaderStyle-Width="100px" DataField="ten_tt">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MA_NHOM" />
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="gchu" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_tieuchi_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Nhóm tiêu chí <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_NHOM" ktra="DT_DG_NHOM_TCHI" ten="Nhóm tiêu chí" kt_xoa="L" runat="server" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            <Cthuvien:ma ID="ma_nhom_ten" runat="server" CssClass="css_form" kieu_unicode="True" MaxLength="255" kt_xoa="X" Style="display: none;" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mã tiêu chí <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã tiêu chí" onchange="dg_dm_tieuchi_P_KTRA('MA')" runat="server" MaxLength="20"
                                CssClass="form-control css_ma" kieu_chu="true" kt_xoa="G" ReadOnly="true" Enabled="false" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Tên tiêu chí <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên tiêu chí" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                MaxLength="255" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" ten="Mô tả" runat="server" Height="80px" TextMode="MultiLine" CssClass="form-control css_ma"
                                kieu_unicode="True" kt_xoa="X" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return dg_dm_tieuchi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return dg_dm_tieuchi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="mau_excel" runat="server" Text="File mẫu" class="bt_action" anh="K" OnServerClick="excel_mau_Click" />
                        <Cthuvien:nhap ID="import_excel" runat="server" Text="Import" class="bt_action" anh="K" OnClick="return dg_dm_tieuchi_FILE_Import();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN,MA_NHOM,ma_nhom_ten');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return dg_dm_tieuchi_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,540" />
        <Cthuvien:an ID="trangthai" runat="server" />
    </div>
</asp:Content>
