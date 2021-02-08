# Async Hotel

## App Details:
A database of hotel&room information relevent to the company who owns the hotels, can be used for internal data management or for customer searches.

Author: Kjell Overholt

##Getting Started
To run the program in the browser: https://asynchotelapp.azurewebsites.net/

Clone this repository to your local machine.


`$ git clone [repo clone url here]`

To run the program from Visual Studio:

Select File -> Open -> Project/Solution


Next navigate to the location you cloned the Repository.


Double click on the AsyncHotel directory.


Then select and open AsyncHotel.sln

## Images:

**Usage**:
Application Startup:
![Startup](https://github.com/Overholtk/AsyncHotel/blob/master/Assets/use1.png)

API call 1:
![API example 1](https://github.com/Overholtk/AsyncHotel/blob/master/Assets/use2.png)

API call 2:
![API example 2](https://github.com/Overholtk/AsyncHotel/blob/master/Assets/use3.png)

![ERD](https://github.com/Overholtk/AsyncHotel/blob/master/Assets/AsyncInnERD.png)

## Explanation of Tables:
- **Hotel Table**: contains all of the hotel locations.
- **HotelRoom Table**: contains the prices, room numbers and pet friendly attributes of the rooms
- **Room Table**: contains the characteristics of a bedroom that includes layout, name and amenities.
- **Amenities Table**: contains the IDs and names of all availible amenities. 
- **RoomAmenities Table**: Links the Room and Amenities tables by IDs, determining what rooms have what amenities.

## Explanation of Relationships:
-  *Hotel Table*:
   - 1:Many relationship with Hotel Room table- a single location may have any number of rooms.
- *Room Table*:
	- 1:Many relationship with the Hotel Room table- one type of room can apply to many rooms.
	-1:Many relationship with RoomAmmenities- 1 room can have many amenities
	**HotelRoom Table facilitates a Many:Many relationship between the Room & Hotel tables**
- *Amenities Table**:
	- 1:Many with RoomAmenities- many rooms can have the same kind of amenity
	**RoomAmenities facilitates a Many:Many relationship between Room & Amenities tables**

## Architecture
- Repository Pattern: Instead of allowing the controller files to have direct access to the database, control is filtered through an interface, and a service (repository). The interface defines methods that each model has to interact with the database, and then the services implement those methods and attach them to the controller. This allows the code to be 1) maintainable without having to redo excessive amounts of code, and 2) clean, readable, and up to standard with OOP principles of single responsibility. It also keeps the controller in accordance with the MVC design pattern by allowing it only to direct calls rather than make them itself.

## Identity:
- allows users to create a login, we as developers can use that login to give or restrict access to pages and processes of our app. The identities are built by creating a table for them and a DTO for front facing access and easy data transfer. The user sets their username and password, and the username is saved to the databased while the password is hashed and stored securely. While the user is logged in they generate tokens that let the program know who they are, which allows them access to what they have permissions for.

## Routes: (Route/JSON return)
Amenities Routes:
- **api/Amenities**
  Returns a JSON block with all availible amenities
	
	`[{ "id": 1, "name": "Heated Bath", "roomAmenities": null}, {"id": 2, "name": "Oil Lamps", "roomAmenities": null }, { "id": 3, "name": "Crawling Claw Control", "roomAmenities": null }]`

- **api/Amenities/5**
	Returns a JSON block with the specifics of one amenity.
	
	`{"id": 1, "name": "Heated Bath", "roomAmenities": [{ "amenityID": 1, "roomID": 2, "room": {"id": 2, "nickname": "Dusty WereRat", "layout": 1,"roomAmenities": [],
 "hotelRooms": null}]}`

- **api/Bedrooms**
	Returns a JSON list of all bedrooms

	`[
    {
        "id": 1,
        "nickname": "The Underdark",
        "layout": 0,
        "roomAmenities": [
            {
                "amenityID": 2,
                "roomID": 1,
                "amenity": null
            }
        ],
        "hotelRooms": null
    },
    {
        "id": 2,
        "nickname": "Dusty WereRat",
        "layout": 1,
        "roomAmenities": [
            {
                "amenityID": 1,
                "roomID": 2,
                "amenity": null
            },
            {
                "amenityID": 2,
                "roomID": 2,
                "amenity": null
            },
            {
                "amenityID": 3,
                "roomID": 2,
                "amenity": null
            }
        ],
        "hotelRooms": null
    },
    {
        "id": 3,
        "nickname": "Ancient Red Dragon",
        "layout": 3,
        "roomAmenities": [
            {
                "amenityID": 1,
                "roomID": 3,
                "amenity": null
            },
            {
                "amenityID": 3,
                "roomID": 3,
                "amenity": null
            }
        ],
        "hotelRooms": null
    }
]`

- **api/Bedrooms/5**
	Returns a single JSON object of a bedroom.

    `{
    "id": 2,
    "nickname": "Dusty WereRat",
    "layout": 1,
    "roomAmenities": [
        {
            "amenityID": 1,
            "roomID": 2,
            "amenity": null
        },
        {
            "amenityID": 2,
            "roomID": 2,
            "amenity": null
        },
        {
            "amenityID": 3,
            "roomID": 2,
            "amenity": null
        }
    ],
    "hotelRooms": null
}`

- **api/HotelRooms/5/Rooms**
	Returns a list of all rooms in a hotel
    
    `[
    {
        "hotelsID": 2,
        "roomNumber": 1,
        "roomID": 3,
        "rate": 15.0,
        "petFriendly": false,
        "hotels": null,
        "room": null
    }
    ]`


- **api/HotelRooms/5/Rooms/5**
	Returns a single room in a given hotel

    `{
    "hotelsID": 1,
    "roomNumber": 1,
    "roomID": 1,
    "rate": 10.0,
    "petFriendly": false,
    "hotels": null,
    "room": {
        "id": 1,
        "nickname": "The Underdark",
        "layout": 0,
        "roomAmenities": [
            {
                "amenityID": 2,
                "roomID": 1,
                "amenity": null
            }
        ],
        "hotelRooms": []
    }
}`

- **api/Hotels**
	Returns a list of all hotels.

    `[
    {
        "id": 1,
        "name": "The Glorious Accordian",
        "streetAddress": "246513 Street st",
        "city": "Cityton",
        "state": "New Statewise",
        "country": "Accordiantica",
        "phoneNumber": "5555555555",
        "hotelRooms": null
    },
    {
        "id": 2,
        "name": "The Unarmed Crystal",
        "streetAddress": "4864513 Street st",
        "city": "Cityton",
        "state": "New Statewise",
        "country": "Accordiantica",
        "phoneNumber": "5555555555",
        "hotelRooms": null
    },
    {
        "id": 3,
        "name": "Panoramic Goats Pub",
        "streetAddress": "2465489 Street st",
        "city": "Cityton",
        "state": "New Statewise",
        "country": "Accordiantica",
        "phoneNumber": "5555555555",
        "hotelRooms": null
    }
]`

- **api/Hotels/5**
	Returns a single hotel.

    `{
    "id": 2,
    "name": "The Unarmed Crystal",
    "streetAddress": "4864513 Street st",
    "city": "Cityton",
    "state": "New Statewise",
    "country": "Accordiantica",
    "phoneNumber": "5555555555",
    "hotelRooms": [
        {
            "hotelsID": 2,
            "roomNumber": 1,
            "roomID": 3,
            "rate": 15.0,
            "petFriendly": false,
            "room": {
                "id": 3,
                "nickname": "Ancient Red Dragon",
                "layout": 3,
                "roomAmenities": [
                    {
                        "amenityID": 1,
                        "roomID": 3,
                        "amenity": null
                    },
                    {
                        "amenityID": 3,
                        "roomID": 3,
                        "amenity": null
                    }
                ],
                "hotelRooms": []
            }
        }
    ]
}`
