//const RemoveQuestion = (code) => {
//    debugger;
//    document.querySelector(`#${code}`).remove();
//    if (CheckQuestion().length == 0)
//        document.getElementById("questionView").classList.add("d-none");
//}


const RemoveQuestion = (questionId, testId, code) => {
    Swal.fire({
        title: "؟از حذف این سوال مطمئن هستید",
        showCancelButton: true,
        cancelButtonText: "نه اشتباه شد!",
        confirmButtonText: "اوکی ,حذف کن",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "delete",
                data: {
                    "testId": testId,
                    "questionId": questionId
                },
                success: (res) => {
                    if (res.success) {
                        Swal.fire(res.message, "", "success");
                        $("." + code).hide('slow');
                    } else {
                        Swal.fire(res.message, "", "error");
                    }
                }
            });
        }
    });
}

const DeleteQuestion = (Id, code) => {
    debugger;
    var myHeaders = new Headers();
    myHeaders.append("Accept", "text/plain");
    myHeaders.append("Authorization", "{{apiKey}}");

    var requestOptions = {
        method: 'DELETE',
        headers: myHeaders,
        redirect: 'follow'
    };

    fetch("/Admin/PsychologicalTests/DeleteQuestion?questionId=" + Id, requestOptions)
        .then(response => response.text())
        .then(res => {
            let respons = JSON.parse(res);
            if (respons.success == true) {
                $("body").append(`<diva class="toast-container position-fixed bottom-0 end-0 p-3"><div class="toast fade show border border-success" role="alert" aria-live="assertive" aria-atomic="true"><div class="toast-header border-success"><strong class="me-auto text-success"> نتیجه </strong><button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button></div><div class="toast-body">${respons.message}</div></div></div>`);
                document.querySelector(`#${code}`).remove();
            }
            else
                $("body").append(`<div class="toast-container position-fixed bottom-0 end-0 p-3"><div class="toast fade show border border-danger" role="alert" aria-live="assertive" aria-atomic="true"><div class="toast-header border-danger"><strong class="me-auto text-danger"> خطا </strong><button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button></div><div class="toast-body">${respons.message}</div></div></div>`);

        })
        .catch(error => console.log('error', error));
}

