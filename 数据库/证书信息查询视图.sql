select al."ID",----1主键
  oti.INSPECTION_ENTERPRISE,---2送检单位
  oti."CERTIFICATE_ENTERPRISE",----3证书单位
  oti."ACCEPT_ORGNIZATION",----4受理单位
  '',----5出厂日期
  adi."APPLIANCE_NAME",----6器具名称
  '',----7生产厂家
  adi."VERSION",----8器具型号
  adi."FACTORY_NUM",----9出厂编号
  ps."ACCURACY_GRADE",----10准确度等级
  ps."CALIBRATION_DATE",----11检定日期
  ps."TEMPERATURE",----12温度（℃）
  ps."HUMIDITY",----13相对湿度（%）
  ps."PULSE_CONSTANT",----14脉冲常数(imp/kWh)
  adi."FORMAT",----15器具规格
  ps."CHECKERID",----16检定/校准员
  ps."DETECTERID",----17核验员
  ps."VALIDITY_PERIOD",----18有效期（年）
  add_months(CALIBRATION_DATE,12*VALIDITY_PERIOD) as YOUXIAOQIZHI,----19有效期至
  ps."REPORTNUMBER",----20证书/报告编号
  ps."CERTIFICATE_CATEGORY",----21证书类别
  ps."REPORT_CATEGORY",----22报告类别
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
  end as SHOUQUANZIZHI, ----23授权/资质
  (SELECT REPORTTORECEVESTATE from REPORTCOLLECTION where PREPARE_SCHEMEID=ps.id)----24发放状态
  --rn."REPORTTORECEVESTATE",----24发放状态
  oti."CERTIFICATE_ENTERPRISEHELLD",----25所属单位
  oti."ORDER_NUMBER",----26委托单号
  adi."REMARKS"----27备注

  
  from PREPARE_SCHEME ps
inner join APPLIANCE_LABORATORY al
on al.PREPARE_SCHEMEID=ps.id
--inner join REPORTCOLLECTION   rn
--on rn.PREPARE_SCHEMEID=ps.id
inner join APPLIANCE_DETAIL_INFORMATION adi
on al.appliance_detail_informationid=adi.id
inner join ORDER_TASK_INFORMATION oti
on oti.id=adi.order_task_informationid