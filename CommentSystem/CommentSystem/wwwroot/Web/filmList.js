var vm = new Vue({
    el: '#main',
    methods: {
        goToFilm: function (filmId) {
            window.location = `home/FilmOverview?id=${filmId}`;
        }
    }
});
