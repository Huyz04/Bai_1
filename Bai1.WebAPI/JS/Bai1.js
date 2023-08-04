
$(document).ready(function () {
    var PRC = new Products();

})
class Products {
    constructor() {
        this.loadData();
        this.initEnvents();
    }
    initEnvents() {
        $('.Add').click(this.AddOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('.add-title-icon').click(this.iconOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCCancel').click(this.btnCCancelOnClick.bind(this));
        $('.change-title-icon').click(this.CiconOnClick.bind(this));
        $('#btnCSave').click(this.btnSaveOnClick.bind(this));
        $("#txtID").blur(this.checkID.bind(this));
        $('.Change').click(this.ChangeOnClick.bind(this));
    }
    loadData() {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/all",
            method: "GET",
            data: "", // tham so truyen vao qua body 
            contentType: "",
            dataType: ""
        }).done(function (response) {
            $('.Content tbody').empty();
            $.each(response, function (index, item) {
                var trHTML = $(` <tr class="row">
                        <td>`+ item.ID + `</td>
                        <td>`+ item.Code + `</td>
                        <td>`+ item.Name + `</td>
                        <td>`+ item.Category + `</td>
                        <td>`+ item.Brand + `</td>
                        <td>`+ item.Type + `</td>
                        <td>`+ item.Description + `</td>
                    </tr>`);
                $('.Content tbody').append(trHTML);
            })
        }).fail(function (response) {
            debugger;
        })
    }
    AddOnClick() {
        $('.dialog').show();
        $('.dialog-add').show();
        $('#txtID').focus();
        $("input").val("");
    }
    ChangeOnClick() {
        $('.dialog').show();
        $('.dialog-change').show();
        $('#txtID').focus();
        $("input").val("");
    }
    btnCancelOnClick() {
        $('.dialog').hide();
        $('.dialog-add').hide();
    }
    iconOnClick() {
        $('.dialog').hide();
        $('.dialog-add').hide();
    }
    btnCCancelOnClick() {
        $('.dialog').hide();
        $('.dialog-change').hide();
    }
    CiconOnClick() {
        $('.dialog').hide();
        $('.dialog-change').hide();
    }
    btnSaveOnClick() {
        //kiem tra du lieu nhap tren form
        var tID = $("#txtID").val();
        if (!tID) {
            $("#txtID").addClass('error');
            $("#txtID").attr("title","Thong tin bat buoc nhap");
        } else {
            $("#txtID").removeClass('error');
            $("#txtID").removeAttr("title");
        }
        //lay thong tin
        if (tID) {
            var _product = {}; 
            var self = this;
            _product.ID = $("#txtID").val();
            _product.Code = $("#txtCode").val();
            _product.Name = $("#txtName").val();
            _product.Category = $("#txtCategory").val();
            _product.Brand = $("#txtBrand").val();
            _product.Type = $("#txtType").val();
            _product.Decription = $("#txtDecription").val();
            debugger;

            //luu du lieu vao database
            /*data.push(_product);*/
            $.ajax({
                url: "/products",
                method: "POST",
                data: JSON.stringify(_product),
                contentType: "application/json",
                dataType: "json"
            }).done(function (res) {
                self.loadData();
                $('.dialog').hide();
                $('.dialog-add').hide();
            }).fail(function (res) {
                debugger;
            })
            //load lai du lieu

        }

    }

    checkID() {
        var tID = $("#txtID").val();
        if (!tID) {
            $("#txtID").addClass('error');
            $("#txtID").attr("title", "Thong tin bat buoc nhap");
        } else {
            $("#txtID").removeClass('error');
            $("#txtID").removeAttr("title");
        }
    }
}
// Lấy tất cả các dòng trong bảng
    const rows = document.querySelectorAll('#ptable tbody tr');

  // Thêm sự kiện click cho từng dòng
  rows.forEach(row => {
        row.addEventListener('click', () => {
            // Loại bỏ lớp 'selected' từ tất cả các dòng khác
            rows.forEach(otherRow => {
                if (otherRow !== row && otherRow.classList.contains('selected')) {
                    otherRow.classList.remove('selected');
                }
            });
            row.classList.add('selected')
        });
  });