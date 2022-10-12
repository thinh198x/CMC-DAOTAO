<%@ Page Title="ns_td_pd_cdanh_td_ql" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_pd_cdanh_td_ql.aspx.cs" Inherits="f_ns_td_pd_cdanh_td_ql" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt chức danh tuyển dụng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none;">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <div>
                                    <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" ten="Phòng" kt_xoa="X" runat="server" Width="140px"></Cthuvien:DR_lke>
                                    <Cthuvien:ngay ID="NGAYD" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Từ ngày" />
                                    <Cthuvien:ngay ID="NGAYC" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Đến ngày" />
                                </div>
                            </div>
                        </div>

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nam_tk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_pd_cdanh_td_ql_P_KTRA('NAM_TK')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đề xuất TD</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_dx_tk" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TK_TD" runat="server" CssClass="form-control css_list">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang" runat="server" lke="Chờ phê duyệt,Phê duyệt,Không phê duyệt" tra="CPD,PD,KPD" ten="Trạng thái" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" gchu="gchu" kieu_chu="true" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="90px" OnClick="ns_td_pd_cdanh_td_ql_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />

                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" Width="100%" cotAn="SO_ID,mota,ca"
                                cot="SO_ID,CHON,NAM,TEN_MA_DX,SO_THE,HO_TEN,TEN_PHONG,TEN_CDANH,NGAYSINH,NGAYGUI,CV">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="5px" />
                                    <asp:BoundField DataField="SO_ID" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đề xuất tuyển dụng" DataField="TEN_MA_DX" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="SO_THE" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên NV" DataField="HO_TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị/Phòng ban" DataField="TEN_PHONG" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="TEN_CDANH" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày sinh" DataField="NGAYSINH" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày gửi" DataField="NGAYGUI" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Tải xuống CV" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c">
                                        <ItemTemplate>
                                            <Cthuvien:roi ID="CV" runat="server" ToolTip="Tải xuống CV của ứng viên" CssClass="icon-file-excel" Width="100%" Enabled="false" Font-Bold="true" BackColor="#0066ff"
                                                onMouseUp="return ns_td_pd_cdanh_td_ql_P_MO_FILE(event,true);form_P_LOI();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                            <div id="GR_lke_td">
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_pd_cdanh_td_ql_P_LKE()" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Phê duyệt" Width="120px" class="bt_action" anh="K" title="Phê duyệt" OnClick="return ns_td_pd_cdanh_td_ql_P_PHEDUYET('C');form_P_LOI();" />
                        <Cthuvien:nhap ID="thanhly" runat="server" Text="Không phê duyệt" Width="130px" class="bt_action" anh="K" title="Không phê duyệt" OnClick="return ns_td_pd_cdanh_td_ql_P_KOPHEDUYET();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,620" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="an_sothe" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

