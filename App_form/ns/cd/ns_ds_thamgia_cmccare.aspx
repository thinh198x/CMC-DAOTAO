<%@ Page Title="ns_ds_thamgia_cmccare" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ds_thamgia_cmccare.aspx.cs" Inherits="f_ns_ds_thamgia_cmccare" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách đủ dk tham gia CMC Care" />
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
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">

                                <tr>
                                    <td class="form_right">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text="Từ ngày" CssClass="css_gchu" Width="106px" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Từ ngày" runat="server" CssClass="css_form_c" kt_xoa="X" Width="120px" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" CssClass="css_gchu_c" Width="95px" Text="Đến ngày" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Đến ngày" ToolTip="Đến ngày" runat="server"
                                                                        CssClass="css_form_c" kt_xoa="X" Width="120px" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="padding-top: 5px">
                                                <td></td>
                                                <td style="padding-top: 5px; padding-bottom: 5px">
                                                    <a href="#" onclick="return ns_ds_thamgia_cmccare_P_KTRA('TINHTRANG');form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="height: 400px; width: 950px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cotAn="lhd" cot="chon,so_the,ten,Cdanh,phong,ngaysinh,goi_bh,mucphi_bh,thoidiem,thoidiemtangmoi" hangKt="12">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="chon" runat="server" Width="50px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="100px"
                                                                    ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Tên cán bộ" DataField="ten" HeaderStyle-Width="162px"
                                                                    ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Chức danh" DataField="Cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Đơn vị" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Ngày sinh" DataField="ngaysinh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Gói bảo hiểm" DataField="goi_bh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_r" />
                                                                <asp:BoundField HeaderText="Mức phí bảo hiểm" DataField="mucphi_bh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_r" />
                                                                <asp:BoundField HeaderText="Thời điểm hưởng" DataField="thoidiem" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Thời điểm tăng mới">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' runat="server" ID="thoidiemtangmoi" Width="150px" CssClass="css_Gma"></Cthuvien:ngay>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                                        ham="ns_ds_thamgia_cmccare_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_ds_thamgia_cmccare_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ds_thamgia_cmccare_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
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
            </td>
        </tr>
    </table>
    <div id="UPa_hi">

        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,680" />
    </div>
</asp:Content>
