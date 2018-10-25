angular.module('umbraco').controller('departmentedit', function ($scope, $routeParams, departmentResource, notificationsService) {
    $scope.loaded = false;

    if ($routeParams.id == -1) {
                 $scope.department = {};
                 $scope.loaded = true;
    }
    else{
                     //get a person id -> service
                     departmentResource.getById($routeParams.id).then(function (response) {
                     $scope.department = response.data;
                     $scope.loaded = true;
                     });
    }

    $scope.save = function (department) {
              departmentResource.save(department).then(function (response) {
                  $scope.department = response.data;
            
                  notificationsService.success("عملیات با موفقیت", department.name + " ذخیره شد");
                 });
    };
});