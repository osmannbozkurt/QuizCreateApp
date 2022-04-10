const geturi = 'getItems';
let latestBlogList = [];
var questionList = [];
let characters = ["A", "B", "C", "D"];

function fillQuestionList() {


    for (var i = 0; i < 4; i++) {
        let questionId = "question-" + i;
        let correctOptionId = "question-" + i + "-correctoption";
       
        let options = [];
        var optionhtml = "";
        for (var j = 0; j < 4; j++) {
            let optionId = questionId + "-option-" + j;
            let optionChar = characters[j];
            options.push({
                optionId: optionId,
                optionChar: optionChar
            });

            optionhtml = optionhtml + `
             <div class="col-6 mb-2">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" >${optionChar}</span>
                    </div>
                    <input type="text" id="${optionId}" class="form-control " />
                </div>
            </div>
            `
        }
        questionList.push({
            questionId: questionId,
            correctOptionId: correctOptionId,
            optionList: options
        });
        $("#question-area").append(`
        <div class="input-group mb-3 row">
            <div class="col-12 mb-2">
                <textarea id="${questionId}" class="form-control" placeholder="Question ${(i + 1)}"></textarea>
            </div>
            ${optionhtml}

         <div class="input-group">
          <select id="${correctOptionId}"  class="form-control text-center">
         
                     <option disabled selected value="">Choose the correct answer</option>
                     <option value="A">A</option>
                     <option value="B">B</option>
                     <option value="C">C</option>
                     <option value="D">D</option>
                 </select>
         </div>

        </div>
        `);
    }
}
fillQuestionList();

function getItems() {

    var url = $("#blogselectApi").val();

    showLoading();

    $.ajax({
        type: "GET",
        url: url,
        data: {},
        success: function (response) {
            hideLoading();
            _displayItems(response);
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

function _displayItems(result) {
    hideLoading();


    latestBlogList = result.data;

    latestBlogList.forEach(item => {
        $('#blogTitleSelect').append($('<option/>', {
            value: item.newsTitle,
            text: item.newsTitle
        }));
    });

}
getItems();


function ontitlechange() {

    var selected = $("#blogTitleSelect").val();
    var desc = getBlogDescription(selected);
    $("#blog-content").html(desc);
}

function getBlogDescription(blogtitle) {

    var selectedIndex = latestBlogList.findIndex(w => w.newsTitle == blogtitle);

    return latestBlogList[selectedIndex].newsContent;
}



function onPostQuestion() {
    var selectedTitle = $('#blogTitleSelect').val();
    let questionListForPost = [];

    for (var i = 0; i < questionList.length; i++) {
        let questionId = questionList[i].questionId;
        let correctOptionId = questionList[i].correctOptionId;
 
        let questionText = $('#' + questionId).val();
        let correctOption = $('#' + correctOptionId).val();
        if (!questionText || !correctOption) {
            alert("please fill in all required fields.");
            return;
        }

        let optionList = questionList[i].optionList;

        let optionTextList = [];
        for (var j = 0; j < optionList.length; j++) {
            let optionId = questionId + "-option-" + j;
            let optionText = $('#' + optionId).val();

            if (!optionText) {
                alert("please fill in all required fields.");
                return;
            }

            optionTextList.push({
                optionText: optionText,
                optionChar: optionList[j].optionChar
            });
        }

        questionListForPost.push({
            questionText: questionText,
            correctOption: correctOption,
            optionList: optionTextList
        });
    }
    var blogDesc = getBlogDescription(selectedTitle);

    var params = {
        blogTitle: selectedTitle,
        blogDescription: blogDesc,
        questionList: questionListForPost
    }
    var postUrl = $("#quizPosturl").val();

    showLoading();
    $.ajax({
        type: "POST",
        url: postUrl,
        data: params,
        success: function (response) {
            hideLoading();
            showMessage({ title: "Quiz created successfully", type: "success" });

            setTimeout(function () {
                var returnUrl = $("#homePageUrl").val();
                window.location.href = returnUrl;
            }, 2000);
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

