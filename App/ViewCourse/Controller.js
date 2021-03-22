// Controller - Course:
collegeManagementApp.controller('viewCourseController', function ($scope, viewCourseService) {

    $scope.init = function (Id, Name) {
        $scope.Course = { Id, Name };

        loadSubjects();
    }

    loadTeachers();

    function loadTeachers() {
        var teachers = viewCourseService.getAllTeachers();

        teachers.then(function (d) {
                $scope.Teachers = d.data;
            },
            function () {
                alert("Error while loading teachers.");
            });
    }

    function loadSubjects() {
        var subjects = viewCourseService.getAllSubjects($scope.Course.Id);

        subjects.then(function(d) {
                $scope.Subjects = d.data;
            },
            function() {
                alert("Error while loading subjects.");
            });
    }

    $scope.addSubject = () => {
        if ($scope.subject != null) {
            var resp = viewCourseService.createSubject({ Name: $scope.subject.name, CourseId: $scope.Course.Id, TeacherId: $scope.subject.TeacherId });

            resp.then(function (d) {
                    loadSubjects();
                    angular.element('#addSubjectModal').modal('hide');
                    $scope.subject = {}
                },
                function () {
                    alert("Error while creating subject.");
                });

            
        }
    }

    $scope.deleteSubject = (subjectId) => {
        if (subjectId != null) {
            var resp = viewCourseService.deleteSubject(subjectId);

            resp.then(function (d) {
                    loadSubjects();
                },
                function () {
                    alert("Error while deleting subject.");
                });
        }
    }
})