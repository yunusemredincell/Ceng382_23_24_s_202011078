function hideoperation() {

    let element = document.getElementById("hidingelement");

    if (element.style.visibility === "hidden") {
        document.getElementById("hide-button").innerHTML = "Hide Element";
        element.style.visibility = "visible";
    } else {
        element.style.visibility = "hidden";
        document.getElementById("hide-button").innerHTML = "Show Element";
    }

}

function openform() {
    let form = document.getElementById("summation");
    if (form.hidden) {
        form.hidden = false;
    }
    else {
        form.hidden = true;
    }
}


function calculateSum() {

    let num1 = +document.getElementById('num1').value;
    let num2 = +document.getElementById('num2').value;
    let sum = num1 + num2;
    document.getElementById('result').innerHTML = 'The sum of <strong>' + num1 + '</strong> and <strong>' + num2 + '</strong> is <strong>' + sum + '</strong>';

}