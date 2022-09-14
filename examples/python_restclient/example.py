import requests
api_url = "https://jsonplaceholder.typicode.com/todos"
todo = {"userId": 1, "title": "Buy milk", "completed": False}
response = requests.post(api_url, json=todo)
print(response.status_code)
print(response.json())
#{'userId': 1, 'title': 'Buy milk', 'completed': False, 'id': 201}
