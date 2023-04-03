# Week 7 : Connecting frontend and backend

## Pre-requisites:

Having a finished week 6 homework and **Preparation**.

## Agenda

1. Q&A - 30m
2. Go over the setup from the preparation

## Task

Continue working on mealsharing project from the preparation. 
1. Meals
  * Create an endpoint for fetching/searching the meals - endpoint route should be based on the needs of your frontend. In most cases it's `GET /api/meals` (if you followed preparation you already have this endpoint that is returning dummy data).
  * Create `IMealRepository` interface with `Search()` method and implement it as a class `MealRepository`.
  * Call `IMealRepository` from the endpoint and test it from the UI.
  * Try extending Search with `string filterCriteria`
2. Implement reservations
