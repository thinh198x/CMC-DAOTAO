<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_nl.aspx.cs" Inherits="f_ns_hdns_ma_nl"
    Title="ns_hdns_ma_nl" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục năng lực " />
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
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,ma,ma_nhom" hamRow="ns_hdns_ma_nl_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="ma_nhom" />
                                            <asp:BoundField DataField="ma" />
                                            <asp:BoundField DataField="ten_nhom" HeaderText="Nhóm năng lực" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ten" HeaderText="Tên năng lực" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_ma_nl_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_hdns_ma_nl_P_IN();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct1" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Nhóm năng lực" Width="95px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="MA_NHOM" kt_xoa="G" ten="Nhóm năng lực" ktra="NHOM_NL" runat="server" Width="500px" />
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td colspan="2">
                                                    <Cthuvien:ma ID="so_id" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" />
                                                    <Cthuvien:ma ID="ma" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu">Mã năng lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ma_nl" ten="Mã năng lực" runat="server" CssClass="css_form" ReadOnly="true"
                                                        BackColor="#f6f7f7" kt_xoa="G" Width="500px" onfocusout="ns_hdns_ma_nl_P_KTRA('MA')" MaxLength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Tên năng lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên năng lực" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="500px" MaxLength="100" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" Width="500px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Định nghĩa</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" ten="Định nghĩa" runat="server" Height="50px" TextMode="MultiLine" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="500px" MaxLength="1000" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <div class="css_divb">
                                                        <div class="css_divCn">
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" class="gridX" hangKt="5"
                                                                loai="N" PageSize="1" cot="so_id_nl,so_id_ct,ten_muc_nl,mota,bieuhien" cotAn="so_id_nl,so_id_ct">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="5px" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="so_id_nl" runat="server" CssClass="css_Gma" BorderStyle="None" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="so_id_ct" runat="server" CssClass="css_Gma" BorderStyle="None" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="180px" HeaderText="Mức năng lực (*)">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ten_muc_nl" runat="server" CssClass="css_Gma" kieu_unicode="true" BorderStyle="None" Width="100%" MaxLength="100" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="180px" HeaderText="Mô tả">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" kieu_unicode="true" BorderStyle="None" Width="100%" MaxLength="255" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="180px" HeaderText="Biểu hiện">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="bieuhien" runat="server" CssClass="css_Gma" kieu_unicode="true" BorderStyle="None" Width="100%" MaxLength="255" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divC:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top: 5px;" colspan="2">
                                                    <table id="UPa_nhap_grct_nl" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_ma_nl_HangLen();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_ma_nl_HangXuong();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_ma_nl_CatDong();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_ma_nl_ChenDong('C');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_hdns_ma_nl_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_ma_nl_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="excelmau" runat="server" Text="Lấy mẫu Excel" Width="100px" OnClick="ns_hdns_ma_nl_P_MAU();form_P_LOI('');" Title="Lấy file excel mẫu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Import" Width="100px" OnClick="return ns_hdns_ma_nl_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return ns_hdns_ma_nl_P_CHON();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_ma_nl_P_XOA();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                                                                <%--<Cthuvien:nhap ID="FileMau" runat="server" Text="Mẫu excel" Width="90px" OnServerClick="FileMau_Click" />--%>
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,550" />
</asp:Content>
