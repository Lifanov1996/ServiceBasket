# ServiceBasket
Cервис для предоставления информации о списке товаров, и заказов.
 
Свагер доступен по адресу: https://localhost:7053/swagger/index.html
 
### Товар
Сервис по работе с [товарами](https://github.com/Lifanov1996/ServiceBasket/blob/main/ServiceBasket/Infrastructure/Repositories/ProductRepository.cs)

Доступен по адресу: https://localhost:7053/Products

Реализован функционал:
* Получениу списка товаров
* Добавление товара
* Удаление товара


### Заказ 
Сервис по работе с [заказами 1](https://github.com/Lifanov1996/ServiceBasket/blob/main/ServiceBasket/Infrastructure/Repositories/OrdersRepository.cs)

Доступен по адресу: https://localhost:7053/Orders

Реализован функционал:
* Получениe списка заказов 
* Добавление нового заказа

Сервис по работе с [заказами 2](https://github.com/Lifanov1996/ServiceBasket/blob/main/ServiceBasket/Infrastructure/Repositories/OrderUserRepository.cs)

Доступен по адресу: https://localhost:7053/OrderUser/1

Реализован функционал:
* Получение полной информации о заказе 
* Добавление товара в заказ
* Удаление товара из заказа
* Удаление заказа

### База данных
В качестве БД использовалась файловая SQLite. Для работы с ней используется Entity Framework Core.

Файл contextDb, миграционные и БД находяться в папке [Data](https://github.com/Lifanov1996/ServiceBasket/tree/main/ServiceBasket/Data) 
