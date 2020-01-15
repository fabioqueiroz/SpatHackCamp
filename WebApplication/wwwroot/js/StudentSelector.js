//stack of the students
let currentlySelectedStudents = [];
const maxNumberOfStudent = 6;
let numberOfStudentCounter = document.getElementById("counterNumberStudents");
let container = document.getElementById("container-selectors");
let listItems = document.getElementsByClassName("custom-select studentItems")[0];
let alert = document.getElementsByClassName("alert")[0];
//this variable dictates weather the add button will function or not 
let errorActive = false;
let previousValue;

function storeCurrentValue(value) {
    previousValue = value;
    console.log(value);
}

function addStudentItem() {
    //if there are more than 5 students already selected 
    //don't allow further insertion
    if (currentlySelectedStudents.length < 6) {
        hideErrorMessage();
        //get the length of the container elements and insert a 
        //proper name for the form
        let newListItems = listItems.cloneNode(true);
        newListItems.style.marginTop = "10px";
        newListItems.name = "selectedStudent" + (container.children.length);
        container.append(newListItems);
    } else {
        displayErrorMessage("You already reached the maximum number of students in a group");
    }
}

function displayErrorMessage(message) {
    let alert = document.getElementsByClassName("alert")[0];
    alert.style.visibility = "visible";
    alert.innerText = message;
    errorActive = true;
}

/**
 * This function needs to be called every time we successfully
 * completed an operation
 */
function hideErrorMessage() {
    alert.style.visibility = "hidden";
    alert.innerText = "";
    errorActive = false;
}

/**
 * Update the counter with the current number of students
 * in the list
 */
function updateCounter() {
    numberOfStudentCounter.innerText = currentlySelectedStudents.length + "/" + maxNumberOfStudent;
}

function removeStudentFromList() {
    //don't allow item removal if the length is
    //not bigger than 2
    if (container.children.length > 2) {
        hideErrorMessage();
        removeElementFromView();
        let numberOfStudentsHiddenField = document.getElementById("numberOfStudents");
        numberOfStudentsHiddenField.value = container.children.length - 1;
        updateCounter();
    }
}

function removeElementFromView() {
    container.removeChild(container.lastChild);
    currentlySelectedStudents.pop();
}

function selectStudent(studentId, selector) {
    //hide the error message when a new selection is made
    hideErrorMessage();
    //check if the element is already in the list or not
    currentlySelectedStudents.forEach(element => {
        if (element === studentId) {
            //modify border style so that it shows the user the error
            selector.style.borderColor = "red";
            selector.style.borderWidth = "2px";
            displayErrorMessage("You already selected this student!");
        }
    });
    //if the element is not in the list, insert it in the end
    if (errorActive === false) {
        //replace the previous value if available 
        if (currentlySelectedStudents.indexOf(previousValue) !== -1) {
            currentlySelectedStudents[currentlySelectedStudents.indexOf(previousValue)] = studentId;
        } else {
            currentlySelectedStudents.push(studentId);
        }
        unfocusSelector(selector);
        hideErrorMessage();
        updateCounter();
        //update the hidden field
        let numberOfStudentsHiddenField = document.getElementById("numberOfStudents");
        //minus 1 because of the hidden field counts as a child
        numberOfStudentsHiddenField.value = container.children.length - 1;
    }
}

function unfocusSelector(selector) {
    selector.blur();
    selector.style.borderColor = "";
    selector.style.borderWidth = "";
}

function isFormValid() {
    if (currentlySelectedStudents.length >= 4 && currentlySelectedStudents.length <= 6) {
        return !errorActive;
    } else {
        displayErrorMessage("The number of students needs to be between 4 and 6");
    }
    return false;
}
