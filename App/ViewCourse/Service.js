collegeManagementApp.service('viewCourseService', function($http) {

    this.getAllSubjects = function(courseId) {
        return $http.get("/Subject/GetSubjects/" + courseId);
    }

    this.getAllTeachers = function () {
        return $http.get("/Teacher/GetTeachers");
    }

    this.createSubject = function (body) {
        return $http({
            url: "/Subject/CreateSubject",
            method: "POST",
            data: { 'Name': body.Name, 'CourseId': body.CourseId, 'TeacherId': body.TeacherId }
        });
    }

    this.deleteSubject = function (subjectId) {
        return $http({
            url: "/Subject/DeleteSubject",
            method: "POST",
            data: { 'Id': subjectId }
        });
    }
})