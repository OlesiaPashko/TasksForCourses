USE Pashko_DB;
--1.�������� ������ ���� ���������� �������� � ����������� ����������� ��
--������ �� ���
SELECT PositionName, COUNT(PositionName) AS EmployeesOnPosition 
FROM EmployeeOnPositionInProject E 
JOIN Position P ON E.PositionID=P.PositionID  
GROUP BY PositionName
UNION
(SELECT PositionName, 0 FROM Position 
EXCEPT 
SELECT PositionName, 0
FROM EmployeeOnPositionInProject E 
JOIN Position P ON E.PositionID=P.PositionID)
--2. ���������� ������ ���������� ��������, �� ������� ��� �����������
SELECT PositionName FROM Position 
EXCEPT 
SELECT PositionName
FROM EmployeeOnPositionInProject E 
JOIN Position P ON E.PositionID=P.PositionID
--3. �������� ������ �������� � ���������, ������� ����������� ������
--��������� �������� �� �������
SELECT ProjectName, PositionName, COUNT(PositionName) AS EmployeesOnPositionInProject FROM Project P 
JOIN EmployeeOnPositionInProject E ON E.ProjectID=P.ProjectID
JOIN Position Po ON E.PositionID=Po.PositionID 
GROUP BY ProjectName, PositionName 
ORDER BY ProjectName
--4. ��������� �� ������ �������, ����� � ������� ���������� �����
--���������� �� ������� ����������
SELECT ProjectName, count(TaskID)/COUNT(DISTINCT EmployeeID) AS AverangeTasksPerPerson FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
GROUP BY ProjectName
ORDER BY ProjectName
--5. ���������� ������������ ���������� ������� �������
SELECT ProjectName, DATEDIFF(yyyy, CreationDate, ClosingDate) AS Years FROM PROJECT 
WHERE IsOpened = 0

--6. ���������� ����������� � ����������� ����������� ���������� �����
SELECT TOP 3 LastName, COUNT(*) AS UnClosedTaskes FROM Employee E 
JOIN EmployeeOnPositionInProject EP ON E.EmployeeID=EP.EmployeeID
JOIN TASK T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
WHERE TaskStatus != 'Closed'
GROUP BY LastName
ORDER BY UnClosedTaskes
--7. ���������� ����������� � ������������ ����������� ���������� �����,
--������� ������� ��� �����
 SELECT TOP 3 LastName, COUNT(LastName) AS UnclosedTasksCount FROM Task T 
 JOIN EmployeeOnPositionInProject EP ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
 JOIN Employee E ON E.EmployeeID=EP.EmployeeID 
 WHERE TaskStatus != 'Closed' AND Deadline < GETDATE()
 GROUP BY LastName
 ORDER BY UnclosedTasksCount desc
--8. �������� ������� ���������� ����� �� 5 ����
UPDATE Task
SET Deadline = DATEADD(d,5,Deadline)
WHERE TaskStatus != 'Closed' AND Deadline < GETDATE()
--9. ��������� �� ������ ������� ���������� �����, � ������� ��� ��
--����������
SELECT ProjectName, COUNT(TaskID) AS CountOpenedTasks FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
WHERE TaskStatus = 'Opened'
GROUP BY ProjectName
--10.��������� ������� � ��������� ������, ��� ������� ��� ������ ������� �
--������ ����� �������� �������� �������� ������ �������, ��������
--���������
DECLARE @DateOfLastClosedTask DATETIME;

SET @DateOfLastClosedTask = (SELECT max(StatusChangeDate) AS DateOfLastClosedTask FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
WHERE ProjectName NOT IN 
(SELECT ProjectName FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
WHERE T.TaskStatus!='Closed'))

UPDATE Project
SET IsOpened=0,
ClosingDate = @DateOfLastClosedTask
FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
WHERE ProjectName IN (SELECT ProjectName 
WHERE ProjectName NOT IN 
(SELECT ProjectName 
WHERE T.TaskStatus!='Closed'))
--11.�������� �� ���� ��������, ����� ���������� �� ������� �� �����
--���������� �����
SELECT DISTINCT P.ProjectName, EM.LastName
FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
JOIN Employee EM ON EM.EmployeeID=E.EmployeeID 
GROUP BY P.ProjectName, EM.EmployeeID, EM.LastName
EXCEPT
(SELECT DISTINCT P.ProjectName, EM.LastName
FROM Task T 
JOIN EmployeeOnPositionInProject E ON T.EmployeeOnPositionInProjectID=E.EmployeeOnPositionID
JOIN Project P ON E.ProjectID=P.ProjectID
JOIN Employee EM ON EM.EmployeeID=E.EmployeeID 
WHERE TaskStatus!='Closed'
GROUP BY P.ProjectName, EM.EmployeeID, EM.LastName)
--12.�������� ������ (�� ��������) ������� ��������� �� ���������� �
--����������� ����������� ����������� �� �����
CREATE PROCEDURE OverturnTaskProcedure 
   (
        --�������� ���������
        @ProjectName VARCHAR(100),
        @TaskID INT
   )
   AS
   BEGIN
        DECLARE @EmployeeToOverturnTaskON INT;
        --�������� ������ �������� � ������ � � ����� ������
        SET @ProjectName = LTRIM(RTRIM(@ProjectName));
        SET @EmployeeToOverturnTaskON = (SELECT E.EmployeeID FROM Employee E 
		JOIN EmployeeOnPositionInProject EP ON E.EmployeeID=EP.EmployeeID
		JOIN Task T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
		GROUP BY E.EmployeeID
		HAVING COUNT(E.EmployeeID) = (SELECT MIN(SUBQ.TasksOnPerson) AS MinTasksPerPerson FROM 
		(SELECT COUNT(E.EmployeeID) AS TasksOnPerson
		FROM Employee E 
		JOIN EmployeeOnPositionInProject EP ON E.EmployeeID=EP.EmployeeID
		JOIN Task T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
		WHERE T.TaskStatus!='Closed'
		GROUP BY E.EmployeeID) AS SUBQ))

        --��������� ����� ������� EmployeeOnPositionInProject
		UPDATE EmployeeOnPositionInProject
		SET EmployeeID = @EmployeeToOverturnTaskON
		FROM EmployeeOnPositionInProject EP 
		JOIN Project P ON P.ProjectID=EP.ProjectID
		JOIN Task T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
		WHERE T.TaskID=@TaskID AND P.ProjectName=@ProjectName

		 --��������� ����� ������� Task
        UPDATE Task
		SET EmployeeOnPositionInProjectID = (SELECT EmployeeOnPositionInProjectID 
		FROM EmployeeOnPositionInProject EP 
		JOIN Project P ON P.ProjectID=EP.ProjectID
		JOIN Task T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
		WHERE T.TaskID=@TaskID AND P.ProjectName=@ProjectName)
		FROM Employee E 
		JOIN EmployeeOnPositionInProject EP ON E.EmployeeID=EP.EmployeeID
		JOIN Task T ON T.EmployeeOnPositionInProjectID=EP.EmployeeOnPositionID
		WHERE T.TaskID=@TaskID
   END

   GO

   EXEC OverturnTaskProcedure 'Text generator', 1