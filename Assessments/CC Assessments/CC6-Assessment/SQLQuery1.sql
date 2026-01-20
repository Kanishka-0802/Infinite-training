
create table students_A (
    studentid int primary key identity,
    fullname varchar(100) not null,
    email varchar(100) unique,
    department varchar(50) not null,
    yearofstudy int not null
)

create table courses_A (
    courseid int primary key identity,
    coursename varchar(100) not null,
    credits int not null,
    semester varchar(20) not null
)

create table enrollments_A (
    enrollmentid int primary key identity,
    studentid int foreign key references students_A(studentid),
    courseid int foreign key references courses_A(courseid),
    enrolldate datetime not null,
    grade varchar(5) null
)


insert into students_A  values
('Arjun', 'arjun@gmail.com', 'MBA', 2),
('Meera', 'meera@gmail.com', 'IT', 3),
('Rahul', 'rahul@gmail.com', 'AI&DS', 4),
('sneha', 'sneha@gmail.com', 'CSE', 4),
('vikram', 'vikram@gmail.com', 'MCA', 2);


insert into courses_A  values
('datastructures', 4, 'semester 3'),
('digitalmarketing', 3, 'semester 4'),
('machinelearning', 4, 'semester 2'),
('blockchain', 3, 'semester 6'),
('cybersecurity', 4, 'semester 5'),
('computernetworks', 3, 'semester 4')


insert into enrollments_A  values
(1, 1, '2025-01-10', 'A'),
(1, 5, '2025-01-12', 'B'),
(2, 2, '2025-01-11', 'A'),
(3, 3, '2025-01-15', 'C'),
(4, 4, '2025-01-18', null),
(5, 6, '2025-01-20', 'B')


select * from students_A

select * from courses_A
select * from enrollments_A


create procedure usp_1
    @sem varchar(20)
as
begin
    

    select courseid,coursename,credits,semester
    from courses_A
    where semester = @sem
end






