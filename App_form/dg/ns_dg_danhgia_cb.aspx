<%@ Page Title="ns_dg_danhgia_cb" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_danhgia_cb.aspx.cs" Inherits="f_ns_dg_danhgia_cb" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá cán bộ chung " />
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
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_dg_danhgia_cb_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng đánh giá" DataField="thang" HeaderStyle-Width="235px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="20" gridId="GR_lke"
                                            ham="ns_dg_danhgia_cb_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="C_out form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="300px" CssClass="css_form"
                                                                    onchange="tl_tn_tu_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Tháng đánh giá" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_form_c" kt_xoa="G"
                                                                        kieu_luu="S" />
                                                                    </div>
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
                                        <table cellpadding="0" cellspacing="0" width="200px">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="SO_THE,TEN,PHONG,TEN_PHONG,MA_CDANH,CDANH,DIEMSO,NOTE" hangKt="19" gchuId="gchu"
                                                        cotAn="PHONG,MA_CDANH" ctrT="so_tt" ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Mã CB" DataField="SO_THE" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                            <asp:BoundField HeaderText="Họ Tên" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                            <asp:BoundField HeaderText="Phòng" DataField="PHONG" />
                                                            <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                                                            <asp:BoundField HeaderText="Mã cd" DataField="MA_CDANH" />
                                                            <asp:BoundField HeaderText="Vị trí" DataField="CDANH" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                                            <asp:TemplateField HeaderText="Điểm số" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="DIEMSO" runat="server" Width="100px" CssClass="css_Gso" so_tp="2" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="160px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="NOTE" runat="server" Width="160px" CssClass="css_Gma" kieu_unicode="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                                <td class="css_scrl_td">
                                                    <khud_scrl:khud_scrl ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" ham="ns_tl_tu_lke_ct();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dg_danhgia_cb_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dg_danhgia_cb_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dg_danhgia_cb_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return ns_dg_danhgia_cb_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">I</span>n</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_danhgia_cb_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_danhgia_cb_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_danhgia_cb_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_dg_danhgia_cb_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
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
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1426,870" />
    </div>
</asp:Content>
