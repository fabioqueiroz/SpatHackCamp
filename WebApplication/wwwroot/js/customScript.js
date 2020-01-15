//todo
//refactor this 
const highlightColor = "#A6E08E";
const table = document.getElementById("form-table");
if (table != null) {
    const allHiddenInputs = table.getElementsByClassName("input-hidden");
    const allRows = table.getElementsByTagName("tr");
    if (allRows !== null) {
        for (let i = 0; i < allRows.length; i++) {
            let rubricsForCurrentRow = allRows[i].getElementsByClassName("rubric-item");
            for (let j = 0; j < rubricsForCurrentRow.length; j++) {
                rubricsForCurrentRow[j].addEventListener('click', () => {
                    highlightRubric(rubricsForCurrentRow[j],
                        rubricsForCurrentRow);
                    allHiddenInputs[0].value = j;
                })
            }
        }
    }
    //attach listeners to all columns 
}

function highlightRubric(rubric, allRubricsOnRow) {
    //de highlight the other rubrics 
    for (let i = 0; i < allRubricsOnRow.length; i++) {
        allRubricsOnRow[i].style.background = ""
    }
    rubric.style.background = highlightColor;
}

function areLoginDetailsValid() {
    return true;
}

var options = [];

function areFieldsValueValid() {
    var inputName = document.getElementById("firstNameInputUser").value;
    var inputSurname = document.getElementById("lastNameInputUser").value;
    var inputGender = document.getElementById("inputGender").value;
    var inputDofB = document.getElementById("dateOfBirthInputUser").value;
    var inputMail = document.getElementById("emailInputUser").value;
    var inputAddress = document.getElementById("inputAddress").value;
    var inputCity = document.getElementById("inputCity").value;
    var inputCountry = document.getElementById("inputCountry").value;
    var inputPostCode = document.getElementById("inputPostCode").value;

    if (inputName.trim() == '') {
        sendError("Please Enter Your Name!");
        return false;
    } else if (inputSurname.trim() == '') {
        sendError("Please Enter Your Last Name!");
        return false;
    } else if (inputGender.trim() == 'Gender') {
        sendError("Please Enter Your Gender!");
        return false;
    } else if (inputDofB.trim() == '') {
        sendError("Please Enter Your Date of Birth!");
        return false;
    } else if (inputMail.trim() == '') {
        sendError("Please Enter Your E-mail!");
        return false;
    } else if (inputAddress.trim() == '') {
        sendError("Please Enter Your Address!");
        return false;
    } else if (inputCity.trim() == '') {
        sendError("Please Enter Your City!");
        return false;
    } else if (inputCountry.trim() == '') {
        sendError("Please Enter Your Country!");
        return false;
    } else if (inputPostCode.trim() == '') {
        sendError("Please Enter Your Post Code!");
        return false;
    } else {
        return true;
    }
}

function sendError(errorMessage) {
    var error = document.getElementById("errorMessage");
    error.innerText = errorMessage;
    document.getElementById("errorMessage").style.visibility = "visible";
}

function isChangePasswordModalValid() {
    let passwordField1 = document.getElementById("confirmPasswordField");
    let passwordField2 = document.getElementById("confirmPasswordField2");
    let alert = document.getElementsByClassName("alert alert-danger")[0];
    if (passwordField1.value.trim() === "") {
        alert.style.visibility = "visible";
        alert.innerText = "You must enter a password";
        return false;
    }
    if (passwordField2.value.trim() === "") {
        alert.style.visibility = "visible";
        alert.innerText = "You must confirm your password";
        return false;
    }
    if (passwordField1.value.trim() !== passwordField2.value.trim()) {
        alert.style.visibility = "visible";
        alert.innerText = "The passwords must match";
        return false;
    }
    return true;
}


