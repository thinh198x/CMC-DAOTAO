<%@ Page Title="ns_cc_nghibu" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_nghibu.aspx.cs" Inherits="f_ns_cc_nghibu" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp nghỉ bù" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" kieu="U" CssClass="form-control css_list" kt_xoa="K" onchange="ns_cc_nghibu_P_KTRA('PHONG')" ktra="DT_PHONG" />
                                <img runat="server" style="margin-left: 10px;" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cc_nghibu_phong();" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_nghibu_P_KTRA('NAM');" kt_xoa="K" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" kt_xoa="G" CssClass="form-control css_list" onchange="ns_cc_nghibu_P_KTRA('KYLUONG')" ktra="DT_KYLUONG" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30"></span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="t" runat="server" Text="Tổng hợp phép bù" Width="160px" class="bt_action" anh="K" OnClick="ns_cc_nghibu_TINH();form_P_LOI('');" Title="Tổng hợp phép bù" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <table>
                                <tr>
                                    <td align="left">
                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                            <tr>
                                                <td id="td1" rowspan="2" valign="middle" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label2" runat="server" Width="25px" />
                                                </td>
                                                <td id="td3" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label4" runat="server" Width="75px" Text="Mã NV" Font-Bold="true" />
                                                </td>
                                                <td id="td4" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label5" runat="server" Width="155px" Text="Tên nhân viên" Font-Bold="true" />
                                                </td>
                                                <td id="td5" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label7" runat="server" Width="225px" Text="Chức danh" Font-Bold="true" />
                                                </td>
                                                <td id="td55" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label58" runat="server" Width="225px" Text="Phòng" Font-Bold="true" />
                                                </td>
                                                <td id="td12" colspan="12" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid; height: 22px;" align="center">
                                                    <asp:Label ID="Label3" runat="server" Width="560px" Text="Tăng trong năm" Font-Bold="true" />
                                                </td>
                                                <td id="td13" colspan="12" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid; height: 22px;" align="center">
                                                    <asp:Label ID="Label8" runat="server" Width="584px" Text="Dùng trong năm" Font-Bold="true" />
                                                </td>
                                                <td id="td61" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label64" runat="server" Width="105px" Text="Tổng số ngày được nghỉ bù" Font-Bold="true" />
                                                </td>
                                                <td id="td62" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label65" runat="server" Width="105px" Text="Tổng số ngày đã nghỉ bù" Font-Bold="true" />
                                                </td>
                                                <td id="td63" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label66" runat="server" Width="105px" Text="Số ngày nghỉ bù còn lại" Font-Bold="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label111" runat="server" Width="50" Text="T1" />
                                                </td>

                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label9" runat="server" Width="50" Text="T2" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label10" runat="server" Width="50" Text="T3" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label11" runat="server" Width="50" Text="T4" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label12" runat="server" Width="50" Text="T5" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label13" runat="server" Width="50" Text="T6" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label14" runat="server" Width="50" Text="T7" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label15" runat="server" Width="50" Text="T8" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label16" runat="server" Width="50" Text="T9" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label17" runat="server" Width="50" Text="T10" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label18" runat="server" Width="50" Text="T11" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label19" runat="server" Width="50" Text="T12" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label21" runat="server" Width="50" Text="T1" />
                                                </td>

                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label22" runat="server" Width="50" Text="T2" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label23" runat="server" Width="50" Text="T3" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label24" runat="server" Width="50" Text="T4" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label25" runat="server" Width="50" Text="T5" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label26" runat="server" Width="50" Text="T6" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label27" runat="server" Width="50" Text="T7" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label28" runat="server" Width="50" Text="T8" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label29" runat="server" Width="50" Text="T9" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label30" runat="server" Width="50" Text="T10" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label31" runat="server" Width="50" Text="T11" />
                                                </td>
                                                <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                    <asp:Label ID="Label32" runat="server" Width="50" Text="T12" />
                                                </td>
                                            </tr>
                                        </table>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L"
                                            hangKt="15" gchuId="gchu" cot="so_the,ten,chuc_danh,bo_phan,tang_thang1,tang_thang2,tang_thang3,tang_thang4,tang_thang5,tang_thang6,tang_thang7,tang_thang8,tang_thang9,tang_thang10,tang_thang11,tang_thang12,dadung_thang1,dadung_thang2,dadung_thang3,dadung_thang4,dadung_thang5,dadung_thang6,dadung_thang7,dadung_thang8,dadung_thang9,dadung_thang10,dadung_thang11,dadung_thang12,tang_canam,dadung_canam,conlai_canam">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="20px" />
                                                <asp:BoundField DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="chuc_danh" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="bo_phan" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="tang_thang1" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang2" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang3" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang4" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang5" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang6" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang7" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang8" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang9" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang10" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang11" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_thang12" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang1" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang2" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang3" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang4" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang5" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang6" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang7" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang8" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang9" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang10" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang11" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_thang12" HeaderStyle-Width="45px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="tang_canam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="dadung_canam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField DataField="conlai_canam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_nghibu_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Xuất Excel" class="bt_action" anh="K" Width="120px" OnClick="ns_cc_nghibu_P_IN();form_P_LOI('');" Title="Tìm kiếm" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Xuat2" runat="server" Width="70px" class="bt_action" anh="K" Text="Export" OnServerClick="xuat_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,760" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
        <Cthuvien:an ID="anam" runat="server" />
    </div>
</asp:Content>
