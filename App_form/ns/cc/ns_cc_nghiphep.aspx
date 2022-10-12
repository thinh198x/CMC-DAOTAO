<%@ Page Title="ns_cc_nghiphep" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_nghiphep.aspx.cs" Inherits="f_ns_cc_nghiphep" %>

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
                        <td align="center" valign="top" class="form_left" style="display: none">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="17" hamRow="ns_cc_nghiphep_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_nghiphep_P_LKE()" />
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
                                                                    DataTextField="ten" DataValueField="ma" onchange="ns_cc_nghiphep_P_KTRA('PHONG')" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cc_nghiphep_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Năm" CssClass="css_gchu_c" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="NAM" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                                    CssClass="css_form" onchange="ns_cc_nghiphep_P_KTRA();" kieu="S" Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="KYLUONG" ten="Kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form" kieu="S" Width="200px" onchange="ns_cc_nghiphep_P_KTRA('KYLUONG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <div class="box3">
                                                                    <a href="#" onclick="return ns_cc_nghiphep_TINH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calculator"></i>Tính nghỉ phép</a>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="box3 txRight2">
                                                                    <a href="#" onclick="return ns_cc_phep_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-print"></i>Xuất excel</a>
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
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <div style="height: 500px; width: 1000px; overflow-x: scroll">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="height: 100%">
                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X"
                                                                        hangKt="14" gchuId="gchu" cot="so_the,ten,chuc_danh,bo_phan,ngay_vao,nam,thamnien,namtruoc_chuyensang,ngay_cat_phep,tong_duoc_nghi,dadung_cuoinam,conlai_cuoinam">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                            <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Tên NV" DataField="ten" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Chức danh" DataField="chuc_danh" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Bộ phận" DataField="bo_phan" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Ngày vào công ty" DataField="ngay_vao" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_r" />
                                                                            <asp:BoundField HeaderText="Thâm niên" DataField="thamnien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                                                            <asp:BoundField HeaderText="Số phép năm trước chuyển sang" DataField="namtruoc_chuyensang" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                                                            <asp:BoundField HeaderText="Ngày hết hạn phép của năm trước" DataField="ngay_cat_phep" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Tổng phép được nghỉ trong năm" DataField="tong_duoc_nghi" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma_r" />
                                                                            <asp:BoundField HeaderText="Số ngày đã nghỉ" DataField="dadung_cuoinam" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma_r" />
                                                                            <asp:BoundField HeaderText="Số phép còn lại" DataField="conlai_cuoinam" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma_r" />
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_ct_td" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_ct_slide" rong="900" runat="server" loai="X" gridId="GR_ct"
                                                        ham="ns_cc_nghiphep_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <Cthuvien:nhap ID="Xuat2" runat="server" Width="70px" Text="Export" OnServerClick="xuat_Click" />
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
