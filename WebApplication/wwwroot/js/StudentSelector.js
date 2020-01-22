//stack of the students
let currentlySelectedStudents = [];
const maxNumberOfStudent = 6;
let container = document.getElementById("container-selectors");
let listItems = document.getElementsByClassName("custom-select studentItems")[0];

let previousStudentFieldValue;

//this variable dictates weather the add button will function or not

/**
 * This method adds a new Student item selector view
 * inside the view container
 */
function addStudentItem() {
    let lastSelector = container.lastChild;
    let firstSelector = document.getElementsByTagName("select")[0];
    if (lastSelector.value === "default" || firstSelector.value ==="default") {
        displayErrorMessage("Please complete the previous field first");
        return;
    }
    
    let numberOfSelectors = document.getElementsByTagName("select").length;
    //if there are more than 5 field do not allow to add more
    if (numberOfSelectors < 6) {
        hideErrorMessage();
        //insert a new student item
        let newListItems = listItems.cloneNode(true);
        newListItems.style.marginTop = "10px";
        newListItems.name = "selectedStudent" + (container.children.length);
        container.append(newListItems);
    } else {
        displayErrorMessage("You already reached the maximum number of students in a group");
    }
}

function displayErrorMessage(message) {
    let alert = document.getElementById("errorMessageCreateTable");
    alert.style.visibility = "visible";
    alert.innerText = message;
}

function unfocusSelector(selector) {
    selector.blur();
    selector.style.borderColor = "";
    selector.style.borderWidth = "";
}

/**
 * This function needs to be called every time we successfully
 * completed an operation
 */
function hideErrorMessage() {
    let alert = document.getElementById("errorMessageCreateTable");
    alert.style.visibility = "hidden";
    alert.innerText = "";
}


function removeStudentFromList() {
    //don't allow item removal if the length is
    //not bigger than 2
    if (container.children.length > 2) {
        removeElementFromView();
        currentlySelectedStudents.pop();
        let numberOfStudentsHiddenField = document.getElementById("numberOfStudents");
        numberOfStudentsHiddenField.value = container.children.length - 1;
    }
}

function storeCurrentValue(value) {
    previousStudentFieldValue = value;

}

function removeElementFromView() {
    let lastSelector = container.lastChild;
    if (lastSelector.value !== "default") 
    {
        currentlySelectedStudents.pop();
    }
    container.removeChild(container.lastChild);
}

function selectStudent(value, input) {
    //remove the previous value from the array
    let indexToReplace= currentlySelectedStudents.indexOf(previousStudentFieldValue);
    if (indexToReplace !== -1) {
        //add the new value to the array
        currentlySelectedStudents[indexToReplace] = value;
    } else {
        //add a new value to stack
        currentlySelectedStudents.push(value);
    }
    hideErrorMessage();
    unfocusSelector(input);
}


function isFormValid() {
    let numberOfStudents = currentlySelectedStudents.length;
    for (let i = 0; i < numberOfStudents; i++) {
        for (let j = 0; j < numberOfStudents; j++) {
            if (i !== j && currentlySelectedStudents[i] === currentlySelectedStudents[j]) {
                displayErrorMessage("You have selected multiple students with the same name");
                //there are fields that have the same value
                return false;
            }

        }
    }
    if (currentlySelectedStudents.length >= 4 && currentlySelectedStudents.length <= 6) {
        return true;
    } else {
        displayErrorMessage("The number of students needs to be between 4 and 6");
    }
    return false;
}