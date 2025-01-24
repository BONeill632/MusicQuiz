function submitAnswer() {
    var selectedOption = document.querySelector('input[name="selectedOption"]:checked');
    if (!selectedOption) {
        alert("Please select an option.");
        return;
    }

    var correctAnswer = document.querySelector('input[name="correctAnswer"]').value;

    // Remove previous feedback classes and text
    var options = document.querySelectorAll('.option');
    options.forEach(function (option) {
        option.classList.remove('correct', 'incorrect');
        var feedbackText = option.querySelector('.feedback-text');
        if (feedbackText) {
            feedbackText.remove();
        }
    });

    var feedbackText = document.createElement('span');
    feedbackText.classList.add('feedback-text');

    if (selectedOption.value === correctAnswer) {
        selectedOption.parentElement.classList.add('correct');
        feedbackText.innerHTML = 'Correct! ✔';
        feedbackText.style.color = 'green';
    } else {
        selectedOption.parentElement.classList.add('incorrect');
        feedbackText.innerHTML = 'Try again. ✘';
        feedbackText.style.color = 'red';
    }

    selectedOption.parentElement.appendChild(feedbackText);

    // Increment the attempt number in JavaScript
    var attemptNumberField = document.getElementById('attemptNumber');
    var attemptNumber = parseInt(attemptNumberField.value) || 0;
    attemptNumber++;  // Increase attempt number by 1
    attemptNumberField.value = attemptNumber;  // Update hidden field with new attempt number

    // Populate the firstUserAnswer if it is not already set
    var firstUserAnswerField = document.getElementById('firstUserAnswer');
    if (!firstUserAnswerField.value) {
        firstUserAnswerField.value = selectedOption.value;  // Set the first answer only if it's null
    }

    // Enable the Next button
    document.getElementById('nextButton').disabled = false;
}

// Display saved feedback
document.addEventListener("DOMContentLoaded", function () {
    var feedback = document.getElementById("feedback").value;
    if (feedback) {
        var selectedOption = document.querySelector('input[name="selectedOption"]:checked');
        if (selectedOption) {
            var feedbackText = document.createElement('span');
            feedbackText.classList.add('feedback-text');
            feedbackText.innerHTML = feedback;
            feedbackText.style.color = feedback.includes('Correct') ? 'green' : 'red';
            selectedOption.parentElement.appendChild(feedbackText);
            selectedOption.parentElement.classList.add(feedback.includes('Correct') ? 'correct' : 'incorrect');
            // Enable the Next button
            document.getElementById('nextButton').disabled = false;
        }
    }
});
