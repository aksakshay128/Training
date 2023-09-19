CREATE INDEX Ename_Index  on Student (contactnumber ASC);


CREATE INDEX Ename_Job_Index  on Student (StudentName ASC, CourseName ASC);


DROP INDEX Ename_Index ON STUDENT

SELECT * FROM  Student

sp_helpindex 'Student'


EXEC sp_rename 'EmployeeView', 'EmployeeView2';

EXEC sp_rename 'student.Ename_Job_Index','ENAME_INDEX_JOB';


ALTER INDEX Ename_Job_Index on Student DISABLE		


CREATE VIEW PRODUCT_VIEW AS (SELECT UnitPrice FROM PRODUCTS WHERE UnitPrice< ( select AVG(UnitPrice) from PRODUCTS));

select * from PRODUCT_VIEW

EXEC sp_rename 'product_view_CHANGED', 'Low_Cost_Products';



DROP VIEW Low_Cost_Products;
