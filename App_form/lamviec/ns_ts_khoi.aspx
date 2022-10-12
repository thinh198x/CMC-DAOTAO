<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_khoi.aspx.cs" Inherits="f_ns_ts_khoi" Title="ns_ts_khoi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Manday dự trữ khối" />
                        </td>
                        <td align="right">
                            <table id="UPa_dau" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Img1" runat="server" alt="" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img3" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                <table id="UPa_ct" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="TU_NGAY_TK" runat="server" CssClass="css_ngay" Width="120px" kt_xoa="Z"
                                                        ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                </td>
                                                <td style="width: 79px"></td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="120px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="DEN_NGAY_TK" runat="server" CssClass="css_ngay" Width="120px" kt_xoa="Z"
                                                        ten="ngày khám" kieu_luu="I" kieu_date="true" />
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
                                                    <Cthuvien:DR_nhap ID="phong" runat="server" CssClass="css_drop" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Dự án" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="duan" runat="server" CssClass="css_drop" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td style="width: 50px">
                                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_ts_khoi_P_LKE();" />
                                                </td>
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
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" cot="sott,ma_du_an,ten_du_an,tong_manday_lsx,tong_manday_giao,tong_dutru" cotAn="sott" PageSize="1" CssClass="table gridX" loai="X" hangKt="15">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                                            <asp:BoundField DataField="sott" HeaderStyle-Width="18px" />
                                                            <asp:BoundField HeaderText="Mã VV" DataField="ma_du_an" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:TemplateField HeaderText="Tên dự án" HeaderStyle-Width="350px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="Ten_du_an" runat="server" Enabled="false" CssClass="css_Gma" Width="550px"></Cthuvien:ma>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tổng Manday LSX" DataField="tong_manday_lsx" HeaderStyle-Width="120px" ItemStyle-CssClass="css_so" />
                                                            <asp:BoundField HeaderText="Tổng Manday giao" DataField="tong_manday_giao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_so" />
                                                            <asp:BoundField HeaderText="Tổng Manday dự trữ" DataField="tong_dutru" HeaderStyle-Width="120px" ItemStyle-CssClass="css_so" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" id="GR_lke_td" style="padding-left: 286px;">
                                                    <table id="UPa_tong" cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke" ham="ns_ts_khoi_P_LKE()" />
                                                            </td>
                                                            <td style="text-align:right;padding-left: 200px;">
                                                                <asp:Label Font-Bold="true" ID="lableTong" runat="server" Text="Tổng:"></asp:Label>                                                                
                                                            </td>
                                                            <td  style="text-align:right">                                                                
                                                                <Cthuvien:gchu ID="tong"  Font-Bold="true" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                            </td>
                                                        </tr>                                                        
                                                    </table>                                                                                                                                                                
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_ts_khoi_P_IN();"
                                                        Width="70px" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,650" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="id_ct" runat="server" value="0" />
        <Cthuvien:an ID="id_cut" runat="server" value="0" />
        <Cthuvien:an ID="id_ts" runat="server" value="0" />
    </div>
</asp:Content>
