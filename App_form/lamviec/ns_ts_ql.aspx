<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_ql.aspx.cs" Inherits="f_ns_ts_ql" Title="ns_ts_ql" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Liệt kê công việc " />
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
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="TU_NGAY_TK" runat="server" CssClass="css_form_c" Width="120px" kt_xoa="Z"
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="120px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="DEN_NGAY_TK" runat="server" CssClass="css_form_c" Width="120px" kt_xoa="Z"
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Người nhận" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="NG_NHAN_TK" runat="server" CssClass="css_form" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Phòng ban</td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="phong" runat="server" CssClass="css_form" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <%--<td align="left" style="width: 45px"></td>--%>
                                                <td>
                                                    <div class="box3" style="padding-left:10px;">
                                                        <a href="#" onclick="return ns_ts_ql_P_LKE();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                    </div>
                                                </td>
                                                <%--<td style="width: 50px">
                                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_ts_ql_P_LKE();" />
                                                </td>--%>
                                                <td></td>
                                                <td align="left"></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 2px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" cot="sott,ngay,ten,nd,ghi_chu,tu_gio,den_gio,so_phut" cotAn="sott" PageSize="1" CssClass="table gridX" loai="X" hangKt="15">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                                            <asp:BoundField DataField="sott" HeaderStyle-Width="18px" />
                                                            <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Ng nhận" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Công việc" DataField="nd" HeaderStyle-Width="200px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Ghi chú" DataField="ghi_chu" HeaderStyle-Width="200px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Từ" DataField="tu_gio" HeaderStyle-Width="50px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Đến" DataField="den_gio" HeaderStyle-Width="50px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Số phút" DataField="so_phut" HeaderStyle-Width="50px" ItemStyle-CssClass="css_so" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" id="GR_lke_td" runat="server">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke" ham="ns_ts_ql_P_LKE()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txCenter">
                                                    <div class="box3" style="padding-top:5px;">
                                                        <a href="#" onclick="return ns_ts_ql_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">I</span>n</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_ts_ql_P_IN();"
                                                        Width="70px" />
                                                </td>--%>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="id_ct" runat="server" value="0" />
        <Cthuvien:an ID="id_cut" runat="server" value="0" />
        <Cthuvien:an ID="id_ts" runat="server" value="0" />
    </div>
</asp:Content>
