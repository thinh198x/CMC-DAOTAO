<%@ Page Title="hdns_pt_nguonluc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_pt_nguonluc.aspx.cs" Inherits="f_hdns_pt_nguonluc" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phân tích nguồn lực" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td> 
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Tháng" Width="80px" CssClass="css_gchu"></Cthuvien:bbuoc> 
                                                </td>
                                                <td>
                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" ten="Tháng" kt_xoa="X" CssClass="css_ma" kieu_chu="true"
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
                                                    <div style="height: 360px; width: 900px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="30" cot="phong,ten_phong,cdanh,ten_cdanh,ns_hientai,ns_thangtien,cdanh_thangtien,ns_dukien_ts,ns_dukien_nv,ghichu,so_id" cotAn="so_id" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Mã đơn vị" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="phong" runat="server" CssClass="css_Gma_c" kieu_chu="true" kt_xoa="X" f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="120px">
                                                                    <ItemStyle CssClass="css_Gnd" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="cdanh" runat="server" CssClass="css_Gma_c" kieu_chu="true" kt_xoa="X" f_tkhao="~/App_form/ns/ma/ns_ma_cvu.aspx" ktra="ns_ma_cvu,ma,ten" Width="100px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ten_cdanh" HeaderText="Tên chức danh" HeaderStyle-Width="200px" />
                                                                <asp:TemplateField HeaderText="Nhân sự tại thời điểm hiện tại" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ns_hientai" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Số lượng nhân sự thăng tiến" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ns_thangtien" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Chức danh thăng tiến" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="cdanh_thangtien" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Số lượng nhân sự nghỉ thai sản" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ns_dukien_ts" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                 <asp:TemplateField HeaderText="Số lượng nghỉ việc dự kiến" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ns_dukien_nv" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                 <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ghichu" runat="server" Width="200px" CssClass="css_Gso" kieu_so="true" />
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
                                    <td align="center" valign="middle">
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" CssClass="css_button"
                                                        OnClick="return hdns_pt_nguonluc_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" CssClass="css_button"
                                                        OnClick="return hdns_pt_nguonluc_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" CssClass="css_button"
                                                        OnClick="return hdns_pt_nguonluc_P_XOA();form_P_LOI();" />
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return hdns_pt_nguonluc_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return hdns_pt_nguonluc_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return hdns_pt_nguonluc_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return hdns_pt_nguonluc_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="hdns_pt_nguonluc_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="125px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                            ham="hdns_pt_nguonluc_P_LKE()" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1220,560" />
    </div>
</asp:Content>
