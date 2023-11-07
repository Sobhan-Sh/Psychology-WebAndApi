var inputfile = document.querySelector(".input-div input");
var input_div_span = document.querySelector(".input-div span");
var input_div = document.querySelector(".input-div");
inputfile.addEventListener("change", (e) => {
  console.log(e.target.files.length);
  if (e.target.files.length > 0) {
    input_div_span.classList.add("notEmpty");
    input_div_span.innerHTML = "عکس انتخاب شد";
  } else {
    input_div_span.innerHTML = "انتخاب اواتار";
    input_div_span.classList.remove("notEmpty");
  }
});
