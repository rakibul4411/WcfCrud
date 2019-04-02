var URL = "http://localhost:58521/Service1.svc/person/";
var myApp = angular.module("myApp", []);
myApp.controller("mainController", function ($scope, $http) {
    $scope.PersonVM = {};
    $scope.model = {};
    function GetAll() {
        $http({
            method: "GET",
            url: URL + "GetPerson"
        }).then(
            function (response) {
                $scope.PersonVM = response.data;
            },
            function () {
                alert("Failed.");
                console.log(response.data);
            });
    }
    $scope.btnSubmit = "Create";
    function Create(model) {
        var json = model;
        $http({
            method: "POST",
            url: URL + "AddPerson",
            data: json,
        }).then(
            function (response) {
                $scope.model = {};
                GetAll();
            },
            function () {
                alert("Failed.");
                console.log(response.data);
            });
    }
    $scope.btnUpdate = function (ps) {
        var editData = { "ID": ps };
        $http({
            method: "GET",
            url: URL + "GetPerson" + "/" + ps.ID
        }).then(
            function (response) { $scope.model = response.data; },
            function () { alert("Failed."); }
        );
        $scope.btnSubmit = "Update";
    };

    function Update(model) {
        var json = model;
        $http({
            method: "PUT",
            url: URL + "UpdatePerson",
            data: json
        }).then(
            function (response) {
                $scope.model = {};
                GetAll();
            },
            function () {
                alert("Failed.");
                console.log(response.data);
            });
    }
    $scope.btnDelete = Delete;
    GetAll();
    function Delete(model) {
        var json = model;
        if (confirm("Are you sure to delete it??????") === true) {
            $http({
                method: "POST",
                url: URL + "DeletePerson",
                data: json
            }).then(
                function (response) {
                    GetAll();
                    alert("Deleted!!!");
                },
                function () {
                    alert("Failed.");
                    console.log(response.data);
                });
        }
    }
    $scope.Click = function (model) {
        if ($("#btnSubmit").val() == "Create") {
            Create(model);
        }
        if ($("#btnSubmit").val() == "Update") {
            Update(model);
            $scope.btnSubmit = "Create";
        }
    }
});
