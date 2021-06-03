print '--****** table creation and initial data ******--'
print '***** start execution ' + Convert(varchar(50), getdate()) + ' *****'

Use Hogwarts
Declare @tableName varchar(50)

Set @tableName = 'Inscriptions'
IF OBJECT_ID(@tableName) is not null Begin
	print '--> Dropping table ' + @tableName
	Drop table Inscriptions
End

print '--> Creating table ' + @tableName
Create table Inscriptions
(
	ID int identity primary key,
	Name Varchar(20) not null, 
	LastName VARCHAR(20) not null,
	DocumentNum Varchar(10) not null,
	Age tinyint not null,
	House varchar(100) not null,
	State varchar(100) not null,
	CreatedDate datetime default getdate() null,
	UpdatedDate datetime default getdate() null
)

print '**** Inserting initial data ****'
print '--> Inserting Inscriptions'

Insert Into Inscriptions
Values	('Diego Fernando', 'Alape Bermudez', '1030702090', 21, 'Slytherin','Recibida',default, null)

print '***** End of execution ' + Convert(varchar(50), getdate()) + ' *****'


