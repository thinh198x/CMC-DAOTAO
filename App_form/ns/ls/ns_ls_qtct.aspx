<%@ Page Title="ns_ls_qtct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_qtct.aspx.cs" Inherits="f_ns_ls_qtct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình công tác trong công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten"
                                    ToolTip="Mã số cán bộ" kieu_chu="true" gchu="gchu" kt_xoa="K" />
                                <Cthuvien:an ID="ASOTHE" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_15">Họ tên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên" kieu_unicode="true"
                                    ReadOnly="true" Enabled="false" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="cap_kl,luongcb,thuongthang,phantram_hl,phucap,tongluong" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Số QĐ" DataField="so_qd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Công ty" DataField="donvi" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày ký" DataField="ngay_qd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Người ký" DataField="ten_nky" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lương cơ bản" DataField="luongcb" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Thưởng tháng" DataField="thuongthang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="% Hưởng lương" DataField="phantram_hl" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Phụ cấp" DataField="phucap" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Tổng lương" DataField="tongluong" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_r" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ls_qtct_P_LKE()" />
                    </div>
                    <div class="list_bt_action" style="display: none;">
                        <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="ns_ls_qtct_P_IN()" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="Nhap2" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,600" />
    </div>
</asp:Content>
