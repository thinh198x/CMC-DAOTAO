<%@ Page Title="ns_qt_nghiviec_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_nghiviec_pd.aspx.cs" Inherits="f_ns_qt_nghiviec_pd" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt nghỉ việc" />
                                    </td>
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
                            <table>
                                <tr>
                                    <%--<td valign="top">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label50" runat="server" Text="Tình trạng" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="trangthai" runat="server" CssClass="css_form" onchange="ns_qt_nghiviec_pd_P_KTRA('TRANGTHAI')">
                                                        <asp:ListItem Selected="True" Text="Chưa phê duyệt" Value="0"></asp:ListItem>
                                                        <asp:ListItem   Text="Đã phê duyệt" Value="1"></asp:ListItem>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="15"
                                                        cot="so_the,ten" hamRow="ns_qt_nghiviec_pd_GR_lke_RowChange();">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center" colspan="2">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                                        ham="ns_qt_nghiviec_pd_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>
                                    <td align="left" class="form_right">
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td valign="top" colspan="6">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label50" runat="server" Text="Tình trạng" Width="100px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="trangthai" runat="server" CssClass="css_form" onchange="ns_qt_nghiviec_pd_P_KTRA('TRANGTHAI')">
                                                                    <asp:ListItem Selected="True" Text="Chưa phê duyệt" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Đã phê duyệt" Value="1"></asp:ListItem>
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="X" hangKt="15"
                                                                    cot="so_the,ten" hamRow="ns_qt_nghiviec_pd_GR_lke_RowChange();">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Chức danh" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Đơn vị" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Thâm niên" DataField="ten" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Loại hợp đồng" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Ngày nộp đơn" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Ngày xin thôi việc" DataField="ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Trạng thái" DataField="ten" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="GR_lke_td" runat="server" align="center" colspan="6">
                                                                <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                                                    ham="ns_qt_nghiviec_pd_P_LKE()" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="6" style="font-weight: 700">Thông tin chung
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" Text="Mã Số CB" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled="true"
                                                        ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="150px"
                                                        f_tkhao="~/App_form/ns/tt/ns_danhsach.aspx" onchange="ns_qt_nghiviec_pd_P_KTRA('SO_THE')" gchu="gchu" placeholder="Nhấn F1" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Họ tên" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ho_ten" ten="Tên cán bộ" runat="server" kieu_unicode="true" CssClass="css_form"
                                                        Width="150px" kt_xoa="K" disabled="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Chức danh" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_cdanh" ten="Tên chức danh" runat="server" kieu_unicode="true" CssClass="css_form"
                                                        Width="150px" kt_xoa="K" disabled="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ten_phong" ten="Tên phòng" runat="server" kieu_unicode="true" CssClass="css_form"
                                                        Width="150px" kt_xoa="K" disabled="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Ngày vào cty" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_vao" ten="Ngày vào" disabled="true" runat="server" kt_xoa="G" CssClass="css_form_c" kieu_luu="S" Width="122px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Thâm niên" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tham_nien" runat="server" Width="150px" CssClass="css_form_r" kt_xoa="X" so_tp="0" disabled="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Loại hợp đồng" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="loai_hd" ten="Loại hợp đồng" runat="server" kieu_unicode="true" CssClass="css_form"
                                                        Width="150px" kt_xoa="K" disabled="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Ngày hiệu lực" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hl" ten="Ngày hiệu lực" disabled="true" runat="server" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Ngày hết hiệu lực" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_het_hl" ten="Ngày hết hiệu lực" disabled="true" runat="server" kt_xoa="G" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: 700; padding-top: 10px">Thông tin nghỉ việc
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Ngày nộp đơn" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_nop" ten="Ngày nộp đơn" disabled="true" runat="server" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Ngày xin thôi việc" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_xin" ten="Ngày xin thôi việc" disabled="true" runat="server" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label36" runat="server" Text="Ngày nghỉ thực tế" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_tt" ten="Ngày nghỉ thực tế" disabled="true" runat="server" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label37" runat="server" Text="Ngày phê duyệt" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_PD" ten="Ngày phê duyệt" disabled="true" runat="server" CssClass="css_form_c" Width="122px" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: 700; padding-top: 10px">lý do nghỉ việc
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Lý do 1" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo1" runat="server" lke=",X" Width="30px" disabled="true" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Lý do 2" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo2" runat="server" lke=",X" Width="30px" disabled="true" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text="Lý do 3" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo3" runat="server" lke=",X" Width="30px" disabled="true" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text="Lý do 4" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo4" runat="server" lke=",X" Width="30px" disabled="true" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Lý do 5" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo5" runat="server" lke=",X" Width="30px" disabled="true" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text="Lý do khác" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lydo_khac" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('LYDO_KHAC')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Text="Chi tiết lý do" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="lydo_chitiet" ten="Chi tiết lý do" disabled="true" runat="server" kieu_unicode="true" CssClass="css_form"
                                                                    Width="326px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: 700; padding-top: 10px">Đánh giá về công ty của CBNV trước khi nghỉ việc
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Text="Mức lương" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" Text="Không hài lòng" Width="162px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ml_khl" onchange="ns_qt_nghiviec_pd2_P_KTRA('ML_KHL')" disabled="true" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text="Hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ml_hl" onchange="ns_qt_nghiviec_pd2_P_KTRA('ML_HL')" disabled="true" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text="Rất hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ml_rhl" onchange="ns_qt_nghiviec_pd2_P_KTRA('ML_RHL')" disabled="true" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Quản lý" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label23" runat="server" Text="Không hài lòng" Width="162px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_khl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('QL_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text="Hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_hl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('QL_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label26" runat="server" Text="Rất hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_rhl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('QL_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" Text="Môi trường" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text="Không hài lòng" Width="162px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="mt_khl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('MT_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" Text="Hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="mt_hl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('MT_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" Text="Rất hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="mt_rhl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('MT_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text="Cơ hội thăng tiến" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label32" runat="server" Text="Không hài lòng" Width="162px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ch_khl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('CH_KHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label33" runat="server" Text="Hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ch_hl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('CH_HL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label34" runat="server" Text="Rất hài lòng" Width="127px" CssClass="css_gchu_r" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ch_rhl" runat="server" disabled="true" onchange="ns_qt_nghiviec_pd2_P_KTRA('CH_RHL')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label35" runat="server" Text="Góp ý cá nhân với CT" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="gopy" ten="Góp ý cá nhân với CT" disabled="true" runat="server" kieu_unicode="true" CssClass="css_form"
                                                                    Width="369px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: 700; padding-top: 10px">lý do nghỉ việc việc do CBQL trực tiếp đưa ra
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label38" runat="server" Text="Lý do 1" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo1" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label39" runat="server" Text="Lý do 2" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo2" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label40" runat="server" Text="Lý do 3" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo3" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label41" runat="server" Text="Lý do 4" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo4" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label42" runat="server" Text="Lý do 5" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo5" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label43" runat="server" Text="Lý do khác" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="ql_lydo_khac" runat="server" onchange="ns_qt_nghiviec_pd2_P_KTRA('QL_LYDO_KHAC')" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label44" runat="server" Text="Chi tiết nghỉ việc CBQL đưa ra" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ql_lydo_chitiet" ten="Chi tiết nghỉ việc CBQL đưa ra" disabled="true" runat="server" kieu_unicode="true" CssClass="css_form"
                                                                    Width="326px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label45" runat="server" Text="Không tuyển dụng lại" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="ktd" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - không tuyển dụng,  - Tuyển dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label46" runat="server" Text="Lý do không tuyển lại" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="lydo_ktd" ten="Lý do không tuyển lại" runat="server" kieu_unicode="true" CssClass="css_form"
                                                                    Width="495px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="font-weight: 700; padding-top: 10px">Đề xuất CBQL
                                        <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label47" runat="server" Text="Giữ lại" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="giu_lai" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Giữ lại,  - Không giữ lại" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label48" runat="server" Text="Điều chỉnh lương" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="dcl" runat="server" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Án dụng,  - Không áp dụng" CssClass="css_form_c" Text="" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label49" runat="server" Text="Mức điều chỉnh" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so so_tp="3" ID="mdc" ten="Mức điều chỉnh" runat="server" kieu_so="true" CssClass="css_form"
                                                                    Width="326px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label51" runat="server" Text="Đề xuất" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="dexuat" ten="đề xuất khác" runat="server" kieu_unicode="true" CssClass="css_form"
                                                                    Width="666px" kt_xoa="K" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton" style="float: none">
                                                        <tr>
                                                            <td style="padding-top: 15px" align="center">
                                                                <div class="box3">
                                                                    <a href="#" onclick="return ns_qt_nghiviec_pd_P_NH('1');form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                                    <a href="#" class="bt bt-grey" onclick="return ns_qt_nghiviec_pd_P_NH('2');form_P_LOI();">Đồng ý đề xuất</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 20px;">
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1220,800" />
</asp:Content>
