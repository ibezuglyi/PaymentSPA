(function (ko, datacontext) {
    datacontext.paymentItem = paymentItem;
    datacontext.paymentList = paymentList;


    function paymentList(data) {
        var self = this;
        data = data || {};

        self.Title = data.title;
        self.Total = data.total;
        self.Payments = $.map(data.payments, function (item) { return new paymentItem(item); });
        self.toJson = function () { return ko.toJSON(self) };
    }
    function paymentItem(data) {
        var self = this;
        data = data || {value:0, createdAt:new Date()};
        // Persisted properties
        self.Id = data.Id;
        self.value = ko.observable(data.value);
        self.createdAt = ko.observable(data.createdAt);

        // Non-persisted properties
        self.errorMessage = ko.observable();

        saveChanges = function () {
            return datacontext.saveChangedTodoItem(self);
        };

        // Auto-save when these properties change
        self.value.subscribe(saveChanges);
        self.createdAt.subscribe(saveChanges);

        self.toJson = function () { return ko.toJSON(self) };
    }


})(ko, paymentApp.datacontext);