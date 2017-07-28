USE [Calemas.Erp]
GO

DELETE FROM ApiClaims
DELETE FROM ApiResources
DELETE FROM ApiScopeClaims
DELETE FROM ApiScopes
DELETE FROM ApiSecrets
DELETE FROM ClientClaims
DELETE FROM ClientCorsOrigins
DELETE FROM ClientGrantTypes
DELETE FROM ClientPostLogoutRedirectUris
DELETE FROM ClientRedirectUris
DELETE FROM IdentityClaims
DELETE FROM IdentityResources
DELETE FROM Clients

SET IDENTITY_INSERT [dbo].[ApiResources] ON 

GO
INSERT [dbo].[ApiResources] ([Id], [Description], [DisplayName], [Enabled], [Name]) VALUES (1, N'Calemas', N'Calemas', 1, N'ssocalemas')
GO
SET IDENTITY_INSERT [dbo].[ApiResources] OFF
GO
SET IDENTITY_INSERT [dbo].[ApiScopes] ON 

GO
INSERT [dbo].[ApiScopes] ([Id], [ApiResourceId], [Description], [DisplayName], [Emphasize], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, 1, N'SPA Client Implicit', NULL, 0, N'calemas', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[ApiScopes] OFF
GO
SET IDENTITY_INSERT [dbo].[ApiScopeClaims] ON 

GO
INSERT [dbo].[ApiScopeClaims] ([Id], [ApiScopeId], [Type]) VALUES (1, 1, N'name')
GO
INSERT [dbo].[ApiScopeClaims] ([Id], [ApiScopeId], [Type]) VALUES (2, 1, N'openid')
GO
INSERT [dbo].[ApiScopeClaims] ([Id], [ApiScopeId], [Type]) VALUES (3, 1, N'email')
GO
INSERT [dbo].[ApiScopeClaims] ([Id], [ApiScopeId], [Type]) VALUES (4, 1, N'role')
GO
SET IDENTITY_INSERT [dbo].[ApiScopeClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

GO
INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [LogoutSessionRequired], [LogoutUri], [PrefixClientClaims], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (1, 2592000, 3600, 0, 1, 0, 0, 1, 1, 1, 300, N'ssocalemas', N'Calemas', N'http://calemas-front.azurewebsites.net', 1, 1, 300, 0, NULL, 1, N'http://calemas-front.azurewebsites.net/#/loggedout/?', 1, N'oidc', 1, 1, 1, 0, 0, 1296000, 0)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientCorsOrigins] ON 

GO
INSERT [dbo].[ClientCorsOrigins] ([Id], [ClientId], [Origin]) VALUES (1, 1, N'http://localhost:8080')
GO
INSERT [dbo].[ClientCorsOrigins] ([Id], [ClientId], [Origin]) VALUES (2, 1, N'http://localhost:8080/')
GO
SET IDENTITY_INSERT [dbo].[ClientCorsOrigins] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] ON 

GO
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (1, 1, N'implicit')
GO
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] ON 

GO
INSERT [dbo].[ClientPostLogoutRedirectUris] ([Id], [ClientId], [PostLogoutRedirectUri]) VALUES (1, 1, N'http://localhost:8080/#/loggedout/?')
GO
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] ON 

GO
INSERT [dbo].[ClientRedirectUris] ([Id], [ClientId], [RedirectUri]) VALUES (1, 1, N'http://localhost:8080/#/authorized/?')
GO
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientScopes] ON 

GO
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (1, 1, N'openid')
GO
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (2, 1, N'profile')
GO
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (3, 1, N'email')
GO
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (4, 1, N'calemas')
GO
SET IDENTITY_INSERT [dbo].[ClientScopes] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientSecrets] ON 

GO
INSERT [dbo].[ClientSecrets] ([Id], [ClientId], [Description], [Expiration], [Type], [Value]) VALUES (1, 1, NULL, NULL, N'SharedSecret', N'o2yscdGkShWToi2YQDRVvS1vc35GXEzz/OrSk4GggzU=')
GO
SET IDENTITY_INSERT [dbo].[ClientSecrets] OFF
GO
SET IDENTITY_INSERT [dbo].[IdentityResources] ON 

GO
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, NULL, N'Your user identifier', 0, 1, N'openid', 1, 1)
GO
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (2, N'Your user profile information (first name, last name, etc.)', N'User profile', 1, 1, N'profile', 0, 1)
GO
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (3, NULL, N'Your email address', 1, 1, N'email', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[IdentityResources] OFF
GO
SET IDENTITY_INSERT [dbo].[IdentityClaims] ON 

GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (1, 1, N'sub')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (2, 2, N'updated_at')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (3, 2, N'locale')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (4, 2, N'zoneinfo')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (5, 2, N'birthdate')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (6, 2, N'gender')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (7, 2, N'website')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (8, 3, N'email')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (9, 2, N'picture')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (10, 2, N'preferred_username')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (11, 2, N'nickname')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (12, 2, N'middle_name')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (13, 2, N'given_name')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (14, 2, N'family_name')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (15, 2, N'name')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (16, 2, N'profile')
GO
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (17, 3, N'email_verified')
GO
SET IDENTITY_INSERT [dbo].[IdentityClaims] OFF
GO
