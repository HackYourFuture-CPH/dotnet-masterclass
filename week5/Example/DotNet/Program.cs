using System.Text.Json;
using System.Text.Json.Serialization;

try
{
    List<User> users = await FetchUsers();

    foreach (User user in users.Take(3))
    {
        Console.WriteLine(user.FirstName);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
}

async Task<List<User>> FetchUsers()
{
    var fetchClient = new HttpClient();
    var data = await fetchClient.GetStringAsync("https://reqres.in/api/users");
    var userInfo = JsonSerializer.Deserialize<UserInfoList>(data);
        
    return userInfo.UserList;
}

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }

    public class UserInfoList
    {
        [JsonPropertyName("data")]
        public List<User> UserList { get; set; }
    }