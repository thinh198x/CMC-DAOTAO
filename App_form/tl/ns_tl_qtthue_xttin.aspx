<%@ Page Title="ns_tl_qtthue_xttin" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_qtthue_xttin.aspx.cs" Inherits="f_ns_tl_qtthue_xttin" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xem thông tin quyết toán thuế TNCN" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left width_common inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" kt_xoa="G" onchange="ns_tl_qtthue_xttin_P_KTRA('NAM');" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" runat="server" BackColor="#f6f7f7" disabled="disabled" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                    ToolTip="Mã nhân viên" ten="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ tên" BackColor="#f6f7f7" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã số thuế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MAST" ten="Mã số thuế" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Có ủy quyền</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="uyquyen" ten="Ủy quyền" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="height: 450px; overflow-y: scroll;">
                             <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="L"
                            hangKt="10" gchuId="gchu">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                <asp:BoundField HeaderText="Số TT" DataField="SOTT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Nội dung" DataField="TEN" HeaderStyle-Width="400px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Giá trị" DataField="LUONG" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gso" />
                            </Columns>
                        </Cthuvien:GridX>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,800" />
    </div>
</asp:Content>