
Using this link:

```urls
- http://localhost:5190/odata/Escos?$select=Name&$expand=Customers($filter=Id gt 432767)&$orderby=Name desc
- http://localhost:5190/odata/Escos?$select=Name&$expand=Customers($filter=Id gt 432767)&$orderby=Name asc
- http://localhost:5190/odata/Escos?$select=Name&$expand=Customers($filter=Id eq 432766)
- http://localhost:5190/odata/Escos?$select=Name&$expand=Customers($filter=FirstName eq 'Mushtaq')
- http://localhost:5190/odata/Escos?$expand=Customers
- http://localhost:5190/odata/Escos?$select=Name&$expand=Customers
- http://localhost:5190/odata/Escos?$apply=aggregate($count as Count)
- http://localhost:5190/odata/Escos?$apply=aggregate(Id with sum as IdTotalSilly)
- http://localhost:5190/odata/Escos?$select=Name
- http://localhost:5190/odata/Escos/$count
- http://localhost:5190/odata/Escos
```
