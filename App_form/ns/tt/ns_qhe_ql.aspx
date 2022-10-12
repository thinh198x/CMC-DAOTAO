<%@ Page Title="ns_qhe_ql" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qhe_ql.aspx.cs" Inherits="f_ns_qhe_ql" EnableEventValidation="false" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quan hệ nhân thân" />
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
                        <td valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,lqhe" hamRow="ns_qhe_ql_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Họ tên nhân thân" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Quan hệ" DataField="ten_lqh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Đối tượng giảm trừ" DataField="phuthuoc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                                    <asp:BoundField HeaderText="loại quan hệ" DataField="lqhe" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_qhe_ql_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_qhe_ql_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Mã nhân viên" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        ktra="ns_cb,so_the,ten" ToolTip="Mã cán bộ" kieu_chu="true" Width="155px" placeholder="Nhấn (F1)"
                                                        f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_qhe_ql_P_KTRA('SO_THE')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Họ tên" CssClass=" css_gchu_c" Width="130px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="tencb" ten="Tên cán bộ" runat="server" CssClass="css_form" ToolTip="Họ tên cán bộ" kieu_unicode="true" Width="156px" ReadOnly="true" kt_xoa="K" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label22" runat="server" Text="Họ tên nhân thân" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" ten="Họ tên" runat="server" kt_xoa="X" CssClass="css_form" Width="155px" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label5" runat="server" Text="Mối quan hệ" Width="130px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="LQHE" ktra="DT_LQHE" runat="server" Width="156px" kt_xoa="X"></Cthuvien:DR_lke>
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Ngày sinh" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaysinh" ten="Ngày sinh" ToolTip="Ngày sinh đối tượng giảm trừ" runat="server" kt_xoa="X" CssClass="css_form_c" Width="129px" kieu_luu="I" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Mã số thuế NPT" Width="130px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="n_ngh" ten="Mã số thuế NPT" ToolTip="Mã số thuế NPT" runat="server" kt_xoa="X"
                                                        CssClass="css_form" Width="156px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Số CMTND/Thẻ CC" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="so_cmt" ten="Số CMTND/Thẻ CC" ToolTip="Số CMTND/Thẻ CC" runat="server" kt_xoa="X"
                                                        CssClass="css_form" Width="156px" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Ngày cấp" Width="130px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_cmt" ten="Ngày cấp" ToolTip="Ngày cấp CMT" runat="server" kt_xoa="X" CssClass="css_form_c" Width="129px" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Nơi cấp" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="dchi" ten="Nơi cấp" runat="server" kt_xoa="X" CssClass="css_form" Width="455px" kieu_unicode="true" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="Label27" Text="Thông tin trên giấy khai sinh của người phụ thuộc (nếu không có MST,CMTND, Hộ chiếu)" runat="server" Font-Bold="true" Width="100%" />
                                        </div>
                                        <hr width="100%" />
                                    </td>
                                </tr>

                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Số" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="so" ten="Số" ToolTip="Số" runat="server" kt_xoa="X"
                                                        CssClass="css_form" Width="156px" kieu_unicode="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Quyển số" Width="130px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="quyenso" ten="Quyển số" ToolTip="Quyển số" runat="server" kt_xoa="X"
                                                        CssClass="css_form" Width="156px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Quốc gia" Width="130px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="nn" runat="server" Width="156px" ten="Quốc tịch" ktra="ns_ma_nuoc,ma,ten" kt_xoa="X" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label39" runat="server" Width="130px" CssClass="css_gchu_c" Text="Tỉnh/Thành phố" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="tinhthanh" ten="Tỉnh/Thành phố" runat="server" Width="154px" onchange="ns_qhe_ql_P_KTRA_DR('tinhthanh')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label16" runat="server" CssClass="css_gchu" Width="96px" Text="Quận/Huyện" />
                                    </td>

                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="quanhuyen" ten="Quận/Huyện" runat="server" Width="156px" onchange="ns_qhe_ql_P_KTRA_DR('quanhuyen')" ToolTip="Quận huyện" Height="22px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label42" runat="server" Width="130px" CssClass="css_gchu_c" Text="Xã/Phường" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="phuongxa" ten="Xã/Phường" runat="server" Width="156px" onchange="ns_qhe_ql_P_KTRA_DR('phuongxa')" ToolTip="Xã phường" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Đối tượng giảm trừ" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:kieu ID="phuthuoc" runat="server" Text="X" lke="X," ToolTip="X - Giảm trừ,  - Không giảm trừ" Width="30px" CssClass="css_form_c" />
                                        <%--<Cthuvien:kieu ID="is_bhxh" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c" Text="X" />--%>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Ngày bắt đầu giảm trừ" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày bắt đầu giảm trừ" ToolTip="Ngày bắt đầu giảm trừ" runat="server" kt_xoa="X"
                                                            CssClass="css_form_c" Width="129px" kieu_luu="I" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Ngày kết thúc giảm trừ" Width="130px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Ngày kết thúc giảm trừ" ToolTip="Ngày kết thúc giảm trừ"
                                                            runat="server" kt_xoa="X" CssClass="css_form_c" Width="130px" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Mô tả" Width="65px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_form"
                                            Width="455px" kieu_unicode="true" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <%--<tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_qhe_ql_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_qhe_ql_P_MOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_qhe_ql_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                             <td style="display: none">
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_qhe_ql_P_MOI();form_P_LOI();" />
                                                            </td>
                                                             <td style="display: none">
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_qhe_ql_P_NH();form_P_LOI();" />
                                                            </td>

                                                             <td style="display: none">
                                                                <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_qhe_ql_P_MAU();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_qhe_ql_FILE_IMPORT();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="File" runat="server" Text="File" Width="60px" OnClick="return nhap_file();form_P_LOI();" />
                                                            </td> 
                                                             <td style="display: none">
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_qhe_ql_P_XOA();form_P_LOI();" />
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
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1260,800" />
</asp:Content>
