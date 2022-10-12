<%@ Page Title="hdns_doituong_cc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_doituong_cc.aspx.cs" Inherits="f_hdns_doituong_cc" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đối tượng chấm công" />
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
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd,ma,cdanh,ngay_hl" hamRow="hdns_doituong_cc_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Cấp bậc vị trí" DataField="tencdanh" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Miễn theo dõi chấm công" DataField="mien_td" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Miễn theo dõi đi muộn" DataField="mien_dmvs" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Làm việc ngoài" DataField="mien_onsite" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Làm việc khác giờ làm công ty" DataField="mien_giochuan" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ma">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cdanh">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ngay_hl">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ngay_hl_td">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ngay_hl_dmvs">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ngay_hl_onsite">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="HDNS_DOITUONG_CC_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Vị trí chức danh"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="cdanh" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_form" kieu="S" Width="160px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Miễn theo dõi làm việc"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu ID="mien_td" onchange="anhienngayhieuluc('NGAY_HL_TD');form_P_LOI();" runat="server" lke="C,K" Width="30px" ToolTip="C - Có, K - Không" CssClass="css_form_c" Text="K" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <div class="ip-group date">
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy'  ID="ngay_hl_td" runat="server" kt_xoa="X" CssClass="css_form_c" Width="112px" kieu_luu="S" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Miễn theo dõi đi muộn về sớm"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu ID="mien_dmvs" onchange="anhienngayhieuluc('NGAY_HL_DMVS');form_P_LOI();" runat="server" lke="C,K" Width="30px" ToolTip="C - Có, K - Không" CssClass="css_form_c" Text="K" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <div class="ip-group date">
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy'  ID="ngay_hl_dmvs" runat="server" kt_xoa="X" CssClass="css_form_c" Width="112px" kieu_luu="S" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Làm việc ngoài công ty hoặc đi onsite" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu ID="mien_onsite" onchange="anhienngayhieuluc('NGAY_HL_ONSITE');form_P_LOI();" runat="server" lke="C,K" Width="30px" ToolTip="C - Có, K - Không" CssClass="css_form_c" Text="K" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <div class="ip-group date">
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy'  ID="ngay_hl_onsite" runat="server" kt_xoa="X" CssClass="css_form_c" Width="112px" kieu_luu="S" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Làm khác giờ chuẩn công ty" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:kieu ID="mien_giochuan" onchange="anhienngayhieuluc('NGAY_HL');form_P_LOI();" runat="server" lke="C,K" Width="30px" ToolTip="C - Có, K - Không" CssClass="css_form_c" Text="K" />
                                    </td>

                                </tr>
                                 <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <div class="ip-group date">
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy'  ID="ngay_hl" runat="server" kt_xoa="X" CssClass="css_form_c" Width="112px" kieu_luu="S" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:so ID="ma" runat="server" CssClass="css_form hiden" kieu_chu="true" kt_xoa="X"
                                                        gchu="gchu" Width="160px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" runat="server" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return HDNS_DOITUONG_CC_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return HDNS_DOITUONG_CC_P_MOI();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i><span class="txUnderline">M</span>ới</a>
                                                        <%--<a href="#" onclick="return HDNS_DOITUONG_CC_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">L</span>ưu</a>--%>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return hdns_doituong_cc_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return hdns_doituong_cc_P_XOA();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_CHON();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                                <%--<td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_ths_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_ths_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_ths_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img alt="" src="~/images/bitmaps/chen.gif" title="Thêm 1 dòng mới" onclick="return ns_ths_chenDong('C');" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 150px; height: 19px">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left" style="height: 19px">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1150,560" />
</asp:Content>
