
$(document).ready(function () {
    var PRC = new Products();

})
class Products {
    constructor() {
        this.loadData();
        this.initEnvents();
    }
    initEnvents() {
        $('.Add').click(this.AddOnClick);
        $('#btnCancel').click(this.btnCancelOnClick);
        $('.add-title-icon').click(this.iconOnClick);
        $('#btnSave').click(this.btnSaveOnClick);

    }
    loadData() {
        $.each(data, function (index, item) {
            var trHTML = $(` <tr>
                        <td>`+ item.ID + `</td>
                        <td>`+ item.Code + `</td>
                        <td>`+ item.Name + `</td>
                        <td>`+ item.Category + `</td>
                        <td>`+ item.Brand + `</td>
                        <td>`+ item.Type + `</td>
                        <td>`+ item.Decription + `</td>
                    </tr>`);
            $('.Content tbody').append(trHTML);
        })
    }
    AddOnClick() {
        $('.dialog').show();
        $('.dialog-add').show();
    }
    btnCancelOnClick() {
        $('.dialog').hide();
        $('.dialog-add').hide();
    }
    iconOnClick() {
        $('.dialog').hide();
        $('.dialog-add').hide();
    }
    btnSaveOnClick() {
        //kiem tra du lieu nhap tren form

        //lay thong tin

        //luu du lieu vao database
    }
}

var data = [
    {
        ID: "11",
        Code: "P011",
        Name: "	REALME 5 PRO 6+ 128GB",
        Category: "Mobile & Gadget",
        Brand: "Realme",
        Type: "Mobile phones",
        Decription: "REALME 5 PRO 6+ 128GB"
    },
    {
        ID: "12",
        Code: "P011",
        Name: "	REALME 6 PRO 6+ 128GB",
        Category: "Mobile & Gadget",
        Brand: "Realme",
        Type: "Mobile phones",
        Decription: "REALME 5 PRO 6+ 128GB"
    },
    {
        ID: "13",
        Code: "P011",
        Name: "	REALME 7 PRO 6+ 128GB",
        Category: "Mobile & Gadget",
        Brand: "Realme",
        Type: "Mobile phones",
        Decription: "REALME 5 PRO 6+ 128GB"
    }
]