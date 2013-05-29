window.paymentApp.paymentListViewModel = (function (ko, datacontext) {
    var paymentList = ko.observableArray(),
        paymentObject = ko.observable(),
    error = ko.observable(),
    addPayment = function () {
        paymentObject(datacontext.createPayment());
        //payment.isEditingListTitle(true);
        //datacontext.saveNewPayment(payment)
        //    .then(addSucceeded)
        //    .fail(addFailed);
        //addSucceeded(payment);
    },
    showNewPayment = function (payment)
    {
        paymentObject = payment;
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
        paymentObject:paymentObject,
        addPayment: addPayment,
        error: error,
        paymentList: paymentList
    };
})(ko, paymentApp.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.paymentApp.paymentListViewModel);