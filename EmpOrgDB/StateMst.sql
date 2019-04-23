CREATE TABLE [dbo].[StateMst] (
    [StateID] INT      IDENTITY (1, 1) NOT NULL,
    [State_Name]        NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([StateID] ASC)
);