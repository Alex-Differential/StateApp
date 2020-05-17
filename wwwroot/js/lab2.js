const uri = 'api/polit_system';
let categories = [];

function getCategories() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCategories(data))
        .catch(error => console.error('Unable to get categories.', error));
}

function addCategory() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');

    const category = {
        pS_Name: addNameTextbox.value.trim(),
        pS_Info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(category)
    })
        .then(response => response.json())
        .then(() => {
            getCategories();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add category.', error));
}

function deleteCategory(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCategories())
        .catch(error => console.error('Unable to delete category.', error));
}

function displayEditForm(id) {
    const category = categories.find(category => category.pS_ID === id);

    document.getElementById('edit-id').value = category.pS_ID;
    document.getElementById('edit-name').value = category.pS_Name;
    document.getElementById('edit-info').value = category.pS_Info;
    document.getElementById('editForm').style.display = 'block';
}

function updateCategory() {
    const categoryId = document.getElementById('edit-id').value;
    const category = {
        PS_ID: parseInt(categoryId, 10),
        PS_Name: document.getElementById('edit-name').value.trim(),
        PS_Info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${categoryId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(category)
    })
        .then(() => getCategories())
        .catch(error => console.error('Unable to update category.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'форма' : 'форми';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayCategories(data) {
    const tBody = document.getElementById('categories');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(category => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.style.height = '30px';
        //editButton.style.width = '50px';
        editButton.style.backgroundColor = '#337ab7';
        editButton.style.border = 'none';
        editButton.style.color = '#fff';
        editButton.style.outline = 'none';
        editButton.style.borderRadius = '5px';
        editButton.setAttribute('onclick', `displayEditForm(${category.pS_ID})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.style.height = '30px';
        deleteButton.style.backgroundColor = '#c9302c';
        deleteButton.style.border = 'none';
        deleteButton.style.color = '#fff';
        deleteButton.style.outline = 'none';
        deleteButton.style.borderRadius = '5px';
        deleteButton.setAttribute('onclick', `deleteCategory(${category.pS_ID})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(category.pS_Name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(category.pS_Info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    categories = data;
}