$(document).ready(function () {

    //DataTable Start from Here

   const datatable= $('#userTables').DataTable({
        dom: "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yeni İstafədəçi',
                attr: {
                    id: "btnAdd"
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'Yenilə',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/User/GetAllUsers/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#userTables').hide();
                            $('.btnUpdate').show();
                        },
                        success: function (data) {
                            const userListDto = jQuery.parseJSON(data);
                            datatable.clear();
                            if (userListDto.ResultStatus === 0) {
                                $.each(userListDto.Users.$values,
                                    function (index, user) {
                                        const newTableRow=datatable.row.add([
                                            user.Id,
                                            user.UserName,
                                            user.Email,
                                            user.PhoneNumber,
                                            `<img src="/img/${user.Picture}" class="my-image-table" alt="${user.UserName}" />`,
                                            `<td class="text-center">
                                                <button class="btn btn-primary btn-sm btn-update" data-id="${user.Id}"><span class="fas fa-edit"></span> </button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${user.Id}"><span class="fas fa-minus-circle"></span> </button>
                                            </td>`
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);//Jquery obyektine cevirdiy
                                        jqueryTableRow.attr('name', `${user.Id}`);
                                    });
                                datatable.draw();
                                $('.btnUpdate').hide();
                                $('#userTables').fadeIn(1500);
                            } else {
                                toastr.error(`${userListDto.Message}`, "Xeta Bas verdi");
                            }
                        },
                        error: function (err) {
                            $('.btnUpdate').hide();
                            $('#userTables').fadeIn(1000);
                            toastr.error(`${err.responseText}`, "Xeta!");
                        }
                    });
                }
            }

        ],
        "language": {
            "sEmptyTable": "Cədvəldə heç bir məlumat yoxdur",
            "sInfo": " _TOTAL_ Nəticədən _START_ - _END_ Arası Nəticələr",
            "lengthMenu": "Səhifədə _MENU_ Nəticə Göstər",
            "sZeroRecords": "Nəticə Tapılmadı.",
            "sInfoEmpty": "Nəticə Yoxdur",
            "sInfoFiltered": "( _MAX_ Nəticə İçindən Tapılanlar)",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Yüklənir...",
            "sProcessing": "Gözləyin...",
            "sSearch": "Axtarış:",
            "sZeroRecords": "Nəticə Tapılmadı.",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Axırıncı",
                "sNext": "Sonraki",
                "sPrevious": "Öncəki"
            },

            "oAria": {
                "sSortAscending": ": sütunu artma sırası üzərə aktiv etmək",
                "sSortDescending": ": sütunu azalma sırası üzərə aktiv etmək"
            }

        },
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "Paginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bSort": false,
        "bInfo": true,
        "bAutoWidth": false,
        "placeholder": " ",
    });
    //DataTables End from Here

    //Ajax GET / Getting the _UserAddPartial as Modal Form starts from here

    $(function () {
        const url = '/Admin/User/Add/';
        const placeholderDiv = $('#modalPlaceHolder');
        $("#btnAdd").click(function () {
            $.get(url).done(function (data) {
                placeholderDiv.html(data);
                placeholderDiv.find(".modal").modal("show");
            });
        });

    //Ajax GET / Getting the _UserAddPartial as Modal Form ends from here


    //Ajax POST / Posting the FormData as UserAddDto starts from here

        placeholderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-user-add');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0));
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType:false,
                success: function (data) {
                    const userAddAjaxModel = jQuery.parseJSON(data);
                    const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                    placeholderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeholderDiv.find('.modal').modal('hide');
                       const newTableRow= datatable.row.add([
                            userAddAjaxModel.UserDto.User.Id,
                            userAddAjaxModel.UserDto.User.UserName,
                            userAddAjaxModel.UserDto.User.Email,
                            userAddAjaxModel.UserDto.User.PhoneNumber,
                            `<img src="/img/${userAddAjaxModel.UserDto.User.Picture}" class="my-image-table" alt="${userAddAjaxModel.UserDto.User.UserName}" />`,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span> </button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span> </button>
                            `
                       ]).node();
                        const jqueryTableRow = $(newTableRow);//Jquery obyektine cevirdiy
                        jqueryTableRow.attr('name', `${userAddAjaxModel.UserDto.User.Id}`);
                        datatable.row(newTableRow).draw();
                        toastr.success(`${userAddAjaxModel.UserDto.Message}`, 'Uğurlu Əməliyyat');
                    } else {
                        let summarytext = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summarytext = `*${text}\n`;
                        });
                        toastr.warning(summarytext);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    });
    //Ajax POST / Posting the FormData as UserAddDto ends from here

    //Ajax POST / Deleting a User starts from here

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const userName = tableRow.find('td:eq(1)').text();
        console.log(userName);
        Swal.fire({
            title: 'Silmək istədiyinizdən əminsiniz?',
            text: `${userName} adlı istifadeci silinəcəkdir!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Bəli, silmək istəyirəm.',
            cancelButtonText: 'Xeyr, silmək istəmirəm.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { userId: id },
                    url: '/Admin/User/Delete/',
                    success: function (data) {
                        const userDto = jQuery.parseJSON(data);
                        if (userDto.ResultStatus === 0) {
                            Swal.fire(
                                'Istifadeci silindi!',
                                `${userDto.User.UserName} adlı istifadeci uğurla silindi`,
                                'success'
                            );
                            datatable.row(tableRow).remove().draw();
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Xəta Baş Verdi...',
                                text: `${userDto.Message}`,
                            });
                        };
                    },
                    error: function (err) {
                        toastr.error(`${err.responseText}`, "Xeta");
                    }
                });
            };
        });
    });
    //Ajax POST / Deleting a User ends from here

    //Ajax GET / Updating a User starts from here

    $(function () {
        const url = '/Admin/User/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            console.log(id);
            $.get(url, { userId: id }).done(function (data) {
                console.log(data);
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function (err) {
                toastr.error('Xeta');
            });
        });
         //Ajax GET / Updating a User ends from here

        //Ajax POST / Updating a User starts from here

        placeHolderDiv.on('click', "#btnUpdate", function (event) {
            event.preventDefault();
            const form = $('#form-user-update');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0));
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType: false,
                success: function (data) {
                    const userUpdateAjaxModel = jQuery.parseJSON(data);
                    if (userUpdateAjaxModel.UserDto !== null) {
                        const id = userUpdateAjaxModel.UserDto.User.Id;
                        const tableRow = $(`[name="${id}"]`);
                    }
                    const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        datatable.row(tableRow).data([
                            userUpdateAjaxModel.UserDto.User.Id,
                            userUpdateAjaxModel.UserDto.User.UserName,
                            userUpdateAjaxModel.UserDto.User.Email,
                            userUpdateAjaxModel.UserDto.User.PhoneNumber,
                            `<img src="/img/${userUpdateAjaxModel.UserDto.User.Picture}" class="my-image-table" alt="${userUpdateAjaxModel.UserDto.User.UserName}" />`,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span> </button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span> </button>
                            `
                        ]);
                        tableRow.attr("name", `${id}`);
                        datatable.row(tableRow).invalidate();// invalidate-deyishikliyden xeberdar olur datatable
                        toastr.success(`${userUpdateAjaxModel.UserDto.Message}`, "Uğurlu Əməliyyat!")
                    } else {
                        let summarytext = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summarytext = `*${text}\n`;
                        });
                        toastr.warning(summarytext);
                    };
                },
                error: function (err) {
                    toastr.error(err.responseText,"Xəta!");
                }
            });
        });

        //Ajax POST / Updating a User ENDS from here
    });
    //Document Ready ends here
});