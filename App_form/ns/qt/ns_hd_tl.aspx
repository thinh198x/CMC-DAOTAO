<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ns_hd_tl.aspx.cs" Inherits="f_ns_hd_tl" Title="ns_hd_tl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center" style="padding-top: 5px">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="right" colspan="2">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="ten_form" runat="server" CssClass="css_tieudeM" Text="Thanh lý hợp đồng " />
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
                        <td align="center" class="form_right">
                            <table id="UPa_ct" runat="Server" cellspacing="1" cellpadding="1">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Bbuoc3" runat="server" CssClass="css_gchu_c_c" Text="Mã nhân viên" Tolltip="Mã nhân viên" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="so_the" runat="server" CssClass="css_form" Width="150px" BackColor="#f6f7f7" kieu_chu="true"
                                            ten="Số thẻ cán bộ" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu_c_c" Text="Tên nhân viên" Tolltip="Tên nhân viên" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="ten" runat="server" Enabled="false" CssClass="css_form" Width="150px" BackColor="#f6f7f7" kieu_chu="true"
                                            ten="Số thẻ cán bộ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu_c" Text="Ngày bắt đầu" Tolltip="Ngày bắt đầu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" kieu_luu="S" Enabled="false" CssClass="css_form_c" Width="150px"
                                            kt_xoa="X" ten="Ngày bắt đầu" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Bbuoc2" runat="server" CssClass="css_gchu_c" Text="Ngày kết thúc" Tolltip="Ngày kết thúc" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" kieu_luu="S" Enabled="false" CssClass="css_form_c" Width="150px"
                                            kt_xoa="X" ten="Ngày kết thúc" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu_c" Text="Ngày thanh lý" Tolltip="Ngày thanh lý" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_TL" runat="server" kieu_luu="S" CssClass="css_form_c" Width="150px"
                                            kt_xoa="X" ten="Ngày thanh lý" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <div class="box3 txRight">
                                            <a href="#" onclick="return ns_hd_tl_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                            <a href="#" onclick="return ns_hd_tl_P_HUY();form_P_LOI();" class="bt bt-grey">Hủy</a>
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="670,300" />
</asp:Content>
