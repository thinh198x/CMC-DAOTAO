<%@ Page Title="ns_hdns_nl_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_nl_cdanh.aspx.cs" Inherits="f_ns_hdns_nl_cdanh" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Gán năng lực cho vị trí chức danh" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id" hamRow="ns_hdns_nl_cdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_hdns_nl_cdanh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Width="100px">Ngày hiệu lực</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" MaxLength="10" runat="server" CssClass="css_form_c" kt_xoa="G" Width="100px"
                                                                        ten="Ngày hiệu lực" onchange="ns_hdns_nl_cdanh_P_KTRA('NGAY')" kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                        CssClass="table gridX" loai="N" cot="thunhaptu,thunhapden,thuesuat" hangKt="8" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Thu nhập từ (*)" HeaderStyle-Width="140px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="thunhaptu" MaxLength="10" runat="server" kt_xoa="G" Text="0" nhap="true" Width="120px" CssClass="css_Gso" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Thu nhập đến (*)" HeaderStyle-Width="140px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="thunhapden" MaxLength="10" runat="server" Width="120px" CssClass="css_Gso" so_tp="2" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Thuế suất (%)(*)" HeaderStyle-Width="140px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="thuesuat" MaxLength="2" runat="server" Width="120px" CssClass="css_Gma_c" so_tp="2" />
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
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_hdns_nl_cdanh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return ns_hdns_nl_cdanh_P_MOI();form_P_LOI();" class="bt bt-grey">Mới</a>
                                                        <a href="#" onclick="return ns_hdns_nl_cdanh_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_nl_cdanh_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_nl_cdanh_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_nl_cdanh_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_nl_cdanh_ChenDong('C');" />
                                                </td>
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
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="780,490" />
    </div>
</asp:Content>
