RESTORE DATABASE AdventureWorks
FROM DISK = 'C:\Users\user\Documents\School\2017FALL\CS460\AdventureWorks2014.bak'  
WITH MOVE 'AdventureWorks2014_Data' TO 'C:\Users\user\Documents\School\2017FALL\CS460\homeworks\homework6\AdventureWorks.mdf',  
MOVE 'AdventureWorks2014_Log' TO 'C:\Users\user\Documents\School\2017FALL\CS460\homeworks\homework6\AdventureWorks.ldf' 