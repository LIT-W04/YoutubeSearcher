$(function () {
    $('.date').datetimepicker();
    var from;
    var to;
    var nextPageToken;

    $('.from').on('dp.change', function (e) {
        from = e.date;
        setButton();
    });

    $('.to').on('dp.change', function (e) {
        to = e.date;
        setButton();
    });

    function setButton() {
        $(".btn-success").prop('disabled', !areDatesValid(from, to));
    }

    function areDatesValid(fromDate, toDate) {
        if (!fromDate) {
            return true;
        }

        return fromDate.isBefore(toDate);

    }

    $(window).scroll(function () {
        if ($(window).scrollTop() >= $(document).height() - $(window).height() - 10) {
            fillTable();
        }
    });


    function fillTable() {
        $.get('/home/search', {
            search: $("#seachText").val(),
            from: $("#from").val(),
            to: $("#to").val(),
            nextPageToken: nextPageToken
        }, function (results) {
            nextPageToken = results.NextPageToken;
            results.Videos.forEach(video => {
                $("table").append(`<tr>
                    <td>
                        <a href='${video.Url}'>
                         <img style='width:100px;' src='${video.Thumbnail}' />
                        </a>
                    </td>
                    <td>
                        <a href='${video.Url}'>
                            ${video.Title}
                        </a>
                    </td>
                    <td>
                        ${new Date(parseInt(video.PublishedDate.replace("/Date(", "").replace(")/", ""), 10))}
                    </td>
                    </tr>`);
            });
        });
    }

    $(".btn-success").on('click', function () {
        nextPageToken = '';
        $("table tr:gt(0)").remove();
        fillTable();
    });

    $("table").on('click', 'a', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.post('/home/TrackLinkClick', { url: url }, function () {
            window.location.href = url;
        });
    });

});