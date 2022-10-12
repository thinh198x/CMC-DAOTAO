<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ns_ti_ma_tk.aspx.cs" Inherits="f_ns_ti_ma_tk" Title="ns_ti_ma_tk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <%--<div style="height: 460px; width: 1200px; overflow: scroll">--%>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thông tin thống kê " />
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
                        <td align="center">
                            <div style="height: 460px; width: 1200px; overflow: scroll">
                                <Cthuvien:GridX ID="GR_dk" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                    cot="LOAI_LKE,NHOM,MA,TEN,LOAI,BB,rong,f_tkhao,ktra" hangKt="120" ctrS="nhap" hamUp="ns_ti_ma_tk_GR_Update">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Loại" HeaderStyle-Width="90px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="loai_lke" runat="server" Width="90px" CssClass="css_Gma" kieu_chu="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nhóm" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_nhom" runat="server" Width="120px" CssClass="css_Gma" kieu_chu="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mã" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_ma" runat="server" Width="120px" CssClass="css_Gma" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_ten" runat="server" Width="240px" CssClass="css_Gnd" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loại" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="GR_loai" runat="server" Width="50px" CssClass="css_Gma_c"
                                                    lke="C,H,S,N,T" Text="C" ToolTip="Kiểu:C-Chữ thường, H-Chữ hoa, S-Số, N-Ngày, T-Tháng" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bắt buộc" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="GR_bb" runat="server" Width="50px" CssClass="css_Gma_c"
                                                    lke="C,K" Text="K" ToolTip="Bắt buộc nhập: C-Có, K-Không" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rộng" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_rong" runat="server" Width="50px" CssClass="css_Gma_c" kieu_so="true" ToolTip="Số ký tự" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="f_tkhao" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_f_tkhao" runat="server" Width="300px" CssClass="css_Gma" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ktra" HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="GR_ktra" runat="server" Width="200px" CssClass="css_Gma" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </td>
                    </tr>
                </table>
                <%--</div>--%>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellspacing="1" cellpadding="1" >
                    <tr>
                        <td style="padding-top: 5px">
                            <div class="box3 txRight2">
                                <a href="#" onclick="return ns_ti_ma_tk_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ti_ma_tk_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                            </div>
                        </td>
                        <%--<td>
                            <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" OnClick="return ns_ti_ma_tk_P_NH();form_P_LOI();" />
                        </td>
                        <td>
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ti_ma_tk_P_XOA();form_P_LOI();" />
                        </td>--%>
                        <td>
                            <table cellpadding="0" cellspacing="1" style="height:20px;">
                                <tr>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển hàng lên" onclick="return ns_ti_ma_tk_len();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển hàng xuống" onclick="return ns_ti_ma_tk_xuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img alt="" src="../../images/bitmaps/chen.gif" title="Chèn hàng" onclick="return ns_ti_ma_tk_chen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                        <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_ti_ma_tk_cat();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="padding-top: 5px">
                            <div class="box3 txRight2">
                                <a href="#" onclick="return ns_ti_ma_tk_P_SAN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>hêm mã đã có</a>
                            </div>
                        </td>
                        <%--<td id="td_hien_san">
                            <Cthuvien:nhap ID="hien_san" runat="server" Text="Thêm mã đã có" Width="120px"
                                title="Chọn mã thống kê chương trình đã có" OnClick="return ns_ti_ma_tk_P_SAN();form_P_LOI();" />
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_san" style="position: absolute; top: 50px; left: 70px; border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
        <table cellspacing="1" cellpadding="1">
            <tr id="tr_san">
                <td>
                    <asp:Label ID="Label42" runat="server" CssClass="css_phude" Text="Mã thống kê đã có" />
                </td>
                <td align="right">
                    <img id="dong_san" alt="" src="../../images/bitmaps/dong.png" onclick="return ns_ti_ma_tk_DONG();" />
                </td>
            </tr>
            <tr>
                <td>
                    <Cthuvien:GridX ID="GR_san" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L" hangKt="10">
                        <Columns>
                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                            <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                            <asp:BoundField HeaderText="Loại" DataField="loai" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                        </Columns>
                    </Cthuvien:GridX>
                </td>
            </tr>
            <tr>
                <td>
                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="70px" OnClick="return ns_ti_ma_tk_P_CHON();form_P_LOI();" />
                </td>
            </tr>
        </table>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1170,600" />
</asp:Content>
