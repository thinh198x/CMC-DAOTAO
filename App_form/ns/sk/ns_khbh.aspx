<%@ Page Title="ns_khbh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_khbh.aspx.cs" Inherits="f_ns_khbh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch bảo hộ lao động" />
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
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="11" hamRow="ns_khbh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Loại KH" DataField="loai_kh" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="70" gridId="GR_lke"
                                            ham="ns_khbh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label2" runat="server" Text="Năm" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_form_r"
                                            Width="130px" kieu_so="true" onchange="ns_khbh_P_KTRA('NAM')" />
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Loại kế hoạch" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="LOAI_KH" ten="Loại kế hoạch" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_lkh,ma,ten" placeholder="Nhấn (F1)"
                                                        f_tkhao="~/App_form/ns/ma/ns_ma_lkh.aspx" kieu_chu="true" Width="130px" onchange="ns_khbh_P_KTRA('LOAI_KH')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label13" runat="server" Text="Mã kế hoạch" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" ten="Mã kế hoạch" runat="server" kieu_chu="true"
                                                        CssClass="css_form" Width="130px" onchange="ns_khbh_P_KTRA('MA')" />
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
                                        <Cthuvien:bbuoc ID="Label22" runat="server" Text="Tên" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="css_form" kt_xoa="X" Width="342px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Nội dung" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="noidung" ten="Nội dung kế hoạch bảo hộ lao động" runat="server" kt_xoa="X"
                                            CssClass="css_form" Width="342px" kieu_unicode="true" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Từ ngày" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Từ ngày" Width="100px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Đến ngày" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Đến ngày" runat="server" Width="100px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Tiền" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="tien" ten="Tiền" runat="server" kt_xoa="X"
                                            CssClass="css_form_r" Width="125px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Ghi chú" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" Height="50px"
                                            CssClass="css_form" Width="342px" kieu_unicode="true" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_khbh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_khbh_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_khbh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,500" />
    </div>
</asp:Content>
