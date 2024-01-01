//CREATE
$(document).ready(function () {
    function showSuccessMessage(categoryName) {
        var successMessage = categoryName + " kategorisi eklendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitCreateCategoryForm() {
        $.ajax({
            url: $("#createCategoryForm").attr("action"),
            type: $("#createCategoryForm").attr("method"),
            data: $("#createCategoryForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#Name").val());

                setTimeout(function () {
                    window.location.href = "Index";
                }, 1000);
            }
        });
    }

    $("#createCategoryForm").submit(function (e) {
        e.preventDefault();
        submitCreateCategoryForm();
    });
});

//EDIT
$(document).ready(function () {
    function showSuccessMessage() {
        var successMessage = "Kategori güncellendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitEditCategoryForm() {
        $.ajax({
            url: $("#editCategoryForm").attr("action"),
            type: $("#editCategoryForm").attr("method"),
            data: $("#editCategoryForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#editCategoryForm input[name=Name]").val());

                setTimeout(function () {
                    window.location.href = "/Categories/Index";
                }, 1000);
            }
        });
    }

    $("#editCategoryForm").submit(function (e) {
        e.preventDefault();
        submitEditCategoryForm();
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
        cancelButtonText: "İptal Et"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Başarılı",
                text: "Kategori başarıyla silindi.",
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