$(window).on("load", function () {
    $.validator.messages.required = 'To pole jest wymagane.';
    $.validator.messages.minlength = jQuery.validator.format("Proszę podać przynajmniej {0} znaki.");
    $.validator.messages.maxlength = jQuery.validator.format("Proszę podać nie więcej niż {0} znaków.");

    var dateMin = new Date();
    dateMin.setDate(dateMin.getDate() - 1);

    $('#create').validate({
        errorElement: 'small',
        errorClass: 'questionSpan text-danger field-validation-valid',
        rules: {
            'Survey.Title': {
                required: true,
                minlength: 2,
                maxlength: 200
            },
            'Survey.Description': {
                required: true,
                minlength: 2,
                maxlength: 200
            },
            'Survey.StartDate': {
                required: true,
                min: dateMin.toISOString()
            },
            'Survey.EndDate': {
                required: true,
                min: dateMin.toISOString()
            }
        },
        messages: {
            'Survey.StartDate': {
                min: "Proszę wprowdzić większą datę otwarcia."
            },
            'Survey.EndDate': {
                min: "Proszę wprowdzić większą datę zamknięcia."
            }
        },
    });

    var questions = $(".questionRow").length;
    for (var i = 0; i < questions; i++) {
        $('[name="Questions[' + i + '].Text"]').rules(
                'add', {
                required: true,
                minlength: 2,
                maxlength: 200
            }
        );

        var answers = $("#question_" + i).find('.answerRow').length;
        for (var j = 0; j < answers; j++) {
            $('[name="Questions[' + i + '].Answers[' + j + '].Text').rules(
                    'add', {
                    required: true,
                    minlength: 2,
                    maxlength: 200
                }
            );
        }
        
    }
});

$(document).on('change', '#startDate', function () {
    CheckDate();
    return false;
});

$(document).on('change', '#endDate', function () {
    CheckDate();
    return false;
});

function CheckDate() {
    var selectedDate = $("#endDate").val();
    var startDate = $("#startDate").val();

    if (selectedDate < startDate) {
        $("#endDate").rules('remove', 'min');
        $("#endDate").rules(
                'add', {
                min: startDate,
                messages: { min: "Proszę wprowdzić datę większą lub równą dacie otwarcia." }
            }
        );
    }
}