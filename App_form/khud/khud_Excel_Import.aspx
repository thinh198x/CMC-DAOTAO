<%@ Page Language="C#" AutoEventWireup="true" CodeFile="khud_Excel_Import.aspx.cs" Inherits="f_khud_Excel_Import"
    Title="khud_Excel_Import" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table cellpadding="7" cellspacing="1">
                <tr>
                    <td align="center">
                        <Cthuvien:luu ID="Label2" runat="server" Text="Import Dữ liệu từ File Excel, Dbf" CssClass="css_phude" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="1" cellspacing="1" id="UPa_ct">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Width="60px" Text="Chọn file" />
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="chon_file" runat="server" Width="350px" CssClass="css_form" BackColor="White" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="ten" runat="server" CssClass="css_gchu" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Width="60px" Text="Thông tin" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="nv" runat="server" Width="265px" CssClass="css_form">
                                        <asp:ListItem Text="Thông tin phòng ban" Value="NS_PHONG" />
                                        <asp:ListItem Text="Thông tin cán bộ" Value="ns_cb_excel" />
                                        <asp:ListItem Text="Hợp đồng" Value="NS_HD" />
                                        <asp:ListItem Text="Quan hệ thân nhân" Value="NS_QH" />
                                        <asp:ListItem Text="Mã nhóm chức danh" Value="NS_MA_NCDANH" />
                                        <asp:ListItem Text="Mã chức danh" Value="NS_MA_CDANH" />
                                        <asp:ListItem Text="Thông tin khen thưởng" Value="NS_KTKL_KT" />
                                        <asp:ListItem Text="Thông tin kỷ luật" Value="NS_KTKL_KL" />

                                        <%--<asp:ListItem Text="Thông tin bảo hiểm xã hội" Value="NS_BHXH" />
                                        <asp:ListItem Text="Mã bệnh viện(Nơi khám chữa bệnh)" Value="NS_MA_BV" />
                                        <asp:ListItem Text="Mã loại hợp đồng" Value="NS_MA_LHD" />
                                        <asp:ListItem Text="Cập nhập lương hợp đồng và bảo hiểm" Value="NS_HD_UPDATE_LUONG" />
                                        <asp:ListItem Text="Trang thiết bị" Value="NS_TTB" />
                                        <asp:ListItem Text="Mã Ngành(nhóm chuyên ngành)" Value="NS_MA_NCNGANH" />
                                        <asp:ListItem Text="Mã cấp đào tạo" Value="NS_MA_CAPDT" />
                                        <asp:ListItem Text="Mã dân tộc" Value="NS_MA_DT" />
                                        <asp:ListItem Text="Mã tôn giáo" Value="NS_MA_TG" />
                                        <asp:ListItem Text="Mã xếp loại đào tạo" Value="NS_MA_XLOAI" />
                                        <asp:ListItem Text="Mã ngân hàng" Value="NS_MA_NHA" />
                                        <asp:ListItem Text="Quá trình đào tạo" Value="NS_DTHV" />
                                        <asp:ListItem Text="Mã nhóm tìm kiếm" Value="NS_TK_MA_NHTK" />
                                        <asp:ListItem Text="Mã chỉ tiêu tìm kiếm" Value="NS_TK_MA_CHITIEU" />
                                        <asp:ListItem Text="Mã kết quả hiển thị" Value="NS_TK_KQTK" />
                                        <asp:ListItem Text="Phụ cấp" Value="NS_TL_TN_PCAP" />
                                        <asp:ListItem Text="Thông tin thêm" Value="NS_TTT" />
                                        <asp:ListItem Text="Chuyển phòng" Value="NS_CP" />
                                        <asp:ListItem Text="Thông tin nghỉ phép" Value="NS_TT_NGHI" />
                                        <asp:ListItem Text="Thông tin thôi việc" Value="NS_TV" />
                                        <asp:ListItem Text="Hoạt động công tác" Value="NS_HDCT" />--%>
                                    </Cthuvien:DR_nhap>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <div class="box3 txRight">
                                        <a href="#" onclick="return khud_Excel_Import_File_mau();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">F</span>ile mẫu</a>
                                        <a href="#" onclick="return khud_Excel_Import_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">I</span>mport</a>
                                    </div>
                                </td>
                                <td style="display: none">
                                    <Cthuvien:nhap ID="nhap1" runat="server" Width="100px" Text="File mẫu" OnServerClick="nhap2_Click" />
                                </td>
                                <td style="display: none">
                                    <Cthuvien:nhap ID="nhap" runat="server" Width="100px" Text="Import" OnServerClick="nhap_Click" />
                                </td>
                                <%--<td>
                                    <Cthuvien:nhap ID="nhap1" runat="server" Width="90px" Text="File mẫu" giu="true" OnServerClick="nhap2_Click" />
                                </td>
                                <td>
                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Import" giu="true" OnServerClick="nhap_Click" />
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="nhap" />
            <asp:PostBackTrigger ControlID="nhap1" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="500,210" />
        <Cthuvien:an ID="tra_dong" runat="server" Value="FILE_HTOAN" />
        <Cthuvien:an ID="thumuc" runat="server" />
    </div>
</asp:Content>
