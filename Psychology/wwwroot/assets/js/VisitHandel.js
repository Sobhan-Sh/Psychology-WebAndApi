const BASE_URL = "https://localhost:44321/";
const TYPE_Query = "FromQuery";

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

const Visite = (event) => {
    let consultationDay = $("#ConsultationDay");
    if (consultationDay.val().length > 0 && event.value > 0) {
        RequestAsync("Home/CheckTimeVisit", TYPE_Query, "get", `PsychologistId=${event.value}&ConsultationDay=${consultationDay.val()}`,
            (result) => {
                let li = "";
                for (let i = 0; i < result.data.length; i++) { li += `<li ${result.data[i].isVisit ? "class='visit'" : null}><input type='radio' /> از ${result.data[i].startTime} تا ${result.data[i].endTime} </li>` };
                let html = `<ul class="view-list-timevisit"><label> شنبه </label>${li}</ul> `;
                $("#viewTimeVisit").html(html);
            },
            (err) => {
                console.log(err);
            }
        );
    }
};
