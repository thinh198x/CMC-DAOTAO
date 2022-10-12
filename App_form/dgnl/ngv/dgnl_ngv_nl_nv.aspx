<%@ Page Title="dgnl_ngv_nl_nv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dgnl_ngv_nl_nv.aspx.cs" Inherits="f_dgnl_ngv_nl_nv" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá năng lực cán bộ nhân viên " />
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
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,ma,dot_dgia" hamRow="dgnl_ngv_nl_nv_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="ma" DataField="ma" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Đợt đánh giá" DataField="DOT_DGIA" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Đợt đánh giá" DataField="DOT_DGIA_TEN" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                            ham="dgnl_ngv_nl_nv_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1" class="form_right">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label8" runat="server" Text="Năm" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="NAM" runat="server" ten="Năm" kt_xoa="X" CssClass="css_form" kieu_so="true"
                                                        Width="140px" />
                                                    <Cthuvien:an ID="hincd" runat="server" Value="" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label9" runat="server" Text="Đợt đánh giá" Width="100px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="DOT_DGIA" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                                        Width="140px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_ddg_nl.aspx" gchu="gchu" guiId="NAM" ten="Đợt đánh giá"
                                                        onfocusout="dgnl_ngv_nl_nv_P_KTRA('DOT')" ktra="dg_dm_ddg_nl,ma,ten" placeholder="Nhấn F1" />
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
                                                    <div style="height: 400px; width: 700px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" hamUp="dgnl_ngv_nl_nv_Update"
                                                            CssClass="table gridX" loai="N" hangKt="15" cot="tt,so_the,ten,phong,nhom_nl_ten,nangluc_ten,muc_nl,muc_nl_cn,gchu,nhom_nl,nangluc"
                                                            cotAn="tt,nhom_nl,nangluc">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="STT" HeaderStyle-Width="30px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:so ID="tt" runat="server" Width="30px" CssClass="css_Gma_c" kieu_luu="I" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mã cán bộ(*)" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                                            ktra="ns_cb,so_the,ten" kieu_chu="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="150px"
                                                                    ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:TemplateField HeaderText="Nhóm năng lực(*)" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="nhom_nl_ten" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                            Width="200px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_n_nl.aspx" gchu="gchu" ten="Nhóm năng lực"
                                                                            onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MA_NHOM')" ktra="dg_dm_nhom_nl,ma,ten" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Năng lực(*)" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="nangluc_ten" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                            Width="200px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_nl.aspx" gchu="gchu" ten="năng lực" guiId="hincd"
                                                                            onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MANL')" ktra="dg_dm_nl,ma,ten" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Năng lực chuẩn(*)" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="mucnl" runat="server" Width="150px" CssClass="css_Gma" kieu_unicode="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mức năng lực theo nhân viên(*)" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="muc_nl_cn" runat="server" Width="150px" CssClass="css_Gma" kieu_unicode="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="gchu" runat="server" Width="150px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Nhóm năng lực" DataField="nhom_nl" HeaderStyle-Width="100px">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Năng lực" DataField="nangluc" HeaderStyle-Width="80px">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
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
                                                        <a href="#" onclick="return dgnl_ngv_nl_nv_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return dgnl_ngv_nl_nv_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return dgnl_ngv_nl_nv_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_ngv_nl_nv_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_ngv_nl_nv_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" CssClass="css_button"
                                                        OnClick="return dgnl_ngv_nl_nv_P_XOA();form_P_LOI();" />
                                                </td>--%>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return dgnl_ngv_nl_nv_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return dgnl_ngv_nl_nv_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return dgnl_ngv_nl_nv_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return dgnl_ngv_nl_nv_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 5px;">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,540" />
    </div>
</asp:Content>
