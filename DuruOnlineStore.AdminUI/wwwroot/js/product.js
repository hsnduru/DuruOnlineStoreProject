//CREATE
$(document).ready(function () {
    function showSuccessMessage(productName) {
        var successMessage = productName + " eklendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitCreateProductForm() {
        $.ajax({
            url: $("#createProductForm").attr("action"),
            type: $("#createProductForm").attr("method"),
            data: $("#createProductForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#Name").val());
                
                setTimeout(function () {
                    window.location.href = "Index";
                }, 1000);
            }
        });
    }

    $("#createProductForm").submit(function (e) {
        e.preventDefault();
        submitCreateProductForm();
    });
});

//EDIT
$(document).ready(function () {
    function showSuccessMessage() {
        var successMessage = "Ürün güncellendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitEditProductForm() {
        $.ajax({
            url: $("#editProductForm").attr("action"),
            type: $("#editProductForm").attr("method"),
            data: $("#editProductForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#editProductForm input[name=Name]").val());

                setTimeout(function () {
                    window.location.href = "/Products/Index";
                }, 1000);
            }
        });
    }

    $("#editProductForm").submit(function (e) {
        e.preventDefault();
        submitEditProductForm();
    });
});

//DELETE
function confirmDelete() {
    Swal.fire({
        title: "Emin misiniz?",
        text: "Bu işlemi geri alamazsınız!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Evet, sil!",
        cancelButtonText: "Vazgeç"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Silindi",
                text: "Ürün başarıyla silindi.",
                icon: "success",
                timer: 1000,
                showConfirmButton: false
            });

            setTimeout(function () {
                document.getElementById("deleteForm").submit();
            }, 1000);
        }
    });
}

//function formatNumber(input) {
//    // Ondalıklı fiyat girişini uygun bir formata getirme

//    // Varsayılan kültür ayarı (örneğin, İngilizce)
//    var culture = 'en-US';

//    // Tarayıcı dilini kontrol et
//    var browserLanguage = window.navigator.language || navigator.browserLanguage;

//    // Türkçe kontrolü
//    if (browserLanguage.toLowerCase() === 'tr-tr') {
//        culture = 'tr-TR';
//    }

//    var formattedValue = parseFloat(input.value.replace(',', '.')).toLocaleString(culture, {
//        minimumFractionDigits: 2,
//        maximumFractionDigits: 2
//    });

//    input.value = formattedValue;
//}