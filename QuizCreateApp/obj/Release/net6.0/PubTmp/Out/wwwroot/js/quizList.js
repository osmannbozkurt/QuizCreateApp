




function deleteQuiz(quizId) {

    Swal.fire({
        title: 'Are you sure?',
        text: "The quiz will be permanently deleted.!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            deleteQuizConfirm(quizId);
        }
    })
}

function deleteQuizConfirm(quizId) {

    var postUrl = $("#deleteQuizUrl").val();

    showLoading();
    $.ajax({
        type: "POST",
        url: postUrl,
        data: { quizId: quizId },
        success: function (response) {
            hideLoading();
            showMessage({ title: "Quiz deleted successfully", type: "success" });

            setTimeout(function () {
                location.reload();
            }, 1000);
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