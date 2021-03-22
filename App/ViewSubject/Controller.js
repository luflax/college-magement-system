// Controller - ViewSubject:
collegeManagementApp.controller('viewSubjectController', function ($scope, viewSubjectService) {

    loadStudents();

    $scope.init = function (subjectId) {
        $scope.subjectId = subjectId;
    }

    function loadStudents() {
        var students = viewSubjectService.getAllStudents();

        students.then(function (d) {
                $scope.Students = d.data;
            },
            function () {
                alert("Error while loading students.");
            });
    }

    $scope.onModalSave = function () {
        $scope.student.SubjectId = $scope.subjectId;
        if ($scope.editting) {
            GradesHubProxy.invoke('UpdateGrade', $scope.student);
        } else {
            GradesHubProxy.invoke('AddGrade', $scope.student);
        }
        angular.element('#addStudentModal').modal('hide');
    }

    $scope.deleteGrade = function (gradeId) {
        GradesHubProxy.invoke('DeleteGrade', $scope.subjectId, gradeId);
    }

    $scope.updateGrades = function (subject) {
        $scope.$apply(function () {
            $scope.Grades = subject;
        });
    }

    $scope.openEditModal = (grade) => {
        if (grade != null) {
            $scope.editting = true;
            $scope.student = grade;
            $scope.modalTitle = `Edit ${grade.StudentName}'s grade`;
            $scope.modalButtonText = "Update";
            angular.element('#addStudentModal').modal('show');
        }
    }

    $scope.openNewModal = () => {
        $scope.student = {};
        $scope.editting = false;
        $scope.modalTitle = 'Add new student grade';
        $scope.modalButtonText = "Save";
        angular.element('#addStudentModal').modal('show');
    }
})