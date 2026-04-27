# Employee Management System - API Documentation

## Base URL
```
https://localhost:5001/api
```

## Authentication
Current API does not require authentication. JWT tokens can be integrated in future versions.

## Endpoints

### Employees

#### Get All Employees
- **URL**: `/employees`
- **Method**: `GET`
- **Query Parameters**:
  - `pageNumber` (optional): Default 1
  - `pageSize` (optional): Default 10
  - `searchTerm` (optional): Search by first name, last name, or email

**Example Request**:
```
GET /api/employees?pageNumber=1&pageSize=10&searchTerm=Ahmed
```

**Response** (200 OK):
```json
{
  "data": [
    {
      "id": 1,
      "firstName": "Ahmed",
      "lastName": "Hassan",
      "email": "ahmed.hassan@company.com",
      "phone": "+201001234567",
      "position": "Senior Developer",
      "salary": 150000,
      "hireDate": "2020-01-15T00:00:00",
      "departmentId": 1,
      "departmentName": "Information Technology",
      "createdAt": "2024-01-15T10:30:00Z",
      "updatedAt": null
    }
  ],
  "totalCount": 1,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 1,
  "hasNextPage": false,
  "hasPreviousPage": false
}
```

#### Get Employee by ID
- **URL**: `/employees/{id}`
- **Method**: `GET`
- **Path Parameters**:
  - `id` (required): Employee ID

**Example Request**:
```
GET /api/employees/1
```

**Response** (200 OK):
```json
{
  "id": 1,
  "firstName": "Ahmed",
  "lastName": "Hassan",
  "email": "ahmed.hassan@company.com",
  "phone": "+201001234567",
  "position": "Senior Developer",
  "salary": 150000,
  "hireDate": "2020-01-15T00:00:00",
  "departmentId": 1,
  "departmentName": "Information Technology",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": null
}
```

#### Create Employee
- **URL**: `/employees`
- **Method**: `POST`
- **Content-Type**: `application/json`

**Request Body**:
```json
{
  "firstName": "Ali",
  "lastName": "Mohammed",
  "email": "ali.mohammed@company.com",
  "phone": "+201001234572",
  "position": "Frontend Developer",
  "salary": 120000,
  "hireDate": "2024-04-27",
  "departmentId": 1
}
```

**Response** (201 Created):
```json
{
  "id": 6,
  "firstName": "Ali",
  "lastName": "Mohammed",
  "email": "ali.mohammed@company.com",
  "phone": "+201001234572",
  "position": "Frontend Developer",
  "salary": 120000,
  "hireDate": "2024-04-27T00:00:00",
  "departmentId": 1,
  "departmentName": "Information Technology",
  "createdAt": "2024-04-27T12:00:00Z",
  "updatedAt": null
}
```

#### Update Employee
- **URL**: `/employees/{id}`
- **Method**: `PUT`
- **Content-Type**: `application/json`
- **Path Parameters**:
  - `id` (required): Employee ID

**Request Body**:
```json
{
  "firstName": "Ahmed",
  "lastName": "Hassan",
  "email": "ahmed.hassan@company.com",
  "phone": "+201001234567",
  "position": "Tech Lead",
  "salary": 160000,
  "hireDate": "2020-01-15",
  "departmentId": 1
}
```

**Response** (200 OK):
```json
{
  "id": 1,
  "firstName": "Ahmed",
  "lastName": "Hassan",
  "email": "ahmed.hassan@company.com",
  "phone": "+201001234567",
  "position": "Tech Lead",
  "salary": 160000,
  "hireDate": "2020-01-15T00:00:00",
  "departmentId": 1,
  "departmentName": "Information Technology",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-04-27T12:30:00Z"
}
```

#### Delete Employee
- **URL**: `/employees/{id}`
- **Method**: `DELETE`
- **Path Parameters**:
  - `id` (required): Employee ID

**Response** (204 No Content)

---

### Departments

#### Get All Departments
- **URL**: `/departments`
- **Method**: `GET`

**Response** (200 OK):
```json
[
  {
    "id": 1,
    "name": "Information Technology",
    "description": "IT Department",
    "managerName": "John Manager",
    "createdAt": "2024-01-15T10:30:00Z",
    "employeeCount": 2
  }
]
```

#### Get Department by ID
- **URL**: `/departments/{id}`
- **Method**: `GET`

**Response** (200 OK):
```json
{
  "id": 1,
  "name": "Information Technology",
  "description": "IT Department",
  "managerName": "John Manager",
  "createdAt": "2024-01-15T10:30:00Z",
  "employeeCount": 2
}
```

#### Create Department
- **URL**: `/departments`
- **Method**: `POST`

**Request Body**:
```json
{
  "name": "Marketing",
  "description": "Marketing Department",
  "managerName": "Sarah Marketing Manager"
}
```

**Response** (201 Created):
```json
{
  "id": 4,
  "name": "Marketing",
  "description": "Marketing Department",
  "managerName": "Sarah Marketing Manager",
  "createdAt": "2024-04-27T12:00:00Z",
  "employeeCount": 0
}
```

#### Update Department
- **URL**: `/departments/{id}`
- **Method**: `PUT`

**Request Body**:
```json
{
  "name": "Information Technology",
  "description": "Updated IT Department",
  "managerName": "John Manager Updated"
}
```

**Response** (200 OK):
```json
{
  "id": 1,
  "name": "Information Technology",
  "description": "Updated IT Department",
  "managerName": "John Manager Updated",
  "createdAt": "2024-01-15T10:30:00Z",
  "employeeCount": 2
}
```

#### Delete Department
- **URL**: `/departments/{id}`
- **Method**: `DELETE`

**Response** (204 No Content)

---

## Error Responses

### 404 Not Found
```json
{
  "message": "Employee with ID 999 not found"
}
```

### 500 Internal Server Error
```json
{
  "message": "Error fetching employees"
}
```

---

## Status Codes
- `200 OK`: Request successful
- `201 Created`: Resource created successfully
- `204 No Content`: Resource deleted successfully
- `400 Bad Request`: Invalid request parameters
- `404 Not Found`: Resource not found
- `500 Internal Server Error`: Server error
