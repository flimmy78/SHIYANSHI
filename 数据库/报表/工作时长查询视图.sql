select al.ID,----1主键
      oti.ORDER_NUMBER,----2委托单号
      '',----3所属单位
      oti.CERTIFICATE_ENTERPRISE,----4证书单位
      oti.ACCEPT_ORGNIZATION,--5受理单位 
      adi.APPLIANCE_NAME, --6器具名称
      '',--7生产厂家
      adi.VERSION, --8器具型号
      adi.FORMAT,--9器具规格
      adi.FACTORY_NUM, --10出厂编号
      adi.NUM, --11数量
      ps.REPORTNUMBER,--12证书/报告编号
      al.UNDERTAKE_LABORATORYID, --13实验室
      ps.CHECKERID, --14检定/校准员
      ps.DETECTERID,--15核验员
      '',--16出厂日期
      oti.CREATETIME, --17送检日期
      al.RECEIVETIME,--18实验室接收时间
      '',--19检定完成日期
      ps.AUDITTIME,--20审核日期
      ps.APPROVALDATE,--21批准日期
      '',--22待领取时长
      '',--23检定时长
      '',--24审核时长
      '',--25批准时长
      '',--26总时长
      adi.REMARKS--27备注  
                  
  from PREPARE_SCHEME ps
inner join APPLIANCE_LABORATORY al
on al.PREPARE_SCHEMEID=ps.id
inner join APPLIANCE_DETAIL_INFORMATION adi
on al.appliance_detail_informationid=adi.id
inner join ORDER_TASK_INFORMATION oti
on oti.id=adi.order_task_informationid