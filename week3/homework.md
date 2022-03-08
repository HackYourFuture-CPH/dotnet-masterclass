# Homework

## How to deliver homework 

Open this template repository  https://github.com/HackYourFuture-CPH/dotnet-masterclass and click on ![image](https://user-images.githubusercontent.com/6642037/115988976-3796da80-a5bc-11eb-9184-554a2218b2ae.png) and then create a copy of this structure on your own GitHub profile with the name ``hyf-dotnet-masterclass``

Create a PR to add your homework to the respective week folder like you are used to do in the web development course, and if you don't remember how to do hand in homework using Pull Requests, please check here https://github.com/HackYourFuture-CPH/JavaScript/blob/master/javascript1/week1/homework.md

## Homework exercises for Week #3

### 1. Make a new WebAPI project with a ConverterController
Either reuse an existing WebAPI project, or create a new.
Add a new controller called a "Converter" controller, with the route "converter".
Look at the built-in controller to see how it's done.

```dotnet new webapi```



### 2. Make a controller action to convert Gallons to Litres
Make a controller action that takes an int Gallons and returns an int in litres. (Multiply gallons with 0.26417 to get it in litres).


### 3. Make an action that converts Miles to kilometres
Input should be an int, in miles. Output should be an object with both the miles and the kilometres.
km=m*1.609.
Create the model to output as well (Mileage).


```csharp
//To return an object, do like this:

return new Mileage(){Miles=miles, Kilometers=km};
```


### Make an action that accepts HTTP Post
Make an action that accepts an HTTP Post, with a body that is an object with number and a unit, and returns the corresponding conversion.

```csharp

```

## Extra

### Additional conversions
Add additional conversions - pounds to kg, yards to meters, feet to cm and so on.
Either in separate methods or in a main Conversion action method.