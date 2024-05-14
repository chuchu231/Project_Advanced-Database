create or alter proc select_booking
as
begin
	select b.BOOKINGID as N'Mã', p.LASTNAME + ' ' + p.FIRSTNAME as N'Bệnh nhân',  d1.LASTNAME + ' ' + d2.FIRSTNAME as N'Nha sĩ phụ trách', 
	d2.LASTNAME + ' ' + d2.FIRSTNAME as N'Trợ khám', b.ROOM as N'Phòng', convert(date,b.TIME) as 'Ngày khám', convert(time,b.TIME) as 'Giờ khám'
	from booking b join dentist d1 on d1.ID=b.DENTISTID join dentist d2 on d2.id=b.ASSISTANTID 
	join patient p on p.id=b.PATIENTID
end
go

create or alter proc search_booking_patient @name  nvarchar(50)
as
begin
	select b.BOOKINGID as N'Mã', p.LASTNAME + ' ' + p.FIRSTNAME as N'Bệnh nhân',  d1.LASTNAME + ' ' + d2.FIRSTNAME as N'Nha sĩ phụ trách', 
	d2.LASTNAME + ' ' + d2.FIRSTNAME as N'Trợ khám', b.ROOM as N'Phòng', convert(date,b.TIME) as 'Ngày khám', convert(time,b.TIME) as 'Giờ khám'
	from booking b join dentist d1 on d1.ID=b.DENTISTID join dentist d2 on d2.id=b.ASSISTANTID 
	join patient p on p.id=b.PATIENTID
	where p.LASTNAME + ' ' + p.FIRSTNAME= @name
end
go

create or alter proc search_booking_dentist_forAdmandStaff @name nvarchar(50)
as
begin
	select b.BOOKINGID as N'Mã', p.LASTNAME + ' ' + p.FIRSTNAME as N'Bệnh nhân',  d1.LASTNAME + ' ' + d2.FIRSTNAME as N'Nha sĩ phụ trách', 
	d2.LASTNAME + ' ' + d2.FIRSTNAME as N'Trợ khám', b.ROOM as N'Phòng', convert(date,b.TIME) as 'Ngày khám', convert(time,b.TIME) as 'Giờ khám'
	from booking b join dentist d1 on d1.ID=b.DENTISTID join dentist d2 on d2.id=b.ASSISTANTID 
	join patient p on p.id=b.PATIENTID
	where d1.LASTNAME + ' ' + d2.FIRSTNAME = @name
end
go

create or alter proc search_booking_dentist_forDentist @username char(20)
as
begin
	select b.BOOKINGID as N'Mã', p.LASTNAME + ' ' + p.FIRSTNAME as N'Bệnh nhân',  d1.LASTNAME + ' ' + d2.FIRSTNAME as N'Nha sĩ phụ trách', 
	d2.LASTNAME + ' ' + d2.FIRSTNAME as N'Trợ khám', b.ROOM as N'Phòng', convert(date,b.TIME) as 'Ngày khám', convert(time,b.TIME) as 'Giờ khám'
	from booking b join dentist d1 on d1.ID=b.DENTISTID join dentist d2 on d2.id=b.ASSISTANTID 
	join patient p on p.id=b.PATIENTID
	where d1.USERNAME=@username
end
go

create or alter proc search_booking_room @room char(10)
as
begin
	select b.BOOKINGID as N'Mã', p.LASTNAME + ' ' + p.FIRSTNAME as N'Bệnh nhân',  d1.LASTNAME + ' ' + d2.FIRSTNAME as N'Nha sĩ phụ trách', 
	d2.LASTNAME + ' ' + d2.FIRSTNAME as N'Trợ khám', b.ROOM as N'Phòng', convert(date,b.TIME) as 'Ngày khám', convert(time,b.TIME) as 'Giờ khám'
	from booking b join dentist d1 on d1.ID=b.DENTISTID join dentist d2 on d2.id=b.ASSISTANTID 
	join patient p on p.id=b.PATIENTID
	where b.ROOM=@room
end
go

create or alter proc delete_per_schedule @username char(10), @time time, @date datetime
as
begin
	declare @id numeric
	set @id = (select id
				from dentist 
				where USERNAME = @username )
	delete PERSONALSCHEDULE 
	where ID = @id and 
	convert(time,[datetime]) = @time and
	convert(date,[datetime]) = @date
end

go

create or alter proc update_per_schedule @username char(10), @time datetime, @date datetime
as
begin
	declare @id numeric
	set @id = (select id
				from dentist 
				where USERNAME = @username )
	update PERSONALSCHEDULE 
	set [datetime]= @date + @time 
	where ID = @id
end

go
create or alter proc add_per_schedule @username char(10), @time datetime, @date datetime
as
begin
	declare @id numeric
	set @id = (select id
				from dentist 
				where USERNAME = @username )
	insert into PERSONALSCHEDULE (ID,[DATETIME]) values (@id, @date + @time)
end            
USE [CSDLNC05]
GO
/****** Object:  StoredProcedure [dbo].[addAppointment]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[addAppointment] @ID_BN numeric ,@ID_BS numeric ,@DATE datetime ,@ID_TK numeric ,@ROOM char(10),@STATUS nvarchar(50) 
as
begin
 insert into BOOKING(PATIENTID,DENTISTID,TIME,ASSISTANTID,ROOM,STATUS) values (@ID_BN,@ID_BS,@DATE,@ID_TK,@ROOM,@STATUS)
end
GO
/****** Object:  StoredProcedure [dbo].[addInvoice]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE
OR alter
proc [dbo].[addInvoice]  @Plan_ID numeric, @PAY float,@NOTE nvarchar(50), @METHOD nvarchar(50)
as

-- B2: Tao hoa don thanh toan
DEClARE 

@medCost float,

@serviceCost float 


SET @medCost =  (SELECT SUM(ISNULL(med.Price * inc.AMOUNT,0))

FROM TREATMENTPLAN mr
left join PRESCRIPTION inc on mr.PLANID=inc.PLANID
left join MEDICATION med on med.MEDICATIONID = inc.MEDICATIONID
LEFT JOIN dbo.PATIENT p ON p.ID = mr.PATIENTID
WHERE mr.PLANID= @Plan_ID
 )

SET @serviceCost = (SELECT SUM(ISNULL(svd.fee,0))  

FROM TREATMENTPLAN mr, TREATMENTDETAIL svd

WHERE mr.PLANID= @Plan_ID

AND mr.PLANID=svd.PLANID )


INSERT INTO INVOICE(PLANID,TOTALPAYMENT,PAYMENTMETHOD,RECEIVEDAMOUNT,CHANGEAMOUNT,NOTE) VALUES (@Plan_ID,@serviceCost+@medCost,@METHOD,@PAY,@PAY-@medCost-@serviceCost,@NOTE) 
GO
/****** Object:  StoredProcedure [dbo].[addMedPre]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[addMedPre] @ID_MED numeric ,@ID_PLAN numeric ,@AMOUNT int ,@DES nvarchar(50)
AS
BEGIN
   INSERT INTO dbo.PRESCRIPTION(    MEDICATIONID,    PLANID,    AMOUNT,  DESCRIPTION)VALUES(  @ID_MED,@ID_PLAN,@AMOUNT,@DES   )
END
GO
/****** Object:  StoredProcedure [dbo].[addTreatment]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[addTreatment] @ID_BN numeric, @ID_NS numeric, @NGAY datetime , @ID_TK numeric, @NOTE nvarchar(50), @STATUS nvarchar(50)
AS
BEGIN
    

INSERT INTO dbo.TREATMENTPLAN(PATIENTID,DENTISTID,DATE,ASSISTANTID,NOTE,STATUS)
VALUES(@ID_BN,@ID_NS,@NGAY,@ID_TK,@NOTE,@STATUS )
END
GO
/****** Object:  StoredProcedure [dbo].[addTreatmentDetail]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[addTreatmentDetail] @ID_Plan numeric ,@ID_TEETH numeric ,@FEE float ,@DES nvarchar(50)
AS	
BEGIN
    INSERT INTO dbo.TREATMENTDETAIL(       PLANID,    TEETH,   FEE,    DESCRIPTION)VALUES( @ID_Plan,@ID_TEETH,@FEE,@DES  )
END
GO
/****** Object:  StoredProcedure [dbo].[addTreatmentPlan]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[addTreatmentPlan] @ID_BN numeric, @ID_NS numeric, @NGAY datetime , @ID_TK numeric, @NOTE nvarchar(50), @STATUS nvarchar(50)
AS
BEGIN
    

INSERT INTO dbo.TREATMENTPLAN(PATIENTID,DENTISTID,DATE,ASSISTANTID,NOTE,STATUS)
VALUES(@ID_BN,@ID_NS,@NGAY,@ID_TK,@NOTE,@STATUS )
END
GO
/****** Object:  StoredProcedure [dbo].[deleteMedPre]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	 [dbo].[deleteMedPre] @ID_PLAN numeric, @ID_MED numeric
AS	
BEGIN
    DELETE FROM dbo.PRESCRIPTION WHERE PLANID= @ID_PLAN AND MEDICATIONID = @ID_MED
END
GO
/****** Object:  StoredProcedure [dbo].[DentistBookingByDate]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[DentistBookingByDate] @ID_NS numeric, @START datetime, @END datetime
AS
BEGIN
    SELECT PATIENTID AS MÃ_BN, TIME AS Ngày, ROOM AS Phòng FROM dbo.BOOKING WHERE DENTISTID = @ID_NS AND TIME BETWEEN @START AND @END
END
GO
/****** Object:  StoredProcedure [dbo].[DentistTreatmentByDate]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[DentistTreatmentByDate] @ID_NS numeric, @START datetime, @END datetime
AS	
BEGIN
    SELECT tp.PATIENTID AS MÃ_BN, td.DESCRIPTION AS ĐIỀU_TRỊ, tp.DATE AS Ngày
	FROM dbo.TREATMENTPLAN tp,   dbo.TREATMENTDETAIL td
	WHERE tp.DENTISTID = @ID_NS
	AND td.PLANID = tp.PLANID
	AND tp.DATE BETWEEN @START and @END 
END
GO
/****** Object:  StoredProcedure [dbo].[editMedByPlan]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[editMedByPlan] @ID_MED numeric, @ID_PLAN numeric, @DES nvarchar(50), @AMOUNT int
AS	
BEGIN
    UPDATE dbo.PRESCRIPTION
	SET AMOUNT = @AMOUNT, DESCRIPTION = @DES
	WHERE PLANID= @ID_PLAN AND MEDICATIONID = @ID_MED
END
GO
/****** Object:  StoredProcedure [dbo].[FindUser]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindUser]
    @InputUsername VARCHAR(50),
    @InputPassword VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem tài khoản có tồn tại trong bảng Dentist không
    IF EXISTS (SELECT 1 FROM Dentist WHERE Username = @InputUsername AND Password = @InputPassword)
    BEGIN
        SELECT *
        FROM Dentist
        WHERE Username = @InputUsername AND Password = @InputPassword;
    END
    ELSE
    BEGIN
        -- Nếu không tìm thấy trong bảng Dentist, kiểm tra trong bảng Staff
        IF EXISTS (SELECT 1 FROM Staff WHERE Username = @InputUsername AND Password = @InputPassword)
        BEGIN
            SELECT *
            FROM Staff
            WHERE Username = @InputUsername AND Password = @InputPassword;
        END
        ELSE
        BEGIN
            -- Trả về một kết quả trống nếu không tìm thấy ở cả hai bảng
            SELECT NULL AS DummyResult;
        END
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[getInvoice]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create
--alter
proc [dbo].[getInvoice]  @Plan_ID numeric
as

-- B2: Tao hoa don thanh toan
DEClARE 

@medCost float,

@serviceCost float 


SET @medCost =  (SELECT SUM(ISNULL(med.Price * inc.AMOUNT,0))

FROM TREATMENTPLAN mr
left join PRESCRIPTION inc on mr.PLANID=inc.PLANID
left join MEDICATION med on med.MEDICATIONID = inc.MEDICATIONID
LEFT JOIN dbo.PATIENT p ON p.ID = mr.PATIENTID
WHERE mr.PLANID= @Plan_ID
 )

SET @serviceCost = (SELECT SUM(ISNULL(svd.fee,0))  

FROM TREATMENTPLAN mr, TREATMENTDETAIL svd

WHERE mr.PLANID= @Plan_ID

AND mr.PLANID=svd.PLANID )


select @Plan_ID as Mã_kế_hoạch, @medCost+@serviceCost as Tổng
GO
/****** Object:  StoredProcedure [dbo].[getInvoiceByPA]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getInvoiceByPA] @PA numeric
as
begin
select iv.INVOICEID as Mã, iv.PLANID as Mã_điều_trị, iv.TOTALPAYMENT as Tổng
from INVOICE iv, TREATMENTPLAN tm 
where iv.PLANID = tm.PLANID and tm.PATIENTID = @PA
end
GO
/****** Object:  StoredProcedure [dbo].[LOGIN]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[LOGIN]
    @USERNAME CHAR(10),
    @PASSWORD CHAR(10)
AS
BEGIN
    DECLARE @result CHAR(20);

    IF (@USERNAME IS NULL OR @PASSWORD IS NULL)
    BEGIN
        SET @result = 'InvalidInput';
    END
    ELSE IF EXISTS (SELECT 1 FROM dbo.DENTIST WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD)
    BEGIN
        SET @result = 'Dentist';
    END
    ELSE IF EXISTS (SELECT 1 FROM dbo.STAFF WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD)
    BEGIN
        SET @result = 'Staff';
    END
    
    ELSE IF @USERNAME = 'admin'
    BEGIN
        SET @result = 'Admin';
    END
    ELSE
    BEGIN
        SET @result = 'UserNotFound';
    END

    SELECT @result AS 'UserRole';
END;
GO
/****** Object:  StoredProcedure [dbo].[MedByPlan]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[MedByPlan] @ID_PLAN numeric
AS
BEGIN
    SELECT med.MEDICATIONID as Mã, med.MEDICATIONNAME as Thuốc, pr.AMOUNT as SL, pr.DESCRIPTION as HDSD FROM dbo.PRESCRIPTION pr LEFT JOIN dbo.MEDICATION med ON pr.MEDICATIONID = med.MEDICATIONID where pr.PLANID=@ID_Plan
END
GO
/****** Object:  StoredProcedure [dbo].[MedList]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MedList]
AS
	SET NOCOUNT ON;
SELECT MEDICATION.*
FROM     MEDICATION
GO
/****** Object:  StoredProcedure [dbo].[PlanDetailByPlan]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	 [dbo].[PlanDetailByPlan] @IDPlan numeric
AS	
BEGIN
    

SELECT distinct tp.PLANID AS Mã, dt.FIRSTNAME AS Nha_sĩ,ast.FIRSTNAME AS Trợ_khám, tp.DATE AS Ngày, tp.NOTE, tp.STATUS
FROM dbo.TREATMENTPLAN tp 
LEFT JOIN dbo.DENTIST dt ON tp.DENTISTID = dt.ID
LEFT JOIN dbo.DENTIST ast ON tp.ASSISTANTID = ast.ID
LEFT JOIN dbo.TREATMENTDETAIL td ON tp.PLANID = td.PLANID WHERE tp.PLANID =@IDPlan
END
GO
/****** Object:  StoredProcedure [dbo].[PlanListByPA]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PlanListByPA] @IDBN numeric
AS	
BEGIN	
SELECT PLANID as Mã_kế_hoạch, Date as Ngày FROM dbo.TREATMENTPLAN WHERE PATIENTID = @IDBN 
END
GO
/****** Object:  StoredProcedure [dbo].[TeethByPlan]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[TeethByPlan] @IDPlan numeric
AS	
BEGIN
SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt, td.DESCRIPTION as Điều_trị
FROM dbo.TREATMENTPLAN tp 
LEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID
LEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH
WHERE tp.PLANID = @IDPlan
END
GO
/****** Object:  StoredProcedure [dbo].[updateAppointment]    Script Date: 1/11/2024 4:45:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateAppointment] @ID_BN numeric ,@ID_BS numeric ,@DATE datetime ,@ID_TK numeric ,@ROOM char(10),@STATUS nvarchar(50), @ID_BOOK numeric
as
begin
 update BOOKING set PATIENTID = @ID_BN,DENTISTID= @ID_BS,TIME = @DATE,ASSISTANTID= @ID_TK,ROOM = @ROOM,STATUS=@STATUS where BOOKINGID=@ID_BOOK
end
GO
USE [CSDLNC05]
GO
/****** Object:  StoredProcedure [dbo].[FindUser]    Script Date: 1/11/2024 1:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindUser]
    @InputUsername VARCHAR(50),
    @InputPassword VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem tài khoản có tồn tại trong bảng Dentist không
    IF EXISTS (SELECT 1 FROM Dentist WHERE Username = @InputUsername AND Password = @InputPassword)
    BEGIN
        SELECT *
        FROM Dentist
        WHERE Username = @InputUsername AND Password = @InputPassword;
    END
    ELSE
    BEGIN
        -- Nếu không tìm thấy trong bảng Dentist, kiểm tra trong bảng Staff
        IF EXISTS (SELECT 1 FROM Staff WHERE Username = @InputUsername AND Password = @InputPassword)
        BEGIN
            SELECT *
            FROM Staff
            WHERE Username = @InputUsername AND Password = @InputPassword;
        END
        ELSE
        BEGIN
            -- Trả về một kết quả trống nếu không tìm thấy ở cả hai bảng
            SELECT NULL AS DummyResult;
        END
    END
END;
GO
GO
