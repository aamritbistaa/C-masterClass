//Build a Console Guest Book. Ask the user for their name and how many are 
//in their party. Keep track of how many peple are at the party. At the end,
//print out the guiest list and the total number of guests.

using Homework_MiniProject___Guest_Book;

GuestLogic.Welcome();

(List <string> guestsNameList, int totalGuest)= GuestLogic.AddAllGuest();

GuestLogic.DisplayAllGuest(guestsNameList);

GuestLogic.DisplayGuestCount(totalGuest);





/*
 * Welcome the user
 * Ask user for their name, and store it
 * Ask user for no of people in the group, and up the counter
 * Check if more users are comming
 * if not display the name and no of guest
 */