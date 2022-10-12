<%@ Page Title="ns_ma_cc_baccdanh" Language="C#" MasterPageFile="~/trangnen.master"
    AutoEventWireup="true" CodeFile="ns_ma_cc_baccdanh.aspx.cs" Inherits="f_ns_ma_cc_baccdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Bậc tay nghề" />
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
                                            CssClass="table gridX" loai="X" hangKt="9" cotAn="so_id" hamRow="ns_ma_cc_baccdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngayd" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_ma_cc_baccdanh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">

                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Nhóm" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="NCDANH" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="140px" f_tkhao="~/App_form/ns/ma/ns_ma_cc_ncdanh.aspx" gchu="gchu" onchange="ns_ma_cc_baccdanh_P_KTRA('NCDANH')"
                                                        ktra="ns_ma_cc_ncdanh,ma,ten" ten="Nhóm chức danh" kt_xoa="K" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Chức danh" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="CDANH" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="140px" f_tkhao="~/App_form/ns/ma/ns_ma_cc_cdanh.aspx" gchu="gchu" onchange="ns_ma_cc_baccdanh_P_KTRA('CDANH')"
                                                        ktra="ns_ma_cc_cdanh,ncdanh,ma,ten" ten="Chức danh" guiId="NCDANH" kt_xoa="K" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Ngày" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" CssClass="css_form_c" Width="140px" kieu_luu="S" kt_xoa="G"
                                                        xuly_Enter="true" ten="Ngày áp dụng" onblur="ns_ma_cc_baccdanh_P_KTRA('NGAYD')" />
                                                    <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" />
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
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma,hso,sl_yc" hangKt="5" gchuId="gchu" ctrT="so_tt"
                                                        ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Bậc" HeaderStyle-Width="140px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="160px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="hso" runat="server" Width="100px" CssClass="css_Gso" so_tp="3" co_dau="C" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sản lượng yêu cầu" HeaderStyle-Width="160px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="sl_yc" runat="server" Width="100px" CssClass="css_Gso" so_tp="3" co_dau="C" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 10px">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="right">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_ma_cc_baccdanh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ma_cc_baccdanh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:hso,GR_ct:sl_yc');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_ma_cc_baccdanh_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_ma_cc_baccdanh_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_ma_cc_baccdanh_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_ma_cc_baccdanh_ChenDong('C');" />
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
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="780,500" />
    </div>
</asp:Content>
