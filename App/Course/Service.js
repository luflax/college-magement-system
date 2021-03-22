collegeManagementApp.service('courseService', function($http) {

    this.getAllCourses = function() {
        return $http.get("/Course/GetCourses");
    }

    this.createCourse = function (body) {
        return $http({
            url: "/Course/CreateCourse",
            method: "POST",
            data: { 'Name': body.Name }
        });
    }

    this.deleteCourse = function (courseId) {
        return $http({
            url: "/Course/DeleteCourse",
            method: "POST",
            data: { 'Id': courseId }
        });
    }
})