	

select w, count(*) from kms group by w;

select w, sum(case w when 1 then 1 else 0 end) male, sum(case w when 2 then 1 else 0 end) as female from kms group by w;

select w, sum(1) male, sum(1) as female from kms group by w;

use kms;
select yy,[01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] 
 from (select recid, month(dr) as mm, year(dr) as yy from kms) as ww pivot (count(recid) for mm in 
 ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] )) as ww

 select month(dr), count(*) from kms group by month(dr) order by month(dr);

 select w,year(dr) year, count(recid) cnt from kms group by grouping sets( (w, year(dr)),(year(dr)),()) order by year(dr),w;

  select w,year(dr) year, count(recid) cnt from kms group by rollup( (w, year(dr)),(year(dr))) order by year(dr),w;

  select year(dr), w, count(*) as cnt from kms group by rollup(year(dr), w)