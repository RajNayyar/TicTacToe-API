# TicTacToe-API

#REGISTRATION:
----------------------------------------------------
[PUT] http://localhost:58499/api/CreateUser/

[From Body]
{
	"Name": "name",
	"UserName": "username"
}
-----------------------------------------------------


#GAME SESSION
-----------------------------------------------------
----> It would return an ACCESSTOKEN that can be used in the following:


[PUT] http://localhost:58499/api/GameSession/

--> in header---> Provide the ACCESSTOKEN 

- At a time only two ACCESSTOKEN can be registered on this API for player one and two.
- Third player cannot enter the session until one and two have left.,
------------------------------------------------------


#AT ANY POINT OF TIME IF YOU WANT TO CHECK THE STATUS OF THE SESSION
---------------------------------------------------------------------
[GET] http://localhost:58499/api/GameSession/

it would return the status of the game session


