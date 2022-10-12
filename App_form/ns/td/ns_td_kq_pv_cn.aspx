<%@ Page Title="ns_td_kq_pv_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_kq_pv_cn.aspx.cs" Inherits="f_ns_td_kq_pv_cn" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quản lý kết quả phỏng vấn" />
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
                                    <td id="UPa_tk">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Năm" Width="90px" CssClass="css_gchu" /></td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="nam_tk" runat="server" ten="Năm" kt_xoa="G" CssClass="css_form_r" kieu_so="true"
                                                                    Width="140px" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Mã tuyển dụng" Width="90px" CssClass="css_gchu" /></td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="yeucau_tk" placeholder="Nhấn (F1)" runat="server" Width="140px" CssClass="css_form"
                                                                    BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/td/ns_td_dexuat.aspx"
                                                                    kt_xoa="X" ktra="ns_td_dexuat,ma,ma" ToolTip="Mã yêu cầu tuyển dụng" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label2" runat="server" Width="70px" Text="Vị trí TD" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="cdanh_tk" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="True" f_tkhao="~/App_form/ns/hdns/tl/ns_ma_cdanh.aspx"
                                                                    kt_xoa="X" ktra="ns_ma_cdanh,ma,ten" ToolTip="Vị trí TD" Width="120px" ten="Vị trí TD" placeholder="Nhấn (F1)" />
                                                            </td>
                                                            <td>
                                                                <div><a href="#" onclick="return ns_td_kq_pv_cn_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 600px; width: 600px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id,nam,thang,gioitinh,ngaysinh" hamRow="ns_td_kq_pv_cn_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                                    <asp:BoundField HeaderText="Mã yêu cầu" DataField="ma_yc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Tên ứng viên" DataField="ten" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Giới tính" DataField="ten_gtinh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Vị trí tuyển dụng" DataField="cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Bộ phận tuyển dụng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Năm" DataField="nam" />
                                                    <asp:BoundField HeaderText="Tháng" DataField="thang" />
                                                    <asp:BoundField HeaderText="Giới tính" DataField="gioitinh" />
                                                    <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" />
                                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                            ham="ns_td_kq_pv_cn_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td colspan="2">
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                                    <Cthuvien:bbuoc ID="Bbuoc6" runat="server" CssClass="css_gchu" Width="100px" Text="Mã đề xuất" Tolltip="Mã  đề xuất" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA_YC" runat="server" ten="Mã" kt_xoa="G" CssClass="css_form" Enabled="false" ReadOnly="false"
                                                                    Width="155px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Width="100px" Text="Năm" Tolltip="Năm" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" ten="Năm" Enabled="false" ReadOnly="false" kt_xoa="G" CssClass="css_form_r"
                                                                    Width="155px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc4" Width="120px" runat="server" CssClass="css_gchu_c" Text="Tháng" Tolltip="Tháng" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="THANG" kieu_so="true" runat="server" ten="Tháng" kt_xoa="G" Enabled="false" ReadOnly="false" CssClass="css_form_r"
                                                                    Width="155px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label12" runat="server" Text="Bộ phận yêu cầu" CssClass=" css_gchu_a" Width="100px"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="PHONG" runat="server" CssClass="css_form" kieu_chu="true" Enabled="false" ReadOnly="false"
                                                                    kt_xoa="X" gchu="gchu" Width="155px" ten="Phòng ban" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label5" runat="server" Text="Vị trí tuyển dụng" CssClass="css_gchu_c" Width="120px"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="CDANH" runat="server" Width="155px" CssClass="css_form" Enabled="false" ReadOnly="false" ten="Vị trí tuyển dụng" kt_xoa="X" ToolTip="Chức danh" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Mã ứng viên" CssClass="css_gchu_a" Width="100px"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="SO_THE" ten="Mã ứng viên" Enabled="false" ReadOnly="false" runat="server" CssClass="css_form" ToolTip="Mã ứng viên" Width="155px" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc3" runat="server" Text="Họ tên" CssClass="css_gchu_c" Width="120px"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="TEN" ten="Họ tên" runat="server" CssClass="css_form" ToolTip="Họ tên" Width="155px" kt_xoa="X" Enabled="false" ReadOnly="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label19" runat="server" Text="Giới tính" CssClass=" css_gchu" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ten_gtinh" ten="Giới tính" runat="server" CssClass="css_form" ToolTip="Giới tính" Width="155px" kt_xoa="X" Enabled="false" ReadOnly="false" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Ngày sinh" CssClass=" css_gchu_c" Width="120px"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaysinh" ten="Ngày sinh" runat="server"
                                                                        CssClass="css_form_c" Width="130px" kt_xoa="G" Enabled="false" ReadOnly="false" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <div style="width: 550px; overflow-x: scroll">
                                                        <Cthuvien:GridX ID="Gr_mt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="tieuchi,ghinhan_dactrung,tytrong,diem_dg,tongdiem" hangKt="6">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Tiêu chí" DataField="tieuchi" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:TemplateField HeaderText="Nhận xét những nét đặc trưng" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ghinhan_dactrung" runat="server" kieu_unicode="true" CssClass="css_Gma" kt_xoa="X" Width="130px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tỷ trọng (%)" HeaderStyle-Width="115px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="tytrong" runat="server" kieu_so="true" CssClass="css_Gma" kt_xoa="G" Width="115px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Điểm đánh giá" HeaderStyle-Width="115px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="diem_dg" runat="server" kieu_so="true" CssClass="css_Gma" kt_xoa="G" Width="115px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tổng điểm" HeaderStyle-Width="115px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="tongdiem" runat="server" kieu_so="true" CssClass="css_Gma" kt_xoa="G" Width="115px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Text="Nhận xét chung" CssClass=" css_gchu" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="nhanxet_chung" ten="Nhận xét chung" runat="server" kt_xoa="X" Height="40px"
                                                        CssClass="css_form" Width="443px" kieu_unicode="true" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Width="100px">Kết luận</asp:Label>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:kieu ID="dong_y" runat="server" lke=",X" Width="30px" ToolTip="X - Đồng ý" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" CssClass="css_gchu_c">Đồng ý tiếp nhận</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:kieu ID="xemxet" runat="server" lke=",X" Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c">Cần xem xét thêm</asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:kieu ID="khong_dongy" runat="server" lke=",X" Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c" Text="" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" CssClass="css_gchu_c">Không đồng ý</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label18" runat="server" Text="Lý do" CssClass=" css_gchu" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="lydo" ten="Lý do" runat="server" kt_xoa="X" Height="40px"
                                                        CssClass="css_form" Width="443px" kieu_unicode="true" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label20" runat="server" Text="Đề xuất loại HĐ" CssClass=" css_gchu" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="lhd_bandau" ten="Đề xuất loại HĐ" runat="server" CssClass="css_form" ToolTip="đề xuất loại hợp đồng ban đầu" Width="155px" kt_xoa="X" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text="ĐX TG thử việc" CssClass=" css_gchu_c" Width="120px"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="tg_thuviec" ten="ĐX TG thử việc" runat="server" CssClass="css_form" ToolTip="đề xuất thời gian thử việc" Width="155px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc7" runat="server" Text="Mức lương CT" CssClass="css_gchu_a" Width="100px"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:so ID="mucluong_ct" so_tp="3" ten="mức lương ct" kieu_so="true" runat="server" CssClass="css_form_r" ToolTip="Mức lương chính thức" Width="155px" kt_xoa="G" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Mức lương TV" CssClass="css_gchu_c" Width="120px"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="mucluong_tv" so_tp="3" ten="Mức lương thử việc" kieu_so="true" runat="server" CssClass="css_form_r" ToolTip="Mức lương đến" Width="155px" kt_xoa="G" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" Text="Ngày DK đi làm" CssClass=" css_gchu" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaydl_dk" ten="Ngày DK đi làm" runat="server"
                                                                        CssClass="css_form_c" Width="130px" kt_xoa="G" />
                                                                </div>
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:Label ID="Label16" runat="server" Text="Trạng thái" CssClass=" css_gchu_c" Width="120px"></asp:Label>
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:ma ID="trangthai" ten="Trạng thái tuyển dụng" runat="server" CssClass="css_form" ReadOnly="false" Enabled="false" ToolTip="Trạng thái tuyển dụng" Width="155px" kt_xoa="G" />
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
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_td_kq_pv_cn_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_kq_pv_cn_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,830" />
    </div>
</asp:Content>

