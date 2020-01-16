function addTableRow() {
    let inputTableHeight = document.getElementById("tableHeight");
    let currentTableHeight = parseInt(inputTableHeight.value);
    let table = document.getElementById("round-table");
    let tableRow = document.createElement("tr");

    for (let i = 1; i <= 5; i++) {
        let column;
        if (i === 1) {
            column = document.createElement("th");
            column.scope = "row";
        } else {
            column = document.createElement("td");
        }
        
        column.className = "rubric-item";
        
        let divTextarea = document.createElement("div");
        divTextarea.className = "md-form";

        let textarea = document.createElement("textarea");
        textarea.className = "md-textarea form-control";
        textarea.rows = 3;
        let rowValue = currentTableHeight + 1;
        textarea.name = "row" + rowValue + "col" + i;

        divTextarea.appendChild(textarea);
        column.appendChild(divTextarea);
        tableRow.appendChild(column);
        table.appendChild(tableRow);
        inputTableHeight.value = currentTableHeight +1;
    }
}