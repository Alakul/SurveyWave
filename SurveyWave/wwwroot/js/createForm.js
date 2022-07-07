changeFirstElementQuestion();
changeFirstElementsAnswer();

$(document).on('click', '#addQuestion', function () {
    var i = $(".questionRow").length;

    $.ajax({
        url: this.href + "?index=" + i,
        cache: false,
        success: function (html) {
            $("#questionRows").append(html);
            changeFirstElementQuestion();
            changeFirstElementsAnswer();
            changeIdQuestion();

            var last = $(".questionRow").length - 1;
            $('[name="Questions['+ last +'].Text').rules(
                    'add', {
                    required: true,
                    minlength: 2,
                    maxlength: 200
                }
            );
            $('[name="Questions['+ last +'].Answers[0].Text').rules(
                    'add', {
                    required: true,
                    minlength: 2,
                    maxlength: 200
                }
            );
        }
    });
    return false;
});

$(document).on('click', 'a.deleteQuestion', function () {
    $(this).parents("div.questionRow:first").remove();
    changeFirstElementQuestion();
    changeIdQuestion();
    return false;
});

$(document).on('click', '.addAnswer', function () {
    var name = $(this).parents("div.questionRow:first").attr('id');
    var qi = name.substring(name.indexOf('_') + 1, name.length);
    var i = $(this).parents("div.questionRow:first").find('.answerRows').children('.answerRow').length;
    var element = $(this).parents("div.questionRow:first").find('.answerRows');
    var type = $(this).parents("div.questionRow:first").find('.questionContent').find('.inputGroupValue');

    $.ajax({
        url: this.href + "?questionIndex=" + qi + "&index=" + i + "&type=" + type.val(),
        cache: false,
        success: function (html) {
            element.append(html);
            changeFirstElementsAnswer();

            var last = $("#question_"+qi).find('.answerRows').children('.answerRow').length - 1;
            $('[name="Questions[' + qi + '].Answers[' + last + '].Text').rules(
                    'add', {
                    required: true,
                    minlength: 2,
                    maxlength: 200
                }
            );
        }
    });
    return false;
});

$(document).on('click', 'a.deleteAnswer', function () {
    var id = $(this).parents(".questionRow:first").attr('id');
    var index = id.substring(id.indexOf('_') + 1, id.length);

    $(this).parents("div.answerRow:first").remove();
    var answers = $("#question_" + index).find(".answerRow");

    changeFirstElementsAnswer();
    changeIdAnswer(answers, index);

    return false;
});

$(document).on('click', '.questionHide', function () {
    var element = $(this).parents("div.questionRow:first").find('.questionContent');
    if (element.css("display") == 'block') {
        element.hide();
    }
    else {
        element.show();
    }
    return false;
});

$(document).on('change', '.selectType', function () {
    var value = $(this).val();
    var elements = $(this).parents("div.questionRow:first").find('.answerRows').find('.inputGroup');
    var elementValue = $(this).parents("div.questionRow:first").find('.questionContent').find('.inputGroupValue');

    if (value == 1) {
        elements.each(function (i, obj) {
            $(this).attr('type', 'radio');
            $(this).attr('value', 'Radio');
            elementValue.attr('value', 'Radio');
        });
    }
    else if (value == 2) {
        elements.each(function (i, obj) {
            $(this).attr('type', 'checkbox');
            $(this).attr('value', 'Checkbox');
            elementValue.attr('value', 'Checkbox');
        });
    }
    return false;
});

function changeFirstElementQuestion() {
    var questions = $(".questionRow").length;
    if (questions == 1) {
        $("#questionRows").find('.questionRow:first').find('.questionButtons').hide();
    }
    else if (questions > 1) {
        $("#questionRows").find('.questionRow:first').find('.questionButtons').show();
    }
}

function changeFirstElementsAnswer() {
    var elements = $(".questionRow");

    elements.each(function (i, obj) {
        var answers = $(this).find('.answerRow').length;
        var min = 2;
        if (answers == min) {
            $(this).find('.answerRow:first').find('.answerButtons').find('.deleteAnswer').hide();
            $(this).find('.answerRow:first').next().find('.answerButtons').find('.deleteAnswer').hide();
        }
        else if (answers > min) {
            $(this).find('.answerRow:first').find('.answerButtons').find('.deleteAnswer').show();
            $(this).find('.answerRow:first').next().find('.answerButtons').find('.deleteAnswer').show();
        }
    });
}

function changeIdQuestion() {
    var elements = $(".questionRow");

    elements.each(function (i, obj) {
        $(this).attr("id", "question_" + i);
        $(this).find(".questionLabel").text(i - (-1) + ".");
        $(this).find(".questions").attr("name", "Questions[" + i + "].Text");
        $(this).find(".questionSpan").attr("data-valmsg-for", "Questions[" + i + "].Text")
        $(this).find(".inputGroupValue").attr("name", "Questions[" + i + "].Type");

        changeIdAnswer($(this).find(".answerRow"), i);
    });
}

function changeIdAnswer(elements, index) {
    elements.each(function (i, obj) {
        $(this).attr("id", "answer_" + i);
        $(this).find(".answers").attr("name", "Questions[" + index + "].Answers[" + i + "].Text");
        $(this).find(".answers").attr("placeholder", "Opcja " + (i + 1));
        $(this).find(".answerSpan").attr("data-valmsg-for", "Questions[" + index + "].Answers[" + i + "].Text")
    });
}

$(document).on('click', '.questionUp', function () {
    var name = $(this).parents("div.questionRow:first").attr('id');
    var index = name.substring(name.indexOf('_') + 1, name.length);
    var indexPrevious = index - 1;

    if (indexPrevious == -1) {
        return;
    }
    else {
        $("#question_" + index).insertBefore($("#question_" + indexPrevious));
        changeIdQuestion();
    }
    return false;
});

$(document).on('click', '.questionDown', function () {
    var name = $(this).parents("div.questionRow:first").attr('id');
    var index = name.substring(name.indexOf('_') + 1, name.length);
    var indexNext = index - (- 1);

    if (indexNext > $(".questionRow").length) {
        return;
    }
    else {
        $("#question_" + indexNext).insertBefore($("#question_" + index));
        changeIdQuestion();
    }
    return false;
});

$(document).on('click', '.answerUp', function () {
    var name = $(this).parents("div.answerRow:first").attr('id');
    var index = name.substring(name.indexOf('_') + 1, name.length);
    var indexPrevious = index - 1;

    var question = $(this).parents("div.questionRow:first");

    if (indexPrevious == -1) {
        return;
    }
    else {
        question.find("#answer_" + index).insertBefore(question.find("#answer_" + indexPrevious));
        var answers = $(this).parents("div.answerRows:first").find(".answerRow");
        var id = $(this).parents(".questionRow:first").attr('id');
        var questionIndex = id.substring(id.indexOf('_') + 1, id.length);
        changeIdAnswer(answers, questionIndex);
    }
    return false;
});