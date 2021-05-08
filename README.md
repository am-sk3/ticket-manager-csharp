# ticket-manager-csharp
Conversion of old Typescript project to .NET Core API

### This project is a conversion from an old project i've made when finishing a Backend Developer course. ###

Since i do not work with node at the moment, my prefered programming language of choice is C#.

This project is mostly a test to my capabilities and see what can i improve with the knowledge i've gathered over the last year.

This is just an ideia that i had and want to test out how it works in a platform that i have more confidence now.

## The project consists of the following: ##

- Create tickets assigned to certain users
- companies (aKa client) associated with a user (user account)
- The users should be able to see all the opened tickets from their companies (users can be in more than one company)
- Tickets should have comments, which are the replies made to the original ticket.
- Different users can reply to the tickets and that must be saved in the database.
- There should be an email parsing where sending an email without a certain prefix, will create a ticket automatically and reply to that user with the ticket number that has been opened.

This parsing should be made in intervals of 5 minutes, and should manage the emails on the server (get the email, read, parse attachements and delete de email from the server to save on space)

The original email should be converted to a ticket, with the body of the HTML intact (including attachments if possible).

All the replies received with the ticket prefix should be parsed as a reply and assigned to the original ticket.

This project will also be an experience to try out new stuff and organization since i am still a very junior developer, and as such i want to re-do it all over again.
