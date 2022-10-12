<%@ Page Title="tl_bluong_nagase_nn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_bluong_nagase_nn.aspx.cs" Inherits="f_tl_bluong_nagase_nn" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Foreigner staff salary" />
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
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG_CP" runat="server" kieu="U" Width="202px" CssClass="css_drop"
                                                                    onchange="tl_bluong_nagase_nn_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return tl_bluong_nagase_nn_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text="Tháng" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANGCC" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="K"
                                                                    kieu_luu="S" onblur="tl_bluong_nagase_nn_P_KTRA('THANG')" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Tỷ giá hiện tại" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="tygia" runat="server" Width="100px" CssClass="css_so_c" kt_xoa="K"/>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinhluong" runat="server" Text="Tính lương tháng" CssClass="css_button"
                                                                    OnClick="return tl_bluong_nagase_nn_TINH();" Width="160px" />
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
                                        <div style="height: 500px; width: 1000px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" cotAn="PHONG_CP,SEC,RATE"
                                                            hangKt="21" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="PHONG_CP" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Emloyee Code" DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Emloyee Name" DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Days" DataField="DAYS" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Normal Days" DataField="NORMALDAY" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="SEC" HeaderText="Section"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="SALARYNETUSD" HeaderText="Monthly Net basic salary (USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="OT_NOWEEKDAY" HeaderText="Overtime Normal weekday (5:15pm~10pm)(hours) 150%"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="OT_WEEKDAY" HeaderText="Overtime Weekend (Sat & Sun) & Nagase holiday (6am~10pm)(hours) 200%"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="OT_HOLIDAY" HeaderText="Overtime National Holiday(6am~10pm)(hours) 300%"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="NT_NOWEEKDAY" HeaderText="Overtime Normal weekday night (10pm~6am)(hours) 200%"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="NT_WEEKDAY" HeaderText="Overtime Weekend (Sat & Sun) & Nagase holiday night(10pm~6am)(hours) 270%"  HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="NT_HOLIDAY" HeaderText="Overtime National Holiday night (10pm~6am)(hours) 390%" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="SALARY_OT" HeaderText="Salary for overtime(USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="ALLOWANCEUSD" HeaderText="Allowance (USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="UNPAIDUSD" HeaderText="Unpaid leave (USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="INSURANCEFEE" HeaderText="Deduct company trip, insurance fee" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TOTALPAY" HeaderText="Total payment to employee (VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TOTALNETUSD" HeaderText="Total net income (in USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TOTALNETVND" HeaderText="Total net income (in VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PITCAL" HeaderText="Deductions for family circumstanes for PIT calculation (in VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="AFTERDECDUTION" HeaderText="Monthly net income after Deductions (in VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="GROSSFORPIT" HeaderText="Monthly gross income for PIT calculation (in VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="PAYPIT" HeaderText="Payable PIT (VND)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="TAXABLE" HeaderText="Taxable income" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="GROSSSALARYUSD" HeaderText="Monthly Gross salary (USD)" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gso" />
                                                                <asp:BoundField DataField="RATE" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
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
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_bluong_nagase_nn_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_bluong_nagase_nn_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_bluong_nagase_nn_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return tl_bluong_nagase_nn_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return tl_bluong_nagase_nn_P_IN();form_P_LOI();"
                                                        Width="70px" />
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
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="tl_bluong_nagase_nn_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thangcc" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="tl_bluong_nagase_nn_P_LKE()" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,700" />
    </div>
</asp:Content>
