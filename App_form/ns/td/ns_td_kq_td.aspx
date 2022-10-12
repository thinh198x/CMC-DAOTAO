<%@ Page Title="ns_td_kq_td" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kq_td.aspx.cs" Inherits="f_ns_td_kq_td" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left" style="width: 234px">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Cập nhật kết quả các vòng thi" />
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
                    <tr>
                        <td valign="top" class="form_left" style="width: 234px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 234px">
                                        <table id="Upa_tk" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" Width="100px" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td style="padding-bottom: 2px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="nam_tk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="css_form_r" Width="200px" onchange="ns_td_kq_td_P_KTRA('NAM_TK')" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Bbuoc1" runat="server" Width="100px" Text="Mã yêu cầu TD" CssClass="css_gchu" />
                                                </td>
                                                <td style="padding-bottom: 2px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_lke ID="ma_dx_tk" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TK_TD" runat="server" Width="200px">                                                                                
                                                                </Cthuvien:DR_lke>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="padding-top: 5px">
                                                <td></td>
                                                <td style="padding-top: 5px; padding-bottom: 5px">
                                                    <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_td_kq_td_P_LKE('M');form_P_LOI();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 440px; width: 400px; overflow-x: scroll">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="L" hangKt="13" cotAn="so_id" hamRow="ns_td_kq_td_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="100px"
                                                        ItemStyle-CssClass="css_Gma_r" />
                                                    <asp:BoundField HeaderText="Mã yêu cầu" DataField="ma_yc" HeaderStyle-Width="100px"
                                                        ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Vị trí TD" DataField="ten_cdanh" HeaderStyle-Width="100px"
                                                        ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Phòng/Ban" DataField="ten_phong" HeaderStyle-Width="100px"
                                                        ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Số id" DataField="so_id" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_kq_td_lke('K')" />
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
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label8" runat="server" Width="140px" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="css_form_r" Width="220px" onchange="ns_td_kq_td_P_KTRA('NAM')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Width="120px" Text="Yêu cầu tuyển dụng" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_lke ID="MAYEUCAU_TD" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TD" runat="server" Width="220px" onchange="ns_td_kq_td_P_KTRA('MAYEUCAU_TD')">                                                                                
                                                                </Cthuvien:DR_lke>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label14" runat="server" Width="140px" Text="Chức danh" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ten_cdanh" runat="server" Enabled="false" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                                    Width="220px" ten="Chức danh" BackColor="#f6f7f7" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Bbuoc3" runat="server" Width="120px" Text="Đơn vị" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                                    Width="220px" ten="Đơn vị" BackColor="#f6f7f7" />
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
                                                    <div style="height: 450px; width: 820px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="so_the,ten,ngaysinh,monthi1,ngaythi1,nguoi_pv1,diemdat1,ketqua1,monthi2,ngaythi2,nguoi_pv2,diemdat2,ketqua2,monthi3,ngaythi3,nguoi_pv3,diemdat3,ketqua3,ketqua_chung,gd_nhansu_pd,tgd_pd"
                                                            cotAn="so_id" hangKt="8">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:TemplateField HeaderText="Môn thi 1" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="monthi1" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ngày thi môn 1" HeaderStyle-Width="110px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythi1" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Người PV" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="nguoi_pv1" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Điểm đánh giá 1" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="diemdat1" runat="server" CssClass="css_Gma" kieu_so="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Kết quả thi môn 1" HeaderStyle-Width="160px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ketqua1" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="160px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Môn thi 2" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="monthi2" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ngày thi môn 2" HeaderStyle-Width="110px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythi2" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Người PV 2" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="nguoi_pv2" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Điểm đánh giá 2" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="diemdat1" runat="server" CssClass="css_Gma" kieu_so="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Kết quả thi môn 2" HeaderStyle-Width="160px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ketqua2" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="160px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Môn thi 3" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="monthi3" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ngày thi môn 3" HeaderStyle-Width="110px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythi3" runat="server" Width="110px" CssClass="css_Gma_c" kieu_luu="S" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Người PV 3" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="nguoi_pv3" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Điểm đánh giá 3" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="diemdat3" runat="server" CssClass="css_Gma" kieu_so="true" kt_xoa="X" Width="150px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Kết quả thi môn 3" HeaderStyle-Width="160px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ketqua3" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="160px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Kết quả chung" HeaderStyle-Width="160px">
                                                                    <ItemTemplate>
                                                                        <%--<Cthuvien:DR_list ID="ketqua_chung" runat="server" Width="160px" lke=",Đạt,Không đạt" tra="0,1,2" ten="kết quả chung" kt_xoa="X" CssClass="css_Glist" />--%>
                                                                        <Cthuvien:DR_nhap ID="ketqua_chung" ten="Xác nhận" runat="server" DataTextField="ten" DataValueField="ma"
                                                                            CssClass="css_Glist" kieu="S" Height="25px" Width="160px">
                                                                            <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Không đạt" Value="2"></asp:ListItem>
                                                                        </Cthuvien:DR_nhap>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="GĐ nhân sự PD" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="gd_nhansu_pd" runat="server" Width="200px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TGĐ phê duyệt" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="tgd_pd" runat="server" Width="200px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <div style="height: 450px; width: 820px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GridX1" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="so_the,ten,ngaysinh"
                                                            cotAn="so_id" hangKt="6">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />

                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" Width="70px" Text="Nhập" OnClick="return ns_td_kq_td_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_kq_td_P_MOI();form_P_LOI();" Width="70px" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" Width="70px" Text="Xóa" OnClick="return ns_td_kq_td_P_XOA();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="mail" runat="server" CssClass="css_button" Font-Bold="True" Width="100px" Text="Gửi mail" OnClick="return sendMail();form_P_LOI();" />
                                                    </div>
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_td_kq_td_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_td_kq_td_HangXuong();" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_click" />
                                                </td>
                                                <td align="center" style="height: 40px;">                                        
                                        <Cthuvien:nhap ID="excel2" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_td_kq_td_P_IN();form_P_LOI();" />
                                    </td>
                                                <%-- <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_td_kq_td_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_td_kq_td_ChenDong('C');" />
                                                </td>--%>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
    </div>
</asp:Content>
