# Week 1 - lesson plan

## Agenda

- Q&A about preparation materials
- Let's take a look at preparation materials (Ivan)
- Let's talk about C# Fundamentals
  - Methods (Ivan)
  - Generics (Ivan)
  - Lists (Calin)

## Exercises

### 1. Caclulator
Make a `GET` endpoint that will take parameter `number1` and `number2` and based on `operation` parameter will perform one of following operations: addition, substraction, multiplication. If number1 or number2 are not a number return bad request response. For operation valid values are `add`, `substract`, `multiplay`. 
Example: `GET /calculate?number1=5&number2=10&operation=add` would return 15 as a result.

### 2. [Method + Generic Method]

### 3. Distinct alphabetical list
Make a `POST` endpoint that takes a list of strings as input and returns a new list containing only the unique elements, sorted in alphabetical order. For example, if the input list is `["apple", "banana", "cherry", "apple", "date", "banana"]`, the output should be `["apple", "banana", "cherry", "date"]`.

### 4. Word Frequency Count
Write a `GET` endpoint that takes a `string` as input and counts the frequency of each word in the `string`. 
Your program should output a list of `objects` where each `object` contains a word and its frequency. 
For example, if the input string is "the quick brown fox jumps over the lazy dog", your program should output the following list:
`[("the", 2), ("quick", 1), ("brown", 1), ("fox", 1), ("jumps", 1), ("over", 1), ("lazy", 1), ("dog", 1)]`
