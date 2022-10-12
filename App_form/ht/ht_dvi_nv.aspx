<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_dvi_nv.aspx.cs" Inherits="f_ht_dvi_nv"
    Title="ht_dvi_nv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Mã người sử dụng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="width:100px;">
                                        <Cthuvien:dao ID="klk" runat="server" CssClass="css_kh_de_da" Width="85px" 
                                            ForeColor="#D5E0E3" lke="Kế toán,Tất cả" Text="Kế toán" nhap="false" 
                                            ToolTip="Liệt kê theo Modul: Kế toán, tất cả (Click để thay đổi)" AutoPostBack="true" />
                                    </td>
                                    <td align="center" style="width:50px;">
                                        <img alt="" ID="Anh3" runat="server" c/>
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
            <td valign="middle">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label5" runat="server" CssClass="css_gchu" Text="Đơn vị" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="dvi" runat="server" CssClass="css_drop" Width="270px" 
                                            DataTextField="ten" DataValueField="dvi" kieu="S" onchange="ht_mansd_P_LKE('C')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Lable8" runat="server" CssClass="css_gchu" Text="Phòng" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="phong" runat="server" CssClass="css_drop" Width="270px" 
                                            DataTextField="ten" DataValueField="ma" kieu="S" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã NSD" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_ma" Width="100px" MaxLength="10" 
                                                        kieu_chu="True" kt_xoa="G" ToolTip="Mã để quản lý NSD. Phải là duy nhất trong đơn vị" 
                                                        ten="mã NSD" onchange="ht_mansd_P_KTRA('MA')" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu" Text="Mã đăng nhập" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA_LOGIN" runat="server" CssClass="css_ma" Width="266px" MaxLength="50" 
                                                        kieu_chu="True" kt_xoa="X" ToolTip="Mã để NSD đăng nhập vào hệ thống. Phải là duy nhất trong toàn hệ thống" 
                                                        ten="mã đăng nhập" onchange="ht_mansd_P_KTRA('MA_LOGIN')" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                                <Cthuvien:anh ID="test" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/phai.gif" 
                                                                    ToolTip="Kiểm tra mã duy nhất" OnClientClick="return ht_mansd_P_TEST('C');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True" 
                                            kt_xoa="X" Width="266px" ten="tên NSD" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Width="60px" Text="Password" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="pas" runat="server" CssClass="css_nd" kt_xoa="X" TextMode="Password" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" 
                                                        Width="125px" Height="17px" Text="Nghiệp vụ" ham="ht_mansd_P_NPA('dk')" />
                                                </td>
                                                <td style="width:1px;" />
                                                <td>
                                                    <Cthuvien:tab ID="NPa_nhom" runat="server" CssClass="css_tab_ngang_de" 
                                                        Width="125px" Height="17px" Text="Nhóm" ham="ht_mansd_P_NPA('nhom')" />
                                                </td>
                                                <td style="width:1px;" />
                                                <td>
                                                    <Cthuvien:tab ID="NPa_dvi" runat="server" CssClass="css_tab_ngang_de" Width="125px" Height="17px" 
                                                        ToolTip="Danh sách đơn vị NSD quản lý" Text="Đơn vị" ham="ht_mansd_P_NPA('dvi')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width: 470px; height: 345px;">
                                        <asp:Panel ID="Pa_dk" runat="server">
                                            <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                                cot="ten,ma,nhap,xem,han,qly,MD,NV" cotAn="MD,NV" hangKt="16" ctrT="TEN" ctrS="nhap">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Nghiệp vụ" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:TemplateField HeaderText="Nhập mã" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nv_ma" runat="server" Width="50px" CssClass="css_Gma_c" 
                                                                lke="C,K" Text="C" ToolTip="Quyền khai báo mã: C-Có, K-Không" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nhập SL" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nv_nhap" runat="server" Width="50px" CssClass="css_Gma_c" 
                                                                lke="C,K" Text="C" ToolTip="Quyền nhập liệu: C-Có, K-Không" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Xem" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nv_xem" runat="server" Width="50px" CssClass="css_Gma_c" 
                                                                lke="C,K" Text="C" ToolTip="Quyền xem số liệu: C-Có, K-Không" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hạn SL" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nv_han" runat="server" Width="50px" CssClass="css_Gma_c" 
                                                                lke="C,K" Text="C" ToolTip="Quyền đặt hạn nhập liệu: C-Có, K-Không" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Q.lý" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nv_qly" runat="server" Width="50px" CssClass="css_Gma_c" 
                                                                lke="C,K" Text="C" ToolTip="Quyền quản lý nghiệp vụ: C-Có, K-Không" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="MD" />
                                                    <asp:BoundField DataField="NV" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </asp:Panel>
                                        <asp:Panel ID="Pa_nhom" runat="server" Style="display:none;">
                                            <Cthuvien:GridX ID="GR_nhom" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                                loai="N" hangKt="16" cot="ten,CHON,NHOM" cotAn="NHOM" ctrT="TEN" ctrS="nhap">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="402px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="nhom_chon" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn nhóm" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NHOM" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </asp:Panel>
                                        <asp:Panel ID="Pa_dvi" runat="server" Style="display:none;">
                                            <Cthuvien:GridX ID="GR_dvi" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                                loai="L" hangKt="16" cotAn="DVI" ctrT="TEN" ctrS="nhap" >
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="445px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField DataField="DVI" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </asp:Panel>
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
                                        <Cthuvien:nhap id="nhap" runat="server" Text="Nhập" width="80px"  OnClick="return ht_mansd_P_NH();form_P_LOI();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap id="moi" runat="server" Text="Mới" Width="80px" OnClick="return ht_mansd_P_MOI();form_P_LOI();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap id="xoa" runat="server" Text="Xóa" Width="80px" OnClick="return ht_mansd_P_XOA();form_P_LOI();" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <Cthuvien:anh ID="dia" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/dia.gif" 
                                                        ToolTip="Lấy số liệu vào từ File" OnClientClick="return ht_mansd_FILE();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td id="id_chen" runat="server" style="display:none;">
                                        <table cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td align="center" valign="middle" style="border: lightgray 1px solid; width:20px;">
                                                    <Cthuvien:anh ID="dvi_cat" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/cat.gif" 
                                                        ToolTip="Cắt các dòng đã chọn" OnClientClick="return ht_mansd_CatDong();" />
                                                </td>
                                                <td align="center" valign="middle" style="border: lightgray 1px solid; width:20px;">
                                                    <Cthuvien:anh ID="dvi_chen" runat="server" ImageUrl="~/images/bitmaps/chen.gif" 
                                                        ToolTip="Chèn dòng" OnClientClick="return ht_mansd_ChenDong();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="display:none;">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" valign="middle" style="border: lightgray 1px solid; width:20px;">
                                                    <Cthuvien:anh ID="tiep" runat="server" ImageUrl="~/images/bitmaps/phai.gif" 
                                                    ToolTip="Chọn nghiệp vụ NSD" OnClientClick="return ht_mansd_Chon();" />
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
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                loai="X" hangKt="15" hamRow="ht_mansd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                        <td class="css_scrl_td">
                            <khud_scrl:khud_scrl ID="GR_lke_slide" loai="X" runat="server" gridId="GR_lke" ham="ht_mansd_P_LKE('K')" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,685" />
</asp:Content>
