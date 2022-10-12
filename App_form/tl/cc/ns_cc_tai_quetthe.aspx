<%@ Page Title="ns_cc_tai_quetthe" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tai_quetthe.aspx.cs" Inherits="f_ns_cc_tai_quetthe" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Tải dữ liệu từ máy chấm công" />
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
                        <td class="form_left">
                            <table>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L"
                                            hangKt="18" gchuId="gchu">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                <asp:BoundField HeaderText="Số TT" DataField="STT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Mã chấm công" DataField="MA_CC" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Quẹt vân tay" DataField="VAN_TAY" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" ham="ns_cc_tai_quetthe_P_LKE()" runat="server" loai="X" gridId="GR_ct" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Máy chấm công" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="MAY_CC" runat="server" kieu="U" Width="202px" CssClass="css_form"
                                                        onchange="ns_cc_tai_quetthe_P_KTRA('MAY_CC')" ten="Máy chấm công" DataTextField="ten" DataValueField="ma" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Từ ngày" CssClass="css_form_c" Width="120px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Đến ngày" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYC" runat="server" ten="Đến ngày" CssClass="css_form_c" Width="120px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <div class="box3" style="padding-top: 10px">
                                                        <a href="#" onclick="return ns_cc_tai_quetthe_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tải dữ liệu</a>
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
                        <td align="center">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="box3" style="padding-top: 10px">
                                            <a href="#" onclick="return ns_cc_tai_quetthe_P_NH();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                            <a href="#" class="bt bt-grey" onclick="return ns_cc_tai_quetthe_P_MOI();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                            <a href="#" onclick="return ns_cc_tai_quetthe_P_XOA();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="770,750" />
    </div>
</asp:Content>
