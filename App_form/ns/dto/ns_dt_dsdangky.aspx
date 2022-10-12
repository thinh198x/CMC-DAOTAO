<%@ Page Title="ns_dt_dsdangky" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_dsdangky.aspx.cs" Inherits="f_ns_dt_dsdangky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách khóa học" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã khóa học</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã lớp học" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                    BackColor="#f6f7f7" ktra="ns_dt_taokh,ma,ten" f_tkhao="~/App_form/ns/dt/ns_dt_taokh.aspx"
                                    onchange="ns_dt_dsdangky_P_KTRA('MA')" kt_xoa="G" placeholder="Nhấn (F1)" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Giới hạn học viên</span>
                            <div class="input-group">
                                <Cthuvien:ma runat="server" ID="gioihan" ten="Giới hạn học viên" CssClass="form-control css_ma"
                                    ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đã đăng ký</span>
                            <div class="input-group">
                                <Cthuvien:ma runat="server" ID="dangky" ten="Đã đăng ký" CssClass="form-control css_ma" ReadOnly="true"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" cot="so_the,ten,phong,cv_chinh,tinhtrang">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Công việc" DataField="cv_chinh" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="70px" class="bt_action" anh="K" Text="Xem" OnClick="return ns_dt_dsdangky_P_XEM();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Phê duyệt" OnClick="return ns_dt_dsdangky_P_PHEDUYET();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="120px" class="bt_action" anh="K" Text="Hủy phê duyệt" OnClick="return ns_dt_dsdangky_P_HUYPHEDUYET();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,700" />
    </div>
</asp:Content>
