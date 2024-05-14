-- PARTITION
-- BOOKING
-- Mô tả: Tạo partition phân đoạn theo ngày khám (< '2022-01-01', '2022-01-01' đến <'2023-01-01', từ '2023-01-01' về sau')

use csdlnc05
go

 -- '2022-01-01','2023-01-01'
-- tạo file group 
alter database CSDLNC05
ADD FILEGROUP FG1

alter database CSDLNC05
ADD FILEGROUP FG2

alter database CSDLNC05
ADD FILEGROUP FG3 

ALTER DATABASE CSDLNC05
ADD FILE(NAME = FG1,
FILENAME = 'D:\DBForPartition_1.mdf',
SIZE=2,
MAXSIZE=100,
FILEGROWTH=1)
TO FILEGROUP FG1

ALTER DATABASE CSDLNC05
ADD FILE(NAME = FG2,
FILENAME = 'D:\DBForPartition_2.ndf',
SIZE=2,
MAXSIZE=100,
FILEGROWTH=1)
TO FILEGROUP FG2

ALTER DATABASE CSDLNC05
ADD FILE(NAME = FG3,
FILENAME = 'D:\DBForPartition_3.ndf',
SIZE=2,
MAXSIZE=100,
FILEGROWTH=1)
TO FILEGROUP FG3

-- tao partition function
CREATE PARTITION FUNCTION BookingPartition(DATETIME)
AS 
	RANGE RIGHT 
	FOR VALUES ('2022-01-01','2023-01-01')
GO

-- tao partition scheme
CREATE PARTITION SCHEME BookingPartitionScheme
AS PARTITION BookingPartition
to (FG1,FG2,FG3)

-- tạo clustered index 
alter table booking
drop constraint PK_BOOKING

ALTER TABLE BOOKING
ADD PRIMARY KEY NONCLUSTERED(BOOKINGID)
ON [PRIMARY]
GO
create clustered index IX_BOOKINGTIME_DATETIME 
ON BOOKING
(
	[TIME]
) ON BookingPartitionScheme([TIME])
GO

-- Test
SELECT ps.name As [Name of PS], pf.name As [Name of PF], prf.boundary_id, prf.value
FROM sys.partition_schemes ps
INNER JOIN sys.partition_functions pf ON pf.function_id = ps.function_id
INNER JOIN sys.partition_range_values prf ON pf.function_id = prf.function_id
GO

-- Exec
SELECT * FROM BOOKING WHERE $Partition.[BookingPartition] ([TIME]) in (1);


-------------------------------
--------------------------------


CREATE PARTITION FUNCTION PART_FUNC_TREATMENTPLAN(DATETIME) AS RANGE LEFT FOR VALUES ('1-1-2020', '1-1-2021', '1-1-2022', '1-1-2023', '1-1-2024')


ALTER DATABASE CSDLNC04 ADD FILEGROUP FG1;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG2;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG3;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG4;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG5;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG6;
ALTER DATABASE CSDLNC04 ADD FILEGROUP FG7;

ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup1,  
    FILENAME = 'D:\CSDLNC\filegroup1.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG1;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup2,  
    FILENAME = 'D:\CSDLNC\filegroup2.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG2;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup3,  
    FILENAME = 'D:\CSDLNC\filegroup3.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG3;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup4,  
    FILENAME = 'D:\CSDLNC\filegroup4.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG4;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup5,  
    FILENAME = 'D:\CSDLNC\filegroup5.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG5;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup6,  
    FILENAME = 'D:\CSDLNC\filegroup6.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG6;  
ALTER DATABASE CSDLNC04  
ADD FILE   
(  
    NAME = filegroup7,  
    FILENAME = 'D:\CSDLNC\filegroup7.ndf',  
    SIZE = 25MB,  
    FILEGROWTH = 25MB  
)  
TO FILEGROUP FG7;  



CREATE PARTITION SCHEME TREATMENTPLAN_SCHEME AS PARTITION PART_FUNC_TREATMENTPLAN TO (FG1, FG2, FG3, FG4, FG5, FG6, FG7)

create table TREATMENTPLAN (
   PATIENTID            numeric              not null,
   DENTISTID            numeric              not null,
   DATE                 datetime             not null,
   PLANID               numeric              identity,
   ASSISTANTID          numeric              null,
   NOTE                 nvarchar(50)                  null,
   STATUS               nvarchar(50)                  null
) ON TREATMENTPLAN_SCHEME (DATE)
go

CREATE CLUSTERED INDEX IND ON TREATMENTPLAN(DATE) ON TREATMENTPLAN_SCHEME (DATE)


ALTER TABLE TREATMENTPLAN ADD CONSTRAINT PK_TREATMENTPLAN PRIMARY KEY NONCLUSTERED(PLANID, DATE)

ALTER TABLE TREATMENTPLAN
ALTER COLUMN NOTE nvarchar(150);

CREATE INDEX IDX_MEDID ON MEDICATION(MEDICATIONID);

SELECT * FROM MEDICATION 