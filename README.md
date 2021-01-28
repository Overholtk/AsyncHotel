# Async Hotel

## App Details:
A database of hotel&room information relevent to the company who owns the hotels, can be used for internal data management or for customer searches.

## Images:

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