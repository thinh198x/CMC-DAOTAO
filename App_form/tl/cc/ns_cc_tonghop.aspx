<%@ Page Title="ns_cc_tonghop" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tonghop.aspx.cs" Inherits="f_ns_cc_tonghop" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Bảng tổng hợp chấm công" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label99" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_form"
                                                                    onchange="ns_cc_tonghop_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cc_tonghop_phong();" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label89" runat="server" CssClass="css_gchu_c" Text="Năm"
                                                                    Width="50px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="NAM" ten="Năm" runat="server" DataTextField="nam" DataValueField="nam"
                                                                    CssClass="css_form" onchange="ns_danhsach_P_NAM();" kieu="S" Width="70px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label112" runat="server" CssClass="css_gchu_c" Text="Kỳ công"
                                                                    Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="KYLUONG" ten="Kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form" kieu="S" Width="260px" onchange="ns_cc_tonghop_P_KTRA('KYLUONG')" />
                                                            </td>
                                                            <td style="display:none">
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td style="padding-left: 20px">
                                                                <div class="box3" style="width: 300px;">
                                                                    <a href="#" onclick="return ns_cc_tonghop_TINH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-calculator"></i>Tổng hợp công</a>
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
                                        <div style="height: 500px; width: 1200px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td id="td1" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label1" runat="server" Width="29px" />
                                                                </td>
                                                                <td id="td2" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="85px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td id="td3" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="216px" Text="Tên nhân viên" />
                                                                </td>
                                                                <td id="td4" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Width="256px" Text="Phòng ban" />
                                                                </td>
                                                                <td id="td5" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="116px" Text="Ngày bắt đầu" />
                                                                </td>
                                                                <td id="td6" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label6" runat="server" Width="116px" Text="Ngày kết thúc" />
                                                                </td>
                                                                <td id="td7" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Width="116px" Text="Công làm việc thực tế" />
                                                                </td>
                                                                <td id="td8" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Width="116px" Text="Công nghỉ phép" />
                                                                </td>
                                                                <td id="td9" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Width="116px" Text="Công đào tạo" />
                                                                </td>
                                                                <td id="td10" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Width="116px" Text="Công công tác" />
                                                                </td>
                                                                <td id="td11" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label11" runat="server" Width="116px" Text="Công ngày lễ tết" />
                                                                </td>
                                                                <td id="td12" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label12" runat="server" Width="116px" Text="Công chế độ" />
                                                                </td>
                                                                <td id="td13" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label13" runat="server" Width="116px" Text="Tổng công hưởng lương" />
                                                                </td>
                                                                <td id="td14" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="116px" Text="Công nghỉ việc riêng không hưởng lương" />
                                                                </td>
                                                                <td id="td15" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="116px" Text="Công nghỉ chế độ con nhỏ" />
                                                                </td>
                                                                <td id="td16" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="116px" Text="Công thai sản" />
                                                                </td>
                                                                <td id="td17" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="116px" Text="Tổng công BH/không lương" />
                                                                </td>
                                                                <td id="td18" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="116px" Text="" />
                                                                </td>
                                                                <td id="td19" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="116px" Text="" />
                                                                </td>
                                                                <td id="td20" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="116px" Text="" />
                                                                </td>
                                                                <td id="td21" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="116px" Text="" />
                                                                </td>
                                                                <td id="td22" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label22" runat="server" Width="116px" Text="" />
                                                                </td>
                                                                <td id="td23" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="116px" />
                                                                </td>
                                                                <td id="td24" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="116px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td id="td25" style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label25" runat="server" Width="116px" Text="Tên nhân viên" />
                                                                </td>
                                                                <td id="td26" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Width="116px" Text="Phòng ban" />
                                                                </td>                                                              
                                                                <td id="td27" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="116px" Text="Tổng công hưởng lương" />
                                                                </td>
                                                                <td id="td28" style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label28" runat="server" Width="116px" Text="Tổng công BH/không lương" />
                                                                </td>                                                              
                                                            </tr>
                                                        </table>

                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" hangKt="19" cot="SO_THE,TEN,PHONG,NGAYD,NGAYC,CONG_1,CONG_2,CONG_3,CONG_4,CONG_5,CONG_6,CONG_7,CONG_8,CONG_9,CONG_10,CONG_11,CONG_12,CONG_13,CONG_14,CONG_15,CONG_16,CONG_17,CONG_18,CONG_19,CONG_20,TONG_CONG1,TONG_CONG2" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:TemplateField HeaderStyle-Width="248px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma runat="server" ID="PHONG" Enabled="false" ReadOnly="true" Width="248px" CssClass="css_Gma"></Cthuvien:ma>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NGAYD" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="NGAYC" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_3" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_10" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_11" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_12" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_13" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_14" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_15" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_16" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_17" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_18" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_19" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="CONG_20" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="TONG_CONG1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="TONG_CONG2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />                                                               
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
                                                    <div class="box3 txRight2" style="width: 300px;">
                                                        <a href="#" id="tdMo" onclick="return ns_cc_tonghop_P_MO();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Mở</a>
                                                        <a href="#" id="tdKhoa" onclick="return ns_cc_tonghop_P_DONG();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Khóa</a>
                                                        <a href="#" onclick="return ns_cc_tonghop_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i>Xuất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return ns_cc_tonghop_P_FILES();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_cc_tonghop_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ns_cc_tonghop_P_PHEDUYET();form_P_LOI();"
                                                        Width="100px" />
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; display: none">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_cc_tonghop_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; display: none" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_cc_tonghop_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; display: none" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_tonghop_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; display: none" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_cc_tonghop_ChenDong('C');" />
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td colspan="4">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,700" />
    </div>
</asp:Content>
