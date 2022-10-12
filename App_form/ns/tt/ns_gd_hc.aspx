<%@ Page Title="ns_gd_hc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_gd_hc.aspx.cs" Inherits="f_ns_gd_hc" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hoàn cảnh kinh tế" />
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
                        <td valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="16" cotAn="so_id" hamRow="ns_gd_hc_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày kê khai" DataField="ngayd" HeaderStyle-Width="125px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                            ham="ns_gd_hc_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label10" runat="server" Text="Mã số cán bộ" CssClass="css_gchu_nl" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" Width="170px" nhap="true"
                                                        BackColor="#f6f7f7" ten="Mã số cán bộ" kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                        ktra="ns_cb,so_the,ten" onchange="ns_gd_hc_P_KTRA('so_the')" kieu_chu="true" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" Text="Ngày kê khai" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày kê khai" Width="140px" CssClass="css_form_c" kt_xoa="X"
                                                            kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Thu nhập chính trong năm" CssClass="css_gchu_nl" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="thunhap_chinh" runat="server" kt_xoa="X" CssClass="css_form_r" Width="170px"
                                                        kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Thu nhập khác" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="thunhap_khac" runat="server" Width="170px" kt_xoa="X" CssClass="css_form_r"
                                                        kieu_unicode="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Bình quân 1 người/ hộ" CssClass="css_gchu_nl" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="binhquan" runat="server" Width="170px" CssClass="css_form_r" kt_xoa="X"
                                                        so_tp="2" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Loại nhà được cấp, được thuê" CssClass="css_gchu_c"
                                                        Width="185px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lnha_cap" runat="server" CssClass="css_form_r" Width="170px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="DT nhà được cấp, được thuê (m2)" CssClass="css_gchu_nl"
                                                        Width="205px" ToolTip="Diện tích nhà được cấp, được thuê (m2)" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="snha_cap" runat="server" Width="170px" CssClass="css_form_r" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Loại nhà tự mua, tự xây" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lnha_mua" runat="server" CssClass="css_form" Width="170px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="DT nhà tự mua, tự xây" CssClass="css_gchu_nl"
                                                        ToolTip="Diện tich nhà tự mua, tự xây" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="snha_mua" runat="server" Width="170px" CssClass="css_form_r" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Diện tích đất được cấp" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="sdat_cap" runat="server" kt_xoa="X" CssClass="css_form_r" Width="170px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Diện tích đất tự mua" CssClass="css_gchu_nl" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="sdat_mua" runat="server" kt_xoa="X" Width="170px" CssClass="css_form_r" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Diện tích đất trang trại" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="sdat_tt" runat="server" CssClass="css_form_r" Width="170px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Số LĐ thuê mướn (người)" ToolTip="Số lao động thuê mướn (người)"
                                                        CssClass="css_gchu_nl" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="ld_thue" runat="server" Width="170px" kt_xoa="X" CssClass="css_form_r" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Hoạt động KT của GĐ CB" CssClass="css_gchu_c"
                                                        Width="150px" ToolTip="Hoạt động kinh tế của gia đình cán bộ" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="hd_kinhte" runat="server" Width="170px" CssClass="css_form" kt_xoa="X"
                                                        kieu_unicode="true" />
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
                                                        CssClass="table gridX" loai="N" cot="tt,ten,gtri" cotAn="tt" hangKt="10" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="TT" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="tt" runat="server" Width="50px" CssClass="css_Gma_c" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tên tài sản(*)" HeaderStyle-Width="432px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ten" runat="server" Width="425px" CssClass="css_Gma" kieu_unicode="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Giá trị (VNĐ)(*)" HeaderStyle-Width="280px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="gtri" runat="server" Width="280px" CssClass="css_Gma_r" kieu_so="true" />
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
                                    <td align="center" valign="middle">
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_gd_hc_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_gd_hc_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_gd_hc_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_gd_hc_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_gd_hc_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_gd_hc_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_gd_hc_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1020,700" />
    </div>
</asp:Content>
