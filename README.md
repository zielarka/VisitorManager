**ApiVisitorManager

The task of the application is remote aggregation of counts.
---


#### AUTH MODULE ####

### POST /api/Auth/register

Example: Create – POST /api/Auth/register

Request body:
```
{
    "username": "example@wp.pl",
    "password": "admin123!",
}
```

### POST /api/Auth/login
Example: Login – POST /api/Auth/login

Request body:
```
{
    "username": "example@wp.pl",
    "password": "admin123!",
}
```

Response:
```
{
    "token": "VVVVVVVVVVVVVVVVVVVVVVVVV"
}
```

---
#### USER MODULE ####

### GET /api/User/ 
[Authorize]
Example: Get All Users – GET /api/User/

Request body:
```
{
    "token": "VVVVVVVVVVVVVVVVVVVVVVVV"
}
```

Response:
```
[
    {
        "id": "aaaaaaaa-aaaa-aaaa-aaaa-743aae8ae269",
        "userName": "test"
    },
    {
        "id": "aaaaaaaa-aaaa-aaaa-aaaa-743aae8ae269",
        "userName": "testaz3"
    },
    {
        "id": "aaaaaaaa-aaaa-aaaa-aaaa-743aae8ae269",
        "userName": "testaz5"
    }
]
```

### DELETE /api/User/{userId} 
[Authorize]
Example: Delete by iduser – DELETE /api/User/{userId} 


---
#### STORE MODULE ####

### GET /api/Store/ 
[Authorize]
Example: Get All Stores – GET /api/Store

Response:
```
[
    {
        "id": "08848a6f-cf67-483e-884c-42edcfd02325",
        "name": "test1",
        "city": "test",
        "street": "test",
        "sid": "test"
    },
    {
        "id": "215fae6d-5c2b-42eb-bb37-6c53c9815aa2",
        "name": "D0034b",
        "city": "Toruń",
        "street": "ul Nad Strugą",
        "sid": "0001"
    }
]
```

### POST /api/Store/ 
[Authorize]
Example: Add Store – POST /api/Store

Request body:
```
{
  "name": "D0034b",
  "city": "Toruń",
  "street": "ul Nad Strugą",
  "sid": "3721",
  "postalCode": "87-100",
  "responsiblePerson": "Jan Kowalski",
  "latitude":53.0515277,
  "longitude": 18.7080651
}
```

### PUT /api/Store/{storeId} 
[Authorize]
Example: Update name store – PUT /api/Store/{storeId}

Request body:
```
{
  "name": "D0034b777"
}
```

### DELETE /api/Store/{storeId} 
[Authorize]
Example: Delete  store – DELETE /api/Store/{storeId}

---
#### DEVICE MODULE ####

### GET /api/Device/ 
[Authorize]
Example: Get All Device – GET /api/Device

Request body:
```
[
    {
        "id": "60c1c6aa-60e7-477c-9f4f-0f5d1446e2ad",
        "name": "test2",
        "storeId": "08848a6f-cf67-483e-884c-42edcfd02325"
    }
]
```

### POST /api/Device/ 
[Authorize]
Example: Add Device – POST /api/Device

Request body:
```
{
  "serialNumber": "b827eb332456",
  "name": "3721 - Toruń ul. nad Strugą"
}
```

### PUT /api/Device/{deviceId} 
[Authorize]
Example: Update StoreId in Devcie– PUT /api/Device/{deviceId}

Request body:
```
{
  "StoreId": "08848a6f-cf67-483e-884c-42edcfd02325"
}
```

### DELETE /api/Device/{deviceId} 
[Authorize]
Example: Delete  device – DELETE /api/Device/{deviceId}


---
#### EVENT MODULE ####

### POST /api/event/ 
[Authorize]
Example: Add Event – POST /api/Event
"CounterId": 1 - IN
"CounterId": 2 - OUT
"DateTime": use format ISO 8601
Request body:
```
{
        "DeviceId": "60c1c6aa-60e7-477c-9f4f-0f5d1446e2ad",
        "CounterId": 1,
        "Amount": 2,
        "DateTime": "2021-07-16T17:16:40"
}
```
Response:
```
{
    "success": true,
    "errorMessage": ""
}
```
---

### GET GetStatisticsperDay /api/event?storeId=A95FAC35-CB8B-404B-BC4B-65691D9E152A&startDate=2021-07-15T00:00:00&endDate=2021-07-18T00:00:00

Response:
```
[
    {
        "count": 0,
        "date": "2021-07-15"
    },
    {
        "count": 25,
        "date": "2021-07-16"
    },
    {
        "count": 0,
        "date": "2021-07-17"
    },
    {
        "count": 0,
        "date": "2021-07-18"
    }
]
```
