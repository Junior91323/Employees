var EmployeeController = function ($scope, $http, $routeParams, $filter, $location) {

    var RefreshData = function () {

        $http.get(Settings.API.Employees.GetList()).then(function successCallback(data) {
            if (data != null) {
                $scope.data = data.data;
                console.log($scope.data);
            }
        }, function errorCallback(error) {
            console.log("code: " + status);
        });


    }
    var LoadJobs = function () {

        $http.get(Settings.API.Jobs.GetList()).then(function successCallback(data) {
            if (data != null) {
                $scope.jobs = data.data;
                console.log($scope.jobs);
            }
        }, function errorCallback(error) {
            console.log("code: " + status);
        });


    }

    if ($scope.data == null) {
        //RefreshData();

    }

    $scope.$on('$viewContentLoaded', function () {
        //call it here
         RefreshData();
        LoadJobs();
    });

    $scope.AddEmployee = function (employee, form) {
        if (form.$valid) {
            $http.post(Settings.API.Employees.Create(), employee).then(function (data) {
                if (data != null) {
                    console.log("success: " + data);
                    //alert(owner.Name + " is added!");
                    $location.path('/employees');
                    RefreshData();
                }
            }, function (data, status, headers, config) {
                console.log("code: " + status);
            });
        }
    };

    $scope.DeleteEmployee = function (id, e) {
       // e.preventDefault();
        if (id != 0) {
            $http.delete(Settings.API.Employees.Delete(id)).then(function (data) {
                if (data != null) {
                    console.log("success: " + data);
                    //alert(owner.Name + " is added!");
                    RefreshData();
                }
            }, function (data, status, headers, config) {
                console.log("код ответа: " + status);
            });
        }
    };




}

EmployeeController.$inject = ['$scope', '$http', '$routeParams', '$filter', '$location'];