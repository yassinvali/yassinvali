$(function () {
    showButton(0);
    $('#forward').click(function () {

        if ($('#QuestionNumber').val() == undefined) {
            var _id = parseInt(1);
            getpreviousQuestionOption(_id + 1);
            var age = parseInt($('#Age').val());
            var gendar = parseInt($('#Gendar').val());
            var workExperience = parseInt($('#WorkExperience').val());
            var currentWorkExperience = parseInt($('#CurrentWorkExperience').val());
            var education = parseInt($('#Education').val());
            var position = parseInt($('#Position').val());

            $.ajax({
                type: "POST",
                url: '../home/RegisterUserInfo',
                data: {
                    Gendar: gendar,
                    Age: age,
                    WorkExperience: workExperience,
                    CurrentWorkExperience: currentWorkExperience,
                    Education: education,
                    Position: position
                },
                success: function (result) {
                    $('#middle-wizard').html(result);
                    showButton(_id + 1);
                },
                error: function () {
                    $('#middle-wizard').html('خطا ، اطلاعات با خطا روبرو شده است');
                }
            });

        } else {
            var _id = parseInt($('#QuestionNumber').val());
            forward(_id);
            showButton(_id + 1);
            getpreviousQuestionOption(_id + 1);
        }
    })

    $('#backward').click(function () {
        var _id = parseInt($('#QuestionNumber').val());
        backward(_id);
        showButton(_id - 1);
        getpreviousQuestionOption(_id - 1);
    })

    $('#process').click(function () {
        process();
    })

    function forward(qId) {

        var _val = -1;
        if ($(".iradio_square-grey").hasClass("checked")) {
            _val = $(".iradio_square-grey > input:checked").val();
        }
        $.ajax({
            type: "GET",
            url: '../Home/Forward',
            data: { questionId: qId, answerId: _val },
            success: function (result) {
                $('#middle-wizard').html(result);
            },
            error: function () {
                console.log('error')
            }

        })
    }

    function backward(qId) {
        $.ajax({
            type: "GET",
            url: '../home/Backward',
            data: { questionId: qId },
            success: function (result) {
                $('#middle-wizard').html(result);
            },
            error: function () {
                console.log('error')
            }
        })
    }

    function showButton(pageNumber) {
        $('#backward').hide();
        $('#forward').show();
        $('#process').hide();

        if (pageNumber > 0 && pageNumber < 113) {
            $('#backward').show();
        }
        if (pageNumber >= 112) {
            $('#forward').hide();
            $('#backward').hide();
            $('#process').show()
        }
    }

    function process() {
        var age = parseInt($('#Age').val());
        var gendar = parseInt($('#Gendar').val());
        var workExperience = parseInt($('#WorkExperience').val());
        var currentWorkExperience = parseInt($('#CurrentWorkExperience').val());
        var education = parseInt($('#Education').val());
        var position = parseInt($('#Position').val());

        $.ajax({
            type: "POST",
            url: '../home/Process',
            data: {
                Gendar: gendar,
                Age: age,
                WorkExperience: workExperience,
                CurrentWorkExperience: currentWorkExperience,
                Education: education,
                Position: position
            },
            success: function (result) {
                $('#middle-wizard').html(result);
            },
            error: function () {
                $('#middle-wizard').html('خطا ، اطلاعات با خطا روبرو شده است');
            }
        });
        $('#backward').hide();
        $('#forward').hide();
        $('#process').hide();
    }

    function getpreviousQuestionOption(qid) {
        $('.iradio_square-grey').removeClass('checked');

        $.ajax({
            type: "GET",
            url: '../home/GetSelectedOption',
            data: { questionNumber: qid },
            success: function (result) {
                if (result != -1) {
                    $('.radion-continer .radio_input').each(function (item) {

                        if (item == parseInt(result)) {
                            $.each($(".icheck"), function (ke, value) {
                                if (ke == parseInt(result)) {
                                    $(this).parent().addClass('checked')
                                };
                            });
                        }
                    })
                }
            },
            error: function () {
                console.log('error')
            }

        })
    }
})