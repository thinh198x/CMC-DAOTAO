<%@ Page Title="ns_hd_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hd_tt.aspx.cs" Inherits="f_ns_hd_tt" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quá trình hợp đồng lao động " />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L" hangKt="10">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số hợp đồng" DataField="so_hd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Loại hợp đồng" DataField="loai_hd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngayc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Ngày ký" DataField="ngay_ky" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Người ký" DataField="ma_nguoiky" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Chức danh người ký" DataField="ten_cdanh_nguoiky" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_hd_tt_P_LKE()" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,570" />
    </div>
</asp:Content>
