<%@ Page Title="ns_dt_taokh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_taokh.aspx.cs" Inherits="f_ns_dt_taokh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">

        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khởi tạo khóa học" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L" hangKt="17" hamRow="ns_dt_taokh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="200px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Ngày tạo" DataField="ngaytrinh" HeaderStyle-Width="100px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_dt_taokh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Mã khóa ĐT" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ToolTip="Mã khóa đào tạo" runat="server" Width="170px" CssClass="css_form"
                                                                    kt_xoa="K" kieu_chu="true" onchange="ns_dt_taokh_P_KTRA('MA')" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text="Ngày tạo" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaytrinh" runat="server" Width="145px" CssClass="css_form_c" kt_xoa="K"
                                                                        kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Số QĐ" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="so_qd" ten="Số quyết định" ToolTip="Số quyết định" kieu_chu="true"
                                                                    runat="server" CssClass="css_form" Width="170px" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Ngày QĐ" CssClass="css_gchu_c" Width="120px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_qd" ten="Ngày quyết định" runat="server" CssClass="css_form_c" Width="145px" kt_xoa="X" kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Tên khóa ĐT" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="TEN" ten="Tên khóa đào tạo" ToolTip="Tên khóa đào tạo" kieu_unicode="true"
                                                                    runat="server" CssClass="css_form" Width="170px" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Text="Tỷ lệ lương (%)" CssClass="css_gchu_c" Width="120px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="tyle" ten="Tỷ lệ hưởng lương" runat="server" CssClass="css_form_r" Width="170px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Nhóm C.ngành" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="nhomcn" ten="Nhóm chuyên ngành" runat="server" CssClass="css_form" kieu_chu="true"
                                                                    BackColor="#f6f7f7" ktra="ns_ma_ncnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_ncnganh.aspx"
                                                                    onchange="ns_dt_taokh_P_KTRA('NHOMCN')" Width="170px" kt_xoa="X" placeholder="Nhấn (F1)" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Chuyên ngành" CssClass="css_gchu_c" Width="120px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="chuyennganh" ten="Chuyên ngành" runat="server" CssClass="css_form" kieu_chu="true"
                                                                    BackColor="#f6f7f7" ktra="ns_ma_cnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_cnganh.aspx"
                                                                    onchange="ns_dt_taokh_P_KTRA('CHUYENNGANH')" guiId="nhomcn" Width="170px" kt_xoa="X" placeholder="Nhấn (F1)" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Mục tiêu" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="muctieu" ten="Mục tiêu đào tạo" ToolTip="Mục tiêu đào tạo" kieu_unicode="true"
                                                        runat="server" CssClass="css_form" Width="472px" kt_xoa="X" TextMode="MultiLine" Height="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Nội dung đào tạo" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noidung" ten="Nội dung đào tạo" ToolTip="Nội dung đào tạo" kieu_unicode="true"
                                                        runat="server" CssClass="css_form" Width="472px" kt_xoa="X" TextMode="MultiLine" Rows="4" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Nơi đào tạo" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="noidt" ten="Nơi đào tạo" runat="server" CssClass="css_form" Width="170px"
                                                                    kt_xoa="X" kieu_unicode="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Số lượng" CssClass="css_gchu_c" Width="120px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="soluong" ten="Số lượng" runat="server" CssClass="css_form" Width="170px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Từ ngày" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="145px" CssClass="css_form_c" kt_xoa="X"
                                                                        kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text="Đến ngày" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="145px" CssClass="css_form_c" kt_xoa="X"
                                                                        kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Cấp đào tạo" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="cap_dt" ten="Cấp đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                                    kieu_chu="true" ktra="ns_ma_capdt,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_capdt.aspx"
                                                                    onchange="ns_dt_taokh_P_KTRA('cap_dt')" Width="170px" kt_xoa="X" placeholder="Nhấn (F1)" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Hình thức đào tạo" CssClass="css_gchu_c"
                                                                    Width="120px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="hinhthuc" ten="Hình thức đào tạo" runat="server" CssClass="css_form"
                                                                    BackColor="#f6f7f7" kieu_chu="true" ktra="ns_ma_htdt,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx"
                                                                    onchange="ns_dt_taokh_P_KTRA('hinhthuc')" Width="170px" kt_xoa="X" placeholder="Nhấn (F1)" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Ghi chú" CssClass="css_gchu" Width="90px" />
                                                </td>

                                                <td>
                                                    <Cthuvien:nd ID="note" ToolTip="Ghi chú" runat="server" Width="472px" CssClass="css_form" Height="50px"
                                                        kt_xoa="X" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dt_taokh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dt_taokh_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dt_taokh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return ns_dt_taokh_P_DANGKY();form_P_LOI()" class="bt bt-grey"><span class="txUnderline">Đ</span>ăng ký</a>
                                                        <a href="#" onclick="return ns_dt_taokh_P_HUYDANGKY();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">H</span>ủy đăng ký</a>
                                                        <a href="#" onclick="return ns_dt_taokh_P_DONG();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Đ</span>óng ĐK</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" onclick="return ns_dt_taokh_P_TOCHUC();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ổ chức</a>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,700" />
    </div>
</asp:Content>
