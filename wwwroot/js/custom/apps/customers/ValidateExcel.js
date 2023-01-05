"use strict";
var KTModalNewTarget = function () {
    var t, e, n, a, o, i; return {
        init: function () {
            t = document.getElementById("inputSuccess") && (o = new bootstrap.Modal(i)),
                a = document.querySelector("#test-form"),
                n = FormValidation.formValidation(a, {
                    fields: {
                        contract_service_prices: { validators: { notEmpty: { message: "vendor Name  is required" } } }, contract_service_name: { validators: { notEmpty: { message: "Batch Number is required" } } },
                        contract_service_notes: { validators: { notEmpty: { message: "Batch Date is required" } } }

                    }, plugins: {
                        trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" })

                    }
                })
                


               
           
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTModalNewTarget.init() }));