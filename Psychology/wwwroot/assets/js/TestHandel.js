const DeleteTest = (testId, code) => {
    Swal.fire({
        title: "؟از حذف این ازمون مطمئن هستید",
        text: "توجه داشته باشید با این کار سوالات و جواب های ان نیز پاک می شود!",
        icon: "warning",
        showCancelButton: true,
        cancelButtonText: "نه اشتباه شد!",
        confirmButtonText: "اوکی ,حذف کن",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "delete",
                data: {
                    "testId": testId
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