# Async Hotel

## App Details:
A database of hotel&room information relevent to the company who owns the hotels, can be used for internal data management or for customer searches.

##Images:

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
