/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     2016/8/31 22:19:45                           */
/*==============================================================*/


alter table ACTIVE_POWER
   drop constraint FK_ACTIVE_P_REFERENCE_OVERALL_;

alter table AC_VOLTAGE_CURRENT
   drop constraint FK_AC_VOLTA_REFERENCE_OVERALL_;

alter table ALLOWABLE_ERROR
   drop constraint FK_MAXIMUM__REFERENCE_METERIN2;

alter table APPLIANCECOLLECTION
   drop constraint FK_APPLIANC_REFERENCE_APPLIANC;

alter table APPLIANCE_DETAIL_INFORMATION
   drop constraint FK_APPLIANC_REFERENCE_ORDER_TA;

alter table APPLIANCE_LABORATORY
   drop constraint FK_APPLIANC_REFERENCE_PREPARE_;

alter table APPLIANCE_LABORATORY
   drop constraint FK_APPLIANC_REFERENCE_UNDERTAK;

alter table APPLIANCE_LABORATORY
   drop constraint FK_APPLIANC_REFERENCE_APPLIAN2;

alter table COMPANY
   drop constraint FK_COMPANY_REFERENCE_COMPANY;

alter table CROSS_COS
   drop constraint FK_CROSS_CO_REFERENCE_CROSS_HE;

alter table CROSS_FREQUENCY_POWER_FACTOR
   drop constraint FK_CROSS_FR_REFERENCE_CROSS_HE;

alter table CROSS_SIN
   drop constraint FK_CROSS_SI_REFERENCE_CROSS_HE;

alter table CROSS_VOLTAGE_CURRENT
   drop constraint FK_CROSS_VO_REFERENCE_CROSS_HE;

alter table DC_CURRENT_OUTPUT
   drop constraint FK_DC_CURRE_REFERENCE_OVERALL_;

alter table DC_VOLTAGE_CURRENT_MEASURE
   drop constraint FK_DC_VOLTA_REFERENCE_OVERALL3;

alter table DC_VOLTAGE_CURRENT_MEASURE_CH
   drop constraint FK_DC_VOLTA_REFERENCE_OVERALL_;

alter table DC_VOLTAGE_MEASURE_NO_INDEX
   drop constraint FK_DC_VOLTA_REFERENCE_OVERALL4;

alter table DC_VOLTAGE_OUTPUT
   drop constraint FK_DC_VOLTA_REFERENCE_OVERALL2;

alter table FILE_UPLOADER
   drop constraint FK_FILE_UPL_REFERENCE_PREPARE_;

alter table FREQUENCY
   drop constraint FK_FREQUENC_REFERENCE_OVERALL_;

alter table METERING_STANDARD_DEVICE
   drop constraint FK_METERING_REFERENCE_UNDERTAK;

alter table METERING_STANDARD_DEVICEPREPAR
   drop constraint FK_PREPARE_SCHEME_REF;

alter table METERING_STANDARD_DEVICEPREPAR
   drop constraint FK_METERING_REFERENCE_METERIN3;

alter table METERING_STANDARD_DEVICE_CHECK
   drop constraint FK_METERING_REFERENCE_METERIN2;

alter table PHASE
   drop constraint FK_PHASE_REFERENCE_OVERALL_;

alter table PREPARE_SCHEME
   drop constraint FK_PREPARE__REFERENCE_SCHEME;

alter table PRINTREPORT
   drop constraint FK_PRINTREP_REFERENCE_PREPARE_;

alter table QUALIFIED_UNQUALIFIED_TEST_ITE
   drop constraint FK_QUALIFIED_UN;

alter table REPORTCOLLECTION
   drop constraint FK_REPORTCO_REFERENCE_PREPARE_;

alter table RULE
   drop constraint FK_RULE_REFERENCE_UNDERTAK;

alter table RULE
   drop constraint FK_RULE_REFERENCE_RULE;

alter table SCHEME
   drop constraint FK_SCHEME_REFERENCE_UNDERTAK;

alter table SCHEME_RULE
   drop constraint FK_SCHEME_R_REFERENCE_RULE;

alter table SCHEME_RULE
   drop constraint FK_SCHEME_R_REFERENCE_SCHEME;

alter table THREE_PHASE_UNCERTAINTY
   drop constraint FK_THREE_PH_REFERENCE_RULE;

alter table TRANSMITER_SIN
   drop constraint FK_TRANSMIT_REFERENCE_TRANSMIT;

alter table TRANSMITTER_COS
   drop constraint FK_TRANSMIT_REFERENCE_TRANSMI3;

alter table TRANSMITTER_FREQUENCY_PHASE
   drop constraint FK_TRANSMIT_REFERENCE_TRANSMI2;

alter table TRANSMITTER_POWER_FACTOR
   drop constraint FK_TRANSMIT_REFERENCE_TRANSMI4;

alter table UNCERTAINTY
   drop constraint FK_ONE_PHAS_REFERENCE_RULE2;

alter table UNCERTAINTY2_HZ
   drop constraint FK_UNCERTAI_REFERENCE_RULE2;

alter table UNCERTAINTYPARAMETERMANAGEMENT
   drop constraint FK_UNCERTAI_REFERENCE_RULE;

drop view VSHENPI;

drop view VSHENHE;

drop view VRUKU;

drop view VQIJULINGQU2;

drop view VQIJULINGQU1;

drop view VJIANDINGRENWU;

drop view VBAOGAODAYIN;

drop table ACTIVE_POWER cascade constraints;

drop table AC_VOLTAGE_CURRENT cascade constraints;

drop table ALLOWABLE_ERROR cascade constraints;

drop table APPLIANCECOLLECTION cascade constraints;

drop table APPLIANCE_DETAIL_INFORMATION cascade constraints;

drop table APPLIANCE_LABORATORY cascade constraints;

drop table COMPANY cascade constraints;

drop table CROSS_COS cascade constraints;

drop table CROSS_FREQUENCY_POWER_FACTOR cascade constraints;

drop table CROSS_HEAD cascade constraints;

drop table CROSS_SIN cascade constraints;

drop table CROSS_VOLTAGE_CURRENT cascade constraints;

drop table DC_CURRENT_OUTPUT cascade constraints;

drop table DC_VOLTAGE_CURRENT_MEASURE cascade constraints;

drop table DC_VOLTAGE_CURRENT_MEASURE_CH cascade constraints;

drop table DC_VOLTAGE_MEASURE_NO_INDEX cascade constraints;

drop table DC_VOLTAGE_OUTPUT cascade constraints;

drop table ERROR_LIMIT cascade constraints;

drop table FILE_UPLOADER cascade constraints;

drop table FREQUENCY cascade constraints;

drop table METERING_STANDARD_DEVICE cascade constraints;

drop table METERING_STANDARD_DEVICEPREPAR cascade constraints;

drop table METERING_STANDARD_DEVICE_CHECK cascade constraints;

drop table ORDER_TASK_INFORMATION cascade constraints;

drop table OVERALL_TABLE cascade constraints;

drop table PHASE cascade constraints;

drop table PREPARE_SCHEME cascade constraints;

drop table PRINTREPORT cascade constraints;

drop table QUALIFIED_UNQUALIFIED_TEST_ITE cascade constraints;

drop table REPORTCOLLECTION cascade constraints;

drop table RULE cascade constraints;

drop table SCHEME cascade constraints;

drop table SCHEME_RULE cascade constraints;

drop table THREE_PHASE_UNCERTAINTY cascade constraints;

drop table TRANSMITER_SIN cascade constraints;

drop table TRANSMITTER_COS cascade constraints;

drop table TRANSMITTER_FREQUENCY_PHASE cascade constraints;

drop table TRANSMITTER_HEAD cascade constraints;

drop table TRANSMITTER_POWER_FACTOR cascade constraints;

drop table TRANSMITTER_RANGE cascade constraints;

drop table UNCERTAINTY cascade constraints;

drop table UNCERTAINTY2_HZ cascade constraints;

drop table UNCERTAINTYPARAMETERMANAGEMENT cascade constraints;

drop table UNDERTAKE_LABORATORY cascade constraints;

/*==============================================================*/
/* Table: ACTIVE_POWER                                          */
/*==============================================================*/
create table ACTIVE_POWER 
(
   ID                   VARCHAR2(36)         not null,
   RATED_CONDITION      VARCHAR2(200),
   POWER_FACTOR         VARCHAR2(200),
   POWER_FACTOR_UNIT    VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_ACTIVE_POWER primary key (ID)
);

comment on table ACTIVE_POWER is
'数表三相
JJG 780-92 交流数字功率表检定规程
';

comment on column ACTIVE_POWER.REFERENCE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: AC_VOLTAGE_CURRENT                                    */
/*==============================================================*/
create table AC_VOLTAGE_CURRENT 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_AC_VOLTAGE_CURRENT primary key (ID)
);

comment on table AC_VOLTAGE_CURRENT is
'数表三相
JJG 410-94 精密交流电压校准源检定规程-交流电压输出的两列三列
JJG(航天) 51-1999 交流标准电流源检定规程-三相交流电流输出的两列三列
JJG(航天)34-1999 交流数字电压表检定规程-三相交流电压测量的两列三列
JJG（航天）35-1999 交流数字电流表检定规程-交流电流测量（50Hz）的两列三列
';

comment on column AC_VOLTAGE_CURRENT.REFERENCE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: ALLOWABLE_ERROR                                       */
/*==============================================================*/
create table ALLOWABLE_ERROR 
(
   ID                   VARCHAR2(36)         not null,
   VALUE                VARCHAR2(200),
   UNIT                 VARCHAR2(200),
   METERING_STANDARD_DEVICEID VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_ALLOWABLE_ERROR primary key (ID)
);

comment on table ALLOWABLE_ERROR is
'标准装置/标准器不确定度、准确度等级、最大允许误差信息';

/*==============================================================*/
/* Table: APPLIANCECOLLECTION                                   */
/*==============================================================*/
create table APPLIANCECOLLECTION 
(
   ID                   VARCHAR2(36)         not null,
   GETNUMBER            NUMBER,
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   APPLIANCE_DETAIL_INFORMATIONID VARCHAR2(36),
   constraint PK_APPLIANCECOLLECTION primary key (ID)
);

/*==============================================================*/
/* Table: APPLIANCE_DETAIL_INFORMATION                          */
/*==============================================================*/
create table APPLIANCE_DETAIL_INFORMATION 
(
   ID                   VARCHAR2(36)         not null,
   BAR_CODE_NUM         VARCHAR2(200),
   APPLIANCE_NAME       VARCHAR2(200),
   VERSION              VARCHAR2(200),
   FORMAT               VARCHAR2(200),
   FACTORY_NUM          VARCHAR2(200),
   NUM                  NUMBER,
   ATTACHMENT           VARCHAR2(200),
   APPEARANCE_STATUS    VARCHAR2(200),
   MAKE_ORGANIZATION    VARCHAR2(200),
   REMARKS              VARCHAR2(4000),
   END_PLAN_DATE        DATE,
   ORDER_TASK_INFORMATIONID VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   APPLIANCE_RECIVE     VARCHAR2(200),
   APPLIANCE_PROGRESS   VARCHAR2(200),
   ORDER_STATUS         VARCHAR2(200),
   ISOVERDUE            VARCHAR2(200),
   OVERDUE              VARCHAR2(200),
   STORAGEINSTRUCTIONS  VARCHAR2(4000),
   STORAGEINSTRUCTI_STATU VARCHAR2(200),
   EQUIPMENT_STATUS_VALUUMN VARCHAR2(200),
   RETURN_INSTRUCTIONS  VARCHAR2(4000),
   constraint PK_APPLIANCE_DETAIL_INFORMATIO primary key (ID)
);

comment on column APPLIANCE_DETAIL_INFORMATION.BAR_CODE_NUM is
'0开头，后7位有效数字Research';

comment on column APPLIANCE_DETAIL_INFORMATION.APPLIANCE_NAME is
'Research';

comment on column APPLIANCE_DETAIL_INFORMATION.VERSION is
'Research';

comment on column APPLIANCE_DETAIL_INFORMATION.FACTORY_NUM is
'Research';

comment on column APPLIANCE_DETAIL_INFORMATION.NUM is
'默认1';

comment on column APPLIANCE_DETAIL_INFORMATION.APPEARANCE_STATUS is
'默认良好';

comment on column APPLIANCE_DETAIL_INFORMATION.MAKE_ORGANIZATION is
'DropDown文本框输入,写入制造单位,自动模糊匹配5个合适的单位;如果没有,新增保存.';

comment on column APPLIANCE_DETAIL_INFORMATION.END_PLAN_DATE is
'从登记时间开始算，如果天数超过14天，那么设备超期，如果超过11天则预警';

comment on column APPLIANCE_DETAIL_INFORMATION.APPLIANCE_RECIVE is
'DropDown';

comment on column APPLIANCE_DETAIL_INFORMATION.ORDER_STATUS is
'已分配、已归档DropDownResearch';

comment on column APPLIANCE_DETAIL_INFORMATION.ISOVERDUE is
'是、否DropDownResearch';

comment on column APPLIANCE_DETAIL_INFORMATION.STORAGEINSTRUCTI_STATU is
'DropDown';

comment on column APPLIANCE_DETAIL_INFORMATION.EQUIPMENT_STATUS_VALUUMN is
'器具状态值用来进行排序';

/*==============================================================*/
/* Table: APPLIANCE_LABORATORY                                  */
/*==============================================================*/
create table APPLIANCE_LABORATORY 
(
   ID                   VARCHAR2(36)         not null,
   UNDERTAKE_LABORATORYID VARCHAR2(36),
   APPLIANCE_DETAIL_INFORMATIOID VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   constraint PK_APPLIANCE_LABORATORY primary key (ID)
);

/*==============================================================*/
/* Table: COMPANY                                               */
/*==============================================================*/
create table COMPANY 
(
   ID                   VARCHAR2(36)         not null,
   COMPANYNAME          VARCHAR2(200),
   COMPANYADDRES        VARCHAR2(200),
   POSTCODE             VARCHAR2(200),
   CONTACTS             VARCHAR2(200),
   CONTACTSNUMBER       VARCHAR2(200),
   FAX                  VARCHAR2(200),
   PARENTID             VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_COMPANY primary key (ID)
);

comment on column COMPANY.ID is
'标识';

/*==============================================================*/
/* Table: CROSS_COS                                             */
/*==============================================================*/
create table CROSS_COS 
(
   ID                   VARCHAR2(36)         not null,
   COS                  VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CROSS_HEADID         VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_CROSS_COS primary key (ID)
);

comment on table CROSS_COS is
'国家电网公司交流采样测量装置校验规范
有功功率和cos有关';

/*==============================================================*/
/* Table: CROSS_FREQUENCY_POWER_FACTOR                          */
/*==============================================================*/
create table CROSS_FREQUENCY_POWER_FACTOR 
(
   ID                   VARCHAR2(36)         not null,
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   CROSS_HEADID         VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_CROSS_FREQUENCY_POWER_FACTO primary key (ID)
);

comment on table CROSS_FREQUENCY_POWER_FACTOR is
'国家电网公司交流采样测量装置校验规范';

/*==============================================================*/
/* Table: CROSS_HEAD                                            */
/*==============================================================*/
create table CROSS_HEAD 
(
   ID                   VARCHAR2(36)         not null,
   TYPE                 VARCHAR2(200),
   VALUE                VARCHAR2(200),
   VALUE_UNIT           VARCHAR2(200),
   GRADE_VALUE          VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_CROSS_HEAD primary key (ID)
);

comment on table CROSS_HEAD is
'国家电网公司交流采样测量装置校验规范';

/*==============================================================*/
/* Table: CROSS_SIN                                             */
/*==============================================================*/
create table CROSS_SIN 
(
   ID                   VARCHAR2(36)         not null,
   SIN                  VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   CROSS_HEADID         VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_CROSS_SIN primary key (ID)
);

comment on table CROSS_SIN is
'国家电网公司交流采样测量装置校验规范
无功功率和sin有关';

/*==============================================================*/
/* Table: CROSS_VOLTAGE_CURRENT                                 */
/*==============================================================*/
create table CROSS_VOLTAGE_CURRENT 
(
   ID                   VARCHAR2(36)         not null,
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   STANDARD_VALUE_A     VARCHAR2(200),
   STANDARD_VALUE_A_UNIT VARCHAR2(200),
   STANDARD_VALUE_B     VARCHAR2(200),
   STANDARD_VALUE_B_UNIT VARCHAR2(200),
   STANDARD_VALUE_C     VARCHAR2(200),
   STANDARD_VALUE_C_UNIT VARCHAR2(200),
   DISPLAY_A_VALUE      VARCHAR2(200),
   DISPLAY_VALUE_A_UNIT VARCHAR2(200),
   DISPLAY_B_VALUE      VARCHAR2(200),
   DISPLAY_VALUE_B_UNIT VARCHAR2(200),
   DISPLAY_C_VALUE      VARCHAR2(200),
   DISPLAY_VALUE_C_UNIT VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CROSS_HEADID         VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_CROSS_VOLTAGE_CURRENT primary key (ID)
);

comment on table CROSS_VOLTAGE_CURRENT is
'国家电网公司交流采样测量装置校验规范';

/*==============================================================*/
/* Table: DC_CURRENT_OUTPUT                                     */
/*==============================================================*/
create table DC_CURRENT_OUTPUT 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                NUMBER,
   RANGE_UNIT           VARCHAR2(200),
   RESISTANCE           VARCHAR2(200),
   RESISTANCE_UNIT      VARCHAR2(200),
   OUTPUT_VALUE         VARCHAR2(200),
   OUTPUT_VALUE_UNIT    VARCHAR2(200),
   READ_VALUE           VARCHAR2(200),
   READ_VALUE_UNIT      VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   RELATIVE_ERROR       VARCHAR2(200),
   RELATIVE_ERROR_UNIT  VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   INDEX1               VARCHAR2(200),
   INDEX2               VARCHAR2(200),
   STANDARD_RESISTANCE_INDEX VARCHAR2(200),
   RESOLUTION           VARCHAR2(200),
   REFERENCE_RANGE      VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_DC_CURRENT_OUTPUT primary key (ID)
);

comment on table DC_CURRENT_OUTPUT is
'数表三相
JJG(航天) 38-1987 直流标准电流源检定规程-直流电流输出';

comment on column DC_CURRENT_OUTPUT.RELATIVE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: DC_VOLTAGE_CURRENT_MEASURE                            */
/*==============================================================*/
create table DC_VOLTAGE_CURRENT_MEASURE 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   DISPLAY_VALUE_POSITIVE VARCHAR2(200),
   DISPLAY_VALUE_POSITIVE_UNIT VARCHAR2(200),
   DISPLAY_VALUE_NEGATIVE VARCHAR2(200),
   DISPLAY_VALUE_NEGATIVE_UNIT VARCHAR2(200),
   RELATIVE_ERROR_POSITIVE VARCHAR2(200),
   RELATIVE_ERROR_POSITIVE_UNIT VARCHAR2(200),
   RELATIVE_ERROR_NEGATIVE VARCHAR2(200),
   RELATIVE_ERROR_NEGATIVE_UNIT VARCHAR2(200),
   KVALUE               VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   INDEX1               VARCHAR2(200),
   INDEX2               VARCHAR2(200),
   INDEX2_UNIT          VARCHAR2(200),
   RESOLUTION           VARCHAR2(200),
   STATUS               VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_DC_VOLTAGE_CURRENT_MEASURE primary key (ID)
);

comment on table DC_VOLTAGE_CURRENT_MEASURE is
'数表三相
JJG 315-1983 直流数字电压表检定规程（试行）-单相-直流电压测量
JJG 598-1989 直流数字电流表检定规程（试行）-单相-直流电流测量';

comment on column DC_VOLTAGE_CURRENT_MEASURE.RELATIVE_ERROR_POSITIVE_UNIT is
'%';

comment on column DC_VOLTAGE_CURRENT_MEASURE.RELATIVE_ERROR_NEGATIVE_UNIT is
'%';

comment on column DC_VOLTAGE_CURRENT_MEASURE.KVALUE is
'例如：K=2、k=3';

comment on column DC_VOLTAGE_CURRENT_MEASURE.STATUS is
'区分不同表格';

/*==============================================================*/
/* Table: DC_VOLTAGE_CURRENT_MEASURE_CH                         */
/*==============================================================*/
create table DC_VOLTAGE_CURRENT_MEASURE_CH 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   DISPLAY_VALUE_POSITIVE VARCHAR2(200),
   DISPLAY_VALUE_POSITIVE_UNIT VARCHAR2(200),
   DISPLAY_VALUE_NEGATIVE VARCHAR2(200),
   DISPLAY_VALUE_NEGATIVE_UNIT VARCHAR2(200),
   RELATIVE_ERROR_POSITIVE VARCHAR2(200),
   RELATIVE_ERROR_POSITIVE_UNIT VARCHAR2(200),
   RELATIVE_ERROR_NEGATIVE VARCHAR2(200),
   RELATIVE_ERROR_NEGATIVE_UNIT VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   INDEX1               VARCHAR2(200),
   INDEX2               VARCHAR2(200),
   INDEX2_UNIT          VARCHAR2(200),
   RESOLUTION           VARCHAR2(200),
   STATUS               VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_DC_VOLTAGE_CURRENT_MEASURE_ primary key (ID)
);

comment on table DC_VOLTAGE_CURRENT_MEASURE_CH is
'数表三相
JJG 315-1983 直流数字电压表检定规程（试行）-单相-直流电压测量多通道CH0-CH16';

comment on column DC_VOLTAGE_CURRENT_MEASURE_CH.RELATIVE_ERROR_POSITIVE_UNIT is
'%';

comment on column DC_VOLTAGE_CURRENT_MEASURE_CH.RELATIVE_ERROR_NEGATIVE_UNIT is
'%';

comment on column DC_VOLTAGE_CURRENT_MEASURE_CH.STATUS is
'区分不同表格';

/*==============================================================*/
/* Table: DC_VOLTAGE_MEASURE_NO_INDEX                           */
/*==============================================================*/
create table DC_VOLTAGE_MEASURE_NO_INDEX 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   RELATIVE_ERROR       VARCHAR2(200),
   RELATIVE_ERROR_UNIT  VARCHAR2(200),
   KVALUE               VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_DC_VOLTAGE_MEASURE_NO_INDEX primary key (ID)
);

comment on table DC_VOLTAGE_MEASURE_NO_INDEX is
'数表三相，适用于多相位多通道
JJG 315-1983 直流数字电压表检定规程（试行）-三相-直流电压测量
JJG 598-1989 直流数字电流表检定规程（试行）-三相-直流电流测量';

comment on column DC_VOLTAGE_MEASURE_NO_INDEX.DISPLAY_VALUE is
'多列';

comment on column DC_VOLTAGE_MEASURE_NO_INDEX.STANDARD_VALUE is
'多列';

comment on column DC_VOLTAGE_MEASURE_NO_INDEX.RELATIVE_ERROR is
'多列';

comment on column DC_VOLTAGE_MEASURE_NO_INDEX.RELATIVE_ERROR_UNIT is
'% ';

comment on column DC_VOLTAGE_MEASURE_NO_INDEX.KVALUE is
'例如：K=2、k=3';

/*==============================================================*/
/* Table: DC_VOLTAGE_OUTPUT                                     */
/*==============================================================*/
create table DC_VOLTAGE_OUTPUT 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   OUTPUT_VALUE         VARCHAR2(200),
   OUTPUT_VALUE_UNIT    VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   RELATIVE_ERROR       VARCHAR2(200),
   RELATIVE_ERROR_UNIT  VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   INDEX1               VARCHAR2(200),
   INDEX2               VARCHAR2(200),
   RESOLUTION           VARCHAR2(200),
   REFERENCE_RANGE      VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_DC_VOLTAGE_OUTPUT primary key (ID)
);

comment on table DC_VOLTAGE_OUTPUT is
'数表三相
JJG 445-1986 直流标准电压源检定规程';

comment on column DC_VOLTAGE_OUTPUT.RELATIVE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: ERROR_LIMIT                                           */
/*==============================================================*/
create table ERROR_LIMIT 
(
   ID                   VARCHAR2(36)         not null,
   ACCURACY_GRADE       VARCHAR2(200),
   LIMIT_VALUE          VARCHAR2(200),
   CATEGORY             VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_ERROR_LIMIT primary key (ID)
);

comment on column ERROR_LIMIT.CATEGORY is
'相位非相位';

/*==============================================================*/
/* Table: FILE_UPLOADER                                         */
/*==============================================================*/
create table FILE_UPLOADER 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   PATH                 VARCHAR2(200),
   FULLPATH             VARCHAR2(200),
   SUFFIX               VARCHAR2(200),
   "SIZE"               NUMBER,
   REMARK               VARCHAR2(200),
   NAME2                VARCHAR2(200),
   PATH2                VARCHAR2(200),
   FULLPATH2            VARCHAR2(200),
   SUFFIX2              VARCHAR2(200),
   SIZE2                NUMBER,
   REMARK2              VARCHAR2(200),
   STATE2               VARCHAR2(200),
   STATE                VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   CONCLUSION           VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_FILE_UPLOADER primary key (ID)
);

comment on column FILE_UPLOADER.CONCLUSION is
'RadioButton';

/*==============================================================*/
/* Table: FREQUENCY                                             */
/*==============================================================*/
create table FREQUENCY 
(
   ID                   VARCHAR2(36)         not null,
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   RELATIVE_ERROR       VARCHAR2(200),
   RELATIVE_ERROR_UNIT  VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_FREQUENCY primary key (ID)
);

comment on table FREQUENCY is
'数表三相
规程名称：JJG 603-2006 频率表检定规程 ';

comment on column FREQUENCY.RELATIVE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: METERING_STANDARD_DEVICE                              */
/*==============================================================*/
create table METERING_STANDARD_DEVICE 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   TEST_RANGE           VARCHAR2(200),
   FACTORY_NUM          VARCHAR2(200),
   CATEGORY             VARCHAR2(200),
   STATUS               VARCHAR2(200),
   UNDERTAKE_LABORATORYID VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_METERING_STANDARD_DEVICE primary key (ID)
);

comment on column METERING_STANDARD_DEVICE.STATUS is
'修改后标识为历史数据，以往数据作废';

/*==============================================================*/
/* Table: METERING_STANDARD_DEVICEPREPAR                        */
/*==============================================================*/
create table METERING_STANDARD_DEVICEPREPAR 
(
   PREPARE_SCHEME       VARCHAR2(36)         not null,
   METERING_STANDARD_DEVICEID VARCHAR2(36)         not null,
   constraint PK_METERING_STANDARD_DEVICEPRE primary key (PREPARE_SCHEME, METERING_STANDARD_DEVICEID)
);

/*==============================================================*/
/* Table: METERING_STANDARD_DEVICE_CHECK                        */
/*==============================================================*/
create table METERING_STANDARD_DEVICE_CHECK 
(
   ID                   VARCHAR2(200)        not null,
   CERTIFICATE_NUM      VARCHAR2(200),
   CHECK_DATE           DATE,
   VALID_TO             DATE,
   METERING_STANDARD_DEVICEID VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_METERING_STANDARD_DEVICE_C2 primary key (ID)
);

/*==============================================================*/
/* Table: ORDER_TASK_INFORMATION                                */
/*==============================================================*/
create table ORDER_TASK_INFORMATION 
(
   ID                   VARCHAR2(36)         not null,
   ORDER_NUMBER         VARCHAR2(200),
   ACCEPT_ORGNIZATION   VARCHAR2(200),
   INSPECTION_ENTERPRISE VARCHAR2(200),
   INSPECTION_ENTERPRISE_ADDRESS VARCHAR2(200),
   INSPECTION_ENTERPRISE_POST VARCHAR2(200),
   CONTACTS             VARCHAR2(200),
   CONTACT_PHONE        VARCHAR2(200),
   FAX                  VARCHAR2(200),
   CERTIFICATE_ENTERPRISE VARCHAR2(200),
   CERTIFICATE_ENTERPRISE_ADDRESS VARCHAR2(200),
   CERTIFICATE_ENTERPRISE_POST VARCHAR2(200),
   CONTACTS2            VARCHAR2(200),
   CONTACT_PHONE2       VARCHAR2(200),
   FAX2                 VARCHAR2(200),
   CUSTOMER_SPECIFIC_REQUIREMENTS VARCHAR2(4000),
   ORDER_STATUS         VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_ORDER_TASK_INFORMATION primary key (ID)
);

comment on column ORDER_TASK_INFORMATION.ORDER_NUMBER is
'Research';

comment on column ORDER_TASK_INFORMATION.ACCEPT_ORGNIZATION is
'ResearchDropDown计量中心只出检定，检定授权分是否，若为是资质为冀；若为否，则/（国网授权）；电科院出检定或者校准，检定授权分是否，若为是,资质为京，若为否，则为/（国网授权）；校准CNAS若为是则为cnas资质，若为否则为/';

comment on column ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE is
'ResearchDropDown';

comment on column ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE is
'DropDownResearch';

comment on column ORDER_TASK_INFORMATION.ORDER_STATUS is
'已分配、已归档DropDownResearch';

comment on column ORDER_TASK_INFORMATION.CREATETIME is
'Research';

/*==============================================================*/
/* Table: OVERALL_TABLE                                         */
/*==============================================================*/
create table OVERALL_TABLE 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   KVALUE               VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_OVERALL_TABLE primary key (ID)
);

comment on table OVERALL_TABLE is
'表通道信息';

comment on column OVERALL_TABLE.KVALUE is
'例如：K=2、k=3';

/*==============================================================*/
/* Table: PHASE                                                 */
/*==============================================================*/
create table PHASE 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   PHASE_UNIT           VARCHAR2(200),
   DISPLAY_VALUE        VARCHAR2(200),
   DISPLAY_VALUE_UNIT   VARCHAR2(200),
   STANDARD_VALUE       VARCHAR2(200),
   STANDARD_VALUE_UNIT  VARCHAR2(200),
   ABSOLUTE_ERROR       VARCHAR2(200),
   ABSOLUTE_ERROR_UNIT  VARCHAR2(200),
   UNCERTAINTY_DEGREE   VARCHAR2(200),
   UNCERTAINTY_DEGREE_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   OVERALL_TABLEID      VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_PHASE primary key (ID)
);

comment on table PHASE is
'数表三相
规程名称：JJG 440-2008 工频单相相位表检定规程';

comment on column PHASE.ABSOLUTE_ERROR_UNIT is
'%';

/*==============================================================*/
/* Table: PREPARE_SCHEME                                        */
/*==============================================================*/
create table PREPARE_SCHEME 
(
   ID                   VARCHAR2(36)         not null,
   REPORT_CATEGORY      VARCHAR2(200),
   CERTIFICATE_CATEGORY VARCHAR2(200),
   CNAS                 VARCHAR2(200),
   CONTROL_NUMBER       VARCHAR2(200),
   CERTIFICATION_AUTHORITY VARCHAR2(200),
   QUALIFICATIONS       VARCHAR2(200),
   TEMPERATURE          VARCHAR2(200),
   HUMIDITY             VARCHAR2(200),
   CHECK_PLACE          VARCHAR2(200),
   CHECKERID            VARCHAR2(36),
   DETECTERID           VARCHAR2(36),
   APPROVALID           VARCHAR2(36),
   CALIBRATION_DATE     DATE,
   CONCLUSION           VARCHAR2(200),
   CONCLUSION_EXPLAIN   VARCHAR2(4000),
   VALIDITY_PERIOD      DATE,
   CALIBRATION_INSTRUCTIONS VARCHAR2(4000),
   ACCURACY_GRADE       VARCHAR2(200),
   RATED_FREQUENCY      VARCHAR2(200),
   PULSE_CONSTANT       VARCHAR2(200),
   EXTERNAL_RESITANCE_VALUE VARCHAR2(200),
   SCHEMEID             VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   AUDITOPINION         VARCHAR2(4000),
   AUDITTIME            DATE,
   AUDITTEPERSON        VARCHAR2(200),
   ISAGGREY             VARCHAR2(200),
   APPROVAL             VARCHAR2(4000),
   APPROVALDATE         DATE,
   APPROVALEPERSON      VARCHAR2(200),
   APPROVALISAGGREY     VARCHAR2(200),
   PRINTSTATUS          VARCHAR2(200),
   ISBACK               VARCHAR2(200),
   REPORTNUMBER         VARCHAR2(200),
   REPORTSTATUS         VARCHAR2(200),
   constraint PK_PREPARE_SCHEME primary key (ID)
);

comment on column PREPARE_SCHEME.REPORT_CATEGORY is
'DropDown';

comment on column PREPARE_SCHEME.CERTIFICATE_CATEGORY is
'DropDown';

comment on column PREPARE_SCHEME.QUALIFICATIONS is
'DropDown';

comment on column PREPARE_SCHEME.CHECK_PLACE is
'DropDown';

comment on column PREPARE_SCHEME.CONCLUSION is
'DropDown';

comment on column PREPARE_SCHEME.PRINTSTATUS is
'DropDown';

/*==============================================================*/
/* Table: PRINTREPORT                                           */
/*==============================================================*/
create table PRINTREPORT 
(
   ID                   VARCHAR2(36)         not null,
   GETNUMBER            NUMBER,
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   constraint PK_PRINTREPORT primary key (ID)
);

/*==============================================================*/
/* Table: QUALIFIED_UNQUALIFIED_TEST_ITE                        */
/*==============================================================*/
create table QUALIFIED_UNQUALIFIED_TEST_ITE 
(
   ID                   VARCHAR2(36)         not null,
   CONCLUSION           VARCHAR2(4000),
   PREPARE_SCHEMEID     VARCHAR2(36),
   RULEID               VARCHAR2(36),
   RULENAME             VARCHAR(200),
   RULENJOINAME         VARCHAR(2000),
   HTMLVALUE            CLOB,
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_QUALIFIED_UNQUALIFIED_TEST_ primary key (ID)
);

comment on table QUALIFIED_UNQUALIFIED_TEST_ITE is
'报告对应的检定项目及其项目结论';

comment on column QUALIFIED_UNQUALIFIED_TEST_ITE.RULENAME is
'检定项目原始名称';

comment on column QUALIFIED_UNQUALIFIED_TEST_ITE.RULENJOINAME is
'表格展示一行';

/*==============================================================*/
/* Table: REPORTCOLLECTION                                      */
/*==============================================================*/
create table REPORTCOLLECTION 
(
   ID                   VARCHAR2(36)         not null,
   GETNUMBER            NUMBER,
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   constraint PK_REPORTCOLLECTION primary key (ID)
);

/*==============================================================*/
/* Table: RULE                                                  */
/*==============================================================*/
create table RULE 
(
   ID                   VARCHAR2(36)         not null,
   NAMEOTHER            VARCHAR2(200),
   NAME                 VARCHAR2(200),
   SCHEME_MENU          VARCHAR2(200),
   SORT                 NUMBER,
   IS_UNCERTAINTY       VARCHAR2(200),
   UNCERTAINTY_MENU     VARCHAR2(200),
   UNDERTAKE_LABORATORYID VARCHAR2(36),
   INPUTSTATE           VARCHAR2(200),
   PARENTID             VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_RULE primary key (ID)
);

comment on column RULE.ID is
'标识';

/*==============================================================*/
/* Table: SCHEME                                                */
/*==============================================================*/
create table SCHEME 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   REPORT_CATEGORY      VARCHAR2(200),
   CERTIFICATE_CATEGORY VARCHAR2(200),
   STATUS               VARCHAR2(200),
   ISSTOP               VARCHAR2(200),
   ISPUBLISH            VARCHAR2(200),
   COPYID               VARCHAR2(36),
   UNDERTAKE_LABORATORYID VARCHAR2(36),
   PUBLISHTIME          DATE,
   PUBLISHPERSON        VARCHAR2(200),
   ISPUBLISHTIME        VARCHAR2(200),
   ISPUBLISHPERSON      VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_SCHEME primary key (ID)
);

comment on column SCHEME.STATUS is
'已使用，未使用';

comment on column SCHEME.ISSTOP is
'停用，启用';

comment on column SCHEME.ISPUBLISH is
'已发布，未发布';

/*==============================================================*/
/* Table: SCHEME_RULE                                           */
/*==============================================================*/
create table SCHEME_RULE 
(
   ID                   VARCHAR2(36)         not null,
   RULEID               VARCHAR2(36),
   SCHEMEID             VARCHAR2(36),
   HTMLVALUE            CLOB,
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_SCHEME_RULE primary key (ID)
);

comment on column SCHEME_RULE.RULEID is
'标识';

/*==============================================================*/
/* Table: THREE_PHASE_UNCERTAINTY                               */
/*==============================================================*/
create table THREE_PHASE_UNCERTAINTY 
(
   ID                   VARCHAR2(36)         not null,
   DIGIT                NUMBER,
   DEGREE1              NUMBER,
   DEGREE2              NUMBER,
   DEGREE3              NUMBER,
   RULEID               VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_THREE_PHASE_UNCERTAINTY primary key (ID)
);

comment on table THREE_PHASE_UNCERTAINTY is
'参考三相数表不确定评定';

/*==============================================================*/
/* Table: TRANSMITER_SIN                                        */
/*==============================================================*/
create table TRANSMITER_SIN 
(
   ID                   VARCHAR2(36)         not null,
   TEST_QUANTITY        VARCHAR2(200),
   GRADE                VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   SIN                  VARCHAR2(200),
   SIN_UNIT             VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUE VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUE_UNIT VARCHAR2(200),
   STANDARD_OUTPUT_VALUE VARCHAR2(200),
   STANDARD_OUTPUT_VALUE_UNIT VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   TRANSMITTER_HEADID   VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITER_SIN primary key (ID)
);

comment on table TRANSMITER_SIN is
'JJG126-1995 交流电量变换为直流电量电工测量变送器
无功功率是sin';

comment on column TRANSMITER_SIN.REFERENCE_ERROR_UNIT is
'% ';

/*==============================================================*/
/* Table: TRANSMITTER_COS                                       */
/*==============================================================*/
create table TRANSMITTER_COS 
(
   ID                   VARCHAR2(36)         not null,
   TEST_QUANTITY        VARCHAR2(200),
   GRADE                VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   COS                  VARCHAR2(200),
   COS_UNIT             VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES_UNIT VARCHAR2(200),
   STANDARD_OUTPUT_VALUE VARCHAR2(200),
   STANDARD_OUTPUT_VALUE_UNIT VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   TRANSMITTER_HEADID   VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITTER_COS primary key (ID)
);

comment on table TRANSMITTER_COS is
'JJG126-1995 交流电量变换为直流电量电工测量变送器
电压，电流，有功功率都是cos
';

comment on column TRANSMITTER_COS.REFERENCE_ERROR_UNIT is
'% ';

/*==============================================================*/
/* Table: TRANSMITTER_FREQUENCY_PHASE                           */
/*==============================================================*/
create table TRANSMITTER_FREQUENCY_PHASE 
(
   ID                   VARCHAR2(36)         not null,
   TEST_QUANTITY        VARCHAR2(200),
   GRADE                VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES_UNIT VARCHAR2(200),
   STANDARD_OUTPUT_VALUE VARCHAR2(200),
   STANDARD_OUTPUT_VALUE_UNIT VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   TRANSMITTER_HEADID   VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITTER_FREQUENCY_PHASE primary key (ID)
);

comment on table TRANSMITTER_FREQUENCY_PHASE is
'JJG126-1995 交流电量变换为直流电量电工测量变送器';

comment on column TRANSMITTER_FREQUENCY_PHASE.REFERENCE_ERROR_UNIT is
'% ';

/*==============================================================*/
/* Table: TRANSMITTER_HEAD                                      */
/*==============================================================*/
create table TRANSMITTER_HEAD 
(
   ID                   VARCHAR2(36)         not null,
   类型                   VARCHAR2(200),
   变送器输入开始              VARCHAR2(200),
   变送器输入开始单位            VARCHAR2(200),
   变送器输入结束              VARCHAR2(200),
   变送器输入结束单位            VARCHAR2(200),
   通道                   VARCHAR2(200),
   "Un"                 VARCHAR2(200),
   "Un单位"               VARCHAR2(200),
   "In"                 VARCHAR2(200),
   "In单位"               VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITTER_HEAD primary key (ID)
);

comment on table TRANSMITTER_HEAD is
'JJG126-1995 交流电量变换为直流电量电工测量变送器';

/*==============================================================*/
/* Table: TRANSMITTER_POWER_FACTOR                              */
/*==============================================================*/
create table TRANSMITTER_POWER_FACTOR 
(
   ID                   VARCHAR2(36)         not null,
   TEST_QUANTITY        VARCHAR2(200),
   GRADE                VARCHAR2(200),
   TEST_POINT           VARCHAR2(200),
   TEST_POINT_UNIT      VARCHAR2(200),
   U                    VARCHAR2(200),
   U_UNIT               VARCHAR2(200),
   A                    VARCHAR2(200),
   A_UNIT               VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES VARCHAR2(200),
   TWO_INPUT_STANDARD_VALUES_UNIT VARCHAR2(200),
   STANDARD_OUTPUT_VALUE VARCHAR2(200),
   STANDARD_OUTPUT_VALUE_UNIT VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE  VARCHAR2(200),
   ACTUAL_OUTPUT_VALUE_UNIT VARCHAR2(200),
   REFERENCE_ERROR      VARCHAR2(200),
   REFERENCE_ERROR_UNIT VARCHAR2(200),
   TRANSMITTER_HEADID   VARCHAR2(36),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITTER_POWER_FACTOR primary key (ID)
);

comment on table TRANSMITTER_POWER_FACTOR is
'JJG126-1995 交流电量变换为直流电量电工测量变送器';

comment on column TRANSMITTER_POWER_FACTOR.REFERENCE_ERROR_UNIT is
'% ';

/*==============================================================*/
/* Table: TRANSMITTER_RANGE                                     */
/*==============================================================*/
create table TRANSMITTER_RANGE 
(
   ID                   VARCHAR2(36)         not null,
   TEST_QUANTITY        VARCHAR2(200),
   INPUT_START          VARCHAR2(200),
   INPUT_START_UNIT     VARCHAR2(200),
   INPUT_END            VARCHAR2(200),
   INPUT_END_UNIT       VARCHAR2(200),
   OUTPUT_START         VARCHAR2(200),
   OUTPUT_START_UNIT    VARCHAR2(200),
   OUTPUT_END           VARCHAR2(200),
   OUTPUT_END_UNIT      VARCHAR2(200),
   SORT                 VARCHAR2(200),
   PREPARE_SCHEMEID     VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_TRANSMITTER_RANGE primary key (ID)
);

comment on table TRANSMITTER_RANGE is
'JJG126-1995 交流电量变换为直流电量电工测量变送器 
测试量多条
';

/*==============================================================*/
/* Table: UNCERTAINTY                                           */
/*==============================================================*/
create table UNCERTAINTY 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                NUMBER,
   RANGE_UNIT           VARCHAR2(200),
   KPI_1                NUMBER,
   KPI_1_UNIT           VARCHAR2(200),
   KPI_2                NUMBER,
   KPI_2_UNIT           VARCHAR2(200),
   RULEID               VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_UNCERTAINTY primary key (ID)
);

comment on table UNCERTAINTY is
'参考表检定不确定度5720A计算和源检定不确定度参考-8508A(新) 计算';

/*==============================================================*/
/* Table: UNCERTAINTY2_HZ                                       */
/*==============================================================*/
create table UNCERTAINTY2_HZ 
(
   ID                   VARCHAR2(36)         not null,
   RANGE                VARCHAR2(200),
   RANGE_UNIT           VARCHAR2(200),
   MIN_FREQUENCY        VARCHAR2(200),
   MIN_FREQUENCY_UNIT   VARCHAR2(200),
   MAX_FREQUENCY        VARCHAR2(200),
   MAX_FREQUENCY_UNIT   VARCHAR2(200),
   INDEX1               VARCHAR2(200),
   INDEX1_UNIT          VARCHAR2(200),
   INDEX2               VARCHAR2(200),
   INDEX2_UNIT          VARCHAR2(200),
   RULEID               VARCHAR2(36),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_UNCERTAINTY2_HZ primary key (ID)
);

comment on table UNCERTAINTY2_HZ is
'参考表检定不确定度5720A计算-交流';

comment on column UNCERTAINTY2_HZ.RULEID is
'标识';

/*==============================================================*/
/* Table: UNCERTAINTYPARAMETERMANAGEMENT                        */
/*==============================================================*/
create table UNCERTAINTYPARAMETERMANAGEMENT 
(
   ID                   VARCHAR2(36)         not null,
   SOURCEOFERROR        VARCHAR2(200),
   LIMIT_VALUE          NUMBER,
   ERRORDISTRIBUTION    VARCHAR2(200),
   "k"                  VARCHAR2(200),
   UNCERTAINTYDEGREE    NUMBER,
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   RULEID               VARCHAR2(36),
   constraint PK_UNCERTAINTYPARAMETERMANAGEM primary key (ID)
);

comment on column UNCERTAINTYPARAMETERMANAGEMENT.SOURCEOFERROR is
'DropDown';

comment on column UNCERTAINTYPARAMETERMANAGEMENT.ERRORDISTRIBUTION is
'DropDown';

comment on column UNCERTAINTYPARAMETERMANAGEMENT."k" is
'DropDown';

/*==============================================================*/
/* Table: UNDERTAKE_LABORATORY                                  */
/*==============================================================*/
create table UNDERTAKE_LABORATORY 
(
   ID                   VARCHAR2(36)         not null,
   NAME                 VARCHAR2(200),
   CREATETIME           DATE,
   CREATEPERSON         VARCHAR2(200),
   UPDATETIME           DATE,
   UPDATEPERSON         VARCHAR2(200),
   constraint PK_UNDERTAKE_LABORATORY primary key (ID)
);

comment on table UNDERTAKE_LABORATORY is
'承接实验室主键和名称一样';

/*==============================================================*/
/* View: VBAOGAODAYIN                                           */
/*==============================================================*/
create or replace view VBAOGAODAYIN(ID, REPORTNUMBER, ORDER_NUMBER, APPLIANCE_NAME, VERSION, FACTORY_NUM, CERTIFICATE_ENTERPRISE, CUSTOMER_SPECIFIC_REQUIREMENTS, CERTIFICATE_CATEGORY, QUALIFICATIONS, CONCLUSION_EXPLAIN, CONCLUSION, UNDERTAKE_LABORATORYID, APPROVALDATE, BAR_CODE_NUM, PRINTSTATUS) as
select d.ID,
  d.REPORTNUMBER,             --报告编号
  a.ORDER_NUMBER,                  --委托单号
  b.APPLIANCE_NAME,                --器具名称
  b.VERSION,                         --型号
  b.FACTORY_NUM,                   --出厂编号
  a.CERTIFICATE_ENTERPRISE,        --证书单位
  a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
  d.CERTIFICATE_CATEGORY,          --证书类别
  CASE
    when d.QUALIFICATIONS     ='本单位获北京市质量技术监督局专项计量授权，证书编号：（京）法计（2012）006号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '北京授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '校准'
    WHEN d.qualifications     ='本单位获河北市质量技术监督局专项计量授权，证书编号：（冀）法计（2014）D033号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '河北授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '校准'
    ELSE ''
  end as qualifications,    --资质授权
  d.CONCLUSION_EXPLAIN,     --总结论说明
  d.CONCLUSION,             --总结论
  c.UNDERTAKE_LABORATORYID, --实验室
  d.APPROVALDATE,           --批准日期
  b.BAR_CODE_NUM,           --条形码
  d.PRINTSTATUS             --打印状态
from PREPARE_SCHEME d
LEFT join APPLIANCE_LABORATORY c
on c.PREPARE_SCHEMEID=d.id
LEFT join APPLIANCE_DETAIL_INFORMATION b
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join ORDER_TASK_INFORMATION a 
on a.id=b.ORDER_TASK_INFORMATIONID
with read only;

comment on column VBAOGAODAYIN.REPORTNUMBER is
'Research';

comment on column VBAOGAODAYIN.ORDER_NUMBER is
'Research';

comment on column VBAOGAODAYIN.FACTORY_NUM is
'Research';

comment on column VBAOGAODAYIN.CERTIFICATE_ENTERPRISE is
'Research';

comment on column VBAOGAODAYIN.UNDERTAKE_LABORATORYID is
'ResearchDropDown';

comment on column VBAOGAODAYIN.APPROVALDATE is
'Research';

comment on column VBAOGAODAYIN.BAR_CODE_NUM is
'Research';

comment on column VBAOGAODAYIN.PRINTSTATUS is
'ResearchDropDown';

/*==============================================================*/
/* View: VJIANDINGRENWU                                         */
/*==============================================================*/
create or replace view VJIANDINGRENWU as
select b.ID, --器具明细id
  a.ORDER_NUMBER,             --委托单号
  b.APPLIANCE_NAME,                --器具名称
  b.VERSION,                         --型号
  b.FACTORY_NUM,                   --出厂编号
  a.CERTIFICATE_ENTERPRISE,        --证书单位
  a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
  b.ORDER_STATUS,                  --器具状态
  a.CREATETIME,                  --送检时间
  b.APPLIANCE_PROGRESS,            --器具进度
  b.OVERDUE,                       --超期原因
  e.STATE,                         --上传状态
  d.REPORTSTATUS,                  --报告状态
  d.APPROVAL,                      --审核审批不通过原因
  a.INSPECTION_ENTERPRISE,         --送检单位
  b.ISOVERDUE,                      --是否超期
c.UNDERTAKE_LABORATORYID,--实验室
b.EQUIPMENT_STATUS_VALUUMN--状态值

from APPLIANCE_DETAIL_INFORMATION  b
--器具明细
LEFT join ORDER_TASK_INFORMATION a
--委托单
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCE_LABORATORY c
--器具明细信息_承接实验室
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join PREPARE_SCHEME d
--预备方案
on c.PREPARE_SCHEMEID=d.id
LEFT join FILE_UPLOADER e
--附件
on d.id=c.PREPARE_SCHEMEID
with read only;

comment on column VJIANDINGRENWU.ORDER_NUMBER is
'Research';

comment on column VJIANDINGRENWU.APPLIANCE_NAME is
'Research';

comment on column VJIANDINGRENWU.VERSION is
'Research';

comment on column VJIANDINGRENWU.FACTORY_NUM is
'Research';

comment on column VJIANDINGRENWU.CERTIFICATE_ENTERPRISE is
'Research';

comment on column VJIANDINGRENWU.ORDER_STATUS is
'DropDownResearch';

comment on column VJIANDINGRENWU.INSPECTION_ENTERPRISE is
'Research';

comment on column VJIANDINGRENWU.ISOVERDUE is
'DropDownResearch';

/*==============================================================*/
/* View: VQIJULINGQU1                                           */
/*==============================================================*/
create or replace view VQIJULINGQU1 as
select
a.ID,
a.ORDER_NUMBER, --委托单号
a.CERTIFICATE_ENTERPRISE,--证书单位
a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
c.CREATEPERSON,--领取者,根据判断是否存在领取者来取器具领取状态
a.CREATETIME,--登记时间（送检时间段）
f.CREATEPERSON as REPORTCREATEPERSON--领取者,根据判断是否存在领取者来取报告领取状态

from ORDER_TASK_INFORMATION a
LEFT join APPLIANCE_DETAIL_INFORMATION b
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCECOLLECTION c
on b.id=c.APPLIANCE_DETAIL_INFORMATIONID
left join APPLIANCE_LABORATORY d
on b.id=d.APPLIANCE_DETAIL_INFORMATIOID
left join PREPARE_SCHEME e
on d.PREPARE_SCHEMEID=e.id
left join REPORTCOLLECTION f
on f.PREPARE_SCHEMEID=e.id
with read only;

comment on column VQIJULINGQU1.ORDER_NUMBER is
'Research';

comment on column VQIJULINGQU1.CERTIFICATE_ENTERPRISE is
'Research';

comment on column VQIJULINGQU1.CREATEPERSON is
'ResearchDropDown';

comment on column VQIJULINGQU1.CREATETIME is
'Research';

comment on column VQIJULINGQU1.REPORTCREATEPERSON is
'ResearchDropDown';

/*==============================================================*/
/* View: VQIJULINGQU2                                           */
/*==============================================================*/
create or replace view VQIJULINGQU2(ID, APPLIANCE_NAME, VERSION, FACTORY_NUM, NUM, ATTACHMENT, NAME, APPLIANCE_RECIVE, REPORTNUMBER, REMARKS, ORDER_NUMBER) as
select a.ID,
  b.APPLIANCE_NAME, --器具名称
  b.VERSION,               --型号
  b.FACTORY_NUM,         --出厂编号
  b.NUM,                 --数量
  b.ATTACHMENT,          --附件
  e.NAME,                --承接实验室
  b.APPLIANCE_RECIVE,--器具接收
  d.REPORTNUMBER,--证书编号
  b.REMARKS,             --备注
  a.ORDER_NUMBER--委托单号
  
from ORDER_TASK_INFORMATION a
LEFT join APPLIANCE_DETAIL_INFORMATION b
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCE_LABORATORY c
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join PREPARE_SCHEME d
on c.PREPARE_SCHEMEID=d.id
left join UNDERTAKE_LABORATORY e
on c.UNDERTAKE_LABORATORYID=e.id
with read only;

/*==============================================================*/
/* View: VRUKU                                                  */
/*==============================================================*/
create or replace view VRUKU(ID, REPORTNUMBER, ORDER_NUMBER, APPLIANCE_NAME, VERSION, FACTORY_NUM, CERTIFICATE_ENTERPRISE, CUSTOMER_SPECIFIC_REQUIREMENTS, NAME, ORDER_STATUS, STORAGEINSTRUCTIONS, UNDERTAKE_LABORATORYID, APPROVALDATE, STORAGEINSTRUCTI_STATU) as
select b.ID,
  d.REPORTNUMBER,             --报告编号
  a.ORDER_NUMBER,                  --委托单号
  b.APPLIANCE_NAME,                --器具名称
  b.VERSION,                         --型号
  b.FACTORY_NUM,                   --出厂编号
  a.CERTIFICATE_ENTERPRISE,        --证书单位
  a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
  e.NAME,                          --器具所在实验室
  b.ORDER_STATUS,                  --器具状态
  b.STORAGEINSTRUCTIONS,           --入库说明
  c.UNDERTAKE_LABORATORYID,        --实验室
  d.APPROVALDATE,                  --批准日期
  b.STORAGEINSTRUCTI_STATU         --入库状态
from APPLIANCE_DETAIL_INFORMATION b
LEFT join  ORDER_TASK_INFORMATION a
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCE_LABORATORY c
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join PREPARE_SCHEME d
on c.PREPARE_SCHEMEID=d.id
left join UNDERTAKE_LABORATORY e
on c.UNDERTAKE_LABORATORYID=e.id
with read only;

comment on column VRUKU.ORDER_NUMBER is
'Research';

comment on column VRUKU.CERTIFICATE_ENTERPRISE is
'Research';

comment on column VRUKU.UNDERTAKE_LABORATORYID is
'ResearchDropDown';

comment on column VRUKU.APPROVALDATE is
'Research';

comment on column VRUKU.STORAGEINSTRUCTI_STATU is
'ResearchDropDown';

/*==============================================================*/
/* View: VSHENHE                                                */
/*==============================================================*/
create or replace view VSHENHE(ID, REPORTNUMBER, ORDER_NUMBER, APPLIANCE_NAME, VERSION, FACTORY_NUM, CERTIFICATE_ENTERPRISE, CUSTOMER_SPECIFIC_REQUIREMENTS, CERTIFICATE_CATEGORY, QUALIFICATIONS, CONCLUSION_EXPLAIN, CONCLUSION, ISAGGREY, PREPARE_SCHEMEID) as
select b.ID,
  d.REPORTNUMBER,             --报告编号
  a.ORDER_NUMBER,                  --委托单号
  b.APPLIANCE_NAME,                --器具名称
  b.VERSION,                         --型号
  b.FACTORY_NUM,                   --出厂编号
  a.CERTIFICATE_ENTERPRISE,        --证书单位
  a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
  d.CERTIFICATE_CATEGORY,          --证书类别
  CASE
    when d.QUALIFICATIONS     ='本单位获北京市质量技术监督局专项计量授权，证书编号：（京）法计（2012）006号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '北京授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '校准'
    WHEN d.qualifications     ='本单位获河北市质量技术监督局专项计量授权，证书编号：（冀）法计（2014）D033号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '河北授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '校准'
    ELSE ''
  end as qualifications, --资质授权
  d.CONCLUSION_EXPLAIN,  --总结论说明
  d.CONCLUSION,           --总结论
  d.ISAGGREY,--审核同意
e.PREPARE_SCHEMEID --附件中的预备方案id
  
from APPLIANCE_DETAIL_INFORMATION b
LEFT join  ORDER_TASK_INFORMATION a
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCE_LABORATORY c
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join PREPARE_SCHEME d
on c.PREPARE_SCHEMEID=d.id
left join FILE_UPLOADER e
on d.id=e.PREPARE_SCHEMEID
with read only;

comment on column VSHENHE.ORDER_NUMBER is
'Research';

comment on column VSHENHE.ISAGGREY is
'ResearchDropDown';

/*==============================================================*/
/* View: VSHENPI                                                */
/*==============================================================*/
create or replace view VSHENPI(ID, REPORTNUMBER, ORDER_NUMBER, APPLIANCE_NAME, VERSION, FACTORY_NUM, CERTIFICATE_ENTERPRISE, CUSTOMER_SPECIFIC_REQUIREMENTS, CERTIFICATE_CATEGORY, QUALIFICATIONS, CONCLUSION_EXPLAIN, CONCLUSION, UNDERTAKE_LABORATORYID, APPROVALISAGGREY, PREPARE_SCHEMEID) as
select b.ID,
  d.REPORTNUMBER,             --报告编号
  a.ORDER_NUMBER,                  --委托单号
  b.APPLIANCE_NAME,                --器具名称
  b.VERSION,                         --型号
  b.FACTORY_NUM,                   --出厂编号
  a.CERTIFICATE_ENTERPRISE,        --证书单位
  a.CUSTOMER_SPECIFIC_REQUIREMENTS,--客户特殊要求
  d.CERTIFICATE_CATEGORY,          --证书类别
  CASE
    when d.QUALIFICATIONS     ='本单位获北京市质量技术监督局专项计量授权，证书编号：（京）法计（2012）006号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '北京授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '校准'
    WHEN d.qualifications     ='本单位获河北市质量技术监督局专项计量授权，证书编号：（冀）法计（2014）D033号'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '河北授权检定'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='检定'
    and a.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN d.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN 'CNAS校准'
    WHEN d.qualifications     ='/'
    and d.CERTIFICATE_CATEGORY='校准'
    and a.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '校准'
    ELSE ''
  end as qualifications,   --资质授权
  d.CONCLUSION_EXPLAIN,    --总结论说明
  d.CONCLUSION,            --总结论
  c.UNDERTAKE_LABORATORYID,--实验室
  d.APPROVALISAGGREY ,      --同意不同意判断待批还已批
e.PREPARE_SCHEMEID --附件中的预备方案id
from APPLIANCE_DETAIL_INFORMATION b 
LEFT join ORDER_TASK_INFORMATION a
on a.id=b.ORDER_TASK_INFORMATIONID
LEFT join APPLIANCE_LABORATORY c
on b.id=c.APPLIANCE_DETAIL_INFORMATIOID
LEFT join PREPARE_SCHEME d
on c.PREPARE_SCHEMEID=d.id
left join FILE_UPLOADER e
on d.id=e.PREPARE_SCHEMEID
with read only;

comment on column VSHENPI.ORDER_NUMBER is
'Research';

comment on column VSHENPI.UNDERTAKE_LABORATORYID is
'ResearchDropDown';

comment on column VSHENPI.APPROVALISAGGREY is
'ResearchDropDown';

alter table ACTIVE_POWER
   add constraint FK_ACTIVE_P_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table AC_VOLTAGE_CURRENT
   add constraint FK_AC_VOLTA_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table ALLOWABLE_ERROR
   add constraint FK_MAXIMUM__REFERENCE_METERIN2 foreign key (METERING_STANDARD_DEVICEID)
      references METERING_STANDARD_DEVICE (ID);

alter table APPLIANCECOLLECTION
   add constraint FK_APPLIANC_REFERENCE_APPLIANC foreign key (APPLIANCE_DETAIL_INFORMATIONID)
      references APPLIANCE_DETAIL_INFORMATION (ID);

alter table APPLIANCE_DETAIL_INFORMATION
   add constraint FK_APPLIANC_REFERENCE_ORDER_TA foreign key (ORDER_TASK_INFORMATIONID)
      references ORDER_TASK_INFORMATION (ID);

alter table APPLIANCE_LABORATORY
   add constraint FK_APPLIANC_REFERENCE_PREPARE_ foreign key (PREPARE_SCHEMEID)
      references PREPARE_SCHEME (ID);

alter table APPLIANCE_LABORATORY
   add constraint FK_APPLIANC_REFERENCE_UNDERTAK foreign key (UNDERTAKE_LABORATORYID)
      references UNDERTAKE_LABORATORY (ID);

alter table APPLIANCE_LABORATORY
   add constraint FK_APPLIANC_REFERENCE_APPLIAN2 foreign key (APPLIANCE_DETAIL_INFORMATIOID)
      references APPLIANCE_DETAIL_INFORMATION (ID);

alter table COMPANY
   add constraint FK_COMPANY_REFERENCE_COMPANY foreign key (PARENTID)
      references COMPANY (ID);

alter table CROSS_COS
   add constraint FK_CROSS_CO_REFERENCE_CROSS_HE foreign key (CROSS_HEADID)
      references CROSS_HEAD (ID);

alter table CROSS_FREQUENCY_POWER_FACTOR
   add constraint FK_CROSS_FR_REFERENCE_CROSS_HE foreign key (CROSS_HEADID)
      references CROSS_HEAD (ID);

alter table CROSS_SIN
   add constraint FK_CROSS_SI_REFERENCE_CROSS_HE foreign key (CROSS_HEADID)
      references CROSS_HEAD (ID);

alter table CROSS_VOLTAGE_CURRENT
   add constraint FK_CROSS_VO_REFERENCE_CROSS_HE foreign key (CROSS_HEADID)
      references CROSS_HEAD (ID);

alter table DC_CURRENT_OUTPUT
   add constraint FK_DC_CURRE_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table DC_VOLTAGE_CURRENT_MEASURE
   add constraint FK_DC_VOLTA_REFERENCE_OVERALL3 foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table DC_VOLTAGE_CURRENT_MEASURE_CH
   add constraint FK_DC_VOLTA_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table DC_VOLTAGE_MEASURE_NO_INDEX
   add constraint FK_DC_VOLTA_REFERENCE_OVERALL4 foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table DC_VOLTAGE_OUTPUT
   add constraint FK_DC_VOLTA_REFERENCE_OVERALL2 foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table FILE_UPLOADER
   add constraint FK_FILE_UPL_REFERENCE_PREPARE_ foreign key (PREPARE_SCHEMEID)
      references PREPARE_SCHEME (ID);

alter table FREQUENCY
   add constraint FK_FREQUENC_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table METERING_STANDARD_DEVICE
   add constraint FK_METERING_REFERENCE_UNDERTAK foreign key (UNDERTAKE_LABORATORYID)
      references UNDERTAKE_LABORATORY (ID);

alter table METERING_STANDARD_DEVICEPREPAR
   add constraint FK_PREPARE_SCHEME_REF foreign key (PREPARE_SCHEME)
      references PREPARE_SCHEME (ID);

alter table METERING_STANDARD_DEVICEPREPAR
   add constraint FK_METERING_REFERENCE_METERIN3 foreign key (METERING_STANDARD_DEVICEID)
      references METERING_STANDARD_DEVICE (ID);

alter table METERING_STANDARD_DEVICE_CHECK
   add constraint FK_METERING_REFERENCE_METERIN2 foreign key (METERING_STANDARD_DEVICEID)
      references METERING_STANDARD_DEVICE (ID);

alter table PHASE
   add constraint FK_PHASE_REFERENCE_OVERALL_ foreign key (OVERALL_TABLEID)
      references OVERALL_TABLE (ID);

alter table PREPARE_SCHEME
   add constraint FK_PREPARE__REFERENCE_SCHEME foreign key (SCHEMEID)
      references SCHEME (ID);

alter table PRINTREPORT
   add constraint FK_PRINTREP_REFERENCE_PREPARE_ foreign key (PREPARE_SCHEMEID)
      references PREPARE_SCHEME (ID);

alter table QUALIFIED_UNQUALIFIED_TEST_ITE
   add constraint FK_QUALIFIED_UN foreign key (PREPARE_SCHEMEID)
      references PREPARE_SCHEME (ID);

alter table REPORTCOLLECTION
   add constraint FK_REPORTCO_REFERENCE_PREPARE_ foreign key (PREPARE_SCHEMEID)
      references PREPARE_SCHEME (ID);

alter table RULE
   add constraint FK_RULE_REFERENCE_UNDERTAK foreign key (UNDERTAKE_LABORATORYID)
      references UNDERTAKE_LABORATORY (ID);

alter table RULE
   add constraint FK_RULE_REFERENCE_RULE foreign key (PARENTID)
      references RULE (ID);

alter table SCHEME
   add constraint FK_SCHEME_REFERENCE_UNDERTAK foreign key (UNDERTAKE_LABORATORYID)
      references UNDERTAKE_LABORATORY (ID);

alter table SCHEME_RULE
   add constraint FK_SCHEME_R_REFERENCE_RULE foreign key (RULEID)
      references RULE (ID);

alter table SCHEME_RULE
   add constraint FK_SCHEME_R_REFERENCE_SCHEME foreign key (SCHEMEID)
      references SCHEME (ID);

alter table THREE_PHASE_UNCERTAINTY
   add constraint FK_THREE_PH_REFERENCE_RULE foreign key (RULEID)
      references RULE (ID);

alter table TRANSMITER_SIN
   add constraint FK_TRANSMIT_REFERENCE_TRANSMIT foreign key (TRANSMITTER_HEADID)
      references TRANSMITTER_HEAD (ID);

alter table TRANSMITTER_COS
   add constraint FK_TRANSMIT_REFERENCE_TRANSMI3 foreign key (TRANSMITTER_HEADID)
      references TRANSMITTER_HEAD (ID);

alter table TRANSMITTER_FREQUENCY_PHASE
   add constraint FK_TRANSMIT_REFERENCE_TRANSMI2 foreign key (TRANSMITTER_HEADID)
      references TRANSMITTER_HEAD (ID);

alter table TRANSMITTER_POWER_FACTOR
   add constraint FK_TRANSMIT_REFERENCE_TRANSMI4 foreign key (TRANSMITTER_HEADID)
      references TRANSMITTER_HEAD (ID);

alter table UNCERTAINTY
   add constraint FK_ONE_PHAS_REFERENCE_RULE2 foreign key (RULEID)
      references RULE (ID);

alter table UNCERTAINTY2_HZ
   add constraint FK_UNCERTAI_REFERENCE_RULE2 foreign key (RULEID)
      references RULE (ID);

alter table UNCERTAINTYPARAMETERMANAGEMENT
   add constraint FK_UNCERTAI_REFERENCE_RULE foreign key (RULEID)
      references RULE (ID);

