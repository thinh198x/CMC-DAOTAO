<%@ Page Title="ns_cc_phep_bu" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_phep_bu.aspx.cs" Inherits="f_ns_cc_phep_bu" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td align="right">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu2" runat="server" CssClass="css_tieudeM" Text="Quản lý phép năm" />
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
                        <td align="left" valign="top" class="form_left">
                            <table id="UPa_tk" cellpadding="1" cellspacing="1" id="pdSearch">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Phòng" CssClass="css_gchu" Width="80px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" kieu="U" Width="202px" kt_xoa="K" onchange="ns_cc_phep_bu_P_KTRA('PHONG')" ktra="DT_PHONG" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="labl1" runat="server" Text="Mã nhân viên" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="so_the" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                        Width="202px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên" MaxLength="30"
                                                        onchange="ns_cc_phep_bu_P_LKE()" ktra="ns_cb,so_the,ten" kt_xoa="K" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Năm"
                                            Width="80px" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" onchange="ns_cc_phep_bu_P_KTRA('NAM');" Width="202px" kt_xoa="K" ktra="DT_NAM" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label32" runat="server" CssClass="css_gchu_c" Text="Kỳ công"
                                                        Width="80px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" Width="202px" kt_xoa="G" onchange="ns_cc_phep_bu_P_KTRA('KYLUONG')" ktra="DT_KYLUONG" />
                                                </td>
                                                <td style="padding-left:10px">
                                                    <Cthuvien:nhap ID="t" runat="server" Text="Tổng hợp phép năm" Width="160px" OnClick="ns_cc_phep_bu_TINH();form_P_LOI('');" Title="Tổng hợp phép năm" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <div style="width: 1100px; overflow-x: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td rowspan="2" id="td011" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="15px" />
                                                                </td>
                                                                <td rowspan="2" id="td111" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="80px" Text="Số TT" />
                                                                </td>
                                                                <td rowspan="2" id="td211" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="124px" Text="Mã nhân viên" />
                                                                </td>
                                                                <td rowspan="2" id="td311" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="202px" Text="Họ tên" />
                                                                </td>
                                                                 <td rowspan="2" id="td511" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="150px" Text="Chức danh" />
                                                                </td>
                                                                <td rowspan="2" id="td411" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="152px" Text="Bộ phận" />
                                                                </td> 
                                                                 <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label28" runat="server" Width="152px" Text="Ngày vào" />
                                                                </td> 
                                                                <td rowspan="2" id="td512" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label6" runat="server" Width="150px" Text="Kỳ tính" />
                                                                </td>
                                                                <td rowspan="2"  style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Width="150px" Text="Thâm niên" />
                                                                </td>
                                                                <td rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label1" runat="server" Width="150px" Text="Phép thâm niên" />
                                                                </td>
                                                                <td rowspan="2"  style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label25" runat="server" Width="150px" Text="Phép năm trước chuyển sang" />
                                                                </td>
                                                                <td rowspan="2"  style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label30" runat="server" Width="150px" Text="Ngày cắt phép năm trước" />
                                                                </td>
                                                                <td rowspan="2" id="td515" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="150px" Text="Số phép năm" />
                                                                </td>
                                                                <td rowspan="2" id="td516" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label29" runat="server" Width="150px" Text="Phép được nghỉ trong năm" />
                                                                </td> 
                                                                <td rowspan="2"  style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="130px" Text="Số ngày đã nghỉ" />
                                                                </td>
                                                                <td colspan="12"  style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="120px" Text="Số ngày đã sử dụng" />
                                                                </td> 
                                                                <td rowspan="2" id="td518" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label33" runat="server" Width="130px" Text="Số phép còn lại" />
                                                                </td>

                                                            </tr>
                                                            <tr> 
                                                                <td id="td8" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Width="36px" Text="T1" />
                                                                </td>
                                                                <td id="td9" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Width="36px" Text="T2" />
                                                                </td>
                                                                <td id="td10" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Width="36px" Text="T3" />
                                                                </td>
                                                                <td id="td11" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label11" runat="server" Width="36px" Text="T4" />
                                                                </td>
                                                                <td id="td12" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Width="36px" Text="T5" />
                                                                </td>
                                                                <td id="td13" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label13" runat="server" Width="36px" Text="T6" />
                                                                </td>
                                                                <td id="td14" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="36px" Text="T7" />
                                                                </td>
                                                                <td id="td15" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="36px" Text="T8" />
                                                                </td>
                                                                <td id="td16" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="36px" Text="T9" />
                                                                </td>
                                                                <td id="td17" style="background-color: #9fc54e; height: 25px; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="36px" Text="T10" />
                                                                </td>
                                                                <td id="td18" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="36px" Text="T11" />
                                                                </td>
                                                                <td id="td19" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Width="36px" Text="T12" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="X" hangKt="10" Width="100%" cotAn="SO_ID">
                                                            <Columns>
                                                                <asp:BoundField HeaderStyle-Width="7px" />
                                                                <asp:BoundField DataField="SOTT" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="so_the" HeaderStyle-Width="113px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="ho_ten" HeaderStyle-Width="188px" ItemStyle-CssClass="css_Gma" />                                                                
                                                                <asp:BoundField DataField="CDANH" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN_PHONG" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />  
                                                                <asp:BoundField DataField="NGAY_VAO" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="ky_tinh" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="thamnien" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="phep_tn" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="phep_nt" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="ngay_cat_phep" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gma_c" />                                                                
                                                                <asp:BoundField DataField="tong_p" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />                                                                
                                                                <asp:BoundField DataField="tong_dn" HeaderStyle-Width="138px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="phep_sd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t1" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t2" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t3" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t4" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t5" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t6" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t7" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t8" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t9" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t10" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t11" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="t12" HeaderStyle-Width="28px" ItemStyle-CssClass="css_Gso" />      
                                                                <asp:BoundField DataField="phep_cl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                            </Columns>
                                                        </Cthuvien:GridX>

                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" colspan="9">
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_phep_bu_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="9">
                                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Xuất Excel" Width="120px" OnClick="ns_cc_phep_bu_P_EXPORT();form_P_LOI('');" Title="Tìm kiếm" />
                                    </td>
                                </tr>
                                 <tr style="display: none">
                                    <td colspan="9">
                                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <%--<td colspan="9" align="center">
                                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Phê duyệt" Width="120px" class="css_button" title="Phê duyệt" OnClick="return ns_qt_nghiphep_pd_P_PHEDUYET('C');form_P_LOI();" />
                                        <Cthuvien:nhap ID="thanhly" runat="server" Text="Không phê duyệt" Width="130px" class="css_button" title="Không phê duyệt" OnClick="return ns_qt_nghiphep_pd_P_KOPHEDUYET();form_P_LOI();" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,660" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="phongc" runat="server" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

