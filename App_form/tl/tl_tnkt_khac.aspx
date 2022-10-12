<%@ Page Title="tl_tnkt_khac" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tnkt_khac.aspx.cs" Inherits="f_tl_tnkt_khac" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Thu nhập/Khấu trừ khác" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
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
                                            CssClass="table gridX" loai="X" hangKt="6" hamRow="tl_tnkt_khac_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="tl_tnkt_khac_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="70px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="146px"
                                                        f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="tl_tnkt_khac_P_KTRA('SO_THE')"
                                                        gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Loại" Width="60px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="loai" runat="server" CssClass="css_form_c" Width="120px" ten="ten_kieu"
                                                        Text="T" lke="T,K" ToolTip="T-Thu nhập, K-Khấu trừ" onblur="tl_tnkt_khac_P_KTRA('LOAI')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Ngày" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" Width="120px" CssClass="css_form_c" kt_xoa="G"
                                                            kieu_luu="S" onchange="tl_tnkt_khac_P_KTRA('NGAY')" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Số tiền" Width="60px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tien" runat="server" Width="120px" CssClass="css_form" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Chịu thuế" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:kieu ID="chiuthue" runat="server" CssClass="css_form_c" Width="50px" ten="ten_kieu"
                                                        Text="C" lke="C,K" ToolTip="C-Có, K-Không" />
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Nội dung" Width="80px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nd ID="note" ten="Nội dung" kieu_unicode="true" runat="server" CssClass="css_form" Width="340px"
                                                        kt_xoa="X" TextMode="MultiLine" Height="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return tl_tnkt_khac_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return tl_tnkt_khac_P_MOI();form_P_LOI();" class="bt bt-grey">Mới</a>
                                                        <a href="#" onclick="return tl_tnkt_khac_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                    </div>
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,400" />
    </div>
</asp:Content>
