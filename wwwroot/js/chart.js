document.addEventListener("DOMContentLoaded", function () {
    const ctx = document.getElementById("vehicleChart").getContext("2d");
    new Chart(ctx, {
        type: "pie",
        data: {
            labels: ["Toplam Araç", "Bakim sayisi", "Tamamlanan Bakım"],
            datasets: [
                {
                    data: JSON.parse(document.getElementById("chartData").textContent),
                    backgroundColor: ["#213a58", "#15919B", "#46DFB1"],
                    borderColor: ["#3B82F6", "#FACC15", "#22C55E"],
                    borderWidth: 1
                }
            ]
        }
    });
});
