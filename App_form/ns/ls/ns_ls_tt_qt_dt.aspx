<%@ Page Title="ns_ls_tt_qt_dt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ls_tt_qt_dt.aspx.cs" Inherits="f_ns_ls_tt_qt_dt" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quá trình đào tạo" />
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
                            <table>
                                <tr>
                                    <td>
                                        <div>   
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id,lop,nd,ldt,tt,dd_tc,diem,ghichu" hamRow="ns_ls_tt_qt_dt_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Tên khóa học" DataField="ten_kdt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngay_d" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngay_c" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Trạng thái lớp học" DataField="tt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Tên đơn vị tổ chức" DataField="dvi_tc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />                                                
                                                    <asp:BoundField HeaderText="Kết quả thi" DataField="kq" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Chi phí" DataField="tien" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_r" />
                                                    <asp:BoundField  DataField="lop" />
                                                    <asp:BoundField  DataField="nd" />
                                                    <asp:BoundField  DataField="ldt" />
                                                    <asp:BoundField  DataField="tt" />
                                                    <asp:BoundField  DataField="dd_tc" />
                                                    <asp:BoundField  DataField="diem" />
                                                    <asp:BoundField  DataField="ghichu" />                                                
                                                    <asp:BoundField  DataField="so_id" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                          </div>       
                                          <div>          
                                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ls_tt_qt_dt_P_LKE()" />
                                          </div>  
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" onclick="ns_ls_tt_qt_dt_P_Excel();return false;" />
                                        <Cthuvien:nhap ID="excel_an" runat="server" Text="Xuất excel ẩn" OnServerClick="excel_Click" style="display:none;" />
                                    </td>
                                </tr>
                            </table>                                 
                        </td>
                        <td align="left" class="form_right" valign="top">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                         ReadOnly="true" Enabled="false" Width="165px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Tên cán bộ" CssClass=" css_gchu_c" Width="80px"></asp:Label></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="css_form" ToolTip="Họ tên cán bộ" kieu_unicode="true" Width="165px" ReadOnly="true" Enabled="false" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                   <td colspan="2"><hr /></td>
                               </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label13" runat="server" Text="Tên khóa đào tạo" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                <td>
                                                    <Cthuvien:ma ID="TEN_KDT" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" kt_xoa="X" Width="165px" kieu_unicode="true" MaxLength="100" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Lớp học" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lop" ten="Lớp học" runat="server" CssClass="css_form" kt_xoa="X" kieu_unicode="true" 
                                                        Width="165px"  gchu="gchu" MaxLength="255" />
                                                </td>
                                           </tr>
                                        </table>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Nội dung đào tạo" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nd ID="nd" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                            Width="422px" MaxLength="1000"></Cthuvien:nd>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label6" runat="server" Text="Ngày bắt đầu" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" Width="140px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" ten="Ngày bắt đầu" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Ngày kết thúc" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_c" runat="server" Width="138px" CssClass="css_form_c" kt_xoa="X" ten="Ngày kết thúc" kieu_luu="S" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Loại đào tạo" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:kieu ID="ldt" runat="server" kt_xoa="K" lke="X," tra="X," Width="30px" ToolTip="X - Đào tạo trong công ty" CssClass="css_form_c" MaxLength="1" ReadOnly="true" Enabled="false" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Trạng thái lớp học" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_list ID="tt" runat="server" Width="165px" lke="Hoàn thành,Đang thi,Đã thi,Chưa hoàn thành" tra="H,T,D,C" ten="Trạng thái lớp học" CssClass="css_list" ToolTip="Trạng thái lớp học" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Đơn vị tổ chức" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="dvi_tc" runat="server" Width="165px" CssClass="css_form" kt_xoa="X" ten="Đơn vị tổ chức" kieu_unicode="true" MaxLength="100" />                                                    
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lb" runat="server" Text="Địa điểm tổ chức" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="dd_tc" ten="Địa điểm tổ chức" runat="server" CssClass="css_form" kieu_unicode="true" 
                                                        kieu_chu="true" Width="165px" gchu="gchu" ToolTip="Địa chỉ tổ chức" kt_xoa="X" MaxLength="255" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Điểm thi" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="diem" runat="server" Width="165px" CssClass="css_form_c" kt_xoa="X" ten="Điểm thi" co_dau="K" MaxLength="20" />                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Kết quả thi" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_list ID="kq" kieu="U" lke="Đạt,Không đạt" tra="D,K" runat="server" Width="165px"></Cthuvien:DR_list>                                                   
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Chi phí" Width="80px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="tien" runat="server" Width="165px" CssClass="css_form_r" kt_xoa="X" ten="Số tiền" co_dau="K" />   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Mô tả" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                            Width="422px" MaxLength="1000"></Cthuvien:nd>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick=" ns_ls_tt_qt_dt_P_MOI();form_P_LOI('');" Title="Ấn nút để nhập mới" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick=" ns_ls_tt_qt_dt_P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />                                                   
                                                </td>     
                                                <td>
                                                    <Cthuvien:nhap ID="mau_excel" runat="server" Text="File mẫu" OnServerClick="excel_mau_Click"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="import_excel" runat="server" Text="Import" OnClick="return ns_ls_tt_qt_dt_FILE_Import();form_P_LOI();" />
                                                </td>                                           
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick=" ns_ls_tt_qt_dt_P_XOA();form_P_LOI('');" Title="Ấn nút để xóa" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" Width="70px" OnClick=" nhap_file();form_P_LOI('');" Title="Ấn nút để tải file" />
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
    <Cthuvien:an ID="so_id" runat="server" Value="0" />
    <Cthuvien:an ID="so_the_an" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
</asp:Content>
