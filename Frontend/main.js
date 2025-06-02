document.addEventListener("DOMContentLoaded", function fetchMovieData() {
    fetch("http://localhost:5155/api/movies/")
        .then(response => response.json())
        .then(movies => {
            const listContainer = document.getElementById("movie-list");
            movies.forEach(movie => {
                const movieDiv = document.createElement("div");
                movieDiv.className = "movie-card";

                const title = document.createElement("h2");
                title.textContent = movie.title;

                const type = document.createElement("p");
                type.textContent = `Type: ${movie.type}`;

                const releaseYear = document.createElement("p");
                releaseYear.textContent = `Release year: ${movie.releaseYear}`;

                const genre = document.createElement("p");
                genre.textContent = `Genre: ${movie.genre}`;

                const director = document.createElement("p");
                director.textContent = `Director: ${movie.director}`;

                const imageURL = document.createElement("img");
                imageURL.src = movie.imageURL;

                movieDiv.appendChild(title);
                movieDiv.appendChild(type);
                movieDiv.appendChild(releaseYear);
                movieDiv.appendChild(genre);
                movieDiv.appendChild(director);
                movieDiv.appendChild(imageURL);
                listContainer.appendChild(movieDiv);
            });
        })
})