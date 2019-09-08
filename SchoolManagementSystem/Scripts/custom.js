$(document).ready(function () {
    $('.select2').select2({
        allowClear: true
    });

    loadTextBoxFromSelect('PostalName', 'postalCodeText');

    $('.date-picker').datepicker({
        dateFormat: "mm/dd/yy", changeMonth: true,
        changeYear: true
    }).val('');

    $('.date-picker-edit').datepicker({
        dateFormat: "mm/dd/yy", changeMonth: true,
        changeYear: true,
        dateonly: true
    });
});


function getItemsYear(dropDownId, toUpdateDropDownId, updatingUrl) {
    itemId = $("#" + dropDownId).val();

    $.ajax
        ({
            url: updatingUrl,
            type: 'POST',
            datatype: 'application/json',
            contentType: 'application/json',
            data: JSON.stringify({
                itemId: +itemId
            }),
            success: function (result) {
                $("#" + toUpdateDropDownId).html("");
                $.each($.parseJSON(result), function (i, item) {
                    $("#" + toUpdateDropDownId).append
                        ($('<option></option>').val(item.PeriodName).html(item.PeriodName))
                })
            },
            error: function (request, status, error) {
                //alert(request.responseText);
            },
        });

}

function getItems(dropDownId, toUpdateDropDownId, updatingUrl) {
    itemId = $("#" + dropDownId).val();
    
    $.ajax
        ({
            url: updatingUrl,
            type: 'POST',
            datatype: 'application/json',
            contentType: 'application/json',
            data: JSON.stringify({
                itemId: +itemId
            }),
            success: function (result) {
                $("#" + toUpdateDropDownId).html("");
                $.each($.parseJSON(result), function (i, item) {
                    $("#" + toUpdateDropDownId).append
                        ($('<option></option>').val(item.Id).html(item.Name))
                })
            },
            error: function (request, status, error) {
                //alert(request.responseText);
            },
        });

}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#schLogo').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#schLogoId").change(function () {
    readURL(this);
});

function loadTextBoxFromSelect(selectId, textBoxId) {
    var selectText = $('#' + selectId + " option:selected").text();
    var selectValue = $('#' + selectId).val();
    $('#' + textBoxId).val('');
    $('#' + textBoxId).val(selectValue);
}

function bootboxConfirm(confirmMessage) {
    bootbox.confirm(confirmMessage, function (result) {
        return result;
    })
}

function clearSelectedData(selectId) {
    $('#' + selectId).val('');
}

function clearTextData(textId) {
    $('#' + textId).val('');
}

function deleteRecord(action, controller, Id) {
    $.ajax({
        type: "post", // here is your problem
        url: "@Url.Action(action, controller)",
        data: { id: Id },
        ajaxasync: true,
        success: function () {
            bootbox.alert("Record deleted successfully");
        },
        error: function (data) {
            bootbox.alert("Eror occured: " + data.x);
        }
    });
}
$('.calendarDelete').click(function (e) {
    id = $(this).attr('id');
    e.preventDefault();
    alert(id);
    deleteRecord("Delete", "Calendars", id);
    return false;
});