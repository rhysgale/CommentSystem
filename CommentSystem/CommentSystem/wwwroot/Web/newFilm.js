var vm = new Vue({
    el: '#main',
    data: {
    },
    methods: {
        submitFilm: function () {
            var desc = $("#filmdesc").val();
            var title = $("#filmtitle").val();
            $.ajax({
                type: "POST",
                data: JSON.stringify({ filmTitle: title, filmDescription: desc }),
                url: "/api/films",
                contentType: "application/json",
                success: function () {
                    window.location.href = "/home";
                }
            });
        }
    }
});
