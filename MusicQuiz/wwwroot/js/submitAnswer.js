function submitAnswer() {
    var selectedOption = document.querySelector('input[name="selectedOption"]:checked');
    if (!selectedOption) {
        alert("Please select an option.");
        return;
    }

    var correctAnswer = document.querySelector('input[name="correctAnswer"]').value;

    // Remove previous feedback classes and text from all options
    var options = document.querySelectorAll('.quiz-option');
    options.forEach(function (option) {
        option.classList.remove('correct', 'incorrect');
        var feedbackText = option.querySelector('.feedback-text');
        if (feedbackText) {
            feedbackText.remove();
        }
    });

    var feedbackText = document.createElement('span');
    feedbackText.classList.add('feedback-text');

    // Find the correct parent quiz-option element
    var parentOption = selectedOption.closest('.quiz-option');

    if (selectedOption.value === correctAnswer) {
        parentOption.classList.add('correct');
        feedbackText.classList.add('correct');
        feedbackText.innerHTML = 'Correct! ✔';
    } else {
        parentOption.classList.add('incorrect');
        feedbackText.classList.add('incorrect');
        feedbackText.innerHTML = 'Try again. ✘';
    }

    parentOption.appendChild(feedbackText);

    // Rest of the function remains the same
    var attemptNumberField = document.getElementById('attemptNumber');
    var attemptNumber = parseInt(attemptNumberField.value) || 0;
    attemptNumber++;
    attemptNumberField.value = attemptNumber;

    var firstUserAnswerField = document.getElementById('firstUserAnswer');
    if (!firstUserAnswerField.value) {
        firstUserAnswerField.value = selectedOption.value;
    }

    document.getElementById('nextButton').disabled = false;
}

// Update the DOMContentLoaded event handler as well
document.addEventListener("DOMContentLoaded", function () {
    var feedback = document.getElementById("feedback").value;
    if (feedback) {
        var selectedOption = document.querySelector('input[name="selectedOption"]:checked');
        if (selectedOption) {
            var parentOption = selectedOption.closest('.quiz-option');
            var feedbackText = document.createElement('span');
            feedbackText.classList.add('feedback-text');
            feedbackText.innerHTML = feedback;
            feedbackText.classList.add(feedback.includes('Correct') ? 'correct' : 'incorrect');
            parentOption.appendChild(feedbackText);
            parentOption.classList.add(feedback.includes('Correct') ? 'correct' : 'incorrect');
            document.getElementById('nextButton').disabled = false;
        }
    }
});
