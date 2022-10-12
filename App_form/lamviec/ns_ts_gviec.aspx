<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ts_gviec.aspx.cs" Inherits="f_ns_ts_gviec" Title="ns_ts_gviec" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quản lý công việc" />
                        </td>
                        <td align="right">
                            <table id="UPa_dau" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Img1" runat="server" alt="" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img3" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="border: lightgray 1px solid;">
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellspacing="1" cellpadding="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" CssClass="css_gchu" Text="Nhân viên" />
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="ma_xa" runat="server" CssClass="css_drop" DataTextField="ten"
                                            DataValueField="ma" Width="206px" kieu="S" onchange="ns_ts_gviec_P_KTRA('MAXA');" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="lblhoten" runat="server" CssClass="css_gchu" Text="Công việc" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kt_xoa="X"
                                            Width="200px" kieu_unicode="True" ten="tên" MaxLength="200" onblur="ns_ts_gviec_P_KTRA('TEN')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label36" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_SINH" runat="server" CssClass="css_ma_c" Width="200px" kt_xoa="X"
                                            kieu_date="true" kieu_luu="S" ten="ngày sinh" onblur="ns_ts_gviec_P_KTRA('NGAYSINH')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Đến ngày" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="cmt" runat="server" CssClass="css_ma_c" Width="200px" kt_xoa="X" kieu_so="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" CssClass="css_gchu" Text="Nội dung" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_cap_cmt" runat="server" CssClass="css_ma_c" Width="200px" kt_xoa="X"
                                            kieu_date="true" kieu_luu="S" ten="ngày cấp cmt" onblur="ns_ts_gviec_P_KTRA('NGAYCAPCMT')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" CssClass="css_gchu" Text="CV cấp trên" />
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="DR_nhap3" runat="server" CssClass="css_drop" DataTextField="ten"
                                            DataValueField="ma" Width="206px" kieu="S" onchange="ns_ts_gviec_P_KTRA('MAHUYEN');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="1" id="Upa_bt" runat="server">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="70px" OnClick=" return ns_ts_gviec_P_NH();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" OnClick="$get(b_so_bhxh_ID).value =''; return  ns_ts_gviec_P_MOI();  " />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ts_gviec_P_XOA();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" style="border: lightgray 1px solid;" id="tong">
                <table cellpadding="0" cellspacing="0" id="UPa_tk">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label8" runat="server" Text="Loại" CssClass="css_gchu" Width="70px" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="DR_nhap1" runat="server" CssClass="css_drop" DataTextField="ten"
                                            DataValueField="ma" Width="156px" kieu="S" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Text="Hoàn thành" Width="100px" />
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="DR_nhap2" runat="server" CssClass="css_drop" DataTextField="ten"
                                            DataValueField="ma" Width="156px" kieu="S" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:ma ID="so_bhxh_tk" runat="server" CssClass="css_ma" kieu_chu="true" Width="150px"
                                            MaxLength="20" kt_xoa="K"
                                            ten="số sổ bảo hiểm xã hội" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="100px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="Ma1" runat="server" CssClass="css_ma" kieu_chu="true" Width="150px"
                                            MaxLength="20" kt_xoa="K"
                                            ten="số sổ bảo hiểm xã hội" />
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" OnClick="ns_ts_gviec_P_LKE(); return false;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,lan_dc,sohs">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                    <asp:BoundField HeaderText="Chọn" DataField="chon" HeaderStyle-Width="50px" ItemStyle-CssClass="css_ma" />
                                    <asp:BoundField HeaderText="Công việc" DataField="cv" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma" />
                                    <asp:BoundField HeaderText="Loại" DataField="loai" HeaderStyle-Width="90px" ItemStyle-CssClass="css_ma_c" />
                                    <asp:BoundField HeaderText="Ngày giao" DataField="ngay_giao" HeaderStyle-Width="90px" ItemStyle-CssClass="css_ma_c" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinh_trang" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" id="GR_lke_td" runat="server" colspan="2">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke" ham="ns_ts_gviec_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="lan_dc" runat="server" />
        <Cthuvien:an ID="kt_ntn" runat="server" />
        <Cthuvien:an ID="so_hieu_hs" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="880,470" />
    </div>
</asp:Content>
