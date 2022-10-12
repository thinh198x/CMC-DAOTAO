<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_ttncn.aspx.cs" Inherits="f_ns_hdns_ma_ttncn"
    Title="ns_hdns_ma_ttncn" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục Thuế thu nhập cá nhân" />
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
                        <td align="left" valign="top" class="form_left">
                            <div>
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="doituong_cutru,ty_le,so_id" hamRow="ns_hdns_ma_ttncn_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="ten_doituong_cutru" HeaderText="Đối tượng cư trú" HeaderStyle-Width="240px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_d" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="doituong_cutru" />                                            
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>                                
                                <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_hdns_ma_ttncn_P_LKE()" />
                            </div>
                            <div style="text-align: center; margin-top: 15px;">
                                <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_ma_ttncn_P_EXCEL();form_P_LOI();" />
                            </div>
                        </td>

                        <td class="form_right">
                            <table runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" cellpadding="1" cellspacing="0">                                           
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Đối tượng cư trú" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="DOITUONG_CUTRU" kt_xoa="G" ten="Đối tượng cư trú" ktra="DT_CUTRU" runat="server" Width="270px" onchange="ns_hdns_ma_ttncn_P_KTRA('DOITUONG_CUTRU');" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" ten="Ngày hiệu lực" Width="243px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X" onchange="ns_hdns_ma_ttncn_P_KTRA('NGAY_D');"/>
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>                                           
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" id="UPa_lk" style="padding-right:20px;">
                                        <div class="css_divb">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="N" cot="tien_tu,tien_den,ty_le" hangKt="8" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:TemplateField HeaderText="Thu nhập từ (*)" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tien_tu" MaxLength="10" runat="server" kt_xoa="G" Text="0" nhap="true" Width="120px" CssClass="css_Gso" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Thu nhập đến (*)" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tien_den" MaxLength="10" runat="server" Width="120px" CssClass="css_Gso" so_tp="2" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Thuế suất (%)(*)" HeaderStyle-Width="115px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="ty_le" MaxLength="2" runat="server" Width="115px" CssClass="css_Gma_c" so_tp="2" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </Cthuvien:GridX>
                                              </div>
                                            <khud:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                        </div>    
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <table border="0" cellpadding="1" cellspacing="1">
                                            <tr>                                               
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_ma_ttncn_HangLen();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_ma_ttncn_HangXuong();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_ma_ttncn_CatDong();" />
                                                </td>
                                                <td>
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_ma_ttncn_ChenDong('C');" />
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
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_hdns_ma_ttncn_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_ma_ttncn_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('TIEN_TU,TIEN_DEN');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_ma_ttncn_P_XOA();form_P_LOI();" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="970,580" />
</asp:Content>
