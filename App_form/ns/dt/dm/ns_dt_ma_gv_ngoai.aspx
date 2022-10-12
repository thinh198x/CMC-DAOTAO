<%@ Page Title="ns_dt_ma_gv_ngoai" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_gv_ngoai.aspx.cs" Inherits="f_ns_dt_ma_gv_ngoai" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục giảng viên đào tạo bên ngoài" />
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
                                        <div class="css_divb">
                                            <div>
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id" hamRow="ns_dt_ma_gv_ngoai_GR_lke_RowChange()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField HeaderText="Tên đối tác" DataField="dtac" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Tên giảng viên" DataField="gvien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gso" />
                                                        <asp:BoundField HeaderText="Đơn vị" DataField="dvi_ctac" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                                        <asp:BoundField HeaderText="Điện thoại" DataField="sdt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                                        <asp:BoundField DataField="so_id" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_dtac_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="padding-top: 15px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_gv_ngoai_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Tên đối tác ĐT" Width="100px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DTAC" runat="server" Width="452px" ktra="DT_DTAC" ten="Đối tác đào tạo" ToolTip="Đối tác đào tạo" CssClass="css_list" kt_xoa="G" onchange="ns_dt_ma_gv_ngoai_P_KTRA('DTAC')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Bbuoc3" runat="server" Text="Lĩnh vực đào tạo" Width="110px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="css_divb" style="margin-right: 20px;">
                                                        <div class="css_divCn">
                                                            <Cthuvien:GridX ID="GR_lvcha" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="X" cot="MA_LVCHA,TEN_LVCHA" cotAn="" hangKt="4">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:TemplateField HeaderText="Mã lĩnh vực đào tạo" HeaderStyle-Width="152px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="MA_LVCHA" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="false" Enabled="false" ToolTip="Mã lĩnh vực đào tạo" MaxLength="20" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Tên lĩnh vực đào tạo" DataField="TEN_LVCHA" HeaderStyle-Width="242px" ItemStyle-CssClass="css_Gnd" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_lvcha" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Tên giảng viên" Width="100px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="GVIEN" runat="server" CssClass="css_form" ten="Tên giảng viên" ToolTip="Tên giảng viên" Width="160px" kt_xoa="X" MaxLength="255" />
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:Label ID="Label1" runat="server" Text="Chức danh" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cdanh" runat="server" CssClass="css_form" ToolTip="Chức danh" Width="160px" kt_xoa="X" MaxLength="50" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Bbuoc4" runat="server" Text="Đơn vị công tác" Width="100px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="dvi_ctac" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="500" ToolTip="Đơn vị công tác" />
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:Label ID="Label2" runat="server" Text="Ngày sinh" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngsinh" ten="ngày sinh" runat="server" Width="133px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" ToolTip="Ngày sinh" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Bbuoc5" runat="server" Text="Điện thoại" Width="100px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="sdt" runat="server" CssClass="css_form_r" Width="160px" kt_xoa="X" MaxLength="50" ToolTip="Số điện thoại" kieu_so="true" />
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:Label ID="Label3" runat="server" Text="Email" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="email" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="100" ToolTip="Email" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="KN giảng viên" Width="100px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="knghiem" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="200" ToolTip="Kinh nghiệm giảng viên" />
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:Label ID="Label7" runat="server" Text="Lĩnh vực giảng dạy" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lvuc" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="100" ToolTip="Lĩnh vực giảng dạy" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Đánh giá chung về GV" Width="140px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nd ID="dgia" ten="" runat="server" CssClass="css_form" Width="452px" kt_xoa="X" Height="50px" MaxLength="1000" ToolTip="Đánh giá chung về giảng viên" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Mô tả" Width="100px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 150px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nd ID="mota" ten="" runat="server" CssClass="css_form" Width="452px" kt_xoa="X" Height="50px" MaxLength="1000" ToolTip="Mô tả" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <table id="UPa_nhap" style="padding-top: 30px">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_ma_gv_ngoai_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_ma_gv_ngoai_P_NH();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="form_P_TRA_CHON('so_id,GVIEN');form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="Tải mẫu file" CssClass="css_button" OnClick="return ns_dt_ma_gv_ngoai_FI_NH();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dt_ma_gv_ngoai_P_XOA();form_P_LOI();" Width="100px" />
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
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,600" />
    </div>
</asp:Content>
