# WordsGame
Simple Web Application to explore some .NET technologies

Simple game of words where the system will show the user a random letter, and the user will have 30 secs to input words that begin with that letter. Words cannot be repeated, but they can be any sequence of characters, so there is no checking if the sequence is an actual word.

Internally this app contains a basic Authentication (using IdentityFramework) that validates the user is properly authenticated and a very basic Authorization. The backend contains a WebAPI implementation (which is also integrated with the Auth schema) but this implementation resides in the same Web Application (ideally this should be deployed in a different server to to validate auth works across servers)
