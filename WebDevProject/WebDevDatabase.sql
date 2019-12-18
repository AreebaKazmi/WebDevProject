CREATE TABLE Person (
  PersonID INTEGER  NOT NULL   IDENTITY ,
  Name TEXT  NOT NULL  ,
  [CNIC/B-Form] BIGINT  NOT NULL  ,
  [Mobile Number] BIGINT    ,
  [Residence Telephone Number] BIGINT      ,
PRIMARY KEY(PersonID));
GO




CREATE TABLE Examination (
  ExamID INTEGER  NOT NULL   IDENTITY ,
  Fee INTEGER  NOT NULL  ,
  [Exam Group] TEXT  NOT NULL    ,
PRIMARY KEY(ExamID));
GO




CREATE TABLE Subject (
  Code INTEGER  NOT NULL   IDENTITY ,
  Title TEXT  NOT NULL    ,
PRIMARY KEY(Code));
GO




CREATE TABLE Status_2 (
  StatusID INTEGER  NOT NULL   IDENTITY ,
  Description TEXT  NOT NULL    ,
PRIMARY KEY(StatusID));
GO




CREATE TABLE Principle (
  PrincipleID INTEGER  NOT NULL   IDENTITY ,
  PersonID INTEGER  NOT NULL    ,
PRIMARY KEY(PrincipleID)  ,
  FOREIGN KEY(PersonID)
    REFERENCES Person(PersonID));
GO


CREATE INDEX Principle_FKIndex1 ON Principle (PersonID);
GO


CREATE INDEX IFK_Rel_10 ON Principle (PersonID);
GO


CREATE TABLE School (
  [School Code] INTEGER  NOT NULL   IDENTITY ,
  PrincipleID INTEGER  NOT NULL  ,
  Name TEXT  NOT NULL  ,
  Address TEXT  NOT NULL  ,
  [Contact Number] BIGINT  NOT NULL    ,
PRIMARY KEY([School Code])  ,
  FOREIGN KEY(PrincipleID)
    REFERENCES Principle(PrincipleID));
GO


CREATE INDEX School_FKIndex1 ON School (PrincipleID);
GO


CREATE INDEX IFK_Rel_11 ON School (PrincipleID);
GO


CREATE TABLE Guardian (
  GuardianID INTEGER  NOT NULL   IDENTITY ,
  PersonID INTEGER  NOT NULL    ,
PRIMARY KEY(GuardianID)  ,
  FOREIGN KEY(PersonID)
    REFERENCES Person(PersonID));
GO


CREATE INDEX Guardian_FKIndex1 ON Guardian (PersonID);
GO


CREATE INDEX IFK_Rel_12 ON Guardian (PersonID);
GO


CREATE TABLE [Examination has Subject] (
  ExamID INTEGER  NOT NULL  ,
  Code INTEGER  NOT NULL    ,
PRIMARY KEY(ExamID, Code)    ,
  FOREIGN KEY(ExamID)
    REFERENCES Examination(ExamID),
  FOREIGN KEY(Code)
    REFERENCES Subject(Code));
GO


CREATE INDEX Examination_has_Subject_FKIndex1 ON [Examination has Subject] (ExamID);
GO
CREATE INDEX Examination_has_Subject_FKIndex2 ON [Examination has Subject] (Code);
GO


CREATE INDEX IFK_Rel_06 ON [Examination has Subject] (ExamID);
GO
CREATE INDEX IFK_Rel_07 ON [Examination has Subject] (Code);
GO


CREATE TABLE Candidate (
  [Roll Number] INTEGER  NOT NULL   IDENTITY ,
  StatusID INTEGER  NOT NULL  ,
  PersonID INTEGER  NOT NULL  ,
  [School Code] INTEGER    ,
  GuardianID INTEGER  NOT NULL  ,
  DOB DATE  NOT NULL  ,
  Gender TEXT  NOT NULL  ,
  Religion TEXT  NOT NULL  ,
  Picture TEXT  NOT NULL  ,
  Address TEXT  NOT NULL  ,
  Email TEXT  NOT NULL  ,
  [Private Candidate] BIT  NOT NULL    ,
PRIMARY KEY([Roll Number])        ,
  FOREIGN KEY([School Code])
    REFERENCES School([School Code]),
  FOREIGN KEY(GuardianID)
    REFERENCES Guardian(GuardianID),
  FOREIGN KEY(PersonID)
    REFERENCES Person(PersonID),
  FOREIGN KEY(StatusID)
    REFERENCES Status_2(StatusID));
GO


CREATE INDEX Candidate_FKIndex2 ON Candidate ([School Code]);
GO
CREATE INDEX Candidate_FKIndex3 ON Candidate (GuardianID);
GO
CREATE INDEX Candidate_FKIndex5 ON Candidate (PersonID);
GO
CREATE INDEX Candidate_FKIndex4 ON Candidate (StatusID);
GO


CREATE INDEX IFK_Rel_04 ON Candidate ([School Code]);
GO
CREATE INDEX IFK_Rel_05 ON Candidate (GuardianID);
GO
CREATE INDEX IFK_Rel_13 ON Candidate (PersonID);
GO
CREATE INDEX IFK_Rel_15 ON Candidate (StatusID);
GO


CREATE TABLE [Candidate took Examination] (
  [Roll Number] INTEGER  NOT NULL  ,
  ExamID INTEGER  NOT NULL    ,
PRIMARY KEY([Roll Number], ExamID)    ,
  FOREIGN KEY([Roll Number])
    REFERENCES Candidate([Roll Number]),
  FOREIGN KEY(ExamID)
    REFERENCES Examination(ExamID));
GO


CREATE INDEX Candidate_has_Examination_FKIndex1 ON [Candidate took Examination] ([Roll Number]);
GO
CREATE INDEX Candidate_has_Examination_FKIndex2 ON [Candidate took Examination] (ExamID);
GO


CREATE INDEX IFK_Rel_08 ON [Candidate took Examination] ([Roll Number]);
GO
CREATE INDEX IFK_Rel_09 ON [Candidate took Examination] (ExamID);
GO


CREATE TABLE [Admit Card] (
  [School Code] INTEGER  NOT NULL  ,
  GuardianID INTEGER  NOT NULL  ,
  [Roll Number] INTEGER  NOT NULL        ,
  FOREIGN KEY([Roll Number])
    REFERENCES Candidate([Roll Number]),
  FOREIGN KEY(GuardianID)
    REFERENCES Guardian(GuardianID),
  FOREIGN KEY([School Code])
    REFERENCES School([School Code]));
GO


CREATE INDEX Admit_Card_FKIndex1 ON [Admit Card] ([Roll Number]);
GO
CREATE INDEX Admit_Card_FKIndex2 ON [Admit Card] (GuardianID);
GO
CREATE INDEX Admit_Card_FKIndex3 ON [Admit Card] ([School Code]);
GO


CREATE INDEX IFK_Rel_14 ON [Admit Card] ([Roll Number]);
GO
CREATE INDEX IFK_Rel_15 ON [Admit Card] (GuardianID);
GO
CREATE INDEX IFK_Rel_16 ON [Admit Card] ([School Code]);
GO


