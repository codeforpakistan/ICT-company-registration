
$(function () {
    $('[data-toggle="popover"]').popover({
        placement: 'top',
        trigger: 'hover'
    });
    $('.select2').select2();
    $(".form-control").attr("autoComplete", "Off");   
    $('.datepicker').datepicker({
        dateFormat: 'dd-mm-yyyy',
        formate:'dd-mm-yyyy',
        autoclose: true,
        todayHighlight: true,
        orientation: 'bottom'
    });


    $("input.numbers").keypress(function (event) {
        return /\d/.test(String.fromCharCode(event.keyCode));
    });

    $('input.chkone').on('change', function () {
        $('input.chkone').not(this).prop('checked', false);
    });
});

function searchTable(inputId,tableId) {
    // Declare variables
    var input, filter, table, tr, td, i;
    input = document.getElementById(inputId);
    filter = input.value.toUpperCase();
    table = document.getElementById(tableId);
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td");
        for (j = 0; j < td.length; j++) {
            let tdata = td[j];
            if (tdata) {
                if (tdata.innerHTML.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = "";
                    break;
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
}




var _redirectUrl = null;
var NGO = function () {
    this.Validation = {
        Check: {
            isNullOrEmpty: function (_obj) {
                if (_obj == undefined || _obj == "" || _obj == "undefined")
                    return true;
                else
                    return false;
            },
            isNumber: function (_obj) {
                if (isNaN(_obj) || _obj == undefined || _obj == "" || _obj == "undefined")
                    return false;
                else
                    return true;
            }

        }
    },
        this.HTML = {

            Loader: {

                Show: function (_obj) {

                    if (ily.Validation.Check.isNullOrEmpty(_obj)) {

                        $.blockUI({ message: '<span class="text-primary">Please wait<br/><i class= "far fa-spinner fa-spin fa-2x" aria-hidden="true" ></i ></span>', title: "please wait", baseZ: 2000 });
                    }
                    else {
                        $(_obj).block({ message: '<span class="text-primary">Please wait<br/><i class= "far fa-spinner fa-spin fa-2x" aria-hidden="true" ></i ></span>', title: "please wait", baseZ: 2000 });
                    }

                },
                Hide: function (_obj) {

                    if (ily.Validation.Check.isNullOrEmpty(_obj))
                        $.unblockUI();
                    else
                        $(_obj).unblock();
                }
            },
            Alert: {
                Show: function (_obj, callback) {
                    var _options = {
                        type: "success",
                        title: "success",
                        message: "",
                        showCancelButton: false,
                        confirmButtonText: "Ok"
                    }
                    if (!ily.Validation.Check.isNullOrEmpty(_obj)) {
                        if (!ily.Validation.Check.isNullOrEmpty(_obj.type))
                            _options.type = _obj.type;
                        if (!ily.Validation.Check.isNullOrEmpty(_obj.title))
                            _options.title = _obj.title;
                        if (!ily.Validation.Check.isNullOrEmpty(_obj.message))
                            _options.message = _obj.message;
                        if (!ily.Validation.Check.isNullOrEmpty(_obj.showCancelButton))
                            _options.showCancelButton = _obj.showCancelButton;
                        if (!ily.Validation.Check.isNullOrEmpty(_obj.confirmButtonText))
                            _options.confirmButtonText = _obj.confirmButtonText;
                    }
                    if (!ily.Validation.Check.isNullOrEmpty(callback)) {
                        Swal.fire(
                            {
                                title: _options.title,
                                html: _options.message,
                                icon: _options.type,
                                showCancelButton: _options.showCancelButton,
                                confirmButtonText: _options.confirmButtonText

                            }).then(function (result) {
                                if (result.value) {
                                    swal.close();
                                    callback();
                                }
                            });
                    }
                    else {

                        Swal.fire({ title: _options.title, html: _options.message, icon: _options.type });
                    }
                }
        },
            
        Confirm: {
        Show: function (_obj, callback) {
            var _options = {
                type: "warning",
                title: "",
                message: "Do you want to perform this action",
                showCancelButton: true,
                confirmButtonText: "Yes",             
                cancelButtonText:"No"
            }
            if (!ily.Validation.Check.isNullOrEmpty(_obj)) {
                if (!ily.Validation.Check.isNullOrEmpty(_obj.type))
                    _options.type = _obj.type;
                if (!ily.Validation.Check.isNullOrEmpty(_obj.title))
                    _options.title = _obj.title;
                if (!ily.Validation.Check.isNullOrEmpty(_obj.message))
                    _options.message = _obj.message;
                if (!ily.Validation.Check.isNullOrEmpty(_obj.showCancelButton))
                    _options.showCancelButton = _obj.showCancelButton;
                if (!ily.Validation.Check.isNullOrEmpty(_obj.confirmButtonText))
                    _options.confirmButtonText = _obj.confirmButtonText;
                if (!ily.Validation.Check.isNullOrEmpty(_obj.cancelButtonText))
                    _options.cancelButtonText = _obj.cancelButtonText;
            }
            //
            Swal.fire({
                title: _options.title,
                html: _options.message,
                icon: _options.type,
                showCancelButton: _options.showCancelButton,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: _options.cancelButtonText,
                confirmButtonText: _options.confirmButtonText,
                reverseButtons: true
            }).then(function (result) {
                if (result.value) {
                    callback();
                }
            });
            //


        }
    }
        }

}

NGO.prototype = {
    ApplyOption: function (option) {

        var o = option;
        this._element = null;
        this._id = null;
        this._mode = null;
        this._text = null;
        this.title = null;
        this._sweetAlert = null;
        this._toast = null;
        this._heading = null;
        this._icon = null;
        this._operation = null;
        this._redirect = false;
        this._class = null;
        this._type = null;

        for (var i = 0; i < o.itemList.length; i++) {
            console.log(o.itemList[i].operation);
            if (o.itemList[i].mode == "id")
                this._element = $('#' + o.itemList[i].elem);
            else if (o.itemList[i].mode == 'class')
                this._element = $('.' + o.itemList[i].elem);
            else if (o.itemList[i].mode = 'elem')
                this._element = o.itemList[i].elem;
            else if (o.itemList[i].mode = 'tag')
                this._element = o.itemList[i].elem;
            console.log(o.itemList[i].elem);
            this._heading = o.itemList[i].heading;
            this._title = o.itemList[i].title;
            this._text = o.itemList[i].text;
            this._icon = o.itemList[i].icon;
            this._redirect = o.itemList[i].redirect;
            _redirectUrl = o.itemList[i].redirectUrl;
            this._type = o.itemList[i].type;

            this._operation = o.itemList[i].operation;
            this._class = o.itemList[i].className

            if (this._operation == 'toast') {
                this.showToast();
            }
            else if (this._operation == "sweetAlert") {
                this.showSweetAlert();
            }
            else if (this._operation == "changeText") {
                this.changeText();
            }
            else if (this._operation == 'showLoader') {
                this.showLoader();
            }
            else if (this._operation == 'hideLoader') {
                this.hideLoader();
            }
            else if (this._operation == "changeText") {
                this.changeText();
            }
            else if (this._operation == "addClass") {
                this.AddClass();
            }
            else if (this._operation == "removeClass") {
                this.RemoveClass();
            }
            else if (this._operation == "hide" || this._operation == "remove") {
                this.FadeOut();
            }
            else if (this._operation == 'show') {
                this.FadeIn();
            }
        }
    },
    FadeOut: function () {
        this._element.fadeOut(600);
    },
    FadeIn: function () {
        this._element.fadeIn('slow');
    },
    AddClass: function () {
        $(this._element).addClass(this._class)
    },
    RemoveClass: function () {
        this._element.removeClass(this._class);
    },
    showLoader: function () {
        this._element.show();
    },
    hideLoader: function () {
        this._element.hide();
    },

    changeText: function () {
        this._element.text(this._text);
    },
    showToast: function () {
        $.toast({
            heading: this._heading,
            text: this._text,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: this._icon,
            hideAfter: 3500,
            stack: 6
        });
    },
    showSweetAlert: function () {

        if (this._redirect == undefined || this._redirect == false) {
            Swal.fire(this._heading, this._text, this._type);
        }
        else if (this._redirect == true) {
            Swal.fire(
                {
                    title: this._heading,
                    text: this._text,
                    type: this._type,
                    showCancelButton: false
                }).then(function (result) {
                    if (result.value) {
                        window.location = _redirectUrl;
                    }
                });

        }
    }


};


var ily = new NGO();

