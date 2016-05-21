function showdialog(type_msg, title, msg, url, name_OK, name_Cancel) {
    if (name_OK == null) {
        name_OK = "Ok"
    }
    if (name_Cancel == null) {
        name_Cancel = "Cancel";
    }
    var html = "";
    html += "<div class='modal fade' id='modal_Mensajes' tabindex='-1' role='dialog' aria-labelledby='modal_label' aria-hidden='true'>";
    html += "<div class='modal-dialog' style='width: 350px; margin: 13% auto;'>";
    html += "<div class='modal-content'>";
    html += "<div class='modal-body'>";
    html += "<fieldset style='width: 100%; margin: 0px;padding: 0px;'>";

    html += "<table id='TableModal'>";
    html += "<tr id='TableHeaderModal'><td colspan='3' class='text-center'><b>" + title + "</b></td></tr>";



    switch (type_msg) {
        case 'I':
            // Information
            html += "<tr><td><img class='margin' style='width:80px;' src='" + url + "public/images/img_msg_info.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr></table>";
            html += "<br></fieldset></div></div></div></div>";
            break;
        case 'Q':
            // Error
            html += "<tr><td><img class='margin' style='width:80px;' src='" + url + "public/images/img_msg_question.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnSi' name='BtnSi' class='btn btn-info btn-sm'>" + name_OK + "</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' id='BtnNo' name='BtnNo' class='btn btn-warning btn-sm'>" + name_Cancel + "</button></td></tr></table>";
            html += "<br></fieldset></div></div></div></div>";
            break;
        case 'W':
            // Warning
            html += "<tr><td><img class='margin' style='width:80px;' src='" + url + "public/images/img_msg_warning.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr></table>";
            html += "<br></fieldset></div></div></div></div>";
            break;
        case 'E':
            // Error
            html += "<tr><td><img class='margin' style='width:80px;' src='" + url + "public/images/img_msg_error.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr></table>";
            html += "<br></fieldset></div></div></div></div>";
            break;
    }
    $("#msg-dialog").html(html);
    $('#modal_Mensajes').modal({ backdrop: 'static', keyboard: false })
    $('#modal_Mensajes').modal('show');
}
        
function Editdialog(type_msg, title, msg, url, name_OK, name_Cancel) {

    if (name_OK == null) {
        name_OK = "Ok"
    }
    if (name_Cancel == null) {
        name_Cancel = "Cancel";
    }

    var html = "";
    html += "<tr id='TableHeaderModal'><td colspan='3' class='text-center'><b>" + title + "</b></td></tr>";
    switch (type_msg) {
        case 'I':
            // Information
            html += "<tr><td><img class='img-responsive' src='" + url + "public/images/img_msg_info.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr>";
            break;
        case 'Q':
            // Error
            html += "<tr><td><img class='img-responsive' src='" + url + "public/images/img_msg_question.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnSi' name='BtnSi' class='btn btn-info btn-sm'>" + name_OK + "</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button type='button' id='BtnNo' name='BtnNo' class='btn btn-warning btn-sm'>" + name_Cancel + "</button></td></tr>";

            break;
        case 'W':
            // Warning
            html += "<tr><td><img class='img-responsive' src='" + url + "public/images/img_msg_warning.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr>";

            break;
        case 'E':
            // Error
            html += "<tr><td><img class='img-responsive' src='" + url + "public/images/img_msg_error.png'> </td><td colspan='2' class='text-left'><b>" + msg + "</b></td></tr>";
            html += "<tr><td colspan='3' class='text-center'><button type='button' id='BtnAceptar' name='BtnAceptar' class='btn btn-primary btn-sm BtnAceptar' data-dismiss='modal'>" + name_OK + "</button></td></tr>";

            break;
    }
    return html;
}

//function DisableTabIndex(iTab) {
//    $("ul.nav li:nth-child(" + iTab + ")").removeClass("active").addClass('disabled');
//    $("ul.nav li:nth-child(" + iTab + ")").find('a').removeAttr("data-toggle");
//}

//function MoveTabIndex(iTab) {
//    $("ul.nav-tabs li:eq(" + iTab + ") a").tab('show');
//}

//function EnableTabIndex(iTab) {
//    $("ul.nav li:nth-child(" + iTab + ")").removeClass("disabled").addClass('active');
//    $("ul.nav li:nth-child(" + iTab + ")").find('a').attr("data-toggle", "tab");
//}

//function EnableTabIndex_(iTab) {
//    $(".subTab ul.nav li:nth-child(" + iTab + ")").removeClass("disabled").addClass('active');
//    $(".subTab ul.nav li:nth-child(" + iTab + ")").find('a').attr("data-toggle", "tab");
//}

//function DisableTabIndex_(iTab) {
//    //$(".subTab ul.nav li:nth-child(" + iTab + ")").removeClass("active").addClass('disabled');
//    //$(".subTab ul.nav li:nth-child(" + iTab + ")").find('a').removeAttr("data-toggle");
//}

function DisableTabIndex(iTab) {
    $("#TabPrincipal li:nth-child(" + iTab + ")").removeClass("active").addClass('disabled');
    $("#TabPrincipal li:nth-child(" + iTab + ")").find('a').removeAttr("data-toggle");
}

function MoveTabIndex(iTab) {
    $("#TabPrincipal li:eq(" + iTab + ") a").tab('show');
}

function EnableTabIndex(iTab) {
    $("#TabPrincipal li:nth-child(" + iTab + ")").removeClass("disabled").addClass('active');
    $("#TabPrincipal li:nth-child(" + iTab + ")").find('a').attr("data-toggle", "tab");
}


function DisableTabIndex_Sub(iTab) {
    $("#subTabPrincipal li:nth-child(" + iTab + ")").removeClass("active").addClass('disabled');
    $("#subTabPrincipal li:nth-child(" + iTab + ")").find('a').removeAttr("data-toggle");
}

function MoveTabIndex_Sub(iTab) {
    $("#subTabPrincipal li:eq(" + iTab + ") a").tab('show');
}

function EnableTabIndex_Sub(iTab) {
    $("#subTabPrincipal li:nth-child(" + iTab + ")").removeClass("disabled").addClass('active');
    $("#subTabPrincipal li:nth-child(" + iTab + ")").find('a').attr("data-toggle", "tab");
}
function LoadComboSystemParameter(base_url, Combo, Grupo, Text, OK) {
    if (Text == null) {
        Text = "Select";
    }
    var prmParameter = {};
    prmParameter.IPARAMETERID = 0;
    prmParameter.IGROUPID = Grupo;
    prmParameter.VVALUE = 0;
    prmParameter.SVISIBLE = 0;
    $.ajax({
        url: base_url + 'Security/SystemParameterSearch',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        traditional: true,
        data: JSON.stringify(prmParameter),
        async: false,
        cancel: false,
        success: function (data) {
            Combo.empty();
            Combo.append("<option value='0'>-- " + Text + " --</option>");
            if (data.objResult.iResultId == OK) {
                $.each(data.lObjBE, function (i, row) {
                    var $option = $('<option>');
                    $option.val(row.IPARAMETERID);
                    $option.html(row.VDESCRIPTION);
                    Combo.append($option);

                });
            }
        }
    });
}

function LoadSystemParameter(base_url, Grupo, OK) {
    var prmParameter = {};
    prmParameter.IPARAMETERID = 0;
    prmParameter.IGROUPID = Grupo;
    prmParameter.VVALUE = 0;
    prmParameter.SVISIBLE = 0;

    var oSystemParameter = null;
    $.ajax({
        url: base_url + 'Security/SystemParameterSearch',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        traditional: true,
        data: JSON.stringify(prmParameter),
        async: false,
        cancel: false,
        success: function (data) {
            if (data.objResult.iResultId == OK) {                
                oSystemParameter = data.lObjBE;
            }
        }
    });
    return oSystemParameter;
}

function LoadSystemParameterId(base_url, Id) {
   
    var prmParameter = {};
    prmParameter.IPARAMETERID = Id;
    prmParameter.IGROUPID = 0;
    prmParameter.VVALUE = 0;
    prmParameter.SVISIBLE = 0;

    var oSystemParameter;
    $.ajax({
        url: base_url + 'Security/SystemParameterSearch',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        traditional: true,
        data: JSON.stringify(prmParameter),
        async: false,
        cancel: false,
        success: function (data) {

            oSystemParameter = data;
        }
    });
    return oSystemParameter;
}

function ValidarTextFielt(input) {
    var x = input.value.trim();
    var bolValida = true;
    if (x.length == 0) {
        //input.style.border = "1px solid Red"; 
        //input.style.border = "";
        bolValida = false;
    }
    else {
        //input.style.border = "";
    }
    return bolValida;
}

function ValidarTextFielt_Quitar(input) {
    input.style.border = "";
}

function ddlcontrolError(Input) {
        var x = Input.value;
        var bolValida = true;
        if (x == '0' || x == '00' || x == '') {
            //Input.style.border = "1px solid Red";
            bolValida = false;
        }
        else {
            //Input.style.border = "";
        }
        return bolValida;
    }

function convertStringToDate(dateString) { // format ---->  mm/dd/yyyy - hh:ii:ss
        var fecha = new Date(dateString.substring(6, 10) + '-' + dateString.substring(0, 2) + '-' + dateString.substring(3, 5));
        if (dateString.length >= 15) fecha.setHours(parseInt(dateString.substring(13, 15)));
        if (dateString.length >= 18) fecha.setMinutes(parseInt(dateString.substring(16, 18)));
        if (dateString.length >= 21) fecha.setSeconds(parseInt(dateString.substring(19, 21)));
        return fecha;
    }

function AsignarStartDateTimePicker(DateChange, DateSetStart) { 
        $(DateChange).datetimepicker().on('change', function () {
            var InitialDateTimePickerString = $(DateChange).find("input").val();
            var formatoHMS = "mm/dd/yyyy";
            if (InitialDateTimePickerString.length >= 15) formatoHMS = "mm/dd/yyyy - hh";
            if (InitialDateTimePickerString.length >= 18) formatoHMS = "mm/dd/yyyy - hh:ii";
            if (InitialDateTimePickerString.length >= 21) formatoHMS = "mm/dd/yyyy - hh:ii:ss";
            var InitialFecha = convertStringToDate(InitialDateTimePickerString);
            InitialFecha.setDate(InitialFecha.getDate() + parseInt(1));
            if ($(DateSetStart).find("input").val() != '') {
                var Finalfecha = convertStringToDate($(DateSetStart).find("input").val());
                if (InitialFecha >= Finalfecha) {
                    $(DateSetStart).find("input").val('');
                }
            }
            $(DateSetStart).datetimepicker("remove");
            $(DateSetStart).datetimepicker({
                language: 'en-US',
                use24hours: true,
                format: formatoHMS,
                autoclose: true,
                todayBtn: true,
                pickerPosition: "bottom-left",
                startDate: InitialFecha
            });
        });
    }


function AsignarStartDatePicker(DateChange, DateSetStart) {
        $(DateChange).datepicker().on('change', function () {
            var InitialFecha = convertStringToDate($(DateChange).find("input").val());
            InitialFecha.setDate(InitialFecha.getDate() + parseInt(2));
            if ($(DateSetStart).find("input").val() != '') {
                var Finalfecha = convertStringToDate($(DateSetStart).find("input").val());
                if (InitialFecha >= Finalfecha) {
                    $(DateSetStart).find("input").val('');
                }
            }
            $(DateSetStart).datepicker("remove");
            $(DateSetStart).datepicker({
                format: "mm/dd/yyyy",
                autoclose: true,
                todayBtn: true,
                startDate: InitialFecha
            });
        });
    }


function RadioGroupValue(nameDiv,nameRadio) {
    $(nameDiv).on('change', 'input[name=' + nameRadio + ']:radio', function (e) {
        var valrad = $('input:radio[name=' + nameRadio + ']:checked').val();
        return valrad;
    });
}

function inputOnlyAlphabetic(control) {
    $("#" + control).keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: Ctrl+C
            (e.keyCode == 67 && e.ctrlKey === true) ||
            // Allow: Ctrl+X
            (e.keyCode == 88 && e.ctrlKey === true) ||
            // Allow: home, end, left, right...
            (e.keyCode >= 35 && e.keyCode <= 39) ||
            (e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)
            ) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        //if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        //}
    });
}

function DesactivarControlesAndValidacion(form, control, estado) {
    for (var i = 0; i < control.length; i++) {
        $('#' + control[i]).prop('disabled', estado);
        $('#' + form).data('bootstrapValidator').enableFieldValidators(control[i], !estado);
    }
}

function DesabledControl(control, estado) {
    for (var i = 0; i < control.length; i++) {
        $('#' + control[i]).prop('disabled', estado);
    }
}

function DesabledControlClass(control, estado) {
    for (var i = 0; i < control.length; i++) {
        $('.' + control[i]).prop('disabled', estado);
    }
}

function ReadOnlyControl(control, estado) {
    for (var i = 0; i < control.length; i++) {
        $('#' + control[i]).prop('readonly', estado);
    }
}
 