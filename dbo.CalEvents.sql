CREATE TABLE [dbo].[CalEvents] (
    [EventID]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (MAX) NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [Location]      NVARCHAR (MAX) NULL,
    [StartTime]     DATETIME       NOT NULL,
    [Duration]      TIME (7)       NOT NULL,
    [CustomerID]    INT            NULL,
    [RoomNumber]    INT            NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    [RoomNum]       INT     NOT NULL,
    [CustIDen]      INT     NOT NULL,
    CONSTRAINT [PK_dbo.CalEvents] PRIMARY KEY CLUSTERED ([EventID] ASC)
);

