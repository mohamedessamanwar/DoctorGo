
    document.getElementById("addTime").addEventListener("click", function () {
    const timeInputs = document.getElementById("timeInputs");
    const newInput = document.createElement("input");
    newInput.setAttribute("name", "AppointmentTime");
    newInput.setAttribute("type", "time");
        newInput.setAttribute("class", "form-control mt-2");
    //    const newInput = `
    //     <div class="col-md-10" id="timeInputs">
    //<!-- Initial Time Input -->
    //<input name="AppointmentTime" class="form-control" type="time" />
    //</div>
        
        
    //    `
    timeInputs.appendChild(newInput);
    });
