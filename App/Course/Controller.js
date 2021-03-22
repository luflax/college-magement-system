// Controller - Course:
collegeManagementApp.controller('courseController', function($scope, courseService) {

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

    $scope.addCourse = () => {
        if ($scope.course != null) {
            var resp = courseService.createCourse({ Name: $scope.course.name });

            resp.then(function (d) {
                    loadCourses();
                    angular.element('#addCourseModal').modal('hide');
                    $scope.course = {}
                },
                function () {
                    alert("Error while creating course.");
                });

            
        }
    }

    $scope.deleteCourse = (courseId) => {
        if (courseId != null) {
            var resp = courseService.deleteCourse(courseId);

            resp.then(function (d) {
                    loadCourses();
                },
                function () {
                    alert("Error while deleting course.");
                });
        }
    }
})