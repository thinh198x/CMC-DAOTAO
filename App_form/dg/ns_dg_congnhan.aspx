<%@ Page Title="ns_dg_congnhan" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dg_congnhan.aspx.cs" Inherits="f_ns_dg_congnhan" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá công nhân" />
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
                                            CssClass="table gridX" loai="X" hangKt="18" hamRow="ns_dg_congnhan_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="ns_dg_congnhan_P_LKE()" />
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
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="70px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_form"
                                                                    onchange="ns_dg_congnhan_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_dg_congnhan_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text="Ngày" Width="60px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" runat="server" Width="100px" CssClass="css_form_c" kt_xoa="K"
                                                                        kieu_luu="S" onblur="ns_dg_congnhan_P_KTRA('NGAY')" />
                                                                    </div>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
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
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label2" runat="server" Width="24px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label3" runat="server" Width="80px" Text="Mã cán bộ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label5" runat="server" Width="210px" Text="Họ tên" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label7" runat="server" Text="Kỹ năng làm việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="3" align="center">
                                                                    <asp:Label ID="Label33" runat="server" Text="Kỹ năng giao tiếp" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="4" align="center">
                                                                    <asp:Label ID="Label37" runat="server" Text="Tinh thần làm việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label30" runat="server" Width="110px" Text="T.Số Điểm" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="5" align="center">
                                                                    <asp:Label ID="Label42" runat="server" Text="Đánh giá" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid; border-bottom: gray 1px solid;" colspan="2" align="center">
                                                                    <asp:Label ID="Label4" runat="server" Text="Đề nghị" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label14" runat="server" Width="110px" Text="Hiểu công việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label15" runat="server" Width="110px" Text="Bảo quản thiết bị" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label16" runat="server" Width="110px" Text="Chất lượng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label32" runat="server" Width="110px" Text="ATLĐ" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label34" runat="server" Width="110px" Text="Đồng nghiệp" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label35" runat="server" Width="110px" Text="Khách hàng" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label36" runat="server" Width="110px" Text="Tiếp thu ý kiến" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label38" runat="server" Width="110px" Text="Thời gian làm việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label39" runat="server" Width="110px" Text="Chấp hành quy định" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label40" runat="server" Width="110px" Text="Ý thức làm việc" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label41" runat="server" Width="110px" Text="Đồng phục" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label43" runat="server" Width="60px" Text="A+" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label44" runat="server" Width="60px" Text="A" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label45" runat="server" Width="60px" Text="B" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label46" runat="server" Width="60px" Text="C" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label47" runat="server" Width="60px" Text="D" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label48" runat="server" Width="60px" Text="ĐB" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" align="center">
                                                                    <asp:Label ID="Label49" runat="server" Width="60px" Text="TQ" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="SO_THE,TEN,HIEUCV,BQTHIETBI,CHATLUONG,ATLD,DONGNGHIEP,KHANG,TIEPTHU,THOIGIAN,CHAPHANH,YTHUC,DONGPHUC,SODIEM,AP,A,B,C,D,DB,TQ"
                                                            hangKt="21" gchuId="gchu">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="HIEUCV" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="BQTHIETBI" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="CHATLUONG" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ATLD" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="DONGNGHIEP" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="KHANG" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TIEPTHU" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="THOIGIAN" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="CHAPHANH" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="YTHUC" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="DONGPHUC" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="108px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="SODIEM" runat="server" Width="108px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="AP" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="A" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="B" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="C" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="D" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="DB" runat="server" Width="58px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="TQ" runat="server" Width="58px" CssClass="css_Gma" />
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
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dg_congnhan_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dg_congnhan_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dg_congnhan_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dg_congnhan_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dg_congnhan_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dg_congnhan_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>--%>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_dg_congnhan_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1355,780" />
    </div>
</asp:Content>
