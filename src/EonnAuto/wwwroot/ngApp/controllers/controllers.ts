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
        public years;
        public cars;
        //public models;
        //public trims;
        //public engSizes;

        public getVehicles() {
            this.vehicles = this.VehicleService.listVehicles();
        }

        public save() {
            this.VehicleService.save
                (this.vehicle);
            this.$state.reload();
        }

        constructor(

            private VehicleService: EonnAuto.Services.VehicleService,
            private $state: ng.ui.IStateService,
            private $uibModal: angular.ui.bootstrap.IModalServiceInstance,
            private $stateParams:
                ng.ui.IStateParamsService) {

            this.years = [2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017];
            this.cars = [
                {
                    make: 'Acura',
                    models: [
                        { name: 'TL', trims: ['Sports', 'Technology'], engSizes: ['3.2Cly', '3.6Cly'] },
                        { name: 'MDX', trims: ['Advanced', 'Base'], engSizes: ['6.8Cly', '3.4Cly'] }
                    ]
                },
                {
                    make: 'M-Benz',
                    models: [
                        { name: 'C-class', trims: ['320', 'Base'], engSizes: ['2.4Cly', '5.8Cly'] },
                        { name: 'G-class', trims: ['450', 'Advanced'], engsizes: ['8.5Cly', '5.8Cly'] }
                    ],
                },
            ];
            this.getVehicles();
        }
    }
    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class DetailController {
        public vehicle;
        public inspection;

        //injecting account service
        public findAdmin() {
            return this.accountService.getClaim('IsAdmin');
        }
        constructor(
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            public accountService: EonnAuto.Services.AccountService,
            private VehicleService: EonnAuto.Services.VehicleService,
            private InspectionService: EonnAuto.Services.InspectionService,
            private $state: ng.ui.IStateService) {
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
        public deleteVehicle() {
            this.VehicleService.deleteVehicle(this.vehicle.id).then(() => this.$state.go('mycar'));
        }
        public deleteInspection(inspection, id) {
            console.log(inspection, id);
            this.InspectionService.deleteInspection(id).then(() => this.$state.reload())
        }
        public editInspection(inspection) {
            this.$http.put(`/api/inspection/${this.$stateParams['id']}`, inspection)
                .then((result) => {
                    this.$state.reload();
                }).catch((reason) => {
                    console.log(reason);
                    console.log(inspection);
                });
        }
    }
}

