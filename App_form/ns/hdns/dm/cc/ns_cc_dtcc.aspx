<%@ Page Title="ns_cc_dtcc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_dtcc.aspx.cs" Inherits="f_ns_cc_dtcc" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập đối tượng chấm công" />
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
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,phong,nsd" hamRow="ns_cc_dtcc_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="css_Gma" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Hiệu lực miễn theo dõi chấm công" DataField="ngay_hl_mtd" HeaderStyle-Width="130px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Hiệu lực miễn đi muộn về sớm" DataField="ngay_hl_dmvs" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Hiệu lực onsite" DataField="ngay_hl_onsite" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Hiệu lực làm việc khác giờ" DataField="ngay_hl_kg" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="phong" />
                                            <asp:BoundField DataField="nsd" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_cc_dtcc_P_LKE()" />
                            </div>
                        </td>
                        <td class="form_right" style="width: 560px">
                            <div style="height: 500px; width: 100%; overflow-y: scroll">
                                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                    <tr style="display: none">
                                        <td>
                                            <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Phòng ban" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <Cthuvien:DR_lke ID="PHONG" ten="Phòng ban" runat="server" Width="250px" ktra="DT_PH" onchange="ns_cc_dtcc_P_KTRA('PHONG');" kt_xoa="G" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <asp:Label ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Miễn theo dõi làm việc" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <Cthuvien:kieu ID="mtd" onchange="anhien();form_P_LOI();" runat="server" lke=",X" Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table id="UPa_mtd" cellpadding="1" cellspacing="1" style="display: none">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <div class="ip-group date">
                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hl_mtd" ten="Ngày hiệu lực" runat="server" kt_xoa="X" CssClass="css_form_c" Width="222px" kieu_luu="S" />
                                                            <span class="ip-group-addon" style="width:0%"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="height: 140px">
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                    </td>
                                                    <td valign="top" style="width: 400px">
                                                        <div class="css_divb">
                                                            <div class="css_divCn">
                                                                <Cthuvien:GridX ID="GR_mtd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="MA_CD,ten,SO_ID_CD,ma" cotAn="SO_ID_CD,ma" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="172px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi_tk.aspx" guiId="phongid,ngay_hl_mtd" Width="172px" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="165px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="165px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SO_ID_CD" />
                                                                        <asp:BoundField DataField="ma" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </div>
                                                            <ctr_khud_divC:ctr_khud_divC ID="GR_mtd_slide" runat="server" gridId="GR_mtd" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" style="padding-right: 7px">
                                                        <div style="border: gray 1px solid; width: 20px; height: 15px;" align="center">
                                                            <img id="a4" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_dtcc_mtd_cat(event);" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Miễn theo dõi đi muộn về sớm" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <Cthuvien:kieu ID="dmvs" onchange="anhien();form_P_LOI();" runat="server" lke=",X" Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table id="UPa_dmvs" cellpadding="1" cellspacing="1" style="display: none">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <Cthuvien:bbuoc ID="Bbuoc6" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <div class="ip-group date">
                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hl_dmvs" ten="Ngày hiệu lực" runat="server" kt_xoa="X" CssClass="css_form_c" Width="222px" kieu_luu="S" />
                                                            <span class="ip-group-addon" style="width:0%"><i class="fa fa-calendar"></i></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="height: 140px">
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Bbuoc7" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                    </td>
                                                    <td valign="top" style="width: 400px">
                                                        <div class="css_divb">
                                                            <div class="css_divCn">
                                                                <Cthuvien:GridX ID="GR_dmvs" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="MA_CD,ten,SO_ID_CD,ma" cotAn="SO_ID_CD,ma" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="172px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi_tk.aspx" guiId="phongid,ngay_hl_dmvs" Width="172px" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="165px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="165px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SO_ID_CD" />
                                                                        <asp:BoundField DataField="ma" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </div>
                                                            <ctr_khud_divC:ctr_khud_divC ID="GR_dmvs_slide" runat="server" gridId="GR_dmvs" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" style="padding-right: 7px">
                                                        <div style="border: gray 1px solid; width: 20px; height: 15px;" align="center">
                                                            <img id="Img4" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_dtcc_dmvs_cat(event);" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <asp:Label ID="Label6" runat="server" Text="Làm việc ngoài công ty hoặc đi onsite" CssClass="css_gchu" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <Cthuvien:kieu ID="onsite" onchange="anhien();form_P_LOI();" runat="server" lke=",X" Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="UPa_onsite" cellpadding="1" cellspacing="1" style="display: none">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <Cthuvien:bbuoc ID="Bbuoc8" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <div class="ip-group date">
                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hl_onsite" ten="Ngày hiệu lực" runat="server" kt_xoa="X" CssClass="css_form_c" Width="222px" kieu_luu="S" />
                                                            <span class="ip-group-addon" style="width:0%"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="height: 140px">
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Bbuoc9" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                    </td>
                                                    <td valign="top" style="width: 400px">
                                                        <div class="css_divb">
                                                            <div class="css_divCn">
                                                                <Cthuvien:GridX ID="GR_onsite" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="MA_CD,ten,SO_ID_CD,ma" cotAn="SO_ID_CD,ma" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="172px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi_tk.aspx" guiId="phongid,ngay_hl_onsite" Width="172px" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="165px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="165px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SO_ID_CD" />
                                                                        <asp:BoundField DataField="ma" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </div>
                                                            <ctr_khud_divC:ctr_khud_divC ID="GR_onsite_slide" runat="server" gridId="GR_onsite" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" style="padding-right: 7px">
                                                        <div style="border: gray 1px solid; width: 20px; height: 15px;" align="center">
                                                            <img id="Img1" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_dtcc_onsite_cat(event);" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Làm khác giờ chuẩn công ty" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <Cthuvien:kieu ID="kg" onchange="anhien();form_P_LOI();" runat="server" lke=",X" Width="30px" ToolTip="X - Có,  - Không" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="UPa_kg" cellpadding="1" cellspacing="1" style="display: none">
                                                <tr>
                                                    <td align="left" style="width: 120px">
                                                        <Cthuvien:bbuoc ID="Bbuoc10" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" Width="120px" />
                                                    </td>
                                                    <td align="left">
                                                        <div class="ip-group date">
                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hl_kg" ten="Ngày hiệu lực" runat="server" kt_xoa="X" CssClass="css_form_c" Width="222px" kieu_luu="S" />
                                                            <span class="ip-group-addon" style="width:0%"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="height: 140px">
                                                    <td>
                                                        <Cthuvien:bbuoc ID="Bbuoc11" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                    </td>
                                                    <td valign="top" style="width: 400px">
                                                        <div class="css_divb">
                                                            <div class="css_divCn">
                                                                <Cthuvien:GridX ID="GR_kg" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="MA_CD,ten,SO_ID_CD,ma" cotAn="SO_ID_CD,ma" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="172px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi_tk.aspx" guiId="phongid,ngay_hl_kg" Width="172px" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="165px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="165px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SO_ID_CD" />
                                                                        <asp:BoundField DataField="ma" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </div>
                                                            <ctr_khud_divC:ctr_khud_divC ID="GR_kg_slide" runat="server" gridId="GR_kg" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" style="padding-right: 7px">
                                                        <div style="border: gray 1px solid; width: 20px; height: 15px;" align="center">
                                                            <img id="Img2" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_dtcc_kg_cat(event);" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Cthuvien:so ID="ma" runat="server" CssClass="css_form hiden" kieu_chu="true" kt_xoa="X"
                                                gchu="gchu" Width="160px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td>
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="90px" OnClick="return ns_cc_dtcc_P_MOI();form_P_LOI();" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_cc_dtcc_P_NH();form_P_LOI();" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_cc_dtcc_P_XOA();form_P_LOI();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="phongid" runat="server" kt_xoa="X" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1330,650" />
    </div>
</asp:Content>
