CREATE TABLE [dbo].[EmployeeMst] (
    [EmployeeID]  INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50) NULL,
    [MiddleName]   NVARCHAR (50) NULL,
    [LastName] NVARCHAR (50) NULL,
    [Emp_Code] NVARCHAR (50) NULL,
    [DateOfBirth] DATETIME NULL,
    [JoiningDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);
