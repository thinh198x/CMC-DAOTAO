<%@ Page Title="ns_dt_kbd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_kbd.aspx.cs" Inherits="f_ns_dt_kbd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
       <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khóa bồi dưỡng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
                            <table id="UPa_ct" runat="server"  cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Năm" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_so" Width="100px" kieu_so="true" onchange="ns_dt_kbd_P_KTRA('NAM')"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Số QĐ" Width="60px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="so_qd" ToolTip="Số quyết định" runat="server"  Width="185px" CssClass="css_ma" kt_xoa="X" kieu_luu="S" kieu_chu="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Ngày QĐ" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_qd" ToolTip="Ngày quyết định"  runat="server"  Width="185px" CssClass="css_so_c" kieu_luu="I" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Tên khóa BD" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" ten="Tên khóa bồi dưỡng" ToolTip="Tên khóa bồi dưỡng" kieu_unicode="true" 
                                                        runat="server" CssClass="css_ma" Width="486px" kt_xoa="X"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Nơi bồi dưỡng" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="noidt" ten="Nơi đào tạo" runat="server" CssClass="css_ma" 
                                                        Width="185px" kt_xoa="X" kieu_unicode="true"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Quốc gia" CssClass="css_gchu_c" Width="110px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="quocgia" ten="Quốc gia" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        ktra="ns_ma_nuoc,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_nuoc.aspx" onchange="ns_dt_kbd_P_KTRA('quocgia')" 
                                                        Width="185px" kt_xoa="X"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Từ ngày" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server"  Width="185px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="I" /> 
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Đến ngày" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYC" runat="server"  Width="185px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="I" /> 
                                                </td>
                                            </tr>
                                        </table>                            
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Nội dung" CssClass="css_gchu" Width="90px"/>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="noidung" ten="Nội dung" kieu_unicode="true" 
                                                        runat="server" CssClass="css_ma" Width="185px" kt_xoa="X"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Hình thức BD" CssClass="css_gchu_c" Width="110px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="hinhthuc" ten="Hình thức bồi dưỡng" ToolTip="Hình thức bồi dưỡng" runat="server" CssClass="css_ma" 
                                                        BackColor="#f6f7f7" kieu_chu="true" ktra="ns_ma_htdt,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" 
                                                        onchange="ns_dt_kbd_P_KTRA('hinhthuc')" Width="185px" kt_xoa="X"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Nguồn kinh phí" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="kinhphi" ten="Nguồn kinh phí" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                                        ktra="ns_dt_ma_nguonkp,ma,ten" kt_xoa="X" f_tkhao="~/App_form/ns/dt/ns_dt_ma_nguonkp.aspx"
                                                        kieu_chu="true" Width="185px" onchange="ns_dt_kbd_P_KTRA('KINHPHI')" gchu="gchu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Đơn giá" CssClass="css_gchu_c" Width="110px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="giatri" ten="Giá trị" runat="server" CssClass="css_so"  
                                                        onchange="ns_dt_kbd_P_KTRA('giatri')" Width="151px" kt_xoa="X" ValueText="0" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ma_nte" runat="server" kt_xoa="K" CssClass="css_ma_c" kieu_chu="true" BackColor="#f6f7f7"
                                                        f_tkhao="~/App_form/ns/ma/ns_ma_nte.aspx" Width="27px" Text="VND" ten="Mã tiền tệ" 
                                                        onchange="ns_dt_kbd_P_KTRA('MA_NTE')" ktra="ns_ma_nte,ma,ten"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="80px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" onchange="ns_dt_kbd_P_KTRA('NOTE')"
                                            CssClass="css_ma" Width="486px" kieu_unicode="true" TextMode="MultiLine" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="tt,so_the,ten,phong,kq" hangKt="5" hamUp="ns_dt_kbd_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="TT" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="tt" runat="server" Width="50px" CssClass="css_Gma_c" kieu_luu="I" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mã cán bộ" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="so_the" runat="server" Width="50px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                            ktra="ns_cb,so_the,ten" kieu_chu="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:TemplateField HeaderText="Kết quả" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="kq" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id ="UPa_nhap" runat ="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dt_kbd_P_NH();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dt_kbd_P_MOI();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dt_kbd_P_XOA();form_P_LOI();" Width="70px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dt_kbd_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dt_kbd_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dt_kbd_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dt_kbd_ChenDong('C');" />
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
                                CssClass="table gridX" loai="L" hangKt="19" cotAn="so_id" hamRow="ns_dt_kbd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên khóa bồi dưỡng" DataField="ten" HeaderStyle-Width="250px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id ="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                        </table>
                </td>
             </tr>
    </table>
    <div id ="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,520"  />
    </div>
</asp:Content>
