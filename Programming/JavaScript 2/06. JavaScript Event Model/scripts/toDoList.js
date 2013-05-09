(function () {
    var newItem = document.getElementById('newItem'),
        addButton = document.getElementById('add'),
        showButton = document.getElementById('show'),
        hideButton = document.getElementById('hide'),
        todoList = document.getElementById('toDoList');

    addButton.addEventListener('click', addItem);
    showButton.addEventListener('click', showList);
    hideButton.addEventListener('click', hideList);

    function addItem() {
        if (newItem.value) {
            var item = document.createElement('li');
            var itemText = document.createElement('p');
            var removeItem = document.createElement('button');
            removeItem.innerHTML = 'X';
            removeItem.id = 'remove';
            removeItem.type = 'button';
            removeItem.addEventListener('click', removeFromList);

            var text = document.createTextNode(newItem.value);
            itemText.appendChild(text);
            item.appendChild(itemText);
            item.appendChild(removeItem);
            todoList.appendChild(item);
        }
    }

    function removeFromList(ev) {
        todoList.removeChild(this.parentNode);
    }

    function showList() {
        todoList.style.display = 'block';
    }

    function hideList() {
        todoList.style.display = 'none';
    }
})();