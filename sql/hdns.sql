create or replace procedure hd_ma_nnghe_ct(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma nganh nghe chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select * from hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma;
end;
/
create or replace procedure hd_ma_nnghe_lke(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number:=b_tu_n; b_den number:=b_den_n;
begin
--  Liet ke ma nganh nghe
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_nnghe where ma_dvi=b_ma_dvi;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select ma,ten,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_nnghe
    where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
end;
/
create or replace procedure PHD_MA_NNGHE_MA_TENNGHE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma chuyen mon chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select ma,ten  from hd_ma_nnghe where ma_dvi=b_ma_dvi;
end;
/
/
create or replace procedure hd_ma_nnghe_ma(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number; b_den number;
begin
--  Xem Ma nganh nghe
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_ma is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_nnghe where ma_dvi=b_ma_dvi;
select nvl(min(sott),b_dong) into b_tu from (select ma,row_number() over (order by ma) sott
    from hd_ma_nnghe where ma_dvi=b_ma_dvi order by ma) where ma>=b_ma;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select ma,ten,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_nnghe
    where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure hd_ma_nnghe_xem(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,cs_lke out pht_type.cs_type,b_ma varchar2:='')
AS
    b_loi varchar2(100);
begin
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'KT','KT','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
if b_ma is null then
    open cs_lke for select * from hd_ma_nnghe where ma_dvi=b_ma_dvi order by ma;
else open cs_lke for select * from hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma;
end if;
end;
/
create or replace procedure hd_ma_nnghe_nh(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,b_ten nvarchar2,b_tt varchar2,b_ghichu varchar2)
AS
    b_loi varchar2(100); b_c1 varchar2(1); b_c2 varchar2(2); b_i1 number; b_idvung number;
begin
--  Nhap ma nganh nghe chi tiet
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Nhap ma nganh nghe:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ten) is null then b_loi:='loi:Phai nhap ten nganh nghe:loi'; raise PROGRAM_ERROR; end if;
if b_tt not in ('N','A') then b_loi:='loi:Sai trang thai '||b_tt||':loi'; raise PROGRAM_ERROR; end if;
b_loi:='loi:Va cham NSD:loi';
delete hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma;
insert into hd_ma_nnghe values (b_ma_dvi,b_ma,b_ten,b_tt,b_ghichu,sysdate,b_nsd,b_idvung);
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure hd_ma_nnghe_xoa(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2)
AS
    b_loi varchar2(100); b_i1 number;
begin
--  Xoa ma nganh nghe chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Chon ma nganh nghe:loi'; raise PROGRAM_ERROR; end if;
delete hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma;
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/////////////////////////////////////////////////////////////////
create or replace procedure hd_ma_cmon_ct(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma chuyen mon chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select * from hd_ma_cmon where ma_dvi=b_ma_dvi and ma=b_ma;
end;
/
create or replace function FHD_MA_CMON_TEN(b_ma_dvi varchar2,b_ma varchar2,b_ma_nnghe varchar2) return nvarchar2
AS
    b_kq nvarchar2(255);
begin
select min(ten) into b_kq from hd_ma_cmon where ma_dvi=b_ma_dvi and ma=b_ma and ma_nnghe=b_ma_nnghe;
return b_kq;
end;
/
create or replace procedure PHD_MA_CMON_MA_TENNGHE(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma chuyen mon chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select ma_nnghe,FHD_MA_NNGHE_TEN(b_ma_dvi, ma_nnghe) ten_nnghe  from hd_ma_cmon where ma_dvi=b_ma_dvi;
end;
/
create or replace function FHD_MA_NNGHE_TEN(b_ma_dvi varchar2,b_ma varchar2) return nvarchar2
AS
    b_kq nvarchar2(255);
begin
select min(ten) into b_kq from hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma;
return b_kq;
end;
/
create or replace procedure hd_ma_cmon_lke(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_mannghe varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);b_tu number:=b_tu_n;b_den number:=b_den_n;
begin
--  Liet ke ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_cmon where ma_dvi=b_ma_dvi and ma_nnghe=b_mannghe;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select so_id,ma,ten,ma_nnghe,FHD_MA_NNGHE_TEN(b_ma_dvi, ma_nnghe) ten_ma_nnghe,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_cmon
    where ma_dvi=b_ma_dvi and ma_nnghe=b_mannghe order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/

create or replace procedure hd_ma_cmon_ma(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_mannghe varchar2,b_ma varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100); b_tu number; b_den number;
begin
--  Xem Ma chuyen mon
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_mannghe is null then b_loi:='loi:Nhap loai nghe:loi'; raise PROGRAM_ERROR; end if;
if b_ma is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_cmon where ma_dvi=b_ma_dvi and ma_nnghe=b_mannghe;
select nvl(min(sott),b_dong) into b_tu from (select ma,row_number() over (order by ma) sott
    from hd_ma_cmon where ma_dvi=b_ma_dvi and ma_nnghe=b_mannghe order by ma) where ma>=b_ma;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select so_id,ma,ten,ma_nnghe,FHD_MA_NNGHE_TEN(b_ma_dvi, ma_nnghe) ten_ma_nnghe,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_cmon 
    where ma_dvi=b_ma_dvi and ma_nnghe=b_mannghe order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure hd_ma_cmon_xem(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,cs_lke out pht_type.cs_type,b_ma varchar2:='')
AS
    b_loi varchar2(100);
begin
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'KT','KT','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
if b_ma is null then
    open cs_lke for select a.*,FHD_MA_NNGHE_TEN(b_ma_dvi, a.ma_nnghe) ten_ma_nnghe,row_number() over (order by ma) sott from hd_ma_cmon a
        where ma_dvi=b_ma_dvi and (b_ma_nnghe is null or ma_nnghe like b_ma_nnghe)  order by ma;
else    open cs_lke for select * from hd_ma_cmon where ma_dvi=b_ma_dvi and ma=b_ma;
end if;
end;
/
create or replace procedure hd_ma_cmon_nh
    (b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,b_ten nvarchar2,b_ma_nnghe varchar2,b_tt varchar2,b_ghichu varchar2)
AS
    b_loi varchar2(100); b_idvung number; b_i1 number; b_so_id number;
begin
--  Nhap ma chuyen mon chi tiet
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Nhap ma chuyen mon:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ten) is null then b_loi:='loi:Phai nhap ten chuyen mon:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_i1 from hd_ma_nnghe where ma_dvi=b_ma_dvi and ma=b_ma_nnghe;
if b_i1<>1 then b_loi:='loi:Sai ma nganh nghe '||b_ma_nnghe||':loi'; raise PROGRAM_ERROR; end if;
if b_tt not in ('N','A') then b_loi:='loi:Sai trang thai '||b_tt||':loi'; raise PROGRAM_ERROR; end if;
b_loi:='loi:Va cham NSD:loi';
begin
select so_id into b_so_id from hd_ma_cmon where ma_dvi=b_ma_dvi and ma=b_ma and ma_nnghe = b_ma_nnghe and nvl(so_id,0) >0;
EXCEPTION
when others then
PHT_ID_MOI(b_so_id,b_loi);
end;
delete hd_ma_cmon where ma_dvi=b_ma_dvi and ma=b_ma and ma_nnghe = b_ma_nnghe;
insert into hd_ma_cmon values (b_ma_dvi,b_so_id,b_ma,b_ten,b_ma_nnghe,b_tt,b_ghichu,sysdate,b_nsd,b_idvung);
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/
create or replace procedure hd_ma_cmon_xoa(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma_nnghe varchar2,b_ma varchar2)
as
    b_loi varchar2(100);b_i1 number;
begin
--  Xoa ma chuyen mon chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Chon ma chuyen mon:loi'; raise PROGRAM_ERROR; end if;
delete hd_ma_cmon where ma_dvi=b_ma_dvi and ma_nnghe=b_ma_nnghe and ma=b_ma;
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
////////////////////////////////////
create or replace procedure hd_ma_nnnghe_ct(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);
begin
--  Xem ma ngach nghe nghiep chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
open cs_lke for select * from hd_ma_nnnghe where ma_dvi=b_ma_dvi and ma=b_ma;
end;
/
create or replace procedure hd_ma_nnnghe_lke(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_tu_n number,b_den_n number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);b_tu number:=b_tu_n;b_den number:=b_den_n;
begin
--  Liet ke ma  ngach nghe nghiep
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
select count(*) into b_dong from hd_ma_nnnghe where ma_dvi=b_ma_dvi;
PKH_LKE_TRANG(b_dong,b_tu,b_den);
open cs_lke for select * from (select ma,ten,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_nnnghe
    where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
end;
/
create or replace procedure hd_ma_nnnghe_ma(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,
    b_ma varchar2,b_trangkt number,b_trang out number,b_dong out number,cs_lke out pht_type.cs_type)
AS
    b_loi varchar2(100);b_tu number;b_den number;
begin
--  Xem Ma ngach nghe nghiep
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','MNX');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if b_ma is null then b_loi:='loi:Nhap ma:loi'; raise PROGRAM_ERROR; end if;
select count(*) into b_dong from hd_ma_nnnghe where ma_dvi=b_ma_dvi;
select nvl(min(sott),b_dong) into b_tu from (select ma,row_number() over (order by ma) sott
    from hd_ma_nnnghe where ma_dvi=b_ma_dvi order by ma) where ma>=b_ma;
PKH_LKE_VTRI(b_trangkt,b_tu,b_den,b_trang);
open cs_lke for select * from (select ma,ten,tt,ghichu,nsd,row_number() over (order by ma) sott from hd_ma_nnnghe
    where ma_dvi=b_ma_dvi order by ma) where sott between b_tu and b_den;
exception when others then if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
/

/
create or replace procedure PHD_MA_NNNGHE_XEM(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,cs_lke out pht_type.cs_type,b_ma varchar2:='')
AS
    b_loi varchar2(100);
begin

b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'KT','KT','MNX');
if b_loi is not null then raise_application_error(-20105,b_loi); end if;
if b_ma is null then
    open cs_lke for select a.*,row_number() over (order by ma) sott from hd_ma_nnnghe a where ma_dvi=b_ma_dvi order by ma;
else open cs_lke for select a.*,row_number() over (order by ma) sott from hd_ma_nnnghe a where ma_dvi=b_ma_dvi and ma=b_ma;
end if;
end;
/
create or replace procedure hd_ma_nnnghe_nh(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2,b_ten nvarchar2,b_tt varchar2,b_ghichu varchar2)
AS
    b_loi varchar2(100);b_idvung number;b_i1 number;
begin
--  Nhap ma ngach nghe nghiep chi tiet
PHT_MA_NSD_KTRA_VU(b_ma_dvi,b_nsd,b_pas,b_idvung,b_loi,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Nhap ma ngach nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
if trim(b_ten) is null then b_loi:='loi:Phai nhap ten ngach nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
if b_tt not in ('N','A') then b_loi:='loi:Sai trang thai '||b_tt||':loi'; raise PROGRAM_ERROR; end if;
b_loi:='loi:Va cham NSD:loi';
delete hd_ma_nnnghe where ma_dvi=b_ma_dvi and ma=b_ma;
insert into hd_ma_nnnghe values (b_ma_dvi,b_ma,b_ten,b_tt,b_ghichu,sysdate,b_nsd,b_idvung);
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;

/
create or replace procedure hd_ma_nnnghe_xoa(b_ma_dvi varchar2,b_nsd varchar2,b_pas varchar2,b_ma varchar2)
AS
    b_loi varchar2(100); b_i1 number;
begin
--  Xoa ma ngach nghe nghiep chi tiet
b_loi:=FHT_MA_NSD_KTRA(b_ma_dvi,b_nsd,b_pas,'NS','NS','M');
if b_loi is not null then raise PROGRAM_ERROR; end if;
if trim(b_ma) is null then b_loi:='loi:Chon ma bac ngach nghe nghiep:loi'; raise PROGRAM_ERROR; end if;
delete hd_ma_nnnghe where ma_dvi=b_ma_dvi and ma=b_ma;
commit;
exception when others then rollback; if b_loi is null then raise PROGRAM_ERROR; else raise_application_error(-20105,b_loi); end if;
end;
///////////////////////////////////////////

