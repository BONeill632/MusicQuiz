﻿function confirmDelete(questionId) {
    if (confirm('Are you sure you want to delete this question?')) {
        document.getElementById('deleteForm-' + questionId).submit();
    }
}