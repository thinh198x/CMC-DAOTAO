<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_cd_phep.aspx.cs" Inherits="f_ns_cc_cd_phep"
    Title="ns_cc_cd_phep" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quy định ngày phép theo chức danh" />
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
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id" hamRow="ns_cc_cd_phep_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngay_bd" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngay_kt" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Chức danh" HeaderStyle-Width="140px" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Số phép" HeaderStyle-Width="70px" DataField="phep" ItemStyle-CssClass="css_Gma_r" />
                                                    <asp:BoundField DataField="so_id" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div>
                                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_cd_phep_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                </td>
                                                <td colspan="4">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div style="height: 200px; overflow-y: no-display;">
                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="N" cot="ma_cdanh,ten_cdanh" hangKt="6">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="ma_cdanh" runat="server" ReadOnly="true" Width="100px" CssClass="css_Gma" kt_xoa="X"
                                                                                        kieu_chu="True" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" placeholder="Nhấn (F1)" BackColor="#f6f7f7"
                                                                                        onchange="ns_cc_cd_phep_P_KTRA('MA')" ktra="ns_ma_cdanh,ma,ten" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" HeaderStyle-Width="320px" ItemStyle-CssClass="css_Gma" />
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20px; height: 20px; padding-top: 5px;" align="right" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" style="border: gray 1px solid; width: 15px; height: 15px;" title="Chèn dòng" onclick="return ns_cc_cd_phep_ChenDong('C');" />
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" style="border: gray 1px solid; width: 15px; height: 15px;" title="Cắt các dòng đã chọn" onclick="return ns_cc_cd_phep_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Số phép được hưởng" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="PHEP" runat="server" ten="Số phép được hưởng" co_dau="K" CssClass="css_form_r" Width="157px" kt_xoa="X" MaxLength="2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Áp dụng từ ngày" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_BD" runat="server" kt_xoa="X" ten="Áp dụng từ ngày" CssClass="css_form_c" Width="130px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Bbuoc1" runat="server" Width="120px" CssClass="css_gchu_c" Text="Áp dụng đến ngày" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_kt" runat="server" kt_xoa="X" ten="Áp dụng đến ngày" CssClass="css_form_c" Width="130px" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Width="140px">Là người nước ngoài</asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:kieu ID="nngoai" runat="server" lke=",X" Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text=""
                                                        kt_xoa="X" onchange="return ns_cc_cd_phep_P_KTRA_NNGOAI('IS_NNGOAI')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="blbngayhuong" runat="server" CssClass="css_gchu_c" Width="120px" Text="Số ngày được hưởng"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phep_nn" runat="server" ten="Số ngày được hưởng" CssClass="css_form_r" kt_xoa="X" kieu_so="true" Width="158px" MaxLength="2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Nhập" OnClick="return ns_cc_cd_phep_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="moi" runat="server" Width="80px" Text="Mới" OnClick="return ns_cc_cd_phep_P_MOI();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_cc_cd_phep_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1270,600" />
        <Cthuvien:an ID="ma_nnn_day" runat="server" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>

