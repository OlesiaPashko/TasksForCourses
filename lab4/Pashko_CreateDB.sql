USE Pashko_DB;
CREATE TABLE Project(
	ProjectID INT PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	ProjectName VARCHAR(40) NOT NULL,
	CreationDate DATETIME,
	IsOpened BIT DEFAULT 0,
	ClosingDate DATETIME
);

CREATE TABLE Employee(
	EmployeeID INT PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	FirstName VARCHAR(30),
	ParrentName VARCHAR(30),
	LastName VARCHAR(30),
	BirthDate DATETIME
);
DROP TABLE EmployeeOnPositionInProject

CREATE TABLE EmployeeOnPositionInProject(
	EmployeeOnPositionID INT PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	PositionID INT,
	constraint FK_Position_EmployeeOnPosition foreign key (PositionID) references Position (PositionID),
	EmployeeID INT,
	constraint FK_Employee_EmployeeOnPosition foreign key (EmployeeID) references Employee (EmployeeID),
	ProjectID INT,
	constraint FK_Project_EmployeeOnPosition foreign key (ProjectID) references Project (ProjectID),
)

CREATE TABLE Task(
	TaskID INT PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	TaskName VARCHAR(100),
	TaskStatus VARCHAR(16) NOT NULL CHECK (TaskStatus IN ('Opened', 'Done', 'Closed', 'Needs Refinement')),
	StatusChangeDate DATETIME NOT NULL,
	StatusChangeEmployeeID INT NOT NULL,
	constraint FK_Employee_Task foreign key (StatusChangeEmployeeID) references Employee (EmployeeID),
	EmployeeOnPositionInProjectID INT,
	constraint FK_EmployeeOnPosition_Task foreign key (EmployeeOnPositionInProjectID) references EmployeeOnPosition (EmployeeOnPositionID),
	Deadline DATETIME
);

CREATE TABLE Position(
	PositionID INT PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	PositionName VARCHAR(100)
);