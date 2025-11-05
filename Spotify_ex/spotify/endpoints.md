```
GET http://localhost:5000/Porfiles/e3525334-2f77-46a0-a17e-8736911f5cbb

GET http://localhost:5000/Porfiles

POST http://localhost:5000/Porfiles
{
    "Name": "Prova",
    "Description": "Prova",
    "Status": "Actiu", 
    "User_ID": "5c1bf1c5-98b1-40c7-b5d7-c0ca003d1559"
}

DELETE http://localhost:5000/Porfiles/e3525334-2f77-46a0-a17e-8736911f5cbb

PUT http://localhost:5000/Porfiles/e3525334-2f77-46a0-a17e-8736911f5cbb (UPDATE)

{
    "Name": "Prova",
    "Description": "Prova",
    "Status": "Innactiu", 
    "User_ID": "5c1bf1c5-98b1-40c7-b5d7-c0ca003d1559"
}
```