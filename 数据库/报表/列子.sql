
select UNDERTAKE_LABORATORYID,
sum(case when conclusion='合格' then icount end) 合格,
sum(case when conclusion='不合格' then icount end) 不合格
from (
select UNDERTAKE_LABORATORYID,'合格' conclusion,COUNT(ps.id) icount from APPLIANCE_LABORATORY al
left join PREPARE_SCHEME ps on al.PREPARE_SCHEMEID=ps.id
and ps.conclusion='合格'
group by UNDERTAKE_LABORATORYID
union all
select UNDERTAKE_LABORATORYID,'不合格' conclusion,COUNT(ps.id) icount  from APPLIANCE_LABORATORY al
left join PREPARE_SCHEME ps on al.PREPARE_SCHEMEID=ps.id
and ps.conclusion='不合格'
group by UNDERTAKE_LABORATORYID
) tempA 
group by UNDERTAKE_LABORATORYID
