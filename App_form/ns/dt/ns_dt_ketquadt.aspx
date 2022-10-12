<%@ Page Title="ns_dt_ketquadt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ketquadt.aspx.cs" Inherits="f_ns_dt_ketquadt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kết quả khóa đào tạo " />
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
                                            CssClass="table gridX" loai="L" hangKt="15" cotAn="so_id" hamRow="ns_dt_ketquadt_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Số QĐ" DataField="so_qd" HeaderStyle-Width="100px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="78" gridId="GR_lke"
                                            ham="ns_dt_ketquadt_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>

                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Mã khóa ĐT" CssClass="css_gchu" Width="90px" ToolTip="Mã khóa ĐT"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã khóa đào tạo" ToolTip="Mã khóa đào tạo" runat="server" Width="185px" CssClass="css_form"
                                                                    kt_xoa="G" f_tkhao="~/App_form/ns/dt/ns_dt_kdt.aspx" BackColor="#f6f7f7"
                                                                    ktra="ns_dt_kdt,ma,ten" onfocusout="ns_dt_ketquadt_P_KTRA('MA')" kieu_chu="true" placeholder="Nhấn F1" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Số QĐ" CssClass="css_gchu" Width="90px" ToolTip="Số QĐ"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_QD" ten="Số quyết định" ToolTip="Tên khóa đào tạo"
                                                                    runat="server" CssClass="css_form" Width="185px" kt_xoa="X" kieu_chu="true" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Ngày QĐ" CssClass="css_gchu" Width="106px" ToolTip="Ngày QĐ"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_QD" ten="Ngày QĐ" runat="server" CssClass="css_form_c" kt_xoa="X" Width="165px" />
                                                                    </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Nhận xét" CssClass="css_gchu" Width="90px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="nhanxet" ToolTip="Nhận xét khóa học" kieu_unicode="true" runat="server" Width="486px" CssClass="css_form"
                                                        kt_xoa="X" TextMode="MultiLine" Rows="3" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="so_the,ten,phong,ketqua" hangKt="10" hamUp="ns_dt_ketquadt_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="100px"
                                                                ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="172px"
                                                                ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:TemplateField HeaderText="Kết quả(*)" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c">
                                                                <ItemTemplate>
                                                                    <Cthuvien:kieu ID="ketqua" runat="server" Width="120px" CssClass="css_Gma_c" lke="G,K,TBK,TB,Y,KQ" Text=""
                                                                        ToolTip="G - Giỏi, K - Khá,TBK - Trung bình khá, TB - Trung bình, Y - Yếu, KQ - Không đạt" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dt_ketquadt_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_dt_ketquadt_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dt_ketquadt_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_dt_ketquadt_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_dt_ketquadt_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_dt_ketquadt_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="height:19px">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left" style="height: 19px">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">

        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,700" />
    </div>
</asp:Content>
