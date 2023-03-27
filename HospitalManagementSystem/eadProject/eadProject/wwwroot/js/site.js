// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function PatientAdd() {
    var formData = $("#patientForm").serialize();
    $.ajax({
        type: "POST",
        url: "/Admin/AddPatient",
        data: formData,
        contentType: "application/json; charset:utf-8",
        success: function (res) { console.log(res); },
        error: function (err) { console.log(err); }
    });
}