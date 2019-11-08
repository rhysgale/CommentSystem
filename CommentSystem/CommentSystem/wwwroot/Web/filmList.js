var vm = new Vue({
    el: '#main',
    data: {
        message: 'Hello Vue!'
    },
    methods: {
        goToFilm: function (filmId) {
            window.location = `home/FilmOverview?id=${filmId}`;
        }
    }
});
