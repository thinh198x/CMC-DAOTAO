<%@ Page Title="cc_cn_ct_nagase" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_cn_ct_nagase.aspx.cs" Inherits="f_cc_cn_ct_nagase" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Chấm công nhật hành chính" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
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
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Width="60px" Text="Phòng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                    CssClass="css_drop" kieu="S" Width="200px" onchange="cc_cn_ct_nagase_P_KTRA('PHONG')" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return cc_cn_ct_nagase_phong();" />
                                                            </td>
                                                            <td style="display:none">
                                                                <asp:Label ID="Label3" runat="server" Width="40px" Text="Ca" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td style="display:none">
                                                                <Cthuvien:kieu ID="ca" runat="server" CssClass="css_ma_c" Width="30px" ten="ten_kieu"
                                                                    Text="S" lke="S,C,Đ" ToolTip="S-Ca Sáng, C-Ca Chiều, Đ-Ca Đêm" />
                                                            </td>
                                                            <td style="display:none">
                                                                <asp:Label ID="Label5" runat="server" Width="30px" Text="Loại" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td style="display:none">
                                                                <Cthuvien:kieu ID="loai" runat="server" CssClass="css_ma_c" Width="30px" ten="ten_kieu"
                                                                    Text="H" lke="H,N" ToolTip="H-Hành chính, N-Ngoài giờ" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="css_gchu_c" Text="Tháng chấm công"
                                                                    Width="120px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANGCC" runat="server" CssClass="css_ma_c" kt_xoa="K" Width="100px"
                                                                    ten="Tháng chấm công" onblur="cc_cn_ct_nagase_P_KTRA('THANGCC')" kieu_luu="S" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="css_gchu_c" Text="Ngày đầu kỳ tính lương"
                                                                    Width="145px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" CssClass="css_ma_c" kt_xoa="G" Width="100px"
                                                                    ten="Ngày đầu kỳ tính lương" kieu_luu="S" onblur="cc_cn_ct_nagase_P_KTRA('NGAYD')" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="css_gchu_c" Text="Số ngày làm việc"
                                                                    Width="115px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="ngaylam" runat="server" CssClass="css_so_c" kt_xoa="G" Width="30px"
                                                                    ReadOnly="true" ToolTip="Số ngày làm việc trong tháng" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:nhap ID="tonghop" runat="server" CssClass="css_button" OnClick="cc_cn_ct_nagase_P_TONGHOP();form_P_LOI();"
                                                                    Text="Tổng hợp" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
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
                                        <div style="height: 510px; width: 1290px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left" class="css_border">
                                                                    <div id="UPa_ngay">
                                                                        <Cthuvien:GridX ID="GR_ngay" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="L" hangKt="2">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:BoundField HeaderText="Thứ/Ngày/Tháng" DataField="TT" HeaderStyle-Width="233px" ItemStyle-CssClass="css_ma" />
                                                                                <asp:BoundField DataField="n1" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n2" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n3" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n4" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n5" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n6" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n7" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n8" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n9" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n10" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n11" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n12" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n13" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n14" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n15" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n16" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n17" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n18" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n19" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n20" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n21" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n22" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n23" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n24" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n25" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n26" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n27" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n28" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n29" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n30" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField DataField="n31" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                </td>

                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; height: 26px; border-bottom: gray 1px solid; border-top: gray 1px solid;" rowspan="2" align="center">
                                                                                <asp:Label ID="Label10" runat="server" Width="80px" Text="Days" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; height: 26px; border-bottom: gray 1px solid; border-top: gray 1px solid;" colspan="3" align="center">
                                                                                <asp:Label ID="Label12" runat="server" Text="Total leave (days)" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; height: 26px; border-bottom: gray 1px solid; border-top: gray 1px solid;" colspan="3" align="center">
                                                                                <asp:Label ID="Label13" runat="server" Text="Overtime accumulation" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; height: 26px; border-bottom: gray 1px solid; border-top: gray 1px solid;" colspan="3" align="center">
                                                                                <asp:Label ID="Label23" runat="server" Text="Night time work" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left">
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label16" runat="server" Width="80px" Text="Paid leave" />
                                                                            </td>

                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label11" runat="server" Width="80px" Text="Unpaid leave" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label14" runat="server" Width="80px" Text="Other leave" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label15" runat="server" Width="80px" Text="Normal w.day" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label17" runat="server" Width="80px" Text="W.kend (Sat & Sun)" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label18" runat="server" Width="80px" Text="National holiday" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label20" runat="server" Width="80px" Text="Normal w.day" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label21" runat="server" Width="80px" Text="W.kend (Sat & Sun)" />
                                                                            </td>
                                                                            <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                                <asp:Label ID="Label22" runat="server" Width="80px" Text="National holiday" />
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
                                                        <div>
                                                            <%--style="height: 445px; width: 1290px; overflow: scroll"--%>
                                                            <table cellpadding="0" cellspacing="0" width="200px">
                                                                <tr>
                                                                    <td align="left">
                                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                            CssClass="table gridX" loai="N" hangKt="15" cotAn="phong"
                                                                            cot="so_the,ten,phong,n1,n2,n3,n4,n5,n6,n7,n8,n9,n10,n11,n12,n13,n14,n15,n16,n17,n18,n19,n20,n21,n22,n23,n24,n25,n26,n27,n28,n29,n30,n31,ngaythuong,nghi_coluong,nghi_koluong,nghikhac,ot_ngaythuong,ot_cuoituan,ot_ngayle,nt_ngaythuong,nt_cuoituan,nt_ngayle">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_nd" />
                                                                                <asp:BoundField DataField="phong" />

                                                                                <asp:BoundField HeaderText="" DataField="n1" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n2" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n3" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n4" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n5" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n6" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n7" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n8" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n9" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n10" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n11" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n12" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n13" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n14" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n15" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n16" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n17" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n18" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n19" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n20" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n21" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n22" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n23" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n24" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n25" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n26" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n27" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n28" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n29" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n30" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="n31" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <%--<asp:BoundField HeaderText="" DataField="ngaythuong" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gso" />--%>
                                                                                <asp:TemplateField HeaderStyle-Width="78px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="ngaythuong" runat="server" Width="78px" CssClass="css_Gma_c" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="" DataField="nghi_coluong" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gso" />
                                                                                <asp:BoundField HeaderText="" DataField="nghi_koluong" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gso" />
                                                                                <asp:BoundField HeaderText="" DataField="nghikhac" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="ot_ngaythuong" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="ot_cuoituan" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="ot_ngayle" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="nt_ngaythuong" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="nt_cuoituan" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />
                                                                                <asp:BoundField HeaderText="" DataField="nt_ngayle" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma_c" />

                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="tim" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                                        Width="120px" kt_xoa="K" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="tim" CssClass="css_button" OnClick="cc_cn_ct_nagase_P_TIMKIEM();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nhap ID="macdinh" runat="server" CssClass="css_button" OnClick="cc_ma_cc_P_MACDINH();form_P_LOI();"
                                                        Text="Mặc định" Width="100px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA_MDINH" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="30px" f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" gchu="gchu" ktra="ns_cc_ma_cc,ma,ten"
                                                        ten="Mã chấm công mặc định" kt_xoa="K" Text="N" onchange="cc_cn_ct_nagase_P_KTRA('MA_MDINH')" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="kieu" runat="server" CssClass="css_ma_c" Width="30px" Text="T"
                                                        lke="T,H" ToolTip="T-Tất cả hàng,H-Từng hàng" kt_xoa="true" BackColor="LightCyan"
                                                        ForeColor="Blue" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu_c" Text=""
                                                        Width="125px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu_c" Text="Từ ngày"
                                                        Width="60px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="tu_ngay" runat="server" CssClass="css_ma_c" kieu_so="true" Width="30px" gchu="gchu"
                                                        ten="Ngày bắt đầu" kt_xoa="K" MaxLength="2" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" CssClass="css_gchu_c" Text="Tới ngày"
                                                        Width="60px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="toi_ngay" runat="server" CssClass="css_ma_c" kieu_so="true" Width="30px" gchu="gchu"
                                                        ten="Ngày kết thúc" kt_xoa="K" MaxLength="2" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="cc_cn_ct_nagase_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="cc_cn_ct_nagase_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return cc_cn_ct_nagase_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return cc_cn_ct_nagase_P_FILES();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,700" />
        <Cthuvien:an ID="t7" runat="server" />
        <Cthuvien:an ID="cn" runat="server" />
        <Cthuvien:an ID="thumuc" runat="server" />
    </div>
</asp:Content>
