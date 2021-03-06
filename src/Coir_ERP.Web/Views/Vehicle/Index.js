(function () {
    $(function () {

        //const _createOrEditVehicleModal = new app.ModalManager({
        //    viewUrl: '/Vehicle/CreateOrEditModal',
        //    scriptUrl:
        //    modalClass: 'CreateOrEditVehicleModal'
        //});

        const _$VehicleTable = $('#Vehicle');
        const _$VehicleService = abp.services.app.vehicle;
        _$VehicleTable.jtable({
            title:"Vehicle",
            paging: true,
            sorting: true,
            pazeSize:10,
            actions: {
                
                listAction: {
                    method: _$VehicleService.getByFilter

                } ,
                createAction: '',
                updateAction: '',
                deleteAction: '',
                
            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                vehicleNumber: {
                    title: 'Vehicle Number',
                    width: '20%'
                },
                customerName: {
                    title: 'Customer',
                    width: '20%'
                },
                driverName: {
                    title: 'Driver',
                    width: '20%'
                }
                , amount: {
                    title: 'Amount',
                    width:'20%'
                },
                remarks: {
                    title: 'Remarks',
                    width:'30%'
                }
            }
            
        });
        _$VehicleTable.jtable('load');
    });
})();