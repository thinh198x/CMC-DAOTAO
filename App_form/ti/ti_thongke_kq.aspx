<%@ Page Title="ti_thongke_kq" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_thongke_kq.aspx.cs" Inherits="f_ti_thongke_kq" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kết quả thống kê số liệu" />
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
            <td colspan="2" align="center">
                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_thamnien_ct" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TN" dong="true" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_thamnien_cd" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CD" dong="true" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_trinhdo" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TD" dong="true" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_mucluong" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="ML" dong="true" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_kynang" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="KN" dong="true" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Cthuvien:roi ID="Lb_chualenluong" runat="server" CssClass="css_link_Y" Width="80%" Font-Bold="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CLL" dong="true" Text="" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="TN" runat="server" Value="TN" />
        <Cthuvien:an ID="CD" runat="server" Value="CD" />
        <Cthuvien:an ID="TD" runat="server" Value="TD" />
        <Cthuvien:an ID="ML" runat="server" Value="ML" />
        <Cthuvien:an ID="KN" runat="server" Value="KN" />
        <Cthuvien:an ID="CLL" runat="server" Value="CLL" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="500,300" />
    </div>
    <script language="javascript" type="text/javascript">
        var ti_thongke_kq_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_so_idId, b_mt,
            b_ctr, b_hang, b_f_tkhao, ti_thongke_choAct = 0, b_Lb_thamnien_ctId, b_Lb_thamnien_cdId, b_Lb_thamnien_cdId, b_Lb_thamnien_cdId, b_Lb_thamnien_cdId, b_Lb_thamnien_cdId;
        function ti_thongke_kq_P_KD() {
            ti_thongke_kq_lkeCho;
            b_vungId = form_Fs_VUNG_ID('UPa_ct');
            b_Lb_thamnien_ctId = form_Fs_TEN_ID(b_vungId, 'Lb_thamnien_ct');
            b_Lb_thamnien_cdId = form_Fs_TEN_ID(b_vungId, 'Lb_thamnien_cd');
            b_Lb_trinhdoId = form_Fs_TEN_ID(b_vungId, 'Lb_trinhdo');
            b_Lb_mucluongId = form_Fs_TEN_ID(b_vungId, 'Lb_mucluong');
            b_Lb_kynangId = form_Fs_TEN_ID(b_vungId, 'Lb_kynang');
            b_Lb_chualenluongId = form_Fs_TEN_ID(b_vungId, 'Lb_chualenluong');


        }
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                if (b_dtuong.indexOf("KQ") >= 0) {
                    var a_kq = Fas_ChMang(a_tso[0], '#');
                    // thamnien_ct, thamnien_cd, trinhdo, mucluong, kynang, chualenluong
                    $get(b_Lb_thamnien_ctId).innerHTML = "Thống kê theo thâm niên công tác: " + a_kq[0];
                    $get(b_Lb_thamnien_cdId).innerHTML = "Thống kê theo thâm niên chức danh: " + a_kq[1];
                    $get(b_Lb_trinhdoId).innerHTML = "Thống kê  theo trình độ : " + a_kq[2];
                    $get(b_Lb_mucluongId).innerHTML = "Thống kê theo mức lương: " + a_kq[3];
                    $get(b_Lb_kynangId).innerHTML = "Thống kê theo kỹ năng: " + a_kq[4];
                    $get(b_Lb_chualenluongId).innerHTML = "Thống kê theo thời hạn lên lương: " + a_kq[5];
                    return false;
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>
</asp:Content>
