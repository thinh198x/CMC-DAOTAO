<%@ Page Title="tl_dky_lamthempd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_dky_lamthempd.aspx.cs" Inherits="f_tl_dky_lamthempd" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt đăng ký làm thêm giờ" />
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
                        <td valign="middle" class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Tình trạng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" kieu="S" Width="200px" onchange="tl_dky_lamthempd_P_KTRA('tinhtrang')">
                                                        <asp:ListItem Text="Chưa phê duyệt" Value="0" />
                                                        <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                                        <asp:ListItem Text="Không phê duyệt" Value="2" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Tháng" Width="90px" CssClass="css_gchu_c" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang" ten="Tháng" runat="server" CssClass="css_form_c" Width="120px" kieu_luu="I" onchange="tl_dky_lamthempd_P_LKE();" />
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
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="10" cot="chon,so_id,so_the,ten,phong,ngay_bd,gio_bd,gio_kt,ot_thoigian,nt_thoigian,hinhthuc,noidung,tinhtrang,ykien"
                                            cotAn="so_id,so_the,tinhtrang">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_bd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Giờ bắt đầu" DataField="gio_bd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Giờ kết thúc" DataField="gio_kt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Số giờ làm thêm" DataField="ot_thoigian" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Số giờ làm đêm" DataField="nt_thoigian" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Hình thức" DataField="hinhthuc" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Nội dung" DataField="noidung" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:TemplateField HeaderText="Ý kiến phản hồi" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ykien" runat="server" Width="200px" CssClass="css_Gnd" kt_xoa="X" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="tl_dky_lamthempd_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                        <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return tl_dky_lamthempd_CHON();" />
                                    </td>
                                    <td>
                                        <div class="box3 txRight2">
                                            <a href="#" onclick="return tl_dky_lamthempd_P_PHEDUYET();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">P</span>hê duyệt</a>
                                            <a href="#" onclick="return tl_dky_lamthempd_P_KOPHEDUYET();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">K</span>hông phê duyệt</a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,600" />
    </div>
</asp:Content>
