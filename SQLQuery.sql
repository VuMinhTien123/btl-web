create database WebsiteBanHang
use WebsiteBanHang
go
create TABLE [dbo].[Category] (
    [CateId]            INT   primary key           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NULL,
    [Avatar]         NCHAR (100)    NULL,
    [Slug]           VARCHAR (100)  NULL,
    [ShowOnHomePage] BIT            NULL,
    [DisplayOrder]   INT            NULL,
    [Deleted]        BIT            NULL,
    [CreatedOnUtc]   DATETIME       NULL,
    [UpdateOnUtc]    DATETIME       NULL
)


go
create TABLE [dbo].[Product] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NULL,
    [Avartar]         image   NULL,
    CateId      INT   foreign key  references Category(CateId)       NULL,
    [ShortDes]        NVARCHAR (100) NULL,
    [FullDescription] NVARCHAR (500) NULL,
    [Price]           FLOAT (53)     NULL,
    [PriceDiscount]   FLOAT (53)     NULL,
    [Typeld]          INT            NULL,
    [Slug]            VARCHAR (50)   NULL,
    [BrandId]         INT            NULL,
    [Deleted]         BIT            NULL,
    [ShowOnHomePage]  BIT            NULL,
    [DisplayOrder]    INT            NULL,
    [CreatedOnUtc]    DATETIME       NULL,
    [UpdateOnUtc]     DATETIME       NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)


go
CREATE TABLE [dbo].[Users] (
    [idUser]    INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [Email]     VARCHAR (50) NULL,
    [Password]  VARCHAR (50) NULL,
    [IsAdmin]   BIT          NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([idUser] ASC)
)

go
CREATE TABLE [dbo].[Order] (
    [OrderId]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NULL,
    [UserId]       INT       foreign key references Users(idUser)     NULL,
    [Status]       INT            NULL,
    [CreatedOnUtc] DATETIME       NULL,
    [Address]      NVARCHAR (250) NULL,
    [Phone]        INT            NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC)
)
go 
create TABLE [dbo].[OrderDetail] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL ,
    [OrderId]   INT foreign key references [dbo].[Order](OrderId) NULL,
    [ProductId] INT foreign key references [dbo].Product(Id) NULL,
    [Quantity]  INT NULL,
    [Price]     INT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
)


Insert into Category(Name, Slug) values( N'Evoo', N'maytinh')


insert into Product(Name, CateId, Price, ShortDes, FullDescription, Typeld) values( N'Asus', 1, 30000, N'Mô tả ngắn', N'Mô tả đầy đủ', 2)
