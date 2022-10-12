<%@ Page Title="ns_dg_pd_giao_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_pd_giao_kpi.aspx.cs" Inherits="f_ns_dg_pd_giao_kpi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt giao nhiệm vụ KPI" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">

                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Tình trạng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_drop" kieu="S" Width="376px">
                                            <asp:ListItem Text="Chưa phê duyệt" Value="0" />
                                            <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                            <asp:ListItem Text="Không phê duyệt" Value="2" />
                                        </Cthuvien:DR_nhap>
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
                                            CssClass="table gridX" loai="N" hangKt="10" cot="chon,ma,ten,lan,ngayd,ma_dvi,phong,ykien">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Mã cán bộ" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Đơn vị" DataField="ma_dvi" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Phòng ban" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày giao KPI" DataField="lan" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField HeaderText="chu kỳ đánh giá" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:TemplateField HeaderText="Ý kiến phản hồi" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ykien" runat="server" Width="200px" CssClass="css_Gnd" kt_xoa="X" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_dg_pd_giao_kpi_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td colspan="2" align="center">
                <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                            <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_dg_pd_giao_kpi_CHON();" />
                        </td>
                        <td>
                            <Cthuvien:nhap ID="xem" runat="server" Text="Xem" CssClass="css_button" OnClick="return ns_dg_pd_giao_kpi_P_XEM();form_P_LOI();"
                                Width="70px" />
                        </td>
                        <td>
                            <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ns_dg_pd_giao_kpi_P_PHEDUYET();form_P_LOI();"
                                Width="90px" />
                        </td>
                        <td>
                            <Cthuvien:nhap ID="khongpheduyet" runat="server" Text="Ko phê duyệt" CssClass="css_button" OnClick="return ns_dg_pd_giao_kpi_P_KOPHEDUYET();form_P_LOI();"
                                Width="100px" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,450" />
    </div>
</asp:Content>
