<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_khoach.aspx.cs" Inherits="f_ns_ts_khoach" Title="ns_ts_khoach" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table id="UPa_ct" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch dự án " />
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
                        <td align="center">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Dự án" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="DU_AN" runat="server" CssClass="css_form" Width="286px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td>
                                                    <div class="box3" style="padding-left:5px;">
                                                        <a href="#" onclick="return ns_ts_khoach_P_LKE();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                    </div>
                                                </td>
                                                <%--<td align="left">
                                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_ts_khoach_P_LKE();" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="padding-top: 2px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="15">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                                            <asp:BoundField HeaderText="Mã dự án" DataField="ma_du_an" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Tên dự án" DataField="ten_du_an" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Nhân viên" DataField="ng_nhan" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="SĐT" DataField="sdt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Email" DataField="email" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Vị trí" DataField="vi_tri" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Skill" DataField="Skill" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Man Hour" DataField="hour" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Thực tế" DataField="thuc_te" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" id="GR_lke_td" runat="server">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke" ham="ns_ts_khoach_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0"></table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,680" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="id_ct" runat="server" value="0" />
        <Cthuvien:an ID="id_cut" runat="server" value="0" />
        <Cthuvien:an ID="id_ts" runat="server" value="0" />
    </div>
</asp:Content>
