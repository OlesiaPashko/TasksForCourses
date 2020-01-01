use Pashko_DB;

INSERT INTO Employee
(
	FirstName,
	ParrentName,
	LastName,
	BirthDate) 
VALUES ('Olesya', 'Vitaliivna','Pashko', '2000-10-07 00:00:00'),
('Olya', 'Victorivna','Pupko', '2000-01-17 00:00:00'),
('Oleh', 'Hennadiovych','Romanenko', '1998-11-06 00:00:00'),
('Ciril', 'Olexiovych','Karpo', '2003-04-24 00:00:00'),
('Poman', 'Antotnovych','Antonenko', '2001-05-12 00:00:00')

INSERT INTO Project(
	ProjectName,
	CreationDate,
	IsOpened,
	ClosingDate)
VALUES ('Internet Shop', '2016-01-17 00:00:00', 1, Null),
('Robotic hand', '2009-03-11 00:00:00', 0, '2019-04-12 00:00:00' ),
('Text interpretator', '2012-02-19 00:00:00', 0, '2018-02-10 00:00:00' ),
('Text generator', '2013-01-22 00:00:00', 1, Null ),
('AI for the car', '2010-02-13 00:00:00', 1, Null ),
('Awasome Game', '2017-02-13 00:00:00', 0, '2013-01-11 00:00:00' )

INSERT INTO EmployeeOnPositionInProject(
	PositionID,
	EmployeeID,
	ProjectID
)
VALUES (1, 1, 3),
(2, 1, 4),
(3, 2, 1),
(7, 2, 4),
(1, 3, 6),
(4, 4, 5),
(5, 4, 1),
(7, 5, 3),
(1, 5, 6),
(6, 1, 3),
(1, 1, 2),
(6, 3, 2)

INSERT INTO Position(PositionName)
VALUES('Tester'),
('Junior Front-end developer'),
('UX designer'),
('Data analist'),
('Senior Back-end developer'),
('Middle Python developer'),
('Junior Python developer'),
('Senior Python developer'),
('Senior Front-end developer'),
('Middle Front-end developer')

iNSERT INTO Task(
	TaskName,
	TaskStatus,
	StatusChangeDate,
	StatusChangeEmployeeID,
	EmployeeOnPositionInProjectID,
	Deadline)
VALUES 
('Make integration tests', 'Closed', '2019-01-12 00:00:00', 1, 11, '2019-02-10 00:00:00'),
('Test angles of move', 'Closed', '2018-10-03 00:00:00', 3, 11, '2018-11-20 00:00:00'),
('Make data viasualisation about move capabilities', 'Closed', '2017-10-10 00:00:00', 1, 12, '2017-11-10 00:00:00'),
('Add new database', 'Closed', '2016-10-20 00:00:00', 3, 12, '2016-11-25 00:00:00'),
('Make buttons', 'Needs Refinement', '2019-11-13 00:00:00', 1, 2, '2019-11-10 00:00:00'),
('Make main styles', 'Opened', '2019-10-10 00:00:00', 3, 2, '2019-11-20 00:00:00'),
('Use new library', 'Needs Refinement', '2019-11-09 00:00:00', 1, 4, '2019-11-25 00:00:00'),
('Add new database', 'Opened', '2019-10-23 00:00:00', 3, 4, '2019-10-20 00:00:00'),
('Make integration tests', 'Closed', '2017-04-12 00:00:00', 2, 5, '2017-04-25 00:00:00'),
('Test user stories', 'Opened', '2017-05-10 00:00:00', 2, 5, '2017-05-20 00:00:00'),
('Make design of main page', 'Needs Refinement', '2016-03-18 00:00:00', 1, 3, '2016-04-20 00:00:00'),
('Make design of user account page', 'Opened', '2016-04-15 00:00:00', 2, 3, '2016-04-17 00:00:00'),
('Make design of basket', 'Done', '2016-03-20 00:00:00', 1, 3, '2016-04-01 00:00:00'),
('Analis data from sensors', 'Opened', '2011-03-10 00:00:00', 4, 6, '2010-04-20 00:00:00'),
('Analis data of competitor', 'Done', '2010-05-13 00:00:00', 2, 6, '2010-05-17 00:00:00'),
('Make data visualisation', 'Needs Refinement', '2010-06-07 00:00:00', 1, 6, '2010-06-10 00:00:00'),
('Analis data about usability', 'Closed', '2010-02-10 00:00:00', 3, 6, '2010-02-20 00:00:00'),
('Make buttons clickable', 'Opened', '2016-01-27 00:00:00', 1, 2, '2016-02-02 00:00:00'),
('Test all english tenses in interpretator', 'Closed', '2018-02-09 00:00:00', 4, 1, '2018-02-09 00:00:00'),
('Make visualisation of data', 'Done', '2012-03-19 00:00:00', 5, 10, '2012-03-19 00:00:00'),
('Analis data from sensors', 'Opened', '2010-02-13 00:00:00', 3, 6, '2010-02-20 00:00:00'),
('Test grafic elements', 'Closed', '2017-03-13 00:00:00', 2, 5, '2017-03-15 00:00:00'),
('Make design of main page', 'Needs Refinement', '2016-03-18 00:00:00', 1, 3, '2016-04-17 00:00:00'),
('Make plan of developmant', 'Done', '2012-03-20 00:00:00', 4, 8, '2012-03-22 00:00:00'),
('Make integration tests', 'Done', '2017-04-22 00:00:00', 4, 1, '2017-04-23 00:00:00')
