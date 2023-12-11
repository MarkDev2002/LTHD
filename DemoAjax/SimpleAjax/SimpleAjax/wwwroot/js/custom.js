$(document).ready(function () { // code javascript sẽ được thực hiện sau khi HTML đã tải xong
    $("#loadData").click(function () {
        ShowEmployeeData();
    });
});

function ShowEmployeeData() {
    $.ajax({ // sử dụng jQuery để thực hiện request Ajax từ client đến server.

        // địa chỉ URL mà request sẽ được gửi đến
        url: '/Ajax/EmployeeList',  // request sẽ gửi đến action method "EmployeeList" trong Controller có tên "Ajax".
        type: 'Get', // HTTTP Get, lấy request từ server
        dataType: 'json', // dữ liệu mong muốn được trả về từ request Ajax
        contentType: 'application/json;charset=utf-8;', // định dạng dữ liệu gửi đến server
        success: function (result, status) {
            // tham số truyền vào (result,status)
            // result : chứa dữ liệu mà server trả về trong response.
            // status : chứa trạng thái của request Ajax cho biết tình trạng của yêu cầu

            // dữ liệu được thêm vào một đối tượng JavaScript có tên object
            var object = "";
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id;
                object += '<td>' + item.firstName;
                object += '<td>' + item.middleName;
                object += '<td>' + item.lastName;
                object += '<td>' + item.emailAddress;
                object += '<td>' + item.phoneNumber;
                object += '</tr>';

            });

            // object được thêm vào bảng trên trang web bằng cách chọn phần tử HTML có ID "table_data" 
            $('#table_data').html(object);
        },
        error: function () { // hàm xử lý khi ajax gặp lỗi
            alert("Data can't get");
        }
    });
};