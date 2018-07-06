    self.addCustomer = function () {
        var dataObject = ko.toJSON(this);

        // remove computed field from JSON data which server is not expecting
        delete dataObject.FullName;

        $.ajax({
            url: '/api/customers',
            type: 'post',
            data: dataObject,
            contentType: 'application/json',
            success: function (data) {
                CustomerViewModel.customers.push(new Customer(data.Id, data.Name, data.Address));

                self.Id(null);
                self.Name('');
                self.Address('');
            }
        });
    };
}

// use as student list view's view model
function CustomerList() {

    var self = this;

    // observable arrays are update binding elements upon array changes
    self.customers = ko.observableArray([]);

    self.getCustomers = function () {
        self.customers.removeAll();

        // retrieve students list from server side and push each object to model's students list
        $.getJSON('/api/customers', function (data) {
            $.each(data, function (key, value) {
                self.customers.push(new Customer(value.Id, value.Name, value.Address));
            });
        });
    };


    // remove student. current data context object is passed to function automatically.
    self.removeCustomer = function (customer) {
        $.ajax({
            url: '/api/customers' + customer.Id(),
            type: 'delete',
            contentType: 'application/json',
            success: function () {
                self.customers.remove(customer);
            }
        });
    };
}


// create index view view model which contain two models for partial views
CustomerViewModel = { addCustomerViewModel: new Customer(), CustomerViewModel: new CustomerList() };


// on document ready
$(document).ready(function () {

    // bind view model to referring view

    // load student data
    CustomerViewModel.CustomerViewModel.getCustomers();
});