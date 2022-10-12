<%@ Page Title="ns_td_dot" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_dot.aspx.cs" Inherits="f_ns_td_dot" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đợt tuyển dụng" />
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
            <td>
                <table cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Năm tuyển dụng" Width="100px" CssClass="css_gchu_c" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="nam" ten="Năm tuyển dụng" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="150px" kieu_so="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="Mã đợt" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" Width="150px" onchange=" return ns_td_dot_P_KTRA('MA')" CssClass="css_ma" kieu_chu="true" kt_xoa="G" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Tên đợt" Width="100px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="tendot" ten="tên đợt tuyển dụng" runat="server" CssClass="css_ma" kt_xoa="X" Width="150px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Ngày bắt đầu" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày bắt đầu" runat="server" CssClass="css_ma_c" kt_xoa="X" Width="150px" kieu_luu="S" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text="Ngày kết thúc" Width="100px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Ngày kết thúc" runat="server" CssClass="css_ma_c" kt_xoa="X" Width="150px" kieu_luu="S"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Điểm đạt" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="diem" ten="Điểm đạt" runat="server" CssClass="css_so" kt_xoa="X" Width="150px" so_tp="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_ma" Width="613px" kieu_unicode="true"
                                            TextMode="MultiLine" Height="50px"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:tab ID="NPa_yc" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                        Height="20px" Text="Các yêu cầu" ham="ns_td_dot_P_NPA('yc')"/>
                                                </td>
                                                <td style="width: 1px;" />
                                                <td>
                                                    <Cthuvien:tab ID="NPa_vg" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                        Height="20px" Text="Các vòng thi tuyển" ham="ns_td_dot_P_NPA('vg')" />
                                                </td>
                                                <td style="border-bottom: 1px solid #cccccc; width: 10%">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="tab_content">
                                        <asp:Panel ID="Pa_yc" runat="server" Style="display: block;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="UPa_yc">
                                                            <Cthuvien:GridX ID="GR_yc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="N" cot="sott,ma_dxuat,nhom_cdanh,cdanh,ten_ncdanh,ten_cdanh,loai,soluong,noi_lv"
                                                                cotAn="nhom_cdanh,cdanh" hangKt="8" hamUp="ns_td_dot_Update_yc">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:TemplateField HeaderText="TT" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="sott" runat="server" Width="30px" CssClass="css_Gma_c" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mã đề xuất" HeaderStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ma_dxuat" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/td/ns_td_dexuat.aspx"
                                                                                ktra="ns_td_dexuat,ma,ma" kieu_chu="true" ten="Mã đề xuất" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Mã nhóm chức danh" DataField="nhom_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Mã chức danh" DataField="cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="ten_ncdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Loại" DataField="loai" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField HeaderText="Số lượng" DataField="soluong" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField HeaderText="Nơi làm việc" DataField="noi_lv" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Pa_vg" runat="server" Style="display: none;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="UPa_vg" style="height: 215px; width: 760px; overflow: scroll">
                                                            <Cthuvien:GridX ID="GR_vg" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="N" cot="sott,ma_dxuat,ten_ncdanh,ten_cdanh,vong1,diem1,hso1,vong2,diem2,hso2,vong3,diem3,hso3,vong4,diem4,hso4,
                                                                vong5,diem5,hso5,vong6,diem6,hso6,vong7,diem7,hso7,vong8,diem8,hso8,vong9,diem9,hso9,vong10,diem10,hso10"
                                                                hangKt="8" hamUp="ns_td_dot_Update_vg">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField HeaderText="TT" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField HeaderText="Mã đề xuất" DataField="ma_dxuat" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="ten_ncdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                    <asp:TemplateField HeaderText="Vòng 1" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong1" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 1" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem1" runat="server" Width="30px" CssClass="css_Gso" so_tp="2" ten="Điểm vượt qua vòng 1" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso1" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 1" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 2" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong2" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 2" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem2" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 2" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso2" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 2" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 3" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong3" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 3" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem3" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 3" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso3" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 3" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 4" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong4" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 4" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem4" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 4" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso4" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 4" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 5" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong5" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 5" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem5" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 5" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso5" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 5" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 6" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong6" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 6" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem6" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 6" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso6" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 6" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 7" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong7" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 7" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem7" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 7" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso7" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 7" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 8" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong8" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 8" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem8" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 8" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso8" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 8" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 9" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong9" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 9" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem9" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 9" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso9" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 9" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vòng 10" HeaderStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="vong10" runat="server" Width="80px" CssClass="css_Gma" kieu_chu="true" ten="Vòng 10" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="diem10" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Điểm vượt qua vòng 10" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="30px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:so ID="hso10" runat="server" Width="30px" CssClass="css_Gso" so_tp="2"  ten="Hệ số vòng 10" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_td_dot_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_dot_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_td_dot_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_td_dot_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_td_dot_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_td_dot_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_td_dot_ChenDong('C');" />
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
                                CssClass="table gridX" loai="X" hangKt="16" cotAn="so_id" hamRow="ns_td_dot_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên đợt" DataField="tendot" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="80" gridId="GR_lke"
                                ham="ns_td_dot_P_LKE()" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,520" />
    </div>
</asp:Content>
