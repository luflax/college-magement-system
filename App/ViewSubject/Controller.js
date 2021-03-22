// Controller - Course:
collegeManagementApp.controller('viewSubjectController', function ($scope, viewSubjectService) {

    $scope.init = function (Subject) {
        console.log(Subject)
        $scope.Subject = Subject;
        
    }
})