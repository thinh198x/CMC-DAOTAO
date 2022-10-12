<%@ Page Title="ns_qt_debat" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_debat.aspx.cs" Inherits="f_ns_qt_debat" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="D.s Nâng lương" />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="18" cotAn="SOTT" cot="ngay_lap,SOTT" hamRow="ns_qt_debat_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay_lap" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField DataField="SOTT" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="70" gridId="GR_lke"
                                            ham="ns_qt_debat_P_LKE()" />
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
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu_c" Text="Ngày lập" Width="80px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_LAP" runat="server" CssClass="css_form_c" kt_xoa="G" Width="120px"
                                                            kieu_luu="S" ten="Ngày lập" ToolTip="Ngày lập" onchange="ns_qt_debat_P_KTRA('NGAY_LAP')" />
                                                    </div>
                                                    <Cthuvien:an ID="hincd" runat="server" Value="" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cotAn="cdanh,cvu,ncd" cot="so_the,ten,phong,ten_cvu,hspc,ten_ncd,ten_cdanh,bac,hso,luong,ghichu,cvu,cdanh,ncd" hangKt="15" rong="20" hamUp="ns_qt_debat_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã cán bộ" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                            ktra="ns_cb,so_the,ten" kieu_chu="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />

                                                <asp:TemplateField HeaderText="chức vụ mới" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_cvu" runat="server" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_cvu.aspx" ktra="ns_ma_cvu,ma,ten,hspc" Width="140px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hsố pcấp mới" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="hspc" runat="server" Width="50px" CssClass="css_Gso" so_tp="3" co_dau="C" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nhóm chức danh mới" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_ncd" runat="server" CssClass="css_Gma_c" kieu_chu="true" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten" Width="120px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="chức danh mới" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="TEN_CDANH" runat="server" CssClass="css_Gma_c" guiId="hincd" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="120px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bậc mới" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="bac" runat="server" CssClass="css_Gma_r" Width="50px" kt_xoa="X" kieu_chu="true"
                                                            f_tkhao="~/App_form/ns/ma/ns_ma_baccdanh.aspx" gchu="gchu" ktra="ns_ma_baccdanh_ct,ma,ma" ten="tên bậc chức danh công việc"
                                                            ToolTip="Bậc chức danh công việc" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hsố mới" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="hso" runat="server" Width="50px" CssClass="css_Gso" so_tp="3" co_dau="C" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lương mới" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="luong" runat="server" Width="120px" CssClass="css_Gso" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ghichu" runat="server" Width="150px" CssClass="css_Gma" kieu_unicode="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="cdanh" DataField="cdanh" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="cvu" DataField="cvu" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="ncd" DataField="ncd" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_qt_debat_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_qt_debat_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_qt_debat_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_qt_debat_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_qt_debat_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_qt_debat_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_qt_debat_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1420,750" />
    </div>
</asp:Content>
