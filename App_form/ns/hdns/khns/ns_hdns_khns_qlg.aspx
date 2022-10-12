<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_khns_qlg.aspx.cs" Inherits="f_ns_hdns_khns_qlg"
    Title="ns_hdns_khns_qlg" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch quỹ lương" />
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
                            <table cellpadding="1" cellspacing="1" id="UPa_tk" width="100%">
                                <tr>
                                    <td width="40px">
                                        <asp:Label ID="Label16" runat="server" Text="Năm" CssClass="css_gchu" />
                                    </td>
                                    <td width="80px">
                                        <Cthuvien:DR_lke ID="nam_lke" ktra="KHNS_QLG_NAM" runat="server" Width="60px"></Cthuvien:DR_lke> 
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="tim" runat="server" Width="80px" Text="Tìm" OnClick="return ns_hdns_khns_qlg_P_LKE();" />  
                                    </td>                                              
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <div>
                                            <div>
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                                    CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,phong,thang_d,thang_c" hamRow="ns_hdns_khns_qlg_GR_lke_RowChange()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField DataField="nam" HeaderText="Năm" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                                        <asp:BoundField DataField="ten_phong" HeaderText="Đơn vị" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                        <asp:BoundField DataField="tong_cdanh" HeaderText="Chức danh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                        <asp:BoundField DataField="tong_tn_dkien" HeaderText="Tổng thu nhập dự kiến" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" /> 
                                                        <asp:BoundField DataField="so_id" />   
                                                        <asp:BoundField DataField="phong" />    
                                                        <asp:BoundField DataField="thang_d" />  
                                                        <asp:BoundField DataField="thang_c" />                              
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>                                
                                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_khns_qlg_P_LKE()" />
                                        </div>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="6" Width="100px" OnClick="return ns_hdns_khns_qlg_P_EXCEL();form_P_LOI();" />
                                        <div style="display: none">                                            
                                            <Cthuvien:nhap ID="excel_an" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />                                                            
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>

                        <td class="form_right">
                            <table runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" cellpadding="1" cellspacing="1">                                           
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Năm" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="NAM" kt_xoa="G" ten="Năm" ktra="KHNS_QLG_NAM" runat="server" Width="150px" onchange="ns_hdns_khns_qlg_P_KTRA('NAM');" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Đơn vị" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="PHONG" kt_xoa="G" ten="Năm" ktra="KHNS_QLG_PHONG" runat="server" Width="150px" onchange="ns_hdns_khns_qlg_P_KTRA('PHONG');" />
                                                    <Cthuvien:ma ID="so_id" runat="server" style="display:none;" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Từ tháng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">                                                        
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang_d" runat="server" ten="Từ tháng" Width="122px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X"/>
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Đến tháng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">                                                        
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang_c" runat="server" ten="Đến tháng" Width="122px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X"/>
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>                                           
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" id="UPa_lk" style="padding-right:20px;">
                                        <div class="css_divb">
                                            <div class="css_divCn" style="width:860px; overflow-x:auto;">
                                                <table id="tblHeader" cellspacing="0" cellpadding="0" class="tbl_ll" style="z-index:100000;">
                                                    <tr>
                                                        <td id="td1" rowspan="2" valign="middle" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label2" runat="server" Width="20px" />
                                                        </td>
                                                        <td id="td31" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="STT" Font-Bold="true" Width="37px" />
                                                        </td>
                                                        <td id="td41" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label5" runat="server" Width="88px" Text="Mã nhân viên"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td51" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label7" runat="server" Width="128px" Text="Họ tên"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td551" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label58" runat="server" Width="108px" Text="Chức danh"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td121" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label3" runat="server" Width="108px" Text="Loại nhân viên"  Font-Bold="true" />
                                                        </td>

                                                        <td id="td131" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label8" runat="server" Width="88px" Text="Tình trạng"  Font-Bold="true" />
                                                        </td>

                                                        <td id="td611" colspan="3" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label64" runat="server" Width="324px" Text="Thu nhập theo tháng hiện tại"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td621" colspan="3" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label65" runat="server" Width="324px" Text="Thu nhập tháng kế hoạch"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td631" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label66" runat="server" Width="108px" Text="TG bắt đầu LV trong năm"  Font-Bold="true" />
                                                        </td>

                                                        <td id="td32" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label6" runat="server" Width="108px" Text="TG thay đổi TN tháng" Font-Bold="true" />
                                                        </td>
                                                        <td id="td42" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label20" runat="server" Width="108px" Text="TG kết thúc LV trong năm"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td52" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label33" runat="server" Width="108px" Text="Số tháng làm việc dự kiến"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td552" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label34" runat="server" Width="108px" Text="Số tháng thu nhập hiện tại"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td122" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label36" runat="server" Width="108px" Text="Số tháng thu nhập thay đổi"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td132" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label37" runat="server" Width="108px" Text="Tỷ lệ lương cứng"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td612" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label38" runat="server" Width="108px" Text="Tỷ lệ thưởng năng suất"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td622" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label39" runat="server" Width="108px" Text="Tỷ lệ độc lập"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td633" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label40" runat="server" Width="108px" Text="Tỷ lệ phụ thuộc"  Font-Bold="true" />
                                                        </td>

                                                        <td id="td3" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label41" runat="server" Width="108px" Text="Kế hoạch phụ cấp 1" Font-Bold="true" />
                                                        </td>
                                                        <td id="td4" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label42" runat="server" Width="108px" Text="Phụ cấp 2"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td5" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label43" runat="server" Width="108px" Text="Phụ cấp 3"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td55" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label44" runat="server" Width="138px" Text="Kế hoạch BHXH\BHYT\BHTN"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td123" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label45" runat="server" Width="108px" Text="Kinh phí công đoàn"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td12" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label13" runat="server" Width="108px" Text="Tổng quỹ thu nhập tháng"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td13" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label46" runat="server" Width="108px" Text="Tổng phụ cấp"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td61" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label47" runat="server" Width="108px" Text="Tổng quỹ thưởng năng suất"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td62" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label48" runat="server" Width="108px" Text="Tổng chi phúc lợi"  Font-Bold="true" />
                                                        </td>
                                                        <td id="td63" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label49" runat="server" Width="108px" Text="Tổng thu nhập dự kiến"  Font-Bold="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label111" runat="server" Width="108px" Text="Thu nhập tháng"  Font-Bold="true"/>
                                                        </td>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label9" runat="server" Width="108px" Text="Lương cơ bản"  Font-Bold="true"/>
                                                        </td>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label10" runat="server" Width="108px" Text="Thưởng đánh giá tháng" Font-Bold="true" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label1" runat="server" Width="108px" Text="Thu nhập tháng" Font-Bold="true" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label11" runat="server" Width="108px" Text="Lương cơ bản" Font-Bold="true" />
                                                        </td>
                                                        <td style="background-color: #9fc54e; height: 30px; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label12" runat="server" Width="108px" Text="Thưởng đánh giá tháng" Font-Bold="true" />
                                                        </td>
                                                    </tr>
                                                </table>

                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" HeaderStyle-Height="1px"
                                                    CssClass="table gridX" loai="N" cot="sott,so_the,ten,ten_cdanh,ten_plnv,tinhtrang,thu_nhap,luong_cb,thuong,thu_nhap_kh,luong_cb_kh,thuong_kh,ngay_d_nam,ngay_td,ngay_c_nam,thang_lv_dk,thang_tn,thang_tn_td,tyle_lc,tyle_tnx,tyle_dl,tyle_pt,phucap1,phucap2,phucap3,kh_bh,phi_cd,tongquy_tnt,tong_pc,tong_thuong_nx,tong_chi_pl,tong_tn_dk,so_id,cdanh,loai_nv" 
                                                    cotAn="so_id,cdanh,loai_nv" hangKt="10" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="ns_hdns_khns_qlg_GR_ct_Update">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField DataField="sott" HeaderStyle-Width="30px" />
                                                        <asp:BoundField DataField="so_the" HeaderStyle-Width="80px" />
                                                        <asp:BoundField DataField="ten" HeaderStyle-Width="120px" />                                                        
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" kt_xoa="X" Width="97%" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi.aspx" guiId="phong_an,ngay_an" CssClass="css_Gma" ToolTip="Ấn F1 để chọn chức danh" BackColor="#f6f7f7" ReadOnly="true"></Cthuvien:ma>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_plnv" ten="Loại nhân viên" runat="server" kt_xoa="X" Width="97%" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_plnv.aspx" CssClass="css_Gma" ToolTip="Ấn F1 để chọn loại nhân viên" BackColor="#f6f7f7" ReadOnly="true" Enabled="false"></Cthuvien:ma>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:DR_list ID="tinhtrang" runat="server" Width="97%" lke="Đã có,Tuyển mới" tra="DC,TM" ten="Loại nhân viên"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thu_nhap" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="luong_cb" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thuong" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thu_nhap_kh" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="luong_cb_kh" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thuong_kh" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_d_nam" runat="server" Width="97%" CssClass="css_Gma_c" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_td" runat="server" Width="97%" CssClass="css_Gma_c" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_c_nam" runat="server" Width="97%" CssClass="css_Gma_c" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thang_lv_dk" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thang_tn" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thang_tn_td" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tyle_lc" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tyle_tnx" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tyle_dl" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tyle_pt" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="phucap1" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="phucap2" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="phucap3" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="130px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="kh_bh" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="phi_cd" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tongquy_tnt" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tong_pc" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tong_thuong_nx" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tong_chi_pl" MaxLength="20" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tong_tn_dk" runat="server" Width="97%" CssClass="css_Gso" so_tp="2" co_dau="K" ReadOnly="true" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="so_id"/>
                                                        <asp:BoundField DataField="cdanh" />
                                                        <asp:BoundField DataField="loai_nv" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <khud:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                        </div>    
                                    </td>
                                </tr>                               
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_hdns_khns_qlg_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_khns_qlg_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="mau_excel" runat="server" Text="File mẫu" OnServerClick="excel_mau_Click"/>
                                                            </td>
                                                            <td>
                                                               <Cthuvien:nhap ID="import_excel" runat="server" Text="Import" OnClick="return ns_hdns_khns_qlg_FILE_Import();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                               <Cthuvien:nhap ID="lichsu" runat="server" Text="Xem lịch sử" OnClick="return ns_hdns_khns_qlg_P_LSU();form_P_LOI();" />
                                                            </td>                                                            
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="phong_an" runat="server" />
        <Cthuvien:an ID="ngay_an" runat="server" />        
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,730" />
    </div>
</asp:Content>

