/*  ---------------------------------------------------
Template Name: Ashion
Description: Ashion ecommerce template
Author: Colorib
Author URI: https://colorlib.com/
Version: 1.0
Created: Colorib
---------------------------------------------------------  */

'use strict';

(function ($) {

    /*-------------------
		Quantity change
	--------------------- */

    function updatePrice($container, productId, quantity) {
        $.ajax({
            url: '/Cart/SetQuantity',
            type: 'POST',
            data: { id: productId, quantity: quantity },
            success: function (result) {
                if (result.success && result.updatedPrice !== undefined && result.totalItemCount !== undefined) {
                    var priceElement = $('.cart__price[data-itemid="' + productId + '"]');
                    priceElement.text('₺ ' + result.updatedPrice.toFixed(2));
                    $('.cart-item-count').text(result.totalItemCount);
                }
            },
            error: function (error) {
                console.error('Bir hata oluştu: ' + error.responseText);
            }
        });
    }

    $(document).ready(function () {
        var proQty = $('.pro-qty');
        proQty.prepend('<span class="dec qtybtn">-</span>');
        proQty.append('<span class="inc qtybtn">+</span>');
        proQty.on('click', '.qtybtn', function () {
            var $button = $(this);
            var oldValue = $button.parent().find('input').val();
            if ($button.hasClass('inc')) {
                var newVal = parseFloat(oldValue) + 1;
            } else {
                if (oldValue > 0) {
                    var newVal = parseFloat(oldValue) - 1;
                } else {
                    newVal = 0;
                }
            }
            $button.parent().find('input').val(newVal);

            // Fiyat güncelleme fonksiyonunu çağır
            var productId = $button.closest('.pro-qty').data('itemid');
            updatePrice($button.closest('.pro-qty'), productId, newVal);

            // Sayfayı yenile
            location.reload();
        });
    });
    
    /*-------------------
		Radio Btn
	--------------------- */
    $(".size__btn label").on('click', function () {
        $(".size__btn label").removeClass('active');
        $(this).addClass('active');
    });

})(jQuery);