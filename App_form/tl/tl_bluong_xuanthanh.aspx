﻿<%@ Page Title="tl_bluong_xuanthanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_bluong_xuanthanh.aspx.cs" Inherits="f_tl_bluong_xuanthanh" %>

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
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="80px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="210px" Text="Họ tên" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label32" runat="server" Width="60px" Text="Ngày công thực tế" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label39" runat="server" Width="60px" Text="Phép năm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Text="LƯƠNG CƠ BẢN" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label34" runat="server" Text="LƯƠNG CÔNG VIỆC" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label40" runat="server" Text="LƯƠNG DOANH THU" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label11" runat="server" Width="110px" Text="TỔNG CỘNG LƯƠNG" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label41" runat="server" Text="PHỤ CẤP" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label13" runat="server" Width="110px" Text="Chênh lệch ăn ca" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label42" runat="server" Width="110px" Text="Tổng các khoản phải trả" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label43" runat="server" Text="CÁC KHOẢN GIẢM TRỪ THEO LƯƠNG" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label44" runat="server" Text="THUẾ THU NHẬP CÁ NHÂN" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label45" runat="server" Width="110px" Text="CÁC KHOẢN TRỪ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label46" runat="server" Width="110px" Text="Thực Lĩnh" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="110px" Text="Cấp/Bậc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="110px" Text="Hệ Số LCB" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="110px" Text="Hệ số phụ cấp" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label33" runat="server" Width="110px" Text="Thành Tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label35" runat="server" Width="110px" Text="Cấp/Bậc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label36" runat="server" Width="110px" Text="Hệ Số LCV" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label38" runat="server" Width="110px" Text="Thành Tiền" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label1" runat="server" Width="110px" Text="Số tiền doanh thu" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Width="110px" Text="Lương doanh thu" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Width="110px" Text="Chi quản lý + phụ cấp" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Width="110px" Text="Ăn ca" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Width="110px" Text="Khác" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="110px" Text="KPCĐ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="110px" Text="BHXH" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="110px" Text="BHYT" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="110px" Text="BHTN" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="110px" Text="Thu nhập chịu thuế" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="110px" Text="Số người phụ thuộc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="110px" Text="Thu nhập tính thuế" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Width="110px" Text="Thuế TNCN" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" cotAn="LUONG_TG,LUONG_SP,LUONG_KHOAN"
                                                            hangKt="21" gchuId="gchu" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="LV_THUCTE" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHEP" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CAPBAC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSO_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSPC_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_NN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CAPBAC_CV" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="HSO_CV" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_CV" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="DOANHTHU" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="LUONG_DOANHTHU" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TONG_LUONG" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PCAP" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="ANCA" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TNHAP_CHIUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="CHENHCA" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHAITRA_NLD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PCD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHXH" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHYT" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="BHTN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TNHAPCHIUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHUTHUOC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TN_TINHTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TRUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="KTRU_KCHIUTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
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
