CSCE 470 Project: The Baconator
By: Nick Rubenstein and Stephen Dawkins

All code is in C# and can be ran in Visual Studio 2010.

The .list files from IMDB are too large to go into the GitHub, so ActorsFileParser.cs cannot be ran

ActorsFileParser.cs		Takes the .list files from the IMDB repo and converts them into .txt files we can use easier.
				Note: TV shows and movies are removed as well as any actor that only appears in TV show or movies

LoadActorFilmsInMemory.cs	Reads in files in the format the ActorsFileParser.cs outputs to store in memory.

DegreeOfSeparationTest.cs	Using a sample of 10 famous actors, this file tests our main algorithm of assigning degrees of 
				separtaions from one actor to another
				Note: the smallactors.txt file must be in the same directory as the program file

smallactors.txt			Text document of the top 10 most famous actors used for testing