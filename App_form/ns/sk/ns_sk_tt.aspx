<%@ Page Title="ns_sk_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_sk_tt.aspx.cs" Inherits="f_ns_sk_tt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Sức khỏe cán bộ" />
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
                                            CssClass="table gridX" loai="X" hangKt="6" cotAn="so_id" hamRow="ns_sk_tt_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_sk_tt_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                                        ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_sk_tt_P_KTRA('SO_THE')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label11" runat="server" Text="Năm" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_form_r" Width="120px" kieu_so="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Huyết áp" Width="75px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="huyetap" ten="Huyết áp" runat="server" kt_xoa="X" CssClass="css_form" Width="120px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Thị lực" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="thiluc" ten="Thị lực" runat="server" kt_xoa="X" CssClass="css_form" Width="120px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Cân nặng" Width="75px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cannang" ten="Cân nặng" runat="server" kt_xoa="X" CssClass="css_form" Width="120px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server" Text="Chiều cao" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="chieucao" ten="Chiều cao" runat="server" kt_xoa="X" CssClass="css_form" Width="120px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Xếp loại" Width="75px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="xeploai" ten="Xếp loại" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_lsk,ma,ten" kt_xoa="X" placeholder="Nhấn (F1)"
                                                        kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/sk/ma/ns_ma_lsk.aspx" onchange="ns_sk_tt_P_KTRA('xeploai')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="60px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" Height="50px" CssClass="css_form" Width="327px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_sk_tt_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_sk_tt_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_sk_tt_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
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
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="770,400" />
    </div>
</asp:Content>
