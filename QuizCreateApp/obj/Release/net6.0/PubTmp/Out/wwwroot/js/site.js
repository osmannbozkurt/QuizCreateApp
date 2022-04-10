


function showMessage({type, title}) {

    Swal.fire({
        position: 'top-end',
        icon: type,
        title: title,
        showConfirmButton: false,
        timer: 4500
    })

}