angular.module("umbraco.resources").factory("departmentResource", function ($http) {
    return {
        getById: function (id) { return $http.get('backoffice/hnfirstpack/departmentApi/GetById?id=' + id); },
        save: function (department) { return $http.post("backoffice/hnfirstpack/departmentApi/PostSave", angular.toJson(department)); }
    };
});