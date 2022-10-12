<%@ Page Title="ns_cc_giaitrinh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_giaitrinh.aspx.cs" Inherits="f_ns_cc_giaitrinh" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Giải trình chấm công" />
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
                                                    <asp:Label ID="Label10" runat="server" Text="Mã nhân viên" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" ReadOnly="true"
                                                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_cc_giaitrinh_P_KTRA('SO_THE')" gchu="gchu" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Tháng CC" CssClass="css_gchu_c" Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="thangcc" runat="server" kt_xoa="X" CssClass="css_ma_c" kieu_luu="S" Width="110px" onchange="ns_cc_giaitrinh_P_CHUYEN_HANG();"/>
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
                                                                <td align="left">
                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="N"
                                                                        AutoGenerateColumns="false" hangKt="15" cot="ngay_cc,giovao,giove,nghi_koluong,giaitrinh" PageSize="1" CssClass="table gridX" cotAn="ma">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:BoundField HeaderText="Date" DataField="ngay_cc" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Attendance" DataField="giovao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Leaving" DataField="giove" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Unpaid Leave" DataField="nghi_koluong" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:TemplateField HeaderText="Giải trình" HeaderStyle-Width="150px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="giaitrinh" runat="server" Width="150px" CssClass="css_Gma" Text="" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
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
                                                                <td>
                                                                    <div id="UPa_kq">
                                                                        <Cthuvien:GridX ID="GR_kq" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                            hangKt="15" CssClass="table gridX" cot="ngay_ot,gio_bd,gio_kt,ot_thoigian,nt_thoigian,tinhtrang,giaitrinh">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Ngày" HeaderStyle-Width="80px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ngay_ot" runat="server" Width="80px" CssClass="css_Gma_c" Text="" ToolTip="Ngày" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Giờ bắt đầu" HeaderStyle-Width="60px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="gio_bd" runat="server" Width="60px" CssClass="css_Gma_c" Text="" ToolTip="Giờ bắt đầu" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Giờ kết thúc" HeaderStyle-Width="60px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="gio_kt" runat="server" Width="60px" CssClass="css_Gma_c" Text="" ToolTip="Giờ kết thúc" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Thời gian làm thêm" HeaderStyle-Width="40px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ot_thoigian" runat="server" Width="40px" CssClass="css_Gma_c" Text="" ToolTip="Thời gian làm thêm" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Thời gian làm đêm" HeaderStyle-Width="40px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="nt_thoigian" runat="server" Width="40px" CssClass="css_Gma_c" Text="" ToolTip="Thời gian làm đêm" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Tình trạng" HeaderStyle-Width="120px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="tinhtrang" runat="server" Width="120px" CssClass="css_Gma_c" Text="" ToolTip="Tình trạng" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Giải trình" HeaderStyle-Width="180px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="giaitrinh" runat="server" Width="180px" CssClass="css_Gma" Text="" ToolTip="Giải trình" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
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
                                        <table id="Table1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_cc_giaitrinh_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_cc_giaitrinh_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_cc_giaitrinh_P_XOA();form_P_LOI();"
                                                        Width="70px" />
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
                                            CssClass="table gridX" loai="X" hangKt="22" hamRow="ns_cc_giaitrinh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng giải trình" DataField="thang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="950,700" />
    </div>
</asp:Content>
