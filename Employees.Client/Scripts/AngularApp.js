var AppAngular = angular.module('AngularApp', ['ngRoute']);
AppAngular.controller('EmployeeController', EmployeeController);

AppAngular.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

var configFunction = function ($routeProvider, $httpProvider, $locationProvider) {
    $routeProvider
        .when('/employees', {
            templateUrl: 'Views/Employees/EmployeeList.html',
            controller: 'EmployeeController'
        })
        .when('/employee', {
            templateUrl: 'Views/Employees/CreateEmployee.html',
            controller: 'EmployeeController'
        });

    $routeProvider.otherwise({ redirectTo: '/employees' });
    $locationProvider.hashPrefix('');
    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider', '$locationProvider'];


AppAngular.config(configFunction);