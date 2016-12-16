namespace EonnAuto.Services {
    export class VehicleService {
        private VehicleResource;

        public listVehicles() {
            return this.VehicleResource.query();
        }
        public save(vehicle) {
            return this.VehicleResource.save(vehicle).$promise;
        }
        public getVehicle(id) {
            return this.VehicleResource.get({ id: id });
        }
        public deleteVehicle(id: number) {
            return this.VehicleResource.delete({ id: id }).$promise;
        }
        constructor($resource: ng.resource.IResourceService) {
            this.VehicleResource = $resource('api/vehicle/:id');
        }
    }
    angular.module('EonnAuto').service('VehicleService', VehicleService);

    export class InspectionService {
        private InspectionResource;

        public listInspections() {
            return this.InspectionResource.query();
        }
        public save(inspection) {
            return this.InspectionResource.save(inspection).$promise;
        }
        public getInspection(id) {
            return this.InspectionResource.get({ id: id });
        }
        public deleteInspection(id: number) {
            return this.InspectionResource.delete({ id: id }).$promise;
        }
        constructor($resource: ng.resource.IResourceService) {
            this.InspectionResource = $resource('api/detail/:id');

        }
    }
    angular.module('EonnAuto').service('InspectionService', InspectionService);
    }
