<%@ Page Title="ns_tt_cbql_dgia_hdld" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tt_cbql_dgia_hdld.aspx.cs" Inherits="f_ns_tt_cbql_dgia_hdld" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt đánh giá HĐLĐ" />
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
                            <table id="UPa_ct" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table style="margin-left: 50px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="80px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="trthai_pd" ktra="DT_TRTHAI_PD" runat="server" Width="120px"></Cthuvien:DR_lke>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--  --%>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div id="lke_cdanh" style="overflow-x: scroll">
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Đơn vị" DataField="ma_dvi" HeaderStyle-Width="200px"
                                                                    ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Ngày vào" DataField="ngayd" HeaderStyle-Width="120px"
                                                                    ItemStyle-CssClass="css_Gnd" />
                                                                <%--<asp:BoundField HeaderText="Loại HĐ đánh giá" DataField="ngay_yc" HeaderStyle-Width="120px"
                                                                    ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Trạng thái" DataField="sl_cantuyen" HeaderStyle-Width="100px"
                                                                    ItemStyle-CssClass="css_Gma_c" />--%>
                                                                <asp:BoundField DataField="nsd" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                                        ham="ns_tt_cbql_dgia_hdld_P_LKE()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="margin-top: 5px;">
                                                    <table cellpadding="0" cellspacing="0" class="tableButton">
                                                        <tr>
                                                            <td align="center">
                                                                <div class="box3 txCenter">
                                                                    <a href="#" onclick="return ns_tt_cbql_dgia_hdld_EXCEL();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất Excel</a>
                                                                    <a href="#" onclick="return ns_tt_cbql_dgia_hdld_P_CB();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>hi tiết</a>
                                                                </div>
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
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                        </div>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td colspan="4">
                                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
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
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,720" />
    </div>
</asp:Content>
