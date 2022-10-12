create or replace procedure PNS_MA_CDANH_XEM(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnghe varchar2,b_ma_cmon varchar2,b_ma_nnnghe varchar2,b_cap_bac varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'KT','KT','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select a.*,FHD_MA_NNGHE_TEN(b_ma_dvi,a.ma_nnghe) ten_ma_nnghe,FHD_MA_NNNGHE_TEN(b_ma_dvi, a.ma_nnnghe) ten_ma_nnnghe,
    FHD_MA_CMON_TEN(b_ma_dvi,ma_cmon,ma_nnghe) ten_cmon,FHD_MA_CBAC_TEN(b_ma_dvi,ma_nnnghe,ma_capbac) ten_ma_capbac,row_number() over (order by ma_nnghe,ma_cmon,ma_nnnghe,ma_capbac) sott from hd_ma_cdanh a
    where ma_dvi=b_ma_dvi  and (b_ma_nnghe is null or ma_nnghe like b_ma_nnghe)and (b_ma_cmon is null or ma_cmon like b_ma_cmon)
        and (b_ma_nnnghe is null or ma_nnnghe like b_ma_nnnghe) order by ma_nnghe,ma_cmon,ma_nnnghe,ma_capbac;
end;
/
create or replace function FHD_MA_CBAC_TEN(b_ma_dvi varchar2,b_ma_nnnghe varchar2,b_ma_nngiep varchar2) return nvarchar2
AS
    b_kq nvarchar2(255);
begin
select min(cap_bac) into b_kq from hd_ma_bnnghe where ma_dvi=b_ma_dvi and ma_nnnghe=b_ma_nnnghe and ma_nngiep=b_ma_nngiep;
return b_kq;
end;

/
create or replace procedure PNS_MA_CDANH_CT(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma chuc danh chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select * from hd_ma_cdanh where ma_dvi=b_ma_dvi and ma=b_ma;
end;
///////////

create or replace procedure PNS_MA_CDANH_LKE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnghe varchar2,b_ma_cmon varchar2,b_ma_nnnghe varchar2,b_cap_bac varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
 b_loi varchar2(100);b_tu number:=b_tu_n;b_den number:=b_den_n;
begin
--  Liet ke ma chuc danh
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_cdanh 
    where ma_dvi=b_ma_dvi and (b_ma_nnghe is null or ma_nnghe like b_ma_nnghe)and (b_ma_cmon is null or ma_cmon like b_ma_cmon)
        and (b_ma_nnnghe is null or ma_nnnghe like b_ma_nnnghe)and (b_cap_bac is null or ma_capbac like b_cap_bac);
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select so_id,ma_nnghe,ma_cmon,ma_nnnghe,ma_capbac,ma,ten,tt,ghichu,pduyet,nsd,row_number() over (order by ma) sott from hd_ma_cdanh
    where ma_dvi=b_ma_dvi and (b_ma_nnghe is null or ma_nnghe like b_ma_nnghe)and (b_ma_cmon is null or ma_cmon like b_ma_cmon)
        and (b_ma_nnnghe is null or ma_nnnghe like b_ma_nnnghe) order by ma) where sott between b_tu and b_den;
end;
/

/
create or replace procedure PNS_MA_CDANH_MA
    (b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnghe varchar2,b_ma_cmon varchar2,b_ma_nnnghe varchar2,b_cap_bac varchar2,b_ma varchar2,
    b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number; b_den number;
begin
--  Xem ma chuc danh
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
--if b_ma is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_cdanh where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe and ma_capbac=b_cap_bac;
select nvl(min(sott),b_dong) into b_tu from (select ma,row_number() over (order by ma) sott
    from hd_ma_cdanh where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe and ma_capbac=b_cap_bac order by ma) where ma>=b_ma;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select so_id,ma_nnghe,ma_cmon,ma_nnnghe,ma_capbac,ma,ten,tt,ghichu,pduyet,nsd,row_number() over (order by ma) sott from hd_ma_cdanh
    where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;


//////////////
create or replace procedure PNS_MA_CDANH_NH(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
   b_ma_nnghe varchar2,b_ma_cmon varchar2,b_ma_nnnghe varchar2,b_cap_bac varchar2,b_ma varchar2,b_ten varchar2,b_tt varchar2,b_ghichu varchar2,b_pduyet varchar2)
AS
    b_loi varchar2(100);b_idvung number;b_i1 number;b_so_id number;
begin
--  Nhap ma chuc danh chi tiet
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma_nnghe) is null then b_loi:='loi:Nhap ma nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ma_cmon) is null then b_loi:='loi:Nhap ma chuyen mon:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ma_nnnghe) is null then b_loi:='loi:Nhap ma ngach nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
if trim(b_cap_bac) is null then b_loi:='loi:Nhap cap bac nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
begin
select so_id into b_so_id from hd_ma_cdanh
    where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe and ma_capbac=b_cap_bac and ma=b_ma and nvl(so_id,0) >0;
EXCEPTION
when others then
PHT_ID_MOI(b_so_id,b_loi);
end;
delete hd_ma_cdanh where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe and ma_capbac=b_cap_bac and ma=b_ma;
insert into hd_ma_cdanh values(b_ma_dvi,b_so_id,b_ma_nnghe,b_ma_cmon,b_ma_nnnghe,b_cap_bac,b_ma,b_ten,b_tt,b_ghichu,b_pduyet,sysdate,b_nsd,b_idvung);
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;


/////////////////////////

/

create or replace procedure PNS_MA_CDANH_XOA(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma_nnghe varchar2,b_ma_cmon varchar2,b_ma_nnnghe varchar2,b_ma_capbac varchar2,b_ma varchar2)
AS
    b_loi varchar2(100); b_i1 number;
begin
--  Xoa ma chuc danh chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Chon ma :loi'; raise PROGRAM_ERROR; end if;
delete hd_ma_cdanh where ma_dvi=b_ma_dvi and ma_nnghe = b_ma_nnghe and ma_cmon=b_ma_cmon and ma_nnnghe=b_ma_nnnghe and ma_capbac=b_ma_capbac and ma=b_ma;
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/

