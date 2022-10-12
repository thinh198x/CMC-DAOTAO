-- Create table NS_HDNS_MA_NN
create table NS_HDNS_MA_NN
(
  ma_dvi  NVARCHAR2(30) not null,
  ma      VARCHAR2(30) not null,
  ten     NVARCHAR2(255),
  tt      VARCHAR2(1),
  ghichu  NVARCHAR2(2000),
  ngay_nh DATE,
  nsd     VARCHAR2(10),
  idvung  NUMBER
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table NS_HDNS_MA_NN add constraint NS_HDNS_MA_TLNN_P primary key (MA_DVI, MA);