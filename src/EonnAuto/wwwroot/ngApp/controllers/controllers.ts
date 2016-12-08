namespace EonnAuto.Controllers {

    export class HomeController {

        public vehicles;
        public vehicleResource;
        public vehicle;

        public getVehicles() {
            this.vehicles = this.vehicleResource.query();
        }
        public save() {
            this.vehicleResource.save(this.vehicle).$promise.then(() => {
                this.vehicle = null;
                this.getVehicles();
            });
            
        }
        constructor(private $resource: angular.resource.IResourceService) {
            this.vehicleResource = $resource('/api/vehicles/:id');
            this.getVehicles();
        }
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class DetailController {
        public vehicle;

        constructor(private $http: ng.IHttpService, private $stateParams:
            ng.ui.IStateParamsService) {
            $http.get(`/api/vehicles/${$stateParams['id']}`)
                .then((response) => {
                    this.vehicle = response.data;
                    console.log(this.vehicle);
                });
        }
    }

}