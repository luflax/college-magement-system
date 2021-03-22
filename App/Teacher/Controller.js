// Controller - Teacher:
collegeManagementApp.controller('teacherController', function($scope, teacherService) {

    loadTeachers();

    function loadTeachers() {
        var teachers = teacherService.getAllTeachers();

        teachers.then(function(d) {
                $scope.Teachers = d.data;
            },
            function() {
                alert("Error while loading teachers.");
            });
    }

    var addTeacher = () => {
        if ($scope.teacher != null) {
            var resp = teacherService.createTeacher($scope.teacher);

            resp.then(function (d) {
                    loadTeachers();
                    angular.element('#addTeacherModal').modal('hide');
                },
                function () {
                    alert("Error while creating teacher.");
                });


        }
    }

    var updateTeacher = () => {
        if ($scope.teacher != null) {
            var resp = teacherService.updateTeacher($scope.teacher);

            resp.then(function (d) {
                    loadTeachers();
                    angular.element('#addTeacherModal').modal('hide');
                },
                function () {
                    alert("Error while updating teacher.");
                });
        }
    }

    $scope.onModalSave = () => {
        if ($scope.editting != null) {
            if ($scope.editting) {
                updateTeacher();
            } else {
                addTeacher();
            }

        }
    }

    $scope.deleteTeacher = (teacherId) => {
        if (teacherId != null) {
            var resp = teacherService.deleteTeacher(teacherId);

            resp.then(function (d) {
                    loadTeachers();
                },
                function () {
                    alert("Error while deleting teacher.");
                });
        }
    }

    $scope.openEditModal = (teacher) => {
        if (teacher != null) {
            $scope.editting = true;
            $scope.teacher = { Id: teacher.Id, Name: teacher.Name, BirthDay: new Date(teacher.BirthDay), Salary: teacher.Salary };
            $scope.modalTitle = `Edit teacher ${teacher.Name}`;
            $scope.modalButtonText = "Update";
            angular.element('#addTeacherModal').modal('show');
        }
    }

    $scope.openNewModal = () => {
        $scope.teacher = {};
        $scope.editting = false;
        $scope.modalTitle = 'Add new teacher';
        $scope.modalButtonText = "Create";
        angular.element('#addTeacherModal').modal('show');
    }
})