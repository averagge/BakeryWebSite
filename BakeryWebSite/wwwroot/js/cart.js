// Получаем список товаров из Local Storage
var cartItems = JSON.parse(localStorage.getItem('cart')) || [];

// Находим элемент, в который будем выводить содержимое корзины
var cartContainer = document.getElementById('cart-items');

// Функция для обновления отображения корзины
function displayCartItems() {
    cartContainer.innerHTML = ''; // Очищаем контейнер перед обновлением

    cartItems.forEach(function (item, index) {
        // Создаем элемент для каждого товара
        var itemContainer = document.createElement('div');
        itemContainer.className = 'cart-item';

        var nameElement = document.createElement('div');
        nameElement.innerHTML = item.name;

        var priceElement = document.createElement('div');
        priceElement.innerHTML = 'Цена: ' + item.price + ' руб.';

        var quantElement = document.createElement('div');
        quantElement.innerHTML = 'Количество: ' + item.quantity;

        // Кнопка для увеличения количества товара
        var addButton = document.createElement('button');
        addButton.innerHTML = '+';
        addButton.className = 'add';
        addButton.onclick = function () {
            item.quantity++;
            saveCartItems();
            displayCartItems();
        };

        // Кнопка для уменьшения количества товара
        var subtractButton = document.createElement('button');
        subtractButton.innerHTML = '-';
        subtractButton.className = 'subtract';
        subtractButton.onclick = function () {
            if (item.quantity > 1) {
                item.quantity--;
            } else {
                cartItems.splice(index, 1); // Удаляем товар, если количество становится 0
            }
            saveCartItems();
            displayCartItems();
        };

        // Кнопка для удаления товара из корзины
        var removeButton = document.createElement('button');
        removeButton.innerHTML = 'Удалить';
        removeButton.className = 'remove';
        removeButton.onclick = function () {
            cartItems.splice(index, 1);
            saveCartItems();
            displayCartItems();
        };

        // Добавляем элементы в контейнер товара
        itemContainer.appendChild(nameElement);
        itemContainer.appendChild(priceElement);
        itemContainer.appendChild(quantElement);
        itemContainer.appendChild(addButton);
        itemContainer.appendChild(subtractButton);
        itemContainer.appendChild(removeButton);

        // Добавляем контейнер товара в основной контейнер корзины
        cartContainer.appendChild(itemContainer);
    });
}

// Функция для сохранения корзины в Local Storage
function saveCartItems() {
    localStorage.setItem('cart', JSON.stringify(cartItems));
}

// Отображаем содержимое корзины при загрузке страницы
displayCartItems();
