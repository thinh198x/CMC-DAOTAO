<%@ Page Title="ns_ls_kt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_kt.aspx.cs" Inherits="f_ns_ls_kt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="r_c_content b_right">
        <div class="title_dmuc width_common">
            <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình khen thưởng" />
            <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
        </div>
        <div class="width_common auto_sc">
            <div class="b_left col_100 inner" id="UPa_tk">
                <div class="col_3_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhân viên <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                ToolTip="Mã số cán bộ" kieu_chu="true" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ls_kt_P_KTRA('SO_THE')" gchu="gchu" kt_xoa="K" />
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
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="lhd,ma_nguoiky,cdanh_nguoiky">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Số quyết định" DataField="soqd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Cấp khen thưởng" DataField="cap_ktkl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Hình thức khen thưởng" DataField="hinhthuc" HeaderStyle-Width="145px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Nội dung khen thưởng" DataField="lydo" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ls_kt_P_LKE()" />
                    </div>
                </div>
                <div class="list_bt_action">
                    <Cthuvien:nhap ID="XuatExcel" class="bt_action" anh="K" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_ls_kt_P_IN();form_P_LOI();" />
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
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,700" />
    </div>
</asp:Content>
