<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_tl_nhom_cdanh.aspx.cs" Inherits="f_dg_tl_nhom_cdanh"
    Title="dg_tl_nhom_cdanh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập tiêu chí đánh giá cho chức danh" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="13" cotAn="nsd,cdanh,nhom_tchi,tchi_dgia,gchu" hamRow="dg_tl_nhom_cdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Nhóm tiêu chí" DataField="nhom_tchi" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tiêu chí" DataField="tchi_dgia" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Chức danh" DataField="cdanh_ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Nhóm tiêu chí" DataField="nhom_tchi_ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tiêu chí" DataField="tchi_dgia_ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Trọng số (%)" DataField="trongso" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ghi chú" DataField="gchu">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="100" loai="X" gridId="GR_lke"
                                            ham="dg_tl_nhom_cdanh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label5" runat="server" CssClass="css_gchu">Chức danh</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="CDANH" runat="server" Width="137px" CssClass="css_form" kt_xoa="X" ten="chức danh"
                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten"
                                                        onchange="dg_tl_nhom_cdanh_P_KTRA('cdanh')" ToolTip="Chức danh công việc" placeholder="Nhấn F1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Nhóm tiêu chí</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NHOM_TCHI" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                                    Width="137px" f_tkhao="~/App_form/dg/dm/dg_dm_nhom_tieuchi.aspx" gchu="gchu" ten="nhóm tiêu chí" kt_xoa="X"
                                                                    onchange="dg_tl_nhom_cdanh_P_KTRA('MA_NHOM')" ktra="dg_dm_nhom_tieuchi,ma,ten" placeholder="Nhấn F1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu">Tiêu chí đánh giá</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TCHI_DGIA" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="137px" f_tkhao="~/App_form/dg/dm/dg_dm_tieuchi.aspx" gchu="gchu" guiId="NHOM_TCHI" ten="tiêu chí đánh giá" kt_xoa="X"
                                                        onchange="dg_tl_nhom_cdanh_P_KTRA('TCHI_DGIA')" ktra="dg_dm_tieuchi,ma,ten"  placeholder="Nhấn F1"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Trọng số (%)</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="TRONGSO" ten="trọng số" runat="server" MaxLength="3" CssClass="css_form_r" kieu_unicode="True"
                                                        kt_xoa="X" Width="137px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="gchu" ten="Ghi chú" runat="server" CssClass="css_form" Height="50px" TextMode="MultiLine" kieu_unicode="True"
                                                        kt_xoa="X" Width="190px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return dg_tl_nhom_cdanh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return dg_tl_nhom_cdanh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dg_tl_nhom_cdanh_P_NH();form_P_LOI();"
                                                        Text="Nhập" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dg_tl_nhom_cdanh_P_XOA();form_P_LOI();"
                                                        Text="Xóa" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                                        Text="Chọn" Width="70px" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 220px;">
                                <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1055,625" />
</asp:Content>
