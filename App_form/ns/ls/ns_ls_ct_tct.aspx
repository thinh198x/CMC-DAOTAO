<%@ Page Title="ns_ls_ct_tct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_ct_tct.aspx.cs" Inherits="f_ns_ls_ct_tct" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quá trình công tác trong công ty" />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="ngayd,ngayc,cdanh,phong,tien_tdgt,tien_tns,phantram_luong,nguoi_ky_qd,chucdanh_nguoiky,tongluong,so_id" hamRow="ns_ls_ct_tct_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số QD" DataField="so_qd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày QĐ" DataField="ngay_qd" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Lương cơ bản" DataField="tien_lcb" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_r" />                                               
                                                <asp:BoundField HeaderText="" DataField="ngayd" />
                                                <asp:BoundField HeaderText="" DataField="ngayc" />
                                                <asp:BoundField HeaderText="" DataField="cdanh" />
                                                <asp:BoundField HeaderText="" DataField="phong" />
                                                <asp:BoundField HeaderText="" DataField="tien_tdgt" />
                                                <asp:BoundField HeaderText="" DataField="tien_tns" />
                                                <asp:BoundField HeaderText="" DataField="phantram_luong" />
                                                <asp:BoundField HeaderText="" DataField="nguoi_ky_qd" />
                                                <asp:BoundField HeaderText="" DataField="chucdanh_nguoiky" />
                                                <asp:BoundField HeaderText="" DataField="tongluong" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                            ham="ns_ls_ct_tct_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text=" Mã số CB" CssClass="css_gchu_a" Width="90px"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)"
                                                        ToolTip="Mã số cán bộ" kieu_chu="true" Width="155px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ls_ct_tct_P_KTRA('SO_THE')" gchu="gchu" kt_xoa="K" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Tên cán bộ" CssClass=" css_gchu_c" Width="110px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="css_form" ToolTip="Họ tên cán bộ" kieu_unicode="true" Width="155px" ReadOnly="true" Enabled="false" kt_xoa="K" />

                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" Text="Chức danh" CssClass=" css_gchu_a" Width="90px"></asp:Label>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" CssClass="css_form" ToolTip="Chức danh" kieu_unicode="true" Width="155px" ReadOnly="true" kt_xoa="K" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="P" runat="server" Text="Đơn vị" CssClass=" css_gchu_c" Width="110px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phong" ten="Phòng" runat="server" CssClass="css_form" ToolTip="Phòng ban" kieu_unicode="true" Width="155px" ReadOnly="true" kt_xoa="K" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Tên người ký" CssClass=" css_gchu_a" Width="90px"></asp:Label>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="nguoi_ky_qd" ten="Tên người ký" runat="server" CssClass="css_form" kt_xoa="X" ToolTip="Họ tên người ký" kieu_unicode="true" Width="155px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Chức danh người ký" CssClass=" css_gchu_c" Width="110px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="chucdanh_nguoiky" ten="Chức danh người ký" runat="server" kt_xoa="X" CssClass="css_form" ToolTip="Chức danh người ký" kieu_unicode="true" Width="155px" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label2" runat="server" Text="Loại quyết định" CssClass="css_gchu_a" ToolTip="Loại quyết định"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_QD" ten="Số quyết định" runat="server" kt_xoa="X" CssClass="css_form" Width="155px" kieu_chu="true" TaoValid="False" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text=" Ngày quyết định" CssClass="css_gchu_c" Width="110px" ToolTip="Ngày quyết định"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_QD" ten="Ngày quyết định" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 24px">
                                        <Cthuvien:bbuoc ID="Label6" runat="server" Text="Ngày hiệu lực" CssClass="css_gchu" ToolTip="Ngày bắt đầu có hiệu lực"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left" style="height: 24px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày hiệu lực" runat="server" Width="129px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Ngày hết hiệu lực" CssClass="css_gchu_c" Width="110px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Kỷ luật đến ngày" ToolTip="Kỷ luật đến ngày" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Lương cơ bản" CssClass="css_gchu" ToolTip="Lương cơ bản"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 24px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="tien_lcb" ten="Tiền lương cơ bản" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" onchange="ns_ls_ct_tct_P_KTRA('TIEN_LCB')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Thưởng năng suất" CssClass="css_gchu_c" Width="110px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tien_tns" ten="Tiền thưởng năng suất" ToolTip="Tiền thưởng năng suất" runat="server" Width="155px"
                                                        CssClass="css_form_r" kt_xoa="X" onchange="ns_ls_ct_tct_P_KTRA('TIEN_TNS')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="% hưởng lương" CssClass="css_gchu" ToolTip="% hưởng lương"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 24px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="phantram_luong" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" onchange="ns_ls_ct_tct_P_KTRA('PHANTRAM_LUONG')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Thưởng tháng" CssClass="css_gchu_c" Width="110px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tien_tdgt" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" onchange="ns_ls_ct_tct_P_KTRA('TIEN_TDGT')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Tổng lương" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="tongluong" runat="server" Width="155px" CssClass="css_form_r" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txCenter">
                                                        <%--<a href="#" onclick="return ns_ls_ct_tct_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_ls_ct_tct_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ls_ct_tct_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>--%>
                                                        <a href="#" onclick="return ns_ls_ct_tct_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return ns_ls_ct_tct_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                        <a href="#" onclick="return ns_ls_ct_tct_FILE_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>
                                                        <%--<a href="#" onclick="return nhap_file();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">F</span>ile</a>--%>
                                                    </div>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1010,600" />
</asp:Content>
