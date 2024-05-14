CREATE TRIGGER UniqueUsernameDentist
ON dbo.DENTIST
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.DENTIST d ON i.username = d. USERNAME
    )
    BEGIN
    RAISERROR(N'Error: Duplicate username. Each dentist must have a unique username.', 16, 1);
    END
    ELSE
    BEGIN
       INSERT INTO DENTIST (STATUS, FIRSTNAME, LASTNAME, PHONENUMBER, DOB, ADDRESS, [PASSWORD], [USERNAME])
    SELECT
        STATUS,
		FIRSTNAME,
        LASTNAME, 
        PHONENUMBER,
        DOB,
        ADDRESS,
        [PASSWORD],
        [USERNAME]
    FROM inserted;
	END
END;
GO
CREATE TRIGGER UniqueUsernameStaff
ON dbo.STAFF
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.STAFF d ON i.username = d. USERNAME
    )
    BEGIN
    RAISERROR(N'Error: Duplicate username. Each dentist must have a unique username.', 16, 1);

    END
    ELSE
    BEGIN
       INSERT INTO dbo.STAFF (STATUS, FIRSTNAME, LASTNAME, PHONENUMBER, DOB, ADDRESS, [PASSWORD], [USERNAME])
    SELECT
        STATUS,
		FIRSTNAME,
        LASTNAME, 
        PHONENUMBER,
        DOB,
        ADDRESS,
        [PASSWORD],
        [USERNAME]
    FROM inserted;
	END
END;
GO
CREATE TRIGGER UniquePhoneNumber
ON dbo.PATIENT
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.PATIENT d ON i.PHONENUMBER = d. PHONENUMBER
    )
    BEGIN
	     RAISERROR(N'Error: Duplicate PhoneNumber. Each dentist must have a unique PhoneNumber.', 16, 1);

    END
    ELSE
    BEGIN
       INSERT INTO dbo.STAFF (STATUS, FIRSTNAME, LASTNAME, PHONENUMBER, DOB, ADDRESS)
    SELECT
        STATUS,
		FIRSTNAME,
        LASTNAME, 
        PHONENUMBER,
        DOB,
        ADDRESS
    FROM inserted;
	END
END;
GO
CREATE TRIGGER ValidateAppointment
ON dbo.BOOKING
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE YEAR(inserted.TIME) > YEAR(GETDATE())
    )
    BEGIN
        RAISERROR(N'Ngày đặt lịch phải có năm bé hơn hoặc bằng năm hiện tại.', 16, 1);
    END
    ELSE
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM inserted i
            WHERE EXISTS (
                SELECT 1
                FROM dbo.BOOKING a
                WHERE a.PatientID = i.PatientID
                  AND a.TIME = i.TIME)
        )
        BEGIN
            RAISERROR(N'Mỗi bệnh nhân chỉ được phép đăng ký một cuộc hẹn tại một thời điểm cụ thể.', 16, 1);
        END
        ELSE
        BEGIN 
            IF EXISTS (
                SELECT 1
                FROM inserted i
                WHERE EXISTS (
                    SELECT 1
                    FROM dbo.BOOKING a
                    WHERE a.ASSISTANTID = i.ASSISTANTID
                      AND a.TIME = i.TIME
                      AND a.ROOM = i.ROOM)
            )
            BEGIN
                RAISERROR(N'Mỗi nhân viên chỉ có thể được phân công vào một phòng khám nha khoa tại một thời điểm cụ thể.', 16, 1);
            END
            ELSE
            BEGIN
                INSERT INTO dbo.BOOKING
                (
                    PATIENTID,
                    DENTISTID,
                    TIME,
                    ASSISTANTID,
                    ROOM,
                    STATUS
                )
                SELECT
                    i.PatientID,
                    i.DentistID,
                    i.TIME,
                    i.ASSISTANTID,
                    i.ROOM,
                    i.STATUS
                FROM inserted i;
            END
        END
    END
END;
GO
CREATE TRIGGER ValidatePlan
ON dbo.TREATMENTPLAN
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
                SELECT 1
                FROM inserted i
                WHERE EXISTS (
                    SELECT 1
                    FROM dbo.TREATMENTPLAN a
                    WHERE a.PATIENTID = i.PATIENTID 
                      AND a.DATE = i.DATE)
            )
    BEGIN
        RAISERROR(N'Mỗi bệnh nhân chỉ có thể được phân bổ vào một kế hoạch điều trị tại một thời điểm.', 16, 1);
    END
    ELSE
    BEGIN
       INSERT INTO dbo.TREATMENTPLAN
       (
           PATIENTID,
           DENTISTID,
           DATE,
           ASSISTANTID,
           NOTE,
           STATUS
       )
      
    SELECT
        PATIENTID,
           DENTISTID,
           DATE,
           ASSISTANTID,
           NOTE,
           STATUS
    FROM inserted;
	END
END;
