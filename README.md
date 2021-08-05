# GoldBadgeChallenges

Three Console Applications using C# and .NET Framework with libraries simulating the 
[repository pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) 
and unit tests for the repositories.

## 01_Cafe

> Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu.

The menu repository is wrapper for `System.Collections.Generic.List`, but indexed starting at 1 and enforces the menu number properties on `Add` and `Delete` so that 
the menu items are numbered in order.

## 02_Claims

> Komodo has a bug in its software and needs some new code. Komodo allows an insurance claim to be made up to 30 days after an incident took place. 
If the claim is not in the proper time limit, it is not valid.

The claims repository is wrapper for `System.Collections.Generic.Queue`. 
In this project, I got more comfortable creating small methods in the ProgramUI to get specific pieces of input which makes the parent method much cleaner.

## 03_Badges

> Komodo Insurance is fixing their badging system. Here's what they need: An app that maintains a dictionary of details about employee badge information. 
Essentially, a badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. 
A claims agent might have access to B2 & B4.

The badges repository is wrapper for `System.Collections.Generic.Dictionary` and provides both `Add` and `AddSafe` methods to add badges to the repository. 
In this project, I was getting comfortable with the collections interfaces. 
I made use of the `IEnumerable` interface as a great generic parameter type to pass in any type of collection when it was only needed for a foreach loop. 

In the ProgramUI, I continued making smaller methods for getting user input but this time making sure no input is passed in that causes runtime exceptions. 
The `AskForID` method loops until a valid integer is able to be parsed. The `AskForDoors` method trims whitespace and rejects empty strings.
