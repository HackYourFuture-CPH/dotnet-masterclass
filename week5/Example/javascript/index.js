fetch = require("node-fetch-commonjs");

(async function () {
  try {
    const users = await getUsers();

    users
      .slice(0, 3)
      .map((user) => user.first_name)
      .forEach((firstName) => console.log(firstName));
  } catch (err) {
    console.log(err);
  }
})();

async function getUsers() {
    const response = await fetch("https://reqres.in/api/users");
    const data = await response.json();
    const users = await data.data;
    
    return users;
}

