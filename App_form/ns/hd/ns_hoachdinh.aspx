<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hoachdinh.aspx.cs" Inherits="f_ns_hoachdinh"
    Title="ns_hoachdinh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hoạch định" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="L" hangKt="15" cot="iurl,xep,ten,ten_xep,ma,ma_ct,nsd,loai" cotAn="xep,ten,ma,ma_ct,nsd,loai" hamRow="ns_hoachdinh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-CssClass="css_Gma_c">
                                                    <ItemTemplate>
                                                        <Cthuvien:anh ID="iurl" runat="Server" Enabled="false" CssClass="css_Gma_c" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ShowHeader="false" HeaderText="Mã" DataField="xep" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên" DataField="ten" />
                                                <asp:BoundField HeaderText="Tên" DataField="ten_xep" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="ma" HeaderStyle-Width="100px" />
                                                <asp:BoundField DataField="ma_ct" HeaderStyle-Width="100px" />
                                                <asp:BoundField DataField="nsd" />
                                                <asp:BoundField DataField="loai" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                    <td class="css_scrl_td">
                                        <khud_scrl:khud_scrl ID="GR_lke_slide" runat="server" loai="L" gridId="GR_lke" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="them_cdanh" runat="server" Width="70px" Text="Thêm" OnClick="return ns_hoachdinh_cdanh_CHON();" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa_cdanh" runat="server" Text="Xóa" Width="70px" hoi="2" OnClick="return ns_hoachdinh_cdanh_XOA();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Width="50px" Text="Mã" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" kieu_chu="True"
                                                        kt_xoa="G" Width="120px" onchange="ns_hoachdinh_P_KTRA('MA')" />
                                                </td>
                                               <%-- <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" Width="60px" />
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                     <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="120px" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                     <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Số lượng hiện có" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="hienco" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="120px" Text="0"/>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr style="display: none">
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Mã q.lý" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ma_ct" runat="server" CssClass="css_ma" Width="120px" kieu_chu="True"
                                                        kt_xoa="K" ktra="ht_ma_phong,ma" ten="mã quản lý" onchange="ns_hoachdinh_P_KTRA('ma_ct')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left">

                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                                Height="20px" Text="Năng lực cốt lõi" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                                Height="20px" Text="Kỹ năng" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:tab ID="NPa_dt" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                                Height="20px" Text="Hoạch định" />
                                                                        </td>
                                                                        <%-- <td>
                                                                <Cthuvien:tab ID="NPa_hoachdinh" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Hoạch định" />
                                                            </td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" class="tab_content">
                                                                <asp:Panel ID="Pa_dk" runat="server" Style="height: 300px; width: 750px; display: block;">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <Cthuvien:GridX ID="GridX2" runat="server" loai="N"
                                                                                    AutoGenerateColumns="false" hangKt="10" cot="stt,cviec" PageSize="1" CssClass="table gridX" cotAn="ma">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                        <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="80px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="noidung" runat="server" Width="80px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Chuyên môn" HeaderStyle-Width="100px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="chuyenmon" runat="server" Width="80px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Cấp độ" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="capdo" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="trongso" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Kỹ năng" HeaderStyle-Width="100px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="kynang" runat="server" Width="80px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Cấp độ" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="capdo1" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="trongso1" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Tính cách" HeaderStyle-Width="100px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="tinhcanh" runat="server" Width="80px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Cấp độ" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="capdo2" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:so ID="trongso2" runat="server" Width="60px" CssClass="css_Gso" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </Cthuvien:GridX>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </asp:Panel>
                                                                <asp:Panel ID="Pa_kq" runat="server" Style="height: 300px; width: 750px; display: none;">

                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <div id="UPa_lke">
                                                                                    <Cthuvien:GridX ID="GR_kn" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                                        hangKt="10" CssClass="table gridX" cot="makn,tenkn,yeucau" cotAn="makn">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                            <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="350px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="makn" runat="server" CssClass="css_Gma" ToolTip="Mã kỹ năng" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Tên kỹ năng" HeaderStyle-Width="250px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="tenkn" runat="server" Width="250px" CssClass="css_Gma" ToolTip="Kỹ năng chính" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="yeucau" runat="server" Width="100px" CssClass="css_Gma" ToolTip="Yêu cầu" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="yeuca2u" runat="server" Width="100px" CssClass="css_Gma" ToolTip="Yêu cầu" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </Cthuvien:GridX>
                                                                                </div>
                                                                            </td>
                                                                        </tr>

                                                                    </table>

                                                                </asp:Panel>
                                                                <asp:Panel ID="Pa_dt" runat="server" Style="height: 300px; width: 750px; display: none;">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <div id="UPa_dt">
                                                                                    <Cthuvien:GridX ID="GridX1" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                                        hangKt="10" CssClass="table gridX" cot="makn,tenkn,yeucau" cotAn="makn">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                            <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="350px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="makn" runat="server" CssClass="css_Gma" ToolTip="Mã kỹ năng" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Từ ngày" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="tenkn" runat="server" Width="250px" CssClass="css_Gma" ToolTip="Kỹ năng chính" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Tới ngày" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="yeucau" runat="server" Width="100px" CssClass="css_Gma" ToolTip="Yêu cầu" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Số lượng cần" HeaderStyle-Width="250px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="yeuca2u" runat="server" Width="100px" CssClass="css_Gma" ToolTip="Yêu cầu" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </Cthuvien:GridX>
                                                                                </div>
                                                                            </td>
                                                                        </tr>

                                                                    </table>

                                                                </asp:Panel>
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
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return ns_hoachdinh_P_NH();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_hoachdinh_P_XOA();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Width="90px" Text="Tuyển dụng" OnClick="return form_P_TRA_CHON('MA');" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,565" />
</asp:Content>
