select min(vs) as start_range, max(vs) as end_range from (
select cast(vs as int) as vs, vs-ROW_NUMBER() over(order by vs desc) as grp from kms where vs>0) as d
group by grp

select cast(vs as int) as vs, vs-ROW_NUMBER() over(order by vs) as grp from kms where vs>0 order by vs desc

select b.ul,b.dom,b.kor,b.str,b.kv, count(*) as cnt from kms a
	inner join dbo.adr77 b on a.adr_id=b.recid
	group by b.ul, b.dom, b.kor, b.str, b.kv 
	order by cnt desc


select adr_id, count(*) as cnt from kms group by adr_id