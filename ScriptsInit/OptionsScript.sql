USE [ai-bot]
GO
/****** Object:  Table [dbo].[Options]    Script Date: 08/05/2020 05:09:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[OptionId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](150) NULL,
	[Body] [varchar](500) NULL,
	[Type] [varchar](50) NULL,
	[Result] [varchar](500) NULL,
	[ParentOptionId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[OptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'2cfc46ed-d607-4414-9f83-06f027a3935a', N'Cordoba4', N'Cordoba4', N'IMAGE', N'http://localhost:3978/img/cordoba04.jpg', N'12147323-a7f6-4b2e-b60f-988979855dfe')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'1c8fe4da-0824-45a1-9b25-089d609d216a', N'Montaña', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus tortor, fermentum et hendrerit eu, accumsan eu dolor. Proin consectetur vestibulum orci at condimentum..', N'CARD', N'http://www.google.com/', N'5f459636-53ba-48c5-8e52-d8accefc8133')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'56163f03-a550-4215-b2b1-15b725c177d8', N'Reservar Virtual', N'Mendoza', N'FORM', N'MDZ', N'f8cfc5a0-1843-419a-ad01-20b4274f10d6')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'9278ec7c-a94d-4f9e-9043-1d62d592f52a', N'MendozaImagen2', N'MendozaImagen2', N'IMAGE', N'http://localhost:3978/img/mendoza02.jpg', N'72cdfd5c-d9dd-4aec-a8a3-baa4c1f7cb06')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'f8cfc5a0-1843-419a-ad01-20b4274f10d6', N'Video', N'Mendoza Video', N'VIDEOCARD', NULL, N'f8b26d13-9c5d-459a-9a77-de3fd51a67a8')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'527b111d-f37d-4b6b-9502-2c03b0f66031', N'Playa', N'etiam sit amet dui augue. Sed sodales pellentesque nisi, quis feugiat sem laoreet eget. ', N'CARD', N'http://www.google.com/', N'5f459636-53ba-48c5-8e52-d8accefc8133')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'941866b5-a4e3-4a05-9a3d-37d6cec6b611', N'Cordoba5', N'Cordoba5', N'IMAGE', N'http://localhost:3978/img/cordoba05.jpg', N'12147323-a7f6-4b2e-b60f-988979855dfe')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'e8cc3b67-3a09-4600-a000-3e6d57aeef8d', N'MendozaImagen3', N'MendozaImagen3', N'IMAGE', N'http://localhost:3978/img/mendoza04.jpg', N'72cdfd5c-d9dd-4aec-a8a3-baa4c1f7cb06')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'bef555da-7b04-4bc3-b5e4-3ea708e36abf', N'MendozaImagen1', N'Mendoza Imagen 1', N'IMAGE', N'http://localhost:3978/img/mendoza01.jpg', N'72cdfd5c-d9dd-4aec-a8a3-baa4c1f7cb06')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'4cfb0db4-42b2-409c-9348-423027915837', N'Cordoba', N'La Provincia de Córdoba es un destino ideal para experimentar las más diversas sensaciones que a un viajero le pueden provocar placer. Con una impronta cultural e histórica, con un perfil tradicional y moderno y con la gran cantidad de destinos que presenta en su geografía, es el lugar donde todos los turistas pueden disfrutar las más variadas actividades de recreación durante todo el año.', N'CARD', NULL, N'1c8fe4da-0824-45a1-9b25-089d609d216a')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'a2148e4e-212f-4597-bdbe-520455076950', N'MendozaImagen4', N'MendozaImagen4', N'IMAGE', N'http://localhost:3978/img/mendoza05.jpg', N'72cdfd5c-d9dd-4aec-a8a3-baa4c1f7cb06')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'eccb089b-2d7b-45b1-b56d-6f8a6719d486', N'Mendoza Video', N'Video', N'VIDEO', N'http://localhost:3978/img/mendoza_video01.mp4', N'f8cfc5a0-1843-419a-ad01-20b4274f10d6')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'd92c1ecb-1752-4ae3-97de-7b4aef61ee6b', N'Gracias', N'Gracias por la contratación de su viaje a la brevedad le llegara cun correo electronico con la confirmación.', N'CARD', NULL, NULL)
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'b450637d-ffc6-46ec-ad17-7fd2b86f4413', N'Cordoba3', N'Cordoba3', N'IMAGE', N'http://localhost:3978/img/cordoba03.jpg', N'12147323-a7f6-4b2e-b60f-988979855dfe')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'f8c4ab4f-6515-4252-bc9a-8f6b9acbe9d6', N'Bariloche', N'San Carlos de Bariloche (comúnmente llamada Bariloche) es una ciudad en la región de la Patagonia argentina. Limita con Nahuel Huapi, un gran lago glacial rodeado de montañas de los Andes. Bariloche es conocida por su arquitectura al estilo alpino de Suiza y su chocolate, que se vende en tiendas de la calle Mitre, la avenida principal. También es una base popular para el excursionismo y el esquí en las montañas cercanas, y para explorar los alrededores del Distrito de los Lagos.', N'CARD', N'', N'1c8fe4da-0824-45a1-9b25-089d609d216a')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'12147323-a7f6-4b2e-b60f-988979855dfe', N'Galeria Imagenes', N'Galeria Imagenes Cordoba', N'GALLERYIMAGES', NULL, N'4cfb0db4-42b2-409c-9348-423027915837')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'1d211af3-2482-48fd-96d8-b046955022fc', N'Cordoba1', N'Cordoba1', N'IMAGE', N'http://localhost:3978/img/cordoba02.jpg', N'12147323-a7f6-4b2e-b60f-988979855dfe')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'0879f515-75c6-4c5f-9780-b74b256f61c0', N'Cordoba2', N'Cordoba2', N'IMAGE', N'http://localhost:3978/img/cordoba01.jpg', N'12147323-a7f6-4b2e-b60f-988979855dfe')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'72cdfd5c-d9dd-4aec-a8a3-baa4c1f7cb06', N'Galeria Imagenes', N'Galeria Imagenes Mendoza', N'GALLERYIMAGES', NULL, N'f8b26d13-9c5d-459a-9a77-de3fd51a67a8')
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'5f459636-53ba-48c5-8e52-d8accefc8133', N'Bienvenido Visitante', N'Donde gustaria viajar estas vacaciones para un excelente descanso.', N'WELCOME', NULL, NULL)
GO
INSERT [dbo].[Options] ([OptionId], [Title], [Body], [Type], [Result], [ParentOptionId]) VALUES (N'f8b26d13-9c5d-459a-9a77-de3fd51a67a8', N'Mendoza', N'Mendoza es una ciudad de la región de Cuyo en Argentina y es el corazón de la zona vitivinícola argentina, famosa por sus Malbecs y otros vinos tintos. Sus distintas bodegas ofrecen degustaciones y visitas guiadas. La ciudad tiene calles amplias y frondosas rodeadas de edificios modernos y art déco, y con plazas más pequeñas que rodean la Plaza Independencia, sitio del Museo Municipal de Arte Moderno subterráneo, que exhibe arte moderno y contemporáneo.', N'CARD', NULL, N'1c8fe4da-0824-45a1-9b25-089d609d216a')
GO
ALTER TABLE [dbo].[Options] ADD  CONSTRAINT [DF_Options_OptionId]  DEFAULT (newid()) FOR [OptionId]
GO
