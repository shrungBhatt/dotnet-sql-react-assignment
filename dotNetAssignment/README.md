### __1. API for adding a new contract__
```url
POST: {serverAddress}/api/Contracts/AddNewContract
```
```json
Body
{
    "name":"Tata",
    "address":"Young",
    "gender":"2",
    "country":"1",
    "dateOfBirth":"1/1/1982 12:00:00 AM",
    "saleDate":"8/30/2020 11:56:21 AM"
}

Here the gender and country are added as ids in order to create a normalized tables.

For id of genders and countries you can refer to the attached DB or FYI for genders M=1 and F=2, for country USA=1, CAN=2, OTHERS=3
```
### __2. API for updating an existing contract__
```url
PUT: {serverAddress}/api/Contracts/UpdateContract
```
```json
Body
{
    "id": 8,
    "customerName": "Steve",
    "customerAddress": "Balmer",
    "gender": 1,
    "country": 1,
    "coveragePlan": 3,
    "dob": "1997-01-01T00:00:00",
    "saleDate": "2020-08-30T11:56:21",
    "rateChart": 9
}

This is an existing contract, so the coveragePlan and rateChart values will be available. However you do not need to update those. Those will be updated if there is any change in country, birth date or sale date.
```

### __3. API for updating an getting all the contracts with foreign key values__
```url
GET: {serverAddress}/api/Contracts/GetContracts
```
```json
Response
{
    "status": "success",
    "data": [
        {
            "id": 4,
            "customerName": "John",
            "customerAddress": "Dixon",
            "gender": 1,
            "country": 1,
            "coveragePlan": 1,
            "dob": "1975-01-01T00:00:00",
            "saleDate": "2012-01-01T00:00:00",
            "rateChart": 3
        }
    ]
}
```

### __4. API for getting all the contracts with readable data__
```url
GET: {serverAddress}/api/Contracts/GetContractsView
```
```json
Response
{
    "status": "success",
    "data": [
        {
            "customerName": "John",
            "customerAddress": "Dixon",
            "gender": "M",
            "country": "USA",
            "dob": "1975-01-01T00:00:00",
            "saleDate": "2012-01-01T00:00:00",
            "coveragePlan": "Gold",
            "netPrice": 2000.0000
        }
    ]
}
```
### __5. API for deleting an existing contract__
```url
DELETE: {serverAddress}/api/Contracts/DeleteContract?id=7
```
```json
Response
{
    "status": "success",
    "data": {
        "acknowledgement": {
            "status": "success"
        }
    }
}
```
