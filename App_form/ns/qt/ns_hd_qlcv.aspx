<%@ Page Title="ns_hd_qlcv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hd_qlcv.aspx.cs" Inherits="f_ns_hd_qlcv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quản lý hợp đồng" />
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
                    <tr align="left">
                        <td>
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu" Text="Mã số CB" Tolltip="Mã số cán bộ" />
                                    </td>
                                    <td>
                                        <table cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="140px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Số thẻ cán bộ" MaxLength="30"
                                                        onchange="ns_hd_qlcv_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="lable12" runat="server" Text="Loại HĐ" CssClass="css_gchu" Width="65px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="LHD" runat="server" ten="Loại hợp đồng" kieu="U" Width="386px" CssClass="css_drop"
                                            onchange="ns_hd_qlcv_P_NGAYKETTHUC()" DataTextField="ten" DataValueField="ma" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Số HĐ" CssClass="css_gchu" Width="65px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_HD" runat="server" kt_xoa="X" CssClass="css_ma" kieu_chu="true"
                                                        Width="140px" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Ngày ký" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_ky" runat="server" kt_xoa="X" CssClass="css_ma_c" Width="140px"
                                                        kieu_luu="S" ToolTip="Ngày ký hợp đồng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Từ ngày" CssClass="css_gchu" Width="65px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" kieu_luu="S" CssClass="css_ma_c" Width="140px"
                                                        onchange="ns_hd_qlcv_P_NGAYKETTHUC()" kt_xoa="X" ten="Ngày bắt đầu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text="Đến ngày" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" kieu_luu="S" CssClass="css_ma_c" Width="140px"
                                                        kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" Text="Đ.vị công tác" CssClass="css_gchu" Width="110px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="PHONG" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                           CssClass="css_drop" kieu="S" Width="386px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="CV phải làm" Width="80px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="cv_plam" runat="server" kt_xoa="X" CssClass="css_ma" Width="380px"
                                            kieu_unicode="true" ToolTip="Công việc phải làm" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Chức vụ" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="cvu" runat="server" CssClass="css_ma" kieu_chu="true" kt_xoa="X"
                                                        ten="chức vụ" f_tkhao="~/App_form/ns/ma/ns_ma_cvu.aspx" ktra="ns_ma_cvu,ma,ten" BackColor="#f6f7f7"
                                                        gchu="gchu" Width="140px" onchange="ns_hd_qlcv_P_KTRA('CVU')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Hệ số p.cấp" CssClass="css_gchu_c" Width="90px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="hspc" runat="server" CssClass="css_so" kt_xoa="X" Width="140px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp" ValueText="0" disabled="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Nhóm chức danh CV" Width="122px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="ncd" runat="server" Width="140px" CssClass="css_ma" nhap="true" kieu_chu="true"
                                                        kt_xoa="X" BackColor="#f6f7f7" f_tkhao="~/App_form/ns/ma/ns_ma_cc_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten"
                                                        onchange="ns_hd_qlcv_P_KTRA('NCD')" ToolTip="Nhóm chức danh công việc" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label34" runat="server" Text="Chức danh CV" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cdanh" runat="server" Width="140px" CssClass="css_ma"
                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_cc_cdanh.aspx" guiId="ncd"
                                                        kt_xoa="X" onchange="ns_hd_qlcv_P_KTRA('cdanh')" ktra="ns_ma_cdanh,ma,ten" ToolTip="Chức danh công việc" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="Bậc tay nghề" Width="114px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="bcd" runat="server" guiId="ncd,cdanh" CssClass="css_ma" Width="140px" kt_xoa="X" kieu_chu="true"
                                                        f_tkhao="~/App_form/ns/ma/ns_ma_cc_baccdanh.aspx" gchu="gchu" ktra="ns_ma_baccdanh_ct,ma,ma"
                                                        BackColor="#f6f7f7" onchange="ns_hd_qlcv_P_KTRA('BCD')" ten="tên Bậc tay nghề công việc"
                                                        ToolTip="Bậc tay nghề" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label36" runat="server" Text="Hệ số" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="hscd" ToolTip="Hệ số chức danh công việc" runat="server" Width="140px"
                                                        CssClass="css_so" so_tp="3" kt_xoa="X" ValueText="0" disabled="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Sản lượng yêu cầu" Width="114px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="sl_yc" ToolTip="Sản lượng yêu cầu" runat="server" Width="140px"
                                                        CssClass="css_so" so_tp="3" kt_xoa="X" ValueText="0" disabled="true" />
                                                </td> 
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" Text="Mức lương" CssClass="css_gchu" Width="80px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="tien" ten="Mức lương" runat="server" kt_xoa="X" CssClass="css_so" Width="140px"
                                                        ValueText="0" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Lương CB" CssClass="css_gchu_c" Width="90px"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tienbh" ten="Lương cơ bản" runat="server" kt_xoa="X" CssClass="css_so" Width="105px"
                                                        ValueText="0" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ma_nte" runat="server" kt_xoa="K" CssClass="css_ma_c" kieu_chu="true"
                                                        BackColor="#f6f7f7" f_tkhao="~/App_form/ns/ma/ns_ma_nte.aspx" Width="27px" Text="VND"
                                                        ten="Mã tiền tệ" onchange="ns_hd_qlcv_P_KTRA('MA_NTE')" ktra="ns_ma_nte,ma,ten" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="Trả lương theo" Width="95px" CssClass="css_gchu" />
                                    </td>

                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="tratheo" runat="server" kieu="U" Width="146px" CssClass="css_drop">
                                                        <asp:ListItem Value="NM" Text="Năm" />
                                                        <asp:ListItem Value="QY" Text="Quý" />
                                                        <asp:ListItem Value="TH" Text="Tháng" Selected="True" />
                                                        <asp:ListItem Value="TU" Text="Tuần" />
                                                        <asp:ListItem Value="NG" Text="Ngày" />
                                                        <asp:ListItem Value="GI" Text="Giờ" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label37" runat="server" Text="Ngày nghỉ phép" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="ngaynghi" runat="server" kt_xoa="K" CssClass="css_so_c" Width="140px" Text="12" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Loại lương" Width="105px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="loailuong" runat="server" kieu="U" Width="146px" CssClass="css_drop">
                                                        <asp:ListItem Value="GROS" Text="Gross" />
                                                        <asp:ListItem Value="NET" Text="Net" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Hưởng lương" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="hthl" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Hình thức hưởng lương" ToolTip="Hình thức hưởng lương" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Thời gian làm việc" Width="110px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="tg_lv" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Thời gian làm việc" ToolTip="Thời gian làm việc" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Dụng cụ LĐ" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="dc_ld" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Dụng cụ lao động" ToolTip="Dụng cụ lao động" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Phương tiện" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="ptdl" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Phương tiện đi lại" ToolTip="Phương tiện đi lại" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" Text="Các phụ cấp:" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="phucap" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Các phụ cấp" ToolTip="Phụ cấp khác" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="CĐ nâng lương" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="nangluong" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Chế độ nâng lương" ToolTip="Chế độ nâng lương" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="CĐ Nghỉ ngơi" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="nghingoi" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Chế độ nghỉ ngơi" ToolTip="Chế độ nghỉ ngơi" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Bảo hiểm YT-XH" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="bhyt_xh" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Chế độ bảo hiểm Y tế - Xã hội" ToolTip="Chế độ bảo hiểm Y tế - Xã hội" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server" Text="CĐ Đào tạo" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="daotao" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Chế độ đào tạo" ToolTip="Chế độ đào tạo" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Chế độ thưởng" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="thuong" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Chế độ thưởng" ToolTip="Chế độ thưởng" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" Text="Thiết bị BHLĐ" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="bhld" runat="server" CssClass="css_ma" Width="140px" kt_xoa="X"
                                                        ten="Trang thiết bị bảo hộ lao động" ToolTip="Trang thiết bị bảo hộ lao động"
                                                        kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Text="N.vụ bồi thường" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="boithuong" runat="server" CssClass="css_ma" Width="380px" kt_xoa="X"
                                            ten="Nghĩa vụ bồi thường" ToolTip="Nghĩa vụ bồi thường" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" Text="Thỏa thuận khác" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="thoathuan" runat="server" CssClass="css_ma" Width="380px" kt_xoa="X"
                                            ten="Các thỏa thuận khác" ToolTip="Các thỏa thuận khác" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Ghi chú" Width="80px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" runat="server" kt_xoa="X" CssClass="css_ma" Width="380px"
                                            kieu_unicode="true" ToolTip="Ghi chú" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>

                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_hd_qlcv_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="thanhly" runat="server" Text="Thanh lý" CssClass="css_button" OnClick="return ns_hd_qlcv_P_TL();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_hd_qlcv_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_hd_qlcv_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnServerClick="msword_Click" Width="70px" />
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
                                            CssClass="table gridX" loai="X" hangKt="27" cotAn="so_the,ten,so_id" hamRow="ns_hd_qlcv_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số thẻ" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên cb" DataField="ten" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="LHĐ" DataField="lhd" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Ngày thanh lý" DataField="ngay_tl" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="930,735" />
    </div>
</asp:Content>
