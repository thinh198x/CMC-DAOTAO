
/
create or replace procedure PHD_MA_BNNGHE_XEM(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma_nnnghe varchar2,cs_lke out pht_type.cs_type,b_ma varchar2:='')
AS
    b_loi varchar2(100);
begin
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'KT','KT','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select a.*,FHD_MA_NNNGHE_TEN(b_ma_dvi, a.ma_nnnghe) ten_ma_nnnghe,row_number() over (order by ma_nnnghe,ma_nngiep,cap_bac) sott from hd_ma_bnnghe a
    where ma_dvi=b_ma_dvi and (b_ma_nnnghe is null or ma_nnnghe like b_ma_nnnghe) order by ma_nnnghe,ma_nngiep,cap_bac;
end;
/
create or replace procedure PHD_MA_BNNGHE_LKE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_mannnghe varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);b_tu number:=b_tu_n;b_den number:=b_den_n;
begin
--  Liet ke ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_mannnghe;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select so_id,ma_nnnghe,ma_nngiep,cap_bac,FHD_MA_NNNGHE_TEN(b_ma_dvi, ma_nnnghe) ten_ma_nnnghe,tt,ghichu,nsd,row_number() over (order by  ma_nngiep) sott from hd_ma_bnnghe
    where ma_dvi=b_ma_dvi and ma_nnnghe=b_mannnghe order by  ma_nnnghe,ma_nngiep,cap_bac) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure PHD_MA_BNNGHE_MA_NNGIEP_LKE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_mannnghe varchar2,b_manngiep varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);b_tu number:=b_tu_n;b_den number:=b_den_n;
begin
--  Liet ke ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_mannnghe and ma_nngiep=b_manngiep;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select so_id,ma_nnnghe,ma_nngiep,cap_bac,FHD_MA_NNNGHE_TEN(b_ma_dvi, ma_nnnghe) ten_ma_nnnghe,tt,ghichu,nsd,row_number() over (order by  ma_nngiep) sott from hd_ma_bnnghe
    where ma_dvi=b_ma_dvi and ma_nnnghe=b_mannnghe and ma_nngiep=b_manngiep order by ma_nnnghe,ma_nngiep,cap_bac) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure PHD_MA_BNNGHE_MA(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnnghe varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number; b_den number;
begin
--  Xem Ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_ma_nnnghe is null then b_loi:='loi:Nhap loai nghe:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe;
select nvl(min(sott),b_dong) into b_tu from (select ma_nnnghe,row_number() over (order by ma_nnnghe) sott
    from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe order by ma_nnnghe) where ma_nnnghe=b_ma_nnnghe;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from
    (select so_id,ma_nnnghe,ma_nngiep,cap_bac,FHD_MA_NNNGHE_TEN(b_ma_dvi, ma_nnnghe) ten_ma_nnnghe,tt,ghichu,nsd,row_number() over (order by ma_nngiep) sott from hd_ma_bnnghe
        where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe order by ma_nnnghe,ma_nngiep) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure PHD_MA_BNNGHE_MA_CAP_BAC(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnnghe varchar2,b_ma_nngiep varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number; b_den number;
begin
--  Xem Ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_ma_nnnghe is null then b_loi:='loi:Nhap loai nghe:loi'; raise PROGRAM_ERROR; end if;
if b_ma_nngiep is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe and ma_nngiep=b_ma_nngiep;
select nvl(min(sott),b_dong) into b_tu from (select ma_nngiep,row_number() over (order by ma_nngiep) sott
    from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe and ma_nngiep=b_ma_nngiep order by ma_nngiep) 
        where ma_nngiep>=b_ma_nngiep;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select so_id,ma_nnnghe,ma_nngiep,cap_bac,FHD_MA_NNNGHE_TEN(b_ma_dvi, ma_nnnghe) ten_ma_nnnghe,tt,ghichu,nsd,row_number() over (order by ma_nngiep) sott from hd_ma_bnnghe
    where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe and ma_nngiep=b_ma_nngiep order by ma_nnnghe,ma_nngiep,cap_bac) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/


/

/
create or replace procedure PHD_MA_BNNGHE_NH(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnnghe varchar2,b_ma_nngiep varchar2,b_cap_bac varchar2,b_tt varchar2,b_ghichu varchar2)
AS
    b_loi varchar2(100); b_idvung number; b_i1 number; b_so_id number;
begin
--  Nhap ma chuyen mon chi tiet
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma_nnnghe) is null then b_loi:='loi:Nhap ma ngach nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ma_nngiep) is null then b_loi:='loi:Nhap ma cap bac nghe nhiep:loi'; raise PROGRAM_ERROR; end if;
if trim(b_cap_bac) is null then b_loi:='loi:Nhap cap bac nghe nhiep:loi'; raise PROGRAM_ERROR; end if;
begin
select so_id into b_so_id from hd_ma_bnnghe 
    where ma_dvi=b_ma_dvi and ma_nnnghe = b_ma_nnnghe and ma_nngiep=b_ma_nngiep and nvl(so_id,0) >0;
EXCEPTION
when others then
PHT_ID_MOI(b_so_id,b_loi);
end;
delete hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe = b_ma_nnnghe and ma_nngiep=b_ma_nngiep;
insert into hd_ma_bnnghe values(b_ma_dvi,b_so_id,b_ma_nnnghe,b_ma_nngiep,b_cap_bac,b_tt,b_ghichu,sysdate,b_nsd,b_idvung);
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;

create or replace procedure PHD_MA_BNNGHE_XOA(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnnghe varchar2,b_ma_nngiep varchar2,b_cap_bac varchar2)
as
    b_loi varchar2(100);b_i1 number;
begin
--  Xoa ma chuyen mon chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma_nnnghe) is null then b_loi:='loi:Chon ma chuyen mon:loi'; raise PROGRAM_ERROR; end if;
delete hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe = b_ma_nnnghe and ma_nngiep=b_ma_nngiep;
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;


