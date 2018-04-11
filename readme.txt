
--| DS Gadget 1.6
--| https://github.com/JKAnderson/DS-Gadget

A multi-purpose testing tool for Dark Souls 1. This program is only compatible with the current Steam version of DS1.
Requires .NET 4.6.2: https://www.microsoft.com/net/download/thank-you/net462

--| Changelog

1.6
	Added new hotkeys: Quit to Menu, Move Up, Move Down, Toggle No Death
	Option to store HP with position now includes stamina and death cam state
	Said option is now in the Players tab where it should have been anyways
	Closing the app should no longer require quitting and loading to completely clear modifications
	Fix no death and speed being overwritten in some cases (heck off Manus)
	Fix crash if not connected to internet

1.5
	Camera state is now stored along with position
	Fixed body type being overwritten

1.4
	HP can now be edited
	Added option to store and restore HP along with position (ur welcome Milt :V)
	Fixed missing bonfire ID for Seath's prison (again)

1.3
	Hotkeys can be globally enabled or disabled
	Hotkeys can be passed to the game as well or not
	Hotkeys can be unbound with escape
	Cheats have tooltips now
	Fixed filter turning on when you close the app

1.2
	Permanent changes are now cleaned up on app exit; quit out to clear the rest
	App indicates if there's an update available
	Window position is saved
	Settings actually work now
	Ambiguous items like Firekeeper Souls are no longer ambiguous

1.1
	Fixed maxing your stats against your will

1.0
	Reorganized and expanded cheats
	Added phantom and team type
	Added missing Painted World respawn

--| Credits

Wulf's Dark Souls Gizmo by Wulf2k
https://github.com/Wulf2k/DaS-PC-Overlay

Fasm.NET by Jämes Ménétrey
https://github.com/ZenLulz/Fasm.NET

LowLevelHooking by Joseph N. Musser II
https://github.com/jnm2/LowLevelHooking

Octokit by GitHub
https://github.com/octokit/octokit.net

Semver by Max Hauser
https://github.com/maxhauser/semver
