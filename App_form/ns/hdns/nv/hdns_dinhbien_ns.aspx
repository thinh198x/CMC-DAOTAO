<%@ Page Title="hdns_dinhbien_ns" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_dinhbien_ns.aspx.cs" Inherits="f_hdns_dinhbien_ns" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Định biên nhân sự" />
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
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="X" hangKt="16" cotAn="ma,ma_ct,nsd" hamRow="hdns_dinhbien_ns_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="xep" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên bộ phận" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="ma" />
                                                <asp:BoundField DataField="ma_ct" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="hdns_dinhbien_ns_P_LKE()" />
                                    </td>
                                </tr>                               
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text="Năm" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <Cthuvien:DR_list ID="nam" Enabled="true" runat="server" Width="124px" ten="Năm tài chính của đơn vị" ReadOnly="true" onchange="hdns_dinhbien_ns_P_KD_P_KTRA('NGAY_QD')" />
                                                        <%--<Cthuvien:DR_nhap ID="nam" runat="server" kieu="U" CssClass="css_form" Width="120px" 
                                                                        DataTextField="ten" DataValueField="ma" ten="Năm tài chính của đơn vị" onchange="hdns_dinhbien_ns_P_KD_P_KTRA('NGAY_QD')" />--%>
                                                        <%--<Cthuvien:ma ID="NAM" runat="server" CssClass="css_form_r" kieu_so="true" kt_xoa="G" Width="120px" ten="Năm" ToolTip="Năm" />--%>
                                                        <Cthuvien:an ID="hincd" runat="server" Value="" />
                                                        <Cthuvien:an ID="hincd2" runat="server" Value="" />
                                                    </td>
                                                </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Bbuoc1" runat="server" Text="Đơn vị" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <Cthuvien:ma ID="donvi" ten="Đơn vị của tập đoàn" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ht_ma_phong,ma,ten" placeholder="Nhấn (F1)"   
                                                                kt_xoa="K" f_tkhao="~/App_form/ht/ht_maph.aspx" MaxLength="30" kieu_chu="true" Width="130px"  gchu="gchu" onchange="hdns_dinhbien_ns_P_KD_P_KTRA('DONVI')"   />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Bbuoc2" runat="server" Text="Chức danh" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <Cthuvien:ma ID="chucdanh" ten="Chức danh" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="hd_cdanh_dvi,ma,ten" placeholder="Nhấn (F1)" 
                                                                kt_xoa="K" f_tkhao="~/App_form/ns/hdns/tl/hd_cdanh_dvi.aspx" MaxLength="30" kieu_chu="true" Width="130px" gchu="gchu" onchange="hdns_dinhbien_ns_P_KD_P_KTRA('chucdanh')"  guiId="DONVI"  />
                                                            
                                                        </td>
                                                    </tr>
                                                     <tr style="display:none">
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Đẩy" Width="80px" CssClass="css_gchu_c"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <Cthuvien:ma ID="day" ten="Đơn vị của tập đoàn" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ht_ma_phong,ma,ten" placeholder="Nhấn (F1)"
                                                                kt_xoa="K" f_tkhao="~/App_form/ht/ht_maph.aspx" MaxLength="30" kieu_chu="true" Width="120px" onchange="hdns_dinhbien_ns_P_KD_P_KTRA('DONVI')" gchu="gchu" />
                                                        </td>
                                                    </tr>
                                                    
                                                    </table>
                                                </td>
                                                <td style="width:300px">
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return hdns_dinhbien_ns_P_TIM();form_P_LOI();" class="bt bt-grey" Width="120px"><span class="txUnderline">T</span>ìm</a>
                                                    </div>
                                                </td>
                                            </tr>

                                                
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 400px; width: 900px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" CssClass="table gridX" hangKt="19" hamUp="hsns_dinhbien_ns_tinh" cotAn="ten_donvi,ten_cdanh" 
                                                cot="nam,phong,ncdanh,ns_hientai,db_t4,db_t5,db_t6,db_t7,db_t8,db_t9,db_t10,db_t11,db_t12,db_t1,db_t2,db_t3,db_tb,db_cn,db_caon,landoi,ghichu,ten_donvi,ten_cdanh" 
                                                hamRow="hsns_dinhbien_ns_day()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:TemplateField HeaderText="Năm(*)" HeaderStyle-Width="100px">
                                                        <ItemTemplate><Cthuvien:ma ID="nam" runat="server" CssClass="css_Gma_c" kt_xoa="X" Width="50px" Text="2016" /></ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                    <asp:TemplateField HeaderText="Đơn vị(*)" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="phong" runat="server" kieu_chu="true" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten" Width="100px" 
                                                                onchange="hdns_dinhbien_ns_P_KD_P_KTRA('PHONG')" Text="BSS" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                  
                                                    <asp:TemplateField HeaderText="Chức danh(*)" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="NCDANH" runat="server" kieu_chu="true" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/tl/hd_cdanh_dvi.aspx" ktra="hd_cdanh_dvi,ma,ten" Width="150px" 
                                                                onchange="hdns_dinhbien_ns_P_KD_P_KTRA('NCDANH')" guiId="day" />
                                                        </ItemTemplate>
                                                     </asp:TemplateField>                                                   
                                                    <asp:TemplateField HeaderText="Nhân sự hiện tại" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ns_hientai" runat="server" Width="80px" CssClass="css_Gso" Enabled="false" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                    <asp:TemplateField HeaderText="Định biên tháng 4" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t4" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 5" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t5" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 6" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t6" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 7" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t7" runat="server" CssClass="css_Gso" Width="80px" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 8" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t8" runat="server" CssClass="css_Gso" kt_xoa="X" Width="80px" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 9" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t9" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 10" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t10" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 11" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t11" runat="server" Width="80px" CssClass="css_Gso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 12" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t12" runat="server" Width="80px" CssClass="css_Gso" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 1" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t1" runat="server" CssClass="css_Gso" Width="80px" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 2" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t2" runat="server" CssClass="css_Gso" Width="80px" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Định biên tháng 3" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="db_t3" runat="server" CssClass="css_Gso" kt_xoa="X" Width="80px" kieu_so="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="db_tb" HeaderText="Định biên trung bình" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="db_cn" HeaderText="Định biên cuối năm" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="db_caon" HeaderText="Định biên cao nhất" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="landoi" HeaderText="Số lần thay đổi" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <%--<asp:BoundField DataField="tong_db_quy1" HeaderText="Tổng định biên quý 1" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="tong_db_quy2" HeaderText="Tổng định biên quý 2" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="tong_db_quy3" HeaderText="Tổng định biên quý 3" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="tong_db_quy4" HeaderText="Tổng định biên quý 4" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />
                                                    <asp:BoundField DataField="tong_db_canam" HeaderText="Tổng định biên cả năm" ItemStyle-CssClass="css_so" HeaderStyle-Width="80px" />--%>
                                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ghichu" runat="server" Width="200px" MaxLength="1000" CssClass="css_Gma" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />--%>
                                                     <%--<asp:BoundField DataField="phong" />--%>
                                                    <asp:BoundField DataField="ten_donvi"/>
                                                    <asp:BoundField DataField="ten_cdanh" />                                                    
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return hdns_dinhbien_ns_P_THEM();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">T</span>hêm</a>
                                                        <a href="#" onclick="return hdns_dinhbien_ns_P_KD_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return hdns_dinhbien_ns_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return hdns_dinhbien_ns_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                        <a href="#" onclick="return hdns_dinhbien_ns_FILE_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>
                                                    </div>
                                                </td>

                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return hdns_dinhbien_ns_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return hdns_dinhbien_ns_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return hdns_dinhbien_ns_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return hdns_dinhbien_ns_ChenDong('C');" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="display: none">                                                    
                                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" onserverclick="btn_excel_mau_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                                <td align="center">
                                                     <div  class="box3 txRight">    
                                                       
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="UPa_gchu" class="css_border" align="left">
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
     <%--   <Cthuvien:an ID="day" runat="server" Value="0" />--%>
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,680" />
    </div>
</asp:Content>
