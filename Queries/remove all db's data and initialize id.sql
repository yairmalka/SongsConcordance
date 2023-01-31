
use TextApp
delete WordsVsGroups delete groups  delete from ExpressionsVsPositions delete from LinguisticExpressions
delete from Positions delete from words delete from songs
use TextAppBackUp
delete WordsVsGroups delete groups  delete from ExpressionsVsPositions delete from LinguisticExpressions
delete from Positions delete from words delete from songs

use TextApp
DBCC CHECKIDENT ([ExpressionsVsPositions], RESEED, 0);
DBCC CHECKIDENT ([Songs], RESEED, 0);
DBCC CHECKIDENT ([Words], RESEED, 0);
DBCC CHECKIDENT ([WordsVsGroups], RESEED, 0);
DBCC CHECKIDENT (LinguisticExpressions, RESEED, 0);
DBCC CHECKIDENT (Groups, RESEED, 0);
GO
use TextAppBackUp
DBCC CHECKIDENT ([ExpressionsVsPositions], RESEED, 0);
DBCC CHECKIDENT ([Songs], RESEED, 0);
DBCC CHECKIDENT ([Words], RESEED, 0);
DBCC CHECKIDENT ([WordsVsGroups], RESEED, 0);
DBCC CHECKIDENT (LinguisticExpressions, RESEED, 0);
DBCC CHECKIDENT (Groups, RESEED, 0);
GO

select wordvalue, count(*) as [real occurences]
from positions
group by WordValue
order by [real occurences], WordValue


use TextAppBackUp
drop table WordsVsGroups drop table groups drop table ExpressionsVsPositions drop table LinguisticExpressions drop table Positions drop table words drop table songs;
 
 