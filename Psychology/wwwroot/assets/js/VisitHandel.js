const BASE_URL = "https://localhost:44321/";
const TYPE_Query = "FromQuery";
let ViewTimeVisit = $("#viewTimeVisit");
let ViewListPsychologist = $("#viewListPsychologist");
let consultationDay = $("#ConsultationDay");

let TagInfoArray = ["ViewTimeVisit", "ViewListPsychologist", "ViewTimeVisitViewListPsychologist"];
const RequestAsync = (url, type, method, data, successCallback, errorCallback) => {
    switch (type) {
        case "FromQuery":
            url = url + "?" + data;
            break;
    }

    $.ajax({
        url: BASE_URL + url,
        method: method,
        data: data,
        success: (result) => {
            if (successCallback) {
                successCallback(result);
            }
        },
        error: (err) => {
            if (errorCallback) {
                errorCallback(err);
            }
        }
    });
};

const Empty = (tagInfo) => {
    switch (tagInfo) {
        case TagInfoArray[0]: {
            ViewTimeVisit.html("");
            break;
        }
        case TagInfoArray[1]: {
            ViewListPsychologist.html("");
            break;
        }
        case TagInfoArray[2]: {
            ViewTimeVisit.html("");
            ViewListPsychologist.html("");
            break;
        }
    }
}

const GetPsychologist = (event) => {
    if (event.value > 0)
        RequestAsync("Home/GetPsychologist", TYPE_Query, "get", `TOCId=${event.value}`,
            (result) => {
                Empty(TagInfoArray[0]);
                let html = `<select class="selectMy cusotm-form-controle" id="listPsychologist" onchange="GetTimesVisit()"><option value="null"> روانشناس خود را انتخاب کنید </option>`;
                for (let i = 0; i < result.data.length; i++)
                    html += `<option value="${result.data[i].id}"> ${result.data[i].tagSelectFullName} </option>`;
                html += "</select>";
                ViewListPsychologist.html(html);
            },
            (err) => {
                console.log(err);
            }
        );
    else
        Empty(TagInfoArray[2])
};
const GetTimesVisit = () => {
    let listPsychologist = $("#listPsychologist");
    if (consultationDay.val().length > 0 && listPsychologist.val() > 0) {
        RequestAsync("Home/CheckTimeVisit", TYPE_Query, "get", `PsychologistId=${listPsychologist.val()}&ConsultationDay=${consultationDay.val()}`,
            (result) => {
                if (result.success === true) {
                    Swal.fire({
                        title: "توجه",
                        text: result.message,
                        icon: "warning",
                        confirmButtonText: "فهمیدم"
                    });
                    console.log(result)
                    let li = "";
                    for (let i = 0; i < result.data.length; i++) { li += `<li ${result.data[i].isVisit ? "class='visit' disabled" : ""}><input type='radio' name="timeVisit" value="${result.data[i].id}" /> از ${result.data[i].startTime} تا ${result.data[i].endTime} <span></span></li>` };
                    let html = `<ul class="view-list-timevisit"><label> ${result.data[0].day} </label>${li}</ul> `;
                    ViewTimeVisit.html(html);
                } else
                    console.log(result)
            },
            (err) => console.log(err)
        );
    }
};

const SetVisit = () => {
    let FName = $("#PsychologistWorkingDateAndTimeViewModel_PsychologistViewModel_UserViewModel_FName");
    let Phone = $("#PsychologistWorkingDateAndTimeViewModel_PsychologistViewModel_UserViewModel_Phone");
    let TypeOfConsultation = $("#PsychologistWorkingDateAndTimeViewModel_PsychologistViewModel_Id");
    let ListPsychologist = $("#listPsychologist");
    let Time = $(".view-list-timevisit li input[name=timeVisit]:checked");
    if (FName.val().length > 0 && Phone.val().length > 0 && consultationDay.val().length > 0 && TypeOfConsultation.val() > 0 && ListPsychologist.val() > 0 && Time.val() > 0) {
        RequestAsync("Home/SetVisit", TYPE_Query, "get", `Name=${FName.val()}&Phone=${Phone.val()}&TypeOfConsultationId=${TypeOfConsultation.val()}&PsychologistId=${ListPsychologist.val()}&TimeId=${Time.val()}&DateTimeVisit=${consultationDay.val()}`,
            (result) => {
                if (result.success === true) {
                    Swal.fire({
                        title: "توجه",
                        text: result.message,
                        icon: "warning",
                        confirmButtonText: "فهمیدم"
                    });
                    
                } else
                    console.log(result)
            },
            (err) => console.log(err)
        );
    }
};