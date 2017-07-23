(function () {
    angular.module("app-trips")
    .controller("tripEditorController", tripEditorController);

    function tripEditorController($routeParams, $http) {
        var vm = this;

        vm.tripName = $routeParams.tripName;
        vm.stops = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/trips/" + vm.tripName + "/stops")
            .then(function (response) {
                angular.copy(response.data, vm.stops);
            }, function(err){
                vm.errorMessage = "Failed To load Stops";
            })
            .finally(function () {
            vm.isBusy = false;
        });
    }

    function _showMap(stops) {

        if (stops && stops.length > 0) {

            var mapStops = _.map(stops, function (item){
                return {
                    lat: 50.850000,
                    long: 4.350000,
                    info: "Brussels, Belgium - Jun 25-27, 2014"
                };
            });

                travelMap.createMap({
                    stops: mapStops,
                    selector: "#map",
                    currentStop: 1,
                    initialZoom: 3
                });
        } else {
            alert("vai tomar no cu o erro ta aqui");
        }
    }

})();