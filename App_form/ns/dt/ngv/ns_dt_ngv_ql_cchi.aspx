<%@ Page Title="ns_dt_ngv_ql_cchi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ngv_ql_cchi.aspx.cs" Inherits="f_ns_dt_ngv_ql_cchi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch đào tạo năm" />
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
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" Text="Năm" Width="60px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="nam_lst" ktra="DT_NAM" runat="server" Width="80px"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label" runat="server" Text="Tháng" Width="60px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="thang_lst" ktra="DT_THANG" runat="server" Width="80px"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <a href="#" onclick="return ns_dt_ngv_ql_cchi_P_LKE_TK();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="11" cotAn="soid,ghichu,ndung,ddiem,thluong,sl_hvien,cphi_hvien" hamRow="ns_dt_ngv_ql_cchi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Khóa đào tạo" DataField="kdtao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Tổng số lớp" DataField="tso_lop" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                <%--<asp:BoundField HeaderText="Số lượng 1 lớp" DataField="sluong_hvien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />--%>
                                                <asp:BoundField HeaderText="Chi phí/1 lớp" DataField="cphi_lop" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Mức độ ưu tiên" DataField="md_utien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="soid"/>
                                                <asp:BoundField DataField="ghichu"/>
                                                <asp:BoundField DataField="ndung"/>
                                                <asp:BoundField DataField="ddiem"/>
                                                <asp:BoundField DataField="thluong"/>
                                                <asp:BoundField DataField="sl_hvien"/>
                                                <asp:BoundField DataField="cphi_hvien"/>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_dt_ngv_ql_cchi_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Mã NV" Width="90px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="ma_nv" ten="Khóa đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="NS_CB,so_id,ma,ten" placeholder="Nhấn (F1)"
                                                        kt_xoa="X" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" MaxLength="30" kieu_chu="true" Width="160px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Họ tên" Width="106px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="hoten" runat="server" BackColor="#f6f7f7" Width="160px" CssClass="css_form" kt_xoa="X" ten="Đơn vị" />
                                                </td>
                                                <%--<td style="width: 100px; display: none">
                                                    <Cthuvien:ma ID="tt" runat="server" kt_xoa="K" Width="0" Text="A" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label13" runat="server" Text="Chức danh" Width="90px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="cdanh" ten="Khóa đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        kt_xoa="X" kieu_chu="true" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Đơn vị" Width="106px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="dvi" runat="server" BackColor="#f6f7f7" Width="160px" CssClass="css_form" kt_xoa="X" ten="Đơn vị" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Tên chứng chỉ" Width="110px" CssClass="css_gchu"></asp:Label>
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    
                                                    <Cthuvien:DR_lke ID="tencchi" ten="Năm đào tạo"  ktra="DT_NAM" kt_xoa="X" runat="server" Width="154px"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Chi phí" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cphi" runat="server" Width="160px" CssClass="css_form" kt_xoa="X" ten="Tổng số lớp học" kieu_so="True" BackColor="#f6f7f7" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Lĩnh vực cha" Width="106px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="lvcha" ten="SL học viên ĐK/1 lớp" runat="server" BackColor="#f6f7f7" CssClass="css_form" Width="160px" kt_xoa="X" kieu_so="True" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Lĩnh vực con" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="lvcon" ten="Lĩnh vực con" runat="server" BackColor="#f6f7f7" CssClass="css_form_r" Width="160px" kt_xoa="X" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Tên đơn vị cấp CC" Width="106px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="dvi_cap_cc" ten="Chi phí 1 học viên ĐK" runat="server" BackColor="#f6f7f7" CssClass="css_form_r" Width="160px" kt_xoa="X" so_tp="3" />

                                                </td>

                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Đơn vị tổ chức thi" Width="106px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="dv_tc" ten="Mức độ ưu tiên" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                        kt_xoa="X" Width="160px" />
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
                                        <div class="ip-group date">
                                            <Cthuvien:ma ID="thancc" ten="Nội dung đào tạo" runat="server" CssClass="css_form" Width="437px" kt_xoa="X" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Hình thức thi" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:DR_lke ID="hthucthi" ten="Năm đào tạo"  ktra="DT_THANG" kt_xoa="X" runat="server" Width="154px"></Cthuvien:DR_lke>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Mô tả" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td style="width: 143px">
                                        <Cthuvien:nd ID="ghichu" runat="server" CssClass="css_form" Height="50px" kt_xoa="X" TabIndex="5" TextMode="MultiLine" Width="437px" ten="Ghi chú"></Cthuvien:nd>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dt_ngv_ql_cchi_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dt_ngv_ql_cchi_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dt_ngv_ql_cchi_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return ns_dt_ngv_ql_cchi_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất Excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />

                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1230,580" />
</asp:Content>
