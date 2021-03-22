collegeManagementApp.service('viewSubjectService', function($http) {

    this.getAllStudents = function () {
        return $http.get("/Student/GetStudents");
    }
})