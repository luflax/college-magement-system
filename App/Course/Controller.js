// Controller - Course:
courseApp.controller('courseController', function($scope, courseService) {

    loadCourses();

    function loadCourses() {
        var courses = courseService.getAllCourses();

        courses.then(function(d) {
                $scope.Courses = d.data;
            },
            function() {
                alert("Error while loading courses.");
            });
    }
})