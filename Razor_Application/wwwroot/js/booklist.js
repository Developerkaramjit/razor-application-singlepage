var DataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable()
{
    DataTable = $('#DT-Load').dataTable
    ({
        "ajax":
        {
            "url": "api/book",
            "type": "GET",
            "datatype": "JSON"
        },
        "columns":
        [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
             { "data": "isbn", "width": "20%" },
                {
                    "data": "id",
                    "render": function (data)
                    {
                        return `<div class=text-center>
                         <a class="btn btn-success" href="/BookList/Edit?id=${data}">Edit</a>
                         <a class="btn btn-danger" onclick="Delete('api/book?id=${data}')"> Delete </a>  
                          </div>`
                    }
                }
        ]
    })
}
function Delete(url)
{
    swal            /*swal=sweatalert in layout link*/
    ({
        title: "Want to delete data ?",
        icon: "warning",
        dangerModel:true
    }).then((willdelete) =>
    {
        if (willdelete)
        {
            $.ajax
           ({
                url: url,
                type: "DELETE",
                success: function (data)
                {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else
                    {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}