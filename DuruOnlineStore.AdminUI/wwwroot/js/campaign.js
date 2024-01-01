//CREATE
$(document).ready(function () {
    function showSuccessMessage(campaignName) {
        var successMessage = campaignName + " kampanyası eklendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitCreateCampaignForm() {
        $.ajax({
            url: $("#createCampaignForm").attr("action"),
            type: $("#createCampaignForm").attr("method"),
            data: $("#createCampaignForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#Name").val());

                setTimeout(function () {
                    window.location.href = "/Campaigns/Index";
                }, 1000);
            }
        });
    }

    $("#createCampaignForm").submit(function (e) {
        e.preventDefault();
        submitCreateCampaignForm();
    });
});

//EDIT
$(document).ready(function () {
    function showSuccessMessage() {
        var successMessage = "Kampanya güncellendi.";

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1000
        });
    }

    function submitEditCampaignForm() {
        $.ajax({
            url: $("#editCampaignForm").attr("action"),
            type: $("#editCampaignForm").attr("method"),
            data: $("#editCampaignForm").serialize(),
            success: function (data) {
                showSuccessMessage($("#editCampaignForm input[name=Name]").val());

                setTimeout(function () {
                    window.location.href = "/Campaigns/Index";
                }, 1000);
            }
        });
    }

    $("#editCampaignForm").submit(function (e) {
        e.preventDefault();
        submitEditCampaignForm();
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
                text: "Kampanya başarıyla silindi.",
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