 

alter table "SysDepartment"
   drop constraint FK_SYSDEPAR_REFERENCE_SYSDEPAR;

alter table "SysDocumentSysDepartment"
   drop constraint FK_SYSDOCUM_REFERENCE_SYSDEPAR;

alter table "SysDocumentSysDepartment"
   drop constraint FK_SYSDOCUM_RE2;

alter table "SysDocumentSysPerson"
   drop constraint FK_SYSDOCUM_REFERENCE_SYSPERSO;

alter table "SysDocumentSysPerson"
   drop constraint FK_SYSDOCUM_RE3;

alter table "SysDocumentTalk"
   drop constraint FK_SYSDOCUM_REFERENCE_SYSDOCUM;

alter table "SysEmail"
   drop constraint FK_SYSEMAIL_REFERENCE_SYSEMAIL;

alter table "SysField"
   drop constraint FK_SYSFIELD_REFERENCE_SYSFIELD;

alter table "SysMenu"
   drop constraint FK_SYSMENU_REFERENCE_SYSMENU;

alter table "SysMenuSysOperation"
   drop constraint FK_SYSMENUS_REFERENCE_SYSMENU;

alter table "SysMenuSysOperation"
   drop constraint FK_SYSMENUS_REFERENCE_SYSOPERA;

alter table "SysMenuSysRoleSysOperation"
   drop constraint FK_SYSMENUS_RE2;

alter table "SysMenuSysRoleSysOperation"
   drop constraint FK_SYSMENUS_REFERENCE_SYSROLE;

alter table "SysMenuSysRoleSysOperation"
   drop constraint FK_SYSMENUS_REFERENCE_SYSMENU2;

alter table "SysMessage"
   drop constraint FK_SYSMESSA_REFERENCE_SYSMESSA;

alter table "SysPerson"
   drop constraint FK_SYSPERSO_REFERENCE_SYSDEPAR;

alter table "SysRoleSysPerson"
   drop constraint FK_SYSROLES_REFERENCE_SYSPERSO;

alter table "SysRoleSysPerson"
   drop constraint FK_SYSROLES_REFERENCE_SYSROLE;

drop table "FileUploader" cascade constraints;

drop table "SysAnnouncement" cascade constraints;

drop table "SysDepartment" cascade constraints;

drop table "SysDocument" cascade constraints;

drop table "SysDocumentSysDepartment" cascade constraints;

drop table "SysDocumentSysPerson" cascade constraints;

drop table "SysDocumentTalk" cascade constraints;

drop table "SysEmail" cascade constraints;

drop table "SysEmailTemp" cascade constraints;

drop table "SysException" cascade constraints;

drop index "Index_1";

drop table "SysField" cascade constraints;

drop table "SysLog" cascade constraints;

drop table "SysMenu" cascade constraints;

drop table "SysMenuSysOperation" cascade constraints;

drop table "SysMenuSysRoleSysOperation" cascade constraints;

drop table "SysMessage" cascade constraints;

drop table "SysMessageTemp" cascade constraints;

drop table "SysNotice" cascade constraints;

drop table "SysOperation" cascade constraints;

drop index "Index_2";

drop table "SysPerson" cascade constraints;

drop table "SysRole" cascade constraints;

drop table "SysRoleSysPerson" cascade constraints;

/*==============================================================*/
/* Table: "FileUploader"                                        */
/*==============================================================*/
create table "FileUploader" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200),
   "Path"               NVARCHAR2(200),
   "FullPath"           VARCHAR2(500),
   "Suffix"             NVARCHAR2(200),
   "Size"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_FILEUPLOADER primary key ("Id")
);

comment on column "FileUploader"."Name" is
'Research';

comment on column "FileUploader"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysAnnouncement"                                     */
/*==============================================================*/
create table "SysAnnouncement" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Title"              NVARCHAR2(100),
   "Message"            NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSANNOUNCEMENT primary key ("Id")
);

/*==============================================================*/
/* Table: "SysDepartment"                                       */
/*==============================================================*/
create table "SysDepartment" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200)       not null,
   "ParentId"           NVARCHAR2(36),
   "Address"            NVARCHAR2(200),
   "Sort"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   "UpdateTime"         DATE,
   "UpdatePerson"       NVARCHAR2(200),
   constraint PK_SYSDEPARTMENT primary key ("Id")
);

comment on column "SysDepartment"."Name" is
'Research';

/*==============================================================*/
/* Table: "SysDocument"                                         */
/*==============================================================*/
create table "SysDocument" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200),
   "Path"               NVARCHAR2(200),
   "FullPath"           VARCHAR2(500),
   "Suffix"             NVARCHAR2(200),
   "Size"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "Download"           INTEGER,
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSDOCUMENT primary key ("Id")
);

comment on column "SysDocument"."Name" is
'Research';

comment on column "SysDocument"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysDocumentSysDepartment"                            */
/*==============================================================*/
create table "SysDocumentSysDepartment" 
(
   "SysDepartmentId"    NVARCHAR2(36)        not null,
   "Sys_Id"             NVARCHAR2(36)        not null,
   constraint PK_SYSDOCUMENTSYSDEPARTMENT primary key ("SysDepartmentId", "Sys_Id")
);

/*==============================================================*/
/* Table: "SysDocumentSysPerson"                                */
/*==============================================================*/
create table "SysDocumentSysPerson" 
(
   "SysPersonId"        NVARCHAR2(36)        not null,
   "SysSysDocumentId_Id" NVARCHAR2(36)        not null,
   constraint PK_SYSDOCUMENTSYSPERSON primary key ("SysPersonId", "SysSysDocumentId_Id")
);

/*==============================================================*/
/* Table: "SysDocumentTalk"                                     */
/*==============================================================*/
create table "SysDocumentTalk" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Content"            NVARCHAR2(500),
   "SysDocumentId"      NVARCHAR2(36),
   "Bad"                INTEGER,
   "Good"               INTEGER,
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSDOCUMENTTALK primary key ("Id")
);

comment on column "SysDocumentTalk"."Content" is
'Research';

comment on column "SysDocumentTalk"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysEmail"                                            */
/*==============================================================*/
create table "SysEmail" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "SysMailId"          NVARCHAR2(36),
   "Subject"            NVARCHAR2(200)       not null,
   "Content"            NVARCHAR2(1000),
   "Reply_email"        NVARCHAR2(200),
   "Mail_type"          NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "ReadTime"           DATE,
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSEMAIL primary key ("Id")
);

comment on column "SysEmail"."ReadTime" is
'Research';

comment on column "SysEmail"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysEmailTemp"                                        */
/*==============================================================*/
create table "SysEmailTemp" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Mail_name"          NVARCHAR2(200)       not null,
   "Subject"            NVARCHAR2(200)       not null,
   "Content"            NVARCHAR2(1000),
   "Reply_email"        NVARCHAR2(200),
   "IsDefault"          NVARCHAR2(200),
   "Mail_type"          NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint "PK_mail_info2" primary key ("Id")
);

comment on column "SysEmailTemp"."IsDefault" is
'RadioButton';

comment on column "SysEmailTemp"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysException"                                        */
/*==============================================================*/
create table "SysException" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "LeiXing"            NVARCHAR2(200),
   "Message"            NVARCHAR2(1000),
   "Result"             NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSEXCEPTION primary key ("Id")
);

comment on column "SysException"."Message" is
'Research';

comment on column "SysException"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysField"                                            */
/*==============================================================*/
create table "SysField" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "MyTexts"            NVARCHAR2(200)       not null,
   "ParentId"           NVARCHAR2(36),
   "MyTables"           NVARCHAR2(200),
   "MyColums"           NVARCHAR2(200),
   "Sort"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   "UpdateTime"         DATE,
   "UpdatePerson"       NVARCHAR2(200),
   constraint PK_SYSFIELD primary key ("Id")
);

comment on column "SysField"."MyTexts" is
'Research';

/*==============================================================*/
/* Index: "Index_1"                                             */
/*==============================================================*/
create index "Index_1" on "SysField" (
   "MyTables" ASC,
   "MyColums" ASC
);

/*==============================================================*/
/* Table: "SysLog"                                              */
/*==============================================================*/
create table "SysLog" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "PersonId"           NVARCHAR2(36),
   "Message"            NVARCHAR2(1000),
   "Result"             NVARCHAR2(200),
   "MenuId"             NVARCHAR2(36),
   "Ip"                 NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSLOG primary key ("Id")
);

comment on column "SysLog"."Message" is
'Research';

comment on column "SysLog"."Ip" is
'Research';

comment on column "SysLog"."State" is
'ResearchDropDown';

comment on column "SysLog"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysMenu"                                             */
/*==============================================================*/
create table "SysMenu" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200)       not null,
   "ParentId"           NVARCHAR2(36),
   "Url"                NVARCHAR2(200),
   "Iconic"             NVARCHAR2(200),
   "Sort"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreatePerson"       NVARCHAR2(200),
   "CreateTime"         DATE,
   "UpdateTime"         DATE,
   "UpdatePerson"       NVARCHAR2(200),
   "IsLeaf"             NVARCHAR2(200),
   constraint PK_SYSMENU primary key ("Id")
);

comment on table "SysMenu" is
'导航栏';

comment on column "SysMenu"."Name" is
'Research';

comment on column "SysMenu"."State" is
'RadioButtonResearch';

/*==============================================================*/
/* Table: "SysMenuSysOperation"                                 */
/*==============================================================*/
create table "SysMenuSysOperation" 
(
   "SysMenuId"          NVARCHAR2(36)        not null,
   "SysOperationId"     NVARCHAR2(36)        not null,
   constraint PK_SYSMENUSYSOPERATION primary key ("SysMenuId", "SysOperationId")
);

/*==============================================================*/
/* Table: "SysMenuSysRoleSysOperation"                          */
/*==============================================================*/
create table "SysMenuSysRoleSysOperation" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "SysMenuId"          NVARCHAR2(36),
   "SysOperationId"     NVARCHAR2(36),
   "SysRoleId"          NVARCHAR2(36),
   constraint PK_SYSMENUSYSROLESYSOPERATION primary key ("Id")
);

/*==============================================================*/
/* Table: "SysMessage"                                          */
/*==============================================================*/
create table "SysMessage" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Content"            NVARCHAR2(400),
   "SysMessageTempId"   NVARCHAR2(36),
   "MessageType"        NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "ReadTime"           DATE,
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSMESSAGE primary key ("Id")
);

comment on column "SysMessage"."ReadTime" is
'Research';

comment on column "SysMessage"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysMessageTemp"                                      */
/*==============================================================*/
create table "SysMessageTemp" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "MessageName"        NVARCHAR2(200)       not null,
   "Content"            NVARCHAR2(400),
   "IsDefault"          NVARCHAR2(200),
   "MessageType"        NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint "PK_mail_info" primary key ("Id")
);

comment on column "SysMessageTemp"."IsDefault" is
'RadioButton';

comment on column "SysMessageTemp"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysNotice"                                           */
/*==============================================================*/
create table "SysNotice" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Message"            NVARCHAR2(1000),
   "LostTime"           DATE,
   "PersonId"           NVARCHAR2(36),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSNOTICE primary key ("Id")
);

comment on column "SysNotice"."LostTime" is
'Research';

comment on column "SysNotice"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysOperation"                                        */
/*==============================================================*/
create table "SysOperation" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200),
   "Function"           NVARCHAR2(200),
   "Iconic"             NVARCHAR2(200),
   "Sort"               INTEGER,
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   constraint PK_SYSOPERATION primary key ("Id")
);

comment on table "SysOperation" is
'操作';

comment on column "SysOperation"."Iconic" is
'Equal';

comment on column "SysOperation"."State" is
'ResearchDropDown';

comment on column "SysOperation"."CreateTime" is
'Research';

/*==============================================================*/
/* Table: "SysPerson"                                           */
/*==============================================================*/
create table "SysPerson" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200)       not null,
   "MyName"             NVARCHAR2(200),
   "Password"           NVARCHAR2(200)       not null,
   "SurePassword"       NVARCHAR2(200),
   "Sex"                NVARCHAR2(200),
   "SysDepartmentId"    NVARCHAR2(36),
   "Position"           NVARCHAR2(200),
   "MobilePhoneNumber"  NVARCHAR2(200),
   "PhoneNumber"        NVARCHAR2(200),
   "Province"           NVARCHAR2(200),
   "City"               NVARCHAR2(200),
   "Village"            NVARCHAR2(200),
   "Address"            NVARCHAR2(200),
   "EmailAddress"       NVARCHAR2(200),
   "Remark"             NVARCHAR2(1000),
   "State"              NVARCHAR2(200),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   "UpdateTime"         DATE,
   "LogonNum"           INTEGER,
   "LogonTime"          DATE,
   "LogonIP"            NVARCHAR2(200),
   "LastLogonTime"      DATE,
   "LastLogonIP"        NVARCHAR2(200),
   "PageStyle"          NVARCHAR2(200),
   "UpdatePerson"       NVARCHAR2(200),
   "Version"            TIMESTAMP,
   "HDpic"              VARCHAR2(200),
   constraint PK_SYSPERSON primary key ("Id")
);

comment on column "SysPerson"."Name" is
'Research';

comment on column "SysPerson"."MyName" is
'Research';

comment on column "SysPerson"."Sex" is
'DropDown';

comment on column "SysPerson"."Province" is
'DropDown';

comment on column "SysPerson"."City" is
'ProvinceCascade';

comment on column "SysPerson"."Village" is
'CityCascade';

comment on column "SysPerson"."State" is
'RadioButtonResearch';

comment on column "SysPerson"."PageStyle" is
'Display';

/*==============================================================*/
/* Index: "Index_2"                                             */
/*==============================================================*/
create index "Index_2" on "SysPerson" (
   "Name" ASC
);

/*==============================================================*/
/* Table: "SysRole"                                             */
/*==============================================================*/
create table "SysRole" 
(
   "Id"                 NVARCHAR2(36)        not null,
   "Name"               NVARCHAR2(200)       not null,
   "Description"        NVARCHAR2(1000),
   "CreateTime"         DATE,
   "CreatePerson"       NVARCHAR2(200),
   "UpdateTime"         DATE,
   "UpdatePerson"       NVARCHAR2(200),
   constraint PK_SYSROLE primary key ("Id")
);

comment on column "SysRole"."Name" is
'Research';

/*==============================================================*/
/* Table: "SysRoleSysPerson"                                    */
/*==============================================================*/
create table "SysRoleSysPerson" 
(
   "SysPersonId"        NVARCHAR2(36)        not null,
   "SysRoleId"          NVARCHAR2(36)        not null,
   constraint PK_SYSROLESYSPERSON primary key ("SysPersonId", "SysRoleId")
);

alter table "SysDepartment"
   add constraint FK_SYSDEPAR_REFERENCE_SYSDEPAR foreign key ("ParentId")
      references "SysDepartment" ("Id");

alter table "SysDocumentSysDepartment"
   add constraint FK_SYSDOCUM_REFERENCE_SYSDEPAR foreign key ("SysDepartmentId")
      references "SysDepartment" ("Id");

alter table "SysDocumentSysDepartment"
   add constraint FK_SYSDOCUM_RE2 foreign key ("Sys_Id")
      references "SysDocument" ("Id");

alter table "SysDocumentSysPerson"
   add constraint FK_SYSDOCUM_REFERENCE_SYSPERSO foreign key ("SysPersonId")
      references "SysPerson" ("Id");

alter table "SysDocumentSysPerson"
   add constraint FK_SYSDOCUM_RE3 foreign key ("SysSysDocumentId_Id")
      references "SysDocument" ("Id");

alter table "SysDocumentTalk"
   add constraint FK_SYSDOCUM_REFERENCE_SYSDOCUM foreign key ("SysDocumentId")
      references "SysDocument" ("Id");

alter table "SysEmail"
   add constraint FK_SYSEMAIL_REFERENCE_SYSEMAIL foreign key ("SysMailId")
      references "SysEmailTemp" ("Id");

alter table "SysField"
   add constraint FK_SYSFIELD_REFERENCE_SYSFIELD foreign key ("ParentId")
      references "SysField" ("Id");

alter table "SysMenu"
   add constraint FK_SYSMENU_REFERENCE_SYSMENU foreign key ("ParentId")
      references "SysMenu" ("Id");

alter table "SysMenuSysOperation"
   add constraint FK_SYSMENUS_REFERENCE_SYSMENU foreign key ("SysMenuId")
      references "SysMenu" ("Id");

alter table "SysMenuSysOperation"
   add constraint FK_SYSMENUS_REFERENCE_SYSOPERA foreign key ("SysOperationId")
      references "SysOperation" ("Id");

alter table "SysMenuSysRoleSysOperation"
   add constraint FK_SYSMENUS_RE2 foreign key ("SysOperationId")
      references "SysOperation" ("Id");

alter table "SysMenuSysRoleSysOperation"
   add constraint FK_SYSMENUS_REFERENCE_SYSROLE foreign key ("SysRoleId")
      references "SysRole" ("Id");

alter table "SysMenuSysRoleSysOperation"
   add constraint FK_SYSMENUS_REFERENCE_SYSMENU2 foreign key ("SysMenuId")
      references "SysMenu" ("Id");

alter table "SysMessage"
   add constraint FK_SYSMESSA_REFERENCE_SYSMESSA foreign key ("SysMessageTempId")
      references "SysMessageTemp" ("Id");

alter table "SysPerson"
   add constraint FK_SYSPERSO_REFERENCE_SYSDEPAR foreign key ("SysDepartmentId")
      references "SysDepartment" ("Id");

alter table "SysRoleSysPerson"
   add constraint FK_SYSROLES_REFERENCE_SYSPERSO foreign key ("SysPersonId")
      references "SysPerson" ("Id");

alter table "SysRoleSysPerson"
   add constraint FK_SYSROLES_REFERENCE_SYSROLE foreign key ("SysRoleId")
      references "SysRole" ("Id");

