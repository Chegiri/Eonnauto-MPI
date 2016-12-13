namespace EonnAuto.Controllers {

    export class HomeController {
        public message = 'Welcome To EONNAUTO'
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
    export class MyCarController {

        public vehicles;
        public vehicleResource;
        public vehicle;
        public inspection;

        public getVehicles() {
            this.vehicles = this.vehicleResource.query();
        }
        public save() {
            this.vehicleResource.save(this.vehicle).$promise.then(() => {
                this.vehicle = null;
                this.getVehicles();
            });

        }
        constructor(private $resource: angular.resource.IResourceService, private $http: ng.IHttpService, private $stateParams:
            ng.ui.IStateParamsService) {
            this.vehicleResource = $resource('/api/vehicle/:id');
            this.getVehicles();
        }
        public addInspection(inspection) {
            this.$http.post(`/api/vehicle/${this.$stateParams['id']}/inspection`, inspection)
                .then((response) => {
                    this.inspection = response.data;
                });
        }

    }
    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class DetailController {
        public vehicle;
        public inspection;
        //public vehicleResource;

        //constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService) {
        //    //this.vehicle = this.getVehicle($stateParams['id']);
        //    this.vehicleResource = $resource('/api/vehicle/:id');
        //    this.getVehicle($stateParams['id']);
        //    console.log(this.vehicleResource);
        //}
        //public getVehicle(id) {
        //    return this.vehicleResource.get({ id: id });

        constructor(private $http: ng.IHttpService, private $stateParams:
            ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            $http.get(`/api/vehicle/${$stateParams['id']}`)
                .then((response) => {
                    this.vehicle = response.data;
                    console.log(this.vehicle);
                });
        }
        public addInspection(inspection) {
            this.$http.post(`/api/vehicle/${this.$stateParams['id']}/inspection`, inspection)
                .then((response) => {
                    this.inspection = response.data;
                    this.$state.reload();
                });
        }
    }
}

