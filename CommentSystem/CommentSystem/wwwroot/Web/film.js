var vm = new Vue({
    el: '#main',
    data: {
        comments: [],
        commentText: "",
        filmModel: {},
        editComment: { commentText: "", commentId: "" },
        history: []
    },
    methods: {
        sortComments: function () {
            this.comments.sort(function (a, b) {
                a = new Date(a.createDateTime);
                b = new Date(b.createDateTime);
                return a > b ? -1 : a < b ? 1 : 0;
            });
        },
        submitComment: function () {
            var me = this;
            $.ajax({
                type: "POST",
                data: JSON.stringify({commentText: this.commentText, filmId: this.filmModel.filmId}),
                url: "/api/comment",
                contentType: "application/json",
                success: function (comment) {
                    me.sortComments();
                    me.comments.unshift(comment);
                    me.commentText = "";
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
        openHistoryModal: function (id) {
            var me = this;
            var selectedComment = me.comments.find(x => x.commentId === id);
            me.history = [];

            selectedComment.commentHistory.forEach(function (model) {
                me.history.push(model);
            });
            $("#historyModal").modal("show");
        },
        openUpdateModal: function (commentId) {
            var me = this;
            me.editComment.commentId = commentId;
            var selected = me.comments.find(x => x.commentId === commentId);
            me.editComment.commentText = selected.commentText;
            $("#editCommentModal").modal("show");
        },
        updateComment: function () {
            var me = this;
            $.ajax({
                type: "PUT",
                data: JSON.stringify(this.editComment),
                url: "/api/comment",
                contentType: "application/json",
                success: function (data) {
                    var comment = me.comments.find(x => x.commentId === me.editComment.commentId);
                    var idx = me.comments.indexOf(comment);
                    me.comments.splice(idx, 1);
                    me.comments.push(data);
                    $("#editCommentModal").modal("hide");
                    me.sortComments();
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
