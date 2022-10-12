<%@ Page Title="ns_cc_tt_bang_cong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tt_bang_cong.aspx.cs" Inherits="f_ns_cc_tt_bang_cong" %>

<%@ Register Src="~/App_ctr/khud/ns_khud.ascx" TagName="ns_khud" TagPrefix="ns_khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xem thông tin bảng công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <div style="display: none;">
                                <Cthuvien:DR_lke ID="PHONG" runat="server" kieu="U" Width="202px" ten="Phòng" onchange="ns_cc_tonghop_P_KTRA('PHONG')" ktra="DT_PHONG" />
                            </div>
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" onchange="ns_cc_tt_bang_cong_P_NAM();" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="ns_cc_tt_bang_cong_P_KTRA('KYLUONG')" ktra="DT_KY" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" ten="Mã nhân viên tìm kiếm" onchange="ns_cc_th_P_KTRA('SO_THE')" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div style="width: 1200px; overflow-x: scroll">
                            <div>
                                <div>
                                    <div style="width: 3400px">
                                        <ns_khud:ns_khud ID="ns_khud" runat="server" />
                                    </div>
                                </div>
                                <div style="display: none">
                                    <div>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" hangKt="20">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="cotan" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_tt_bang_cong_P_LKE()" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,650" />
        <Cthuvien:an ID="aphong" runat="server" Value="1" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
