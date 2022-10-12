<%@ Page Title="ns_tc_kh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tc_kh.aspx.cs" Inherits="f_ns_tc_kh" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Các tổ chức khác" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Mã CB" CssClass="css_gchu" Width="70px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten"
                                                        ToolTip="ns_tc_kh" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" kieu_chu="true" Width="120px" onchange="ns_tc_kh_P_KTRA('so_the')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Tên tổ chức" CssClass="css_gchu" Width="70px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="TENTC" ten="Tên tổ chức" runat="server" CssClass="css_ma" 
                                                        kt_xoa="X" Width="240px" kieu_unicode="true"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Số thẻ TC" CssClass="css_gchu_c" Width="70px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SOTHE_TC" ten="Số thẻ TC" ToolTip="Số thẻ cán bộ trong tổ chức" runat="server" CssClass="css_ma" 
                                                        kt_xoa="X" kieu_chu="true" Width="120px"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Ngày cấp" CssClass="css_gchu" Width="70px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYCAP" ten="Ngày cấp" runat="server"  Width="120px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Nơi cấp" CssClass="css_gchu_c" Width="70px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noicap" ten="Nơi cấp" runat="server" kt_xoa="X" CssClass="css_ma" Width="240px" kieu_unicode="true"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Ngày vào" CssClass="css_gchu" Width="70px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvao" ten="Ngày vào" runat="server"  Width="120px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Nơi vào" CssClass="css_gchu_c" Width="70px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noivao" ten="Nơi vào" runat="server" kt_xoa="X" CssClass="css_ma" Width="240px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Chức vụ" CssClass="css_gchu" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="chucvu" ten="Chức vụ" runat="server" kt_xoa="X" CssClass="css_ma" Width="440px"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id ="UPa_nhap" runat ="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tc_kh_P_NH();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tc_kh_P_MOI();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tc_kh_P_XOA();form_P_LOI();" Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="7" cotAn="so_id" hamRow="ns_tc_kh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên tổ chức" DataField="tentc" HeaderStyle-Width="330px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                ham="ns_tc_kh_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id ="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
<Cthuvien:an ID="so_id" runat="server" />
<Cthuvien:an ID="kthuoc" runat="server" Value="950,340" />
</asp:Content>
