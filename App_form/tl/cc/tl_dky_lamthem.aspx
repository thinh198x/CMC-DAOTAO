<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_dky_lamthem.aspx.cs" Inherits="f_tl_dky_lamthem"
    Title="tl_dky_lamthem" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đăng ký làm thêm giờ " />
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
                        <td class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Tháng" Width="80px" />
                                                </td>
                                                <td align="left">

                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang" ten="Tháng" runat="server" CssClass="css_form_c" Width="120px" kieu_luu="I" onchange="tl_dky_lamthem_P_LKE();" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id,nguoiduyet,tinhtrang_id" hamRow="tl_dky_lamthem_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_bd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Giờ bắt đầu" DataField="gio_bd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Giờ kết thúc" DataField="gio_kt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Người duyệt" DataField="nguoiduyet" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke" ham="tl_dky_lamthem_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="sotheb" runat="server" CssClass="css_gchu" Text="Số thẻ"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" ten="Số thẻ" runat="server" CssClass="css_form" kieu_chu="True" BackColor="#f6f7f7" ReadOnly="true"
                                                                    kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="tl_dky_lamthem_P_KTRA('SO_THE')" Width="120px"
                                                                    placeholder="Nhấn F1" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X"></Cthuvien:gchu>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Người duyệt" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="nguoiduyet" ten="Mã cán bộ duyệt" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" Width="312px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Ngày đăng ký"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">

                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_BD" ten="Ngày bắt đầu" runat="server" CssClass="css_form_c" kieu_luu="S"
                                                                        kt_xoa="G" Width="94px" />
                                                                </div>
                                                            </td>
                                                            <td align="left" style="display: none">
                                                                <asp:Label ID="Label9" runat="server" CssClass="css_gchu_c" Text="Tới ngày" Width="80px" />
                                                            </td>
                                                            <td align="left" style="display: none">

                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_kt" ten="Ngày kết thúc" runat="server" CssClass="css_form_c" kieu_luu="S"
                                                                        kt_xoa="G" Width="120px" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Giờ bắt đầu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="GIO_BD" ten="Giờ bắt đầu" runat="server" CssClass="css_form_c" kt_xoa="X"
                                                                    Width="120px" ToolTip="Nhập kiểu giờ định dạng 00:00" onchange="tinh_thoigian();" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Giờ kết thúc"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="GIO_KT" ten="Giờ kết thúc" runat="server" CssClass="css_form_c" kt_xoa="X"
                                                                    Width="120px" ToolTip="Nhập kiểu giờ định dạng 00:00" onchange="tinh_thoigian();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Hình thức" Width="80px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="hinhthuc" ten="Tên" runat="server" CssClass="css_form_c" Text="T"
                                                                    lke="T,C,H" ToolTip="T - OT on weekday,C - OT on weekend, H - OT on holiday" Width="40px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="css_gchu_c" Text="Thêm giờ" Width="84px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ot_thoigian" ten="Số giờ làm thêm" runat="server" CssClass="css_form_c" kt_xoa="X" Text="0" disabled="true" Width="40px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="css_gchu_c" Text="Làm đêm" Width="86px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="nt_thoigian" ten="Số giờ làm đêm" runat="server" CssClass="css_form_c" kt_xoa="X" Text="0" disabled="true" Width="40px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Nội dung" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" CssClass="css_form" kieu_unicode="true" TextMode="MultiLine" Rows="2"
                                                        Width="315px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Ghi chú phê duyệt" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ykien" ten="Tên" runat="server" CssClass="css_form" TextMode="MultiLine" Rows="2"
                                                        Width="315px" disabled="true" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 15px">
                                                    <div class="box3  txRight">
                                                        <a href="#" onclick="return tl_dky_lamthem_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return tl_dky_lamthem_P_MOI();form_P_LOI();"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return tl_dky_lamthem_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" class="bt bt-grey" onclick="return tl_dky_lamthem_P_HUY();form_P_LOI();"><span class="txUnderline">H</span>ủy</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return tl_dky_lamthem_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_dky_lamthem_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return tl_dky_lamthem_P_XOA();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="huy" runat="server" Text="Hủy" CssClass="css_button" OnClick="return tl_dky_lamthem_P_HUY();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 150px;">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="950,400" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
