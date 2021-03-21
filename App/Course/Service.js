courseApp.service('courseService', function($http) {

    this.getAllCourses = function() {
        return $http.get("/Course/GetCourse");
    }
})