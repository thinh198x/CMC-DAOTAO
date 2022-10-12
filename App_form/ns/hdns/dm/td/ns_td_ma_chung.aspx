<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_td_ma_chung.aspx.cs" Inherits="f_ns_td_ma_chung"
    Title="ns_td_ma_chung" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục dùng chung tuyển dụng" />
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
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="ten_nhom,NHOM_MA,thamso1,thamso2,trangthai,mota" hamRow="ns_td_ma_chung_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Nhóm danh mục" DataField="ten_nhom" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mã danh mục" DataField="ma" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên danh mục" DataField="ten" HeaderStyle-Width="250px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                 <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NHOM_MA"/>
                                                <asp:BoundField DataField="thamso1"/>
                                                <asp:BoundField DataField="thamso2"/>
                                                <asp:BoundField DataField="trangthai"/>
                                                <asp:BoundField DataField="mota"/>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_ma_chung_P_LKE()" />
                            </div>
                        </td>
                        <td class="form_right" valign="top">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" Width="120px" CssClass="css_gchu">Nhóm danh mục</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <!--<Cthuvien:DR_lke ID="NHOM_MA1" ktra="DT_TD_MA_CHUNG_NHOM" runat="server" Width="190px" onchange="ns_td_ma_chung_P_MOI();ns_td_ma_chung_P_LKE();"></Cthuvien:DR_lke>   -->
                                                    <Cthuvien:DR_list ID="NHOM_MA" runat="server" kt_xoa="L" Width="190px" lke="Trạng thái Yêu cầu TD,Trạng thái phê duyệt,Trạng thái thư mời,Loại chi phí tuyển dụng,Trạng thái ứng viên" tra="TTYC,TTPD,TTTM,LCP,TTUV" ten="Nhóm danh mục"/>                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã danh mục" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" ten="Mã danh mục" runat="server" CssClass="css_form" kieu_chu="True"
                                                                    kt_xoa="G" onchange="ns_td_ma_chung_P_KTRA('MA')" Width="190px" MaxLength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Tên danh mục" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên danh mục" runat="server" kieu_unicode="true" CssClass="css_form" kt_xoa="X" Width="190px" MaxLength="250" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái"/>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TRANGTHAI" runat="server" Width="190px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Tham số 1</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="thamso1" ten="Tham số 1" runat="server" CssClass="css_form" kt_xoa="X" Width="190px" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Tham số 2</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="thamso2" ten="Tham số 2" runat="server" CssClass="css_form" kt_xoa="X" Width="190px"  MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" kieu_unicode="True" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="190px" MaxLength="1000"></Cthuvien:nd>
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_td_ma_chung_P_MOI('GLX');form_P_LOI();" /> 
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_td_ma_chung_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />   
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_td_ma_chung_P_XOA();form_P_LOI();" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1070,510" />
</asp:Content>

