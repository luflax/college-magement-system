// Controller - Student:
collegeManagementApp.controller('studentController', function($scope, studentService) {

    loadStudents();

    function loadStudents() {
        var students = studentService.getAllStudents();

        students.then(function(d) {
                $scope.Students = d.data;
            },
            function() {
                alert("Error while loading students.");
            });
    }

    var addStudent = () => {
        if ($scope.student != null) {
            var resp = studentService.createStudent($scope.student);

            resp.then(function (d) {
                    loadStudents();
                    angular.element('#addStudentModal').modal('hide');
                },
                function () {
                    alert("Error while creating student.");
                });


        }
    }

    var updateStudent = () => {
        if ($scope.student != null) {
            var resp = studentService.updateStudent($scope.student);

            resp.then(function (d) {
                    loadStudents();
                    angular.element('#addStudentModal').modal('hide');
                },
                function () {
                    alert("Error while updating student.");
                });
        }
    }

    $scope.onModalSave = () => {
        if ($scope.editting != null) {
            if ($scope.editting) {
                updateStudent();
            } else {
                addStudent();
            }

        }
    }

    $scope.deleteStudent = (studentId) => {
        if (studentId != null) {
            var resp = studentService.deleteStudent(studentId);

            resp.then(function (d) {
                    loadStudents();
                },
                function () {
                    alert("Error while deleting student.");
                });
        }
    }

    $scope.openEditModal = (student) => {
        if (student != null) {
            $scope.editting = true;
            $scope.student = { Id: student.Id, Name: student.Name, BirthDay: new Date(student.BirthDay), RegistrationNumber: student.RegistrationNumber};
            $scope.modalTitle = `Edit student ${student.Name}`;
            $scope.modalButtonText = "Update";
            angular.element('#addStudentModal').modal('show');
        }
    }

    $scope.openNewModal = () => {
        $scope.student = {};
        $scope.editting = false;
        $scope.modalTitle = 'Add new student';
        $scope.modalButtonText = "Create";
        angular.element('#addStudentModal').modal('show');
    }
})