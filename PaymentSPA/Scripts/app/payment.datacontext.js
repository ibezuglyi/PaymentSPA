window.paymentApp = window.paymentApp || {};

window.paymentApp.datacontext = (function () {
    var datacontext = {
        createPayment: createPayment,
        getPaymentLists: getPaymentLists,
        saveNewPayment: saveNewPayment,
    };
    return datacontext;

    function getPaymentLists(paymentListObservable, errorObservable) {
        return ajaxRequest("get", paymentListUrl())
            .done(getSucceeded)
            .fail(getFailed);

        function getSucceeded(data) {
            var mappedPaymentList = $.map(data, function (list) { return new createPaymentList(list); });
            paymentListObservable(mappedPaymentList);
        }

        function getFailed() {
            errorObservable("Error retrieving todo lists.");
        }
     

    }
    function saveNewPayment(payment) {
        console.log("payment saved");
        return ajaxRequest("post", paymentItemUrl(), payment)
            .done(function (result) {

            });
    }
    function createPayment(data) {
        return new datacontext.paymentItem(data);
    }
    function createPaymentList(data) {
        return new datacontext.paymentList(data); // todoList is injected by todo.model.js
    }
    function saveChangedTodoItem(paymentItem) {
        clearErrorMessage(paymentItem);
        return ajaxRequest("put", paymentItemUrl(paymentItem.Id), paymentItem, "text")
            .fail(function () {
                todoItem.errorMessage("Error updating todo item.");
            });
    }

    // Private
    function clearErrorMessage(entity) { entity.errorMessage(null); }
    // Ajax helper
    function ajaxRequest(type, url, data, dataType) {
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? data.toJson() : null
        };
        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            }
        }
        return $.ajax(url, options);
    }

    function paymentListUrl() { return "/api/payments/getall"; }
    function paymentItemUrl(id) { return "/api/payments/" + (id || ""); }
})();