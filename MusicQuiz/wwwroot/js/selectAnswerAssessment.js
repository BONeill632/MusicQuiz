function selectOption(optionId, className) {
    // Remove 'selected' class from all options
    document.querySelectorAll(`.${className}`).forEach(div => {
        div.classList.remove('selected');
    });

    // Add 'selected' class to the clicked option
    const selectedOption = document.getElementById(optionId);
    selectedOption.classList.add('selected');

    // Set the value of the hidden input field
    document.getElementById('selectedOption').value = optionId;

    // Enable the "Next" button
    const nextButton = document.getElementById('nextButton');
    if (nextButton) {
        nextButton.disabled = false;
    }
}

document.addEventListener('DOMContentLoaded', function () {
    // Add click event listeners to all options
    document.querySelectorAll('.option').forEach(function (div) {
        div.addEventListener('click', function () {
            // Remove 'selected' class from all options
            document.querySelectorAll('.option').forEach(function (div) {
                div.classList.remove('selected');
            });

            // Add 'selected' class to the clicked option
            div.classList.add('selected');

            // Set the radio button as checked
            const radio = div.querySelector('input[type="radio"]');
            if (radio) {
                radio.checked = true;
            }

            // Enable the "Next" button
            const nextButton = document.getElementById('nextButton');
            if (nextButton) {
                nextButton.disabled = false;
            }
        });
    });
});
