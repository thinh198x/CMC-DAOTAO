<%@ Page Title="ns_ttb" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ttb.aspx.cs" Inherits="f_ns_ttb" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quản lý cấp phát tài sản" />
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
                        <td align="left" valign="top" class="form_left">
                            <table id="UPa_tk" cellpadding="1" cellspacing="1" >
                                <tr>
                                    <td style="width: 90px;">
                                        <asp:Label ID="Label13" runat="server" Text="Phòng ban" Width="90px" CssClass="css_gchu" />
                                    </td>                                                
                                    <td >
                                        <table  cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="dr_phongban" ktra="NS_TTB_DVI" runat="server" Width="158px" onchange=""></Cthuvien:DR_lke>
                                                    
                                                </td>
                                                <td><div class="div-table-collum" style="width: 40px; padding-left: 5px;"><a href="#" onclick="return ns_ttb_P_Phong();" class="bt bt-grey"><i class="fa fa-list maR0"></i></a></div></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Mã nhân viên" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="css_form" kieu_chu="true"
                                            Width="200px" gchu="gchu" ten="Số thẻ cán bộ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Họ tên" Width="50px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="hoten_tk" runat="server" CssClass="css_form" kieu_chu="true"
                                            Width="200px" gchu="gchu" ten="Họ tên cán bộ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" OnClick="return ns_ttb_P_LKE();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id" hamRow="ns_ttb_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Tên tài sản" DataField="tentb" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div>
                                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ttb_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right" valign="top">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" Text="Mã số CB" CssClass="css_gchu" ToolTip="Mã số cán bộ"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" kt_xoa="X" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                                        ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" kieu_chu="true" Width="155px" onchange="ns_ttb_P_KTRA('so_the')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text="Họ tên" CssClass=" css_gchu_c" Width="90px"></asp:Label></td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="css_form" ToolTip="Họ tên cán bộ"
                                                                    kieu_unicode="true" Width="155px" ReadOnly="true" BackColor="#f6f7f7" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" Text="Vị trí chức danh" CssClass=" css_gchu_a" Width="90px"></asp:Label>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" CssClass="css_form" ToolTip="Chức danh" Width="155px" ReadOnly="true" BackColor="#f6f7f7" kt_xoa="X" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="P" runat="server" Text="Công ty/Bộ phận" CssClass=" css_gchu_c" Width="90px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phong" ten="Phòng" runat="server" CssClass="css_form" ToolTip="Phòng ban" Width="155px" ReadOnly="true" BackColor="#f6f7f7" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label10" runat="server" Text="Tên người bàn giao" CssClass="css_gchu_a"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="cb_giao" ten="Tên người bàn giao" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                                        ToolTip="Tên người bàn giao" kieu_chu="true" Width="155px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ttb_P_KTRA('MA_CB_GIAO')" gchu="gchu" kt_xoa="X" />
                                                    <Cthuvien:ma ID="ma_cb_giao" runat="server" CssClass="css_form" kt_xoa="X" style="display:none;" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Công ty/Bộ phận" CssClass="css_gchu_c" Width="90px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phong_giao" ten="Phòng giao" runat="server" CssClass="css_form" ToolTip="Phòng ban" kieu_unicode="true" Width="155px" ReadOnly="true" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Nhóm tài sản" CssClass="css_gchu" Width="90px"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="NHOM_TS" ktra="NS_TTB_NHOM_TS" runat="server" kt_xoa="X" Width="155px" onchange="ns_ttb_P_KTRA('NHOM_TS')"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text="Tên tài sản" CssClass="css_gchu_c" Width="90px"></Cthuvien:bbuoc></td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MATS" ktra="NS_TTB_MATS" runat="server" kt_xoa="X" Width="155px" onchange="ns_ttb_P_KTRA('MATS')"></Cthuvien:DR_lke>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Số lượng" CssClass="css_gchu_a" Width="90px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:so ID="SLUONG" ten="Số lượng thiết bị được giao" runat="server" CssClass="css_form_r" MaxLength="10" Width="155px"
                                                        kt_xoa="X" onchange="ns_ttb_P_KTRA('SLUONG')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Giá trị tài sản" CssClass=" css_gchu_c" Width="90px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:so ID="tien" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" ReadOnly="true" Enabled="false" BackColor="#f6f7f7" />
                                                    <Cthuvien:so ID="tien_an" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" Style="display: none;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Hình thức sử dụng" Width="110px" CssClass="css_gchu_a" ToolTip="Hình thức sử dụng thiết bị" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_list ID="ht" runat="server" Width="155px" lke="Sử dụng chung,Sử dụng riêng" tra="C,R" ten="Hình thức sử dụng" kt_xoa="X"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" Text="Ngày cấp phát" CssClass="css_gchu_c" Width="90px" ToolTip="Ngày cấp"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYCAP" runat="server" kt_xoa="X" ten="Ngày cấp phát" CssClass="css_form_c" Width="130px" kieu_luu="I" onchange="ns_ttb_P_KTRA('NGAYCAP');" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Trạng thái" Width="90px" CssClass="css_gchu_a" ToolTip="Trạng thái thiết bị" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_list ID="tt" runat="server" Width="155px" lke="Chờ cấp,Đã cấp,Đã thu hồi" tra="C,D,T" ten="Trạng thái" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Bbuoc1" runat="server" Text="Ngày thu hồi" CssClass="css_gchu_c" Width="90px" ToolTip="Ngày thu hồi"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaythu" runat="server" kt_xoa="X" ten="Ngày thu hồi" CssClass="css_form_c" Width="130px" kieu_luu="I" onchange="ns_ttb_P_KTRA('ngaythu');" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Mô tả" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" ten="Mô tả" runat="server" kt_xoa="X" Height="50px"
                                            CssClass="css_form" Width="413px" kieu_unicode="true" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Đẩy" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="day" ten="" runat="server" Text="A" />
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Tên thiết bị" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="tentb" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_ttb_P_MOI();" />
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_ttb_P_NH();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_ttb_P_XOA();" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1130,660" />
    </div>

</asp:Content>
