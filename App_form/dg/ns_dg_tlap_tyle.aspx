<%@ Page Title="ns_dg_tlap_tyle" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_tlap_tyle.aspx.cs" Inherits="f_ns_dg_tlap_tyle" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập hệ số hưởng sau đánh giá" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
            <td valign="middle">
                <table runat="server" border="0" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table cellspacing="0" id="UPa_ct" >
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="100px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="120px" kieu_luu="S"
                                                        ten="Ngày hiệu lực" onchange = "ns_dg_tlap_tyle_P_KTRA('NGAY')" />
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
                                            CssClass="table gridX" loai="N" cot="tyle,nguoi_ld,nguoi_sdld" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap" >
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Tỷ lệ đạt KPI (%)" HeaderStyle-Width="140px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="tyle" runat="server" Width="140px" CssClass="css_Gma_c"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tỷ lệ hưởng lương (%)" HeaderStyle-Width="140px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="nguoi_ld" runat="server" Width="140px" CssClass="css_Gma_c"/>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tỷ lệ hưởng phụ cấp (%)" HeaderStyle-Width="140px"> 
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="nguoi_sdld" runat="server" Width="140px" CssClass="css_Gma_c"/>
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
                        <td align="center">
                            <table id = "UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_tlap_tyle_P_NH();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_tlap_tyle_P_MOI();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_tlap_tyle_P_XOA();form_P_LOI();" Width="70px"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="6" cotAn="so_id" hamRow="ns_dg_tlap_tyle_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id"/>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="ns_dg_tlap_tyle_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    </table>
                </td>
            </tr>

    </table>
    <div id ="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0"/>
        <Cthuvien:an ID="kthuoc" runat="server" Value="660,300" />
    </div>
</asp:Content>
