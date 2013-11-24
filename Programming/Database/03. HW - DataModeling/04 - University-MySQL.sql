SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`faculties` (
  `Id` INT(11) NOT NULL ,
  `Name` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`departments` (
  `Id` INT(11) NOT NULL ,
  `Name` VARCHAR(50) NOT NULL ,
  `FacultyId` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FacultyId` (`FacultyId` ASC) ,
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyId` )
    REFERENCES `university`.`faculties` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`professors` (
  `Id` INT(11) NOT NULL ,
  `Name` VARCHAR(50) NOT NULL ,
  `DepartmentId` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `DepartmentId` (`DepartmentId` ASC) ,
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `university`.`departments` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`courses` (
  `Id` INT(11) NOT NULL ,
  `StudentId` INT(11) NOT NULL ,
  `DepartmentId` INT(11) NOT NULL ,
  `ProfessorId` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `DepartmentId` (`DepartmentId` ASC) ,
  INDEX `ProfessorId` (`ProfessorId` ASC) ,
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `university`.`departments` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `university`.`professors` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`students` (
  `Id` INT(11) NOT NULL ,
  `FirstName` VARCHAR(50) NOT NULL ,
  `LastName` VARCHAR(50) NOT NULL ,
  `CourseId` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`studentbycourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`studentbycourses` (
  `Id` INT(11) NOT NULL ,
  `StudentId` INT(11) NOT NULL ,
  `CourseId` INT(11) NOT NULL ,
  INDEX `CourseId` (`CourseId` ASC) ,
  INDEX `StudentId` (`StudentId` ASC) ,
  CONSTRAINT `FK_StudentByCourses_Courses`
    FOREIGN KEY (`CourseId` )
    REFERENCES `university`.`courses` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_StudentByCourses_Students`
    FOREIGN KEY (`StudentId` )
    REFERENCES `university`.`students` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`titles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`titles` (
  `Id` INT(11) NOT NULL ,
  `Name` VARCHAR(10) NOT NULL ,
  `ProfessorId` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `ProfessorId` (`ProfessorId` ASC) ,
  CONSTRAINT `FK_Titles_Professors`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `university`.`professors` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `university` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
