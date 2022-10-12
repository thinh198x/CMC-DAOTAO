<%@ Page Title="ns_dt_danhsach" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_danhsach.aspx.cs" Inherits="f_ns_dt_danhsach" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách đề xuất" />
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
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Tình trạng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_form" kieu="S" Width="376px" onchange="ns_dt_danhsach_P_KTRA('tinhtrang')">
                                            <asp:ListItem Text="Chưa phê duyệt" Value="0" />
                                            <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                            <asp:ListItem Text="Không phê duyệt" Value="2" />
                                        </Cthuvien:DR_nhap>
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
                                            CssClass="table gridX" loai="N" hangKt="10" cot="chon,ma,ten,lan,ngayd,ma_dvi,phong,soluong,chiphi,ykien">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Mã đề xuất" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên khóa học" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Lần đề xuất" DataField="lan" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField HeaderText="Ngày đề xuất" DataField="ngayd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Đơn vị" DataField="ma_dvi" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Phòng ban" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Số lượng" DataField="soluong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                                <asp:BoundField HeaderText="Chi phí" DataField="chiphi" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
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
                                            ham="ns_dt_danhsach_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
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
                            <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_dt_danhsach_CHON();" />
                        </td>
                        <td>
                            <div class="box3 txRight2">
                                <a href="#" onclick="return ns_dt_danhsach_P_XEM();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>em</a>
                                <a href="#" onclick="return ns_dt_danhsach_P_PHEDUYET();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">P</span>hê duyệt</a>
                                <a href="#" onclick="return ns_dt_danhsach_P_KOPHEDUYET();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">K</span>hông phê duyệt</a>
                                <a href="#" onclick="return ns_dt_danhsach_P_CHOPHEDUYET();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>hờ phê duyệt</a>
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,600" />
    </div>
</asp:Content>
