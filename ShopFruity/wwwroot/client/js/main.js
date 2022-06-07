$(document).ready(function(){
  $('.product_item').mouseover(function(){
    $(this).find($('.product_item-btn')).removeClass('d-none');
  })

  $('.product_item').mouseout(function(){
    $(this).find($('.product_item-btn')).addClass('d-none');
  })
  $(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
        $('#nav').removeClass('py-3');
    } else {
        $('#nav').addClass('py-3');
    }
});
})