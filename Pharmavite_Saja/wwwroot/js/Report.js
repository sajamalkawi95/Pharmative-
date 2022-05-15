$(document).ready(function () {
    ///Sales Revenue = Units Sold x Sales Price ||  all orders ||
    ///////////////////////////
    ////// fill table ///////
    ////////////////////////
    $.get("/Dashbord/GetReport", (data) => {
        console.log(data);
        var totalSales = 0;
        data.forEach(e => totalSales += (e.productOrderQty * e.productPrice));
        console.log(totalSales);
        $('#Report').DataTable(
            {
                dom: 'Blfrtip',
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
                data: data,
                columns: [
                    //{ data: "orderIdfk" },
                    { data: "productName" },
                    { data: "productPrice" },
                    { data: "productOrderQty" },
                    { data: "orderdate" },
                    { data: "deleverddate" },
                    //{ data: "productIdfk" }
                ]
            }
        )
        $('.dt-button').attr("class", "btn btn-success");
        let x = document.getElementById('total');
        console.log(x)
            //.textContent = totalSales;
        document.getElementById('Report').appendChild('<tr>' + '<td>' + data.length + '</td>' + '</tr>');

        //$('#total').html(totalSales);
        //$('#Report').append('<tr>' + '<td>' + data.length + '</td>' + '</tr>')

       // $('#Report').append('<tr>' + '<td>' + ((totalSales) / (data.length)) + '</td>' + '</tr>')


    })
});
