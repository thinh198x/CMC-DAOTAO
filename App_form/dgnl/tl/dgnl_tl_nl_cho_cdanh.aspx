<%@ Page Title="dgnl_tl_nl_cho_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dgnl_tl_nl_cho_cdanh.aspx.cs" Inherits="f_dgnl_tl_nl_cho_cdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <%--<th  colspan="2" align="left"><Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập năng lực cho chức danh" /></th>--%>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập năng lực cho chức danh " />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="17" cotAn="so_id,cdanh" hamRow="dgnl_tl_nl_cho_cdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Chức danh" DataField="cdanh_ten" HeaderStyle-Width="275px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                            ham="dgnl_tl_nl_cho_cdanh_P_LKE()" />
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
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu">Chức danh</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="CDANH" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="137px" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" gchu="gchu" ten="Chức danh"
                                                        onfocusout="dgnl_tl_nl_cho_cdanh_P_KTRA('CDANH')" kt_xoa="G" ktra="ns_ma_cdanh,ma,ten" placeholder="Nhấn F1" />
                                                    <Cthuvien:an ID="hincd" runat="server" Value="" />
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
                                                        CssClass="table gridX" loai="N" hangKt="15" cot="sott,NHOM_NL_TEN,NANGLUC_TEN,muc_nl,gchu,so_id,nhom_nl,nangluc"
                                                        cotAn="sott,so_id,nhom_nl,nangluc" hamUp="dgnl_tl_nl_cho_cdanh_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="STT" DataField="sott">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Nhóm năng lực(*)" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="NHOM_NL_TEN" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                        Width="200px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_n_nl.aspx" gchu="gchu" ten="Nhóm năng lực"
                                                                        onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MA_NHOM')" ktra="dg_dm_nhom_nl,ma,ten" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Năng lực(*)" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="NANGLUC_TEN" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                        Width="200px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_nl.aspx" gchu="gchu" ten="năng lực" guiId="hincd"
                                                                        onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MANL')" ktra="dg_dm_nl,ma,ten" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mức năng lực theo chức danh(*)" HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="muc_nl" runat="server" Width="150px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="gchu" runat="server" Width="150px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="so_id" DataField="so_id">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nhom_nl" DataField="nhom_nl">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nangluc" DataField="nangluc">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle">
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return dgnl_tl_nl_cho_cdanh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return dgnl_tl_nl_cho_cdanh_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return dgnl_tl_nl_cho_cdanh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_tl_nl_cho_cdanh_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_tl_nl_cho_cdanh_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_tl_nl_cho_cdanh_P_XOA();form_P_LOI();" />
                                                </td>--%>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return dgnl_tl_nl_cho_cdanh_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return dgnl_tl_nl_cho_cdanh_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return dgnl_tl_nl_cho_cdanh_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return dgnl_tl_nl_cho_cdanh_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1020,500" />
    </div>
</asp:Content>
