# WebAPI-With-ASPNET-Core-Sample
This is a sample of Web API with ASP.NET Core 1.0

## Get All Students

``` http://localhost:47565/api/student ```

![postman_get](https://cloud.githubusercontent.com/assets/23435109/21072761/2d296148-beef-11e6-8562-46f2d8de1891.PNG)

## Get a Student By ID

``` http://localhost:47565/api/student/1 ```

![postman_getid](https://cloud.githubusercontent.com/assets/23435109/21072765/4b8adf86-beef-11e6-813d-331875aa50e1.PNG)

## Post A Student

``` http://localhost:47565/api/student ```

```json
  {
    "firstName": "Barack",
    "lastName": "Obama",
    "gender": "Male",
    "age": 55
  },
```

![postman_post](https://cloud.githubusercontent.com/assets/23435109/21072767/5becc588-beef-11e6-9b04-564cae10a3fe.PNG)

## Put A Student By ID

``` http://localhost:47565/api/student/5 ```

```json
  {
    "studentId": 5,
    "firstName": "Donald",
    "lastName": "Trump",
    "gender": "Male",
    "age": 70
  },
```

![postman_put](https://cloud.githubusercontent.com/assets/23435109/21072771/6a1dc472-beef-11e6-9521-438914091fcf.PNG)

## Delete A Student By ID

``` http://localhost:47565/api/student/5 ```

![postman_delete](https://cloud.githubusercontent.com/assets/23435109/21072772/6bda0fdc-beef-11e6-9f4c-a29f7a28b8b7.PNG)
