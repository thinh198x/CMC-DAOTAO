<%@ Page Title="ns_dt_danhgia_kdt" Language="C#" MasterPageFile="~/trangnen.master" CodeFile="ns_dt_danhgia_kdt.aspx.cs"
    AutoEventWireup="true" Inherits="f_ns_dt_danhgia_kdt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá khóa đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" CssClass="form-control css_list" runat="server" ktra="DT_NAM" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="timkiem" runat="server" Width="100px" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_dt_danhgia_kdt_P_LKE();form_P_LOI();" />

                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div  style="overflow-x: scroll;">
                             <div class="css_divb">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_danhgia_kdt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_GmaN_c" />
                                    <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="60px" ItemStyle-CssClass="css_GmaN_c" />
                                    <asp:BoundField HeaderText="Tên khóa học" DataField="KHOA_HOC" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Lớp đào tạo" DataField="lop_dt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        </div>
                       
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_dt_danhgia_kdt_P_LKE()" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server" disabled CssClass="form-control css_ma" kt_xoa="K" ToolTip="Năm" ten="Năm" onchange="ns_dt_danhgia_kdt_P_KTRA('NAM')" MaxLength="4" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="thang" kt_xoa="K" CssClass="form-control css_list" runat="server" disabled lke="Tháng 01,Tháng 02, Tháng 03,Tháng 04,Tháng 05,Tháng 06,Tháng 07,Tháng 08,Tháng 09,Tháng 10,Tháng 11,Tháng 12" tra="1,2,3,4,5,6,7,8,9,10,11,12" ten="Tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên khóa học</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KHOA_HOC" kt_xoa="K" CssClass="form-control css_list" runat="server" disabled ktra="DT_KDT" onchange="ns_dt_danhgia_kdt_P_KTRA('KHOA_DT')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lớp đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="LOP_DT" runat="server" disabled BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="K" ToolTip="Lớp đào tạo" ten="Lớp đào tạo" />
                            </div>
                            <div style="display: none;">
                                <Cthuvien:ma ID="ma_lop" runat="server" disabled BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="K" ToolTip="Lớp đào tạo" ten="Lớp đào tạo" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên đối tác</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="doi_tac" runat="server" disabled BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="K" ToolTip="Tên đối tác" ten="Tên đối tác" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Giảng viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="giang_vien" runat="server" disabled BackColor="#f6f7f7" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="K" ToolTip="Giảng viên" ten="Giảng viên" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày học</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' disabled ID="ngay_hoc" ten="Ngày cấp mã số thuế" runat="server" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <div style="display: none;">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' disabled ID="ngay_c" ten="Ngày kết thúc" runat="server" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Chấm điểm theo các tiêu chí đánh giá</span></div>
                    <div class="grid_table width_common">
                        <div style="height: 330px; width: 770px; overflow-x: auto">
                            <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                <tr>
                                    <td id="td1" rowspan="2" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label10" runat="server" Width="18px" />
                                    </td>
                                    <td id="td2" rowspan="2" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label11" Text="STT" runat="server" Width="37px" />
                                    </td>
                                    <td id="td3" rowspan="2" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label12" runat="server" Text="Nội dung chương trình" Width="357px" />
                                    </td>
                                    <td id="td4" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label13" runat="server" Text="Rất tốt" Width="60px" />
                                    </td>
                                    <td id="td5" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label14" runat="server" Text="Tốt" Width="50px" />
                                    </td>
                                    <td id="td6" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label15" runat="server" Text="Khá" Width="50px" />
                                    </td>
                                    <td id="td7" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label16" runat="server" Text="trung bình" Width="80px" />
                                    </td>
                                    <td id="td8" style="background-color: #9fc54e; font-weight: bold; height: 30px; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                        <asp:Label ID="Label17" runat="server" Text="Kém" Width="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td41" style="background-color: #9fc54e; font-weight: bold; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label21" runat="server" Text="5" Width="60px" />
                                    </td>
                                    <td id="td15" style="background-color: #9fc54e; font-weight: bold; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label22" runat="server" Text="4" Width="50px" />
                                    </td>
                                    <td id="td16" style="background-color: #9fc54e; font-weight: bold; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label23" runat="server" Text="3" Width="50px" />
                                    </td>
                                    <td id="td17" style="background-color: #9fc54e; font-weight: bold; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label24" runat="server" Text="2" Width="80px" />
                                    </td>
                                    <td id="td18" style="background-color: #9fc54e; font-weight: bold; height: 25px; border-right: gray 1px solid;" align="center">
                                        <asp:Label ID="Label25" runat="server" Text="1" Width="50px" />
                                    </td>
                                </tr>
                            </table>
                            <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" hamUp="ns_dt_danhgia_kdt_tinh" Width="95%"
                                AutoGenerateColumns="false" hangKt="16" cot="sott,noidung,rtot,tot,kha,trungbinh,kem,stt" cotAn="stt" PageSize="1" CssClass="table gridX">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="sott" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="26px" />
                                    <asp:BoundField DataField="noidung" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="298px" />
                                    <asp:TemplateField HeaderStyle-Width="45px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="rtot" runat="server" Width="45px" lke="X," kt_xoa="X" ToolTip="X - Rất tốt,  - " CssClass="css_Gma_c" Text="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="35px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="tot" runat="server" Width="35px" lke="X," kt_xoa="X" ToolTip="X - Tốt,  - " CssClass="css_Gma_c" Text="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="35px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="kha" runat="server" Width="35px" lke="X," kt_xoa="X" ToolTip="X - khá,  - " CssClass="css_Gma_c" Text="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="trungbinh" runat="server" Width="60px" lke="X," kt_xoa="X" ToolTip="X - Trung bình,  - " CssClass="css_Gma_c" Text="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="45px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="kem" runat="server" Width="45px" lke="X," kt_xoa="X" ToolTip="X - kém,  - " CssClass="css_Gma_c" Text="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="stt" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="b_left mgt10 width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Điều làm anh chị hài lòng tâm đắc nhất trong khóa đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="hailong" TextMode="MultiLine" kieu_unicode="true" runat="server" Height="30px" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Tên đối tác" ten="Tên đối tác" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Điều làm anh chị không hài lòng</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="khailong" TextMode="MultiLine" kieu_unicode="true" runat="server" Height="30px" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Tên đối tác" ten="Tên đối tác" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Kỳ vọng</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="kyvong" TextMode="MultiLine" kieu_unicode="true" runat="server" Height="30px" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Tên đối tác" ten="Tên đối tác" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Đạt được</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="dat_duoc" TextMode="MultiLine" kieu_unicode="true" runat="server" Height="30px" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Tên đối tác" ten="Tên đối tác" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_danhgia_kdt_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_danhgia_kdt_P_NH();form_P_LOI();" Width="70px" />

                        <div style="display: none">
                            <Cthuvien:nhap ID="excel" runat="server" Width="100px" Text="Gửi" OnClick="return ns_dt_danhgia_kdt_P_GUI();form_P_LOI();" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dt_danhgia_kdt_P_XOA();form_P_LOI();" Width="70px" />
                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,830" />
    </div>
</asp:Content>
