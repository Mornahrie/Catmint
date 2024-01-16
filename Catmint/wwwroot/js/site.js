// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirmRegistration() {
    if (confirm("Вы уверены, что хотите зарегистрироваться?")) {
        // Если пользователь подтверждает, выполнить действия  
    } else {
        // Если пользователь отменяет, не делать никаких действий
    }
}

function confirmBooking() {
    if (confirm("Вы уверены, что забронировать?")) {
        // Если пользователь подтверждает, выполнить действия  
    } else {
        // Если пользователь отменяет, не делать никаких действий
    }
}

function showTable() {
    var tableContainer = document.getElementById("tableContainer");
    tableContainer.style.display = "block";
}