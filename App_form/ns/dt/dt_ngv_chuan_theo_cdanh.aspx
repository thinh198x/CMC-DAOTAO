<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dt_ngv_chuan_theo_cdanh.aspx.cs" Inherits="f_dt_ngv_chuan_theo_cdanh"
    Title="dt_ngv_chuan_theo_cdanh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1" class="form_right">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách đào tạo chuẩn theo chức danh " />
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
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Năm" Width="60px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="drnam" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                        CssClass="css_form" kieu="S" Width="80px" onchange="dt_ngv_chuan_theo_cdanh_P_LKE();" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Bộ phận" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dvi" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" kieu="S" Width="200px" onchange="dt_ngv_chuan_theo_cdanh_P_LKE();" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Chức danh" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="cdanh" ten="Chức danh" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" kieu="S" Width="200px" onchange="dt_ngv_chuan_theo_cdanh_P_LKE();" />
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cot="SOTT,so_the,ho_ten,MUC_NL,MUC_NL_CN,TEN_KH" hamRow="dt_ngv_chuan_theo_cdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="SOTT" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="30px" />
                                                <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên CB" DataField="ho_ten" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Năng lực chuẩn theo chức danh" DataField="MUC_NL" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Năng lực hiện tại của nhân viên" DataField="MUC_NL_CN" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Khóa đào tạo" DataField="TEN_KH" HeaderStyle-Width="220px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="90" runat="server" loai="X" gridId="GR_lke"
                                            ham="dt_ngv_chuan_theo_cdanh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="940,550" />
</asp:Content>
