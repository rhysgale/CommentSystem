var vm = new Vue({
    el: '#main',
    data: {
        comments: [],
        commentText: "",
        filmModel: {}
    },
    methods: {
        submitComment: function () {
            var id = this.filmModel.filmId;
            $.ajax({
                type: "POST",
                data: JSON.stringify({commentText: this.commentText, filmId: this.filmModel.filmId}),
                url: "/api/comment",
                contentType: "application/json",
                success: function (comment) {
                    this.comments.push({});
                }
            });
        }
    },
    mounted: function () {
        var me = this;
        me.filmModel = model;
        model.comments.forEach(function (item) {
            me.comments.push(item);
        });
    }
});
