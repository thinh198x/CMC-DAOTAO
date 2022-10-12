<%@ Page Title="ns_tl_tl_ml" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_tl_ml.aspx.cs" Inherits="f_ns_tl_tl_ml" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục thông tin bảng lương" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
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
                        <td class="form_left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_tk" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu">Công ty</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_lke ID="MA_DVI_TK" ten="Bảng công" runat="server" Width="250px" ktra="DT_DVI" onchange="ns_tl_tl_ml_P_KTRA('MA_DVI')" kt_xoa="G" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Hình thức tính lương" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_lke ID="MA_DT_TK" ten="Đối tượng" runat="server" Width="207px" ktra="DT_DT" onchange="ns_tl_tl_ml_P_KTRA('MA_DT')" kt_xoa="L" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <div class="css_divb">
                                                        <div>
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="X" hangKt="10" cot="ten_cot,ten_ct,ten_ap_dung_ct,ap_dung_ct,d_vi,so_id" cotAn="ap_dung_ct,d_vi,so_id" hamRow="ns_tl_tl_ml_GR_lke_RowChange()">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField HeaderText="Mã cột lương" DataField="ten_cot" HeaderStyle-Width="150px">
                                                                        <ItemStyle CssClass="css_Gma" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Tên cột lương" DataField="ten_ct" HeaderStyle-Width="250px">
                                                                        <ItemStyle CssClass="css_Gma" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Loại dữ liệu" DataField="ten_ap_dung_ct" HeaderStyle-Width="195px">
                                                                        <ItemStyle CssClass="css_Gma" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ap_dung_ct" />
                                                                    <asp:BoundField DataField="d_vi" />
                                                                    <asp:BoundField DataField="so_id" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divl:ctr_khud_divl id="Ctr_khud_divl1" runat="server" loai="X" gridid="GR_ct"
                                                            ham="ns_tl_tl_ml_P_LKE()" />
                                                    </div>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã cột lương" />
                                    </td>
                                    <td colspan="3">
                                        <Cthuvien:ma ID="TEN_COT" disabled runat="server" CssClass="css_form" onchange="ns_tl_tl_ml_P_KTRA('MA');" MaxLength="20" kieu_chu="true"
                                            Width="250px" gchu="gchu" ten="Mã cột lương" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Tên cột lương" />
                                    </td>
                                    <td colspan="3">
                                        <Cthuvien:ma ID="TEN_CT" ten="Tên cột lương" runat="server" MaxLength="100" CssClass="css_form" kieu_unicode="True"
                                            kt_xoa="X" Width="250px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Loại dữ liệu" />
                                    </td>
                                    <td colspan="3">
                                        <Cthuvien:DR_list ID="AP_DUNG_CT" ten="Loại dữ liệu" runat="server" Width="250px" lke="Chưa xếp nhóm,Dữ liệu cơ bản,Dữ liệu đầu vào,Dữ liệu import,Dữ liệu tính toán" tra="9,0,1,2,3" onchange="ns_tl_tl_ml_P_KTRA('LOAI_CT')" kt_xoa="K" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" Text="Thứ tự tính" />
                                    </td>
                                    <td align="left" style="width: 30px">
                                        <Cthuvien:so runat="server" ID="sott_nhom" ten="Thứ tự tính" Text="0" kieu_so="true" co_dau="K" CssClass="css_form_c" Width="30px" kt_xoa="X" MaxLength="20" />
                                    </td>
                                    <td align="left" style="padding-left: 80px">
                                        <asp:Label ID="Label6" runat="server" Text="Thứ tự hiển thị" />
                                    </td>
                                    <td align="left" style="width: 30px">
                                        <Cthuvien:so runat="server" ID="sott_hien_thi" ten="Thứ tự hiển thị" Text="0" kieu_so="true" co_dau="K" CssClass="css_form_c" Width="30px" kt_xoa="X" MaxLength="20" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Lương trong kỳ"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu runat="server" ID="hien_thi_tk" ten="Lương trong kỳ" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                    </td>
                                    <td align="left" style="padding-left: 80px">
                                        <asp:Label ID="Label5" runat="server" Text="Lương tổng hợp" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu runat="server" ID="hien_thi_th" ten="Lương tổng hợp" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbltt" runat="server" Text="Áp dụng"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <Cthuvien:kieu runat="server" ID="trang_thai" ten="Áp dụng" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_tl_tl_ml_P_NH();form_P_LOI();" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,570" />
    </div>
</asp:Content>
