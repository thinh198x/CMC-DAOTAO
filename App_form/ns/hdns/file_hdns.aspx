<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_hdns.aspx.cs" Inherits="f_file_hdns"
    Title="file_hdns" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td align="left">
                        <Cthuvien:luu ID="tenmanhinh" runat="server" CssClass="css_tieudeM" Text="" />
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
                                        CssClass="table gridX" loai="X" hangKt="5" cotAn="so_id,ten" hamRow="file_hdns_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Tên file" DataField="ten_file" HeaderStyle-Width="150px"
                                                ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngày nhập" DataField="ngay" HeaderStyle-Width="85px"
                                                ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="url" DataField="url" HeaderStyle-Width="200px"
                                                ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            <asp:BoundField HeaderText="ten" DataField="ten" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </td>
                            </tr>
                            <tr>
                                <td id="GR_lke_td" runat="server" align="center">
                                    <khud_slide:khud_slide ID="GR_lke_slide" rong="20" runat="server" loai="X" gridId="GR_lke"
                                        ham="file_hdns_P_LKE()" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="form_right">
                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                            <tr style="display: none">
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Width="70px" Text="Ngày nhập" />
                                </td>
                                <td align="left">
                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" runat="server" CssClass="css_form_c" Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Width="70px" Text="Tên File" />
                                </td>
                                <td>
                                    <Cthuvien:ma ID="ten_file" runat="server" CssClass="css_form" Width="250px" ten="Tên file" kt_xoa="X" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Width="70px" Text="Chọn File" />
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="chon_file" runat="server" Width="250px" ssClass="css_form" accept="application/vnd.ms-excel"/>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Width="70px" Text="Đường dẫn" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <Cthuvien:luu ID="ten" runat="server" CssClass="css_link_X" />
                                </td>
                            </tr>
                            <tr align="center">
                                <td align="center" colspan="2" style="padding-top: 5px;">
                                    <table cellpadding="1" cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td>
                                                <div class="box3 txRight2">
                                                    <caption style="text-align:right">
                                                        <a class="bt bt-grey" href="#" onclick="return file_hdns_P_NH();form_P_LOI();"><i class="fa fa-save"></i>Nhập</a>
                                                        <a class="bt bt-grey" href="#" onclick="return file_hdns_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i>Xóa</a>
                                                        <a class="bt bt-grey" href="#" onclick="return download_file();form_P_LOI();"><i class="fa fa-download"></i>Download</a>
                                                    </caption>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="display: none">
                                                <Cthuvien:nhap ID="Nhap2" runat="server" giu="false" OnServerClick="nhap_Click" Text="Nhập" Width="70px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="nhap2" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,380" />
        <Cthuvien:an ID="ten_form" runat="server" Value="" />
        <Cthuvien:an ID="nv" runat="server" Value="" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="ten_kq" runat="server" Value="" />
        <Cthuvien:an ID="tra_dong" runat="server" Value="FILE_HTOAN" />
        <Cthuvien:an ID="url" runat="server" Value="" />
        <Cthuvien:an ID="thamso1_cc" runat="server" Value="" />
        <Cthuvien:an ID="thamso2_cc" runat="server" Value="" />
        <Cthuvien:an ID="thamso3_cc" runat="server" Value="" />
        <Cthuvien:an ID="thamso4_cc" runat="server" Value="" />
    </div>
</asp:Content>
