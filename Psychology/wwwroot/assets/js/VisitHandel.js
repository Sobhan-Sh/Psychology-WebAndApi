const BASE_URL = "https://localhost:44321/";
const TYPE_Query = "FromQuery";
const RequestAsync = (url, type, method, data) => {
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
            console.log(result);
        },
        error: (err) => {
            console.log(err);
        }
    });
};

const Visite = (event) => {
    let consultationDay = $("#ConsultationDay");
    if (consultationDay.val().length > 0 && event.value > 0) {
        RequestAsync("Home/CheckTimeVisit", TYPE_Query, "get", `PsychologistId=${event.value}&ConsultationDay=${consultationDay.val()}`);
    }
};