USE [EventManagerDb]
GO
/****** Object:  Table [dbo].[EventBooking]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventBooking](
	[BookingId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NULL,
	[EmailAddress] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
 CONSTRAINT [PK_EventBooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](50) NULL,
	[EventDesc] [varchar](max) NULL,
	[EventVenueId] [int] NOT NULL,
	[EventType] [varchar](200) NOT NULL,
	[EventDate] [date] NULL,
	[EventTime] [varchar](10) NULL,
	[EventFee] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventUsers]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventUsers](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserFirstName] [varchar](50) NULL,
	[UserLastName] [varchar](50) NULL,
	[UserAddress] [varchar](200) NULL,
	[EmailAddress] [varchar](50) NULL,
	[PasswordHash] [varchar](100) NULL,
	[PasswordSalt] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[RoleId] [int] NULL,
	[IsActivated] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_EventUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventVenue]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventVenue](
	[VenueId] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [varchar](50) NULL,
	[VenueAddress] [varchar](200) NULL,
 CONSTRAINT [PK_EventVenue] PRIMARY KEY CLUSTERED 
(
	[VenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/27/2020 10:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[RoleDesc] [varchar](100) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EventBooking] ON 

INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (1, 6, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (2, 4, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (3, 2, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (4, 2, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (5, 3, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (6, 7, N'mfon2k2@yahoo.com', N'08039477512')
INSERT [dbo].[EventBooking] ([BookingId], [EventId], [EmailAddress], [PhoneNumber]) VALUES (7, 4, N'mfon2k2@gmail.com', N'08039477512')
SET IDENTITY_INSERT [dbo].[EventBooking] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventName], [EventDesc], [EventVenueId], [EventType], [EventDate], [EventTime], [EventFee]) VALUES (2, N'Thanks Giving', N'Test', 2, N'Open Webinar', CAST(N'2020-12-27' AS Date), N'21:34', CAST(8000.00 AS Decimal(18, 2)))
INSERT [dbo].[Events] ([EventId], [EventName], [EventDesc], [EventVenueId], [EventType], [EventDate], [EventTime], [EventFee]) VALUES (3, N'Bonding', N'Test', 1, N'Test Name', CAST(N'2020-12-28' AS Date), N'21:40', CAST(45009.00 AS Decimal(18, 2)))
INSERT [dbo].[Events] ([EventId], [EventName], [EventDesc], [EventVenueId], [EventType], [EventDate], [EventTime], [EventFee]) VALUES (4, N'Festival', N'Testing', 2, N'Premium-only Webinar', CAST(N'2020-12-15' AS Date), N'21:40', CAST(6578869.00 AS Decimal(18, 2)))
INSERT [dbo].[Events] ([EventId], [EventName], [EventDesc], [EventVenueId], [EventType], [EventDate], [EventTime], [EventFee]) VALUES (6, N'House Warming', N'Test 6', 1, N'Leap', CAST(N'2020-12-23' AS Date), N'23:45', CAST(43569.00 AS Decimal(18, 2)))
INSERT [dbo].[Events] ([EventId], [EventName], [EventDesc], [EventVenueId], [EventType], [EventDate], [EventTime], [EventFee]) VALUES (7, N'Graduation', N'Test', 1, N'MeetUp', CAST(N'2020-12-25' AS Date), N'21:34', CAST(43500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[EventType] ON 

INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (1, N'MeetUp')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (2, N'Leap')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (3, N'Recruiting Mission')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (4, N'Hackathon')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (5, N'Premium-only Webinar')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (6, N'Open Webinar')
INSERT [dbo].[EventType] ([EventTypeId], [EventTypeName]) VALUES (8, N'Test Name')
SET IDENTITY_INSERT [dbo].[EventType] OFF
SET IDENTITY_INSERT [dbo].[EventUsers] ON 

INSERT [dbo].[EventUsers] ([UserId], [UserFirstName], [UserLastName], [UserAddress], [EmailAddress], [PasswordHash], [PasswordSalt], [PhoneNumber], [RoleId], [IsActivated], [CreatedOn]) VALUES (1, N'Mfon', N'Peter', N'Iponri Lagos', N'admin@eventmanagement.com', N'AATyX+68EN7qXSb/SRIC3Mek5+gXf91Q3fDEVzPXgu6wy7+4aTj46XmZjXdep/tyDg==', N'19f710b2-8ff6-477f-b706-712c4cb3e35d', N'08039477512', 1, 1, CAST(N'2020-12-26T13:19:15.330' AS DateTime))
INSERT [dbo].[EventUsers] ([UserId], [UserFirstName], [UserLastName], [UserAddress], [EmailAddress], [PasswordHash], [PasswordSalt], [PhoneNumber], [RoleId], [IsActivated], [CreatedOn]) VALUES (3, N'Mfon', N'Peter', N'Iponri Lagos', N'mfon2@gmail.com', N'AH10nP0XwahTHhXumN/bJlR/pEkR4Mh1RsVCAmLpUqcpO627wLgdkTCJqADTiEJtmA==', N'59fec358-c749-485a-b33b-37d97dc06762', N'08039477512', 1, 1, CAST(N'2020-12-26T16:56:53.227' AS DateTime))
SET IDENTITY_INSERT [dbo].[EventUsers] OFF
SET IDENTITY_INSERT [dbo].[EventVenue] ON 

INSERT [dbo].[EventVenue] ([VenueId], [VenueName], [VenueAddress]) VALUES (1, N'Venue A', N'Address A')
INSERT [dbo].[EventVenue] ([VenueId], [VenueName], [VenueAddress]) VALUES (2, N'Venue B', N'Address B')
INSERT [dbo].[EventVenue] ([VenueId], [VenueName], [VenueAddress]) VALUES (3, N'Venue C', N'Address C')
SET IDENTITY_INSERT [dbo].[EventVenue] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDesc]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDesc]) VALUES (2, N'User', NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[EventBooking]  WITH CHECK ADD  CONSTRAINT [FK_EventBooking_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[EventBooking] CHECK CONSTRAINT [FK_EventBooking_Events]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventVenue] FOREIGN KEY([EventVenueId])
REFERENCES [dbo].[EventVenue] ([VenueId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventVenue]
GO
ALTER TABLE [dbo].[EventUsers]  WITH CHECK ADD  CONSTRAINT [FK_EventUsers_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[EventUsers] CHECK CONSTRAINT [FK_EventUsers_Roles]
GO
