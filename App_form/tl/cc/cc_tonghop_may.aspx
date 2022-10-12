<%@ Page Title="cc_tonghop_may" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_tonghop_may.aspx.cs" Inherits="f_cc_tonghop_may" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td align="center">
                        <table cellpadding="1" cellspacing="1">
                            <tr>

                                <td align="center" colspan="2">
                                    <table cellpadding="1" width="100%" cellspacing="1">
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Bảng tổng hợp công máy" />
                                            </td>
                                            <td align="right">
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
                                <td valign="middle">
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
                                                                            onchange="cc_tonghop_may_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                                    </td>
                                                                    <td style="width: 20px;" align="center" valign="middle">
                                                                        <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return cc_tonghop_may_phong();" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label31" runat="server" CssClass="css_gchu_c" Text="Năm"
                                                                            Width="50px" />
                                                                    </td>
                                                                    <td>
                                                                        <Cthuvien:DR_nhap ID="NAM" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                                            CssClass="css_form" onchange="ns_danhsach_P_NAM();" kieu="S" Width="70px" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label32" runat="server" CssClass="css_gchu_c" Text="Kỳ công"
                                                                            Width="70px" />
                                                                    </td>
                                                                    <td>
                                                                        <Cthuvien:DR_nhap ID="KYLUONG" ten="Kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                            CssClass="css_form" kieu="S" Width="200px" onchange="cc_tonghop_may_P_KTRA('KYLUONG')" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Text="Nhân viên"
                                                                            Width="70px" />
                                                                    </td>
                                                                    <td>
                                                                        <Cthuvien:ma ID="so_the" ten="Mã CB tìm kiếm" onchange="cc_tonghop_may_P_KTRA('so_the')" runat="server" kt_xoa="K" CssClass="css_form" kieu_chu="true" Width="150px" />
                                                                    </td>
                                                                    <td style="display: none">
                                                                        <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="20px" />
                                                                    </td>
                                                                    <td style="padding-left: 20px">
                                                                        <div class="box3">
                                                                            <a href="#" onclick="return cc_tonghop_may_TINH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calculator"></i>Tổng hợp</a>
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
                                            <td align="left" class="css_border">
                                                <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                    <tr>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai3" runat="server" Width="28.8px" Text="" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai5" runat="server" Width="88px" Text="Số thẻ" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai6" runat="server" Width="157px" Text="Tên CB" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai7" runat="server" Width="108px" Text="Ngày làm việc" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai8" runat="server" Width="88px" Text="Ca làm việc" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai9" runat="server" Width="78px" Text="Lần 1" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai10" runat="server" Width="77px" Text="Lần 2" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai11" runat="server" Width="77px" Text="Lần 3" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <Cthuvien:luu ID="lblloai12" runat="server" Width="77px" Text="Lần 4" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <asp:Label ID="Label27" runat="server" Width="77px" Text="Tổng giờ làm việc" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <asp:Label ID="Label24" runat="server" Width="77px" Text="Mã công" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <asp:Label ID="Label28" runat="server" Width="77px" Text="Đi muộn" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                            <asp:Label ID="Label1" runat="server" Width="77px" Text="Về sớm" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="height: 500px; overflow-y: scroll">
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="L" cotAn="PHONG"
                                                        hangKt="15" gchuId="gchu">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="20px" />
                                                            <asp:BoundField DataField="PHONG" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField DataField="SO_THE" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField DataField="TEN_CB" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField DataField="NGAY_LV" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="CA_LV" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="LAN1" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="LAN2" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="LAN3" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="LAN4" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="TONG_GIO_LV" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gso" />
                                                            <asp:BoundField DataField="KIEUCONG_MA" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField DataField="DIMUON" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gso" />
                                                            <asp:BoundField DataField="VESOM" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gso" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="GR_lke" runat="server" align="center">
                                                <khud_slide:khud_slide ID="GR_lke_slide" ham="cc_tonghop_may_P_LKE_KHOITAO()" rong="80" runat="server" loai="X" gridId="GR_ct" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                                    <tr> 
                                                        <td>
                                                            <a href="#" onclick="return cc_tonghop_may_EXCEL();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calssculator"></i>Xuất excel</a>
                                                        </td>
                                                         <td style="display: none">
                                                            <Cthuvien:nhap ID="nhap2" runat="server" Width="70px" Text="Nhập" OnServerClick="nhap_Click" giu="false" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="nhap2" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,730" />
    </div>
</asp:Content>
