<%@ Page Title="ns_hd_dg_tt_cbql" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hd_dg_tt_cbql.aspx.cs" Inherits="f_ns_hd_dg_tt_cbql" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá HĐLĐ" />
                                    </td>
                                    <td align="right">
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
                        <td valign="top" class="form_right">
                            <table id="UPa_ct" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <div style="padding-top: 20px">
                                        <asp:Label ID="Label11" Text="Thông tin chung" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                    </div>
                                    <td align="left">
                                        <table cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Mã nhân viên" Width="120px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" Width="200px" ten="Tên vị trí chức danh" ToolTip="Mã nhân viên" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblmucdich" runat="server" Text="Họ tên" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="true" Width="200px" ten="Họ tên" ToolTip="Họ tên" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Phòng ban" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_form" kieu_unicode="true" Width="200px" ten="Phòng ban" ToolTip="Phòng ban" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Chức danh" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_form" kieu_unicode="true" Width="200px" ten="Chức danh" ToolTip="Chức danh" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Loại hợp đồng" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:ma ID="ten_lhd" runat="server" CssClass="css_form" kieu_unicode="true" Width="200px" ten="Loại hợp đồng" ToolTip="Loại hợp đồng" />
                                                </td>

                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Ngày bắt đầu" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ngayd" runat="server" CssClass="css_form_c" kieu_unicode="true" Width="200px" ten="Ngày bắt đầu" ToolTip="Ngày bắt đầu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Ngày kết thúc" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ngayc" runat="server" CssClass="css_form_c" kieu_unicode="true" Width="200px" ten="Ngày kết thúc" ToolTip="Ngày kết thúc" />
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="lbl1" Text="Nội dung đánh giá" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                        </div>
                                        <hr width="100%" />
                                        <div style="height: 200px; width: 100%; overflow-y: scroll">
                                            <Cthuvien:GridX ID="GR_dgia" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N"
                                                CssClass="table gridX" hangKt="19"  hamUp="ns_hd_dg_tt_cbql_GR_lke_Update"
                                                cot="bt,nd_dgia,yeu,kem,tb,kha,xuatsac,mota">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="STT" DataField="bt" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:TemplateField HeaderText="Nội dung đánh giá" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="nd_dgia" runat="server" CssClass="css_Gma" kt_xoa="X" Width="200px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Yếu" HeaderStyle-Width="60px" ItemStyle-CssClass="txCenter">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="yeu"  onfocusout="ns_hd_dg_tt_cbql_P_KTRA()" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Yếu" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Kém" HeaderStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="kem" onfocusout="ns_hd_dg_tt_cbql_P_KTRA('kem')" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Kém" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Trung bình" HeaderStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="tb" onfocusout="ns_hd_dg_tt_cbql_P_KTRA('tb')" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Trung bình" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Khá" HeaderStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="kha" onfocusout="ns_hd_dg_tt_cbql_P_KTRA('kha')" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Khá" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Xuất sắc" HeaderStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="xuatsac" onfocusout="ns_hd_dg_tt_cbql_P_KTRA('xuatsac')" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Xuất sắc" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="250px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="mota" runat="server" Width="250px" CssClass="css_GmaN_c" ToolTip="Ghi chú" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <hr width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table id="UPa_nh" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Đánh giá chung" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nd ID="dgia_chung" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="35px" Width="500px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <div style="padding-top: 20px">
                                                        <asp:Label ID="Label5" Text="Đề xuất:" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                    </div>
                                                    <hr width="100%" />
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Ký HĐ chính thức" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:kieu ID="than1" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Chọn phê duyệt" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label16" runat="server" Text="1 năm" Width="100px" CssClass="css_gchu_c"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:kieu ID="than2" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Chọn phê duyệt" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label17" runat="server" Text="2 năm" Width="100px" CssClass="css_gchu_c"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:kieu ID="than3" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Chọn phê duyệt" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label18" runat="server" Text="3 năm" Width="100px" CssClass="css_gchu_c"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:kieu ID="than4" runat="server" Width="40px" CssClass="css_form_c" Text="" lke=",X" ToolTip="Chọn phê duyệt" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label19" runat="server" Text="Không xác định thời hạn" CssClass="css_gchu_c"></asp:Label>
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
                                                                <asp:Label ID="Label9" runat="server" Text="Đề xuất khác" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nd ID="dxuat" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="35px" Width="500px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Gia hạn thử việc(Nêu rõ lý do)" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nd ID="lydo" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="35px" Width="500px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>
                                            <tr>
                                    <td align="left">
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="Label12" Text="Trường hợp gia hạn thử việc:" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                        </div>
                                        <hr width="100%" />
                                        <table cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Mục tiêu CV được giao" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="muctieu" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="35px" Width="500px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="Đánh giá kết quả HT" Width="120px" CssClass="css_gchu_c"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="dgia_kq" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="35px" Width="500px" ten="Yêu cầu khác" ToolTip="Yêu cầu khác" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                        </table>
                                    </td>
                                </tr>


                                

                                <tr>
                                    <td align="left">
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="Label20" Text="Đề xuất chỉ tiêu cá nhân sau khi tiếp nhận chính thức:" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                        </div>
                                        <hr width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX2" loai="N" hangKt="4" cotAn=""
                                            cot="khiacanh,chitieu,mota,trongso,dinhmucl1,dinhmucl2">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Khía cạnh" DataField="khiacanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Chỉ tiêu">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="chitieu" runat="server" Width="150px" CssClass="css_GmaN_c"
                                                            ToolTip="Chỉ tiêu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Mô tả">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="mota" runat="server" Width="200px" CssClass="css_GmaN_c"
                                                            ToolTip="Mô tả" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" HeaderText="Trọng số">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="trongso" runat="server" Width="120px" CssClass="css_GmaN_c"
                                                            ToolTip="Trọng số" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" HeaderText="Định mức L1">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="dinhmucl1" runat="server" Width="120px" CssClass="css_GmaN_c"
                                                            ToolTip="Định mức 1" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" HeaderText="Định mức L2">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="dinhmucl2" runat="server" Width="120px" CssClass="css_GmaN_c"
                                                            ToolTip="Định mức 2" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_hd_dg_tt_cbql_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <%--<a href="#" onclick="return ns_hd_dg_tt_cbql_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_hd_dg_tt_cbql_P_GUI();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">G</span>ửi</a>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="css_border" align="left">
                                        <div id="UPa_gchu">
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,820" />
    </div>
</asp:Content>
