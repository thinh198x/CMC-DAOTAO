<%@ Page Title="ns_dt_phieu_ks" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_phieu_ks.aspx.cs" Inherits="f_ns_dt_phieu_ks" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phiếu khảo sát" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Liệt kê</span>
                        <div class="input-group">
                            <Cthuvien:DR_nhap ID="lke" runat="server" CssClass="css_form" kieu="S" Width="120px" onchange="ns_dt_phieu_ks_P_KTRA('LKE')">
                                   <asp:ListItem Text="Đang khảo sát" Value="1" Selected="True"></asp:ListItem>
                                   <asp:ListItem Text="Đã kết thúc" Value="2"></asp:ListItem>
                            </Cthuvien:DR_nhap>
                           <%-- <Cthuvien:DR_list ID="lke" runat="server" CssClass="form-control css_list" ten="Liệt kê"
                                tra="1,2" lke="Đang khảo sát,Đã kết thúc" kt_xoa="X" onchange="ns_dt_phieu_ks_P_KTRA('LKE')" />--%>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_phieu_ks_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="50%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="tu_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="den_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_phieu_ks_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left col_15">Đợt khảo sát</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="dot" ten="Đợt khảo sát" runat="server" CssClass="form-control css_list" kieu="S" kt_xoa="X" ktra="DT_DOTKS"/>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" Enabled="false" ReadOnly="true"
                                    CssClass="form-control css_ma" onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" ten="Họ Tên nhân viên" kt_xoa="K" Enabled="false" ReadOnly="true"
                                    runat="server" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" kt_xoa="K" ten="Phòng ban" Enabled="false" ReadOnly="true" runat="server"
                                    CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày gửi phiếu<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_GUI" runat="server" ten="Ngày gửi phiếu"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cotAn="ma_nhucau,hinhthuc"
                                cot="ma_nhucau,TEN_NHUCAU,hinhthuc,ten_hinhthuc,NTHOI_DIEM_TG,ghichu"
                                hangKt="10" ctrT="so_tt" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_nhucau" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhu cầu đào tạo" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <%--<Cthuvien:ma ID="ten_nhucau" runat="server" Width="120px" CssClass="css_Gma" />--%>
                                             <Cthuvien:DR_lke ID="ten_nhucau" ktra="DT_NCDT" runat="server" CssClass="css_Glist" Width="100%" ten="Nhu cầu đào tạo"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="hinhthuc" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Hình thức đào tạo phù hợp" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_hinhthuc" kieu_chu="true" placeholder="Nhấn (F1)" runat="server" Width="160px" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" ktra="ns_ma_htdt,ma,ten" ReadOnly="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thời điểm có thể tham gia" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NTHOI_DIEM_TG" runat="server" Width="120px" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" Width="120px" CssClass="css_Gnd" kt_xoa="G"
                                                kieu_luu="S" ten="Thời điểm tham gia" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_phieu_ks_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_phieu_ks_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_phieu_ks_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_phieu_ks_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_phieu_ks_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_phieu_ks_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_phieu_ks_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,680" />
    </div>
</asp:Content>
