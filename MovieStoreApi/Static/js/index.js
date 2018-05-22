$('#register').click(function () {
    $.ajax({
        url: '/api/account/register',
        method: 'POST',
        data: {
            Email: $('#rEmail').val(),
            Password: $('#rPassword').val(),
            ConfirmPassword: $('#rConfirmPassword').val(),
            Name: $('#rName').val(),
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
            GetProdcts();
        }
    })
});

function GetAllMovie() {
    $.ajax({
        url: '/api/store/movies',
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log(res);
            AddProduct(res);
        }
    })
};

function OrderProduct(id) {
    $.ajax({
        url: '/api/store/products/buy/'+id,
        headers: {
            authorization: 'Bearer ' + token,
        },
        success: function (res) {
            console.log("Product Bought");
        }
    })
}

function AddProduct(product) {
    for (var i = 0; i < product.length; i++) {
        console.log(product[i]);
        $('#product').append('<li class="list-group-item">' + product[i].Name + ' <button class="buy btn-xs btn-success" value="'+product[i].Id+'">Buy</button></li>');
    }
}

$(document).on('click', '.buy', function () {
        OrderProduct($(this).val());
});