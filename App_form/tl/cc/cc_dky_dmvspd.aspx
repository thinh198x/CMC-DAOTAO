<%@ Page Title="cc_dky_dmvspd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_dky_dmvspd.aspx.cs" Inherits="f_cc_dky_dmvspd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt thông tin đi muộn về sớm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại đăng ký</span>
                            <div class="input-group">
                                <div style="display: none">
                                    <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" ten="Phòng" kt_xoa="X" runat="server" Width="140px"></Cthuvien:DR_lke>
                                    <Cthuvien:ngay ID="NGAYD" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Từ ngày" />
                                    <Cthuvien:ngay ID="NGAYC" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Đến ngày" />
                                </div>
                                <Cthuvien:DR_list ID="loai_dky_tk" ten="Loại đăng ký" CssClass="form-control css_list" runat="server" lke=",Đăng ký đi muộn,Đăng ký về sớm" tra=",DM,VS" kt_xoa="X" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang" ten="Loại đăng ký" CssClass="form-control css_list" runat="server" lke="Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra="0,1,2" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" gchu="gchu" /> 
                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" class="bt_action" anh="K" runat="server" Text="Tìm kiếm" Width="90px" OnClick="cc_dky_dmvspd_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" Width="100%" cotAn="SO_ID"
                                cot="SO_ID,chon,MA_NV,HO_TEN,TEN_CDANH,TEN_PHONG,NGAY_DKY,LOAI_DKY,giod,gioc,sophut,GCHU,LYDO_LD">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="5px" />
                                    <asp:BoundField DataField="SO_ID" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã NV" DataField="MA_NV" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên NV" DataField="ho_ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="TEN_CDANH" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày đăng ký" DataField="NGAY_DKY" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại đăng ký" DataField="LOAI_DKY" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ giờ" DataField="giod" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến giờ" DataField="gioc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số phút" DataField="SOPHUT" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Lý do đi muộn về sớm" DataField="GCHU" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                    <asp:TemplateField HeaderText="Lý do KPD(*)" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="LYDO_LD" runat="server" Width="200px" CssClass="css_Gma"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>

                        </div>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_dky_dmvspd_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" class="bt_action" anh="K" runat="server" Text="Phê duyệt" Width="120px" title="Phê duyệt" OnClick="return cc_dky_dmvspd_P_PHEDUYET('C');form_P_LOI();" />
                        <Cthuvien:nhap ID="thanhly" class="bt_action" anh="K" runat="server" Text="Không phê duyệt" Width="130px" title="Không phê duyệt" OnClick="return cc_dky_dmvspd_P_KOPHEDUYET();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1280,590" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="phongc" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

