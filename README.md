# Enozom
SQL Task
INTERNET DROP that's why answer came late!
If you wanna me to take it again no problem with me,How ever I did attempded it with my problem in connection in less than an Hour
## SQL CODE
SELECT *, sum(salary) as total_salary from employees  INNER JOIN salaries 
                on salaries.emp_no = employees.emp_no
                GROUP by salaries.emp_no
                order by total_salary DESC
                limit 1
