<%@ Page Title="ns_dt_caidat_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_caidat_pd.aspx.cs" Inherits="f_ns_dt_caidat_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập phê duyệt" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner">
                    <div class="col_2_iterm width_common" id="UPa_ct" style="padding-bottom: 15px">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_10">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="dvi" ktra="DT_PH" ten="Phòng" runat="server" CssClass="form-control css_list" kieu="S" Width="200px" onchange="ns_dt_caidat_pd_P_CHUYEN_HANG()" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Loại phê duyệt</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="loai" ToolTip="Loại phê duyệt" runat="server" Width="400px" CssClass="form-control"
                                    onchange="ns_dt_caidat_pd_P_LKE_CHO();">
                                    <asp:ListItem Text="Phê duyệt đề xuất đào tạo" Value="DX" />
                                    <asp:ListItem Text="Phê duyệt danh sách khóa đào tạo" Value="KDT" />
                                    <asp:ListItem Text="Phê duyệt danh sách đăng ký khóa học" Value="DKKH" />
                                    <asp:ListItem Text="Phê duyệt đề xuất tuyển dụng" Value="DXTD" />
                                    <asp:ListItem Text="Phê duyệt nghỉ phép" Value="DXN" />
                                    <asp:ListItem Text="Phê duyệt đăng ký ca làm việc con nhỏ dưới 1 tuổi" Value="DKCNCN" />
                                    <asp:ListItem Text="Phê duyệt đăng ký làm việc ngoài công ty" Value="DKLVNCT" />
                                    <asp:ListItem Text="Phê duyệt xin làm thêm giờ" Value="OT" />
                                    <asp:ListItem Text="Phê duyệt đi muộn về sớm" Value="DMVS" />
                                    <asp:ListItem Text="Phê duyệt giải trình chấm công" Value="GTCC" /> 

                                    <%--<asp:ListItem Text="Phê duyệt chỉ tiêu đánh giá tháng" Value="CTCV" />
                                    <asp:ListItem Text="Phê duyệt đánh giá kết quả thực hiện công việc hàng tháng" Value="CVHT" />
                                    <asp:ListItem Text="Phê duyệt nội bộ đánh giá" Value="NBDG" />
                                    <asp:ListItem Text="Phê duyệt chỉ tiêu KPI" Value="CTKPI" /> --%>
                                    <%--<asp:ListItem Text="Phê duyệt giải trình timesheet" Value="GTTS" />--%>
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="N" cot="so_the,ten,phong,ten_phong,email,lan,loai_pd,so_ngay" cotAn="phong,email" hangKt="18"
                                hamUp="ns_dt_caidat_pd_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                onchange="ns_dt_caidat_pd_P_KTRA('SO_THE')" kieu_chu="true" ToolTip="Nhập mã nhân viên" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ten"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="email" Enabled="false" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cấp phê duyệt">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="lan" ten="Cấp phê duyệt" Height="21px" Width="100%" runat="server" CssClass="css_Gma">
                                                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Cấp 1" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cấp 2" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Cấp 3" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Cấp 4" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Cấp 5" Value="4"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loại phê duyệt">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="loai_pd" ten="Loại phê duyệt" Height="21px" Width="100%" runat="server" CssClass="css_Gma">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Nhân viên" Value="NV"></asp:ListItem>
                                                <asp:ListItem Text="Quản lý" Value="QL"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số ngày được duyệt">
                                        <ItemTemplate>
                                            <Cthuvien:so so_tp="2" ID="so_ngay" runat="server" CssClass="css_Gma_r" kieu_so="true" MaxLength="3" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_caidat_pd_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_caidat_pd_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_caidat_pd_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_caidat_pd_ChenDong();" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Class="bt_action" anh="K" OnClick="return ns_dt_caidat_pd_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Class="bt_action" anh="K" OnClick="return ns_dt_caidat_pd_P_XOA();form_P_LOI('');" Width="70px" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1160,580" />
    </div>
</asp:Content>
