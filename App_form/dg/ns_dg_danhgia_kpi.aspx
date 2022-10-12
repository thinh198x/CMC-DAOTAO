<%@ Page Title="ns_dg_danhgia_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_danhgia_kpi.aspx.cs" Inherits="f_ns_dg_danhgia_kpi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá KPI cán bộ " />
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
                                            CssClass="table gridX" loai="X" hangKt="15" cot="so_id,ngay" cotAn="so_id" hamRow="ns_dg_danhgia_kpi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày đánh giá" DataField="ngay" HeaderStyle-Width="201px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="ns_dg_danhgia_kpi_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Chu kỳ đánh giá" Width="120px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ngay1" runat="server" Width="115px" CssClass="css_form" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:kieu ID="lke" runat="server" lke="Ng,Tu,Th,Q,N" Width="30px" ToolTip="Ng - Ngày,Tu - Tuần,Th - Tháng,Q - Quý ,N - Năm" CssClass="css_form_c" Text="Ng" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Mã cán bộ" Width="100px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="K" CssClass="css_form" ten="Mã sản phẩm"
                                                                    ToolTip="Mã sản phẩm" kieu_chu="true" Width="115px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                                    ktra="ns_ma_cdanh,ma,ten" onchange="ns_dg_giao_kpi_P_KTRA('MACDANH')" BackColor="#f6f7f7"
                                                                    placeholder="Nhấn F1" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text="Ngày giao" Width="100px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayqd" runat="server" Width="115px" CssClass="css_form" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Text="Ngày đánh giá" Width="100px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay2" runat="server" Width="115px" CssClass="css_form" />
                                                                    </div>
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
                                        <div style="height: 570px; width: 1000px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="210px" Text="Công việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="210px" Text="Kế hoạch được giao" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Width="110px" Text="Trọng số (%)" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label25" runat="server" Width="110px" Text="Thời gian cần hoàn thành" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Width="110px" Text="Công cụ đo lường" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="5" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Text="Định nghĩa/tiêu chí chấm điểm (Thang điểm 1-5)" ToolTip="Với 5 là cao nhất và đưa ra định nghĩa cho từng thang điểm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Text="Chi tiết mức độ hoàn thành công việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="1" align="center">
                                                                    <asp:Label ID="Label13" runat="server" Width="110px" Text="Kết quả thực hiện" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Text="Lãnh đạo phòng đánh giá kết quả thực hiện" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Text="Giám đốc đánh giá kết quả thực hiện" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="100px" Text="5" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="100px" Text="4" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="100px" Text="3" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="100px" Text="2" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="100px" Text="1" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="110px" Text="Kết quả/chất lượng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="110px" Text="Thời gian/số lượng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="110px" Text="Cá nhân tự đánh giá kết quả (thang điểm 1-5)" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="110px" Text="Điểm đánh giá" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="110px" Text="Điểm quy đổi" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label11" runat="server" Width="110px" Text="Điểm đánh giá" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="110px" Text="Điểm quy đổi" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="SO_THE,TEN,LUONG_TG,LUONG_SP,LUONG_KHOAN,ANCA,PCAP,TNHAP_CHIUTHUE,TNHAP_KCHIUTHUE,BHXH,BHYT,BHTN,PCD,KTRU_CHIUTHUE,KTRU_KCHIUTHUE,TRUTHUE,TAM_UNG"
                                                            hangKt="100" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:TemplateField HeaderStyle-Width="208px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="SO_THE" runat="server" Width="208px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="208px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TEN" runat="server" Width="208px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="LUONG_TG" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="LUONG_SP" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="LUONG_KHOAN" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="98px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ANCA" runat="server" Width="98px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="98px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="PCAP" runat="server" Width="98px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="98px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TNHAP_CHIUTHUE" runat="server" Width="98px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="98px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TNHAP_KCHIUTHUE" runat="server" Width="98px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="98px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="BHXH" runat="server" Width="98px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="BHYT" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="BHTN" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="PCD" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="KTRU_CHIUTHUE" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="KTRU_KCHIUTHUE" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TRUTHUE" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TAM_UNG" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label28" runat="server" Text="Tổng điểm đánh giá: 0" CssClass="css_gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dg_danhgia_kpi_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dg_danhgia_kpi_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dg_danhgia_kpi_P_KD_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_danhgia_kpi_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_danhgia_kpi_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_danhgia_kpi_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_dg_danhgia_kpi_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <%-- <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_dg_danhgia_kpi_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1320,955" />
    </div>
</asp:Content>
