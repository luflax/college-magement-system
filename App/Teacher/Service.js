collegeManagementApp.service('teacherService', function($http) {

    this.getAllTeachers = function() {
        return $http.get("/Teacher/GetTeachers");
    }

    this.createTeacher = function (body) {
        return $http({
            url: "/Teacher/CreateTeacher",
            method: "POST",
            data: { 'Name': body.Name, 'BirthDay': body.BirthDay, 'Salary': body.Salary }
        });
    }

    this.updateTeacher = function (body) {
        return $http({
            url: "/Teacher/UpdateTeacher",
            method: "POST",
            data: { 'Id': body.Id, 'Name': body.Name, 'BirthDay': body.BirthDay, 'Salary': body.Salary }
        });
    }

    this.deleteTeacher = function (teacherId) {
        return $http({
            url: "/Teacher/DeleteTeacher",
            method: "POST",
            data: { 'Id': teacherId }
        });
    }
})