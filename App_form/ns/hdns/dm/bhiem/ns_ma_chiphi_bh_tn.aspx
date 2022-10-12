<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_chiphi_bh_tn.aspx.cs" Inherits="f_ns_ma_chiphi_bh_tn"
    Title="ns_ma_chiphi_bh_tn" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục chi phí gói BH tự nguyện" />
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
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" cotAn="loai_bh,mota,nsd" hangKt="10" hamRow="ns_ma_chiphi_bh_tn_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="loai_bh" />
                                            <asp:BoundField DataField="ten_loai_bh" HeaderText="Tên loại BH" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ma" HeaderText="Mã gói" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField DataField="ten" HeaderText="Tên gói" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ngayd" HeaderText="Ngày hiệu lực" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="ngayc" HeaderText="Ngày hết hiệu lực" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="phibh_nam" HeaderText="Phí bảo hiểm năm" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_r" />
                                            <asp:BoundField DataField="mota" />
                                            <asp:BoundField DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_ma_chiphi_bh_tn_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="xuat" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_ma_chiphi_bh_tn_P_IN();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu">Tên loại BH</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="LOAI_BH" kt_xoa="G" ten="Tên loại BH" ktra="LOAI_BH" runat="server" Width="272px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã gói" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã gói" runat="server" CssClass="css_form" kieu_chu="True"
                                                                    kt_xoa="G" onchange="ns_ma_chiphi_bh_tn_P_KTRA('MA')" Width="272px" MaxLength="20" />
                                                            </td>
                                                            <td style="width: 100px; display: none">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu">Tên gói</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên gói" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" Width="272px" MaxLength="100" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày hiệu lực" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" Width="245px" CssClass="css_form_c" kieu_luu="S" ten="Ngày hiệu lực"
                                                            kt_xoa="X" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc2" runat="server" Text="Ngày hết hiệu lực" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date" style="left: 0px; top: 0px">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="245px" CssClass="css_form_c" kieu_luu="S" ten="Ngày hết hiệu lực"
                                                            kt_xoa="X" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu">Phí bảo hiểm năm</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="PHIBH_NAM" ten="Phí bảo hiểm năm" runat="server" CssClass="css_form_r" kieu_unicode="True"
                                                        kt_xoa="X" Width="272px" co_dau="K" MaxLength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" kt_xoa="X" CssClass="css_form" Width="272px"
                                                        kieu_unicode="true" ToolTip="Mô tả" TextMode="MultiLine" Height="50px" MaxLength="1000" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_ma_chiphi_bh_tn_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap1" runat="server" Text="Ghi" Width="90px" OnClick="return ns_ma_chiphi_bh_tn_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_ma_chiphi_bh_tn_P_XOA();form_P_LOI();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,530" />
</asp:Content>
