<%@ Page Title="ns_tl_qtthue_uquyen" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_qtthue_uquyen.aspx.cs" Inherits="f_ns_tl_qtthue_uquyen" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Ủy quyền quyết toán thuế TNCN" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="25" cotAn="so_id" hamRow="ns_tl_qtthue_uquyen_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ủy quyền" DataField="uyquyen" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_qtthue_uquyen_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" runat="server" BackColor="#f6f7f7" disabled="disabled" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                    ToolTip="Mã nhân viên" ten="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ tên" BackColor="#f6f7f7" disabled="disabled" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CDANH" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Chức danh" BackColor="#f6f7f7" disabled="disabled" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_PHONG" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Đơn vị" BackColor="#f6f7f7" disabled="disabled" />
                            </div>
                        </div>
                        <div id="UPa_ct2">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Năm<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" kt_xoa="G" onchange="ns_tl_qtthue_uquyen_P_KTRA('NAM');" CssClass="form-control css_list" ktra="DT_NAM" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ủy quyền quyết toán thuế</span>
                                <div class="input-group">
                                    <Cthuvien:DR_list ID="uyquyen" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Vùng"
                                        lke="Có,Không" tra="X, " />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" OnClick="return ns_tl_qtthue_uquyen_P_MOI();" Width="80px" anh="K" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" OnClick="return ns_tl_qtthue_uquyen_P_NH();" Width="80px" anh="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="973,650" />
    </div>
</asp:Content>
