document.addEventListener("DOMContentLoaded", function () {
  const timetableButton = document.getElementById("timetableButton");
  const timeTableSection = document.getElementById("timeTable");
  const mobileAppSection = document.getElementById("mobileApp");

  // Toggle visibility of TimeTable section
  timetableButton.addEventListener("click", function () {
    timeTableSection.classList.toggle("d-none");
    mobileAppSection.classList.add("d-none");
  });
});
