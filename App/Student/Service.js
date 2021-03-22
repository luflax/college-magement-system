collegeManagementApp.service('studentService', function($http) {

    this.getAllStudents = function() {
        return $http.get("/Student/GetStudents");
    }

    this.createStudent = function (body) {
        return $http({
            url: "/Student/CreateStudent",
            method: "POST",
            data: { 'Name': body.Name, 'BirthDay': body.BirthDay, 'RegistrationNumber': body.RegistrationNumber }
        });
    }

    this.updateStudent = function (body) {
        return $http({
            url: "/Student/UpdateStudent",
            method: "POST",
            data: { 'Id': body.Id, 'Name': body.Name, 'BirthDay': body.BirthDay, 'RegistrationNumber': body.RegistrationNumber }
        });
    }

    this.deleteStudent = function (studentId) {
        return $http({
            url: "/Student/DeleteStudent",
            method: "POST",
            data: { 'Id': studentId }
        });
    }
})