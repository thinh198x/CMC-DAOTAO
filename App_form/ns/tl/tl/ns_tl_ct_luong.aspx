<%@ Page Title="ns_tl_ct_luong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_ct_luong.aspx.cs" Inherits="f_ns_tl_ct_luong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Thiết lập công thức lương" />
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
                            <table cellpadding="1" cellspacing="1" id="UPa_ct">
                                <tr>
                                    <td colspan="2" align="left">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" Text="Công ty" Width="60px" /></td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_DVI_TK" ten="Công ty" runat="server" Width="250px" ktra="DT_DVI" onchange="ns_tl_ct_luong_P_KTRA('MA_DVI')" kt_xoa="G" /></td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" Text="Hình thức tính lương" Width="120px" /></td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_DT_TK" ten="Hình thức tính lương" runat="server" Width="250px" ktra="DT_DT" onchange="ns_tl_ct_luong_P_KTRA('MA_DT')" kt_xoa="G" /></td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_ct" runat="server" CssClass="css_tab_ngang_ac" Width="110px"
                                                                    Height="20px" Text="Công thức lương" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="css_divb">
                                                        <div>
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="X" hangKt="10" cot="SOTT_NHOM,sott_hien_thi,ma,ten,congthuc,SO_ID,TT" cotAn="congthuc,SO_ID,TT" hamRow="ns_tl_ct_luong_GR_lke_RowChange()">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField DataField="SOTT_NHOM" HeaderText="TT tính" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                                                    <asp:BoundField DataField="sott_hien_thi" HeaderText="STT hiển thị" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                                    <asp:BoundField HeaderText="Mã cột lương" DataField="ma" HeaderStyle-Width="120px" />
                                                                    <asp:BoundField HeaderText="Tên cột lương" DataField="ten" HeaderStyle-Width="405px" ItemStyle-Font-Bold="true" />
                                                                    <asp:BoundField DataField="congthuc" />
                                                                    <asp:BoundField DataField="SO_ID" />
                                                                    <asp:BoundField DataField="TT" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <khud:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_tl_ct_luong_P_LKE()" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="Table1" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_dl" runat="server" CssClass="css_tab_ngang_ac" Width="110px"
                                                                    Height="20px" Text="Cột đầu vào" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="css_divb">
                                                        <div>
                                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="" cot="ma,ten">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField HeaderText="Mã cột lương" DataField="ma" ItemStyle-CssClass="css_ma" HeaderStyle-Width="120px" />
                                                                    <asp:BoundField HeaderText="Tên cột lương" DataField="ten" HeaderStyle-Width="350px" ItemStyle-Font-Bold="true" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                                            ham="ns_tl_ct_luong_P_DV_LKE()" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td align="left" valign="middle">
                                        <table cellpadding="1" cellspacing="1" id="Upa_tinh">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:kieu runat="server" ID="trang_thai" ten="Áp dụng" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbltt" runat="server" Text="Áp dụng" Width="70px"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <Cthuvien:kieu runat="server" ID="hien_thi" ten="Hiển thị bảng công" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Hiển thị bảng công" Width="120px"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" Text="Thứ tự tính" Width="120px"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so runat="server" ID="SOTT_NHOM" ten="Thứ tự tính" Text="0" kieu_so="true" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label6" runat="server" Text="Thứ tự hiển thị" Width="120px"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so runat="server" ID="sott_hien_thi" ten="Thứ tự hiển thị" Text="0" kieu_so="true" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <Cthuvien:nd ID="congthuc" ToolTip="Công thức" Rows="8" runat="server" kieu="U" Width="100%"
                                            CssClass="css_ma" TextMode="MultiLine" kt_xoa="X" MaxLength="1000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" colspan="2">
                                        <table cellpadding="1" cellspacing="1" id="Upa_nhap">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="kiemtra" runat="server" Text="Kiểm tra CT" Width="90px" OnClick="return ns_tl_ct_luong_P_KT();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_tl_ct_luong_P_NH();form_P_LOI();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,700" />
    </div>
</asp:Content>
