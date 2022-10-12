<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_khns_qlg_ls.aspx.cs" Inherits="f_ns_hdns_khns_qlg_ls"
    Title="ns_hdns_khns_qlg_ls" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Lịch sử thay đổi kế hoạch quỹ lương" />
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
                        <td class="form_right" colspan="2">
                            <table runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" cellpadding="1" cellspacing="1">                                           
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Năm" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="NAM" kt_xoa="G" ten="Năm" ktra="KHNS_QLG_NAM_LS" runat="server" Width="150px" onchange="ns_hdns_khns_qlg_ls_P_KTRA('NAM');" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Đơn vị" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="PHONG" kt_xoa="G" ten="Năm" ktra="KHNS_QLG_PHONG_LS" runat="server" Width="150px" onchange="ns_hdns_khns_qlg_ls_P_KTRA('PHONG');" />
                                                </td>                                            
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Từ tháng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">                                                        
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang_d" runat="server" ten="Từ tháng" Width="122px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X" ReadOnly="true" Enabled="false"/>
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Đến tháng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">                                                        
                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="thang_c" runat="server" ten="Đến tháng" Width="122px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X" ReadOnly="true" Enabled="false"/>
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
                                            <div class="css_divCn" style="width:1280px; overflow-x:auto;">
                                                <table id="tblHeader" cellspacing="0" cellpadding="0" class="tbl_ll" style="z-index:100000;">
                                                    <tr>
                                                        <td id="td1" rowspan="2" valign="middle" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label2" runat="server" Width="20px" />
                                                        </td>
                                                        <td id="td31" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="STT" Font-Bold="true" Width="38px" />
                                                        </td>
                                                        <td id="td41" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label5" runat="server" Width="87px" Text="Mã nhân viên"  Font-Bold="true" />
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
                                                        <td id="td64" rowspan="2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                            <asp:Label ID="Label14" runat="server" Width="88px" Text="Lần thay đổi"  Font-Bold="true" />
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
                                                    CssClass="table gridX" loai="X" cot="sott,so_the,ten,ten_cdanh,ten_plnv,tinhtrang,thu_nhap,luong_cb,thuong,thu_nhap_kh,luong_cb_kh,thuong_kh,ngay_d_nam,ngay_td,ngay_c_nam,thang_lv_dk,thang_tn,thang_tn_td,tyle_lc,tyle_tnx,tyle_dl,tyle_pt,phucap1,phucap2,phucap3,kh_bh,phi_cd,tongquy_tnt,tong_pc,tong_thuong_nx,tong_chi_pl,tong_tn_dk,lan" 
                                                    hangKt="12" gchuId="gchu" ctrT="so_tt" >
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField DataField="sott" HeaderStyle-Width="31px" />
                                                        <asp:BoundField DataField="so_the" HeaderStyle-Width="79px" />
                                                        <asp:BoundField DataField="ten" HeaderStyle-Width="120px" />                                                           
                                                        <asp:BoundField DataField="ten_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma"/>
                                                        <asp:BoundField DataField="ten_plnv" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma"/>
                                                        <asp:BoundField DataField="tinhtrang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c"/>
                                                        <asp:BoundField DataField="thu_nhap" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="luong_cb" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="thuong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>                                                        
                                                        <asp:BoundField DataField="thu_nhap_kh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="luong_cb_kh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="thuong_kh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="ngay_d_nam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c"/>                                                       
                                                        <asp:BoundField DataField="ngay_td" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c"/>
                                                        <asp:BoundField DataField="ngay_c_nam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c"/>                                                        
                                                        <asp:BoundField DataField="thang_lv_dk" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="thang_tn" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>                                                        
                                                        <asp:BoundField DataField="thang_tn_td" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tyle_lc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>                                                       
                                                        <asp:BoundField DataField="tyle_tnx" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tyle_dl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>                                                        
                                                        <asp:BoundField DataField="tyle_pt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="phucap1" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="phucap2" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="phucap3" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="kh_bh" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="phi_cd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>                                                       
                                                        <asp:BoundField DataField="tongquy_tnt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tong_pc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tong_thuong_nx" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tong_chi_pl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="tong_tn_dk" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso"/>
                                                        <asp:BoundField DataField="lan" HeaderStyle-Width="80px"/>
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <khud:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
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
        <Cthuvien:an ID="phong_an" runat="server" />
        <Cthuvien:an ID="ngay_an" runat="server" />        
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,650" />
    </div>
</asp:Content>
