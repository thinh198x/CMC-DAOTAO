<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_td_kho_uvien.aspx.cs" Inherits="f_ns_td_kho_uvien"
    Title="ns_td_kho_uvien" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kho ứng viên" />
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
                        <td align="left" valign="top" style="height: 260px" class="form_left">
                            <table cellpadding="0" id="UPa_cd" cellspacing="0">
                                <tr>
                                    <td align="left" style="height: 60px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label D="Bbuoc3" runat="server" CssClass="css_gchu">Nhóm chức danh</asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ncdanh" BackColor="#f6f7f7" runat="server" Width="120px" CssClass="css_form" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx"
                                                        ktra="ns_ma_ncdanh,ma,ten" kt_xoa="X" kieu_chu="true" ten="Nhóm chức danh" placeholder="Nhấn F1" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label D="Bbuoc3" runat="server" CssClass="css_gchu">Chức danh</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="cdanh" kt_xoa="X" BackColor="#f6f7f7" guiId="ncdanh" runat="server" Width="120px" CssClass="css_form" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx"
                                                        ktra="ns_ma_cdanh,MA,ten,ncdanh" kieu_chu="true" ten="Chức danh công việc" placeholder="Nhấn F1" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label D="Bbuoc3" runat="server" CssClass="css_gchu">CMTND</asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cmt2" kt_xoa="X" runat="server" Width="120px" CssClass="css_form" ten="Chứng minh thư nhân dân" />
                                                </td>
                                                <td>
                                                    <asp:Label D="Bbuoc3" runat="server" CssClass="css_gchu">Giới tính</asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dGT" kt_xoa="X" Width="120px" runat="server" DataTextField="Ten" DataValueField="ma" CssClass="css_form"></Cthuvien:DR_nhap>
                                                </td>
                                                <%--<td>--%>
                                                <%--<Cthuvien:nhap ID="tim" runat="server" CssClass="" Font-Bold="False" OnClick="return ns_td_kho_uvien_P_TIM();form_P_LOI();"
                                                        Text="Tìm kiếm" Width="100px" />--%>
                                                <td>&nbsp;</td>
                                                <td style="padding-top: 5px; padding-bottom: 5px">
                                                    <a href="#" onclick="return ns_td_kho_uvien_P_TIM();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                </td>
                                                <%--</td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="13" cotAn="nsd,ten_cdanh,noi_sinh,gchu,gioi_tinh" hamRow="ns_td_kho_uvien_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số CMT" DataField="cmt" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên" DataField="ho_ten" HeaderStyle-Width="250px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ngày sinh" DataField="ngay_sinh" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nơi sinh" DataField="noi_sinh">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="gchu" DataField="gchu">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="gioi_tinh">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="50" loai="X" gridId="GR_lke"
                                            ham="ns_td_kho_uvien_P_TIM()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="height: 260px" class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Số CMTND</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="CMT" ten="Số CMTND" onchange="ns_td_kho_uvien_P_KTRA('CMT');" runat="server" CssClass="css_form" kt_xoa="G" kieu_so="true"
                                                                    Width="120px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label4" runat="server" Width="80px" CssClass="css_gchu_c">Họ tên</Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="HO_TEN" ten="Tên" kieu_unicode="true" runat="server" CssClass="css_form"
                                                                    kt_xoa="X" Width="151px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Giới tính</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="gioi_tinh" Width="120px" runat="server" DataTextField="Ten" DataValueField="ma" CssClass="css_form"></Cthuvien:DR_nhap>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" Width="80px" CssClass="css_gchu_c">Ngày sinh</asp:Label>
                                                            </td>
                                                            <%--<td align="left">
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_sinh" Width="120px" CssClass="form_c" kt_xoa="X" runat="server" ten="Ngày sinh"></Cthuvien:ngay>
                                                            </td>--%>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_sinh" ten="Ngày sinh" runat="server" CssClass="css_form_c"
                                                                        Width="125px" kt_xoa="X" ToolTip="Ngày sinh" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Nơi sinh</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="noi_sinh" ten="Nơi sinh" runat="server" CssClass="css_form" kieu_unicode="True"
                                                                    kt_xoa="X" Width="365px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="gchu" ten="Ghi chú" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="365px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_td_kho_uvien_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_kho_uvien_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" id="A1" runat="server" class="bt bt-grey" onclick="return nhap_file();form_P_LOI();"><span class="txUnderline">F</span>ile</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_td_kho_uvien_P_NH();form_P_LOI();"
                                                        Text="Nhập" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_td_kho_uvien_P_XOA();form_P_LOI();"
                                                        Text="Xóa" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                                        Text="Chọn" Width="70px" />
                                                </td>--%>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" Width="101px" class="css_button_l"
                                                        title="Thêm File" OnClick="return nhap_file();form_P_LOI();" />
                                                </td>--%>
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,650" />
</asp:Content>
