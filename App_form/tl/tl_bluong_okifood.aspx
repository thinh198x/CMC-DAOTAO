<%@ Page Title="tl_bluong_okifood" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_bluong_okifood.aspx.cs" Inherits="f_tl_bluong_okifood" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Bảng lương tháng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td valign="middle">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_drop"
                                                                    onchange="tl_bluong_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return tl_bluong_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text="Tháng" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="K"
                                                                    kieu_luu="S" onblur="tl_bluong_P_KTRA('THANG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinhluong" runat="server" Text="Tính lương tháng" CssClass="css_button"
                                                                    OnClick="return tl_bluong_TINH();" Width="160px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 500px; width: 1000px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="80px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="210px" Text="Họ tên" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label32" runat="server" Width="60px" Text="Ngày công thực tế" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  colspan="2" align="center">
                                                                    <asp:Label ID="Label39" runat="server" Text="Ngày nghỉ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="21" align="center">
                                                                    <asp:Label ID="Label40" runat="server" Text="TIỀN LƯƠNG, TIÊN CÔNG" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label41" runat="server" Width="110px" Text="TỔNG CỘNG LƯƠNG VÀ PHỤ CẤP" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label42" runat="server" Text="PHỤ CẤP KHÁC" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label1" runat="server" Width="110px" Text="CỘNG CÁC KHOẢN PHẢI TRẢ CHO NLĐ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="9" align="center">
                                                                    <asp:Label ID="Label43" runat="server" Text="CÁC KHOẢN GIẢM TRỪ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="5" align="center">
                                                                    <asp:Label ID="Label57" runat="server" Width="110px" Text="THỰC LĨNH" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label44" runat="server" Width="110px" Text="Nghỉ có hưởng LCB" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label45" runat="server" Width="110px" Text="Nghỉ không hưởng LCB" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label46" runat="server" Text="Lương Chính" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="13" align="center">
                                                                    <asp:Label ID="Label47" runat="server" Text="Lương làm thêm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="110px" Text="TỔNG CỘNG LƯƠNG" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Text="Phụ cấp lương" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="110px" Text="TỔNG CỘNG PHỤ CẤP" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label48" runat="server" Width="110px" Text="Ăn ca" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label49" runat="server" Width="110px" Text="Điện thoại" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label50" runat="server" Width="110px" Text="Xăng xe" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label51" runat="server" Width="110px" Text="Cộng phụ cấp" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label55" runat="server" Width="110px" Text="KPCĐ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label52" runat="server" Width="110px" Text="BHXH" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label53" runat="server" Width="110px" Text="BHYT" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label54" runat="server" Width="110px" Text="BHTN" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label56" runat="server" Text="THUẾ THU NHẬP CÁ NHÂN" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="4" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Width="110px" Text="Trừ tạm ứng cá nhân" />
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="110px" Text="Hệ số" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Text="Làm thêm ngày thường" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label11" runat="server" Text="Làm thêm ngày nghỉ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label13" runat="server" Text="Làm thêm ngày Lễ, Tết" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Width="110px" Text="Cộng lương làm thêm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Text="Phụ cấp công việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Text="Phụ cấp vị trí" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label65" runat="server" Width="110px" Text="Thu nhập chịu thuế" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label66" runat="server" Width="110px" Text="Số người phụ thuộc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label68" runat="server" Width="110px" Text="Thuế TNCN" />
                                                                </td>

                                                            </tr>
                                                          <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label59" runat="server" Text="Làm thêm buổi ngày" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label60" runat="server" Text="Làm thêm buổi đêm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label61" runat="server" Text="Làm thêm buổi ngày" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label62" runat="server" Text="Làm thêm buổi đêm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label63" runat="server" Text="Làm thêm buổi ngày" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label64" runat="server" Text="Làm thêm buổi đêm" />
                                                                </td>
                                                              <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="110px" Text="Hệ số" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                              <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="110px" Text="Hệ số" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                            </tr>
                                                              <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label75" runat="server" Width="110px" Text="Số giờ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label76" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label77" runat="server" Width="110px" Text="Số giờ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label78" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label79" runat="server" Width="110px" Text="Số giờ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label80" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label81" runat="server" Width="110px" Text="Số giờ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label82" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label83" runat="server" Width="110px" Text="Số giờ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label84" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label85" runat="server" Width="110px" Text="Số giờ" />
                                                                </td> 
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label86" runat="server" Width="110px" Text="Thành tiền" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" cotAn="PHONG_CP"
                                                            hangKt="21" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="PHONG_CP" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="LV_THUCTE_OKIFOOD" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="NGHI_CL" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="NGHI_KCL" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSO_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                               
                                                                <asp:BoundField DataField="CONG_CC4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CONG_CC5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CONG_CC6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CONG_CC7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CONG_CC8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CONG_CC9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TIENCONG9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_LT" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_TG" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                 <asp:BoundField DataField="HSO_CV" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_CV" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSPC_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSPC_NN_TIEN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TONG_PC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TONG_LUONG_PC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />

                                                                <asp:BoundField DataField="ANCA" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="DIENTHOAI" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="XANGXE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PCAP" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHAITRA_NLD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                               
                                                                <asp:BoundField DataField="PCD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHXH" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHYT" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHTN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TNHAP_CHIUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHUTHUOC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TRUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TAM_UNG" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="THUC_LINH" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_bluong_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_bluong_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_bluong_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return tl_bluong_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return tl_bluong_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="tl_bluong_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="tl_bluong_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,700" />
    </div>
</asp:Content>
