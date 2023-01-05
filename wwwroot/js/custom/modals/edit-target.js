
"use strict"; var KTModalNewTarget = function () {
    var t, e, n, a, o, i; return {
        init: function () {
            (i = document.querySelector("#kt_modal_edit_target")) && (o = new bootstrap.Modal(i), a = document.querySelector("#kt_modal_edit_target_form"), t = document.getElementById("kt_modal_edit_target_submit"), e = document.getElementById("kt_modal_edit_target_cancel"),
                $(a.querySelector('[name="batch_received_date"]')).flatpickr({ enableTime: 0, dateFormat: "d, M Y" }),
                $(a.querySelector('[name="batch_date"]')).flatpickr({ enableTime: 0, dateFormat: "d, M Y", minDate: $("#RecDateedit").val()}),
                $(a.querySelector('[name="last_update_date"]')).flatpickr({ enableTime: !0, dateFormat: "d, M Y, H:i" }),

                n = FormValidation.formValidation(a, {
                    fields: {
                        batch_vendor_id: { validators: { notEmpty: { message: "vendor Name  is required" } } }, batch_number: { validators: { notEmpty: { message: "Batch Number is required" } } },
                        batch_date: { validators: { notEmpty: { message: "Batch Date is required" } } }, batch_invoice_number: { validators: { notEmpty: { message: "invoice number is required" } } },
                        batch_cost: { validators: { notEmpty: { message: "Total cost is required" } } }

                    }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
                }), t.addEventListener("click", (function (e) {
                    e.preventDefault(), n && n.validate().then((function (e) {
                        console.log("validated y hassan 2!"), "Valid" == e ? (t.setAttribute("data-kt-indicator", "on"), a.submit(),
                            t.disabled = !0, setTimeout((function () {
                                t.removeAttribute("data-kt-indicator"), t.disabled = !1,
                                    Swal.fire({
                                        text: "Form has been successfully submitted!", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    }).then((function (t) { t.isConfirmed && o.hide(); window.location.reload();}))
                            }), 2e3)) : Swal.fire({ text: "Sorry, looks like there are some errors detected, please try again.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } })
                    }))
                })), e.addEventListener("click", (function (t) { t.preventDefault(), Swal.fire({ text: "Are you sure you would like to cancel?", icon: "warning", showCancelButton: !0, buttonsStyling: !1, confirmButtonText: "Yes, cancel it!", cancelButtonText: "No, return", customClass: { confirmButton: "btn btn-primary", cancelButton: "btn btn-active-light" } }).then((function (t) { t.value ? (a.reset(), o.hide()) : "cancel" === t.dismiss && Swal.fire({ text: "Your form has not been cancelled!.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }) })) })))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTModalNewTarget.init() }));