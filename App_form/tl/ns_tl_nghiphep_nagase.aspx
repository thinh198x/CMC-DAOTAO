<%@ Page Title="ns_tl_nghiphep_nagase" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_nghiphep_nagase.aspx.cs" Inherits="f_ns_tl_nghiphep_nagase" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Annual leave summary" />
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
                                                    <asp:Label ID="Label6" runat="server" Text="Location" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_drop"
                                                                    DataTextField="ten" DataValueField="ma" onchange="ns_tl_nghiphep_nagase_P_KTRA('PHONG')" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_tl_nghiphep_nagase_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Year" CssClass="css_gchu_c" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma MaxLength="4" ID="NAM" runat="server" Width="100px" CssClass="css_ma_c"
                                                                    onchange="ns_tl_nghiphep_nagase_P_KTRA('NAM')" kt_xoa="G" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinhluong" runat="server" Text="Execute" CssClass="css_button"
                                                                    OnClick="return ns_tl_nghiphep_nagase_TINH();" Width="160px" />
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
                                                                    <Cthuvien:luu ID="lblloai155" runat="server" Width="24px" Height="30px" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai21" runat="server" Width="80px" Text="Employee code" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai31" runat="server" Width="210px" Text="Name" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai41" runat="server" Width="70px" Text="AL given days" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai1" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai2" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai3" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai4" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai5" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai6" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai7" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai8" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai9" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai10" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai11" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <Cthuvien:luu ID="lblloai12" runat="server" Width="60px" Text="" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label27" runat="server" Width="80px" Text="AL taken day" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label24" runat="server" Width="85px" Text="Fwd from PRV" />
                                                                </td>
                                                                <td style="background-color: #9fc54e; border-right: gray 1px solid;" rowspan="2" align="center">
                                                                    <asp:Label ID="Label28" runat="server" Width="80px" Text="AL balance days" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                                            hangKt="15" gchuId="gchu" cot="SO_THE,TEN,PHEPNAM,loai1,loai2,loai3,loai4,loai5,loai6,loai7,loai8,loai9,loai10,loai11,loai12,TONGNGHI,PHEPNAMCU,SOPHEPCON">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                                                <asp:BoundField DataField="SO_THE" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TEN" HeaderStyle-Width="208px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="PHEPNAM" HeaderStyle-Width="68px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai1" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <%--<asp:BoundField DataField="loai2" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />--%>
                                                                <asp:TemplateField HeaderStyle-Width="58px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="loai2"  runat="server" kieu_so="true" Width="58px" CssClass="css_Gma_c"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="loai3" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai4" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai5" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai6" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai7" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai8" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai9" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai10" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai11" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="loai12" HeaderStyle-Width="58px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="TONGNGHI" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="PHEPNAMCU" HeaderStyle-Width="83px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField DataField="SOPHEPCON" HeaderStyle-Width="78px" ItemStyle-CssClass="css_Gma" />
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
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tl_nghiphep_nagase_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_tl_nghiphep_nagase_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tl_nghiphep_nagase_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                                        OnClick="return ns_tl_nghiphep_nagase_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_tl_nghiphep_nagase_P_IN();form_P_LOI();"
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
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_tl_nghiphep_nagase_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Year" DataField="nam" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_nghiphep_nagase_P_LKE()" />
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
