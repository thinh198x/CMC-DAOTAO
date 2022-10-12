<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_bh_aetna.aspx.cs" Inherits="f_ns_ma_bh_aetna"
    Title="ns_ma_bh_aetna" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gói bảo hiểm Aetna" />
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
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" cotAn="trangthai,ghichu,nsd" hangKt="10" hamRow="ns_ma_bh_aetna_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="ma" HeaderText="Mã gói" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField DataField="ten" HeaderText="Tên gói" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="mucphi" HeaderText="Mức phí" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                                <asp:BoundField DataField="trangthai" />
                                                <asp:BoundField DataField="ten_trangthai" HeaderText="Trạng thái" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="ghichu" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_ma_bh_aetna_P_LKE()" />
                                    </td>
                                </tr>
                                <tr><td style="height:10px"></td></tr>
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xuat" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_ma_bh_aetna_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã gói BH Aetna" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã gói BH Aetna" runat="server" CssClass="css_form" kieu_chu="True"
                                                                    kt_xoa="G" onchange="ns_ma_bh_aetna_P_KTRA('MA')" Width="265px" MaxLength="20" />
                                                            </td>
                                                            <td style="width: 100px; display:none">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 36px">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Tên gói BH Aetna</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" style="height: 36px">
                                                    <Cthuvien:ma ID="TEN" ten="Tên gói BH Aetna" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" Width="265px" MaxLength="100" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu">Mức phí</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="MUCPHI" ten="Mức phí" runat="server" CssClass="css_form_r" kieu_unicode="True" kt_xoa="X" Width="265px" co_dau="K" MaxLength="15" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Trạng thái" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TRANGTHAI" ten="Trạng thái" runat="server" Width="265px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" runat="server" kt_xoa="X" CssClass="css_form" Width="265px"
                                                        kieu_unicode="true" ToolTip="Ghi chú" TextMode="MultiLine" Height="50px" MaxLength="1000" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_ma_bh_aetna_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_ma_bh_aetna_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_ma_bh_aetna_P_XOA();form_P_LOI();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1030,500" />
</asp:Content>
