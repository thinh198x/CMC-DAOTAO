<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dgnl_tl_kh_theo_tc.aspx.cs" Inherits="f_dgnl_tl_kh_theo_tc"
    Title="dgnl_tl_kh_theo_tc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khóa học theo tiêu chuẩn năng lực " />
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
                            <div style="height: 370px; width: 650px; overflow: scroll">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="14" cotAn="nsd,nhom_nl,nangluc,cdanh,gchu" hamRow="dgnl_tl_kh_theo_tc_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh_ten" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Nhóm năng lực" DataField="nhom_nl_ten" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Năng lực" DataField="nangluc_ten" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mức năng lực" DataField="muc_nl" HeaderStyle-Width="80px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã khóa đào tạo" DataField="ma" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="ghichu" DataField="gchu">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="nangluc" DataField="nangluc">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="nhom_nl" DataField="nhom_nl">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="cdanh" DataField="cdanh">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="GR_lke_td" runat="server" align="center">
                                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="40" loai="X" gridId="GR_lke"
                                                ham="dgnl_tl_kh_theo_tc_P_LKE()" />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" CssClass="css_gchu">Mã khóa đào tạo</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã khóa đào tạo" runat="server" onchange="dgnl_tl_kh_theo_tc_P_KTRA('MA')"
                                                                    CssClass="css_form" kieu_unicode="True" Width="130px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu2" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu">Tên khóa đào tạo</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="190px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label5" runat="server" CssClass="css_gchu">Chức danh</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="CDANH" runat="server" Width="190px" CssClass="css_form" kt_xoa="X" ten="chức danh"
                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten"
                                                        onchange="ns_hdct_P_KTRA('cdanh')" ToolTip="Chức danh công việc" placeholder="Nhấn F1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Nhóm năng lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NHOM_NL" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                                                    Width="190px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_n_nl.aspx" gchu="gchu" ten="Nhóm năng lực"
                                                                    onchange="dgnl_tl_kh_theo_tc_P_KTRA('NHOM_NL')" ktra="dg_dm_nhom_nl,ma,ten"  placeholder="Nhấn F1"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu">Năng lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="NANGLUC" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" guiId="NHOM_NL"
                                                        Width="190px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_nl.aspx" gchu="gchu" ten="năng lực" kt_xoa="X"
                                                        onchange="dgnl_tl_kh_theo_tc_P_KTRA('NANGLUC')" ktra="dg_dm_nl,ma,ten"  placeholder="Nhấn F1"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Mức năng lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MUC_NL" ten="Mức năng lực" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="190px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="gchu" TextMode="MultiLine" Height="50px" ten="Ghi chú" runat="server" CssClass="css_form" kieu_unicode="True"
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
                                                        <a href="#" onclick="return dgnl_tl_kh_theo_tc_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return dgnl_tl_kh_theo_tc_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dgnl_tl_kh_theo_tc_P_NH();form_P_LOI();"
                                                        Text="Nhập" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dgnl_tl_kh_theo_tc_P_XOA();form_P_LOI();"
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1025,527" />
</asp:Content>
