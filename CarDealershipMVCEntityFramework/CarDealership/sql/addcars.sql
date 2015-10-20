CREATE TABLE Car(
	Id INT NOT NULL IDENTITY(1, 1),
	Make NVARCHAR(MAX) NOT NULL,
	Model NVARCHAR(MAX) NOT NULL,
	[Year] NVARCHAR(4) NOT NULL,
	ImageUrl NVARCHAR(MAX) NULL,
	Title NVARCHAR(MAX) NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	Price DECIMAL(18,0) NOT NULL
)























































































INSERT INTO Car(Make, Model, [Year], ImageUrl, Title, [Description], Price) 
VALUES ('Honda', 'Accord', '1996', 
		'https://igcdn-photos-e-a.akamaihd.net/hphotos-ak-xpt1/t51.2885-15/10561187_765036253561100_1999913933_n.jpg',
		'BITCHIN'' ''96 HONDA ACCORD!!!!', 
		'This could be the greatest car of all time. No in fact it is. 110k miles, runs like a dream. Comes with steering wheel, tape deck, and seats. Pearly white-ish. Personally owned by the man himself, Alec Wojo. I can''t even believe we''re selling it at this low, low price. Why are we doing it? BECAUSE WE''RE CRAZY PEOPLE WITH CRAZY DREAMS!! ACT NOW BEFORE MY BOSS COMES TO HIS SENSES AND TAKES IT OFF THE MARKET!!!!',
		10000000.00)

INSERT INTO [dbo].[Car]
           ([Make]
           ,[Model]
           ,[Year]
           ,[ImageUrl]
           ,[Title]
           ,[Description]
           ,[Price])
     VALUES
           ('Toyota',
           'Camry',
           '1999',
           'http://www.curbsideclassic.com/wp-content/uploads/2012/08/DSC00560-1024x768.jpg',
           'WICKED fast 1999 Toyta Camry',
           'Do you enjoy the finer things in life? Maybe a glass of Dom Perginon, well aged scotch, and any furniture that are French words? Hell yes you do. And now you''ve found the car to compliment your luxury tastes. Imagine speeding down the interstate at a whiplash inducing fourty miles an hour as you sip fine artisnal water from the foothills of Tuscany. And you can stay environmentally consious too as the car sips it''s own artisnal 87 octane fire juice at a mere rate of 15 miles per gallon. Well, what are you waiting for, champ?',
           5995.00)

INSERT INTO [dbo].[Car]
           ([Make]
           ,[Model]
           ,[Year]
           ,[ImageUrl]
           ,[Title]
           ,[Description]
           ,[Price])
     VALUES
           ('Subaru',
           'Legacy',
           '1992',
           'http://carphotos.cardomain.com/ride_images/1/868/2881/2168940001_large.jpg',
           'This Subaru is SICK!!!',
           'CALL THE POLICE, BECAUSE THESE PRICES ARE CRIMINALLY LOW!!! This 1992 Subaru Legacy is indeed a legacy ''round these parts. Legend has it that a former SWCG employee named Jerry used it as a getaway car when robbing a bank. Unfortunately for Jerry, the bank had already gone out of business and it was an empty building at that point. Jerry doesn''t work here anymore. Point is, Jerry''s gone, he''s not coming back and after a length court battle, we now can offer you this fine speciman with features such as 4(ish) wheels, floormats, and an vague hint of cheap cologne. ACT NOW! JERRY WOULD BE PROUD!',
           2699.00)
GO


