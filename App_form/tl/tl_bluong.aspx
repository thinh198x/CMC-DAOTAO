<%@ Page Title="tl_bluong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_bluong.aspx.cs" Inherits="f_tl_bluong" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Bảng lương tháng" />
                                    </td>
                                    <td align="right">
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
                        <td valign="middle" class="form_left">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label226" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="262px" CssClass="css_form"
                                                                    onchange="tl_bluong_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return tl_bluong_phong();" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label31" runat="server" CssClass="css_gchu_c" Text="Năm"
                                                                    Width="50px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="NAM" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                                    CssClass="css_form" onchange="ns_danhsach_P_NAM();" kieu="S" Width="70px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label32" runat="server" CssClass="css_gchu_c" Text="Kỳ lương"
                                                                    Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="KYLUONG" ten="Kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form" kieu="S" Width="260px" onchange="tl_bluong_P_KTRA('KYLUONG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <div class="box3 txRight2">
                                                                    <a href="#" onclick="return tl_bluong_TINH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calculator"></i>Tính lương tháng</a>
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
                                    <td align="left">
                                        <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:tab ID="NPa_yc" runat="server" CssClass="css_tab_ngang_ac" Width="250px"
                                                        Height="20px" Text="Bảng lương chi tiết trong tháng" />
                                                </td>
                                                <td style="width: 1px;" />
                                                <td>
                                                    <Cthuvien:tab ID="NPa_tt" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                                                        Height="20px" Text="Bảng lương tổng hợp" />
                                                </td>
                                                <td style="border-bottom: 1px solid #cccccc; width: 10%">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tab_content">
                                        <asp:Panel ID="Pa_tt" runat="server" Style="display: none;">
                                            <div style="height: 500px; width: 1200px; overflow: scroll">
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                                <tr>
                                                                    <td id="td1" valign="middle" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label1" runat="server" Width="29px" />
                                                                    </td>
                                                                    <td id="td2" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label2" runat="server" Width="48px" Text="STT" />
                                                                    </td>
                                                                    <td id="td3" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label3" runat="server" Width="85px" Text="Mã CB" />
                                                                    </td>
                                                                    <td id="td4" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label4" runat="server" Width="157px" Text="Họ tên" />
                                                                    </td>
                                                                    <td id="td5" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label5" runat="server" Width="257px" Text="Phòng" />
                                                                    </td>
                                                                    <td id="td6" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label6" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td7" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label7" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td8" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label8" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td9" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label9" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td10" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label10" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td11" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label11" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td12" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label12" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td13" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label13" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td14" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label14" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td15" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label15" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td16" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label16" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td17" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label17" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td18" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label18" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td19" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label19" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td20" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label20" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td21" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label21" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td22" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label22" runat="server" Width="116px" />
                                                                    </td>

                                                                    <td id="td23" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label23" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td24" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label24" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td25" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label25" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td26" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label26" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td27" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label27" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td28" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label28" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td29" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label29" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td30" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label30" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td31" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label33" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td32" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label34" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td33" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label36" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td34" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label37" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td35" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label38" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td36" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label39" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td37" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label40" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td38" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label41" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td39" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label42" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td40" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label43" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td41" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label44" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td42" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label45" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td43" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label46" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td44" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label47" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td45" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label48" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td46" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label49" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td47" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label50" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td48" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label51" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td49" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label52" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td50" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label53" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td51" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label54" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td52" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label55" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td53" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label56" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td54" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label57" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td55" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label58" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="td56" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label59" runat="server" Width="116px" Text="Lương khoán" />
                                                                    </td>
                                                                    <td id="td57" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label60" runat="server" Width="116px" Text="Lương sản phẩm" />
                                                                    </td>
                                                                    <td id="td58" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label61" runat="server" Width="116px" Text="Tổng thu nhập" />
                                                                    </td>
                                                                    <td id="td59" colspan="3" style="background-color: #9fc54e; border-right: gray 1px solid; height: 30px; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label62" runat="server" Width="180px" Text="Bảo hiểm công ty đóng đóng" />
                                                                    </td>
                                                                    <td id="td60" colspan="3" style="background-color: #9fc54e; border-right: gray 1px solid; height: 30px; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label63" runat="server" Width="180px" Text="Bảo hiểm cá nhân đóng" />
                                                                    </td>
                                                                    <td id="td61" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label64" runat="server" Width="116px" Text="Giảm trừ bản thân" />
                                                                    </td>
                                                                    <td id="td62" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label65" runat="server" Width="116px" Text="Số tiền giảm trừ gia cảnh" />
                                                                    </td>
                                                                    <td id="td63" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label66" runat="server" Width="116px" Text="Tổng thu nhập tính thuế" />
                                                                    </td>
                                                                    <td id="td64" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label67" runat="server" Width="116px" Text="Thuế TNCN" />
                                                                    </td>
                                                                    <td id="td65" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label68" runat="server" Width="116px" Text="Thu nhập thực lĩnh" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label35" runat="server" Width="24" />
                                                                    </td>
                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label111" runat="server" Width="116px" Text="BHXH, BHYT" />
                                                                    </td>

                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label112" runat="server" Width="116px" Text="BHTN" />
                                                                    </td>
                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label113" runat="server" Width="116px" Text="CĐP" />
                                                                    </td>
                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label118" runat="server" Width="116px" Text="Trừ BHXH, BHYT" />
                                                                    </td>

                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label119" runat="server" Width="116px" Text="Trừ BHTN" />
                                                                    </td>
                                                                    <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label110" runat="server" Width="116px" Text="Trừ CĐP" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="L"
                                                                hangKt="21" gchuId="gchu"
                                                                cot="STT,SO_THE,TEN,TEN_PHONG,LUONG_1,LUONG_2,LUONG_3,LUONG_4,LUONG_5,LUONG_6,LUONG_7,LUONG_8,LUONG_9,LUONG_10,LUONG_11,LUONG_12,LUONG_13,LUONG_14,LUONG_15,LUONG_16,LUONG_17,LUONG_18,LUONG_19,LUONG_20,LUONG_21,LUONG_22,LUONG_23,LUONG_24,LUONG_25,LUONG_26,LUONG_27,LUONG_28,LUONG_29,LUONG_30,LUONG_31,LUONG_32,LUONG_33,LUONG_34,LUONG_35,LUONG_36,LUONG_37,LUONG_38,LUONG_39,LUONG_40,LUONG_41,LUONG_42,LUONG_43,LUONG_44,LUONG_45,LUONG_46,LUONG_47,LUONG_48,LUONG_49,LUONG_50,LUONG_KHOAN,LUONG_SANPHAM,TONG_THUNHAP,TRU_BHXH_BHYT_CTY,TRU_BHTN_CTY,TRU_CDP_CTY,TRU_BHXH_BHYT,TRU_BHTN,TRU_CDP,GIAMTRU_BANTHAN,SOTIEN_GIACANH,TONG_THUNHAP_TINHTHUE,THUE_TNCN,THUNHAP_THUCNHAN">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                    <asp:BoundField DataField="STT" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:TemplateField HeaderStyle-Width="249">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma runat="server" ID="TEN_PHONG" Enabled="false" ReadOnly="true" Width="249" CssClass="css_Gma"></Cthuvien:ma>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="LUONG_1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_3" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_10" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_11" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_12" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_13" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_14" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_15" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_16" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_17" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_18" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_19" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_20" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_21" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_22" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_23" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_24" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_25" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_26" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_27" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_28" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_29" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_30" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_31" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_32" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_33" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_34" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_35" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_36" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_37" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_38" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_39" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_40" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_41" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_42" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_43" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_44" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_45" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_46" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_47" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_48" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_49" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_50" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_KHOAN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="LUONG_SANPHAM" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TONG_THUNHAP" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_BHXH_BHYT_CTY" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_BHTN_CTY" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_CDP_CTY" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_BHXH_BHYT" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_BHTN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TRU_CDP" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="GIAMTRU_BANTHAN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="SOTIEN_GIACANH" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="TONG_THUNHAP_TINHTHUE" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="THUE_TNCN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                    <asp:BoundField DataField="THUNHAP_THUCNHAN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="Pa_yc" runat="server" Style="display: block;">
                                            <div style="height: 500px; width: 1200px; overflow: scroll">
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            <table id="tblInfo2" style="height: 60px;" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                                <tr>
                                                                    <td id="tk1" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label69" runat="server" Width="29px" />
                                                                    </td>
                                                                    <td id="td88" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label97" runat="server" Width="48px" Text="STT" />
                                                                    </td>
                                                                    <td id="tk2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label70" runat="server" Width="85px" Text="Mã cán bộ" />
                                                                    </td>
                                                                    <td id="tk3" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label71" runat="server" Width="157px" Text="Họ tên" />
                                                                    </td>
                                                                    <td id="tk4" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label72" runat="server" Width="257px" Text="Phòng ban" />
                                                                    </td>
                                                                    <td id="tk5" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label73" runat="server" Width="116px" Text="Ngày bắt đầu" />
                                                                    </td>
                                                                    <td id="tk6" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label74" runat="server" Width="116px" Text="Ngày kết thúc" />
                                                                    </td>
                                                                    <td id="tk7" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label75" runat="server" Width="116px" Text="Công làm việc thực tế" />
                                                                    </td>
                                                                    <td id="tk8" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label76" runat="server" Width="116px" Text="Công nghỉ phép" />
                                                                    </td>
                                                                    <td id="tk9" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label77" runat="server" Width="116px" Text="Công đào tạo" />
                                                                    </td>
                                                                    <td id="tk10" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label78" runat="server" Width="116px" Text="Công công tác" />
                                                                    </td>
                                                                    <td id="tk11" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label79" runat="server" Width="116px" Text="Công ngày lễ tết" />
                                                                    </td>
                                                                    <td id="tk12" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label80" runat="server" Width="116px" Text="Công chế độ" />
                                                                    </td>
                                                                    <td id="tk13" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label81" runat="server" Width="116px" Text="Tổng công hưởng lương" />
                                                                    </td>
                                                                    <td id="tk14" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label82" runat="server" Width="116px" Text="Công nghỉ việc riêng không hưởng lương" />
                                                                    </td>
                                                                    <td id="tk15" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label83" runat="server" Width="116px" Text="Công nghỉ chế độ con nhỏ" />
                                                                    </td>
                                                                    <td id="tk16" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label84" runat="server" Width="116px" Text="Công thai sản" />
                                                                    </td>
                                                                    <td id="tk17" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label85" runat="server" Width="116px" Text="Tổng công BH/không lương" />
                                                                    </td>
                                                                    <td id="tk18" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                        <asp:Label ID="Label86" runat="server" Width="116px" Text="" />
                                                                    </td>
                                                                    <td id="tk19" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                        <asp:Label ID="Label87" runat="server" Width="116px" Text="" />
                                                                    </td>
                                                                    <td id="tk20" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label88" runat="server" Width="116px" Text="" />
                                                                    </td>
                                                                    <td id="tk21" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label89" runat="server" Width="116px" Text="" />
                                                                    </td>
                                                                    <td id="tk22" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label90" runat="server" Width="116px" Text="" />
                                                                    </td>
                                                                    <td id="tk23" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label91" runat="server" Width="116px" />
                                                                    </td>
                                                                    <td id="tk24" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label92" runat="server" Width="116px" Text="Mã cán bộ" />
                                                                    </td>
                                                                    <td id="tk25" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label93" runat="server" Width="116px" Text="Họ tên" />
                                                                    </td>
                                                                    <td id="tk26" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label94" runat="server" Width="116px" Text="Phòng ban" />
                                                                    </td>
                                                                    <td id="tk27" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label95" runat="server" Width="116px" Text="Tổng công hưởng lương" />
                                                                    </td>
                                                                    <td id="tk28" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label96" runat="server" Width="116px" Text="Tổng công BH/không lương" />
                                                                    </td>
                                                                    <td id="tk29" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label99" runat="server" Width="116px" Text="Lương cơ bản" />
                                                                    </td>
                                                                    <td id="tk30" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label98" runat="server" Width="116px" Text="Trợ cấp kinh doanh" />
                                                                    </td>
                                                                    <td id="tk31" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label100" runat="server" Width="116px" Text="Phụ cấp khác" />
                                                                    </td>
                                                                    <td id="tk32" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label101" runat="server" Width="116px" Text="Tổng lương" />
                                                                    </td>
                                                                    <td id="tk33" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label102" runat="server" Width="116px" Text="Công chuẩn" />
                                                                    </td>
                                                                    <td id="tk34" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                        <asp:Label ID="Label103" runat="server" Width="116px" Text="Lương một ngày làm việc" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <Cthuvien:GridX ID="GR_ct2" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" cot="STT,SO_THE,TEN,PHONG,NGAYD,NGAYC,CONG_1,CONG_2,CONG_3,CONG_4,CONG_5,CONG_6,CONG_7,CONG_8,CONG_9,CONG_10,CONG_11,CONG_12,CONG_13,CONG_14,CONG_15,CONG_16,CONG_17,CONG_18,CONG_19,CONG_20,TONG_CONG1,TONG_CONG2,LUONG_CB,PC_KINHDOANH,PC_KHAC,TONG_LUONG,CONG_CHUAN,TOTAL_SALARY_DAY" loai="L"
                                                                hangKt="21" gchuId="gchu">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                    <asp:BoundField DataField="STT" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:TemplateField HeaderStyle-Width="249">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma runat="server" ID="PHONG" Enabled="false" ReadOnly="true" Width="249" CssClass="css_Gma"></Cthuvien:ma>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NGAYD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="NGAYC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_3" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_10" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_11" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_12" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_13" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_14" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_15" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_16" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_17" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_18" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_19" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_20" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="TONG_CONG1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="TONG_CONG2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />

                                                                    <asp:BoundField DataField="LUONG_CB" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="PC_KINHDOANH" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="PC_KHAC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="TONG_LUONG" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="CONG_CHUAN" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField DataField="TOTAL_SALARY_DAY" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return tl_bluong_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-print"></i>Xuất excel</a>
                                                    </div>
                                                </td>
                                                <td id="tdKhoa" style="display: none">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Khóa" CssClass="css_button"
                                                        Width="70px" />
                                                </td>
                                                <td id="tdMo" style="display: none">
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mở" CssClass="css_button"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return tl_bluong_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr style="display: none">
                                                <td colspan="4">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Import" OnServerClick="nhap_Click" />
                                                </td>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,750" />
    </div>
</asp:Content>
