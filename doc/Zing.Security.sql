/****** Object:  Table [dbo].[Users]    Script Date: 07/17/2014 11:19:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/17/2014 11:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[NormalizedUserName] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[PasswordFormat] [nvarchar](255) NULL,
	[HashAlgorithm] [nvarchar](255) NULL,
	[PasswordSalt] [nvarchar](255) NULL,
	[RegistrationStatus] [nvarchar](255) NULL,
	[EmailStatus] [nvarchar](255) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (1, N'admin', N'admin', N'5c8SXodp8Ih9bHGCmbuJOCsFfIg=', N'dsd@d.com', N'Hashed', N'SHA1', N'jNX4dwkFhrTazR/i+C9qGw==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (2, NULL, N'dss2', N'Br/q/rPWaH0SdUt/gIAwaY+U8ig=', N'dsd@d.com', N'Hashed', N'SHA1', N'4kFbvrWj+NljQaU3yV/IaA==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (3, NULL, N'dss3', N'M87GYeomhTjsLNhsMJ5SuWsy+70=', N'dsd@d.com', N'Hashed', N'SHA1', N'0jNmHRG2y/JgwsfCo3BFiA==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (4, NULL, N'dss4', N'bU3MXAnI+5dgd0n7GGxC0HOWdUI=', N'dsd@d.com', N'Hashed', N'SHA1', N'1jOz0OFy0yY4X1hLPPK10g==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (5, NULL, N'dss5', N'BoA6cf9EbiRGlwFbgKgNdhknD0s=', N'dsd@d.com', N'Hashed', N'SHA1', N'3cb9yRKoTwUlrVvxq2jnBw==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (6, NULL, N'dss6', N'z1jxGvCDg/8jckrAZP2d6dKj4lY=', N'dsd@d.com', N'Hashed', N'SHA1', N'3JcSgRDK04PQPAQAstedlw==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (7, NULL, N'dss7', N'MJETu+aN8t67AjPkuYEL+xRPHy8=', N'dsd@d.com', N'Hashed', N'SHA1', N'aYRedkFw2iTH+170dqMz1g==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (8, NULL, N'dss8', N'bYbIb5JuJ2Ur4OIgDE4f653v8nQ=', N'dsd@d.com', N'Hashed', N'SHA1', N'y3izBePFHNT2V9AZOw5m4A==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (9, NULL, N'dss9', N'GRIpqKbzgqbzbFpG5Tzk5in2BQ0=', N'dsd@d.com', N'Hashed', N'SHA1', N'tY0dzdf/OXFWO9Qx0YHEwg==', N'Pending', N'Pending')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Password], [Email], [PasswordFormat], [HashAlgorithm], [PasswordSalt], [RegistrationStatus], [EmailStatus]) VALUES (10, NULL, N'dss10', N'N/go7u+BPbr8IZjBhm1d5ZQ7Z9Y=', N'dsd@d.com', N'Hashed', N'SHA1', N'SI8o6EGQOGkzMgowyxzbXA==', N'Pending', N'Pending')
SET IDENTITY_INSERT [dbo].[Users] OFF
