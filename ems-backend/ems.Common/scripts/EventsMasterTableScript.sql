SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--commom table for all master data
CREATE TABLE [dbo].[MasterDataMapping](
	[MasterDataMappingId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
	[GroupValue] [nvarchar](100) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedTime] [datetime] NOT NULL,	
	[StatusFlag] [int] NOT NULL,
	[DisplayName] [nvarchar](256) NULL,
 CONSTRAINT [PK_MasterDataMapping] PRIMARY KEY NONCLUSTERED 
(
	[MasterDataMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[MasterDataMapping] ADD  CONSTRAINT [DF_MasterDataMapping_StatusFlag]  DEFAULT ((1)) FOR [StatusFlag]

GO
-------------------------------------------EVENTS---------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1024) NULL,
	[SubTitle] [nvarchar](1024) NULL,
	[SupplierId] int NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[CityId] [int] NOT NULL,	
	[InventoryId] [int] NOT NULL, -- DTCM, Rayna inventory
	[TypeId] int NOT NULL, -- Location Based,  Online  , sporting
	[CategoryId] int NOT NULL,  -- Desi, Nightlife, Popular, Concerts
	[CurrencyId] int Not NULL,	
	[FromDateTime] [datetime]  NOT NULL,
	[ToDateTime] [datetime]  NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC

) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Event] ADD CONSTRAINT FK_EventSupplierId FOREIGN KEY (SupplierId) REFERENCES [Supplier](SupplierId);
GO
ALTER TABLE [Event] ADD CONSTRAINT FK_EventInventoryId FOREIGN KEY (InventoryId) REFERENCES [MasterDataMapping](MasterDataMappingId);
GO
ALTER TABLE [Event] ADD CONSTRAINT FK_EventTypeId FOREIGN KEY (TypeId) REFERENCES [MasterDataMapping](MasterDataMappingId);
GO
ALTER TABLE [Event] ADD CONSTRAINT FK_EventCategoryId FOREIGN KEY (CategoryId) REFERENCES [MasterDataMapping](MasterDataMappingId);
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventDetail](
	[EventDetailId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[EventAccessId] [int] NOT NULL, --public, specific supplier , specific email domain, specific users      
	[VenueId] [int] NOT NULL,
	[DefaultImageUrl] [nvarchar](516) NULL,
	[Latitude] decimal(9,6) NULL,
	[Longitude] decimal(9,6) NULL,
	[TimeZoneId] int NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventDetail] PRIMARY KEY CLUSTERED 
(
	[EventDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE EventDetail ADD CONSTRAINT FK_EventDetailEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);
GO
ALTER TABLE EventDetail ADD CONSTRAINT FK_EventDetailEventAccessId FOREIGN KEY (EventAccessId) REFERENCES [MasterDataMapping](MasterDataMappingId);
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

==CREATE TABLE [dbo].[CancellationPolicy](
	[CancellationPolicyId] [int] IDENTITY(1,1) NOT NULL,
	[CancellationName] [nvarchar](1024) NULL,
	[Description] [nvarchar](4000) NULL,
	[IsRefundable] [bit] NULL,
	[RefundPolicy] [nvarchar](4000) NULL,
	[FromHour] [int] NULL,  
	[ToHour] [int] NULL,
	[CancellationValue] [decimal](18, 2) NOT NULL, 
	[CancellationValueTypeId]  [int] NOT NULL, --Percentage,Amount
	[DisplaySortOrder] [int] NULL,
	[Status] [int] NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_CancellationPolicy] PRIMARY KEY CLUSTERED 
(
	[CancellationPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO

ALTER TABLE CancellationPolicy ADD CONSTRAINT FK_CancellationPolicyCancellationValueTypeId FOREIGN KEY (CancellationValueTypeId) REFERENCES [MasterDataMapping](MasterDataMappingId);
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventOptionMaster](
	[EventOptionMasterId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[OptionName] [nvarchar](1024) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Track] [nvarchar](256) NULL,
	[Duration] [int] NULL,	
	[Status] [int] NOT NULL,
	[FromDateTime] [datetime]  NOT NULL,
	[ToDateTime] [datetime]  NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CutOff] [int] NULL,
	[FreeSell] [bit] NULL,
	[MinPax] [nvarchar](100) NULL,
	[MaxPax] [nvarchar](100) NULL,	
	[DisableChild] [bit] NULL,
	[DisableInfant] [bit] NULL,
	[InstantConfirmation] [bit] NULL,
	[Requiredhrs] [bit] NULL,
	[IsOnlineCheckIn] [bit] NULL,
	[IsWaiverFrom] [bit] NULL,
	[Minquantity] [int] NULL,
	[MultiPax] [int] NULL,
	[Inclusion] [nvarchar](max) NULL,
	[Exclusion] [nvarchar](max) NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventOptionMaster] PRIMARY KEY CLUSTERED 
(
	[EventOptionMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE EventOptionMaster ADD CONSTRAINT DF_EventOptionMaster_Status DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE EventOptionMaster ADD CONSTRAINT FK_EventOptionMasterEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);
GO

==CREATE TABLE [dbo].[EventOptionTimeSlot](
	[EventOptionTimeSlotId] [int] IDENTITY(1,1) NOT NULL,
	[EventOptionMasterId] [int] NOT NULL,
	[Name] [nvarchar](1024) NULL,
	[Description] [nvarchar](1024) NULL,
	[FromDateTime] [datetime]  NOT NULL,
	[ToDateTime] [datetime]  NOT NULL,
	[Duration] [int] NULL,	
	[Status] [int] NULL,
	[SortOrder] [int] NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventOptionTimeSlot] PRIMARY KEY CLUSTERED 
(
	[EventOptionTimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO

ALTER TABLE  EventOptionTimeSlot  ADD  CONSTRAINT DF_EventOptionTimeSlot_Status DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE EventOptionTimeSlot ADD CONSTRAINT FK_EventOptionTimeSlotEventOptionMasterId FOREIGN KEY (EventOptionMasterId) REFERENCES [EventOptionMaster](EventOptionMasterId);
GO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventDescriptionSection](
	[EventDescriptionSectionId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,	    
	[Name] [nvarchar](526) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[SortOrder] [int] NOT NULL,  
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventDescriptionSection] PRIMARY KEY CLUSTERED 
(
	[EventDescriptionSectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE EventDescriptionSection ADD CONSTRAINT FK_EventDescriptionSectionEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);

GO

CREATE TABLE [dbo].[EventMedia](
	[EventMediaId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[Name] [nvarchar](526) NOT NULL,
	[MediaTypeId] [int] NOT NULL, --banner,html,text,video,image
	[Url] [nvarchar](516) NULL,
	[Description] [nvarchar](2000) NULL,
	[DisplaySortOrder] [int] NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventMedia] PRIMARY KEY CLUSTERED 
(
	[EventMediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE EventMedia ADD CONSTRAINT FK_EventMediaEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);

GO

CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](512) NULL,
	[TagTypeId] [int] NOT NULL, --event tags, venue tags, banner tags
	[TagKeyword] [nvarchar](512) NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTagMapping](
	[EventTagMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventTagsMapping] PRIMARY KEY CLUSTERED 
(
	[EventTagMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE EventTagMapping ADD CONSTRAINT FK_EventTagMappingEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);

GO
ALTER TABLE EventTagMapping ADD CONSTRAINT FK_EventTagMappingTagId FOREIGN KEY (TagId) REFERENCES [Tags](TagId);
GO

CREATE TABLE [dbo].[EventOptionTagMapping](
	[EventOptionTagMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EventOptionMasterId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventOptionTagMapping] PRIMARY KEY CLUSTERED 
(
	[EventOptionTagMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE EventOptionTagMapping ADD CONSTRAINT FK_EventOptionTagMappingEventOptionMasterId FOREIGN KEY (EventOptionMasterId) REFERENCES [EventOptionMaster](EventOptionMasterId);

GO
ALTER TABLE EventOptionTagMapping ADD CONSTRAINT FK_EventOptionTagMappingTagId FOREIGN KEY (TagId) REFERENCES [Tags](TagId);
GO

GO
CREATE TABLE [dbo].[EventAgenda](
	[EventAgendaId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[Title] [nvarchar](512) NULL,
	[Track] [nvarchar](512) NULL,
	[AgendaTypeId] int Not NULL,
	[StartDate] [DateTime] NULL,
	[EndDate] [DateTime] NULL,
	[Summary] [nvarchar](1024) NULL,
	[Description] [nvarchar](1024) NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventAgenda] PRIMARY KEY CLUSTERED 
(
	[EventAgendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE EventAgenda ADD CONSTRAINT FK_EventAgendaEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);


GO
CREATE TABLE [dbo].[Venue](
	[VenueId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[Capacity] int Not NULL,
	[Address] [nvarchar](512) NULL,
	[Latitude] decimal(9,6) NULL,
	[Longitude] decimal(9,6) NULL,
	[AgeLimit] int Not NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[VenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VenueEventTimeSlotMapping](
	[VenueEventTimeSlotMappingId] [int]  IDENTITY(1,1) NOT NULL,
	[EventOptionTimeSlotId] [int] NOT NULL,
	[VenueId] [int] NOT NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_VenueEventTimeSlotMapping] PRIMARY KEY CLUSTERED 
(
	[VenueEventTimeSlotMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE VenueEventTimeSlotMapping ADD CONSTRAINT FK_VenueEventTimeSlotMappingEventOptionTimeSlotId FOREIGN KEY (EventOptionTimeSlotId) REFERENCES [EventOptionTimeSlot](EventOptionTimeSlotId);

GO
ALTER TABLE VenueEventTimeSlotMapping ADD CONSTRAINT FK_VenueEventTimeSlotMappingVenueId FOREIGN KEY (VenueId) REFERENCES [Venue](VenueId);
GO

CREATE TABLE [dbo].[TicketCategory](
	[TicketCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[EventOptionTimeSlotId] [int] NOT NULL,
	[CurrencyId] int Not NULL,
	[CancellationPolicyId] [int] NOT NULL,
	[IsRefundable] [bit] NULL,
	[PaymentMethodId] int Not NULL, --credit limit, cash , credit card 
	[Name] [nvarchar](512) NULL,
	[Quantity] int Not NULL,	 
	[SeatmapDataColor]  [nvarchar](256) NULL, -- color code
	[StartDate] [DateTime] NULL,
	[EndDate] [DateTime] NULL,
	[MinQuantity] int  NULL,
	[MaxQuantity] int  NULL,
	[VisibilityTypeId] int  NULL,      
	--[TicketIssueTypeId] int  NOT NULL,--[IsByEvent] ,--[IsByOption]  ,--[IsByTimeSlot]  
	--[TicketIssueTypeMasterId] int  NOT NULL, --EventId/OptionId/TimeSlotId
	[IsFeatured] int  NULL,
	[IsPercentageOff] [decimal](18, 3) NULL,
	[IsAmountOff] [decimal](18, 3) NULL,
	[QuantitySold] [decimal](18, 2) NULL,
	[IsPdfTicket]  int NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_TicketCategory] PRIMARY KEY CLUSTERED 
(
	[TicketCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE TicketCategory ADD CONSTRAINT FK_TicketCategoryEventOptionTimeSlotId FOREIGN KEY (EventOptionTimeSlotId) REFERENCES [EventOptionTimeSlot](EventOptionTimeSlotId);

GO
ALTER TABLE TicketCategory ADD CONSTRAINT FK_TicketCategoryCancellationPolicyId FOREIGN KEY (CancellationPolicyId) REFERENCES [CancellationPolicy](CancellationPolicyId);
GO

ALTER TABLE TicketCategory ADD CONSTRAINT FK_TicketCategoryPaymentMethodId FOREIGN KEY (PaymentMethodId) REFERENCES [MasterDataMapping](MasterDataMappingId);

GO

CREATE TABLE [dbo].[TicketCategoryPaxTypeMapping](
	[TicketCategoryPaxTypeMappingId] [int]  IDENTITY(1,1) NOT NULL,
	[TicketCategoryId] [int]  NOT NULL, 
	[PaxTypeId] [int] NOT NULL, --Adult,Child,Military, Education
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_TicketCategoryPaxTypeMapping] PRIMARY KEY CLUSTERED 
(
	[TicketCategoryPaxTypeMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE TicketCategoryPaxTypeMapping ADD CONSTRAINT FK_TicketCategoryPaxTypeMappingTicketCategoryId FOREIGN KEY (TicketCategoryId) REFERENCES [TicketCategory](TicketCategoryId);
GO
ALTER TABLE TicketCategoryPaxTypeMapping ADD CONSTRAINT FK_EventDetailEventAccessIdPaxTypeId FOREIGN KEY (PaxTypeId) REFERENCES [MasterDataMapping](MasterDataMappingId);

GO
GO

CREATE TABLE [dbo].[Section](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[TicketCategoryId] int Not NULL,
	[Floor] [nvarchar](256) NULL,
	[Capacity] int Not NULL,
	[Address] [nvarchar](512) NULL,
	[SeatingTypeId] int Not NULL,
	[SeatMapData] [nvarchar](1024) NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE Section ADD CONSTRAINT FK_SectionTicketCategoryId FOREIGN KEY (TicketCategoryId) REFERENCES [TicketCategory](TicketCategoryId);

GO
CREATE TABLE [dbo].[Seat](
	[SeatId] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NOT NULL,
	[Title] [nvarchar](512) NULL,
	[SeatMapData] [nvarchar](1024) NULL,
	[AvailabilityId] int Not NULL, -- Blocked, Available etc.
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[SeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE Seat ADD CONSTRAINT FK_SeatSectionId FOREIGN KEY (SectionId) REFERENCES [Section](SectionId);

GO
CREATE TABLE [dbo].[EventCostMaster](
	[EventCostMasterId] [int] IDENTITY(1,1) NOT NULL,
	[TicketCategoryPaxTypeMappingId] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[MinimumSell] [decimal](18, 2) NULL,
	[RackRate] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventCostMasterId] PRIMARY KEY NONCLUSTERED 
(
	[EventCostMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO
ALTER TABLE EventCostMaster ADD CONSTRAINT FK_EventCostMasterPaxMappingId FOREIGN KEY (TicketCategoryPaxTypeMappingId) REFERENCES [TicketCategoryPaxTypeMapping](TicketCategoryPaxTypeMappingId);
GO

ALTER TABLE [dbo].[EventCostMaster] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[EventCostMaster] ADD  DEFAULT ((0)) FOR [MinimumSell]
GO
ALTER TABLE [dbo].[EventCostMaster] ADD  DEFAULT ((0)) FOR [RackRate]
GO

CREATE TABLE [dbo].[CostMasterAuditLog]
(
	[CostMasterAuditLogId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[TicketCategoryPaxTypeMappingId] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[MinimumSell] [decimal](18, 2) NULL,
	[RackRate] [decimal](18, 2) NULL,
	[IPAddress] [varchar](500) NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_CostMasterAuditLog] PRIMARY KEY NONCLUSTERED 
(
	[CostMasterAuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO

ALTER TABLE [dbo].[CostMasterAuditLog] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[CostMasterAuditLog] ADD  DEFAULT ((0)) FOR [MinimumSell]
GO
ALTER TABLE [dbo].[CostMasterAuditLog] ADD  DEFAULT ((0)) FOR [RackRate]
GO

CREATE TABLE [dbo].[EventTarrifWiseSellMaster](
	[EventTarrifWiseSellMasterId] [int] IDENTITY(1,1) NOT NULL,
	[EventCostMasterId] [int] NULL,
	[TarrifId] [int] NULL,
	[MarkupTypeId] [int] NULL,
	[MarkupAmount] [decimal](18, 7) NULL,
	[SellAmount] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventTarrifWiseSellMasterId] PRIMARY KEY NONCLUSTERED 
(
	[EventTarrifWiseSellMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO
ALTER TABLE EventTarrifWiseSellMaster ADD CONSTRAINT FK_EventTarrifWiseSellMasterEventCostMasterId FOREIGN KEY (EventCostMasterId) REFERENCES [EventCostMaster](EventCostMasterId);
GO

ALTER TABLE [dbo].[EventTarrifWiseSellMaster] ADD  DEFAULT ((0)) FOR [SellAmount]
GO

CREATE TABLE [dbo].[EventAgentWiseSellMaster](
	[EventAgentWiseSellMasterId] [int] IDENTITY(1,1) NOT NULL,
	[EventCostMasterId] [int] NULL,
	[AgentId] [int] NOT NULL,
	[MarkupTypeId] [int] NOT NULL,
	[MarkupAmount] [decimal](18, 7) NOT NULL,
	[SellAmount] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
	CONSTRAINT [PK_EventAgentWiseSellMasterId] PRIMARY KEY NONCLUSTERED 
	(
		[EventAgentWiseSellMasterId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]  
GO
ALTER TABLE EventAgentWiseSellMaster ADD CONSTRAINT FK_EventAgentWiseSellMasterEventCostMasterId FOREIGN KEY (EventCostMasterId) REFERENCES [EventCostMaster](EventCostMasterId);
GO
ALTER TABLE [dbo].[EventAgentWiseSellMaster] ADD DEFAULT ((0)) FOR [SellAmount]
GO

CREATE TABLE [dbo].[EventSellMasterAuditLog](
	[EventSellMasterAuditLogId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[EventCostMasterId] [int] NULL,
	[MarkupTypeId] [int] NULL,
	[MarkupAmount] [decimal](18, 7) NULL,
	[SellAmount] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_EventAgentWiseSellMasterAuditLog] PRIMARY KEY NONCLUSTERED 
(
	[EventSellMasterAuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]  
GO

ALTER TABLE [dbo].[EventSellMasterAuditLog] ADD  DEFAULT ((0)) FOR [SellAmount]

GO

CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[TicketCategoryId] [int] NOT NULL,
	[TicketAdditionalTypeId] [int] NOT NULL, --GA,Special Ticket (Restricted to users like VIPs),Reduced Price,Discounted Entry - for those who buy before scheduled date,Entry with benefits for large organizations
	[RegistrationTimeLimit] [nvarchar](100) NULL,
	[TicketIssueTypeId] int NULL, --At Payment,On Registration,24 hours after payment,24 hours before event,7 days before event
	[ShowTicketAvailability] int  NULL,
	[AllowDuplicateAttendees] int  NULL,
	[Status] int Not NULL,
	[CreatedDate] datetime NULL,
	[CreatedBy] int NULL,
	[UpdatedDate] datetime NULL,
	[UpdatedBy] int NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED  
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE Ticket ADD CONSTRAINT FK_TicketEventId FOREIGN KEY (EventId) REFERENCES [Event](EventId);

GO
-------------------------------
