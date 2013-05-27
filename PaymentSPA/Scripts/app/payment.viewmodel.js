window.paymentApp.paymentListViewModel = (function (ko, datacontext) {
    var paymentList = ko.observableArray(),
    error = ko.observable(),
    addPayment = function () {
        var payment = datacontext.createPayment();
        //payment.isEditingListTitle(true);
        datacontext.saveNewPayment(payment)
            .then(addSucceeded)
            .fail(addFailed);
    },
    showNewPayment = function (payment)
    {
        paymentList.unshift(payment);
    }
    function addSucceeded(payment) {
        //alert("added succeded");
        showNewPayment(payment);
    }

    function addFailed() {
        error("Save of new todoList failed");
    }

    datacontext.getPaymentLists(paymentList, error); // load todoLists

    return {
        addPayment: addPayment,
        error: error,
        paymentList: paymentList
    };
})(ko, paymentApp.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.paymentApp.paymentListViewModel);