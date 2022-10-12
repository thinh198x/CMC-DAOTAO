<%@ Page Title="tl_tn_pcap" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tn_pcap.aspx.cs" Inherits="f_tl_tn_pcap" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Hưởng phụ cấp" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="tl_tn_pcap_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày thiết lập" DataField="ngay" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="tl_tn_pcap_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text="Phòng" CssClass="css_gchu" Width="80px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="422px" CssClass="css_form"
                                                        onchange="tl_tn_pcap_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" Text="Theo" CssClass="css_gchu" Width="80px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="THEO" runat="server" CssClass="css_form" Width="422px" onchange="tl_tn_pcap_P_KTRA('THEO')">
                                                        <asp:ListItem Text="Theo phòng ban" Value="PB" />
                                                        <asp:ListItem Text="Theo từng cán bộ" Value="CB" />
                                                        <asp:ListItem Text="Theo chức danh công việc" Value="CD" />
                                                        <asp:ListItem Text="Theo chức vụ" Value="CV" />
                                                        <asp:ListItem Text="Theo nhóm" Value="NH" />
                                                        <asp:ListItem Text="Theo mã phụ cấp" Value="PC" />
                                                        <%--<asp:ListItem Text="Giới tính" Value="GT" />--%>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:gchu ID="lblma" runat="server" Text="Mã phòng ban*" CssClass="css_gchu" kt_xoa="K" Width="100px"></Cthuvien:gchu>

                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA_GOC" runat="server" kt_xoa="K" CssClass="css_form" ten="Mã phòng ban" ToolTip="Mã phòng ban"
                                                                    kieu_chu="true" Width="146px" f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten"
                                                                    onchange="tl_tn_pcap_P_KTRA('MA_GOC')" BackColor="#f6f7f7" Text="TATCA" disabled="true" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu_c" Text="Ngày thiết lập" Width="112px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="css_form_c" kt_xoa="G" Width="120px"
                                                                        ten="Ngày thiết lập" onchange="tl_tn_pcap_P_KTRA('NGAY')" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" Text="Quyết định/Tờ trình" CssClass="css_gchu" Width="120px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_QD" runat="server" kt_xoa="X" CssClass="css_form" BackColor="#f6f7f7" placeholder="Nhấn (F1)" ten="Quyết định/Tờ trình"
                                                                    ToolTip="Quyết định/Tờ trình"  f_tkhao="~/App_form/ns/qt/ns_hdct.aspx" guiId="MA_GOC" ktra="ns_hdct,so_the,SO_QD" kieu_chu="true" Width="146px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu_c" Text="Ngày QĐ" Width="112px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_QD" runat="server" CssClass="css_form_c" kt_xoa="X" Width="120px"
                                                                        ten="Ngày quyết định" ToolTip="Ngày quyết định" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Từ ngày" Width="80px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" CssClass="css_form_c" kt_xoa="X" Width="120px"
                                                                        ten="Ngày quyết định" ToolTip="Ngày quyết định" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="112px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" CssClass="css_form_c" kt_xoa="X" Width="120px"
                                                                        ten="Ngày quyết định" ToolTip="Ngày quyết định" />
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
                                        <table id="grct" runat="server" cellpadding="0" cellspacing="0" style="display: block">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="mapc,tenpc,giatri,hinhthuc" hangKt="15" cotAn="hinhthuc" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="tl_tn_pcap_sp_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã Phụ cấp(*)" HeaderStyle-Width="129px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="mapc" runat="server" Width="129px" CssClass="css_Gma_c" kieu_chu="true"
                                                                        f_tkhao="~/App_form/tl/ma/tl_tlap_pcap.aspx" ktra="ns_tl_tlap_pcap,ma,ten,gtri" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên phụ cấp" DataField="tenpc" HeaderStyle-Width="210px" />
                                                            <asp:TemplateField HeaderText="Giá trị(*)" HeaderStyle-Width="165px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="giatri" runat="server" Width="165px" CssClass="css_Gso" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="hình thức" DataField="hinhthuc" HeaderStyle-Width="130px" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table id="grcb" runat="server" cellpadding="0" cellspacing="0" style="display: none">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_cb" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="so_the,ten,giatri,hinhthuc" hangKt="15" cotAn="hinhthuc" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="tl_tn_pcap_sp_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã cán bộ(*)" HeaderStyle-Width="129px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="so_the" runat="server" Width="129px" CssClass="css_Gso" kieu_chu="true"
                                                                        f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,ma,ten" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="170px" />
                                                            <asp:TemplateField HeaderText="Giá trị(*)" HeaderStyle-Width="165px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="giatri" runat="server" Width="165px" CssClass="css_Gma_c" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="hình thức" DataField="hinhthuc" HeaderStyle-Width="130px" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return tl_tn_pcap_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return tl_tn_pcap_P_MOI();form_P_LOI();" class="bt bt-grey">Mới</a>
                                                        <a href="#" onclick="return tl_tn_pcap_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON2('GR_ct:ma,GR_ct:hso');form_P_LOI();" class="bt bt-grey">Chọn</a>
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px">
                                                    <img runat="server" alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return tl_tn_pcap_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return tl_tn_pcap_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return tl_tn_pcap_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return tl_tn_pcap_ChenDong('C');" />
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="SO_QD_ID" runat="server" />
        <Cthuvien:an ID="gtri" runat="server" />
        <Cthuvien:an ID="hinhthuc" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="760,890" />
    </div>
</asp:Content>
