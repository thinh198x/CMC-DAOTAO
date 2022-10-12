<%@ Page Title="ns_cc_tonghop_hal" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tonghop_hal.aspx.cs" Inherits="f_ns_cc_tonghop_hal" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Bảng tổng hợp công cá nhân HAL" />
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
                                                                    onchange="ns_cc_tonghop_hal_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cc_tonghop_hal_phong();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="K"
                                                                    kieu_luu="S" onblur="ns_cc_tonghop_hal_P_KTRA('THANG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinhluong" runat="server" Text="Tổng hợp công" CssClass="css_button"
                                                                    OnClick="return ns_cc_tonghop_TINH();" Width="160px" />
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
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="110px" Text="Ngày tháng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="50px" Text="Ca làm việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="8" align="center">
                                                                    <asp:Label ID="Label36" runat="server" Text="THỜI GIAN LÀM VIỆC 勤務時間" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="11" align="center">
                                                                    <asp:Label ID="Label37" runat="server"  Text="THỜI GIAN LÀM THÊM 残業時間" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label38" runat="server" Width="110px" Text="Số ngày phép chưa sử dụng" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label1" runat="server" Width="110px" Text="Ghi chú" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="110px" Text="Số ngày đi làm"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="110px" Text="Đi muộn "/>
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="110px" Text="Về sớm"/>
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="110px" Text="Nghỉ có lương"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="110px" Text="Nghỉ không lương"/>
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; " rowspan="2" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="110px" Text="T.gia học tập trung"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Width="110px" Text="Thiếu thời gian học TT" rowspan="2"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="110px" Text="T.gian làm việc thực tế" rowspan="2"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="110px" Text="Giờ làm thêm 残業時間 " />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label4" runat="server" Width="110px" Text="Làm thêm ngày thường"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Width="110px" Text="Làm thêm ngày nghỉ"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label11" runat="server" Width="110px" Text="Làm thêm ngày lễ" rowspan="2"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Width="110px" Text="Làm ca đêm ngày thường(D)" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label13" runat="server" Width="110px" Text="Làm ca đêm ngày nghỉ(D)" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="110px" Text="Làm ca đêm ngày lễ(D)"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; " rowspan="2"  align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="110px" Text="Làm thêm ca đêm ngày thường(D)" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="110px" Text="Làm thêm ca đêm ngày nghỉ(D)"/>
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2"  align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="110px" Text="Làm thêm ca đêm ngày lễ(D)"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                              
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Width="70px" Text="Từ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"align="center">
                                                                    <asp:Label ID="Label9" runat="server" Width="70px" Text="Đến" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" hangKt="19" gchuId="gchu" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="NGAY" HeaderText="年月日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="CA" HeaderText="シフト" HeaderStyle-Width="48px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="N1" HeaderText="出勤日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N2" HeaderText="遅刻" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N3" HeaderText="早退" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N4" HeaderText="有給休日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N5" HeaderText="無給休日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N6" HeaderText="集合時間" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N7" HeaderText="集合時間不足" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N8" HeaderText="実際勤務時間" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N9" HeaderText="～時から" HeaderStyle-Width="68px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N10" HeaderText="～時まで" HeaderStyle-Width="68px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N11" HeaderText="残業" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N12" HeaderText="休日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N13" HeaderText="祝祭日" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N14" HeaderText="夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N15" HeaderText="休日夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N16" HeaderText="祝祭夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N17" HeaderText="平日夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N18" HeaderText="休日夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N19" HeaderText="祝祭夜勤" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N20" HeaderText="有給休暇残数" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N21" HeaderText="備考" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
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
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_cc_tonghop_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_cc_tonghop_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_cc_tonghop_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return ns_cc_tonghop_P_FILES();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_cc_tonghop_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_cc_tonghop_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_cc_tonghop_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_cc_tonghop_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_tonghop_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_cc_tonghop_ChenDong('C');" />
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
                                            CssClass="table gridX" loai="X" cotAn="so_the" hangKt="15" hamRow="ns_cc_tonghop_hal_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="" DataField="so_the" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Cán bộ" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="ns_cc_tonghop_P_LKE()" />
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
