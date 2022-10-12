<%@ Page Title="hdns_kh_tuyendung" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_kh_tuyendung.aspx.cs" Inherits="f_hdns_kh_tuyendung" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch tuyển dụng " />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="ma" hamRow="hdns_kh_tuyendung_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Kế hoạch" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="ma" DataField="ma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                            ham="hdns_kh_tuyendung_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Năm" Tolltip="Năm" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="nam" runat="server" ten="Năm" kt_xoa="G" CssClass="css_form_c" kieu_so="true"
                                                        Width="140px" onchange="hdns_kh_tuyendung_P_KD_P_KTRA('NAM');"/>
                                                    <Cthuvien:an ID="hincd" runat="server" Value="" />
                                                    <Cthuvien:an ID="hincd2" runat="server" Value="" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Tháng" Tolltip="Tháng" />
                                                </td>
                                                <td>

                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang" ten="Tháng" runat="server"
                                                        CssClass="css_form_c" Width="112px" kt_xoa="G" />
                                                    </div>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Mã kế hoạch" Tolltip="Mã kế hoạch" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA" ten="Mã kế hoạch " runat="server" onchange="hdns_kh_tuyendung_P_KD_P_KTRA('MA');" kt_xoa="G" CssClass="css_form"
                                                        Width="140px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu" Text="Tên kế hoạch" Tolltip="Tên kế hoạch" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten" ten="Tên kế hoạch " runat="server" kt_xoa="X" CssClass="css_form"
                                                        Width="140px" kieu_unicode="true" />
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
                                                    <div style="height: 550px; width: 800px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" hamUp="hdns_kh_tuyendung_Update_tt"
                                                            CssClass="table gridX" loai="N" hangKt="15" cotAn="so_id" cot="phong,ten_phong,ncdanh,ten_ncdanh,cdanh,ten_cdanh,bcdanh,heso,khoach_ngay,soluong_cantuyen,ngay_dl,lydo,bophan_yc,ten_bophan_yc,ghichu,so_id">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Mã đơn vị(*)" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="PHONG" runat="server" CssClass="css_Gma_c" kieu_chu="true" kt_xoa="X" MaxLength="255"
                                                                            f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Đơn vị" DataField="TEN_PHONG" HeaderStyle-Width="120px">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>

                                                                <asp:TemplateField HeaderText="Mã nhóm chức danh(*)" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="NCDANH" runat="server" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tên nhóm chức danh" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TEN_NCDANH" Enabled="false" runat="server" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mã chức danh(*)" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="cdanh" runat="server" guiId="hincd" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Bậc chức danh(*)" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ten_bcdanh" runat="server" CssClass="css_Gma_c" guiId="hincd,hincd2" kieu_chu="true"
                                                                            MaxLength="10" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_baccdanh.aspx" ktra="ns_ma_baccdanh_ct,ma,hso" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="heso" HeaderText="Hệ số" HeaderStyle-Width="40px" />
                                                                <asp:TemplateField HeaderText="Ngày lập kế hoạch(*)" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="khoach_ngay" runat="server" CssClass="css_Gma" ten="Ngày lập kế hoạch" kieu_date="true" kt_xoa="X" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Số lượng cần tuyển" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="soluong_cantuyen" MaxLength="3" runat="server" CssClass="css_Gma_c" kieu_so="true" kt_xoa="X" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ngày dự kiến đi làm(*)" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_dl" runat="server" CssClass="css_Gma" kieu_date="true" kt_xoa="X" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lý do tuyển dụng" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="lydo" runat="server" MaxLength="255" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Bộ phận yêu cầu" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="bophan_yc" runat="server" MaxLength="255" CssClass="css_Gma_c" kieu_chu="true" kt_xoa="X"
                                                                            f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Tên bộ phận" DataField="ten_bophan_yc" HeaderStyle-Width="120px">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ghichu" runat="server" MaxLength="1000" CssClass="css_Gma" kt_xoa="X" Width="200px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="so_id" DataField="so_id">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" style="padding-top: 5px;">
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return hdns_kh_tuyendung_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return hdns_kh_tuyendung_P_MOI();form_P_LOI();"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return hdns_kh_tuyendung_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN,SOLUONG_CANTUYEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>

                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">

                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return hdns_kh_tuyendung_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return hdns_kh_tuyendung_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return hdns_kh_tuyendung_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return hdns_kh_tuyendung_ChenDong('C');" />
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
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1220,620" />
    </div>
</asp:Content>
