
var activeExamIndex = 0;
var examData = [];
let characters = ["A", "B", "C", "D"];
var selectedOptions = [];


function selectExamList() {
    showLoading();

    var url = $("#selectAllExamId").val();

    $.ajax({
        type: "GET",
        url: url,
        data: {},
        success: function (response) {
            hideLoading();
            examData = response;
            fillQuestionList();
        },
        failure: function (response) {
            hideLoading();
            showMessage({ title: response.responseText, type: "error" });

        },
        error: function (response) {
            hideLoading();
            showMessage({ title: response.responseText, type: "error" });
        }
    });

}
function fillQuestionList() {

    if (examData.length == 0) {
        $("#examcontainer").html("There is no exam yet.");
        $("#completequizbutton").hide();

        return;
    }

    var activeExam = examData[activeExamIndex];

    var questionHtml = "";
    for (var i = 0; i < activeExam.questionList.length; i++) {

        var question = activeExam.questionList[i];
        var questionId = "question-" + question.questionId;
        var optionStr = "";
        for (var j = 0; j < question.optionList.length; j++) {
            var option = question.optionList[j];
            var optionId = questionId + "-option-" + option.optionchar
            optionStr = optionStr + `
                <div class="option" id="${optionId}" data-optionchar="${option.optionchar}" onclick="onselectoption(${question.questionId}, '${optionId}')">
                        ${option.optionchar} :) ${option.text}
                </div>
            `
        }
        questionHtml = questionHtml + `
         <div class="col-6 p-2">
                <p>
                    ${i+1}) ${question.questionText}
                </p>
               ${optionStr}
         </div>
        `
    }



    var fullHtml = `
<div class=" mb-3 mt-4">
      
        <div class="text-center font-weight-bold text-lg">
              ${activeExam.blogTitle}
        </div>
      
    </div>
    <div class="input-group mb-3">
 
        <div id="blog-content" class="blog-content">
            ${activeExam.blogDescription}
        </div>
    </div>
    <div id="question-area" class="row">
        ${questionHtml}
    </div>
        `
    $("#examcontainer").html(fullHtml);

}
selectExamList();

function addNextPrevSection() {


    if (examData.length>1) {

    }
}


function onselectoption(questionId, optionId) {


    for (var i = 0; i < characters.length; i++) {
        var prevOption = "question-"+ questionId + "-option-" + characters[i];
        $("#" + prevOption).removeClass("option-selected");
    }
    var otherIndex = selectedOptions.findIndex(s => s.questionId == questionId);
    if (otherIndex != -1) {
        selectedOptions.splice(otherIndex, 1);
    }
    var optionChar = $("#" + optionId).attr("data-optionchar");
    selectedOptions.push({ 
        questionId: questionId,
        optionChar: optionChar
    });

    $("#" + optionId).addClass("option-selected");
}

function completeExam() {

    if (selectedOptions.length == 0) {
        Swal.fire('no question has been resolved');
        return;
    }

    showLoading();

    var url = $("#completeExamurlId").val();
    var quizId = examData[activeExamIndex].quizId;
    var params = {
        quizId: quizId,
        solvedList: selectedOptions
    }

    $.ajax({
        type: "POST",
        url: url,
        data: params, 
        success: function (response) {
            hideLoading();
            onExamResult(response.data);
        },
        failure: function (response) {
            hideLoading();
            showMessage({ title: response.responseText, type: "error" });

        },
        error: function (response) {
            hideLoading();
            showMessage({ title: response.responseText, type: "error" });
        }
    });
}

function onExamResult(data) {

    /*
    correctOption: "D"
isCorrect: false
questionId: 6
     */

    for (var i = 0; i < data.length; i++) {
        const element = data[i];
        var optionId = "question-" + element.questionId + "-option-" + element.selectedOption;
        var classname = "wrong-answer";
        if (element.isCorrect) {
            classname = "correct-answer";
        }  
        $("#" + optionId).addClass(classname);

    }
}


function goToPrevExam() {

    selectedOptions = [];
    if (activeExamIndex<=0) {

        return;
    }
    activeExamIndex--;
    fillQuestionList();
}
function goToNextExam() {

    selectedOptions = [];

    if (examData.length <= activeExamIndex-1) {

        return;
    }

    activeExamIndex++;
    fillQuestionList()
}