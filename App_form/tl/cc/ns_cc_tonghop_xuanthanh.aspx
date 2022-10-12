<%@ Page Title="ns_cc_tonghop_xuanthanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_tonghop_xuanthanh.aspx.cs" Inherits="f_ns_cc_tonghop_xuanthanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Bảng tổng hợp công" />
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
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_drop"
                                                                    onchange="ns_cc_tonghop_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cc_tonghop_xuanthanh_phong();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANGCC" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="K"
                                                                    kieu_luu="S" onblur="ns_cc_tonghop_P_KTRA('THANG')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinhluong" runat="server" Text="Tổng hợp công" CssClass="css_button"
                                                                    OnClick="return ns_cc_tonghop_TINH();" Width="160px" />
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
                                                        <table id="tblInfo" cellspacing="0" cellpadding="0" class="tbl_ll">
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="80px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="210px" Text="Tên nhân viên" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label36" runat="server" Width="110px" Text="Giờ hành chính" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label37" runat="server" Width="110px" Text="Đi muộn" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="3" align="center">
                                                                    <asp:Label ID="Label38" runat="server" Width="110px" Text="Về sớm" />
                                                                </td>

                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="6" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Text="Nghỉ chế độ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Text="Nghỉ khác" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                              
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label8" runat="server" Text="Nghỉ có lương" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label9" runat="server" Text="Nghỉ chế độ BHXH" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label10" runat="server" Text="Nghỉ không lương" />
                                                                </td>
                                                                
                                                            </tr>
                                                            <tr>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="110px" Text="Nghỉ Phép(hưởng lương cơ bản)" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label17" runat="server" Width="110px" Text="Học tập,Hội nghị " />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label18" runat="server" Width="110px" Text="Nghỉ Lễ,tết" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label19" runat="server" Width="110px" Text="Hiếu,hỉ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label20" runat="server" Width="110px" Text="Nghỉ ốm" />
                                                                </td>
                                                                 <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label21" runat="server" Width="110px" Text="Thai sản" />
                                                                </td>

                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label26" runat="server" Width="110px" Text="Hiếu,hỉ khác" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="110px" Text="Nghỉ việc riêng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;"  align="center">
                                                                    <asp:Label ID="Label23" runat="server" Width="110px" Text="Nghỉ không lý do" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="Gr_ma" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="so_the,ten,ma01,ma2,ma3,ma4,ma5,ma6,ma7,ma8,ma9,ma10,ma11,ma12,ma13,ma14,ma15,ma16,ma17,ma18,ma19,ma20,ma21,ma22,ma23,ma24,ma25" cotAn="ma13,ma14,ma15,ma16,ma17,ma18,ma19,ma20,ma21,ma22,ma23,ma24,ma25" hangKt="1" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma01" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma2" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma3" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma4" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma5" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma6" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma7" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma8" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma9" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma10" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma11" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma12" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma13" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma14" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma15" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma16" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma17" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma18" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma19" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma20" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma21" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma22" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma23" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma24" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ma25" runat="server" Width="108px" CssClass="css_Gma_c" kieu_chu="true"
                                                                            f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>

                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="L" hangKt="19" gchuId="gchu" cotAn="PHONG_CP,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="PHONG_CP" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="N1" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N2" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N3" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N4" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N5" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N6" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N7" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N8" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N9" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N10" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N11" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N12" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N13" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N14" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N15" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N16" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N17" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N18" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N19" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N20" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N21" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N22" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N23" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N24" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="N25" HeaderStyle-Width="108px" ItemStyle-CssClass="css_Gma_c" />
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
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_cc_tonghop_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_cc_tonghop_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_cc_tonghop_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return ns_cc_tonghop_P_FILES();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_cc_tonghop_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_cc_tonghop_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_cc_tonghop_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_cc_tonghop_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_tonghop_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_cc_tonghop_ChenDong('C');" />
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
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_cc_tonghop_GR_lke_RowChange()">
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
                                            ham="ns_cc_tonghop_P_LKE()" />
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
