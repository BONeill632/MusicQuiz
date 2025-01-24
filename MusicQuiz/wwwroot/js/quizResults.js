document.addEventListener("DOMContentLoaded", function () {
    // Data for the chart
    const data = {
        labels: ["Right First Time", "Right Second Time", "Right Third Time", "Right Fourth Time", "Incorrect Answers"],
        datasets: [
            {
                label: "Quiz Results",
                data: [rightFirstTime, rightSecondTime, rightThirdTime, rightFourthTime, incorrectAnswers],
                backgroundColor: [
                    "#4CAF50", // Green for right first time
                    "#FFC107", // Amber for right second time
                    "#FF9800", // Darker amber for right third time
                    "#FF5722", // Even darker amber for right fourth time
                    "#F44336"  // Red for incorrect answers
                ],
                borderRadius: 8, // Rounded corners for bars
                borderWidth: 1,
                hoverBackgroundColor: [
                    "#66BB6A", // Lighter green on hover
                    "#FFD54F", // Lighter amber on hover
                    "#FFB74D", // Lighter dark amber on hover
                    "#FF8A65", // Lighter darker amber on hover
                    "#E57373"  // Lighter red on hover
                ],
                borderColor: "rgba(0,0,0,0.1)" // Subtle border for a sleek look
            }
        ]
    };

    // Chart options
    const options = {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
                display: false // Hides the legend for simplicity
            },
            tooltip: {
                backgroundColor: "rgba(0, 0, 0, 0.7)", // Dark background for tooltips
                titleColor: "#FFF", // White title text
                bodyColor: "#FFF", // White body text
                borderColor: "#CCC", // Light border
                borderWidth: 1,
                cornerRadius: 6
            }
        },
        layout: {
            padding: {
                top: 20,
                right: 20,
                bottom: 20,
                left: 20
            }
        },
        scales: {
            x: {
                beginAtZero: true,
                grid: {
                    display: false
                },
                ticks: {
                    color: "#666",
                    font: {
                        size: 14,
                        family: "Arial, sans-serif",
                        weight: "bold"
                    }
                }
            },
            y: {
                beginAtZero: true,
                max: totalQuestions, // Set the maximum height to total questions
                grid: {
                    color: "#E0E0E0",
                    borderDash: [5, 5] // Dashed grid lines for a modern touch
                },
                ticks: {
                    stepSize: 1,
                    color: "#666",
                    font: {
                        size: 14,
                        family: "Arial, sans-serif"
                    }
                }
            }
        }
    };

    // Create the chart
    const ctx = document.getElementById("scoreChart").getContext("2d");
    new Chart(ctx, {
        type: "bar",
        data: data,
        options: options
    });
});
