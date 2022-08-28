use TimeManagerDB
go

CREATE VIEW vwActivityCategory AS
SELECT A.[Id], A.[Name], A.[Description], C.[Name] AS CategoryName
FROM [dbo].[Activities] AS A 
INNER JOIN [dbo].[Categories] AS C
ON A.[CategoryId] = C.[Id]
go

ALTER VIEW vwActivityCategory AS
SELECT A.[Id], A.[Name], A.[Description], C.[Id] AS CategoryId, C.[Name] AS CategoryName, A.[DateAdded], A.[DateCompleted], A.[Deadline], A.[UserId]
FROM [dbo].[Activities] AS A 
INNER JOIN [dbo].[Categories] AS C
ON A.[CategoryId] = C.[Id]
GO

CREATE VIEW vwCategories AS 
SELECT C.Id, C.Name, COUNT(A.Id) AS ActivitiesNum
FROM [dbo].[Categories] as C
INNER JOIN [dbo].[Activities] as A
ON C.Id = A.CategoryId
GROUP BY C.Id, C.Name
go

insert into dbo.TokenKey values ('2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b')

INSERT INTO
dbo.Categories(Name)  
VALUES 
('Learning'),
('Working Out'),
('Cooking'),
('People')

INSERT INTO
dbo.Activities (Name, Description, CategoryId, DateAdded, DateCompleted, Deadline, UserId)  
VALUES 
('Math', 'Learn some stuff', 1, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Math', 'Learn some stuff', 2, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Working Out', 'Learn some stuff', 1, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Working Out', 'Learn some stuff', 3, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Walk', 'Learn some stuff', 2, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Walk', 'Learn some stuff', 2, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Cleaning', 'Learn some stuff', 1, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Cooking', 'Learn some stuff', 4, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Math', 'Learn some stuff', 3, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Cooking', 'Learn some stuff', 2, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Chill', 'Learn some stuff', 4, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Family', 'Learn some stuff', 1, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1),
('Cooking', 'Learn some stuff', 4, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), convert(datetime,'18-06-13 10:34:09 PM',5), 1)


select * from dbo.vwActivityCategory
select * from dbo.vwCategories
select * from dbo.TokenKey
select * from dbo.Tokens