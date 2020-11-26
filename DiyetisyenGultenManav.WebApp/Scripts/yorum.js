var noteid = -1;
var modalCommentBodyId = "#modal_comment_body";
$(function () {
    $('#modal_comment').on('show.bs.modal', function (e) {
        var btn = $(e.relatedTarget);
        noteid = btn.data("blog-id");
        $(modalCommentBodyId).load("/Yorum/ShowNoteComments/" + noteid);
    });
});
function doYorum(btn, e, yorumid, spanid) {
    var button = $(btn);
    var mode = button.data("edit-mode");
    if (e == "edit_clicked") {
        if (!mode) {
            button.data("edit-mode", true);
            button.removeClass("btn-warning");
            button.addClass("btn-success");
            var btnSpan = button.find("span")
            btnSpan.removeClass("fa-edit");
            btnSpan.addClass("fa-check");
            $(spanid).addClass("editable");
            $(spanid).attr("contenteditable", true);
            $(spanid).focus();
        }
        else {
            button.data("edit-mode", false);
            button.addClass("btn-warning");
            button.removeClass("btn-success");
            var btnSpan = button.find("span")
            btnSpan.addClass("fa-edit");
            btnSpan.removeClass("fa-check");
            $(spanid).removeClass("editable");
            $(spanid).attr("contenteditable", false);
            var txt = $(spanid).text();
            $.ajax({
                method: "POST",
                url: "/Yorum/Edit/" + yorumid,
                data: { text: txt }
            }).done(function (data) {

                if (data.result) {
                    // yorumlar partial tekrar yüklenir
                    $(modalCommentBodyId).load("/Yorum/ShowNoteComments/" + noteid);

                } else {
                    alert("Yorum Güncellenemedi");
                }
            }).fail(function () {
                alert("Sunucu ile Bağlantı kurulamadı.");
            });
        }
    }
    else if (e == "delete_clicked") {
        var dialog_result = confirm("Yorum Silinsin mi ? ");
        if (!dialog_result) return false;
        $.ajax({
            method: "GET",
            url: "/Yorum/Delete/" + yorumid
        }).done(function (data) {

            if (data.result) {
                // yorumlar partial tekrar yüklenir
                $(modalCommentBodyId).load("/Yorum/ShowNoteComments/" + noteid);
            } else {
                alert("Yorum Silinemedi");
            }
        }).fail(function () {
            alert("Sunucu İle bağlantı kurulamadı.");
        });
    } else if (e == "new_clicked") {
        var txt = $("#new_yorum_text").val();
        $.ajax({
            method: "POST",
            url: "/Yorum/Create/",
            data: { "text": txt, "noteid": noteid }
        }).done(function (data) {

            if (data.result) {
                // yorumlar partial tekrar yüklenir
                $(modalCommentBodyId).load("/Yorum/ShowNoteComments/" + noteid);
            } else {
                alert("Yorum Eklenemedi");
            }
        }).fail(function () {
            alert("Sunucu İle bağlantı kurulamadı.");
        });
    }
}