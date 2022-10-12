<%@ Page Title="ns_dg_giao_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_giao_kpi.aspx.cs" Inherits="f_ns_dg_giao_kpi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Giao KPI cho cán bộ " />
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
                                            CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id" hamRow="ns_dg_giao_kpi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="202px" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dg_giao_kpi_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Chu kỳ đánh giá" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ngay" runat="server" Width="115px" CssClass="css_form" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lke" runat="server" lke="Ng,Tu,Th,Q,N" Width="30px" ToolTip="Ng - Ngày,Tu - Tuần,Th - Tháng,Q - Quý ,N - Năm" CssClass="css_form_c" Text="Ng" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Mã cán bộ" Width="90px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="K" CssClass="css_form" ten="Mã sản phẩm"
                                                                    ToolTip="Mã sản phẩm" kieu_chu="true" Width="115px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                                    ktra="ns_ma_cdanh,ma,ten" onchange="ns_dg_giao_kpi_P_KTRA('MACDANH')" BackColor="#f6f7f7" placeholder="Nhấn F1" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text="Ngày giao" Width="90px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayqd" runat="server" Width="115px" CssClass="css_form" />
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
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="gtrid,gtric,thuocdo,trongso" hangKt="10" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Công việc" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="gtrid" runat="server" Width="250px" CssClass="css_Gma" so_tp="2" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Kế hoạch giao" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="gtric" runat="server" Width="350px" CssClass="css_Gma" so_tp="2" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Thước đo" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="thuocdo" runat="server" Width="100px" CssClass="css_Gma" so_tp="2" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="trọng số (%)" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="trongso" runat="server" Width="100px" CssClass="css_Gma" so_tp="2" />
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
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_dg_giao_kpi_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dg_giao_kpi_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dg_giao_kpi_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:hso');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_giao_kpi_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_giao_kpi_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_giao_kpi_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:hso');form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dg_giao_kpi_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dg_giao_kpi_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_giao_kpi_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_giao_kpi_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1105,630" />
    </div>
</asp:Content>
