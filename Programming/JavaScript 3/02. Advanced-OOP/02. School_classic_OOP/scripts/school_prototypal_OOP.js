var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        var personInfo = "Name: " + this.firstName + " " + this.lastName +
                        ", Age: " + this.age;
        return personInfo;
    }
};

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        this._super = new this._super(arguments);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },

    introduce: function () {
        var studentInfo = this._super.introduce() + ", Grade: " + this.grade;

        return studentInfo;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        this._super = new this._super(arguments);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },

    introduce: function () {
        var teacherInfo = this._super.introduce() + ", Speciality: " + this.speciality;

        return teacherInfo;
    }
});

var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
    introduce: function () {
        var schoolInfo = "Name: " + this.name +
            ", Town: " + this.town +
            ", Classes: { ";
        for (var i = 0; i < this.classes.length; i++) {
            schoolInfo += this.classes[i].name + "; ";
        }
        schoolInfo += "} "

        return schoolInfo;
    }
};

var SchoolClass = {
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },
    introduce: function () {
        var classInfo = "Name: " + this.name +
            ", Capacity: " + this.capacity +
            ", Students: { ";
        for (var i = 0; i < this.students.length; i++) {
            classInfo += this.students[i].introduce() + "; ";
        }
        classInfo += "} Form-teacher" + this.formTeacher.introduce();

        return classInfo;
    }
};