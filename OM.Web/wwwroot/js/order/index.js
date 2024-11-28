window.onload = (event) => {
    sortChange();
};
const tbody = document.querySelector('#table-order tbody');
var objOrder = new Object();
function addRow() {
    var checkNewOrder = document.querySelector('.new-order') !== null;
    if (checkNewOrder) {
        alert("Chỉ được thêm 1 bản ghi")
    } else {
        var element = document.getElementById("tbody-order");
        var strSelectProduct = '<select id="order-product" onchange="changeSelect()" style="width:80%; height:30px"><option value="1">Rice</option><option value="2">Meat</option><option value="3">Fruit</option></select>';
        var strOrder = '<tr style="background-color:#FFFF8A" class="new-order"><td class="order-id" style="display: none;"></td><td class="order-product-id" style="display:none;"></td><td>' + strSelectProduct + '</td><td><input class="input-amount" onkeyup="calTotal(this)"></td><td class="order-unitprice"></td><td class="order-total"></td><td><button onclick="removeRow(this)">Delete </button></td></tr>';
        element.innerHTML = element.innerHTML + strOrder;
        changeSelect();
    }
}

let lstOrder = [];
var formData = new FormData();
function saveRow() {
    var newOrder = tbody.querySelector(".new-order");
    if (newOrder) {
        var selected = newOrder.querySelector("#order-product");
        var productId = selected.options[selected.selectedIndex].value;
        objOrder.Amount = newOrder.querySelector(".input-amount").value;
        objOrder.ProductId = productId;
        objOrder.UnitPrice = newOrder.querySelector(".order-unitprice").innerText;
        objOrder.Total = newOrder.querySelector(".order-total").innerText;
        objOrder.DeleteFlag = false;
        objOrder.EditFlag = false;
        lstOrder.push(objOrder);
    } else {
        var selected = newOrder.querySelector("#order-product");
        var productId = selected.options[selected.selectedIndex].value;
        objOrder.Amount = newOrder.querySelector(".input-amount").value;
        objOrder.ProductId = productId;
        objOrder.UnitPrice = newOrder.querySelector(".order-unitprice").innerText;
        objOrder.Total = newOrder.querySelector(".order-total").innerText;
        objOrder.DeleteFlag = false;
        objOrder.EditFlag = true;
        lstOrder.push(objOrder);
    }
    
    if (lstOrder.length === 0) {
        alert("Vui lòng chọn bản ghi")
    } else {
         
        for (let i = 0; i < lstOrder.length; i++) {
            formData.Id = lstOrder[i].OrderId;
            if (lstOrder[i].DeleteFlag == true && lstOrder[i].EditFlag == false) {
                deleteOrder(lstOrder[i].OrderId);
            } else if
                (lstOrder[i].DeleteFlag == false && lstOrder[i].EditFlag == false) {
                formData.append("Amount", lstOrder[i].Amount);
                formData.append("ProductId", lstOrder[i].ProductId);
                formData.append("UnitPrice", lstOrder[i].UnitPrice); 
                formData.append("Total", lstOrder[i].Total);
                createOrder(formData);

            } else if
                (lstOrder[i].DeleteFlag == false && lstOrder[i].EditFlag == true) {
                formData.append("Amount", lstOrder[i].Amount);
                formData.append("ProductId", lstOrder[i].ProductId);
                formData.append("UnitPrice", lstOrder[i].UnitPrice);
                formData.append("Total", lstOrder[i].Total);
                updateOrder(formData);
            }
        }
    }
}

function removeRow(btn) {
    var trElement = btn.parentNode.parentNode;
    trElement.style.backgroundColor = 'gray';
    var valOrderId = btn.parentNode.parentNode.getElementsByClassName("order-id")[0].innerText;
    if (valOrderId.length > 0) {
        objOrder.OrderId = valOrderId;
        objOrder.DeleteFlag = true;
        objOrder.EditFlag = false;
        lstOrder.push(objOrder);
    }
}
 
// Create order
function createOrder(formData) {
    $.ajax({
        type: 'POST',
        url: '/Orders/Create',
        crossdomain: true,
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: sortChange(),
        error: function errorCallback() {
            console.log("Something went wrong please contact admin.");
        }
    })
}
 
// Delete order
function deleteOrder(valOrderId) {
    $.ajax({
        type: "POST",
        url: '/Orders/Delete/' + valOrderId,
        crossdomain: true,
        contentType: false,
        processData: false,
        cache: false,
        data: valOrderId,
        success: sortChange(),
        error: function errorCallback() {
           alert("Something went wrong please contact admin.");
        }
    })
}
   
// Update Order
function updateOrder(formData) {
    $.ajax({
        type: "POST",
        url: '/Orders/Edit/' + valOrderId,
        crossdomain: true,
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: sortChange(),
        error: function errorCallback() {
            bootbox.alert("Something went wrong please contact admin.");
        }
    })

}
  
function selectElement(id, valueToSelect) {
    let element = document.getElementById(id);
    element.value = valueToSelect;
}

function calTotal(btn) {
    const trElement = btn.closest('tr')
    var valAmount = btn.value;
    var valUnitPrice = trElement.querySelector('.order-unitprice').innerHTML;
    var valTotal = trElement.querySelector('.order-total');
    if (isEmpty(valAmount)) {
        valTotal.innerHTML = "0";
        return;
    }
    var total = parseFloat(valUnitPrice) * parseFloat(valAmount);
    valTotal.innerHTML = total.toString();
}

function changeSelect() {
    var selected = document.getElementById("order-product");
    var parentSelected = selected.parentElement.parentElement;
    var valSelected = selected.value;
    var text = selected.options[selected.selectedIndex].text;
    if (!isEmpty(valSelected)) {
        switch (valSelected) {
            case valSelected = '1':
                parentSelected.querySelector(".order-unitprice").innerHTML = "20"
                break;
            case valSelected = '2':
                parentSelected.querySelector(".order-unitprice").innerHTML = "30.5"
                break;
            case valSelected = '3':
                parentSelected.querySelector(".order-unitprice").innerHTML = "35"
                break;
        }
    }
    var amount = parentSelected.querySelector(".input-amount");
    if (!amount) {
        amount = parentSelected.querySelector('.order-amount');
    }
    var unitPrice = parentSelected.querySelector('.order-unitprice');
    var total = parentSelected.querySelector('.order-total');
    if (isEmpty(amount.innerHTML)) {
        total.innerHTML = "0";
        return;
    }
    var totalOrder = parseFloat(unitPrice.innerHTML) * parseFloat(amount.innerHTML);
    total.innerHTML =  totalOrder.toFixed(2).toString();
}

function isEmpty(value) {
    return (value == null || (typeof value === "string" && value.trim().length === 0));
}

function sortChange() {
    var selected = document.getElementById("sort-order");
    var valSelected = selected.value;
    var formData = new FormData();
    formData.append("sort", valSelected);
        $.ajax({
            type: "POST",
            url: '/Orders/Index',
            crossdomain: true,
            contentType: false,
            processData: false,
            dataType: "json",
            cache: false,
            data: formData,
            success: function (data) {
                var items = '';
                $('#table-order tbody').empty();
                $.each(JSON.parse(data), function (i, item) {
                    var rows = "<tr>"
                        + "<td class='order-id' style='display: none;'>" + item.Id + "</td>"
                        + "<td class='order-product-id' style='display: none;' >" + item.ProductId + "</td>"
                        + "<td class='order-name'>" + checkProduct(item.ProductId) + "</td>"
                        + "<td class='order-amount'>" + item.Amount + "</td>"
                        + "<td class='order-unitprice'>" + item.UnitPrice + "</td>"
                        + "<td class='order-total'>" + item.Total + "</td>"
                        + "<td><button class='btn-delete-order' onclick='removeRow(this)'>Delete </button></td>"
                        + "</tr>";
                    $('#table-order tbody').append(rows);
                })
            },
            error: function errorCallback() {
                console.log("Something went wrong please contact admin.");
            }
        })
    formData = new FormData();
}

function checkProduct(productId) {
    switch (productId) {
        case productId = 1:
            return "Rice";
        case productId = 2:
            return "Meat";
        case productId = 3:
            return "Fruit";
    }
}

let lastClickedRow = false; 

tbody.addEventListener('dblclick', function (e) {
    var trElement = e.target.closest("tr");
    console.log(trElement);
    trElement.style.backgroundColor  = '#FFFF8A';
    if (e.target.closest('.order-name')) {
        var strSelectProduct = '<select id="order-product" onchange="changeSelect()" style="width:80%; height:30px"><option value="1">Rice</option><option value="2">Meat</option><option value="3">Fruit</option></select>';
        var orderName = e.target.closest('.order-name');
        orderName.outerHTML = '<td>' + strSelectProduct + '</td>';
    } else if (e.target.closest('.order-amount')){
        var orderName = e.target.closest('.order-amount');
        orderName.outerHTML = '<td><input class="input-amount" onkeyup="calTotal(this)" value=' + orderName.innerHTML + '></td>';
    }
})  

var tableElement = document.querySelector("#table-order tbody");
var classNametd = '';
var eventTarget = '';
var valueTd = '';
document.addEventListener('click', function (e) {
    const isInsideClicked = tableElement.contains(e.target);
    if (classNametd.length == 0 ) {
        classNametd = e.target.className;
    }

    if (classNametd === e.target.className) {
        console.log("true")
    } else {
        if (e.target.tagName === 'INPUT') {
            eventTarget = e.target.tagName
            valueTd = e.target.value;
        }
        eventTarget.innerHTML = "<td class='order-amount' >" + valueTd + "</td>";
    }   
});