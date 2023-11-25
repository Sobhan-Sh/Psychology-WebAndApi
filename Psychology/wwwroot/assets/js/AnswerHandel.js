// query dom
const ListAnswer = () => {
    return document.querySelectorAll(".listAnswer");
}
let viewAnswer = document.querySelector(".viewAnswer");
let answerId = 1;
// create element in (answer)
const addAnswer = () => {
    let score = document.querySelector(".scoreInput");
    let answer = document.querySelector(".answerInput");
    if (score.value != null && answer.value != null) {
        if (score.value !== "" && answer.value !== "")
            $.ajax({
                type: "put",
                data: {
                    "Id": answerId,
                    "Title": answer.value,
                    "Score": score.value
                },
                success: (res) => {
                    if (res.success) {
                        viewAnswer.innerHTML += `<li class="listAnswer list-group-item list-group-item-action s${answerId + 1}"> ${answer.value}<br> ${score.value} <button type="button" class="btn btn-danger btn-sm" onclick="removeAnswer('s${answerId + 1}',${answerId})"> حذف جواب </button></li> `;
                        ListAnswer().length > 1 ? $("#next").removeClass("d-none") : $("#next").addClass("d-none");
                        score.value = "";
                        answer.value = "";
                        answerId++;
                    } else {
                        alert("عملیات با شکست مواجه شد");
                    }
                }
            });
    }
}
// remove answer
const removeAnswer = (code, id) => {
    $.ajax({
        type: "delete",
        data: {
            "answerId": id
        },
        success: (res) => {
            if (res.success) {
                document.querySelector(`.${code}`).remove();
                ListAnswer().length < 2 ? $("#next").addClass("d-none") : $("#next").removeClass("d-none");
            } else {
                alert("عملیات با شکست مواجه شد");
            }
        }
    });
}
// Control button enter
$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});

const DeleteAnswer = (code, answerId, testId) => {
    Swal.fire({
        title: "از حذف این جواب مطمئن هستید",
        showCancelButton: true,
        cancelButtonText: "نه اشتباه شد!",
        confirmButtonText: "اوکی ,حذف کن",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "delete",
                data: {
                    "testId": testId,
                    "answerId": answerId
                },
                success: (res) => {
                    if (res.success) {
                        Swal.fire(res.message, "", "success");
                        document.querySelector("." + code).remove();
                    } else {
                        Swal.fire(res.message, "", "error");
                    }
                }
            });
        }
    });
}