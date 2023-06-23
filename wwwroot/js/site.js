document.addEventListener("DOMContentLoaded", function () {
    togglePriceRentFields();

    var isForRentCheckbox = document.getElementById("IsForRent");
    isForRentCheckbox.addEventListener("change", function () {
        togglePriceRentFields();
    });
});

function togglePriceRentFields() {
    var isForRent = document.getElementById("IsForRent").checked;
    var priceField = document.getElementById("Price");
    var rentPriceField = document.getElementById("RentPrice");
    var priceLabel = document.querySelector("label[for='Price']");
    var rentPriceLabel = document.querySelector("label[for='RentPrice']");
    var statusSelect = document.getElementById("Status");

    if (isForRent) {
        priceField.style.display = "none";
        rentPriceField.style.display = "";
        priceLabel.style.display = "none";
        rentPriceLabel.style.display = "";
        statusSelect.value = "Rent";
    } else {
        priceField.style.display = "";
        rentPriceField.style.display = "none";
        priceLabel.style.display = "";
        rentPriceLabel.style.display = "none";
        if (statusSelect.value === "Rent") {
            statusSelect.value = "Sale";
        }
    }
}

document.getElementById("searchForm").addEventListener("submit", function (event) {
    event.preventDefault(); // Предотвращает отправку формы

    var selectElement = document.querySelector("#searchForm select");
    var selectedValue = selectElement.value;

    if (selectedValue === "1") {
        window.location.href = "/sales"; // Перенаправление на страницу для купівля
    } else if (selectedValue === "2") {
        window.location.href = "/rent"; // Перенаправление на страницу для оренда
    }
});

