<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_pp_luong.aspx.cs" Inherits="f_tl_pp_luong"
    Title="tl_pp_luong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phương pháp tính lương" />
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
                    <tr align = "left">
                        <td>
                            <input type="radio" name="pp" value="QL" id="pp1" /> Tính lương theo quỹ lương công ty
                        </td>
                    </tr>
                    <tr align = "left">
                        <td>
                            <input type="radio" name="pp" value="NN" id="pp2" /> Tính lương theo bảng lương nhà nước
                        </td>
                    </tr>
                    <tr align = "left">
                        <td>
                            <input type="radio" name="pp" value="CT" id="pp3" /> Tính lương theo bảng lương tối thiểu công ty
                        </td>
                    </tr>
                    <tr align = "left">
                        <td>
                            <input type="radio" name="pp" value="VP" id="pp4" /> Tính lương Vĩnh Phúc
                        </td>
                    </tr>
                    <tr style="height:15px;">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id = "UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="apdung" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return tl_pp_luong_apdung();"
                                            Text="Áp dụng" Width="80px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="thoat" runat="server" CssClass="css_button" Font-Bold="True" OnClick="form_P_DONG('tl_pp_luong',null);"
                                            Text="Thoát" Width="80px" />
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
    <div id ="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="450,270" />
    </div>
</asp:Content>
