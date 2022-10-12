<%@ Page Title="ns_cc_giaitrinh_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_giaitrinh_pd.aspx.cs" Inherits="f_ns_cc_giaitrinh_pd" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt giải trình chấm công" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table cellspacing="0" id="UPa_ct">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Tình trạng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                    CssClass="css_drop" kieu="S" Width="376px" onchange="ns_cc_giaitrinh_pd_P_LKE()">
                                                                    <asp:ListItem Text="Chưa phê duyệt" Value="0" />
                                                                    <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                                                    <asp:ListItem Text="Không phê duyệt" Value="2" />
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Tháng CC" CssClass="css_gchu_c" Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="thang" runat="server" kt_xoa="X" CssClass="css_ma_c" kieu_luu="S" Width="110px" onchange="ns_cc_giaitrinh_pd_P_LKE();" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                    Height="20px" Text="Nghỉ không lương" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Làm thêm giờ" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="tab_content">
                                                    <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left" valign="middle" >
                                                                    <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_cc_giaitrinh_pd_CHON();" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="N"
                                                                        AutoGenerateColumns="false" hangKt="15" cot="pheduyet,ngay_cc,giovao,giove,nghi_koluong,giaitrinh" PageSize="1" CssClass="table gridX" cotAn="ma">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:kieu ID="pheduyet" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Date" DataField="ngay_cc" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Attendance" DataField="giovao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Leaving" DataField="giove" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Unpaid Leave" DataField="nghi_koluong" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Giải trình" DataField="giaitrinh" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                                <td id="GR_ct_td" runat="server" class="css_scrl_td">
                                                                    <khud_scrl:khud_scrl ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left" valign="middle" >
                                                                    <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_cc_giaitrinh_pd_CHON2();" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="UPa_kq">
                                                                        <Cthuvien:GridX ID="GR_kq" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                            hangKt="15" CssClass="table gridX" cot="pheduyet,ngay_ot,gio_bd,gio_kt,ot_thoigian,nt_thoigian,tinhtrang,giaitrinh">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:kieu ID="pheduyet" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Ngày" DataField="ngay_ot" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Giờ bắt đầu" DataField="gio_bd" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Giờ kết thúc" DataField="gio_kt" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Thời gian làm thêm" DataField="ot_thoigian" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Thời gian làm đêm" DataField="nt_thoigian" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="Giải trình" DataField="giaitrinh" HeaderStyle-Width="230px" ItemStyle-CssClass="css_Gma" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                </td>
                                                                <td id="GR_lke_td" runat="server" class="css_scrl_td">
                                                                    <khud_scrl:khud_scrl ID="GR_kq_slide" runat="server" loai="N" gridId="GR_kq" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ns_cc_giaitrinh_pd_P_PHEDUYET();form_P_LOI();"
                                                        Width="90px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="khongpheduyet" runat="server" Text="Ko phê duyệt" CssClass="css_button" OnClick="return ns_cc_giaitrinh_pd_P_KOPHEDUYET();form_P_LOI();"
                                                        Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="22" hamRow="ns_cc_giaitrinh_pd_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="so_the" />
                                                <asp:BoundField HeaderText="Danh Sách" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="Td1" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_dky_lamthem_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,700" />
    </div>
</asp:Content>
