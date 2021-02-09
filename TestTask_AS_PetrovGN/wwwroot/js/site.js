
$(document).ready(function () {
    checkDB();

    $('body').on('click', '.btn-add-data', function () {
        $.ajax({
            url: '/ApiOrganization/AddNewData',
            success: function () {
                getData(renderData);
            },
            error: function () {
                getError("Ошибка при добавлении данных в БД");
            }
        });
    });
    // Модалка редактирования
    let popupOptions = {
        width: "400px",
        height: "300px",
        contentTemplate: function () {
            // берем макет окна
            return '<h3>Error NoContent</h3>';
        },
        visible: false,
        dragEnabled: false,
        closeOnOutsideClick: true
    };

    $('body').on('click', '.btn-edit', function () {
        console.log("xxxx");
        let empId = Number.parseInt($(this).siblings('.selected_e_id').val());
       
        $.ajax({
            url: '/Organization/GetModal',
            data: {
                empId: empId
            },
            success: function (data) {
                popupOptions.contentTemplate = data;
                $(".popup-property-details").remove();
                var container = $("<div />")
                    .addClass("popup-property-details")
                    .appendTo($("#popup"));
                popup = container.dxPopup(popupOptions).dxPopup("instance");
                popup.option("title", "Редактирование");
                popup.show();
            },
            error: function () {
                getError('Error ошибка при загрузки модели для взвешивания');
            }
        });
    });

    $('body').on('click', '.btn-del', function () {
        let empId = Number.parseInt($(this).siblings('.selected_e_id').val());
        let thisis = $(this);
        $.ajax({
            url: `/ApiOrganization/DeleteEmployee?id=${empId}`,
            success: function () {
                console.log(thisis);
                $(thisis).parent().parent().remove();
                getSuccess(`Удален сотрудник с id ${empId}`);
            },
            error: function () {
                getError('Не получилось удалить его((');
            }
        });
    })
});

function checkDB() {
    $.ajax({
        url: '/ApiOrganization/CheckDb',
        success: function () {
            getData(renderData);
        },
        error: function () {
            // добавляем кнопу 
            $('.main-container').append('<div class="my-btn btn-add-data">Добавить данные в БД</div>')
        }
    })
}

/**
 * Получает и рендерит данные
 * @param {any} calback
 */
function getData(calback) {
    $.ajax({
        url: '/ApiOrganization/GetAllDepartments',
        success: function (data) {
            renderData(data);
            getSuccess("Данные получены")
        },
        error: function () {
            getError("Ошибка получения данных")
        }
    });
}

function renderData(data) {
    data.forEach(function (value ,i) {
        console.log(value);
        let depString = renderDep(value);
        $('.main-container').append(depString);
    }); 
}

function renderDep(data) {
    let depString = `
<div class="deps_cantainer">
        <h3>${data.title}</h3>
        <div class="dep_data_container">
            <div class="dep-data">Сотрудников: ${data.employeeCount}<span></span></div>
            <div class="dep-data">Средняя ЗП: ${data.midSalary}<span></span></div>
        </div>
        <h5>Сотрудники</h5>
`;
    data.employees.forEach(function (value, i) {
        let empStr = renderEmpString(value);
        depString += empStr;
    });
    depString += `</div>`;
    return depString;
}

function renderEmpString(data) {
    console.log(data);
    let str = `<div class="row emp-raw">
            <div class="col-3 center_text">${data.id}</div>
            <div class="col-3 center_text">${data.name}</div>
            <div class="col-3 center_text">${data.salary}</div>
            <div class="col-3 center_text">
        <span class="btn-edit my_btn btn-danger">Ред</span>
        &nbsp;
        <span class="btn-del my_btn btn-info">Удал</span>
        <input class="selected_e_id" type="hidden" value="${data.id}" />
    </div>
</div>`;
    return str;
}



//Всякое
function getSuccess(message) {
    DevExpress.ui.notify(message, "Success", 2000)
}
function getError(message) {
    DevExpress.ui.notify(message, "error", 2000)
}