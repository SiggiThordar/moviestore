$('#register').click(function () {
    $.ajax({
        url: '/api/account/register',
        method: 'POST',
        data: {
            Email: $('#rEmail').val(),
            Password: $('#rPassword').val(),
            ConfirmPassword: $('#rConfirmPassword').val(),
            FullName: $('#rFullName').val(),
            Address: $('#rAddress').val(),
            Phone: $('#rPhone').val()
        },
        success: function (res) {
            console.log(res);
        },
        error: function (res) {
            console.log("error!", res.responseText, res);
        }
    });
});



$('#review').click(function () {
    $.ajax({
        url: '/api/user/review',
        method: 'POST',
        headers: {
            authorization: 'Bearer ' + token,
        },
        data: {
            Id: 1,
            CustomerUsername: 'Stefán',
            MovieRating: 2,
            Critic: 'Works'
        },
        success: function (res) {
            console.log(res);
        },
        error: function (res) {
            console.log("error!", res.responseText, res);
        }
    });
});


var token = '';

$('#login').click(function () {
    $.ajax({
        url: '/token',
        method: 'POST',
        data: {
            username: $('#lUser').val(),
            password: $('#lPassword').val(),
            grant_type: 'password'

        },
        success: function (res) {
            console.log(res);
            token = res.access_token;
            GetMovies();
        }
    })
});

function GetMovies() {
    $.ajax({
        url: '/api/moviestore/movies',
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log(res);
            AddMovie(res);
        }
    })
};

function OrderMovie(id) {
    $.ajax({
        url: '/api/moviestore/rent/'+id,
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log("Movie Play");
        }
    })
}

function AddMovie(movie) {
    for (var i = 0; i < movie.length; i++) {
        console.log(movie[i]);
        $('#movie').append('<li class="list-group-item">' + movie[i].Title + ' <button class="buy btn-xs btn-success" value="'+movie[i].Id+'">Rent</button></li>');
    }
}

$(document).on('click', '.rent', function () {
        OrderMovie($(this).val());
});