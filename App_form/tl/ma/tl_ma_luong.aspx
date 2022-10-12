<%@ Page Title="tl_ma_luong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ma_luong.aspx.cs" Inherits="f_tl_ma_luong" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Danh mục lương" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu">Nhóm lương</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap Width="200px" ID="NLUONG" CssClass="css_form" DataTextField="TEN" DataValueField="MA" onchange="tl_ma_luong_P_KTRA('NLUONG');" runat="server" ten="Nhóm lương">
                                                    </Cthuvien:DR_nhap>


                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu">Mã cột lương</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" onchange="tl_ma_luong_P_KTRA('MA');" MaxLength="50" kieu_chu="true"
                                                        Width="200px" gchu="gchu" ten="Mã cột lương" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu">Kiểu dữ liệu</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap Width="200px" ID="kdl" CssClass="css_form" runat="server" ten="Kiểu dữ liệu">
                                                        <asp:ListItem Text="Kiểu số" Value="0" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Kiểu chữ" Value="1"></asp:ListItem>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu">Tên dữ liệu</Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten" ten="Tên cột lương" runat="server" MaxLength="255" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="200px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Thứ tự</asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:ma ID="tt" kieu_so="true" runat="server" CssClass="css_form" MaxLength="3" Width="200px" />
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Hiển thị 
                                                </td>
                                                <td>
                                                    <div class="">
                                                    <Cthuvien:kieu ID="is_hienthi" runat="server" lke="X,K" Width="30px" ToolTip="X - Hiển thị, K - Không hiển thị" CssClass="css_form2_ct" Text="X" />
                                                    Import
                                                    <Cthuvien:kieu ID="is_import" runat="server" lke="X,K" Width="30px" ToolTip="X - Import, K - Không Import" CssClass="css_form2_ct" Text="X" />
                                                    Đầu vào
                                                    <Cthuvien:kieu ID="is_Dauvao" runat="server" lke="X,K" Width="30px" ToolTip="X - Đầu vào, K - Không phải đầu vào" CssClass="css_form2_ct" Text="X" />
                                                        </div>
                                                </td>
                                                <td>Công thức
                                                    <Cthuvien:kieu ID="is_congthuc" runat="server" lke="X,K" Width="30px" ToolTip="X - Công thức, K - Không phải công thức" CssClass="css_form2_ct" Text="X" /></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,NLUONG,is_hienthi,is_import,is_dauvao,is_congthuc,kdl" hamRow="tl_ma_luong_GR_lke_RowChange()">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Mã cột lương" DataField="ma" HeaderStyle-Width="200px">
                                                                <ItemStyle CssClass="css_Gma" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Tên cột lương" DataField="ten" HeaderStyle-Width="250px">
                                                                <ItemStyle CssClass="css_Gma" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Kiểu dữ liệu" DataField="ten_kdl" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gma" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Thứ tự" DataField="tt" HeaderStyle-Width="60px">
                                                                <ItemStyle CssClass="css_Gma_c" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nluong" DataField="nluong">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="is_hienthi">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="is_dauvao">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="is_congthuc">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="is_import">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="nsd" DataField="kdl">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_ct_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_ct_slide" runat="server" loai="X" rong="50" gridId="GR_ct"
                                            ham="tl_ma_luong_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle">
                                        <br />
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return tl_ma_luong_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return tl_ma_luong_P_MOI();form_P_LOI();" class="bt bt-grey">Mới</a>
                                                        <a href="#" onclick="return tl_ma_luong_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                    </div> 
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return tl_ma_luong_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return tl_ma_luong_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return tl_ma_luong_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return tl_ma_luong_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="720,780" />
    </div>
</asp:Content>
