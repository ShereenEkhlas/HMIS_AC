////"use strict";
////var KTPasswordResetGeneral = function () {
////    var t,
////        m,
////        e,
////        i; return {
////            init: function () {
////                m = new bootstrap.Modal(document.querySelector("#kt_modal_update_pass")),
////                t = document.querySelector("#kt_password_reset_form"),
////                    e = document.querySelector("#kt_password_reset_submit"),
////                    i = FormValidation.formValidation(t, {
////                        fields: {
////                            newPass: {
////                                validators: {
////                                    notEmpty: { message: "New Password is required" }

////                                }
////                            }
////                        }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
////                    }), e.addEventListener("click", (function (o) { o.preventDefault(), i.validate().then((function (i) { "Valid" == i ? (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, setTimeout((function () { e.removeAttribute("data-kt-indicator"), e.disabled = !1, Swal.fire({ text: "You have successfully logged in!", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }).then((function (e) { e.isConfirmed && (m.hide(), t.disabled = !1,t.querySelector('[name="newPass"]').value = "", CloseModel() ) })) }), 1500)) : Swal.fire({ text: "Sorry, looks like there are some errors detected, please try again.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }) })) }))
////            }
////        }
////}(); KTUtil.onDOMContentLoaded((function () { KTPasswordResetGeneral.init() }));



"use strict";
var KTModalCustomersAdd = function () {
    var t, e, o, n, r, i; return {
        init: function () {
            i = new bootstrap.Modal(document.querySelector("#kt_modal_update_pass")),
                r = document.querySelector("#kt_password_reset_form"),
                t = r.querySelector("#kt_password_reset_submit"),
                e = r.querySelector("#kt_modal_reset_cancel"),

                n = FormValidation.formValidation(r, {
                    fields: {
                        Password: { validators: { notEmpty: { message: "Name is required" } } },
                        

                    }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
                }), t.addEventListener("click", (function (e) { e.preventDefault(), n && n.validate().then((function (e) { console.log("validated!"), "Valid" == e ? (r.submit(), t.setAttribute("data-kt-indicator", "on"), t.disabled = !0, setTimeout((function () { t.removeAttribute("data-kt-indicator"), Swal.fire({ text: "Form has been successfully submitted!", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }).then((function (e) { e.isConfirmed && (i.hide(), t.disabled = !1, CloseModel()) })) }), 2e3)) : Swal.fire({ text: "Sorry, looks like there are some errors detected, please try again.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }) })) })), e.addEventListener("click", (function (t) { t.preventDefault(), Swal.fire({ text: "Are you sure you would like to cancel?", icon: "warning", showCancelButton: !0, buttonsStyling: !1, confirmButtonText: "Yes, cancel it!", cancelButtonText: "No, return", customClass: { confirmButton: "btn btn-primary", cancelButton: "btn btn-active-light" } }).then((function (t) { t.value ? (r.reset(), i.hide()) : "cancel" === t.dismiss && Swal.fire({ text: "Your form has not been cancelled!.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }) })) })), e.addEventListener("click", (function (t) { t.preventDefault(), Swal.fire({ text: "Are you sure you would like to cancel?", icon: "warning", showCancelButton: !0, buttonsStyling: !1, confirmButtonText: "Yes, cancel it!", cancelButtonText: "No, return", customClass: { confirmButton: "btn btn-primary", cancelButton: "btn btn-active-light" } }).then((function (t) { t.value ? (r.reset(), i.hide()) : "cancel" === t.dismiss && Swal.fire({ text: "Your form has not been cancelled!.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }) })) }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTModalCustomersAdd.init() }));