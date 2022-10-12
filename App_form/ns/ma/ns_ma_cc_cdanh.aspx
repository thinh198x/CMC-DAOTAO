<%@ Page Title="ns_ma_cc_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ma_cc_cdanh.aspx.cs" Inherits="f_ns_ma_cc_cdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Chức danh công việc" />
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
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
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
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,mota" hamRow="ns_ma_cc_cdanh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên" DataField="mota">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_ma_cc_cdanh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Nhóm" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="NCDANH" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        kieu_chu="true" Width="100px" f_tkhao="~/App_form/ns/ma/ns_ma_cc_ncdanh.aspx" gchu="gchu"
                                                        onchange="ns_ma_cc_cdanh_P_KTRA('NCDANH')" ktra="ns_ma_cc_ncdanh,ma,ten" ten="Nhóm chức danh công việc" kt_xoa="K" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Mã" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="MA" ten="mã chức danh" runat="server" CssClass="css_form" kieu_chu="True"
                                            kt_xoa="G" onchange="ns_ma_cc_cdanh_P_KTRA('MA')" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" ten="tên" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                            Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Mô tả" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="mota" ten="Mô tả" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" TextMode="MultiLine" Rows="10"
                                            Width="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <%--<tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                    Height="20px" Text="Mô tả công việc" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Yêu cầu kỹ năng" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <%-- <tr>
                                                <td align="left" valign="top" class="tab_content" rowspan="2">
                                                    <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <Cthuvien:GridX ID="GR_cv" runat="server" loai="N"
                                                                        AutoGenerateColumns="false" hangKt="10" cot="stt,cviec" PageSize="1" CssClass="table gridX" cotAn="ma">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:so ID="stt" runat="server" Width="40px" CssClass="css_Gso"/>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Nội dung công việc" DataField="cviec" HeaderStyle-Width="307px" ItemStyle-CssClass="css_Gma" />
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                                <td id="GR_ct_td" runat="server" class="css_scrl_td">
                                                                    <khud_scrl:khud_scrl ID="GR_ct_slide" runat="server" loai="N" gridId="GR_cv" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div id="UPa_lke">
                                                                        <Cthuvien:GridX ID="GR_kn" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                            hangKt="10" CssClass="table gridX" cot="makn,tenkn,yeucau" cotAn="makn">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="350px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="makn" runat="server" CssClass="css_Gma" ToolTip="Mã kỹ năng" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Kỹ năng chính" HeaderStyle-Width="250px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="tenkn" runat="server" Width="250px" CssClass="css_Gma" ToolTip="Kỹ năng chính" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Yêu cầu" HeaderStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="yeucau" runat="server" Width="100px" CssClass="css_Gma" ToolTip="Yêu cầu" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                </td>
                                                                <td id="GR_kn_td" runat="server" class="css_scrl_td">
                                                                    <khud_scrl:khud_scrl ID="Khud_scrl1" runat="server" loai="N" gridId="GR_kn" />
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" runat="server">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_ma_cc_cdanh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ma_cc_cdanh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
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
                                <tr>
                                    <td colspan="2" class="css_border" align="left" style="height: 19px">
                                        <div id="UPa_gchu">
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="850,700" />
</asp:Content>
