<%@ Page Title="ns_tl_nghiphep" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_nghiphep.aspx.cs" Inherits="f_ns_tl_nghiphep" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2" width="100%">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Tổng hợp nghỉ phép" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="17" hamRow="ns_tl_nghiphep_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_nghiphep_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_form"
                                                                    DataTextField="ten" DataValueField="ma" onchange="ns_tl_nghiphep_P_KTRA('PHONG')" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_tl_nghiphep_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Năm" CssClass="css_gchu_c" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma MaxLength="4" ID="NAM" runat="server" Width="100px" CssClass="css_form_c"
                                                                    onchange="ns_tl_nghiphep_P_KTRA('NAM')" kt_xoa="G" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <div class="box3">
                                                                    <a href="#" onclick="return ns_tl_nghiphep_TINH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calculator"></i>Tính nghỉ phép</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 500px; width: 1000px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai155" runat="server" Width="29px" Height="30px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai21" runat="server" Width="85px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai31" runat="server" Width="216px" Text="Họ tên" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai41" runat="server" Width="76px" Text="Phép năm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai1" runat="server" Width="65px" Text="Tháng 1" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai2" runat="server" Width="65px" Text="Tháng 2" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai3" runat="server" Width="65px" Text="Tháng 3" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai4" runat="server" Width="65px" Text="Tháng 4" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai5" runat="server" Width="65px" Text="Tháng 5" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai6" runat="server" Width="65px" Text="Tháng 6" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai7" runat="server" Width="65px" Text="Tháng 7" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai8" runat="server" Width="65px" Text="Tháng 8" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai9" runat="server" Width="65px" Text="Tháng 9" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai10" runat="server" Width="65px" Text="Tháng 10" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai11" runat="server" Width="65px" Text="Tháng 11" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai12" runat="server" Width="65px" Text="Tháng 12" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="85px" Text="Tổng đã nghỉ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="90px" Text="Phép năm cũ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label28" runat="server" Width="85px" Text="Số phép còn" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L"
                                                            hangKt="15" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="PHEPNAM" HeaderStyle-Width="68px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai1" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai2" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai3" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai4" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai5" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai6" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai7" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai8" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai9" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai10" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai11" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="loai12" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TONGNGHI" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PHEPNAMCU" HeaderStyle-Width="83px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="SOPHEPCON" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gso" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_tl_nghiphep_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tl_nghiphep_P_MOI();form_P_LOI();"><i class="fa "></i><span class="txUnderline"></span>Mới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tl_nghiphep_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline"></span>Xóa</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tl_nghiphep_P_IN();form_P_LOI();"><i class="fa fa-print"></i><span class="txUnderline"></span>In</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_tl_nghiphep_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,760" />
    </div>
</asp:Content>
