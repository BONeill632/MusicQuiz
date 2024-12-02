document.addEventListener('DOMContentLoaded', function () {
    var ctx = document.getElementById('scoreChart').getContext('2d');
    var scoreChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Correct', 'Incorrect'],
            datasets: [{
                data: [correctAnswers, totalQuestions - correctAnswers],
                backgroundColor: ['#4CAF50', '#F44336']
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            var label = context.label || '';
                            if (label) {
                                label += ': ';
                            }
                            label += context.raw + ' (' + Math.round(context.raw / totalQuestions * 100) + '%)';
                            return label;
                        }
                    }
                }
            }
        }
    });
});
