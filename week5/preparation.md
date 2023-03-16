# Week 5 - Preparation

## Dependency injection

## Data persistence

### General

An application creates data, then when application quits. What happens to the data? This is where data persistence comes into play. In computer science, persistence refers to the characteristic of state of a system that outlives the process that created it. When data is persisted it means that exact same data can be retrieved by an application when it is running again.

There are various ways of persisting data, here are few approaches:

- Saving data in a file.
- Saving your data to a local device database like MySQL, SQLite etc.
- Saving your data in a remote database like MySQL.
- Sending data to a server.
- Saving data to external storage, like a USB stick.

Format of the data that data can be saved to can differ and it usually depends on factors like:

- Technology - storage technologies have their own format or require you to send data in specific format (eg MongoDB uses JSON/BSON)
- Intention - some external system might require from you to store/export data in specific format eg [CSV](https://en.wikipedia.org/wiki/Comma-separated_values) format
- Type of data: The type of data being stored can determine the most appropriate format. Numerical data may be best stored in a format that preserves precision, such as a binary format, while text data may be best stored in a plain text format.
- Size of data: The size of the data can also influence the choice of format, as some formats are more efficient for storing large amounts of data than others. For example, binary formats are often used for storing large datasets, as they can compress data and save storage space.
- Security requirements: If the data contains sensitive or confidential information, a format that provides encryption or other security features may be necessary.

## Storing data on file system

Using `.NET` we can write and read from the file system. `File` is static class in .NET that provides static methods for the creation, copying, deletion, moving, and opening of a single file.

Most commonly used operations with `File` are Copy, Create, Delete, Open, Read. Almost all operations come with option to work with (text) lines, bytes, text. Some of the methods like Read and Write support asynchronous operations (eg `File.WriteAllTextAsync`)

Simple example of writing an file:

```csharp
File.WriteAllText("test.txt", "some text"); // without path
File.WriteAllText(@"C:\dev\test.txt", "some text"); // absolute path
await File.WriteAllTextAsync(@"C:\dev\aa\test.txt", "some text"); // async call
File.WriteAllText(@"X:\test.txt", "some text"); // ❌ drive X does not exist, this will throw an IO error
```

> Note: if path is not exist or you don’t have permissions to write to the folder or file .NET will throw an IO Exception.
> 

🏗️**Task:**

- Try persisting text to a file.
- Find a method in `File` class that you can use to append text to the file from previous step. Try using VSCode intelligence before searching in google.

## More

## **Comparison with JS**

## Links

- [https://en.wikipedia.org/wiki/Persistence_(computer_science)](https://en.wikipedia.org/wiki/Persistence_(computer_science))
- [https://www.mongodb.com/databases/data-persistence](https://www.mongodb.com/databases/data-persistence)
- [https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/walkthrough-persisting-an-object-in-visual-studio](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/walkthrough-persisting-an-object-in-visual-studio)

