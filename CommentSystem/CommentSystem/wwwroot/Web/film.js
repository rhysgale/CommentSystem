var vm = new Vue({
    el: '#main',
    data: {
        comments: [],
        commentText: "",
        filmModel: {}
    },
    methods: {
        submitComment: function () {
            var me = this;
            $.ajax({
                type: "POST",
                data: JSON.stringify({commentText: this.commentText, filmId: this.filmModel.filmId}),
                url: "/api/comment",
                contentType: "application/json",
                success: function (comment) {
                    me.comments.push(comment);
                }
            });
        },
        deleteComment: function (id) {
            var me = this;
            $.ajax({
                type: "DELETE",
                data: JSON.stringify({ commentId: id }),
                url: "/api/comment",
                contentType: "application/json",
                success: function (comment) {
                    var selected = me.comments.find(x => x.commentId === id);
                    var idx = me.comments.indexOf(selected);
                    me.comments.splice(idx, 1);
                }
            });
        },
        updateComment: function () {
            $.ajax({
                type: "PUT",
                data: JSON.stringify({ commentText: this.commentText, filmId: this.filmModel.filmId }),
                url: "/api/comment",
                contentType: "application/json",
                success: function (comment) {
                    me.comments.push(comment);
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
