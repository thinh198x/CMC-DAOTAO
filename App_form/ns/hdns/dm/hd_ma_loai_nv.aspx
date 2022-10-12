<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hd_ma_loai_nv.aspx.cs" Inherits="f_hd_ma_loai_nv"
    Title="hd_ma_loai_nv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục phân loại nhân viên" />
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
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="ghichu,nsd,so_id" hamRow="hd_ma_loai_nv_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tên phân loại NV" DataField="ten" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Cấp NV" DataField="cap" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="so_id" />
                                                <asp:BoundField DataField="ghichu" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="hd_ma_loai_nv_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Tên phân loại NV" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" ten="Tên phân loại NV"
                                                                    kt_xoa="X" Width="317px" MaxLength="20" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:ma ID="so_id" runat="server" Width="0px" kt_xoa="G" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Cấp NV" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="CAP" runat="server" CssClass="css_form" kt_xoa="X" ten="Cấp NV"
                                                        Width="317px" MaxLength="255" ></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:GridX ID="GR_nh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma,ten,so_id_cd,chon" cotAn="so_id" hangKt="5">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" runat="server" CssClass="css_Gma" kt_xoa="X" Width="80px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField DataField="so_id_cd" />
                                                            <asp:BoundField DataField="chon" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="tt" ten="Trạng thái" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" kieu="S" Width="317px">
                                                        <asp:ListItem Selected="True" Text="Áp dụng" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="Ngừng áp dụng" Value="N"></asp:ListItem>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" ten="Ghi chú"
                                                        Width="317px"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return hd_ma_loai_nv_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return hd_ma_loai_nv_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xaa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return hd_ma_loai_nv_P_XOA();form_P_LOI('');" Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1140,520" />
</asp:Content>
