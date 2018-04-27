var app = angular.module('basicApp', []);
app.controller('homeController', function ($scope, $http) {
    $scope.foundReserv;
    $scope.error = false;
    $scope.saved = false;

    $scope.saveReservation = function () {
        $http(
            {
                method: "POST",
                url: "/Home/SaveReservation",
                data: { ReservationGuid: "", Type: $scope.houseType, PersonalNumber: $scope.personalNumber, DateMade: "" ,Cost: 0, EndDate: $scope.endDate}
            }).then(function (response) {
                if (response === true) {
                    $scope.saved = true;
                }
                else {
                    $scope.error = true;
                }
            });
    };
    $scope.findReservation = function () {
        $http(
            {
                method: "POST",
                url: "/Home/GetReservation",
                data: { guid: $scope.searchGuid }
            }).then(function (response) {
                $scope.foundReserv = response;
            });
    };
});