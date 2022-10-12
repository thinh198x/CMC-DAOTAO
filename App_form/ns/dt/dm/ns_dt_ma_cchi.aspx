<%@ Page Title="ns_dt_ma_cchi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_cchi.aspx.cs" Inherits="f_ns_dt_ma_cchi" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục chứng chỉ đào tạo" />
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
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" Text="Lĩnh vực cha" Width="80px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="LVCHA_TK" runat="server" ten="Lĩnh vực cha" ToolTip="Lĩnh vực cha" kt_xoa="G" ktra="DT_LVCHA" Width="160px" CssClass="css_list" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Hình thức thi" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_list ID="hthuc_thi_tk" lke=",Online,Offline" tra=",ON,OF" CssClass="css_list" runat="server" Width="160px" ToolTip="Hình thức thi" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="padding-top: 10px">
                                                    <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" CssClass="css_button" OnClick="return ns_dt_ma_cchi_P_LKE();form_P_LOI();" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px">
                                         <div class="css_divb">
                                <div>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="" hamRow="ns_dt_ma_cchi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã chứng chỉ" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên chứng chỉ" DataField="ten" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Tên đơn vị cấp" DataField="dvi_cap" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Thời hạn" DataField="thoihan" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                         </div>
                                <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_cchi_P_LKE()" />
                            </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 15px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_cchi_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Mã chứng chỉ" Width="90px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" ten="Mã chứng chỉ" runat="server" kieu_chu="true" CssClass="css_form" Width="160px" onchange="ns_dt_ma_cchi_P_KTRA('MA')" kt_xoa="G" MaxLength="20" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Tên chứng chỉ" Width="106px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" ten="Tên chứng chỉ" ToolTip="Tên chứng chỉ" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="255" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Lĩnh vực cha" Width="90px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="lvcha" runat="server" ten="Lĩnh vực cha" ToolTip="Lĩnh vực cha" kt_xoa="X" ktra="DT_LVCHA" Width="160px" CssClass="css_list" onchange="ns_dt_ma_cchi_P_KTRA('LVCHA')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Lĩnh vực con" Width="106px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="lvcon" runat="server" ten="Lĩnh vực con" ToolTip="Lĩnh vực cha" kt_xoa="X" ktra="DT_LVCON" Width="160px" CssClass="css_list" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label11" runat="server" Text="Tên đơn vị cấp CC" Width="110px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="DVI_CAP" ten="Tên đơn vị cung cấp" ToolTip="Tên đơn vị cấp chứng chỉ" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="1000" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Đơn vị tổ chức thi" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="dvi_tc" runat="server" Width="160px" CssClass="css_form" kt_xoa="X" gchu="gchu" ten="Đơn vị tổ chức thi" ToolTip="Tên đơn vị tổ chức thi" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Chi phí" Width="106px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="chiphi" ten="Chi phí" ToolTip="Chi phí" runat="server" CssClass="css_form_r" Width="127px" kt_xoa="X" MaxLength="15" co_dau="K" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ma2" runat="server" kt_xoa="K" CssClass="css_ma_c" kieu_chu="true" Enabled="false" BackColor="#DBE8F1" Width="27px" Height="21" Text="USD" ten="Mã tiền tệ" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Đường link CC" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="link_cc" runat="server" Width="160px" CssClass="css_form" kt_xoa="X" ToolTip="Đường link CC" MaxLength="500" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Thời hạn của CC" Width="106px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:ma ID="thoihan" ToolTip="Thời hạn của CC" runat="server" CssClass="css_form" Width="439px" kt_xoa="X" MaxLength="255" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Điều kiện cấp CC" Width="110px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:ma ID="dkien" ToolTip="Điều kiện cấp chứng chỉ" runat="server" kieu_unicode="true" CssClass="css_form" Width="439px" kt_xoa="X" MaxLength="500" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Lịch thi CC" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:ma ID="lich_thi" ToolTip="Lịch thi" runat="server" CssClass="css_form" Width="439px" kt_xoa="X" MaxLength="500" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Hình thức" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_list ID="hthuc_thi" lke=",Online,Offline" tra=",ON,OF" CssClass="css_list" runat="server" Width="160px" ToolTip="Hình thức thi" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label21" runat="server" Text="Trạng thái" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_list ID="trangthai" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_list" runat="server" Width="160px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Đối tượng thi" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:ma ID="dtuong" ToolTip="Đối tượng thi" kieu_unicode="true" runat="server" CssClass="css_form" MaxLength="500" Width="438px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Mô tả" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:nd ID="mota" runat="server" CssClass="css_form" Height="50px" kt_xoa="X" TabIndex="5" TextMode="MultiLine" Width="438px" MaxLength="1000"></Cthuvien:nd>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" style="padding-top: 20px">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_cchi_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_cchi_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_ma_cchi_P_XOA();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left">
                                <Cthuvien:gchu ID="ghichu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1250,640" />
</asp:Content>
