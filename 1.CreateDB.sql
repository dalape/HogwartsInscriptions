print '--****** database creation --******'
print '***** Start of execution ' + Convert(varchar(50), getdate()) + ' *****'
If not Exists(SELECT name FROM master.sys.databases WHERE name = 'Hogwarts') Begin
	print '**** creating database ****'
	Create database Hogwarts
End
print '***** end of execution ' + Convert(varchar(50), getdate()) + ' *****'