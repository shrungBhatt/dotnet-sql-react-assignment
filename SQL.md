## SQL

### __1.__ __Deleting redundant records in a table that does not have a primary key__
```sql
DELETE SUB FROM
(SELECT ROW_NUMBER() OVER (PARTITION BY empid ORDER BY empid) cnt
 FROM test) SUB
WHERE SUB.cnt > 1
```
##
##

### __2.__ __Query output of the following__
```sql
IF EXISTS (SELECT TOP 1 * FROM dbo.region)
BEGIN
DROP TABLE dbo.region;
END
```
The above mentioned query will __not__ delete the table because the result of the __if exists__ clause always __returns false__ as there are __zero records__ in the table.
##
This query __will delete__ the table only if there is a __record already present__ in the table.

##
##

### __3.__ __Methods to find the rows that violates the foreign key constraints__

```sql
--- NOT IN (Good)
SELECT employee.deptid
FROM employee  WHERE employee.deptid NOT IN (SELECT department.deptid FROM department)
GO

-- NOT EXISTS (Best)
SELECT employee.deptid
FROM employee WHERE NOT EXISTS (SELECT department.deptid FROM department WHERE employee.deptid = department.deptid)
GO

-- LEFT JOIN (Best)
SELECT employee.deptid
FROM employee
LEFT JOIN department ON employee.deptid= department.deptid
WHERE department.deptid IS NULL
GO
```
The __first__ soulution would __not__ be a __good suggestion__ as it is __least optimized__. As the table __record size increases__ the __execution time__ will __increase__ as that query performs __more logical operations__ than the other two