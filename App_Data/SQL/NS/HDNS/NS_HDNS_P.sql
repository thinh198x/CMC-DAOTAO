create or replace procedure PNS_HDNS_MA_NN_XOA(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2)
AS
b_loi varchar2(100);
BEGIN
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Chon ma nganh nghe:loi'; raise PROGRAM_ERROR; end if;
delete ns_hdns_ma_nn where ma_dvi=b_ma_dvi and ma=b_ma;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_CT(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,cs_1 out pht_type.cs_type)
AS
b_loi varchar2(100);b_idvung number;
BEGIN
if b_loi is not null then raise PROGRAM_ERROR; end if;
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
open cs_1 for select t.* from ns_hdns_ma_nn t where t.ma=b_ma;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_LKE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
       b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
b_loi varchar2(100); b_tu number:=b_tu_n;b_den number:=b_den_n;
BEGIN
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
select count(*) into b_dong from ns_hdns_ma_nn where ma_dvi=b_ma_dvi;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select ma,ten,tt,ghichu,nsd,row_number() over (order by ma) sott from ns_hdns_ma_nn
where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_NH(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
       b_ma varchar2,b_ten nvarchar2,b_tt varchar2,b_ghichu varchar2)
AS
b_loi varchar2(100); b_idvung number;
BEGIN
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Nhap ma nganh nghe:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ten) is null then b_loi:='loi:Phai nhap ten nganh nghe:loi'; raise PROGRAM_ERROR; end if;
if b_tt not in ('N','A') then b_loi:='loi:Sai trang thai '||b_tt||':loi'; raise PROGRAM_ERROR; end if;
b_loi:='loi:Va cham NSD:loi';
delete ns_hdns_ma_nn where ma_dvi=b_ma_dvi and ma=b_ma;
insert into ns_hdns_ma_nn values (b_ma_dvi,b_ma,b_ten,b_tt,b_ghichu,sysdate,b_nsd,b_idvung);
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_XEM(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2, cs_lke out pht_type.cs_type)
AS
b_loi varchar2(100);
BEGIN
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
open cs_lke for select t.ma,t.ten from ns_hdns_ma_nn t where ma_dvi= b_ma_dvi order by t.ma,t.ten;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_MA(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
       b_ma varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS 
b_loi varchar2(100); b_tu number; b_den number;
BEGIN
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_ma is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from ns_hdns_ma_nn where ma_dvi=b_ma_dvi;
select nvl(min(sott),b_dong) into b_tu from (select ma,row_number() over (order by ma) sott
       from ns_hdns_ma_nn where ma_dvi=b_ma_dvi order by ma) where ma>=b_ma;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select t.*,row_number() over (order by ma) sott from ns_hdns_ma_nn t
where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
create or replace procedure PNS_HDNS_MA_NN_EXCEL(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2, cs_lke out pht_type.cs_type)
AS
b_loi varchar2(100);
BEGIN
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
open cs_lke for select t.*,row_number() over(order by t.ma,t.ten) sott from ns_hdns_ma_nn t where ma_dvi= b_ma_dvi;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
END;
/
