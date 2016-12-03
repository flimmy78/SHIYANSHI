select al."ID",----1主键
    oti."ORDER_NUMBER",----2委托单号
    '',----3所属单位
    oti."CERTIFICATE_ENTERPRISE",----4证书单位
     oti.INSPECTION_ENTERPRISE,---5送检单位
    oti."ACCEPT_ORGNIZATION",----6受理单位
  '',----7出厂日期
  adi."APPLIANCE_NAME",----8器具名称
    '',----9生产厂家
   adi."VERSION",----10器具型号
    adi."FORMAT",----11器具规格
  adi."FACTORY_NUM",----12出厂编号
   adi."NUM",----13数量
   oti."CREATETIME",----14送检日期
 oti."CONTACTS",----15送检人
   oti."CREATEPERSON", --16接收人
    al."UNDERTAKE_LABORATORYID", --17实验室
  al."RECEIVETIME",--18实验室接收时间
  ps."CALIBRATION_DATE",----19检定日期
  ps."CHECKERID",----20检定/校准员
  ps."DETECTERID",----21核验员
ps."CERTIFICATE_CATEGORY",--22证书号类别
ps."REPORTNUMBER",----23证书/报告编号
  ps."CERTIFICATE_CATEGORY",----24证书类别
  ps."REPORT_CATEGORY",----25报告类别
  CASE
    when ps.QUALIFICATIONS     ='本单位获北京市质量技术监督局专项计量授权，证书编号：（京）法计（2012）006号'
    and ps.CERTIFICATE_CATEGORY='检定'
    and oti.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '北京授权检定'
    WHEN ps.qualifications     ='/'
    and ps.CERTIFICATE_CATEGORY='检定'
    and oti.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN ps.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and ps.CERTIFICATE_CATEGORY='校准'
    and oti.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN 'CNAS校准'
    WHEN ps.qualifications     ='/'
    and ps.CERTIFICATE_CATEGORY='校准'
    and oti.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '校准'
    WHEN ps.qualifications     ='本单位获河北市质量技术监督局专项计量授权，证书编号：（冀）法计（2014）D033号'
    and ps.CERTIFICATE_CATEGORY='检定'
    and oti.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '河北授权检定'
    WHEN ps.qualifications     ='/'
    and ps.CERTIFICATE_CATEGORY='检定'
    and oti.ACCEPT_ORGNIZATION  ='华北电力科学研究院有限责任公司'
    THEN '检定'
    WHEN ps.qualifications     ='本实验室获中国合格评定国家认可委员（CNAS）认可证书，证书号No.L0394'
    and ps.CERTIFICATE_CATEGORY='校准'
    and oti.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN 'CNAS校准'
    WHEN ps.qualifications     ='/'
    and ps.CERTIFICATE_CATEGORY='校准'
    and oti.ACCEPT_ORGNIZATION  ='冀北电力有限公司计量中心'
    THEN '校准'
    ELSE ''
  end as SHOUQUANZIZHI, ----26授权/资质
al."ORDER_STATUS",--27器具状态
 '',--28有效期至
    ps."APPROVALDATE",--29报告审批通过日期
  ps."REPORTSTATUS", --30报告状态
 '',--31送检月度
 '',--32检定时间
 '',--33检定月度
 '',--34报告时间
 '',--35报告月度
 '',--36工作时间
 '',--37总时间
  adi."REMARKS"--38备注
    
  from PREPARE_SCHEME ps
inner join APPLIANCE_LABORATORY al
on al.PREPARE_SCHEMEID=ps.id
inner join APPLIANCE_DETAIL_INFORMATION adi
on al.appliance_detail_informationid=adi.id
inner join ORDER_TASK_INFORMATION oti
on oti.id=adi.order_task_informationid