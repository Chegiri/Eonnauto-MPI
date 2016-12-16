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

        public vehicle;
        public inspection;

        public getVehicles() {
            this.vehicles = this.VehicleService.listVehicles();
        }
        public save() {
            this.VehicleService.save(this.vehicle);

        }
        constructor(
            
            private VehicleService: EonnAuto.Services.VehicleService,
            private $state: ng.ui.IStateService,
            private $stateParams:
                ng.ui.IStateParamsService) {
            this.getVehicles();


        }
        
    }
    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class DetailController {
        public vehicle;
        public inspection;
<<<<<<< HEAD
    

        constructor(
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private VehicleService: EonnAuto.Services.VehicleService,
            private InspectionService: EonnAuto.Services.InspectionService,
            private $state: ng.ui.IStateService) {
            $http.get(`/api/vehicle/${$stateParams['id']}`)
                .then((response) => {
                    this.vehicle = response.data;
                    console.log(this.vehicle);
                });
=======
        //public vehicleResource;

    //    constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService) {
    //        //this.vehicle = this.getVehicle($stateParams['id']);
    //        this.vehicleResource = $resource('/api/vehicle/:id');
    //        this.getVehicle($stateParams['id']);
    //        console.log(this.vehicleResource);
    //    }
    //    public getVehicle(id) {
    //        return this.vehicleResource.get({ id: id });
        //constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService) {
        //    //this.vehicle = this.getVehicle($stateParams['id']);
        //    this.vehicleResource = $resource('/api/vehicle/:id');
        //    this.getVehicle($stateParams['id']);
        //    console.log(this.vehicleResource);
        //}
        //public getVehicle(id) {
        //    return this.vehicleResource.get({ id: id });

            constructor(private $http: ng.IHttpService, private $stateParams:
                ng.ui.IStateParamsService) {
                $http.get(`/api/vehicle/${$stateParams['id']}`)
                    .then((response) => {
                        this.vehicle = response.data;
                        console.log(this.vehicle);
                    });
>>>>>>> 0156a22809375d5ccddc34e6debb00bd72d49b47
        }
        public addInspection(inspection) {
            this.$http.post(`/api/vehicle/${this.$stateParams['id']}/inspection`, inspection)
                .then((response) => {
                    this.inspection = response.data;
                    this.$state.reload();
                });
            }
        }
        public deleteVehicle() {
            this.VehicleService.deleteVehicle(this.vehicle.id).then(() => this.$state.go('mycar'));
        }
        public deleteInspection() {
            this.InspectionService.deleteInspection(this.inspection.id).then(() => this.$state.go('detail'));
        }
    }

