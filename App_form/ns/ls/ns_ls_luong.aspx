<%@ Page Title="ns_ls_luong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_luong.aspx.cs" Inherits="f_ns_ls_luong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình lương trong công ty" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ReadOnly="true" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                    ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ls_kt_P_KTRA('SO_THE')" gchu="gchu" kt_xoa="K" />
                                <Cthuvien:an ID="ASOTHE" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="form-control css_ma" ToolTip="Họ tên" kieu_unicode="true" ReadOnly="true" Enabled="false" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,phucap" hamRow="ns_ls_luong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Số ID" DataField="so_id" />
                                    <asp:BoundField HeaderText="Số quyết định" DataField="so_qd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lương cơ bản" DataField="luongcb" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Thưởng HQCV" DataField="thuong_kq" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="% hưởng lương" DataField="pt_huongluong" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Phụ cấp" DataField="phucap" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tổng thu nhập mục tiêu" DataField="thunhapthang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="ns_ls_kt_P_LKE()" />
                        </div>
                    </div>
                    <div>
                        <div class="width_common pv_bl" style="display: none"><span>Thông tin phụ cấp</span></div>
                        <div class="grid_table width_common">
                            <div style="height: 300px; overflow-y: scroll">
                                <Cthuvien:GridX ID="GR_ct" runat="server" loai="X" cotAn="co_bh" Width="100%"
                                    AutoGenerateColumns="false" hangKt="20" PageSize="1" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã phụ cấp" DataField="ma_pc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên phụ cấp" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_ad" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngay_kt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action" style="display: none;">
                        <Cthuvien:nhap ID="XuatExcel" class="bt_action" anh="K" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_ls_luong_P_IN();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,650" />
</asp:Content>
