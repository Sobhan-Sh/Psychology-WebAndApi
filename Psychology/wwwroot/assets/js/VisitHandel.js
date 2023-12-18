const BASE_URL = "https://localhost:44321/";
const IS_INVALID = "inValid";
const TYPE_Query = "FromQuery";
let ViewTimeVisit = $("#viewTimeVisit");
let ViewListPsychologist = $("#viewListPsychologist");
let TagFormSetVisit = document.getElementById("FormSetVisit");
let DateTimeVisit = $("#DateTimeVisit");
let PsychologistId;
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
                let html = `<select class="selectMy cusotm-form-controle" name="PsychologistId" id="PsychologistId" onchange="GetTimesVisit()"><option value="null"> روانشناس خود را انتخاب کنید </option>`;
                for (let i = 0; i < result.data.length; i++)
                    html += `<option value="${result.data[i].id}"> ${result.data[i].tagSelectFullName} </option>`;
                html += "</select>";
                ViewListPsychologist.html(html);
                PsychologistId = $("#PsychologistId");
            },
            (err) => {
                console.log(err);
            }
        );
    else
        Empty(TagInfoArray[2])
};
const GetTimesVisit = () => {
    if (DateTimeVisit.val().length > 0 && PsychologistId.val() > 0) {
        RequestAsync("Home/CheckTimeVisit", TYPE_Query, "get", `PsychologistId=${PsychologistId.val()}&ConsultationDay=${DateTimeVisit.val()}`,
            (result) => {
                if (result.success === true) {
                    Swal.fire({
                        title: "توجه",
                        text: result.message,
                        icon: "warning",
                        confirmButtonText: "فهمیدم"
                    });
                    let li = "";
                    for (let i = 0; i < result.data.length; i++) { li += `<li ${result.data[i].isVisit ? "class='visit' disabled" : ""}><input type='radio' name="TimeId" value="${result.data[i].id}" /> از ${result.data[i].startTime} تا ${result.data[i].endTime} <span></span></li>` };
                    let html = `<ul class="view-list-timevisit"><label> ${result.data[0].day} </label>${li}</ul> `;
                    ViewTimeVisit.html(html);
                } else
                    console.log(result)
            },
            (err) => console.log(err)
        );
    }
};

const ValidationForm = () => {
    let Name = $("#Name");
    let Phone = $("#Phone");
    let TypeOfConsultationId = $("#TypeOfConsultationId");
    let TimeId = $(".view-list-timevisit li input[name=TimeId]:checked");
    if (Name.val().length > 0 && Phone.val().length > 0 && TypeOfConsultationId.val() > 0 && PsychologistId.val() > 0 && DateTimeVisit.val().length > 0 && TimeId.val() > 0) return true;
    else {
        if (Name.val().length < 1) Name.addClass(IS_INVALID);

        if (Phone.val().length < 1) Phone.addClass(IS_INVALID);

        if (TypeOfConsultationId.val() < 1) TypeOfConsultationId.addClass(IS_INVALID);

        if (PsychologistId.val() < 1) PsychologistId.addClass(IS_INVALID);

        if (DateTimeVisit.val().length < 1) DateTimeVisit.addClass(IS_INVALID);

        if (TimeId.val() < 1) TimeId.addClass(IS_INVALID);

        let inValidInput = document.querySelectorAll("." + IS_INVALID);
        if (inValidInput.length > 0)
            inValidInput.forEach(item => {
                item.onchange = (event) => {
                    if (event.target.value.length > 0)
                        event.target.classList.remove(IS_INVALID);
                }
            });

        return false;
    }
};

const FormSetVisit = (event) => {
    event.preventDefault();
    if (ValidationForm())
        TagFormSetVisit.submit();
}

const SetVisit = () => {
    if (ValidationForm())
        TagFormSetVisit.submit();
}
