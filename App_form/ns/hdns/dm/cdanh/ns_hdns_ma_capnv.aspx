<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_capnv.aspx.cs" Inherits="f_ns_hdns_ma_capnv"
    Title="ns_hdns_ma_capnv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục cấp nhân viên" />
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
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="15" cotAn="maplnv,ma_plnv" hamRow="ns_hdns_ma_capnv_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Phân loại NV" DataField="ten_plnv" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã cấp NV" DataField="ma" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên cấp NV" DataField="ten" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="maplnv" />
                                                    <asp:BoundField DataField="ma_plnv" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div>
                                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_ma_capnv_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 40px;">
                                        <div style="padding-top: 18px;">
                                            <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" OnServerClick="excel_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr style="display: none">
                                                <td></td>
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" Width="0px" kt_xoa="G" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Width="120px" CssClass="css_gchu">Phân loại CBNV</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_PLNV" ten="Phân loại CBNV" ktra="DT_HD_MA_PLNV" runat="server" Width="317px" kt_xoa="G" onchange="ns_hdns_ma_capnv_P_KTRA('MA');"></Cthuvien:DR_lke>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Mã Cấp NV" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kt_xoa="G" ten="Mã Cấp NV" kieu_chu="true"
                                                        Width="317px" MaxLength="20" onchange="ns_hdns_ma_capnv_P_KTRA('MA');"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Tên Cấp NV" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" ten="Tên Cấp NV"
                                                        kt_xoa="X" Width="317px" MaxLength="100" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                </td>
                                                <td align="left">
                                                    <div style="height: 200px; overflow-y: auto;">
                                                        <Cthuvien:GridX ID="GR_nh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="ma_cd,ten,SO_ID" cotAn="SO_ID" hangKt="5">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma_cd" runat="server" ReadOnly="true" Width="80px" CssClass="css_Gma" kt_xoa="X"
                                                                            kieu_chu="True" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" placeholder="Nhấn (F1)" BackColor="#f6f7f7" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="SO_ID" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_ma_capnv_CatDong();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" runat="server" Width="317px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px" ten="Mô tả"
                                                        Width="317px"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_hdns_ma_capnv_P_MOI();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_hdns_ma_capnv_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('TEN,CAP,SO_ID');form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_hdns_ma_capnv_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,680" />
</asp:Content>

