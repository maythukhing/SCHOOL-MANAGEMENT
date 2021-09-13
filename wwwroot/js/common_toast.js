$(function () {
    
});
function showToast(errortype, msg, title) {
    var shortCutFunction = errortype;
    //var msg = "Permit balance is not enough for Payment";
    //var title = $('#title').val() || '';
    var $showDuration = 300;
    var $hideDuration = 3000;
    var $timeOut = 8000;
    var $extendedTimeOut = 1000;
    var $showEasing = "swing";
    var $hideEasing = "linear";
    var $showMethod = "fadeIn";
    var $hideMethod = "fadeOut";

    toastr.options = {
        closeButton: $('#closeButton').prop('checked'),
        debug: $('#debugInfo').prop('checked'),
        newestOnTop: $('#newestOnTop').prop('checked'),
        progressBar: $('#progressBar').prop('checked'),
        rtl: $('#rtl').prop('checked'),
        positionClass: 'toast-top-center',
        preventDuplicates: $('#preventDuplicates').prop('checked'),
        onclick: null
    };
    toastr.options.showDuration = $showDuration;
    toastr.options.hideDuration = $hideDuration;
    toastr.options.timeOut = $timeOut;
    toastr.options.extendedTimeOut = $extendedTimeOut;
    toastr.options.showEasing = $showEasing;
    toastr.options.hideEasing = $hideEasing;
    toastr.options.showMethod = $showMethod;
    toastr.options.hideMethod = $hideMethod;

    if (!msg) {
        msg = getMessage();
    }
    $('#toastrOptions').text('Command: toastr["'
        + shortCutFunction
        + '"]("'
        + msg
        + (title ? '", "' + title : '')
        + '")\n\ntoastr.options = '
        + JSON.stringify(toastr.options, null, 2)
    );
    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    $toastlast = $toast;
    if (typeof $toast === 'undefined') {
        return;
    }
    if ($toast.find('.clear').length) {
        $toast.delegate('.clear', 'click', function () {
            toastr.clear($toast, { force: true });
        });
    }
}
