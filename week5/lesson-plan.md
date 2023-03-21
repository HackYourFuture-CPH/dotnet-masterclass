# Week 5 : Dependency injection and working with persisted data

## Pre-requisites:
Having a finished week 4 homework.

## Agenda

1. Q&A - 15m
2. Dependency injection - 20m
4. Data persistence - 20m

---

5. Break - 30m

---



## Exercise:

1. Create a Meal class. Add relevant properties - Headline, image url, body text, location & price.
Create an IMealService interface with `List<Meal> ListMeals` and `AddMeal(Meal meal)` methods.
Create a FileMealService that implements IMealService: 
  * "ListMeals()" method - reads and deserializes meals from the file
  * "AddMeal" method - have it save (persist) meals to a file.

Register `FileMealService` as service using dependency injection.
```
builder.Services.AddScoped<ISomething, Something>();
```
Create a simple API for adding and listing meals using the MealService.
```
app.MapGet("/meals", ([FromServices] IMealSharingService apb) => { ... });
app.MapPost("/meals", ([FromServices] IMealSharingService apb) => { ... });
```
