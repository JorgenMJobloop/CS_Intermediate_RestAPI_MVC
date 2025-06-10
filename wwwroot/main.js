// Messy JS code :z
function renderTable(movies, append=false) {
    const tableBody = document.querySelector("#movie-table tbody");
    if(!append) tableBody.innerHTML = '';

    movies.forEach(movie => {
        const row = document.createElement("tr");

        row.appendChild(createCell(movie.title));
        row.appendChild(createCell(movie.type));
        row.appendChild(createCell(movie.releaseYear));
        row.appendChild(createCell(movie.genre));
        row.appendChild(createCell(movie.director));

        const imageCell = document.createElement("td");
        const img = document.createElement("img");

        img.src = `${movie.imageURL}`;
        img.alt = movie.title;
        img.style.width = "60px";
        imageCell.appendChild(img);

        tableBody.appendChild(row);
    })
}

function createCell(text) {
    const cell = document.createElement("td");
    cell.textContent = text;
    return cell;
}

const _url = "https://upgraded-space-robot-4446xgqxgpj3j6r6-5155.app.github.dev/api/movies"

document.addEventListener("DOMContentLoaded", function fetchMovieData(url) {
    fetch(_url)
        .then(res => res.json())
        .then(movies => renderTable(movies));
})
