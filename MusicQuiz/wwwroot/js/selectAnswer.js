    function selectOption(optionId, className) {
        // Remove 'selected' class from all options
        document.querySelectorAll(`.${className}`).forEach(div => {
            div.classList.remove('selected');
        });

        // Add 'selected' class to the clicked option
        document.getElementById(optionId).classList.add('selected');

        // Set the value of the hidden input field
        document.getElementById('selectedOption').value = optionId;
    }

    document.addEventListener('DOMContentLoaded', function () {
        document.querySelectorAll('.option').forEach(function (div) {
            div.addEventListener('click', function () {
                // Remove 'selected' class from all options
                document.querySelectorAll('.option').forEach(function (div) {
                    div.classList.remove('selected');
                });

                // Add 'selected' class to the clicked option
                div.classList.add('selected');

                // Set the radio button as checked
                var radio = div.querySelector('input[type="radio"]');
                radio.checked = true;
            });
        });
    });