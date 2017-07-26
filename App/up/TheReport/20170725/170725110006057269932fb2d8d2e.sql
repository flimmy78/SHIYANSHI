/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     2017/6/27 15:52:01                           */
/*==============================================================*/


alter table EQUIPMENT
   drop constraint FK_EQUIPMEN_REFERENCE_DISTNBUT;

alter table EQUIPMENTTHAT
   drop constraint FK_EQUIPMEN_REFERENCE_EQUIPMEN;

drop table CODING cascade constraints;

drop table DATADICTIONARY cascade constraints;

drop table DISTNBUTION cascade constraints;

drop table EQUIPMENT cascade constraints;

drop table EQUIPMENTTHAT cascade constraints;

/*==============================================================*/
/* Table: CODING                                                */
/*==============================================================*/
create table CODING 
(
   ID                   VARCHAR2(36),
   BARCODE              VARCHAR2(200),
   DELIVERY_TIME        VARCHAR2(200),
   CREATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE
);

/*==============================================================*/
/* Table: DATADICTIONARY                                        */
/*==============================================================*/
create table DATADICTIONARY 
(
   ID                   VARCHAR2(36),
   TYPE                 VARCHAR2(200),
   CATEGORY             VARCHAR2(200),
   CREATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE
);

/*==============================================================*/
/* Table: DISTNBUTION                                           */
/*==============================================================*/
create table DISTNBUTION 
(
   ID                   VARCHAR2(36),
   "ORDER"              VARCHAR2(200),
   DELIVERY_DATE        VARCHAR2(200),
   VEHICLE              VARCHAR2(200),
   THESERIALNUMBER      INT,
   CREATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   constraint AK_KEY_1_DISTNBUT unique (ID)
);

/*==============================================================*/
/* Table: EQUIPMENT                                             */
/*==============================================================*/
create table EQUIPMENT 
(
   ID                   VARCHAR2(36)         not null,
   DISTNBUTIONID        VARCHAR2(200),
   MANUFACTURER         VARCHAR2(200),
   ARRIVE_BATCH_NO      VARCHAR2(200),
   EQUIP_CATEG          VARCHAR2(200),
   SPEC_CODE            VARCHAR2(200),
   MODEL_CODE           VARCHAR2(200),
   COMM_MODE            VARCHAR2(200),
   CARRIER_WAVE_ID      VARCHAR2(200),
   QTY                  VARCHAR2(200),
   REMARK               VARCHAR2(200),
   CREATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   DAOHUOPICHIHAO       VARCHAR2(200),
   ZHICHANZHUANTAI      VARCHAR2(200),
   constraint PK_EQUIPMENT primary key (ID)
);

/*==============================================================*/
/* Table: EQUIPMENTTHAT                                         */
/*==============================================================*/
create table EQUIPMENTTHAT 
(
   ID                   VARCHAR2(36)         not null,
   THEBARCODE           VARCHAR2(200),
   EQUIPMENTID          VARCHAR2(36),
   EQUIPMENTCATEGORY    VARCHAR2(200),
   CREATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   constraint PK_EQUIPMENTTHAT primary key (ID)
);

alter table EQUIPMENT
   add constraint FK_EQUIPMEN_REFERENCE_DISTNBUT foreign key (DISTNBUTIONID)
      references DISTNBUTION (ID);

alter table EQUIPMENTTHAT
   add constraint FK_EQUIPMEN_REFERENCE_EQUIPMEN foreign key (EQUIPMENTID)
      references EQUIPMENT (ID);

