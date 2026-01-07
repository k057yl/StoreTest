# StoreService

Простий Web API сервіс для роботи з даними магазину (клієнти, продукти, покупки).  
Використовується **PostgreSQL** та **ASP.NET Core 9 Web API**.

---

## Функціонал

- Список іменинників (`/api/clients/birthdays?date=YYYY-MM-DD`)  
- Останні покупці за N днів (`/api/clients/recent?days=N`)  
- Категорії покупок клієнта (`/api/clients/{clientId}/categories`)  

При запуску проект автоматично заповнюється тестовими даними (сидер).

---

## Стек технологій

- ASP.NET Core 9 Web API  
- Entity Framework Core + PostgreSQL  
- Swagger UI для тестування API  
- C# 12

---

## Як запустити

1. Налаштуйте PostgreSQL та створіть базу `store_db` (або іншу).  
2. В `appsettings.json` пропишіть свої дані підключення:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=store_db;Username=testuser;Password=testuser"
}
