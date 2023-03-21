## Run The Project
You will need the following tools:
	* [Visual Studio 2022]
	* [.Net 7]
Tech stack 
	.NET Core Web api
	EF Core InMemoryDB
	CQRS Design pattern
	
GitHub link - https://github.com/kanishkashm/MediDroneTransporter

Swagger URL - http://localhost:5005/swagger/index.html

View all drones - 
	http://localhost:5005/api/Drone
Registering a drone - 
	http://localhost:5005/api/Drone(POST)
	Payload - {
				"id": 0,
				"serialNumber": "string",
				"model": 1,
				"weightLimit": 0,
				"batteryCapacity": 0,
				"state": 1
			  }
Loading a drone with medication items - 
	http://localhost:5005/api/TransportMedications(POST)
	Payload - {
				  "droneId": 0,
				  "medications": [
					{
					  "name": "string",
					  "weight": 0,
					  "code": "string",
					  "imagePath": "string"
					}
				  ]
				}
Checking loaded medication items for a given drone - 
	http://localhost:5005/api/TransportMedications/GetDroneMedications?serialNumber=ABC300631253686
Checking available drones for loading -
	http://localhost:5005/api/Drone/AvailableDrones
check drone battery level for a given drone - 
	http://localhost:5005/api/Drone/ABC300631253686

	