var currentpage = 1;
var totalpage = 0;
$(document).ready(function () {
    var PRC = new Products();

})
class Products {
    constructor() {
        this.loadData();
        this.loadTotal();
        this.initEnvents();
    }
    initEnvents() {
        $('.Add').click(this.AddOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('.add-title-icon').click(this.iconOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCCancel').click(this.btnCCancelOnClick.bind(this));
        $('.change-title-icon').click(this.CiconOnClick.bind(this));
        $('#btnCSave').click(this.btnCSaveOnClick.bind(this));
        $("#txtID").blur(this.checkID.bind(this));
        $('.Change').click(this.ChangeOnClick.bind(this));
        $('.Delete').click(this.DeleteOnClick.bind(this));
        $('#BtnFind').click(this.FindOnClick.bind(this));
        $('#First').click(this.FirstOnClick).bind(this);
        $('#Previous').click(this.PreviousOnClick).bind(this);
        $('#Current').click(this.CurrentOnClick).bind(this);
        $('#Next').click(this.NextOnClick).bind(this);
        $('#Last').click(this.LastOnClick).bind(this);

    }
    loadTotal() {
        $.ajax({
            url: "/products/total",
            method: "GET",
            data: "", // tham so truyen vao qua body 
            contentType: "",
            dataType: ""
        }).done(function (response) {
            totalpage = Math.ceil(response/5);
            debugger;
        }).fail(function(response) {
        debugger;
    })
    }
    loadData() {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/Page/0/5",
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
    Find_Name(Fprd_find) {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/" + Fprd_find + "/Name",
            method: "GET"
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
    Find_Brand(Fprd_find) {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/" + Fprd_find + "/Brand",
            method: "GET"
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
    DeleteOnClick() {
        var self = this;
        var trSelected = $('tr.row-selected');
        if (trSelected.length > 0) {
            var CID = $(trSelected).children()[0].textContent;
            // lay thong tin
            $.ajax({
                url: "/products/" + CID,
                method: "DELETE"
            }).done(function (res) {
                debugger;
                if (res) {
                    self.loadData();
                    alert("Xoa thanh cong");
                } else { alert("Du lieu khong con tren he thong") }
            }).fail(function () {
                debugger;
            })
        } else {
            alert('Vui lòng chọn product cần xóa !');
        }
    }
    ChangeOnClick() {
        var trSelected = $('tr.row-selected');
        if (trSelected.length > 0) {
            $('.dialog').show();
            $('.dialog-change').show();
            var CID = $(trSelected).children()[0].textContent;
            // lay thong tin
            $.ajax({
                url: "/products/" + CID,
                method:"GET"
            }).done(function (res) {
                if (!res) {
                    alert('Khong co thong tin product nay');
                } else {
                    $("#txtCID").val(res["ID"]);
                    $("#txtCCode").val(res["Code"]);
                    $("#txtCName").val(res["Name"]);
                    $("#txtCCategory").val(res["Category"]);
                    $("#txtCBrand").val(res["Brand"]);
                    $("#txtCType").val(res["Type"]);
                    $("#txtCDescription").val(res["Description"]);
                }
            }).fail(function () {
                debugger;
            })
        } else {
            alert('Chọn dòng cần sửa !');
        }
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
    FirstOnClick() {
        $.ajax({
            url: "/products/Page/0/5",
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
    PreviousOnClick() {
        if (currentpage != 1) {
            currentpage = currentpage - 1;
            var ignore = (currentpage - 1) * 5;
            $.ajax({
                url: "/products/Page/" + ignore + "/5",
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
    }
    CurrentOnClick() {
        alert("Đang ở Page" + currentpage);
    }
    NextOnClick() {
        if (currentpage < totalpage) {
            currentpage = currentpage + 1;
            var ignore = (currentpage - 1) * 5;
            $.ajax({
                url: "/products/Page/" + ignore + "/5",
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
    }
    LastOnClick() {
        currentpage = totalpage;
        var ignore = (currentpage - 1) * 5;
        $.ajax({
            url: "/products/Page/" + ignore + "/5",
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
    btnSaveOnClick() {
        //kiem tra du lieu nhap tren form
        var tID = $("#txtID").val();
        if (!tID) {
            $("#txtID").addClass('error');
            $("#txtID").attr("title", "Thong tin bat buoc nhap");
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
            _product.Description = $("#txtDescription").val();
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
                alert("Them thanh cong")
            }).fail(function (res) {
                debugger;
            })
        }

    }
    btnCSaveOnClick() {
        //lay thong tin
            var Cprd = {};
            var self = this;
            Cprd.ID = $("#txtCID").val();
            Cprd.Code = $("#txtCCode").val();
            Cprd.Name = $("#txtCName").val();
            Cprd.Category = $("#txtCCategory").val();
            Cprd.Brand = $("#txtCBrand").val();
            Cprd.Type = $("#txtCType").val();
            Cprd.Description = $("#txtCDescription").val();
            debugger;

            //luu du lieu vao database
            /*data.push(_product);*/
            $.ajax({
                url: "/products/" + Cprd.ID,
                method: "PUT",
                data: JSON.stringify(Cprd),
                contentType: "application/json",
                dataType: "json"
            }).done(function (res) {
                debugger;
                self.loadData();
                $('.dialog').hide();
                $('.dialog-change').hide();
                alert("Sua thanh cong")
            }).fail(function (res) {
                debugger;
            })
    }
    FindOnClick() {
        //lay thong tin tim kiem
        var Fprd_find = $("#txt-Find").val();
        var self = this;
        // tim kiem API
        if (Fprd_find != '') {
            if ($("#Menu").val() == "Name") {
                self.Find_Name(Fprd_find);
            }
            else if ($("#Menu").val() == "Brand") {
                self.Find_Brand(Fprd_find);
            }
            else {
                alert("NONE");
            }
        }
        else {
            self.loadData();
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
$(document).on('click', 'table#ptable tbody tr', function () {
    $(this).siblings('.row-selected').removeClass('row-selected'); // phương thức siblings được jQuery cung cấp sẵn
    // add class đánh dấu dòng hiện tại được chọn:
    this.classList.add('row-selected');
});