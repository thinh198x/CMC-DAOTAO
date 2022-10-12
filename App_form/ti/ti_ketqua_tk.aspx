<%@ Page Title="ti_ketqua_tk" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_ketqua_tk.aspx.cs" Inherits="f_ti_ketqua_tk" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kết quả tìm kiếm" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
            <td>
                <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <%--<div style="width: 950px; overflow: scroll">--%>
                                <%--height: 300px; --%>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L" hangKt="15"
                                    cotAn="SOTT,SO_THE,PHONG,TEN,GTINH,NSINH,SOCMT,DCHI,HKHAU,DTDD,DTNR,EMAIL,MAST,NGAYD,CAPDT,HEDT,NHOM_CNGANH,CNGANH,NOIDT,VB,HINHTHUC,THANGD,THANGC,XEPLOAI,LHD,SO_HD,CVU,HSPC,LNG,NGACH,BAC,HSO,NCD,CDANH,BCD,HSCD,TIEN,TIENBH,NGAYC">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="TT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mã cán bộ" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mã Phòng" DataField="PHONG" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên" DataField="TEN" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Giới tính" DataField="GTINH" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày sinh" DataField="NSINH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số CMT" DataField="SOCMT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ" DataField="DCHI" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hộ khẩu" DataField="HKHAU" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="ĐTDD" DataField="DTDD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="ĐTNR" DataField="DTNR" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Email" DataField="EMAIL" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mã số thuê" DataField="MAST" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày vào đơn vị" DataField="NGAYD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Cấp ĐT" DataField="CAPDT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hệ ĐT" DataField="HEDT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngành" DataField="NHOM_CNGANH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chuyên ngành" DataField="CNGANH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Nơi đào tạo" DataField="NOIDT" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Văn bằng" DataField="VB" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hình thức đào tạo" DataField="HINHTHUC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tháng bắt đầu" DataField="THANGD" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tháng kết thúc" DataField="THANGC" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Xếp loại đào tạo" DataField="XEPLOAI" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Loại hợp đồng" DataField="LHD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số hợp đồng" DataField="SO_HD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chức vụ" DataField="CVU" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hệ số phụ cấp" DataField="HSPC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Loại ngạch nhà nước" DataField="LNG" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngạch" DataField="NGACH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Bậc Ngạch" DataField="BAC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hệ số lương nhà nước" DataField="HSO" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Nhóm chức danh CV" DataField="NCD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chức danh công việc" DataField="CDANH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Bậc chức danh công việc" DataField="BCD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hệ số chức danh CV" DataField="HSCD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tổng tiền lương" DataField="TIEN" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tiền lương áp dụng BH" DataField="TIENBH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày kết thúc hợp đồng" DataField="NGAYC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            <%--</div>--%>
                        </td>
                        <td id="GR_lke_td" runat="server" class="css_scrl_td">
                            <khud_scrl:khud_scrl ID="GR_lke_slide" runat="server" loai="L" gridId="GR_lke" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="xem" runat="server" Text="Xem đầy đủ" CssClass="css_button" onclick="return P_EXCEL();form_P_LOI();" Width="100px" />
                                    </td>
                                    <%--<td>
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Chọn mẫu" />
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="mau" runat="Server" kieu="U" Width="150px" CssClass="css_drop" DataTextField="tenbc" DataValueField="ten" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="file" runat="Server" Text="Thêm mẫu" CssClass="css_button" onclick="return ti_ketqua_tk_P_FILES();form_P_LOI();" Width="100px" />
                                    </td>--%>
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
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1010,500" />
    </div>
  
</asp:Content>
