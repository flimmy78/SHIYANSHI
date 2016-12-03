
  CREATE OR REPLACE FORCE VIEW TENGFEI.VZHENGSHULEIBEITONGJIFENXI 
  (
  ID, ----1主键 
  SUOSHUDANWEI,----2所属单位
  ZHENGSHUDANWEI, ----3证书单位
  SHOULIDANWEI,----4受理单位
  PIZHUNJIELUN, ----5批准结论
  PIZHUNSHIJIAN, ----6批准时间
  SHOUQUANZIZHI,----7授权/资质
  ZHENGSHULEIBIE,----8证书类别
  BAOGAOLEIBIE, ----9报告类别
  BAOGAOSHULIANG----10报告数量
  ) AS 
  select al.ID,----1主键  
    '',----2所属单位
    oti.CERTIFICATE_ENTERPRISE,----3证书单位
    oti.ACCEPT_ORGNIZATION,----4受理单位
  ps.APPROVALISAGGREY,----5批准结论
  ps.APPROVALDATE,----6批准时间
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
  end as SHOUQUANZIZHI, ----7授权/资质
    ps.CERTIFICATE_CATEGORY,----8证书类别
  ps.REPORT_CATEGORY,----9报告类别
  1----10报告数量
    
  from PREPARE_SCHEME ps
inner join APPLIANCE_LABORATORY al
on al.PREPARE_SCHEMEID=ps.id
inner join APPLIANCE_DETAIL_INFORMATION adi
on al.appliance_detail_informationid=adi.id
inner join ORDER_TASK_INFORMATION oti
on oti.id=adi.order_task_informationid;
 
