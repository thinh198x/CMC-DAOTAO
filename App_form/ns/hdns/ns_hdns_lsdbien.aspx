<%@ Page Title="ns_hdns_lsdbien" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_lsdbien.aspx.cs" Inherits="f_ns_hdns_lsdbien" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar"> 
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Định biên nhân sự" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>

            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="donvi,so_id"  hamRow="ns_hdns_lsdbien_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phongban_ct" HeaderStyle-Width="400px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày thay đổi" DataField="ngay_nh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Người điều chỉnh" DataField="ten_nsd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="donvi" DataField="donvi" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_lsdbien_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="grid_table width_common">
                        <div style="height: 600px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" hamUp="hsns_dinhbien_ns_tinh" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N"
                                CssClass="table gridX" hangKt="100" cotAn="cdanh,so_id" Width="100%"
                                cot="cdanh,ten_cdanh,ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12,SO_ID">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chức danh" ItemStyle-Wrap="true" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <%--<Cthuvien:DR_lke ID="cdanh" Wrap="true" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>--%>
                                            <Cthuvien:ma ID="cdanh" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" ItemStyle-Wrap="true" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <%--<Cthuvien:DR_lke ID="cdanh" Wrap="true" runat="server" CssClass="css_Glist" Width="100%" ktra="ns_cdanh_P_LIST()" kt_xoa="X"></Cthuvien:DR_lke>--%>
                                            <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_Gma" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhân sự hiện tại tính đến 31/12 năm trước" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ns_hientai" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Định biên ban đầu T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dinhbien_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng phát sinh T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phatsinh_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T1" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t1" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T2" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t2" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T3" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t3" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T4" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t4" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T5" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t5" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T6" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_T6" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T7" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t7" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T8" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t8" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T9" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t9" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T10" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t10" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T11" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t11" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng định biên T12" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tong_t12" runat="server" CssClass="css_Gso" Width="100%" kieu_so="true" MaxLength="4" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,650" />
    </div>
</asp:Content>
