window.todoApp.paymentListViewModel = (function (ko, datacontext) {
    var payments = ko.observableArray(),
    error = ko.observable(),
    addPayment = function () {
        var payment = datacontext.createPayment();
        //payment.isEditingListTitle(true);
        datacontext.saveNewPayment(payments)
            .then(addSucceeded)
            .fail(addFailed);
    }
    function addSucceeded() {
        alert("added succeded");
        //showTodoList(todoList);
    }
    function addFailed() {
        error("Save of new todoList failed");
    }

    return { addPayment: addPayment }
})(ko, todoApp.datacontext);