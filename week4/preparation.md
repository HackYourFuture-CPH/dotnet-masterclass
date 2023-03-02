# Week 4 - preparation: Async and await

We are going to learn some new concepts this week.
I suggest going over the following material:

- [Task asynchronous programming model](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)
- [Asynchronous programming](https://learn.microsoft.com/en-gb/dotnet/csharp/asynchronous-programming/async-scenarios)
- [Video: Introduction To Async, Await, And Tasks](https://www.youtube.com/watch?v=X9N5r6kMOxw)

- [Async explained with common scenario](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming)
## What is async/await?
Async/await is a feature in C# that allows you to write asynchronous code that is easy to read and understand. Asynchronous code is code that can perform multiple tasks concurrently, which can help improve performance and responsiveness in certain situations, such as when making web requests or accessing a database.

The `async` keyword is used to define a method as asynchronous, and the `await` keyword is used to pause the execution of the method until a task is complete. When the method is paused, control is returned to the calling method, allowing other code to execute. When the awaited task is complete, the method resumes execution.

Here's an example of how you might use async/await in C#:

```csharp
async Task<string> GetDataAsync()
{
    var client = new HttpClient();
    var response = await client.GetAsync("https://example.com/data");
    var result = await response.Content.ReadAsStringAsync();
    return result;
}
```

In this example, the `GetDataAsync` method is defined as asynchronous using the `async` keyword. Inside the method, an instance of the HttpClient class is created and used to make a web request to the URL "`https://example.com/data`". The `await` keyword is used to pause execution of the method until the web request completes. Once the request is complete, the response is read using the `ReadAsStringAsync` method and the result is returned.

## What is a task?
A `Task` is an object that represents some work that should be done. The task can tell you if the work is completed and if the operation returns a result, the task gives you the result. Shortly, a `Task` represents an asynchronous operation that may or may not return a value.

A `Task` is a way of representing work that needs to be done asynchronously. When a method returns a `Task`, it means that the method is doing some work in the background and will notify the caller when it is finished. The caller can then continue with other work while the background task is being executed.

Here's an example of how to create and use a `Task` in C#:

```csharp
using System.Threading.Tasks;

async Task<string> GetDataAsync(string url)
{
    var client = new HttpClient();
    var response = await client.GetAsync(url);
    var result = await response.Content.ReadAsStringAsync();
    return result;
}

async void UseTask()
{
    var url = "https://example.com";
    Task<string> task = GetDataAsync(url);

    // Do some other work while the task is being executed.

    var result = await task;
    // Use the result when the task is complete.
}

```

In this example, the `GetDataAsync` method is defined to return a `Task<string>`, indicating that it is an asynchronous operation that will return a `string`. The method uses the `HttpClient` class to make a web request and returns the result as a `string`.

The `UseTask` method creates a `Task<string>` by calling `GetDataAsync`. While the task is being executed, the method can do other work. Once the task is complete, the result is obtained using the `await` keyword and can be used for further processing.

## Working with async/await

There are situations where you need to retrieve multiple pieces of data concurrently. The `Task` class contains two methods, `Task.WhenAll` and `Task.WhenAny`, that allow you to write asynchronous code that performs a non-blocking wait on multiple background jobs.

This example shows how you might grab User data for a set of userIds.

```csharp
async Task<User> GetUserAsync(int userId)
{
    // Code omitted:
    //
    // Given a user Id {userId}, retrieves a User object corresponding
    // to the entry in the database with {userId} as its Id.
}

async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
{
    var getUserTasks = new List<Task<User>>();
    foreach (int userId in userIds)
    {
        getUserTasks.Add(GetUserAsync(userId));
    }

    return await Task.WhenAll(getUserTasks);
}
```