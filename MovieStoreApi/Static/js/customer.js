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
            GetOrders(); // <- If the login is successfull we run the GetOrders function
        }
    })
});


function GetUserInfo() {
    $.ajax({
        url: '/api/store/userinfo',
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log(res);
            // HERE YOU NEED TO DO STUFF WITH USER INFO
        }
    })
}

function GetOrders() {
    $.ajax({
        url: '/api/store/orders/user',
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log(res);
            AddOrder(res);
        }
    })
};

function AddOrder(order) {
    for (var i = 0; i < order.length; i++) {
        console.log(order[i]);
        $('#orders').append('<li class="list-group-item">' + order[i].ProductName + '</li>');
    }
}
