CREATE TABLE [dbo].[DepMst] (
    [Dept_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Dept_Name]        NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Dept_ID] ASC)
);