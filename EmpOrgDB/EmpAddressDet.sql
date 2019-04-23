CREATE TABLE [dbo].[EmpAddressDet] (
    [AddressID] INT      IDENTITY (1, 1) NOT NULL,
    [Address1]        NVARCHAR (50) NULL,
	[Address2]        NVARCHAR (50) NULL,
	[EmployeeID]        INT  NOT NULL,
	[ZoneID]        INT  NOT NULL,
	[StateID]       INT  NOT NULL,
	[PinCode]       INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([AddressID] ASC)
);
GO
ALTER TABLE [dbo].[EmpAddressDet] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.EmpAddressDet_dbo.ZoneMst_ZoneID] FOREIGN KEY ([ZoneID]) REFERENCES [dbo].[ZoneMst] ([ZoneID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[EmpAddressDet] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.EmpAddressDet_dbo.StateMst_StateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[StateMst] ([StateID]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[EmpAddressDet] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.EmpAddressDet_dbo.EmployeeMst_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[EmployeeMst] ([EmployeeID]) ON DELETE CASCADE;
