<%@ Page Title="hdns_th_kh_tuyendung" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_th_kh_tuyendung.aspx.cs" Inherits="f_hdns_th_kh_tuyendung" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tổng hợp kế hoạch tuyển dụng" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td class="form_right">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_form"
                                                                    onchange="hdns_th_kh_tuyendung_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return hdns_th_kh_tuyendung_phong();" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label31" runat="server" CssClass="css_gchu_c" Text="Năm"
                                                                    Width="50px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="NAM" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                                    CssClass="css_form_r" onchange="ns_danhsach_P_NAM();" kieu="S" Width="70px" />
                                                            </td>
                                                            <td align="left" style="display: none">
                                                                <asp:Label ID="Label32" runat="server" CssClass="css_gchu_c" Text="Kỳ lương"
                                                                    Width="70px" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:DR_nhap ID="KYLUONG" ten="Kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form" kieu="S" Width="100px" onchange="hdns_th_kh_tuyendung_P_KTRA('KYLUONG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>

                                                                <a href="#" onclick="return hdns_th_kh_tuyendung_TINH();" class="bt bt-grey"><i class="fa fa-calendar"></i>Tổng hợp </a>
                                                                <%--<Cthuvien:nhap ID="tinhluong" runat="server" Text="Tổng hợp" CssClass="css_button"
                                                                    OnClick="return hdns_th_kh_tuyendung_TINH();" Width="160px" />--%>
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
                                        <div style="height: 500px; width: 1200px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label35" runat="server" Width="30" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Width="48" Text="STT" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label30" runat="server" Width="209px" Text="Đơn vị" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label33" runat="server" Width="158px" Text="Chức danh" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label34" runat="server" Width="114px" Text="Số lượng cần tuyển tháng 1" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="114px" Text="Số lượng cần tuyển tháng 2" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="118px" Text="Số lượng cần tuyển tháng 3" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="114px" Text="Số lượng cần tuyển tháng 4" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="115px" Text="Số lượng cần tuyển tháng 5" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="118px" Text="Số lượng cần tuyển tháng 6" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="117px" Text="Số lượng cần tuyển tháng 7" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="117px" Text="Số lượng cần tuyển tháng 8" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="115px" Text="Số lượng cần tuyển tháng 9" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="116px" Text="Số lượng cần tuyển tháng 10" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Width="116px" Text="Số lượng cần tuyển tháng 11" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="117px" Text="Số lượng cần tuyển tháng 12" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label28" runat="server" Width="116px" Text="Tổng số lượng cần tuyển" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label29" runat="server" Width="114px" Text="Số lượng đã tuyển được" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="117px" Text="Ghi chú" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L"
                                                            hangKt="21" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="STT" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="ten_phong" HeaderStyle-Width="199px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="thang1" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang2" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang3" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang6" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang10" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang11" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="thang12" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="tong_sl_tuyen" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="sl_datuyen" HeaderStyle-Width="107px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="ghichu" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
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
                                                    <div class="box3 txRight">
                                                        <a href="#" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return hdns_th_kh_tuyendung_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">I</span>n</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return hdns_th_kh_tuyendung_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>

                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,750" />
    </div>
</asp:Content>
