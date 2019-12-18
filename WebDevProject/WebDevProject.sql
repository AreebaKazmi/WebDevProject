Insert into dbo.Person (Name, [CNIC/B-Form], [Mobile Number], [Residence Telephone Number])
values ('Tasneem Adnan', 4102949204818, 03924234930,02134020102)

Insert into dbo.Person (Name, [CNIC/B-Form], [Mobile Number], [Residence Telephone Number])
values ('Reeba Aslam', 4102949104218, 03014234950,02138021182)

Insert into dbo.Person (Name, [CNIC/B-Form], [Mobile Number], [Residence Telephone Number])
values ('Sami Murtaza', 42102449264811, 03004234932,02136110102)

Insert into dbo.Person (Name, [CNIC/B-Form], [Mobile Number], [Residence Telephone Number])
values ('Areeba Kazmi', 4210129485921, 03921237920,02133011107)


Insert into Examination (Fee, [Exam Group])
values (2500, 'Bio')

Insert into Examination (Fee, [Exam Group])
values (2500, 'CS')

Insert into Examination (Fee, [Exam Group])
values (1200, 'Commerce')

Insert into Examination (Fee, [Exam Group])
values (1200, 'Humanities')

Insert into Subject (Title)
values ('Mathematics')

Insert into Subject (Title)
values ('Computer Studies')

Insert into Subject (Title)
values ('Biology')

Insert into Subject (Title)
values ('Eonomics')

Insert into Subject (Title)
values ('Pak Studies')


Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Bio' and Convert(Varchar,Title) = 'Biology' 

Insert into [Examination has Subject]
select ExamID,Code from Examination, Subject 
where convert(Varchar,[Exam Group]) = 'Bio' and Convert(Varchar,Title) = 'Mathematics' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Bio' and Convert(Varchar,Title) =  'Pak Studies' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'CS' and Convert(Varchar,Title) = 'Computer Studies' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'CS' and Convert(Varchar,Title) = 'Mathematics' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'CS' and Convert(Varchar,Title) ='Pak Studies' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Commerce' and Convert(Varchar,Title) = 'Economics' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Commerce' and Convert(Varchar,Title) = 'Pak Studies' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Commerce' and Convert(Varchar,Title) = 'Mathematics' 

Insert into [Examination has Subject]
select ExamID , Code from Examination, Subject
where convert(Varchar,[Exam Group]) = 'Humanities' and Convert(Varchar,Title) = 'Pak Studies' 

