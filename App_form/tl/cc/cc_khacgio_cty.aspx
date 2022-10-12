<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cc_khacgio_cty.aspx.cs" Inherits="f_cc_khacgio_cty"
    Title="cc_khacgio_cty" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1" class="form_right">
                    <tr>
                        <td colspan="2">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách CBNV làm việc khác giờ chuẩn công ty" />
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
                        <td style="width: 300px;" class="form_left">
                            <asp:Label ID="Label3" runat="server" Text="Sơ đồ tổ chức" Width="300px" CssClass="css_gchu" />
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Nhân viên" Width="60px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="4">
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                        Width="160px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Nhân viên" MaxLength="30"
                                                        onchange="ns_hd_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Từ ngày" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="tu_ngay" runat="server" kt_xoa="X" CssClass="css_form_c" Width="135px"
                                                            kieu_luu="S" ToolTip="Từ ngày" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Đến ngày" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="den_ngay" runat="server" kt_xoa="X" CssClass="css_form_c" Width="135px"
                                                            kieu_luu="S" ToolTip="Đến ngày" />
                                                    </div>
                                                </td> 
                                                <td>
                                                    <div class="box3">
                                                        <a href="#" onclick="return cc_khacgio_cty_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px">
                                        <div style="height: 500px; width: 800px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="15" cot="SOTT,so_the,ho_ten,ten_cdanh,ten_phong,ma_cong,tu_ngay,den_ngay,gio_bd,gio_kt,tu_ngay_dk,den_ngay_dk" hamRow="cc_khacgio_cty_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField DataField="SOTT" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="30px" />
                                                    <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên CB" DataField="ho_ten" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Phòng" DataField="ten_phong" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã công" DataField="ma_cong" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Từ ngày" DataField="tu_ngay" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Đến ngày" DataField="den_ngay" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Giờ bắt đầu ca" DataField="gio_bd" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Giờ kết thúc ca" DataField="gio_kt" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Từ ngày đăng ký ca" DataField="tu_ngay_dk" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Đến ngày đăng ký ca" DataField="den_ngay_dk" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="90" runat="server" loai="X" gridId="GR_lke"
                                            ham="cc_khacgio_cty_P_LKE()" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,750" />
</asp:Content>
