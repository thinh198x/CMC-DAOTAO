var b_vuId, b_chId, b_vungId, b_moId, b_vtriY = 0, b_luuId, b_dongId, b_tmucId, b_tenId, b_ma_dviId, b_fileMau, file_import_lkeCho;
function khud_Excel_import_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct2');
    b_filemau = form_Fs_VTEN_ID(b_vungId, 'Nhap2');
    form_P_LOI('');
    file_import_lkeCho = setInterval('file_import_P_LKE_CHO()', 200);
}
function thongbao(b_kq) {
    form_P_LOI(b_kq); return false;
}
function file_import_P_LKE_CHO() {
    form_P_LOI(''); return false;
    clearTimeout(file_import_lkeCho); return false; 
}
function khud_Excel_Import_File_mau() {
    __doPostBack('ctl00$ContentPlaceHolder1$nhap1', '');
}
function khud_Excel_Import_Import() {
    __doPostBack('ctl00$ContentPlaceHolder1$nhap', '');
}