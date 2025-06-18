function createCell(text) {
    const cell = document.createElement("td");
    cell.textContent = text;
    return cell;
}

function updateImageOnly(id, imageUrl) {

    fetch(`${_url}/${id}/update-image`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ imageURL: imageUrl })
    })
        .then(res => res.ok ? res.json() : Promise.reject(res)).then(result => {
            console.log("Image updated successfully:", result);
            location.reload();
        }).catch(error => {
            console.error("Error updating image:", error);

        });
}

const _url = "https://upgraded-space-robot-4446xgqxgpj3j6r6-5155.app.github.dev/api/movies";

document.addEventListener("DOMContentLoaded", function fetchMovieData(url) {
    fetch(_url,)
        .then(res => res.json())
        .then(data => console.log(data))
        .then(movies => renderTable(data));
})

function renderTable(movies, append = false) {
    const tableBody = document.querySelector("#movie-table tbody");
    if (!append) tableBody.innerHTML = '';

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