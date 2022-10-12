<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_manhom.aspx.cs" Inherits="f_ht_manhom"
    Title="ht_manhom" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Nhóm phân quyền" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhóm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma_tk" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Mã nhóm quyền" ToolTip="Mã nhóm quyền" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhóm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_tk" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Tên nhóm quyền" ToolTip="Tên nhóm quyền" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ht_manhom_P_LKE();form_P_LOI('');" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="X" hangKt="15" hamRow="ht_manhom_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="30%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="70%" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_manhom_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhóm quyền</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="mã nhóm"
                                    onchange="ht_manhom_P_KTRA('MA')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Tên nhóm quyền</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                    kt_xoa="X" ten="tên nhóm" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="grid_table width_common">
                        <div class="col_2_iterm width_common">
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label b_left col_30">Phân hệ</span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="phanhe" ten="Phân hệ" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_PHANHE"
                                        onchange="ht_manhom_P_CHUYEN_HANG()" />
                                </div>
                            </div>
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label lv2 b_left col_35">Tên chức năng</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_form" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_unicode="true"
                                        onchange="ht_manhom_P_CHUYEN_HANG()" />
                                </div>
                            </div>
                        </div>
                        <div>
                            <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X"
                                cot="ten,ghi,xem,xoa,pd,in,mo_cpd,active,export,MD,NV" cotAn="MD,NV" hangKt="15" ctrT="TEN" ctrS="nhap" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nghiệp vụ" DataField="ten" HeaderStyle-Width="40%" ItemStyle-CssClass="css_Gnd" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Ghi" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'GHI');" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="ghi" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền nhập/ghi dữ liệu: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Xem" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'XEM')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="xem" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xem dữ liệu: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Xóa" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'XOA')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="xoa" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xóa dữ liệu: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Phê duyệt" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'PD')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="PD" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền phê duyệt dữ liệu: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="In biểu mẫu" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'IN')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="in" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền in biểu mẫu: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Mở chờ phê duyệt" CssClass="text_tb"></asp:Label><br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'MO_CPD')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="mo_cpd" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền mở chờ phê duyệt: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Đóng/Mở bảng công/lương" CssClass="text_tb"></asp:Label>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'ACTIVE')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="active" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền quản lý nghiệp vụ: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Xuất báo cáo" CssClass="text_tb"></asp:Label><br />
                                            <br />
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'EXPORT')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="export" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xuất báo cáo: C-Có, K-Không" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MD" />
                                    <asp:BoundField DataField="NV" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_nv_slide" runat="server" ham="ht_manhom_P_CHUYEN_HANG()" gridId="GR_nv" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ht_manhom_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Nhập" OnClick="return ht_manhom_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return ht_manhom_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="all_ghi" runat="server" />
        <Cthuvien:an ID="all_xem" runat="server" />
        <Cthuvien:an ID="all_xoa" runat="server" />
        <Cthuvien:an ID="all_pd" runat="server" />
        <Cthuvien:an ID="all_in" runat="server" />
        <Cthuvien:an ID="all_moPd" runat="server" />
        <Cthuvien:an ID="all_dong" runat="server" />
        <Cthuvien:an ID="all_xuatbc" runat="server" />
        <Cthuvien:an ID="all_Bc" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,650" />
    </div>
</asp:Content>
