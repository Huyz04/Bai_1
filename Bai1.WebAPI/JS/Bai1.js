var Page = 1;
var PageSize = 5;
var TotalPage = 0;
$(document).ready(function () {
    var PRC = new Products();
})
class Products {
    constructor() {
        this.loadTotal();
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
        $('#btnCSave').click(this.btnCSaveOnClick.bind(this));
        $("#txtID").blur(this.checkID.bind(this));
        $('.Change').click(this.ChangeOnClick.bind(this));
        $('.Delete').click(this.DeleteOnClick.bind(this));
        $('#BtnFind').click(this.FindOnClick.bind(this));
        $('#First').click(this.FirstOnClick.bind(this));
        $('#Previous').click(this.PreviousOnClick.bind(this));
        $('#Current').click(this.CurrentOnClick.bind(this));
        $('#Next').click(this.NextOnClick.bind(this));
        $('#Last').click(this.LastOnClick.bind(this));
    }
    loadTotal() {
        $.ajax({
            url: "/products/total?info=&type=",
            method: "GET",
            data: "", // tham so truyen vao qua body 
            contentType: "",
            dataType: ""
        }).done(function (response) {
            TotalPage = Math.ceil(response.Total/PageSize);
        }).fail(function(response) {
        debugger;
    })
    }
    loadTotalFind(info, type) {
        $.ajax({
            url: "/products/total?info="+info+"&type="+type,
            method: "GET",
            data: "", // tham so truyen vao qua body 
            contentType: "",
            dataType: ""
        }).done(function (response) {
            TotalPage = Math.ceil(response.Total / PageSize);
        }).fail(function (response) {
            debugger;
        })
    }
    loadData() {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/all?Page=1&PageSize=5",
            method: "GET",
            data: "", // tham so truyen vao qua body 
            contentType: "",
            dataType: ""
        }).done(function (response) {
            $('.Content tbody').empty();
            $.each(response.Data, function (index, item) {
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
            Page = 1;
        }).fail(function (response) {
            debugger;
        })
    }
    Find(info, type, Page, PageSize) {
        // lay du lieu thong qua loi goi tu APi
        $.ajax({
            url: "/products/find?product_info=" + info + "&product_type=" + type + "&Page=" + Page + "&PageSize=" + PageSize,
            method: "GET"
        }).done(function (response) {
            $('.Content tbody').empty();
            $.each(response.Data, function (index, item) {
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
    FindOnClick() {
        //lay thong tin tim kiem
        var info = $("#txt-Find").val();
        var type = $("#Menu").val();
        var self = this;
        // tim kiem API
        if (info != '') {
            self.Find(info, type, 1, 5);
            Page = 1;
            self.loadTotalFind(info, type);
        }
        else {
            self.loadData();
            self.loadTotal();
        }
    }
    AddOnClick() {
        $('.dialog').show();
        $('.dialog-add').show();
        $('#txtName').focus();
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
                if (res) {
                    self.loadData();
                    self.loadTotal();
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
                if (!res.Data) {
                    alert('Khong co thong tin product nay');
                } else {
                    $("#txtCID").val(res.Data[0].ID);
                    $("#txtCCode").val(res.Data[0].Code);
                    $("#txtCName").val(res.Data[0].Name);
                    $("#txtCCategory").val(res.Data[0].Category);
                    $("#txtCBrand").val(res.Data[0].Brand);
                    $("#txtCType").val(res.Data[0].Type);
                    $("#txtCDescription").val(res.Data[0].Description);
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
        var info = $("#txt-Find").val();
        var type = $("#Menu").val();
        var self = this;
        if (info != '') {
            self.Find(info, type, 1, 5);
            Page = 1;
        }
        else {
            $.ajax({
                url: "/products/all?Page=1&PageSize=5",
                method: "GET",
                data: "", // tham so truyen vao qua body 
                contentType: "",
                dataType: ""
            }).done(function (response) {
                $('.Content tbody').empty();
                $.each(response.Data, function (index, item) {
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
                Page = 1;
            }).fail(function (response) {
                debugger;
            })  
        }
    }
    PreviousOnClick() {
        var self = this;
        var info = $("#txt-Find").val();
        var type = $("#Menu").val();
        if (Page > 1) {
            Page = Page - 1;
            if (info != '') {
                self.Find(info, type, Page, PageSize);
            }
            else {
                $.ajax({
                    url: "/products/all?Page=" + Page + "&PageSize=" + PageSize,
                    method: "GET",
                    data: "", // tham so truyen vao qua body 
                    contentType: "",
                    dataType: ""
                }).done(function (response) {
                    $('.Content tbody').empty();
                    $.each(response.Data, function (index, item) {
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
    }
    CurrentOnClick() {
        alert("Đang ở Page " + Page);
    }
    NextOnClick() {
        if (Page < TotalPage) {
            var info = $("#txt-Find").val();
            var type = $("#Menu").val();
            var self = this;
            Page = Page + 1;
            if (info != '') {
                self.Find(info, type, Page, PageSize);
            }
            else { 
                $.ajax({
                    url: "/products/all?Page=" + Page + "&PageSize=" + PageSize,
                    method: "GET",
                    data: "", // tham so truyen vao qua body 
                    contentType: "",
                    dataType: ""
                }).done(function (response) {
                    $('.Content tbody').empty();
                    $.each(response.Data, function (index, item) {
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
    }
    LastOnClick() {
        var info = $("#txt-Find").val();
        var type = $("#Menu").val();
        var self = this;
        if (info != '') {
            self.loadTotalFind(info, type);
            self.Find(info, type, TotalPage, 5);
            Page = TotalPage;
        }
        else {
            self.loadTotal();
            Page = TotalPage;
            $.ajax({
                url: "/products/all?Page="+Page+"&PageSize=5",
                method: "GET",
                data: "", // tham so truyen vao qua body 
                contentType: "",
                dataType: ""
            }).done(function (response) {
                $('.Content tbody').empty();
                $.each(response.Data, function (index, item) {
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
    btnSaveOnClick() {

            //lay thong tin
            var _product = {};
            var self = this;
            _product.Name = $("#txtName").val();
            _product.Category = $("#txtCategory").val();
            _product.Brand = $("#txtBrand").val();
            _product.Type = $("#txtType").val();
            _product.Description = $("#txtDescription").val();
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
                self.loadTotal();
                $('.dialog').hide();
                $('.dialog-add').hide();
                alert("Them thanh cong")
            }).fail(function (res) {
                debugger;
            })

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

            //luu du lieu vao database
            /*data.push(_product);*/
            $.ajax({
                url: "/products/" + Cprd.ID,
                method: "PUT",
                data: JSON.stringify(Cprd),
                contentType: "application/json",
                dataType: "json"
            }).done(function (res) {
                self.loadData();
                self.loadTotal();
                $('.dialog').hide();
                $('.dialog-change').hide();
                alert("Sua thanh cong")
            }).fail(function (res) {
                alert('Code trung lap trong CSDL, thu Code khac!');
            })
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