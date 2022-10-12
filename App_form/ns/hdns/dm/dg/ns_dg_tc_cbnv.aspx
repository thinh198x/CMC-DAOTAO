<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dg_tc_cbnv.aspx.cs" Inherits="f_ns_dg_tc_cbnv"
    Title="ns_dg_tc_cbnv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gán tiêu chí đánh giá cho CBNV" />
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
                        <td colspan="2" align="center">
                            <table id="UPa_tk" cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left" style="width: 40px">
                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Width="30px">Năm</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left" style="width: 80px">
                                        <Cthuvien:DR_lke ID="NAM_DR" ktra="TC_DG_CBNV_NAM" runat="server" ten="Năm" Width="60px"></Cthuvien:DR_lke>
                                    </td>
                                    <td align="left" width="80px">
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Width="70px">Kỳ đánh giá</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left" width="220px">
                                        <Cthuvien:DR_lke ID="MA_KDG_DR" ktra="TC_DG_CBNV_KY_KDG" runat="server" ten="Kỳ đánh giá" Width="200px"></Cthuvien:DR_lke>
                                    </td>
                                    <td align="left" width="70px">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Width="60px">Phòng ban</asp:Label>
                                    </td>
                                    <td align="left" width="220px">
                                        <Cthuvien:DR_lke ID="phong_dr" ktra="TC_DG_CBNV_PHONG" runat="server" Width="200px"></Cthuvien:DR_lke>
                                    </td>
                                    <td align="left" width="90px">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Width="80px">Mã/Tên CBNV</asp:Label>
                                    </td>
                                    <td align="left" width="220px">
                                        <Cthuvien:ma ID="cbnv" ten="Mã/Tên CBNV" runat="server" CssClass="css_form" kt_xoa="X" Width="200px" MaxLength="50" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" OnClick="return ns_dg_tc_cbnv_P_LKE();form_P_LOI();" />
                                        <Cthuvien:ma ID="day_nhomtc" runat="server" CssClass="css_form" kt_xoa="K" Width="20px" Style="display: none;" />
                                    </td>
                                    <td align="center" style="height: 40px;">
                                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <div class="css_divb" style="margin-right: 20px;">
                                <div class="css_divCn">
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="10" cot="chon,ky_dg,so_the,ten,chucdanh,dvi,ngayd,MA_PLNV,MA_CAPNV" cotAn="MA_PLNV,MA_CAPNV" hamRow="ns_dg_tc_cbnv_GR_lke_RowChange()" hamUp="ns_dg_tc_cbnv_GR_lke_Update">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="chon" runat="server" Width="30px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="60px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Chức danh" DataField="chucdanh" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Phòng ban" DataField="dvi" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ngày vào" DataField="ngayd" HeaderStyle-Width="70px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MA_PLNV" />
                                            <asp:BoundField DataField="MA_CAPNV" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <khud:ctr_khud_divC ID="GR_lke_slide" runat="server" gridId="GR_lke" />
                            </div>
                        </td>
                        <td valign="top" align="right">
                            <div class="css_divb" style="margin-left: 10px; margin-right: 10px;">
                                <div class="css_divCn">
                                    <Cthuvien:GridX ID="GR_tc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="N" cot="nhom_tc,tso_nhom,tieu_chi,tso_tc,dmuc_l1,dmuc_l2,luyke_kysau,so_id,ma_nhom_tc,ma_tc" cotAn="so_id,ma_nhom_tc,ma_tc" hangKt="11" hamUp="ns_dg_tc_cbnv_GR_tc_Update">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Nhóm tiêu chí" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="nhom_tc" runat="server" Width="100%" CssClass="css_Gma" f_tkhao="~/App_form/dg/dm/dg_dm_nhom_tieuchi.aspx" guiId="day_tt_nhomtc" placeholder="Nhấn (F1)" BackColor="#f6f7f7" ReadOnly="true"></Cthuvien:ma>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tr.số NTC" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="tso_nhom" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" kieu_so="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tiêu chí" HeaderStyle-Width="140px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="tieu_chi" runat="server" Width="100%" CssClass="css_Gma" f_tkhao="~/App_form/dg/dm/dg_dm_tieuchi.aspx" guiId="day_nhomtc" placeholder="Nhấn (F1)" BackColor="#f6f7f7" ReadOnly="true"></Cthuvien:ma>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tr.số TC" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="tso_tc" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" kieu_so="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Đ.mức L1" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="dmuc_l1" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" kieu_so="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Đ.mức L2" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="dmuc_l2" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" kieu_so="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lũy kế kỳ sau" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="luyke_kysau" runat="server" CssClass="css_Gma_c" Width="100%" lke="C,K" ToolTip="Lũy kế kỳ sau C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="ma_nhom_tc" />
                                            <asp:BoundField DataField="ma_tc" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <khud:ctr_khud_divC ID="GR_tc_slide" runat="server" gridId="GR_tc" />
                            </div>
                            <table id="UPa_nhap_GR_tc" border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                <tr>
                                    <td align="center" valign="middle" style="width: 20px; height: 20px;">
                                        <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dg_tc_cbnv_HangLen();" />
                                    </td>
                                    <td style="width: 20px; height: 20px;" align="center" valign="middle">
                                        <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dg_tc_cbnv_HangXuong();" />
                                    </td>
                                    <td style="width: 20px; height: 20px;" align="center" valign="middle">
                                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_tc_cbnv_CatDong();" />
                                    </td>
                                    <td style="width: 20px; height: 20px;" align="center" valign="middle">
                                        <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_tc_cbnv_ChenDong('C');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 40px;">
                            <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" onclick="ns_dg_tc_cbnv_P_EXCEL();" OnServerClick="excel_Click" />
                        </td>
                        <td align="center">
                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dg_tc_cbnv_P_NH();form_P_LOI();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,580" />
        <Cthuvien:an ID="so_the" runat="server" />
        <Cthuvien:an ID="day_tt_nhomtc" runat="server" Value="A" />
    </div>
</asp:Content>