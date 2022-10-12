<%@ Page Title="ns_dt_kh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_kh.aspx.cs" Inherits="f_ns_dt_kh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch đào tạo" />
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
                                            CssClass="table gridX" loai="X" hangKt="10" hamRow="ns_dt_kh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã kế hoạch" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày Đ.Ký KH" DataField="ngayd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_kh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label2" runat="server" Text="Năm" Width="90px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_form_c" Width="120px" kieu_so="true" onchange="ns_dt_kh_P_KTRA('NAM')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label13" runat="server" Text="Mã kế hoạch" Width="90px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" ten="Mã kế hoạch" runat="server" kieu_chu="true"
                                                        CssClass="css_form" Width="120px" MaxLength="30" onchange="ns_dt_kh_P_KTRA('ma')" kt_xoa="G" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày Đ.Ký" Width="80px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày đăng ký kế hoạch" ToolTip="Ngày đăng ký kế hoạch"
                                                            Width="120px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Nhóm đào tạo" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="nhom_dt" ten="Nhóm đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_ldt,ma,ten" placeholder="Nhấn (F1)"
                                                        kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_ldt.aspx" MaxLength="10" kieu_chu="true" Width="120px" onchange="ns_dt_kh_P_KTRA('NHOM_DT')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Cấp đào tạo" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="cap_dt" ten="Cấp đào tạo" runat="server" MaxLength="10" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_capdt,ma,ten" placeholder="Nhấn (F1)"
                                                        kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_capdt.aspx" kieu_chu="true" Width="146px" onchange="ns_dt_kh_P_KTRA('CAP_DT')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Đối tượng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="doituong" ten="Đối tượng" kieu_unicode="true" MaxLength="200" runat="server" CssClass="css_form" Width="358px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Hình thức ĐT" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="hinhthuc" ten="Hình thức đào tạo" MaxLength="10" ToolTip="Hình thức đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_htdt,ma,ten"
                                                        kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" kieu_chu="true" Width="120px" onchange="ns_dt_kh_P_KTRA('HINHTHUC')" gchu="gchu" placeholder="Nhấn (F1)" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Số lượng" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="soluong" ten="Số lượng" MaxLength="3" kieu_so="true" runat="server" CssClass="css_form_r" Width="146px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Thời gian" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="thoigian" ten="Thời gian" kieu_unicode="true" MaxLength="100" runat="server" CssClass="css_form" Width="358px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Địa điểm" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="diadiem" ten="Địa điểm" kieu_unicode="true" MaxLength="200" runat="server" CssClass="css_form" Width="358px" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Nguồn kinh phí"  CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="kinhphi" ten="Nguồn kinh phí" MaxLength="10" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_dt_ma_nguonkp,ma,ten" placeholder="Nhấn (F1)"
                                                        kt_xoa="X" f_tkhao="~/App_form/ns/dt/ns_dt_ma_nguonkp.aspx" kieu_chu="true" Width="120px" onchange="ns_dt_kh_P_KTRA('KINHPHI')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Đào tạo trong nước" Width="150px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="trongnuoc" runat="server" Text="C" lke="C,K" ToolTip="C-Đào tạo trong nước, K-Đào tạo ở nước ngoài"
                                                        CssClass="css_form_c" Width="30px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" MaxLength="200" kt_xoa="X"
                                            CssClass="css_form" Width="358px" kieu_unicode="true" Height="50px" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dt_kh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dt_kh_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dt_kh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,NAM');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" >
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>

                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="780,500" />
</asp:Content>
