//document.addEventListener("DOMContentLoaded", () => {

//    const customerRadios = document.querySelectorAll("input[name='Meeting.CustomerType']");
//    const customerDropdown = document.querySelector("#customerDropdown");

//    const productDropdown = document.querySelector("#productDropdown");

//    const unitInput = document.querySelector("#unitInput");

//    const qtyInput = document.querySelector("#quantityInput");
//    const addBtn = document.querySelector("#addProductBtn");

//    const tableBody = document.querySelector("#detailsTable tbody");

//    let rowCount = 0;
//    let editingRow = null;

//    async function loadCustomers(type) {
//        customerDropdown.innerHTML = `<option value="" disabled selected hidden>Select customer name</option>`;
//        const res = await fetch(`/MeetingAndProduct/GetAllCustomers?type=${type}`);
//        const customers = await res.json();
//        customers.forEach(c => {
//            customerDropdown.insertAdjacentHTML(
//                "beforeend",
//                `<option value="${c.id}" ${(c.id == @Model.Meeting.CustomerId ? "selected" : "")}>${c.name}</option>`
//            );
//        });
//    }

//    loadCustomers("@Model.Meeting.CustomerType");

//    customerRadios.forEach(radio =>
//        radio.addEventListener("change", e => loadCustomers(e.target.value))
//    );

//    productDropdown.addEventListener("change", () => {
//        unitInput.value = productDropdown.selectedOptions[0]?.dataset.unit || "";
//    });

//    addBtn.addEventListener("click", () => {
//        const productId = productDropdown.value;
//        const productName = productDropdown.selectedOptions[0]?.text || "";
//        const quantity = qtyInput.value;
//        const unit = unitInput.value;

//        if (!productId || !quantity) {
//            alert("Please select a product and enter quantity.");
//            return;
//        }

//        if (editingRow) {

//            editingRow.querySelector("input[name$='.ProductServiceId']").value = productId;
//            editingRow.querySelector("td:nth-child(2)").firstChild.textContent = productName;

//            editingRow.querySelector("input[name$='.Quantity']").value = quantity;
//            editingRow.querySelector(".qty-text").textContent = quantity;

//            editingRow.querySelector("input[name$='.Unit']").value = unit;
//            editingRow.querySelector("td:nth-child(4)").firstChild.textContent = unit;

//            editingRow = null;
//            addBtn.innerHTML = `<i class="bi bi-plus-square"></i> Add`;
//        } else {

//            rowCount++;
//            const newRow = `
//                            <tr>
//                                <td>${rowCount}</td>
//                                <td>
//                                    ${productName}
//                                    <input type="hidden" name="Details[${rowCount - 1}].ProductServiceId" value="${productId}" />
//                                </td>
//                                <td>
//                                    <span class="qty-text">${quantity}</span>
//                                    <input type="hidden" name="Details[${rowCount - 1}].Quantity" value="${quantity}" />
//                                </td>
//                                <td>
//                                    ${unit}
//                                    <input type="hidden" name="Details[${rowCount - 1}].Unit" value="${unit}" />
//                                </td>
//                                <td><button type="button" class="btn btn-sm btn-warning btn-edit">Edit</button></td>
//                                <td><button type="button" class="btn btn-sm btn-danger btn-delete">Delete</button></td>
//                            </tr>`;
//            if (tableBody.querySelector("td")?.textContent.includes("No matching records")) {
//                tableBody.innerHTML = "";
//            }
//            tableBody.insertAdjacentHTML("beforeend", newRow);
//        }

//        productDropdown.value = "";
//        qtyInput.value = "";
//        unitInput.value = "";
//    });

//    tableBody.addEventListener("click", e => {
//        const row = e.target.closest("tr");
//        if (!row) return;

//        if (e.target.classList.contains("btn-delete")) {
//            row.remove();
//            if (tableBody.children.length === 0) {
//                tableBody.innerHTML = `<tr><td colspan="6" class="text-center">No matching records found</td></tr>`;
//                rowCount = 0;
//            }
//        }

//        if (e.target.classList.contains("btn-edit")) {
//            editingRow = row;
//            const productId = row.querySelector("input[name$='.ProductServiceId']").value;
//            const qty = row.querySelector("input[name$='.Quantity']").value;
//            const unit = row.querySelector("input[name$='.Unit']").value;

//            productDropdown.value = productId;
//            qtyInput.value = qty;
//            unitInput.value = unit;

//            addBtn.innerHTML = `<i class="bi bi-pencil-square"></i> Update`;
//        }
//    });
//});