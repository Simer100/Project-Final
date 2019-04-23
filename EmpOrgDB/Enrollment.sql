CREATE TABLE [dbo].[Enrollment] (
    [EnrollmentID] INT            IDENTITY (1, 1) NOT NULL,
    [Band]         DECIMAL (3, 2) NULL,
    [Dept_ID] INT            NOT NULL,
    [EmployeeID]   INT            NOT NULL,
	[ZoneID]       INT            NOT NULL,
	[StateID]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([EnrollmentID] ASC)
);
GO
ALTER TABLE [dbo].[Enrollment] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Enrollment_dbo.Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[EmployeeMst] ([EmployeeID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[Enrollment] WITH CHECK CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Employee_EmployeeID];
GO
ALTER TABLE [dbo].[Enrollment] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Enrollment_dbo.DepMst_Dept_ID] FOREIGN KEY ([Dept_ID]) REFERENCES [dbo].[DepMst] ([Dept_ID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[Enrollment] WITH CHECK CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.DepMst_Dept_ID];
GO
ALTER TABLE [dbo].[Enrollment] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Enrollment_dbo.StateMst_StateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[StateMst] ([StateID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[Enrollment] WITH CHECK CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.StateMst_StateID];
GO
ALTER TABLE [dbo].[Enrollment] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Enrollment_dbo.ZoneMst_ZoneID] FOREIGN KEY ([ZoneID]) REFERENCES [dbo].[ZoneMst] ([ZoneID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[Enrollment] WITH CHECK CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.ZoneMst_ZoneID];